using Microsoft.AspNetCore.Mvc;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;

namespace UrbanDuck.Controllers
{
    public class TestController : Controller
    {
        private readonly ICompanyService _companyService;
        public TestController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("Company")]
        public async Task<IActionResult> GetAllCompanies()
        {
            return View(await _companyService.GetAllCompanies());
        }

        [HttpGet("Company/{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            return View(await _companyService.GetCompany(id));
        }

        [HttpGet("CreateCompany")]
        public async Task<IActionResult> CreateCompany()
        {
            return View();
        }

        [HttpPost("CreateCompany")]
        public async Task<IActionResult> CreateCompany(Company newCompany)
        {
            await _companyService.CreateCompany(newCompany);
            return RedirectToAction("GetCompanyById", new { id = newCompany.Id });
        }

        [Route("DeleteCompany")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companyService.DeleteCompany(id);
            return RedirectToAction("GetAllCompanies");
        }
    }
}
