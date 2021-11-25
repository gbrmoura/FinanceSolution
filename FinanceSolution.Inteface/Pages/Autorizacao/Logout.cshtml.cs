using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace FinanceSolution.Inteface.Pages.Autorizacao
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            await AuthenticationHttpContextExtensions.SignOutAsync(HttpContext);
            return Redirect("/");
        }
    }
}
