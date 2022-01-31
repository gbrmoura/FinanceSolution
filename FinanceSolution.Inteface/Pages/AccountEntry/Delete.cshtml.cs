using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinanceSolution.Data;
using System.Linq;
using System;

namespace FinanceSolution.Inteface.Pages.AccountEntry
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
                var accountEntry = _context.AccountEntry
                    .Where(e => e.Id == id && e.IsDeleted == false)
                    .SingleOrDefault();

                if (accountEntry == null)
                {
                    ViewData["notFound"] = true;
                    return Page();
                }

                accountEntry.IsDeleted = true;
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
