using AutoMapper;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Common.Models.Dtos;
using CognitiveServices.Domain.Entities;

namespace CognitiveServices.Application.Common.AutoMapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<ImageEntity, ImageDto>();
            CreateMap<CategoryEntity, CategoryDto>();
            CreateMap<ImageCategoryEntity, ImageCategoryDto>();
        }
    }
}
