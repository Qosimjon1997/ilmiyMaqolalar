using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IDeleteRange<T>
    {
        public bool DeleteRange(IEnumerable<T> entity);
    }
}
