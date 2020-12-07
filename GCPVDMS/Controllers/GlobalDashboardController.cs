using GCPVDMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace GCPVDMS.Controllers
{
    public class GlobalDashboardController : Controller
    {
        private IEventRepository repository;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        
        public GlobalDashboardController(IEventRepository repo, RoleManager<IdentityRole> roleMgr, UserManager<ApplicationUser> userMrg)
        {
            //this method is passing in all the data to the constructor and assigning it to a variable to be used to access model data
            //throughout the controller
            repository = repo;
            roleManager = roleMgr;
            userManager = userMrg;
        }

        public IActionResult Index()
        {
            return RedirectToAction("EventList");
        }

        //the following are methods related to EVENT MODELS. New comments are documented
        ///each time we start a new set of model methods.
        public IActionResult EventSignUp()
        {
            return View("~/Views/Event/Volunteer/EventSignUp.cshtml");
        }

        [Authorize(Roles = "Global Admin")]
        public IActionResult EventList() => View(repository.Events);

        [Authorize(Roles = "Global Admin")]
        public ViewResult EventForm(int eventId) =>
            View(repository.Events
                .FirstOrDefault(p => p.EventID == eventId));

        [Authorize(Roles = "Global Admin")]
        public ViewResult EventInfo(int eventId) =>
         View(repository.Events
          .FirstOrDefault(p => p.EventID == eventId));

        [Authorize(Roles = "Global Admin")]
        [HttpPost]
        public IActionResult EventForm(Event @event)
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
        public ViewResult DisplayEvent(int eventId) =>
        View("~/Views/GlobalDashboard/EventInfo.cshtml",repository.Events
         .FirstOrDefault(p => p.EventID == eventId));
        [Authorize(Roles = "Global Admin")]
        public ViewResult Create() => View("~/Views/GlobalDashboard/EventForm.cshtml", new Event());

        //the following methods are related to ROLE MODELS

        [Authorize(Roles = "Global Admin")]
        public ViewResult RoleIndex() => View(roleManager.Roles);
        public IActionResult RoleCreate() => View();

        [Authorize(Roles = "Global Admin")]
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        [Authorize(Roles = "Global Admin")]
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
        public async Task<IActionResult> Delete(string id)
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

        [Authorize(Roles = "Global Admin")]
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

        [Authorize(Roles = "Global Admin")]
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
    }
}
