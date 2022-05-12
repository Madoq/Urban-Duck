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
            var result = await(bookingRepository.Create(model));
            await BookingConfirmationEmail(result);
            return result;
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
                $"<h2>We've canceled your booking:</h2>" +
                $"<div>Booking id: {booking.Id}</div>" +
                $"<div>Listing: {booking.Listing.Title}</div>" + 
                $"<div>Date and Time: {DateTime.Now}</div>";
            var message = new Message(new List<string>() { userEmail }, "Urban Duck booking cancelation", content, null);
            await emailSender.SendEmailAsync(message);
        }

        private async Task BookingConfirmationEmail(Booking booking)
        {
            var user = userManager.FindByIdAsync(booking.UserId.ToString());
            var userEmail = await userManager.GetEmailAsync(user.Result);
            Booking createdBooking = await bookingRepository.GetBookingById(booking.Id);
            string content =
                $"<h2>Here are your booking details:</h2>" +
                $"<div>Booking id: {createdBooking.Id}</div>" +
                $"<div>Listing: {createdBooking.Listing.Title}</div>" +
                $"<div>Description: {createdBooking.Listing.Description}</div>" +
                $"<div>Amount: {createdBooking.Listing.Amount}</div>" +
                $"<div>Price: {createdBooking.Listing.Price} $</div>" + 
                $"<div>Contributor: {createdBooking.Listing.Contributor.FirstName} {createdBooking.Listing.Contributor.LastName}</div>" + 
                $"<div>Date and Time: {DateTime.Now}</div>";
            var message = new Message(new List<string>() { userEmail }, "Urban Duck booking confirmation", content, null);
            await emailSender.SendEmailAsync(message);
        }
    }
}
