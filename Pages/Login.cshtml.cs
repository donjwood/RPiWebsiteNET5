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

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            User aUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == UserName);

            if (aUser == null)
            {
                return Page();
            }

            if (passwordHasher.VerifyHashedPassword(aUser, aUser.PasswordHash, Password) != PasswordVerificationResult.Failed)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, UserName)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToPage("/index");
            }
            else
            {
                return Page();
            }
        }
    }
}
