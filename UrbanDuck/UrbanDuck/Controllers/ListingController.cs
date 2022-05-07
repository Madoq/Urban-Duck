using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;
using UrbanDuck.Services;

namespace UrbanDuck.Controllers
{
    public class ListingController : Controller
    {
        private readonly IListingService _listingService;
        public ListingController(IListingService listingService)
        {
            _listingService = listingService;
        }

        [HttpGet("Listing")]
        public async Task<IActionResult> All()
        {
            return View(await _listingService.GetAll());
        }

        [HttpGet("Listing/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return View(await _listingService.GetById(id));
        }

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

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _listingService.Delete(id);
            return RedirectToAction("All");
        }

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
