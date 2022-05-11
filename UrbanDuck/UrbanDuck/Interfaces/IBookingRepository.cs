using UrbanDuck.Models;

namespace UrbanDuck.Interfaces
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        public Task<Booking> GetBookingById(int id);
    }
}
