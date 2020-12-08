using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCPVDMS.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace GCPVDMS.Controllers
{
    public class EventController : Controller
    {
        private IEventRepository repository;
        public EventController(IEventRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return RedirectToAction("EventInfoPage");
        }
        public ViewResult EventSignUp() =>
            View("~/Views/Event/Volunteer/EventSignUp.cshtml", repository.Events);
        public ViewResult EventInfoPage(int eventId) =>
            View("~/Views/Event/Volunteer/EventInfoPage.cshtml", repository.Events
                .FirstOrDefault(p => p.EventID == eventId));

        public ViewResult ConfirmationPage(int eventId) =>
            View("~/Views/Event/Volunteer/ConfirmationPage.cshtml", repository.Events
                .FirstOrDefault(p => p.EventID == eventId));

        public ViewResult HostaDrive() => View("~/Views/Event/Volunteer/HostaDrive.cshtml");

        //[Authorize(Roles = "Global Admin")]
        //public ViewResult EventList() => View("~/Views/Event/Admin/EventList.cshtml", repository.Events);

        //[Authorize(Roles = "Global Admin")]
        //public ViewResult Index(int eventId) =>
        //    View("~/Views/Event/Admin/Index.cshtml", repository.Events
        //        .FirstOrDefault(p => p.EventID == eventId));

        //[Authorize(Roles = "Global Admin")]
        //public ViewResult DisplayEvent(int eventId) =>
        // View("~/Views/Event/Admin/EventInfo.cshtml", repository.Events
        //  .FirstOrDefault(p => p.EventID == eventId));

        //[Authorize(Roles = "Global Admin")]
        //[HttpPost]
        //public IActionResult Index(Event @event)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.SaveEvent(@event);
        //     //   TempData["message"] = $"{event.EventTitle} has been saved";
        //        return RedirectToAction("EventList");
        //    }
        //    else
        //    {
        //        // there is something wrong with the data values
        //        return View(@event);
        //    }
        //}

        //[Authorize(Roles = "Global Admin")]
        //public ViewResult Create() => View("~/Views/Event/Admin/Index.cshtml", new Event());
    }
}
