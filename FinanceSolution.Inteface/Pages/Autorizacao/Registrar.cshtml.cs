using FinanceSolution.Data;
using FinanceSolution.Data.Models;
using FinanceSolution.Inteface.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace FinanceSolution.Inteface.Pages.Autorizacao
{
    public class RegistrarModel : PageModel
    {

        [BindProperty]
        public UsuarioModel Usuario { get; set; }
        private PasswordService password { get; set; }
        private FinanceSolutionContext context { get; set; }
        private ILogger<RegistrarModel> log { get; set; }

        public RegistrarModel(PasswordService password, FinanceSolutionContext context, ILogger<RegistrarModel> log)
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
            if (!ModelState.IsValid)
            {
                ViewData["error"] = true;
                return Page();
            }

            try
            {
                if (context.Usuario.Any((e) => e.Email.Equals(Usuario.Email)))
                {
                    ViewData["emailInUse"] = true;                  
                    return Page();
                }

                Usuario.Senha = password.EncryptPassword(Usuario.Senha);
                context.Usuario.Add(Usuario);
                context.SaveChanges();

                ViewData["success"] = true;
                return Page();
            }
            catch(Exception e)
            {
                log.LogError(e, "Erro ao registrar usuario.");
                ViewData["internal"] = true;
                return Page();
            }
        }
    }
}
