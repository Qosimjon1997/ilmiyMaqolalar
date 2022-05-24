using AutoMapper;
using DataLayer.Dtos.AuthorDtos;
using DataLayer.Models;

namespace DataLayer.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorReadDto>();
            CreateMap<AuthorCreateDto, Author>();
        }
    }
}
