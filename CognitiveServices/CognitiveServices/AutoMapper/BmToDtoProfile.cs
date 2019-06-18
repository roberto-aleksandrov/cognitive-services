using AutoMapper;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Common.Models.Dtos;
using CognitiveServices.AutoMapper.Converters;
using CognitiveServices.Models.BindingModels;

namespace CognitiveServices.AutoMapper
{
    public class BmToDtoProfile : Profile
    {
        public BmToDtoProfile()
        {
            AllowNullCollections = true;

            CreateMap<UpsertImageBindingModel, CreateImageDto>()
                .ForMember(req => req.Content, opt => opt.ConvertUsing(new FormFileToByteArrayConverter()));

            CreateMap<UpsertImageBindingModel, UpdateImageDto>()
                .ForMember(req => req.Content, opt => opt.ConvertUsing(new FormFileToByteArrayConverter())); ;
        }
    }
}
