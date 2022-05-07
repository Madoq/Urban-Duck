using System.Linq.Expressions;

namespace UrbanDuck.Interfaces
{
    public interface IBaseRepository<T>
    {
        public Task<T> Create(T model);
        public Task Delete(T model);
        public Task Edit(T model);
        public Task<IEnumerable<T>> FindAll();
        public Task<IEnumerable<T>> FindByConditions(Expression<Func<T, bool>> expresion);
    }
}
