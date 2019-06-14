using AutoMapper;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.AutoMapper.Converters;
using CognitiveServices.Models.BindingModels;

namespace CognitiveServices.AutoMapper
{
    public class BmToDtoProfile : Profile
    {
        public BmToDtoProfile()
        {
            CreateMap<UpsertImageBindingModel, CreateImageDto>()
                .ForMember(req => req.Content, opt => opt.ConvertUsing(new FormFileToByteArrayConverter()));
        }
    }
}
