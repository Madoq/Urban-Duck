using UrbanDuck.Models;

namespace UrbanDuck.Interfaces
{
    public interface IContributorService : IBaseService<Contributor>
    {
        public Task<Contributor> GetByUserId(int id);
    }
}
