using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RPiWebsiteNET5.Data;
using RPiWebsiteNET5.Models;
using RPiWebsiteNET5.ViewModels;

namespace RPiWebsiteNET5.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly RPiWebsiteNET5.Data.RPiWebsiteContext _context;

        public IndexModel(RPiWebsiteNET5.Data.RPiWebsiteContext context)
        {
            _context = context;
        }

        public List<UserVM> UserVMList { get;set; }

        [BindProperty]
        public string UserVMListJSON 
        {
            get
            {
                return JsonSerializer.Serialize(UserVMList);
            }
        }

        public async Task OnGetAsync()
        {
            List<User> userList = await _context.Users.ToListAsync();

            UserVMList = new List<UserVM>();

            foreach(User aUser in userList)
            {
                UserVM aUserVM = new UserVM(aUser);
                UserVMList.Add(aUserVM);
            }
        }
    }
}
