using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class SubAuthorRepo : ICreateRange<SubAuthor>, IReadSubAuthor, IDeleteRange<SubAuthor>, IRead<SubAuthor>
    {
        private readonly ApplicationDbContext _dbContext;

        public SubAuthorRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateRangeAsync(IEnumerable<SubAuthor> entity)
        {
            await _dbContext.SubAuthors.AddRangeAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public bool DeleteRange(IEnumerable<SubAuthor> entity)
        {
            _dbContext.SubAuthors.RemoveRange(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<SubAuthor>> GetByArticleIdAsync(Guid id)
        {
            return await _dbContext.SubAuthors.Where(x => x.ArticleId == id).ToListAsync();
        }

        public async Task<IEnumerable<SubAuthor>> GetByAuthorIdAsync(Guid id)
        {
            return await _dbContext.SubAuthors.Where(x=>x.AuthorId == id).ToListAsync();
        }

        public async Task<SubAuthor> GetByIdAsync(Guid id)
        {
            return await _dbContext.SubAuthors.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
