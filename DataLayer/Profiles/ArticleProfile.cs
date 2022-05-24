using AutoMapper;
using DataLayer.Dtos.ArticleDtos;
using DataLayer.Models;

namespace DataLayer.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleReadDto>();
            CreateMap<ArticleCreateDto, Article>();
        }
    }
}
