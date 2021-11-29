using System;
using System.Linq;
using FinanceSolution.Data;
using FinanceSolution.Data.Enums;
using FinanceSolution.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSolution.Inteface.Pages.PaymentMethod
{
    public class CreateModel : PageModel
    {
        private readonly FinanceSolutionContext _context;

        public CreateModel(FinanceSolutionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PaymentMethodModel Payment { get; set; }

        public IActionResult OnGet()
        {
            Payment = new PaymentMethodModel();
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
                if (_context.PaymentMethod.Any(x => x.Description == Payment.Description && x.IsDeleted == false))
                {
                    ViewData["inUse"] = true;
                    return Page();
                }

                _context.PaymentMethod.Add(Payment);
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
