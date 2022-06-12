using DataLayer.Dtos.ArticleDtos;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IArticleService
    {
        public Task<bool> CreateAsync(Article entity);
        public Task<IEnumerable<Article>> GetAllAsync();
        public Task<IEnumerable<Article>> GetAllArticlesByAuthorIdAsync(Guid authorId);
        public Task<IEnumerable<Article>> GetAllArticlesByCurriculumIdAsync(Guid curriculumId);
        public Task<Article> GetByArticleIdAsync(Guid id);
        public bool Delete(Article entity);
    }
}
