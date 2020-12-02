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

    }
}
