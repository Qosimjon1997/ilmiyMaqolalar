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
    public class AuthorRepo : ICreate<Author>, IRead<Author>, IReadRange<Author>, IDelete<Author>, ICountOnly
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CountArticle(Guid id)
        {
            return _dbContext.Articles.Count(x => x.AuthorId == id);
        }

        public async Task<bool> CreateAsync(Author entity)
        {
            await _dbContext.Authors.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public bool Delete(Author entity)
        {
            _dbContext.Authors.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _dbContext.Authors.OrderBy(x => x.Secondname).ThenBy(x => x.Firstname).ToListAsync();
        }

        public async Task<Author> GetByIdAsync(Guid id)
        {
            return await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
