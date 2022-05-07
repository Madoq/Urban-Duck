using UrbanDuck.Models;

namespace UrbanDuck.Interfaces
{
    public interface IContributorRepository : IBaseRepository<Contributor>
    {
        public Task<Contributor> GetContributorWithListings(int companyId);
    }
}
