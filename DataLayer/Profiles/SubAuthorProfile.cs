using AutoMapper;
using DataLayer.Dtos.SubAuthorDtos;
using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.Profiles
{
    public class SubAuthorProfile : Profile
    {
        public SubAuthorProfile()
        {
            CreateMap<SubAuthor, SubAuthorReadDto>();
            CreateMap<IEnumerable<SubAuthorCreateDto>, IEnumerable<SubAuthor>>();
        }
    }
}
