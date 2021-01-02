using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RPiWebsiteNET5.Data;
using RPiWebsiteNET5.Identity.Extensions;
using RPiWebsiteNET5.Models;
using RPiWebsiteNET5.ViewModels;

namespace RPiWebsiteNET5.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly RPiWebsiteNET5.Data.RPiWebsiteContext _context;

        public CreateModel(RPiWebsiteNET5.Data.RPiWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserVM UserVM { get; set; }

        [BindProperty, DataType(DataType.Password)]
        [Display(Name = "New Password")]
        [Required(ErrorMessage = "You must enter a password.")]
        public string Password { get; set; }

        [BindProperty, DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "You must enter a password confirmation.")]
        [Compare(nameof(Password), ErrorMessage ="Confirmation password does not match.")]
        public string PasswordConf { get; set; }


        [BindProperty]
        public bool IsUpdateSuccessful { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }


        public IActionResult OnGet()
        {
            // Check that the user is not a non-admin attempting to create a record.
            if(!User.GetClaimBoolValue("IsAdmin"))
            {
                return Unauthorized();
            }
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check that the user is not a non-admin attempting to create a record.
            if(!User.GetClaimBoolValue("IsAdmin"))
            {
                return Unauthorized();
            }

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            User newUser = new User();
            _context.Entry(newUser).CurrentValues.SetValues(UserVM);
            newUser.PasswordHash = passwordHasher.HashPassword(newUser, Password);
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public JsonResult OnPostIsUsernameAvailable ([FromBody]User userObj)
        {
            bool isAvailable = !_context.Users.Any(e => e.Username == userObj.Username);
            return new JsonResult(isAvailable);
        }
    }
}
