using FinanceSolution.Data;
using FinanceSolution.Inteface.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSolution.Inteface.Pages.Usuario
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Senha { get; set; }

        private PasswordService password { get; set; }
        private FinanceSolutionContext context { get; set; }

        public LoginModel(PasswordService password, FinanceSolutionContext context)
        {
            this.password = password;
            this.context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {


            return Page();
        }
    }
}
