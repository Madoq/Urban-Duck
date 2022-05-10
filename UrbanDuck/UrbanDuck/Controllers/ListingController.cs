using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;
using UrbanDuck.Services;

namespace UrbanDuck.Controllers
{
    public class ListingController : Controller
    {
        private readonly IListingService _listingService;
        private readonly UserManager<User> _userManager;
        public ListingController(IListingService listingService, UserManager<User> userManager)
        {
            _listingService = listingService;
            _userManager = userManager;
        }

        // GET: Transaction/AddOrEdit(Insert)
        // GET: Transaction/AddOrEdit/5(Update)
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
            if (true)//ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    await _listingService.Create(model);
                }
                //Update
                else
                {
                    await _listingService.Edit(model);
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", (await _listingService.GetAll()).ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddEditMyListings", model) });
        }

        public async Task<IActionResult> Index()
        {
            return View(await _listingService.GetAll());
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _listingService.Delete(id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _listingService.GetAll()) });
        }

        //[HttpGet("Listing/AddEditMyListings")]
        //public async Task<IActionResult> AddEditMyListings()
        //{
        //    return View();
        //}

        //[HttpGet("Listing/AddEditMyListings/{id:int}")]
        //public async Task<IActionResult> AddEditMyListings(int id = 0)
        //{
        //    var model = await _listingService.GetById(id);
        //    return View(model);
        //}

        //[HttpGet("Listing")]
        public async Task<IActionResult> All()
        {
            return View(await _listingService.GetAll());
        }


        [HttpGet("Listing/Available")]
        public async Task<IActionResult> Available()
        {
            return View(await _listingService.GetByConditions(l => l.Booking.Count < l.Amount));
        }

        [HttpGet("Listing/MyListings")]
        public async Task<IActionResult> MyListings()
        {
            return View(await _listingService.GetByConditions(l => l.Contributor.UserId == int.Parse(_userManager.GetUserId(User))));
        }

        //[HttpGet("Listing/{id:int}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    return View(await _listingService.GetById(id));
        //}

        [HttpGet("Listing/Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Listing model)
        {
            await _listingService.Create(model);
            return RedirectToAction("GetById", new { id = model.Id });
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _listingService.Delete(id);
        //    return RedirectToAction("All");
        //}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _listingService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Listing model)
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
