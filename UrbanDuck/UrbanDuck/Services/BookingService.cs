using EmailService;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using System.Security.Claims;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;

namespace UrbanDuck.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IEmailSenderService emailSender;
        private readonly UserManager<User> userManager;

        public BookingService(IBookingRepository bookingRepository, IEmailSenderService emailSender, UserManager<User> userManager)
        {
            this.bookingRepository = bookingRepository;
            this.emailSender = emailSender;
            this.userManager = userManager;
        }
        public async Task<Booking> Create(Booking model)
        {
            await BookingConfirmationEmail(model);
            return await(bookingRepository.Create(model));
        }

        public async Task Delete(int id)
        {
            var model = await GetById(id);
            await BookingCacelationEmail(model);
            if (model != null) await bookingRepository.Delete(model);
        }

        public async Task Edit(Booking model)
        {
            await bookingRepository.Edit(model);
        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await bookingRepository.FindAll();
        }

        public async Task<IEnumerable<Booking>> GetByConditions(Expression<Func<Booking, bool>> expresion)
        {
            return await bookingRepository.FindByConditions(expresion);
        }

        public async Task<Booking> GetById(int id)
        {
            return await bookingRepository.GetBookingById(id);
        }

        private async Task BookingCacelationEmail(Booking booking)
        {
            var user = userManager.FindByIdAsync(booking.UserId.ToString());
            string userEmail = await userManager.GetEmailAsync(user.Result);
            string content =
                $"We've canceleed your booking: \n" +
                $"Booking id: {booking.Id}\n" +
                $"Listing: {booking.Listing.Title}\n";
            var message = new Message(new List<string>() { userEmail }, "Urban Duck booking cancelation", content, null);
            await emailSender.SendEmailAsync(message);
        }

        private async Task BookingConfirmationEmail(Booking booking)
        {
            var user = userManager.FindByIdAsync(booking.UserId.ToString());
            string userEmail = await userManager.GetEmailAsync(user.Result);
            string content =
                $"Here's your booking details: \n" +
                $"Booking id: {booking.Id}\n" +
                $"Listing: {booking.Listing.Title}\n" +
                $"Description: {booking.Listing.Description}\n" +
                $"Amount: {booking.Listing.Amount}\n" +
                $"Price: {booking.Listing.Price}";
            var message = new Message(new List<string>() { userEmail }, "Urban Duck booking confirmation", content, null);
            await emailSender.SendEmailAsync(message);
        }
    }
}
