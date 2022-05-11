using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;

namespace UrbanDuck.Controllers
{
    [Route("api")]
    [ApiController]
    public class ListingApiController : ControllerBase
    {
        private readonly IListingService _listingService;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ListingApiController> _logger;

        public ListingApiController(IListingService listingService, UserManager<User> userManager, ILogger<ListingApiController> logger)
        {
            _listingService = listingService;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet("Listing")]
        public async Task<IEnumerable<Listing>> All()
        {
            _logger.LogInformation("API - all listings");
            return await _listingService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("Listing/Available")]
        public async Task<IEnumerable<Listing>> Available()
        {
            _logger.LogInformation("API - all available listings");
            return await _listingService.GetByConditions(l => l.Booking.Count < l.Amount);
        }

        [HttpGet("Listing/MyListings")]
        public async Task<IEnumerable<Listing>> MyListings()
        {
            _logger.LogInformation("API - my listings");
            return await _listingService.GetByConditions(l => l.Contributor.UserId == int.Parse(_userManager.GetUserId(User)));
        }

        [HttpGet("Listing/{id:int}")]
        public async Task<Listing> GetById(int id)
        {
            _logger.LogInformation("API - get listing by id");
            return await _listingService.GetById(id);
        }
    }
}
