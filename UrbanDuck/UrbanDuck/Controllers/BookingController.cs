using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;

namespace UrbanDuck.Controllers
{
    public class BookingController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService, UserManager<User> userManager)
        {
            _bookingService = bookingService;
            _userManager = userManager;
        }

        [HttpGet("Booking/User/")]
        public async Task<IActionResult> All()
        {
            return View(await _bookingService.GetByConditions(b => b.UserId == int.Parse(_userManager.GetUserId(User))));
        }

        [HttpGet("Booking/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return View(await _bookingService.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int userId, int listingId)
        {
            await _bookingService.Create(new Booking { UserId = userId, ListingId = listingId });
            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookingService.Delete(id);
            return RedirectToAction("All");
        }
    }
}
