using System;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IRead<T>
    {
        public Task<T> GetByIdAsync(Guid id);
    }
}
