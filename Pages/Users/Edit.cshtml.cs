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

        public User UserRecord {get; set;}

        [BindProperty]
        public UserVM UserVM { get; set; }

        [BindProperty]
        public string JsonUserRecord {
            get
            {
                return JsonSerializer.Serialize(UserVM);
            }
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserRecord = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);

            if (UserRecord == null)
            {
                return NotFound();
            }

            UserVM = new UserVM(UserRecord);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserVM.SaveTo(UserRecord);
            _context.Attach(UserRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(UserRecord.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        public JsonResult OnPostIsUsernameAvailable ([FromBody]User userObj)
        {
            int currentUserID = int.Parse(User.GetClaimValue(ClaimTypes.Sid));
            bool isAvailable = !_context.Users.Any(e => e.UserName == userObj.UserName && e.ID != currentUserID);
            return new JsonResult(new {isUserNameAvaliable = isAvailable});
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
