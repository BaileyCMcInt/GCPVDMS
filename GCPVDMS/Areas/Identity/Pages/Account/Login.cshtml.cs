using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using GCPVDMS.Models;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GCPVDMS.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<ApplicationUser> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }



        public class InputModel
        {//with identity, the username and email is the same by default so users can log in with both
            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            else
            {
                StatusMessage = "Invalid login attempt";
            }
            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            var userApproval = await _userManager.FindByEmailAsync(Input.Email);

            if (userApproval == null)
            {
                ErrorMessage = "Account with that email address does not exist. If this is a valid email, please register for a new account.";
                return Page();
            }

            if (userApproval.EmailConfirmed == false)
            {
                ErrorMessage = "Your account has not been confirmed. A confirmation email has been sent to your account.";
                return Page();
            }
          

            if (userApproval.FirstTimeLogin == false)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                
                if (ModelState.IsValid)
                {

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");
                        return RedirectToPage("./Index");
                    }
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        ErrorMessage = "Password entered is invalid. Please enter a valid password to sign in to your account.";
                    }

                    //var email = await _userManager.FindByEmailAsync(Input.Email);
                    //if (!await _userManager.IsEmailConfirmedAsync(email))
                    //{
                    //    ModelState.AddModelError(string.Empty,
                    //              "You must have a confirmed email to log in. Check your email to confirm your account.");
                    //    return Page();
                    //}

                }

            }
            else if (userApproval.FirstTimeLogin == true)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (ModelState.IsValid)
                {
                    if (result.Succeeded)
                    {
                        StatusMessage = "Account confirmed! Please fill out your user profile.";
                        _logger.LogInformation("User logged in.");
                        return Redirect("/Identity/Account/Manage/Index");
                    }
                    userApproval.FirstTimeLogin = false;
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        ErrorMessage = "Password entered is invalid. Please enter a valid password to sign in to your account.";
                    }

                }
                else
                {
                    ErrorMessage = "Invalid login attempt";
                }

            }

            //else
            // {
            //     //var email = await _userManager.FindByEmailAsync(Input.Email);
            //     //if (!await _userManager.IsEmailConfirmedAsync(email))
            //     //{
            //     //    ModelState.AddModelError(string.Empty,
            //     //              "You must have a confirmed email to log in. Check your email to confirm your account.");

            //     //}
            //     //}
            // }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }

}