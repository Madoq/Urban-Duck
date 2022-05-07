using UrbanDuck.Models;

namespace UrbanDuck.Interfaces
{
    public interface IListingService : IBaseService<Listing>
    {
        public Task AddPhoto(PhotoUploadModel model);
    }
}
