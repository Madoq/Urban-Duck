using Microsoft.EntityFrameworkCore;
using UrbanDuck.Data;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;

namespace UrbanDuck.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(DatabaseContext context) : base(context) { }

        public async Task<Company> GetCompanyWithAddresses(int companyId)
        {
            return await _context.Companies.Where(x => x.Id == companyId).Include(x => x.Addresses).FirstOrDefaultAsync();
        }
    }
}
