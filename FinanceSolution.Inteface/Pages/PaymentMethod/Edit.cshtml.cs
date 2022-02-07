using System;
using System.Linq;
using FinanceSolution.Data;
using FinanceSolution.Data.Models;
using FinanceSolution.Inteface.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSolution.Inteface.Pages.PaymentMethod
{
    public class EditModel : PageModel
    {
        private readonly FinanceSolutionContext _context;

        public EditModel(FinanceSolutionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PaymentMethodModel Payment { get; set; }

        public IActionResult OnGet([FromQuery] int id)
        {
            Payment = _context.PaymentMethod
                .Where(e => e.Id == id && e.IsDeleted == false)
                .SingleOrDefault();

            if (Payment == null)
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
                var payment = _context.PaymentMethod
                    .Where(e => e.Id == Payment.Id && e.IsDeleted == false)
                    .SingleOrDefault();

                if (payment == null)
                {
                    ViewData["notFound"] = true;
                    return Page();
                }

                var userId = Int16.Parse(User.Identity.GetUserId());
                var user = _context.User.FirstOrDefault(x => x.Id == userId);

                if (user == null) {
                    ViewData["error"] = true;
                    return Page();
                }

                payment.Description = Payment.Description;
                payment.Type = Payment.Type;
                payment.User = user;
                payment.UserId = user.Id;
                payment.IsModified = true;
                payment.IsDeleted = false;
                
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
