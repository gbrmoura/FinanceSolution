using FinanceSolution.Data;
using FinanceSolution.Data.Models;
using FinanceSolution.Inteface.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace FinanceSolution.Inteface.Pages.Authorization
{
    public class RegisterModel : PageModel
    {

        [BindProperty]
        public UserModel User { get; set; }
        private PasswordService password { get; set; }
        private FinanceSolutionContext context { get; set; }

        public RegisterModel(PasswordService password, FinanceSolutionContext context)
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
            if (!ModelState.IsValid)
            {
                ViewData["error"] = true;
                return Page();
            }

            try
            {
                if (context.User.Any((e) => e.Username.Equals(User.Username)))
                {
                    ViewData["userExists"] = true;                  
                    return Page();
                }

                User.Password = password.EncryptPassword(User.Password);
                context.User.Add(User);
                context.SaveChanges();

                ViewData["success"] = true;
                return Page();
            }
            catch(Exception e)
            {
                ViewData["internal"] = true;
                return Page();
            }
        }
    }
}
