using System.Security.Claims;
using System.Security.Principal;

namespace FinanceSolution.Inteface.ExtensionMethods
{
    public static class IndentityExtensions
    {

        public static string GetUserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("id");
            return claim?.Value;
        }

        public static string GetUserRole(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("role");
            return claim?.Value;
        }

        public static string GetUserName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("name");
            return claim?.Value;
        }

        public static string GetShortUserEmail(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("username");
            return claim?.Value;
        }
    }
}
