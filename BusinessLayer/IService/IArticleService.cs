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
        public Task<Article> GetByArticleIdAsync(Guid id);
        public bool Delete(Article entity);
    }
}
