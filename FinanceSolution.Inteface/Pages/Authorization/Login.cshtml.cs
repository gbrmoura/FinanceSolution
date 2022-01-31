using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinanceSolution.Data;
using FinanceSolution.Inteface.Interfaces;
using FinanceSolution.Inteface.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FinanceSolution.Inteface.Pages.Authorization
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        private readonly IPasswordService _password;
        private readonly FinanceSolutionContext _context;

        public LoginModel(IPasswordService password, FinanceSolutionContext context)
        {
            this._password = password;
            this._context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password))
            {
                ViewData["error"] = true;
                return Page();
            }

            try
            {
                var user = _context.User.SingleOrDefault(u => u.Username.Equals(Username));
                if (user == null)
                {
                    ViewData["userNotFound"] = true;
                    return Page();
                }

                if (!_password.VerifyPassword(Password, user.Password))
                {
                    ViewData["password"] = true;
                    return Page();
                }

                var claims = new List<Claim>()
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("name", user.Name),
                    new Claim("username", user.Username),
                    new Claim("role", "USER")
                };

                var identity = new ClaimsIdentity(claims, "login");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return Redirect("/");
            }
            catch (Exception e)
            {
                ViewData["internal"] = true;
                return Page();
            }
        }
    }
}
