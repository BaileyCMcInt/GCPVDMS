﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GCPVDMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GCPVDMS.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel //these are all the attributes for the user profile
        {
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "Email")]
            public string Username { get; set; }
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [Display(Name = "Primary Preferred method of Contact")]
            public string PreferredContact{ get; set; }
            [Display(Name = "Secondary Preferred method of Contact")]
            public string SecondPreferredContact { get; set; }

            [Display(Name = "County Affiliation")]
            public string County { get; set; }
            [Display(Name = "Donor")]
            public bool isDonor { get; set; }
            [Display(Name = "Volunteer")]
            public bool isVolunteer { get; set; }
         
            [DataType(DataType.Date)]
            [Display(Name = "Date of birth")]
            public DateTime Birthday { get; set; }



        }
  
        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var preferredContact = user.PreferredContact;
            var secondpreferredContact = user.SecondPreferredContact;
            var county = user.County;
            var IsVolunteer = user.isVolunteer;
            var IsDonor = user.isDonor;
            var birthday = user.Birthday;
            Username = userName;
            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Username = userName,
                FirstName = firstName,
                LastName = lastName,
                PreferredContact = preferredContact,
                SecondPreferredContact = secondpreferredContact,
                County = county,
                isVolunteer = IsVolunteer,
                isDonor = IsDonor,
                Birthday = birthday
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var preferredContact = user.PreferredContact;
            var secondpreferredContact = user.SecondPreferredContact;
            var county = user.County;
            var IsVolunteer = user.isVolunteer;
            var IsDonor= user.isDonor;
            var birthday = user.Birthday;
            if (Input.FirstName != firstName)
            {
                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.LastName != lastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.PreferredContact != preferredContact)
            {
                user.PreferredContact = Input.PreferredContact;
                await _userManager.UpdateAsync(user);
            }
            if (Input.SecondPreferredContact != secondpreferredContact)
            {
                user.SecondPreferredContact = Input.SecondPreferredContact;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Birthday != birthday)
            {
                user.Birthday = Input.Birthday;
                await _userManager.UpdateAsync(user);
            }
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            if (Input.isVolunteer != IsVolunteer)
            {
                user.isVolunteer = Input.isVolunteer;
                await _userManager.UpdateAsync(user);
            }
            if (Input.isDonor != IsDonor)
            {
                user.isDonor = Input.isDonor;
                await _userManager.UpdateAsync(user);
            }
            if (Input.County != county)
            {
                user.County = Input.County;
                await _userManager.UpdateAsync(user);
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
