using BusinessLayer.IService;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly ICreate<Author> _create;
        private readonly IDelete<Author> _delete;
        private readonly IRead<Author> _read;
        private readonly IReadRange<Author> _readRange;
        private readonly ICount _count;

        public AuthorService(ICreate<Author> create, IDelete<Author> delete, IRead<Author> read, IReadRange<Author> readRange, ICount count)
        {
            _create = create;
            _delete = delete;
            _read = read;
            _readRange = readRange;
            _count = count;
        }

        public int CountOfArticle(Guid id)
        {
            var v = _count.Count(id);
            return v;
        }

        public async Task<bool> CreateAsync(Author author)
        {
            if (author == null)
            {
                return await Task.FromResult(false);
            }

            return await _create.CreateAsync(author);
        }

        public bool Delete(Author author)
        {
            if (author != null)
            {
                return _delete.Delete(author);
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _readRange.GetAllAsync();
        }

        public async Task<Author> GetByAuthorIdAsync(Guid id)
        {
            return await _read.GetByIdAsync(id);
        }
    }
}
