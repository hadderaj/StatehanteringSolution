using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Statehantering.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statehantering.Controllers
{
    public class StatesController : Controller
    {
        StateCreateVM stateCreateVM = new StateCreateVM();
        IMemoryCache cache;

        public StatesController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Route("")]
        [HttpPost]
        public IActionResult Create(StateCreateVM stateCreateVM)
        {
            if (!ModelState.IsValid)
                return View(stateCreateVM);


            TempData["Message"] = "Dina värden har sparats";

            cache.Set("supportEmail", stateCreateVM.Email);

            HttpContext.Session.SetString("CompanyName", stateCreateVM.CompanyName);

            return RedirectToAction(nameof(Display));
        }

        [Route("display")]
        public IActionResult Display()
        {
            var viewModel = new StateDisplayVM
            {
                Email = cache.Get<string>("supportEmail"),
                Message = (string)TempData["Message"],
                CompanyName = HttpContext.Session.GetString("CompanyName")
            };

            return View(viewModel);






        }
    }
}
