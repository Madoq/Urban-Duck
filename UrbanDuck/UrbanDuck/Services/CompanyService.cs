using System.Linq.Expressions;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;
using UrbanDuck.Repositories;

namespace UrbanDuck.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> GetById(int id)
        {
            return await _companyRepository.GetCompanyWithAddresses(id);
        }
        public async Task<IEnumerable<Company>> GetByConditions(Expression<Func<Company, bool>> expresion)
        {
            return await _companyRepository.FindByConditions(expresion);
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _companyRepository.FindAll();
        }

        public async Task<Company> Create(Company model)
        {
            return await _companyRepository.Create(model);
        }
        public async Task Delete(int id)
        {
            var model = await GetById(id);
            if (model != null) await _companyRepository.Delete(model);
        }

        public async Task Edit(Company model)
        {
            await _companyRepository.Edit(model);
        }
    }
}
