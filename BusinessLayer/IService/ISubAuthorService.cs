using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface ISubAuthorService
    {
        public Task<bool> CreateRangeAsync(IEnumerable<SubAuthor> entity);
        public Task<SubAuthor> GetByIdAsync(Guid id);
        public Task<IEnumerable<SubAuthor>> GetByArticleIdAsync(Guid id);
        public Task<IEnumerable<SubAuthor>> GetByAuthorIdAsync(Guid id);
        public bool Delete(IEnumerable<SubAuthor> entity);
    }
}
