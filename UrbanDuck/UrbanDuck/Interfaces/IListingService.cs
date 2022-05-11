using UrbanDuck.Models;

namespace UrbanDuck.Interfaces
{
    public interface IListingService : IBaseService<Listing>
    {
        public Task<bool> IsBookedByUser(int UserId, int ListingId);
        public Task AddPhoto(PhotoUploadModel model);
    }
}
