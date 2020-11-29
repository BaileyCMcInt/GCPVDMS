using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCPVDMS.Models;
using System.Linq;

namespace GCPVDMS.Controllers
{
    public class EventController : Controller
    {

        //public IActionResult Index()
        //{
        //    return View("~/Views/Event/Admin/Index.cshtml");
        //}

        //public IActionResult EventList()
        //{
        //    return View("~/Views/Event/Admin/EventList.cshtml");
        //}
        public IActionResult EventSignUp()
        {
            return View("~/Views/Event/Volunteer/EventSignUp.cshtml");
        }


        private IEventRepository repository;
        public EventController(IEventRepository repo)
        {
            repository = repo;
        }
        public ViewResult EventList() => View("~/Views/Event/Admin/EventList.cshtml", repository.Events);

        public ViewResult Index(int eventId) =>
            View("~/Views/Event/Admin/Index.cshtml", repository.Events
                .FirstOrDefault(p => p.EventID == eventId));

        [HttpPost]
        public IActionResult Index(Event @event)
        {
            if (ModelState.IsValid)
            {
                repository.SaveEvent(@event);
             //   TempData["message"] = $"{event.EventTitle} has been saved";
                return RedirectToAction("EventList");
            }
            else
            {
                // there is something wrong with the data values
                return View(@event);
            }
        }
    }
}
