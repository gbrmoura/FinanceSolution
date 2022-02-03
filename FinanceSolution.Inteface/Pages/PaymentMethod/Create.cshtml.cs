using System;
using System.Linq;
using FinanceSolution.Data;
using FinanceSolution.Data.Enums;
using FinanceSolution.Data.Models;
using FinanceSolution.Inteface.ExtensionMethods;
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

                var userId = Int16.Parse(User.Identity.GetUserId());
                var user = _context.User.FirstOrDefault(x => x.Id == userId);

                if (user == null) {
                    ViewData["error"] = true;
                    return Page();
                }

                Payment.UserId = user.Id;

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
