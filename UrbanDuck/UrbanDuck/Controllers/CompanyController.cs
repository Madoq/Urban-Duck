using Microsoft.AspNetCore.Mvc;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;

namespace UrbanDuck.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
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

        [HttpPost("DeleteCompany")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companyService.DeleteCompany(id);
            return RedirectToAction("GetAllCompanies");
        }

        [HttpGet("EditCompany")]
        public async Task<IActionResult> EditCompany(int id)
        {
            return View(await _companyService.GetCompany(id));
        }

        [HttpPost("EditCompany")]
        public async Task<IActionResult> EditCompany(Company editedCompany)
        {
            await _companyService.EditCompany(editedCompany);
            return RedirectToAction("GetCompanyById", new { id = editedCompany.Id });
        }
    }
}
