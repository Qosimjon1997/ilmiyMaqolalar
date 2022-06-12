using BusinessLayer.IService;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class CurriculumService : ICurriculumService
    {
        private readonly ICreate<Curriculum> _create;
        private readonly IDelete<Curriculum> _delete;
        private readonly IRead<Curriculum> _read;
        private readonly IReadRange<Curriculum> _readRange;
        private readonly ICountOnly _count;

        public CurriculumService(ICreate<Curriculum> create, IDelete<Curriculum> delete, IRead<Curriculum> read, IReadRange<Curriculum> readRange, ICountOnly count)
        {
            _create = create;
            _delete = delete;
            _read = read;
            _readRange = readRange;
            _count = count;
        }

        public int CountArticleInCurriculum(Guid curriculumId)
        {
            return _count.CountArticle(curriculumId);
        }

        public async Task<bool> CreateAsync(Curriculum curriculum)
        {
            if(curriculum == null)
            {
                return await Task.FromResult(false);
            }

            return await _create.CreateAsync(curriculum);
        }

        public bool Delete(Curriculum curriculum)
        {
            if (curriculum != null)
            {
                return _delete.Delete(curriculum);
            }
            else
            {
                return false;
            }

        }

        public async Task<IEnumerable<Curriculum>> GetAllAsync()
        {
            return await _readRange.GetAllAsync();
        }

        public async Task<Curriculum> GetByCurriculumIdAsync(Guid id)
        {
            return await _read.GetByIdAsync(id);
        }
    }
}
