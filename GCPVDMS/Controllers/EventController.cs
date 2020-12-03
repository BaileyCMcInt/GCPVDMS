﻿using System;
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

        [Authorize(Roles = "Global Admin")]
        public ViewResult EventList() => View("~/Views/Event/Admin/EventList.cshtml", repository.Events);

        [Authorize(Roles = "Global Admin")]
        public ViewResult Index(int eventId) =>
            View("~/Views/Event/Admin/Index.cshtml", repository.Events
                .FirstOrDefault(p => p.EventID == eventId));

        [Authorize(Roles = "Global Admin")]
        public ViewResult DisplayEvent(int eventId) =>
         View("~/Views/Event/Admin/EventInfo.cshtml", repository.Events
          .FirstOrDefault(p => p.EventID == eventId));

        [Authorize(Roles = "Global Admin")]
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

        [Authorize(Roles = "Global Admin")]
        public ViewResult Create() => View("~/Views/Event/Admin/Index.cshtml", new Event());
    }
}
