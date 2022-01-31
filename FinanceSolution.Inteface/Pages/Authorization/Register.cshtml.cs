using FinanceSolution.Data;
using FinanceSolution.Data.Models;
using FinanceSolution.Inteface.Interfaces;
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

        private readonly IPasswordService _password;
        private readonly FinanceSolutionContext _context;

        public RegisterModel(IPasswordService password, FinanceSolutionContext context)
        {
            this._password = password;
            this._context = context;
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
                if (_context.User.Any((e) => e.Username.Equals(User.Username)))
                {
                    ViewData["userExists"] = true;                  
                    return Page();
                }

                User.Password = _password.EncryptPassword(User.Password);
                _context.User.Add(User);
                _context.SaveChanges();

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
