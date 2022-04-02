using UrbanDuck.Interfaces;
using UrbanDuck.Models;

namespace UrbanDuck.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IBaseRepository<Company> _companyRepository;

        public CompanyService(IBaseRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> GetCompany(int id)
        {
            return (await _companyRepository.FindByConditions(x => x.Id == id)).FirstOrDefault();
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _companyRepository.FindAll();
        }

        public async Task<Company> CreateCompany(Company company)
        {
            return await _companyRepository.Create(company);
        }
        public async Task DeleteCompany(int id)
        {
            var CompanyToDelete = await GetCompany(id);
            if (CompanyToDelete != null) await _companyRepository.Delete(CompanyToDelete);
        }
    }
}
