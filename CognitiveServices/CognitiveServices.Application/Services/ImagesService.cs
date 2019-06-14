using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Application.Common.Interfaces.Validation;
using CognitiveServices.Application.Services.Interfaces;
using CognitiveServices.Domain.Entities;
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

        public async Task<IEnumerable<ImageDto>> GetAllAsync()
        {
            var imageEntities = await _context.Images
                .Include(n => n.ImageCategories)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ImageDto>>(imageEntities);
        }

        public async Task<ImageDto> CreateAsync(CreateImageDto dto)
        {
            await Task.Delay(1000);
            return new ImageDto();
            await _validator.ValidateAsync<UpsertImageDto>(dto);

            var imageEntity = _mapper.Map<ImageEntity>(dto);

            await _context.Images.AddAsync(imageEntity);

            await _context.SaveChangesAsync();

            return _mapper.Map<ImageDto>(imageEntity);
        }

    }
}
