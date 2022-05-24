using AutoMapper;
using DataLayer.Dtos.CurriculumDtos;
using DataLayer.Models;

namespace DataLayer.Profiles
{
    public class CurriculumProfile : Profile
    {
        public CurriculumProfile()
        {
            CreateMap<Curriculum, CurriculumReadDto>();
            CreateMap<CurriculumCreateDto, Curriculum>();
        }
    }
}
