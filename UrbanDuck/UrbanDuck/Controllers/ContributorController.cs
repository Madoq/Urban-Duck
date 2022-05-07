using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;
using UrbanDuck.Services;

namespace UrbanDuck.Controllers
{
    public class ContributorController : Controller
    {
        private readonly IContributorService _contributorService;
        UserManager<User> userManager;
        public ContributorController(IContributorService contributorService, UserManager<User> userManager)
        {
            _contributorService = contributorService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View(await _contributorService.GetAll());
        }

        [HttpGet("Contributor")]
        public async Task<IActionResult> GetById()
        {
            return View(await _contributorService.GetByUserId(int.Parse(userManager.GetUserId(User))));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contributor model)
        {
            var userid = userManager.GetUserId(User);

            await _contributorService.Create(model);
            return RedirectToAction("GetById", new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _contributorService.Delete(id);
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _contributorService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Contributor model)
        {
            await _contributorService.Edit(model);
            return RedirectToAction("All", new { id = model.Id });
        }
    }
}
