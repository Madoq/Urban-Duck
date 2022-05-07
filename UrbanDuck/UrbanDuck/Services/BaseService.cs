using System.Linq.Expressions;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;

namespace UrbanDuck.Services
{
    public class BaseService<T> : IBaseService<T> where T : IDbModel
    {
        protected readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetByConditions(Expression<Func<T, bool>> expresion)
        {
            return await _repository.FindByConditions(expresion);
        }

        public async Task<T> GetById(int id)
        {
            return (await _repository.FindByConditions(x => x.Id == id)).FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.FindAll();
        }

        public async Task<T> Create(T model)
        {
            return await _repository.Create(model);
        }
        public async Task Delete(int id)
        {
            var model = await GetById(id);
            if (model != null) await _repository.Delete(model);
        }

        public async Task Edit(T model)
        {
            await _repository.Edit(model);
        }
    }
}
