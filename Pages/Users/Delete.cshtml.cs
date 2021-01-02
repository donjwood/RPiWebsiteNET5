using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RPiWebsiteNET5.Data;
using RPiWebsiteNET5.Identity.Extensions;
using RPiWebsiteNET5.Models;
using RPiWebsiteNET5.ViewModels;

namespace RPiWebsiteNET5.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly RPiWebsiteNET5.Data.RPiWebsiteContext _context;

        public DeleteModel(RPiWebsiteNET5.Data.RPiWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserVM UserVM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Check that the user is not a non-admin attempting to delete a record.
            if(!User.GetClaimBoolValue("IsAdmin"))
            {
                return Unauthorized();
            }

            if (id == null)
            {
                return NotFound();
            }

            User userRecord = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);

            if (userRecord == null)
            {
                return NotFound();
            }

            UserVM = new UserVM(userRecord);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Check that the user is not a non-admin attempting to delete a record.
            if(!User.GetClaimBoolValue("IsAdmin"))
            {
                return Unauthorized();
            }

            if (id == null)
            {
                return NotFound();
            }

            User userRecord = await _context.Users.FindAsync(id);

            if (userRecord != null)
            {
                _context.Users.Remove(userRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
