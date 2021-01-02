using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RPiWebsiteNET5.Data;
using RPiWebsiteNET5.Identity.Extensions;
using RPiWebsiteNET5.Models;
using RPiWebsiteNET5.ViewModels;

namespace RPiWebsiteNET5.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly RPiWebsiteNET5.Data.RPiWebsiteContext _context;

        public EditModel(RPiWebsiteNET5.Data.RPiWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserVM UserVM { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public bool IsUpdateSuccessful { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            IsUpdateSuccessful = false;
            if (id == null)
            {
                return NotFound();
            }

            // Check that the user is not a non-admin attempting to update someone else's record.
            if(!User.GetClaimBoolValue("IsAdmin") && id.Value != User.GetClaimIntValue(ClaimTypes.Sid))
            {
                return Unauthorized();
            }

            User userRecord = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);

            if (userRecord == null)
            {
                return NotFound();
            }

            UserVM = new UserVM(userRecord);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            IsUpdateSuccessful = false;
            ErrorMessage = string.Empty;

            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid input.";
                return Page();
            }

            var userToUpdate = await _context.Users.FindAsync(id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            // Check the state of various items before proceeding with the update.
            if(userToUpdate.Username == "admin" && UserVM.Username != "admin") 
            {
                // Admin username cannot be changed.
                return Unauthorized();
            }
            else if(_context.Users.Any(e => e.Username == UserVM.Username && e.ID != UserVM.ID))
            {
                ErrorMessage = "The username \"" + UserVM.Username + "\" is already taken.";
            }
            else if(!User.GetClaimBoolValue("IsAdmin") && userToUpdate.ID != User.GetClaimIntValue(ClaimTypes.Sid))
            {
                return Unauthorized();
            }
            else if (UserVM.IsAdmin != userToUpdate.IsAdmin && userToUpdate.ID == User.GetClaimIntValue(ClaimTypes.Sid))
            {
                // Users cannot change their own admin status.
                return Unauthorized();
            }

            // All tests passed, update the record.
            try
            {
                    _context.Entry(userToUpdate).CurrentValues.SetValues(UserVM);
                    await _context.SaveChangesAsync();
                    IsUpdateSuccessful = true;
                    return Page();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(UserVM.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        public JsonResult OnPostIsUsernameAvailable ([FromBody]User userObj)
        {
            bool isAvailable = !_context.Users.Any(e => e.Username == userObj.Username && e.ID != userObj.ID);
            return new JsonResult(isAvailable);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
