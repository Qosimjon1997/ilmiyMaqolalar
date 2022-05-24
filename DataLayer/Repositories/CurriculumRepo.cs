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
    public class CurriculumRepo : ICreate<Curriculum>, IDelete<Curriculum>, IRead<Curriculum>, IReadRange<Curriculum>
    {
        private readonly ApplicationDbContext _dbContext;

        public CurriculumRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateAsync(Curriculum entity)
        {
            await _dbContext.Curriculums.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public bool Delete(Curriculum entity)
        {
            _dbContext.Curriculums.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Curriculum>> GetAllAsync()
        {
            return await _dbContext.Curriculums.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Curriculum> GetByIdAsync(Guid id)
        {
            return await _dbContext.Curriculums.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
