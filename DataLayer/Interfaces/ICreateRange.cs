using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ICreateRange<T>
    {
        public Task<bool> CreateRangeAsync(IEnumerable<T> entity);
    }
}
