using UrbanDuck.Models;

namespace UrbanDuck.Interfaces
{
    public interface ICompanyService
    {
        public Task<Company> GetCompany(int id);
        public Task<IEnumerable<Company>> GetAllCompanies();
        public Task<Company> CreateCompany(Company company);
        public Task DeleteCompany(int id);
    }
}
