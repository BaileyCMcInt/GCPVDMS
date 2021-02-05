using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCPVDMS.Models;
using System.Linq;

namespace GCPVDMS.Controllers
{
    public class DonorDashboardController : Controller
    {
        public IActionResult DonorHome()
        {
            return View();
        }
    } 
}
