using GCPVDMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using GCPVDMS.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GCPVDMS.Controllers
{
    public class VolunteerDonorDashboardController : Controller
    {
        //adding in model repositories to reference database tables
        private IVolunteerHourRepository repository;
        private IEventRegistrationRepository registrationRepository;
        private IEventRepository eventRepository;
        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext context;

        //passing object repositories into the constructor
        public VolunteerDonorDashboardController(IVolunteerHourRepository hourRepo, IEventRegistrationRepository regRepo, IEventRepository eventRepo, IGCPTaskRepository taskRepo, UserManager<ApplicationUser> userMrg, ApplicationDbContext ctx)
        {
            repository = hourRepo;
            registrationRepository = regRepo;
            eventRepository = eventRepo;
            userManager = userMrg;
            context = ctx;
   
        }

        //this is the index/volunteer events tabs. It displays data for the events the volunteer
        //is signed up for.
        public async Task<ViewResult> Index(string userId, int Id)
        {
            //referencing identity usermanger class passed into the constructor. This retrieves
            //the userID from the IdentityDbContext.
            var user = await userManager.FindByIdAsync(userId);
            //Create viewmodel object for the view
            var viewModel = new SignedUpEventsViewModel()
            {
                //gets an event instance to reference single events
                Event = eventRepository.Events
                    .FirstOrDefault(a => a.EventID == Id),
                //provides list of locations
                Locations = context.Locations.ToList(),
                //list of event registrations
                EventRegistrations = context.EventRegistrations.ToList(),
                //event list view
                Events = context.Events.ToList(),
                UserId = userId

            };
            //returns all the items passed into the viewmodel object to refence in the view.
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CancelMyEvent(int Id, int eventId)
        {
            Event passedEvent = context.Events
                .FirstOrDefault(x => x.EventID == eventId);
           
            var eventReg = new EventRegistration
            {
                EventRegistrationID = Id
            };

            int numSignedUp = passedEvent.NumVolunteersSignedUp - 1;
            passedEvent.NumVolunteersSignedUp = numSignedUp;
            int numNeeded = passedEvent.NumVolunteersNeeded + 1;
            passedEvent.NumVolunteersNeeded = numNeeded;

            context.EventRegistrations.Attach(eventReg);
            context.EventRegistrations.Remove(eventReg);
            context.SaveChanges();

            //returns all the items passed into the viewmodel object to refence in the view.
            return RedirectToAction("Index");
        }


        //this method creates a new log my hours object request
        public ViewResult LogMyHoursCreate(int Id)
        {
            //creates new volunteer hour object
            var logHours = new VolunteerHour();
            //creating the viewmodel
            var viewModel = new LogMyHoursViewModel()
            {
                //assignment our volunteerhour instance to a new volunteerhour object
                VolunteerHour = logHours,
                //gets an event instance from the constructor
                Event = eventRepository.Events
                    .FirstOrDefault(a => a.EventID == Id),
                //provides a list of events for the user to select from
                Events = context.Events.ToList(),
                EventRegistration = registrationRepository.EventRegistrations
                    .FirstOrDefault(a => a.EventID == Id),
                EventRegistrations = registrationRepository.EventRegistrations.ToList()

            };
            //returns the new/blank viewmodel object to the view with data to populate the form with
            return View("~/Views/VolunteerDonorDashboard/LogMyHours.cshtml", viewModel);
        }

        //this method is similar to above but also instantiates the user. You may be able to cut it to one
        //method, I think I did two just following some of our other code, this works fine though.
        public async Task<ViewResult> LogMyHours(string userId, int Id)
        {
            //retrieves user from the usermanager class
            var user = await userManager.FindByIdAsync(userId);

            //creates new volunteerHour object
            VolunteerHour logHours = new VolunteerHour();

            //creates a viewmodel to give us data to populate our form
            var viewModel = new LogMyHoursViewModel()
            {
                VolunteerHour = logHours,
                Events = eventRepository.Events.ToList(),
                Event = eventRepository.Events
                    .FirstOrDefault(a => a.EventID == Id),
                User = user,
                EventRegistration = registrationRepository.EventRegistrations
                    .FirstOrDefault(a => a.EventID == Id),
                EventRegistrations = registrationRepository.EventRegistrations.ToList()
            };

            //returns the viewmodel with the user-populated data
            return View(viewModel);
        }
        [HttpPost]
        //this method saves the logged hours to the volunteerhour table
        public IActionResult LogMyHours(VolunteerHour @volunteerhour)
        {
            //checks that the values are properly populated
            if (ModelState.IsValid)
            {
                //calls repository method to save event to the database
                repository.SaveVolunteerHour(@volunteerhour);
                //returns to the myLogged hours page to validate the hours were submitted
                EventRegistration dbEventReg = context.EventRegistrations
                .FirstOrDefault(p => p.EventID == volunteerhour.EventID && p.UserId == volunteerhour.UserId);
                if (dbEventReg != null)
                {
                    dbEventReg.isLogged = true;
                    context.SaveChanges();
                }
                return RedirectToAction("MyLoggedHours");
            }
            else
            {
                // there is something wrong with the data values
                //this is where you could add validate error messages, or in your model.
                return View(volunteerhour);
            }
        }

        //method that retrieves the users logged hours
        public async Task<IActionResult> MyLoggedHours(int ID, string userId)
        {

            var user = await userManager.FindByIdAsync(userId);
            //creates a new viewmodel object
            var viewModel = new LogMyHoursViewModel
            {
                //gets a lists of volunteerHours
                VolunteerHours = context.VolunteerHours.ToList(),
                //gets a list of events
                Events = context.Events.ToList(),
                //gets all volunteer hours, includes the events based on
                //volunteerHourID.
                VolunteerHour = context.VolunteerHours
                    .Include(i => i.Event)
                    .FirstOrDefault(x => x.VolunteerHourID == ID),
                //sets the UserId in the volunteerHour model to the userId passed
                //in to the method, so that you do not retrieve all volunteer hours
                //you may need to set this up to be passed to this method from your view, 
                //I did not check that part.
                UserId = userId
                
             };
            //returns viewModel of data to retrieve from the view.
                return View(viewModel);
 
        }

        //similar to above concepts, but I'm not sure that I used this method at all.
        public IActionResult EventList(int ID)
        {
            var viewModel = new CreateEventViewModel
            {
                //the include reference refences foriegn keys associated with
                //the model primary key its attached to.
                //so it's refencing the location Foreign Key here. 
                Event = context.Events.Include(i => i.Location)
                    .FirstOrDefault(x => x.EventID == ID),
                Locations = context.Locations.ToList(),
                Events = context.Events.ToList()
            };
            return View(viewModel);
        }

        public ViewResult EventInfoPage(int eventId)
        {
            //inserting viewmodel object
            var viewModel = new SignedUpEventsViewModel
            {
                Event = context.Events
                    .Include(i => i.Location)
                    .FirstOrDefault(x => x.EventID == eventId),
                Events = context.Events.ToList(),
            };
            //Returns viewModel object with Event data
            return View(viewModel);
        }
        public IActionResult DonorHome()
        {
            return View();
        }
      

    }
}
