using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;
using UrbanDuck.Services;

namespace UrbanDuck.Controllers
{
    public class ListingController : Controller
    {
        private readonly IListingService _listingService;
        private readonly UserManager<User> _userManager;
        private readonly IContributorService _contributorService;
        private readonly IMemoryCache memoryCache;

        public ListingController(IListingService listingService, UserManager<User> userManager, IContributorService contributorService, IMemoryCache memoryCache)
        {
            _listingService = listingService;
            _userManager = userManager;
            _contributorService = contributorService;
            this.memoryCache = memoryCache;
        }

        public async Task<IActionResult> AddEditMyListings(int id = 0)
        {
            if (id == 0)
                return View(new Listing());
            else
            {
                var model = await _listingService.GetById(id);
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditMyListings(int id, [Bind("Id,Title,Price,Amount,ContributorId,photoPath")] Listing model)
        {
            if (id == 0)
            {
                await _listingService.Create(model);
            }
            else
            {
                await _listingService.Edit(model);
            }
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", (await _listingService.GetAll()).ToList()) });
        }

        public async Task<IActionResult> Index()
        {
            var contributor = await _contributorService.GetByUserId(int.Parse(_userManager.GetUserId(User)));
            if (contributor != null) return View(await _listingService.GetByConditions(l => l.ContributorId == contributor.Id));
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _listingService.Delete(id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _listingService.GetAll()) });
        }

        [HttpGet("Listing/All")]
        public async Task<IActionResult> All()
        {
            var cacheKey = "listings";
            if (!memoryCache.TryGetValue(cacheKey, out IEnumerable<Listing> listings))
            {
                listings = await _listingService.GetAll();
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromMinutes(2)
                };
                memoryCache.Set(cacheKey, listings, cacheExpiryOptions);
            }
            return View(listings);
        }

        [HttpGet("Listing/All/Available")]
        public async Task<IActionResult> Available()
        {
            return View(await _listingService.GetByConditions(l => l.Booking.Count < l.Amount));
        }

        public async Task<IActionResult> GetById(int id)
        {
            return View(await _listingService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DetailsDelete(int id)
        {
            await _listingService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DetailsEdit(int id)
        {
            return View(await _listingService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DetailsEdit(Listing model)
        {
            await _listingService.Edit(model);
            return RedirectToAction("GetById", new { id = model.Id });
        }

        [HttpGet("Listing/AddPhoto")]
        public async Task<IActionResult> AddPhoto(int id)
        {
            return View(new PhotoUploadModel { listingId = id });
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoto(PhotoUploadModel model)
        {
            await _listingService.AddPhoto(model);
            return RedirectToAction("GetById", new { id = model.listingId });
        }
    }
}
