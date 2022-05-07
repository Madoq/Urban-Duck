using UrbanDuck.Models;

namespace UrbanDuck.Interfaces
{
    public interface IListingRepository : IBaseRepository<Listing>
    {
        public Task<Listing> GetListingWithData(int listingId);
    }
}
