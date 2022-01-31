using System;
using System.Collections.Generic;
using System.Linq;
using FinanceSolution.Data;
using FinanceSolution.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSolution.Inteface.Pages.AccountEntry
{
    public class CreateModel : PageModel
    {

        [BindProperty]
        public AccountEntryModel AccountEntry { get; set; }

        [BindProperty]
        public List<AccountAccrualsModel> AccountAccruals { get; set; }
        
        [BindProperty]
        public List<PaymentMethodModel> AccountPayments { get; set; }

        private readonly FinanceSolutionContext _context;

        public CreateModel(FinanceSolutionContext context)
        {
            this._context = context;
        }

        public IActionResult OnGet()
        {
            AccountAccruals = _context.AccountAccruals
                .Where(x => x.IsDeleted == false)
                .ToList();
            
            AccountPayments = _context.PaymentMethod
                .Where(x => x.IsDeleted == false)
                .ToList();

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
                
                if (!_context.AccountAccruals.Any(x => x.Id == AccountEntry.AccountAccrualId)) 
                {
                    ViewData["accountaccruals"] = true;
                    return Page();
                }

                if (!_context.PaymentMethod.Any(x => x.Id == AccountEntry.PaymentMethodId)) 
                {
                    ViewData["accountpayments"] = true;
                    return Page();
                }

                AccountEntry.AccountAccrual = _context.AccountAccruals
                    .Where(x => x.Id == AccountEntry.AccountAccrualId)
                    .FirstOrDefault();

                AccountEntry.PaymentMethod = _context.PaymentMethod
                    .Where(x => x.Id == AccountEntry.PaymentMethodId)
                    .FirstOrDefault();

                _context.AccountEntry.Add(AccountEntry);
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
