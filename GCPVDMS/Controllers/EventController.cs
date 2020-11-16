using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GCPVDMS.Controllers
{
    public class EventController : Controller
    {

        public IActionResult Index()
        {
            return View("~/Views/Event/Admin/Index.cshtml");
        }
        public IActionResult EventList()
        {
            return View("~/Views/Event/Admin/EventList.cshtml");
        }
        public IActionResult EventSignUp()
        {
            return View("~/Views/Event/Volunteer/EventSignUp.cshtml");
        }
    }
}
