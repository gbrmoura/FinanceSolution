using System;
using System.Linq;
using FinanceSolution.Data;
using FinanceSolution.Inteface.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FinanceSolution.Inteface.Pages.Autorizacao
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Senha { get; set; }

        private PasswordService password { get; set; }
        private FinanceSolutionContext context { get; set; }
        private ILogger<LoginModel> log { get; set; }

        public LoginModel(PasswordService password, FinanceSolutionContext context, ILogger<LoginModel> log)
        {
            this.password = password;
            this.context = context;
            this.log = log;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(Senha))
            {
                ViewData["error"] = true;
                return Page();
            }

            try
            {
                var user = context.Usuario.FirstOrDefault(u => u.Email.Equals(Email));
                if (user == null)
                {
                    ViewData["emailNotFound"] = true;
                    return Page();
                }

                if (!password.VerifyPassword(Senha, user.Senha))
                {
                    ViewData["password"] = true;
                    return Page();
                }

                return Redirect("/Index");
            }
            catch (Exception e)
            {
                log.LogError(e, "Erro ao fazer login no sistema.");
                ViewData["internal"] = true;
                return Page();
            }
        }
    }
}
