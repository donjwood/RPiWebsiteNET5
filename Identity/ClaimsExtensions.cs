using System.Linq;
using System.Security.Claims;

namespace RPiWebsiteNET5.Identity.Extensions
{
    public static class ClaimsExtensions
    {
        public static Claim GetClaim(this ClaimsPrincipal principal, string claimType)
        {
            return ((ClaimsIdentity)principal.Identity).Claims.Where(c => c.Type == claimType).FirstOrDefault();
        }

        public static string GetClaimValue(this ClaimsPrincipal principal, string claimType)
        {
            var claim = GetClaim(principal, claimType);
            return claim != null ? claim.Value : null;
        }

        public static int GetClaimIntValue(this ClaimsPrincipal principal, string claimType)
        {
            return int.Parse(GetClaimValue(principal, claimType));
        }

        public static bool GetClaimBoolValue(this ClaimsPrincipal principal, string claimType)
        {
            return bool.Parse(GetClaimValue(principal, claimType));
        }
    }
}