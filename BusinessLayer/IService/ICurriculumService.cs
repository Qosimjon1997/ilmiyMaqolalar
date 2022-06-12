using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface ICurriculumService
    {
        public Task<bool> CreateAsync(Curriculum curriculum);
        public bool Delete(Curriculum curriculum);
        public Task<IEnumerable<Curriculum>> GetAllAsync();
        public Task<Curriculum> GetByCurriculumIdAsync(Guid id);
        public int CountArticleInCurriculum(Guid curriculumId);

    }
}
