using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinanceSolution.Data;
using FinanceSolution.Inteface.Services;
using Microsoft.AspNetCore.Authentication;
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

        public async Task<IActionResult> OnPost()
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

                var claims = new List<Claim>()
                {
                    new Claim("id", user.Codigo.ToString()),
                    new Claim("name", user.Nome),
                    new Claim("email", user.Email),
                    new Claim("role", "USER")
                };

                var identity = new ClaimsIdentity(claims, "login");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return Redirect("/");
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
