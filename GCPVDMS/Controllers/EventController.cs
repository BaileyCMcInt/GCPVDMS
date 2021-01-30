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

        //Method that displays page with table of events. It only shows events that occur in the future
        //and that are considered active.
        public ViewResult EventSignUp()
        {
            var Events = from e in repository.Events select e;
            Events = repository.Events.Where(e => e.isEventActive == true && e.EventDate > DateTime.Now);

            return View("~/Views/Event/EventSignUp.cshtml", Events);
        }

        //Method that displays details about an event
        //It takes in information about the event using the repository and db
        public ViewResult EventInfoPage(int eventId) =>
            View("~/Views/Event/EventInfoPage.cshtml", repository.Events
                .FirstOrDefault(p => p.EventID == eventId));

        //Add Description - Method that will increase number signed up by 1 and 
        //will add user and event to event registration table.
        public ViewResult ConfirmationPage(int eventId) =>
            View("~/Views/Event/ConfirmationPage.cshtml", repository.Events
                .FirstOrDefault(p => p.EventID == eventId));

        //Method that displays the HostaDrive page
        public ViewResult HostaDrive() => View("~/Views/Event/HostaDrive.cshtml");










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
