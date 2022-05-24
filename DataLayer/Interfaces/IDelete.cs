using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IDelete<T>
    {
        public bool Delete(T entity);
    }
}
