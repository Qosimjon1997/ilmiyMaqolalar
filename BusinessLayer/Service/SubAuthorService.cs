using BusinessLayer.IService;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class SubAuthorService : ISubAuthorService
    {
        private readonly ICreateRange<SubAuthor> _createRange;
        private readonly IDeleteRange<SubAuthor> _deleteRange;
        private readonly IReadSubAuthor _readSubAuthor;
        private readonly IRead<SubAuthor> _read;

        public SubAuthorService(ICreateRange<SubAuthor> createRange, IDeleteRange<SubAuthor> deleteRange, IReadSubAuthor readSubAuthor, IRead<SubAuthor> read)
        {
            _createRange = createRange;
            _deleteRange = deleteRange;
            _readSubAuthor = readSubAuthor;
            _read = read;
        }

        public async Task<bool> CreateRangeAsync(IEnumerable<SubAuthor> entity)
        {
            return await _createRange.CreateRangeAsync(entity);
        }

        public bool Delete(IEnumerable<SubAuthor> entity)
        {
            return _deleteRange.DeleteRange(entity);
        }

        public async Task<IEnumerable<SubAuthor>> GetByArticleIdAsync(Guid id)
        {
            return await _readSubAuthor.GetByArticleIdAsync(id);
        }

        public async Task<IEnumerable<SubAuthor>> GetByAuthorIdAsync(Guid id)
        {
            return await _readSubAuthor.GetByAuthorIdAsync(id);
        }

        public async Task<SubAuthor> GetByIdAsync(Guid id)
        {
            return await _read.GetByIdAsync(id);
        }
    }
}
