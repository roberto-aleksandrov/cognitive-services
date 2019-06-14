using AutoMapper;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Domain.Entities;

namespace CognitiveServices.Application.Common.AutoMapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<CreateImageDto, ImageEntity>();
        }
    }
}
