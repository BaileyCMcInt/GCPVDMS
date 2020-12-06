using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCPVDMS.Models;
using System.Linq;

namespace GCPVDMS.Controllers
{
    public class VolunteerDashboardController : Controller
    {
        private IVolunteerHourRepository repository;
        public VolunteerDashboardController(IVolunteerHourRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogMyHours()
        {
            return View();
        }

        public IActionResult MyLoggedHours()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MyLoggedHours(VolunteerHour @volunteerhour)
        {
            if (ModelState.IsValid)
            {
                repository.SaveVolunteerHour(@volunteerhour);          
                return RedirectToAction("Index");
            }
            else
            {
                return View(@volunteerhour);
            }
        }

    }
}
