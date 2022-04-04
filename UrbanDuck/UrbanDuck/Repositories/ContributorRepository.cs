using Microsoft.EntityFrameworkCore;
using UrbanDuck.Data;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;

namespace UrbanDuck.Repositories
{
    public class ContributorRepository : BaseRepository<Contributor>, IContributorRepository
    {
        public ContributorRepository(DatabaseContext context) : base(context) { }

        public async Task<Contributor> GetContributorWithListings(int contributorId)
        {
            return await _context.Contributors.Where(x => x.Id == contributorId).Include(x => x.Listings).FirstOrDefaultAsync();
        }
    }
}
