using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCPVDMS.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using GCPVDMS.Models.ViewModels;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GCPVDMS.Controllers
{
    public class EventController : Controller
    {
        [TempData]
        string ErrorMessage { get; set; }
        //added in all repositories needed for the viewmodels/models/views
        private IEventRepository repository;
        private IEventRegistrationRepository registrationRepository;
        private ApplicationDbContext context;
        private UserManager<ApplicationUser> userManager;
        public EventController(IEventRepository repo, ApplicationDbContext ctx, IEventRegistrationRepository regRepo, UserManager<ApplicationUser> userMrg)
        {
            repository = repo;
            context = ctx;
            userManager = userMrg;
            registrationRepository = regRepo;
        }
        //this method directs to the event info page. 
        public IActionResult Index()
        {
            return RedirectToAction("EventInfoPage");
        }

        //Method that displays page with table of events. It only shows events that occur in the future
        //and that are considered active.
        public ViewResult EventSignUp(int eventId)
        {
            //this is the EventRegistration object where the EventID and UserID are stored.
            //EventRegistration myEvent = new EventRegistration();

           //this is the viewModel. I used one viewmodel for the sign up process for consistency.
            var viewModel = new SignedUpEventsViewModel
            {
                //EventRegistration = myEvent,
                Event = context.Events
                    .Include(i => i.Location)
                    //.Where(x => x.isEventActive == true && x.EventDate > DateTime.Now),
                    .FirstOrDefault(x => x.EventID == eventId),
                Events = context.Events.Where(x => x.isEventActive == true && x.EventDate >= DateTime.Now.AddDays(-2)).ToList(),
                Locations = context.Locations.ToList()
            };
            

            //Returns viewModel object with EventRegistration data
            return View(viewModel);
        }

        //Method that displays details about an event
        //It takes in information about the event using the repository and db
        public ViewResult EventInfoPage(int eventId)
        {
            //inserting viewmodel object
            var viewModel = new SignedUpEventsViewModel
            {
                Event = context.Events
                    .Include(i => i.Location)
                    .FirstOrDefault(x => x.EventID == eventId),
                Events = context.Events.ToList(),
                GCPEventTasks = context.GCPEventTasks.Where(i => i.isSelected == true && i.EventID == eventId).ToList(),
                GCPTasks = context.GCPTasks.ToList(),
                GCPEventDisclaimers = context.EventDisclaimers.Where(i => i.isSelected == true && i.EventID == eventId).ToList(),
                Disclaimers = context.Disclaimers.ToList()
            };
            //Returns viewModel object with Event data
            return View("~/Views/Event/EventInfoPage.cshtml", viewModel);
        }
        public async Task<ViewResult> ConfirmationPage(int eventId, string Id)
        {
            //inserting user object and obtaining userID from usermanager identity class
            var user = await userManager.FindByIdAsync(Id);

            //inserting new EventRegistration Object
            EventRegistration myEvent = new EventRegistration();
            
            var viewModel = new SignedUpEventsViewModel
            {
                EventRegistration = myEvent,
                Event = repository.Events
                    .FirstOrDefault(x => x.EventID == eventId),
                UserId = Id

            };
            //Returns viewModel object with EventRegistration data
            return View(viewModel);
        }
        //Method that will increase number signed up by 1 and 
        //will add user and event to event registration table.
        [HttpPost]
        public IActionResult ConfirmationPage(EventRegistration eventRegistration, int eventId, string Id)
        {
            var counter = 0;
            Event passedEvent = context.Events
                      .FirstOrDefault(x => x.EventID == eventId);

            if (ModelState.IsValid)
            {
                //Saving the event registration data to the database
                try
                {
                    registrationRepository.SaveEventRegistration(eventRegistration);
                    counter++;
                }
                catch
                {
                    //handles exception for unique key pair constraint
                }

                //creating viewModel object to return all event signed-up data for displaying on confirmation
                //page and dashboard.
                var viewModel = new SignedUpEventsViewModel
                {
                    EventRegistration = eventRegistration,
                    EventId = eventId,
                    Event = context.Events
                        .Include(i => i.Location)
                        .FirstOrDefault(x => x.EventID == eventId),
                    Location = context.Locations
                        .FirstOrDefault(a => a.LocationID == eventId),
                    Locations = context.Locations.ToList(),
                    UserId = Id,
                    
                };
                //returns the confirmation page viewmodel data  
                if (counter > 0)
                {
                    int newSignUpNum = passedEvent.NumVolunteersSignedUp + 1;
                    passedEvent.NumVolunteersSignedUp = newSignUpNum;
                    context.SaveChanges();
                    return View("ConfirmationPage", viewModel);
                }
                else
                {
                    ViewBag.ErrorMessage = "You have already signed up for this event. You can view this event registration in your volunteer dashboard.";
                    return View("EventInfoPage", viewModel);
                }
            }
            else
            {
                // there is something wrong with the data values
                return View(eventRegistration);
            }
        }



        //Method that displays the HostaDrive page
        public ViewResult HostaDrive() => View("~/Views/Event/HostaDrive.cshtml");


    }
}
