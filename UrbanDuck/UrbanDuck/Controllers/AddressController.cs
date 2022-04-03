﻿using Microsoft.AspNetCore.Mvc;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;

namespace UrbanDuck.Controllers
{
    public class AddressController : Controller
    {
        private readonly IBaseService<Address> _addressService;
        public AddressController(IBaseService<Address> addressService)
        {
            _addressService = addressService;
        }

        //[HttpGet]
        //public async Task<IActionResult> All()
        //{
        //    return View(await _addressService.GetAll());
        //}

        [HttpGet("Address/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return View(await _addressService.GetById(id));
        }

        [HttpGet("Address/Company/{id:int}")]
        public async Task<IActionResult> GetByCompanyId(int companyId)
        {
            return View(await _addressService.GetByConditions(x => x.CompanyId == companyId));
        }

        [HttpGet("Address/Create/{companyId:int}")]
        public async Task<IActionResult> Create(int companyId)
        {
            ViewBag.CompanyId = companyId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Address model)
        {
            await _addressService.Create(model);
            return RedirectToRoute("Company", new { id = model.CompanyId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _addressService.Delete(id);
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _addressService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Address model)
        {
            await _addressService.Edit(model);
            return RedirectToAction("All", new { id = model.Id });
        }
    }
}
