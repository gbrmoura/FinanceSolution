using System;
using System.Linq;
using FinanceSolution.Data;
using FinanceSolution.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSolution.Inteface.Pages.AccountAccruals
{
    public class CreateModel : PageModel
    {
        private readonly FinanceSolutionContext _context;
        
        public CreateModel(FinanceSolutionContext context)
        {
            _context = context;
        }

        [BindProperty]        
        public AccountAccrualsModel AccountAccruals { get; set; }

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
                if (_context.AccountAccruals.Any(x => x.Description == AccountAccruals.Description && x.IsDeleted == false))
                {
                    ViewData["inUse"] = true;
                    return Page();
                }

                _context.AccountAccruals.Add(AccountAccruals);
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