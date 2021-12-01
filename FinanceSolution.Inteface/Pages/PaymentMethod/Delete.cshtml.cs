using System;
using System.Linq;
using FinanceSolution.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSolution.Inteface.Pages.PaymentMethod
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
                var payment = _context.PaymentMethod
                    .Where(e => e.Id == id && e.IsDeleted == false)
                    .SingleOrDefault();

                if (payment == null)
                {
                    ViewData["notFound"] = true;
                    return Page();
                }

                payment.IsDeleted = true;
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
