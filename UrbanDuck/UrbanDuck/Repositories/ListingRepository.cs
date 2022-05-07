using Microsoft.EntityFrameworkCore;
using UrbanDuck.Data;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;

namespace UrbanDuck.Repositories
{
    public class ListingRepository : BaseRepository<Listing>, IListingRepository
    {
        public ListingRepository(DatabaseContext context) : base(context) { }

        public async Task<Listing> GetListingWithData(int listingId)
        {
            return await _context.Listings.Where(x => x.Id == listingId)
                .Include(x => x.Contributor)
                .FirstOrDefaultAsync();
        }
    }
}
