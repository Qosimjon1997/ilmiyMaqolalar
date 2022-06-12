using BusinessLayer.IService;
using DataLayer.Dtos.ArticleDtos;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class ArticleService : IArticleService
    {
        private readonly ICreate<Article> _create;
        private readonly IDelete<Article> _delete;
        private readonly IRead<Article> _read;
        private readonly IReadRange<Article> _readRange;
        private readonly IArticle _article;

        public ArticleService(ICreate<Article> create, IRead<Article> read, IDelete<Article> delete, IReadRange<Article> readRange, IArticle article)
        {
            _create = create;
            _delete = delete;
            _read = read;
            _readRange = readRange;
            _article = article;
        }

        public async Task<bool> CreateAsync(Article entity)
        {
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            return await _create.CreateAsync(entity);
        }

        public bool Delete(Article entity)
        {
            if (entity != null)
            {
                return _delete.Delete(entity);
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Article>> GetAllArticlesByAuthorIdAsync(Guid authorId)
        {
            return await _article.GetAllArticlesByAuthorId(authorId);
        }

        public async Task<IEnumerable<Article>> GetAllArticlesByCurriculumIdAsync(Guid curriculumId)
        {
            return await _article.GetAllArticlesByCurriculumId(curriculumId);
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _readRange.GetAllAsync();
        }


        public async Task<Article> GetByArticleIdAsync(Guid id)
        {
            return await _read.GetByIdAsync(id);
        }
    }
}
