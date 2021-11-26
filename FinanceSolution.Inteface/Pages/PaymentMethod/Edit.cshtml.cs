using System.Linq;
using FinanceSolution.Data;
using FinanceSolution.Data.Models;
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

        public IActionResult OnGet(int id)
        {
            Payment = _context.PaymentMethod
                .Where(e => e.Id == id && e.IsDeleted == true)
                .SingleOrDefault();

            if (Payment == null)
            {
                ViewData["notFound"] = true;
                return Page();
            }
            
            return Page();
        }

        // public IActionResult OnPost()
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         ViewData["error"] = true;
        //         return Page();
        //     }


        //     try
        //     {

        //     }
        //     catch ()
        //     {
            
        //     }
        // }
    }
}