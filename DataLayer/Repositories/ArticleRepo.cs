using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ArticleRepo : ICreate<Article>, IDelete<Article>, IReadRange<Article>, IRead<Article>
    {
        private readonly ApplicationDbContext _dbContext;

        public ArticleRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateAsync(Article entity)
        {
            await _dbContext.Articles.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public bool Delete(Article entity)
        {
            _dbContext.Articles.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _dbContext.Articles.ToListAsync();
        }

        public async Task<Article> GetByIdAsync(Guid id)
        {
            return await _dbContext.Articles.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
