using AutoMapper;
using __Namespace__.__Service__.Core.Domain.Models;
using __Namespace__.__Service__.Data.Model.Models;

namespace __Namespace__.__Service__.Core.Domain.Mappers.Profiles
{
    public class __Service__Profile : Profile
    {
        public __Service__Profile()
        {
            CreateMap<__Service__Entity, __Service__Dto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.__Service__EntityId)); ;
            CreateMap<__Service__Dto, __Service__Entity>()
                .ForMember(dest => dest.__Service__EntityId, opt => opt.MapFrom(src => src.Id)); ;
        }
    }

}
