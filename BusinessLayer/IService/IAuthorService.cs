using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IAuthorService
    {
        public Task<bool> CreateAsync(Author author);
        public Task<IEnumerable<Author>> GetAllAsync();
        public Task<Author> GetByAuthorIdAsync(Guid id);
        public bool Delete(Author article);
        public int CountOfArticle(Guid id);
    }
}
