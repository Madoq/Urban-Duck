using Microsoft.EntityFrameworkCore;
using UrbanDuck.Data;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;

namespace UrbanDuck.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(DatabaseContext context) : base(context)
        {

        }
        public async Task<Booking> GetBookingById(int id)
        {
            return await _context.Bookings.Where(b => b.Id == id)
                .Include(b => b.Listing)
                .FirstOrDefaultAsync();
        }
    }
}
