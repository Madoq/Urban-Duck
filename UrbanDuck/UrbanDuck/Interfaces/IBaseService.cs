using System.Linq.Expressions;
using UrbanDuck.Models;

namespace UrbanDuck.Interfaces
{
    public interface IBaseService<T>
    {
        public Task<T> GetById(int id);
        public Task<IEnumerable<T>> GetByConditions(Expression<Func<T, bool>> expresion);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Create(T model);
        public Task Delete(int id);
        public Task Edit(T model);
    }
}
