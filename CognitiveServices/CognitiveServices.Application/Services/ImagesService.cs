using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Application.Common.Interfaces.Validation;
using CognitiveServices.Application.Common.Models.Dtos;
using CognitiveServices.Application.Services.Interfaces;
using CognitiveServices.Domain.Entities;
using Extensions;
using Microsoft.EntityFrameworkCore;

namespace CognitiveServices.Application.Services
{
    public class ImagesService : BaseService, IImagesService
    {
        public ImagesService(
            IValidationService validator,
            ICognitiveServicesDbContext context,
            IMapper mapper)
            : base(validator, context, mapper)
        {
        }

        public async Task<IEnumerable<ImageDto>> GetAllAsync(QueryDto dto)
        {
            var imageEntities = await ApplyQuery<ImageEntity>(dto).ToListAsync();

            return _mapper.Map<IEnumerable<ImageDto>>(imageEntities);
        }

        public async Task<ImageDto> GetByIdAsync(int id)
        {
            var imageEntity = await _context.Images.Include(n => n.ImageCategories).FirstAsync(n => n.Id == id);

            return _mapper.Map<ImageDto>(imageEntity);
        }

        public async Task<ImageDto> CreateAsync(CreateImageDto dto)
        {
            await _validator.ValidateAsync<UpsertImageDto>(dto);

            var imageEntity = _mapper.Map<ImageEntity>(dto);

            imageEntity.ImageCategories = dto.CategoryIds
                            .Select(n => new ImageCategoryEntity
                            {
                                CategoryId = n,
                                Image = imageEntity
                            }).ToList();

            await _context.Images.AddAsync(imageEntity);

            await _context.SaveChangesAsync();

            return _mapper.Map<ImageDto>(imageEntity);
        }

        public async Task<ImageDto> UpdateImage(UpdateImageDto dto)
        {
            await _validator.ValidateAsync(dto);

            var imageEntity = _context.Images
                        .Include(n => n.ImageCategories)
                        .First(n => n.Id == dto.Id);

            _mapper.Map(dto, imageEntity);

            var categoriesToAdd = dto.CategoryIds.Where(categoryId => imageEntity.ImageCategories.All(n => n.CategoryId != categoryId));
            var imgeCategoriesToDelete = imageEntity.ImageCategories.Where(n => !dto.CategoryIds.Contains(n.CategoryId));

            categoriesToAdd.ForEach(categoryId =>
                {
                    if (imageEntity.ImageCategories.All(n => n.CategoryId != categoryId))
                    {
                        imageEntity.ImageCategories.Add(new ImageCategoryEntity { CategoryId = categoryId, ImageId = imageEntity.Id });
                    }
                });

            _context.ImageCategories.RemoveRange(imgeCategoriesToDelete);

            await _context.SaveChangesAsync();

            return _mapper.Map<ImageDto>(imageEntity);
        }

        public async Task<ImageDto> DeleteAsync(DeleteImageDto deleteImageDto)
        {
            await _validator.ValidateAsync(deleteImageDto);

            var imageEntity = _context.Images.Remove(new ImageEntity { Id = deleteImageDto.Id.Value });

            await _context.SaveChangesAsync();

            return new ImageDto { Id = deleteImageDto.Id.Value };
        }

    }
}
