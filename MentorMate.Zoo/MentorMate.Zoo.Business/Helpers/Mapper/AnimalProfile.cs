using AutoMapper;
using MentorMate.Zoo.Domain.Entities;
using MentorMate.Zoo.Business.DTOs.AnimalDTOs;

namespace MentorMate.Zoo.Business.Helpers.Mapper
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<Animal, AnimalResultDTO>()
                .ReverseMap();

            CreateMap<Animal, AnimalViewDTO>()
                .ReverseMap();

            CreateMap<Animal, AnimalAddDTO>()
                .ReverseMap();

            CreateMap<Animal, AnimalUpdateDTO>()
                .ReverseMap()
                .ForMember(a => a.Species, o => o.Ignore())
                .ForMember(a => a.Class, o => o.Ignore())
                .ForMember(a => a.Type, o => o.Ignore());

            CreateMap<AnimalValidateDTO, AnimalAddDTO>()
                .ReverseMap();

            CreateMap<AnimalValidateDTO, AnimalUpdateDTO>()
                .ReverseMap()
                .ForMember(a => a.Species, o => o.Ignore())
                .ForMember(a => a.Class, o => o.Ignore())
                .ForMember(a => a.Type, o => o.Ignore());
        }
    }
}
