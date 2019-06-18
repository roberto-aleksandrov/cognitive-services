using System.Linq;
using AutoMapper;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Common.Models.Dtos;
using CognitiveServices.Domain.Entities;

namespace CognitiveServices.Application.Common.AutoMapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            AllowNullCollections = true;

            CreateMap<CreateImageDto, ImageEntity>();
            CreateMap<UpdateImageDto, ImageEntity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
