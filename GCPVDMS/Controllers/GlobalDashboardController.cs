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
    public class GlobalDashboardController : Controller
    {
        private IEventRepository repository;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext context;

        public GlobalDashboardController(IEventRepository repo, RoleManager<IdentityRole> roleMgr, UserManager<ApplicationUser> userMrg, ApplicationDbContext ctx)
        {
            //this method is passing in all the data to the constructor and assigning it to a variable to be used to access model data
            //throughout the controller
            repository = repo;
            roleManager = roleMgr;
            userManager = userMrg;
            context = ctx;
        }
        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult Index()
        {
            return RedirectToAction("EventList");
        }

        //The following are methods related to EVENT MODELS. 

        //Method to display a table of all the events.
        [Authorize(Roles = "Global Admin")]
        public IActionResult EventList(int ID)
        {
            var viewModel = new CreateEventViewModel
            {
                Event = context.Events.Include(i => i.Location).FirstOrDefault(x => x.EventID == ID),
                Locations = context.Locations.ToList(),
                Events = context.Events.Where(x => x.IsArchived == false).ToList()
            };
            return View(viewModel);
        }


        [Authorize(Roles = "Global Admin")]
        //When the admin clicks edit on an existing event this method is called.
        //Prefills the Event form with the event info
        public ViewResult EventForm(int eventId)
        {
            var viewModel = new CreateEventViewModel
            {
                GCPTasks = context.GCPTasks.ToList(),
                GCPEventTasks = context.GCPEventTasks.Where(x => x.EventID == eventId).ToList(),
                Locations = context.Locations.ToList(),
                Event = repository.Events.FirstOrDefault(p => p.EventID == eventId),
                Disclaimers = context.Disclaimers.ToList(),
                GCPEventDisclaimers = context.EventDisclaimers.Where(x => x.EventID == eventId).ToList()

            };
            viewModel.Location = context.Locations.FirstOrDefault(a => a.LocationID == viewModel.Event.LocationID);
            return View(viewModel);
        }

        [Authorize(Roles = "Global Admin")]
        [HttpPost]
        //this method saves the event after creating a new event or updating an existing event
        //SaveEvent() is in EFEventRepository.cs. 
        //After saving, redirects to the table of Events. 
        public IActionResult EventForm(CreateEventViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                    repository.SaveEvent(viewModel);
                    //   TempData["message"] = $"{event.EventTitle} has been saved";

                return RedirectToAction("EventList");
            }
            else
            {
                //  if there is something wrong with the data values, do not save.
                return View(viewModel);
            }
        }


        //Method for displaying the static event info. 
        [Authorize(Roles = "Global Admin")]
        public ViewResult DisplayEvent(int eventId)
        {

            var viewModel = new CreateEventViewModel
            {
                Event = context.Events.Include(i => i.Location).FirstOrDefault(x => x.EventID == eventId),
                GCPEventTasks = context.GCPEventTasks.Where(i => i.isSelected == true && i.EventID == eventId).ToList(),
                GCPTasks = context.GCPTasks.ToList(),
                EventRegistrations = context.EventRegistrations.Where(i => i.EventID == eventId).ToList(),
                Disclaimers = context.Disclaimers.ToList(),
                GCPEventDisclaimers = context.EventDisclaimers.Include(i => i.Disclaimer).Where(i => i.isSelected == true && i.EventID == eventId).ToList(),
                Users = userManager.Users.ToList()
            };
            return View("~/Views/GlobalDashboard/EventInfo.cshtml", viewModel);
        }

        //Method for creating a new event. The form will be blank.
        [Authorize(Roles = "Global Admin")]
        public ViewResult Create(int id)
        {
            var eventCreate = new Event();
            var eventTasks = context.GCPTasks.Select(gcpTask => new GCPEventTask() {
                GCPTaskID = gcpTask.GCPTaskID,
                isSelected = default,
                GCPTask = gcpTask
            }).ToList();
            var eventDisclaimers = context.Disclaimers.Select(disclaimer => new GCPEventDisclaimer()
            {
                DisclaimerID = disclaimer.DisclaimerID,
                isSelected = default,
                Disclaimer = disclaimer
            }).ToList();

            var viewModel = new CreateEventViewModel
            {
                GCPTasks = context.GCPTasks.ToList(),
                GCPEventTasks = eventTasks,
                Locations = context.Locations.ToList(),
                Location = context.Locations.FirstOrDefault(a => a.LocationID == id),
                Event = eventCreate,
                Disclaimers = context.Disclaimers.ToList(),
                GCPEventDisclaimers = eventDisclaimers
            };
            return View("~/Views/GlobalDashboard/EventForm.cshtml", viewModel);
        }

        //Method for archiving an event. 
        [Authorize(Roles = "Global Admin")]
        [HttpPost]
        public IActionResult ArchiveEvent(int eventId)
        {
            Event dbEntry = context.Events
                .FirstOrDefault(p => p.EventID == eventId);

            dbEntry.IsArchived = true; 

            context.SaveChanges();

            return RedirectToAction("EventList");
        }


        //Displays list of archived events
        [Authorize(Roles = "Global Admin")]
        public IActionResult ArchiveEventsList(int ID)
        {
            var viewModel = new CreateEventViewModel
            {
                Event = context.Events.Include(i => i.Location).FirstOrDefault(x => x.EventID == ID),
                Locations = context.Locations.ToList(),
                Events = context.Events.Where(x => x.IsArchived == true).ToList()
            };
            return View("~/Views/GlobalDashboard/ArchiveEventsList.cshtml", viewModel);
        }


            //the following are methods related to TASK MODELS

            //This method provides the list of tasks in the master task view. 
            [Authorize(Roles = "Global Admin")]
        [HttpGet]
        public IActionResult MasterTask()
        {
            var gcptaskdata = new GCPTaskDTO()
            {
                GCPTaskList = context.GCPTasks.ToList()
            };
            return View(gcptaskdata);
        }
        
        //This method allows the admin to add a new task to the master list. 
        [Authorize(Roles = "Global Admin")]
        [HttpPost]
        public IActionResult MasterTask(GCPTaskDTO GCPTask)
        {
            if (GCPTask.GCPTaskData.GCPTaskID == 0)
            {
                context.GCPTasks.Add(GCPTask.GCPTaskData);
            }
            else
            {
                GCPTask dbEntry = context.GCPTasks
                .FirstOrDefault(p => p.GCPTaskID == GCPTask.GCPTaskData.GCPTaskID);
                if (dbEntry != null)
                {
                    dbEntry.TaskName = GCPTask.GCPTaskData.TaskName;
                }
            }
            context.SaveChanges();
            return RedirectToAction("MasterTask");
        }
        
        //This method is not in use. 
        //[Authorize(Roles = "Global Admin")]
        //public IActionResult GCPTaskDelete(int id)
        //{
        //    var dataForDelete = context.GCPTasks.FirstOrDefault(async => async.GCPTaskID == id);
        //    context.GCPTasks.Remove(dataForDelete);
        //    context.SaveChanges();
        //    return RedirectToAction("MasterTask");
        //}

        //This method allows the admin to edit an existing task
        [Authorize(Roles = "Global Admin")]
        [HttpGet]
        public IActionResult GCPTaskEdit(int id)
        {
     
            var gcptaskdata = new GCPTaskDTO()
            {
                GCPTaskList = context.GCPTasks.ToList(),
                GCPTaskData = context.GCPTasks.FirstOrDefault(a => a.GCPTaskID == id)
            };
            return View("MasterTask", gcptaskdata);
        }



        //the following are methods related to DISCLAIMER MODELS

        //This method provides the list of tasks in the master task view. 
        [Authorize(Roles = "Global Admin")]
        [HttpGet]
        public IActionResult MasterDisclaimer()
        {
            var disclaimerdata = new DisclaimerDTO()
            {
                DisclaimerList = context.Disclaimers.ToList()
            };
            return View(disclaimerdata);
        }

        //This method allows the admin to add a new disclaimer to the master list. 
        [Authorize(Roles = "Global Admin")]
        [HttpPost]
        public IActionResult MasterDisclaimer(DisclaimerDTO disclaimer)
        {
            if (disclaimer.DisclaimerData.DisclaimerID == 0)
            {
                context.Disclaimers.Add(disclaimer.DisclaimerData);
            }
            else
            {
                Disclaimer dbEntry = context.Disclaimers
                .FirstOrDefault(p => p.DisclaimerID == disclaimer.DisclaimerData.DisclaimerID);
                if (dbEntry != null)
                {
                    dbEntry.DisclaimerDesc = disclaimer.DisclaimerData.DisclaimerDesc;
                }
               
            }
            context.SaveChanges();
            return RedirectToAction("MasterDisclaimer");
        }

        //This method allows the admin to edit an existing disclaimer
        [Authorize(Roles = "Global Admin")]
        [HttpGet]
        public IActionResult DisclaimerEdit(int id)
        {

            var disclaimerdata = new DisclaimerDTO()
            {
                DisclaimerList = context.Disclaimers.ToList(),
                DisclaimerData = context.Disclaimers.FirstOrDefault(a => a.DisclaimerID == id)
            };
            return View("MasterDisclaimer", disclaimerdata);
        }

        //the following methods are related to LOCATION and COUNTY MODELS utilized on the Locations tab of the dashboard

        //This method allows the admin to add a new location
        [Authorize(Roles = "Global Admin")]
        [HttpPost]
        public IActionResult Locations(LocationDTO Location)
        {
            if (Location.GCPLocationData.LocationID == 0)
            {
                context.Locations.Add(Location.GCPLocationData);
            }
            else
            {
                Location dbEntry = context.Locations
                .FirstOrDefault(p => p.LocationID == Location.GCPLocationData.LocationID);
                if (dbEntry != null)
                {
                    dbEntry.LocationName = Location.GCPLocationData.LocationName;
                    dbEntry.StreetAddress = Location.GCPLocationData.StreetAddress;
                    dbEntry.StreetAddress2 = Location.GCPLocationData.StreetAddress2;
                    dbEntry.City = Location.GCPLocationData.City;
                    dbEntry.Zip = Location.GCPLocationData.Zip;
                    dbEntry.CountyID = Location.GCPLocationData.CountyID;
                }
            }
            context.SaveChanges();
            return RedirectToAction("Locations");
        }


        //provides list of locations in the location table
        [Authorize(Roles = "Global Admin")]
        [HttpGet]
        public IActionResult Locations()
        {
            var gcpLocation = new LocationDTO()
            {
                LocationList = context.Locations.ToList(),
                Counties = context.Counties.ToList()
            };
            return View(gcpLocation);
        }

        //This method allows the admin to edit an existing location
        [Authorize(Roles = "Global Admin")]
        [HttpGet]
        public IActionResult LocationEdit(int id)
        {

            var locationdata = new LocationDTO()
            {
                LocationList = context.Locations.ToList(),
                GCPLocationData = context.Locations.FirstOrDefault(a => a.LocationID == id),
                Counties = context.Counties.ToList()

            };
            return View("Locations", locationdata);
        }


        //This method allows the admin to add a new county
        [Authorize(Roles = "Global Admin")]
        [HttpPost]
        public IActionResult Counties(CountyDTO County)
        {
            if (County.CountyData.CountyID == 0)
            {
                context.Counties.Add(County.CountyData);
            }
            else
            {
                County dbEntry = context.Counties
                .FirstOrDefault(p => p.CountyID == County.CountyData.CountyID);
                if (dbEntry != null)
                {
                    dbEntry.CountyName = County.CountyData.CountyName;
                    dbEntry.CountyState = County.CountyData.CountyState;
                }
            }
            context.SaveChanges();
            return RedirectToAction("Counties");
        }

        //provides list of counties in the counties table
        [Authorize(Roles = "Global Admin")]
        [HttpGet]
        public IActionResult Counties()
        {
            var gcpCounty = new CountyDTO()
            {
                CountyList = context.Counties.ToList()
            };
            return View(gcpCounty);
        }

        //This method allows the admin to edit an existing county
        [Authorize(Roles = "Global Admin")]
        [HttpGet]
        public IActionResult CountyEdit(int id)
        {

            var countydata = new CountyDTO()
            {

                CountyList = context.Counties.ToList(),
                CountyData = context.Counties.FirstOrDefault(a => a.CountyID == id)

            };
            return View("Counties", countydata);
        }


        //the following methods are related to ROLE MODELS utilized on the ADMIN tab of the dashboard

        //[Authorize(Roles = "Global Admin")]
        public ViewResult RoleIndex() => View(roleManager.Roles);
        public IActionResult RoleCreate() => View();

        //[Authorize(Roles = "Global Admin")]
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        //[Authorize(Roles = "Global Admin")]
        [HttpPost]
        public async Task<IActionResult> RoleCreate([Required]string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }

        [Authorize(Roles = "Global Admin")]
        [HttpPost]
        public async Task<IActionResult> RoleDelete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", roleManager.Roles);
        }

        //[Authorize(Roles = "Global Admin")]
        public async Task<IActionResult> RoleUpdate(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<ApplicationUser> members = new List<ApplicationUser>();
            List<ApplicationUser> nonMembers = new List<ApplicationUser>();
            foreach (ApplicationUser user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        //[Authorize(Roles = "Global Admin")]
        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(RoleUpdate));
            else
                return await RoleUpdate(model.RoleId);
        }


        //the following methods are related to ROLE MODELS utilized on the VOLUNTEER tab of the dashboard
        [Authorize(Roles = "Global Admin")]
        public IActionResult ViewVolunteers()
        {
            return View(userManager.Users);
        }

        [Authorize(Roles = "Global Admin")]
        public IActionResult ViewDonors()
        {
            return View(userManager.Users);
        }


        [Authorize(Roles = "Global Admin")]
        public ViewResult VolunteerInfo(string id) =>
         View(userManager.Users
                .FirstOrDefault(p => p.Id == id));

        //the following methods are for the USER ACCOUNT MANAGEMENT portion of the Global Dashboard

        [Authorize(Roles = "Global Admin")]
        //public IActionResult ViewUsers()
        //{
        //    return View(userManager.Users);
        //}
        public ViewResult DonorInfo(string id) =>
         View(userManager.Users
                .FirstOrDefault(p => p.Id == id));

        [Authorize(Roles = "Global Admin")]
        public async Task<IActionResult> UpdateUser(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        //[Authorize(Roles = "Global Admin")]
        //[HttpPost]
        //public async Task<IActionResult> UpdateUser(string id)
        //{
        //    ApplicationUser user = await userManager.FindByIdAsync(id);
        //    if (user != null)
        //    {
        //            IdentityResult result = await userManager.UpdateAsync(user);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("ViewUsers");
        //            }
        //    }
        //    return View(user);
        //}

        [Authorize(Roles = "Global Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    StatusMessage = "Account has been removed from the queue.";
                    return RedirectToAction("ViewUsers");
                }
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }

        //the following methods are for admin editing volunteer hours

        [Authorize(Roles = "Global Admin")]
        [HttpGet]
        public async Task<IActionResult> HoursApproval(string id, int eventId)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            var hours = new ApproveHoursViewModel()
            {
                VolunteerHours = context.VolunteerHours.ToList(),
                Users = userManager.Users.ToList(),
                User = user,
                Event = repository.Events
                    .FirstOrDefault(a => a.EventID == eventId),
                Locations = context.Locations.ToList()
            };
            return View(hours);
        }

        [Authorize(Roles = "Global Admin")]
        [HttpPost]
        public async Task<IActionResult> HoursApproval(int id, string userId, string approve, string deny, string adminComment)
        {
            ApplicationUser user = await userManager.FindByIdAsync(userId);
            var hours = new ApproveHoursViewModel()
            {
                VolunteerHours = context.VolunteerHours.ToList(),
                VolunteerHour = context.VolunteerHours.FirstOrDefault(a => a.VolunteerHourID == id),
                User = user,

            };
            if (approve == "approve")
            {
                hours.VolunteerHour.isApproved = true;
            }
            if (approve == "deny")
            {
                hours.VolunteerHour.isDenied = true;
            }
            if(adminComment !="null")
            {
                hours.VolunteerHour.adminComment = adminComment;
            }
            context.SaveChanges();
            return RedirectToAction("HoursApproval", hours);
        }


    }
}
