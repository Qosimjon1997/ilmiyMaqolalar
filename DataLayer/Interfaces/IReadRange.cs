using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IReadRange<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
    }
}
