using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace RPiWebsiteNET5.Controllers
{

    [AllowAnonymous]
    [Route("Auth")]
    public class AuthController : Controller
    {
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect(Url.Content("~/"));
            }

            await HttpContext.SignOutAsync();

            return Redirect("~/");
        }
    }

}