using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IReadSubAuthor
    {
        public Task<IEnumerable<SubAuthor>> GetByArticleIdAsync(Guid id);
        public Task<IEnumerable<SubAuthor>> GetByAuthorIdAsync(Guid id);
    }
}
