using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using RPiWebsiteNET5.Models;

namespace RPiWebsiteNET5.Pages
{
    public class LoginModel : PageModel
    {

        private readonly RPiWebsiteNET5.Data.RPiWebsiteContext _context;

        public LoginModel(RPiWebsiteNET5.Data.RPiWebsiteContext context)
        {
            _context = context;
        }

        private const string INVALID_USERNAME_PASSWORD_ERROR = "Invalid username or password.";

        [BindProperty]
        [Required(ErrorMessage = "The username is required.")]
        public string Username { get; set; }
        
        [BindProperty, DataType(DataType.Password)]
        [Required(ErrorMessage = "The password is required.")]
        public string Password { get; set; }

        [BindProperty]
        public string LoginError { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            // Clear any login error
            LoginError = string.Empty;

            // Check that the page is valid.
            if (ModelState.IsValid)
            {
                // Page is valid, find user.
                PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

                User aUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == Username);

                // User not found
                if (aUser == null)
                {
                    LoginError = INVALID_USERNAME_PASSWORD_ERROR;
                    return Page();
                }

                // Validate password.
                if (passwordHasher.VerifyHashedPassword(aUser, aUser.PasswordHash, Password) != PasswordVerificationResult.Failed)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Sid, aUser.ID.ToString()),
                        new Claim(ClaimTypes.GivenName, !String.IsNullOrEmpty(aUser.FirstName) ? aUser.FirstName : String.Empty),
                        new Claim("MiddleName", !String.IsNullOrEmpty(aUser.MiddleName) ? aUser.MiddleName : String.Empty),
                        new Claim(ClaimTypes.Surname, !String.IsNullOrEmpty(aUser.LastName) ? aUser.LastName : String.Empty),
                        new Claim(ClaimTypes.Email, !String.IsNullOrEmpty(aUser.Email) ? aUser.Email : String.Empty),
                        new Claim(ClaimTypes.Name, aUser.Username),
                        new Claim("IsAdmin", aUser.IsAdmin.ToString()),
                        new Claim("DisplayName", aUser.FirstName + " " + aUser.LastName)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    if (string.IsNullOrEmpty(Request.Query["ReturnUrl"]))
                    {
                        return RedirectToPage("/index");
                    }
                    else
                    {
                        return Redirect(Request.Query["ReturnUrl"]);
                    }
                }
                else
                {
                    LoginError = INVALID_USERNAME_PASSWORD_ERROR;
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
