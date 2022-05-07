using Microsoft.AspNetCore.Mvc;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;
using UrbanDuck.Services;

namespace UrbanDuck.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View(await _companyService.GetAll());
        }

        [HttpGet("Company/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return View(await _companyService.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company model)
        {
            await _companyService.Create(model);
            return RedirectToAction("GetById", new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.Delete(id);
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _companyService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Company model)
        {
            await _companyService.Edit(model);
            return RedirectToAction("All", new { id = model.Id });
        }
    }
}
