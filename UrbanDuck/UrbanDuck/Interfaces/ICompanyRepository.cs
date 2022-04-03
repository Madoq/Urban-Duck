using UrbanDuck.Models;

namespace UrbanDuck.Interfaces
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        public Task<Company> GetCompanyWithAddresses(int companyId);
    }
}
