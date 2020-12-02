using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Controllers
{
    public class DashboardController : Controller
    {
        //index returns the global admin dashboard view. shared/index.cshtml
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LocalAdminDashboard()
        {
            return View();
        }
        public IActionResult VolunteerDonorDashboard()
        {
            return View();
        }
    }
}
