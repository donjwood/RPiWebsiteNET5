using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

using RPiWebsiteNET5.Identity.Extensions;

namespace RPiWebsiteNET5.Controllers
{
    public class ValidationController : Controller
    {

        private readonly RPiWebsiteNET5.Data.RPiWebsiteContext _context;

        public ValidationController(RPiWebsiteNET5.Data.RPiWebsiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        [HttpPost]
        public JsonResult isUsernameAvailable([Bind(Prefix = "UserVM.Username")] string username, [Bind(Prefix = "UserVM.ID")] int id) 
        {
            bool isAvailable = !_context.Users.Any(e => e.Username == username && e.ID != id);
            return new JsonResult(isAvailable);
        }
    }
}