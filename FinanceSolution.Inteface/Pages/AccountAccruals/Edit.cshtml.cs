using System;
using System.Linq;
using FinanceSolution.Data;
using FinanceSolution.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSolution.Inteface.Pages.AccountAccruals
{
    public class EditModel : PageModel
    {
        private readonly FinanceSolutionContext _context;

        public EditModel(FinanceSolutionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AccountAccrualsModel AccountAccrual { get; set; }
        
        public IActionResult OnGet(int id)
        {
            AccountAccrual = _context.AccountAccruals
                .Where(e => e.Id == id && e.IsDeleted == false)
                .SingleOrDefault();

            if (AccountAccrual == null)
            {
                ViewData["notFound"] = true;
                return Page();
            }
            
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
                var accountAccruals = _context.AccountAccruals
                    .Where(e => e.Id == AccountAccrual.Id && e.IsDeleted == false)
                    .SingleOrDefault();

                if (accountAccruals == null)
                {
                    ViewData["notFound"] = true;
                    return Page();
                }
                
                accountAccruals.Description = AccountAccrual.Description;
                accountAccruals.Type = AccountAccrual.Type;
                accountAccruals.IsModified = true;
                accountAccruals.IsDeleted = false;

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
