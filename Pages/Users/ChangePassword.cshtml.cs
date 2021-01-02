using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using RPiWebsiteNET5.Identity.Extensions;
using RPiWebsiteNET5.Models;

namespace RPiWebsiteNET5.Pages.Users
{
    public class ChangePasswordModel : PageModel
    {

        private readonly RPiWebsiteNET5.Data.RPiWebsiteContext _context;

        public ChangePasswordModel(RPiWebsiteNET5.Data.RPiWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty, DataType(DataType.Password)]
        [Display(Name = "New Password")]
        [Required(ErrorMessage = "You must enter a password.")]
        public string NewPassword { get; set; }

        [BindProperty, DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "You must enter a password confirmation.")]
        [Compare(nameof(NewPassword), ErrorMessage ="Confirmation password does not match.")]
        public string NewPasswordConf { get; set; }

        [BindProperty]
        public bool IsUpdateSuccessful { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public IActionResult OnGet(int? id)
        {
            // Check to see if the user can access this page with this i
            if(!User.GetClaimBoolValue("IsAdmin") && id.Value != User.GetClaimIntValue(ClaimTypes.Sid))
            {
                // A non admin is attempting to change a password that is not theirs.
                return Unauthorized();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {

            // Clear properties
            IsUpdateSuccessful = false;
            ErrorMessage = string.Empty;

            // Check that the page is valid.
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid input.";
                return Page();
            }

            if(!User.GetClaimBoolValue("IsAdmin") && id.Value != User.GetClaimIntValue(ClaimTypes.Sid))
            {
                // A non admin is attempting to change a password that is not theirs.
                return Unauthorized();
            }

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            try
            {
                // Page is valid, find user.
                User userToUpdate = await _context.Users.FindAsync(id);
                userToUpdate.PasswordHash = passwordHasher.HashPassword(userToUpdate, NewPassword);
                await _context.SaveChangesAsync();
                IsUpdateSuccessful = true;
                return Page();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id.Value))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
