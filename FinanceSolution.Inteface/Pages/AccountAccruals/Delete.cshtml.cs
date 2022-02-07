using System;
using System.Linq;
using FinanceSolution.Data;
using FinanceSolution.Inteface.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSolution.Inteface.Pages.AccountAccruals
{
    public class DeleteModel : PageModel
    {
        private readonly FinanceSolutionContext _context;

        public DeleteModel(FinanceSolutionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            try
            {
                var accountAccruals = _context.AccountAccruals
                    .Where(e => e.Id == id && e.UserId == Int16.Parse(User.Identity.GetUserId()) && e.IsDeleted == false)
                    .SingleOrDefault();

                if (accountAccruals == null)
                {
                    ViewData["notFound"] = true;
                    return Page();
                }

                accountAccruals.IsDeleted = true;
                _context.SaveChanges();

                ViewData["success"] = true;
                return Page();
            }
            catch (Exception e)
            {
                ViewData["internal"] = true;
                return Page();
            }
        }
    }
}
