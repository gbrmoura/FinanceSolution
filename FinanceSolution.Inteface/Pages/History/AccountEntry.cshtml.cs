using System;
using System.Linq;
using System.Threading.Tasks;
using FinanceSolution.Data;
using FinanceSolution.Inteface.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FinanceSolution.Inteface.Pages.History
{
    [Authorize]
    public class AccountEntryModel : PageModel
    {

        private readonly FinanceSolutionContext _context;

        public AccountEntryModel(FinanceSolutionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Amount { get; set; }

        [BindProperty]
        public string CashIn { get; set; }

        [BindProperty]
        public string CashOut { get; set; }

        public IActionResult OnGet()
        {
            this.Amount = "0,00";
            this.CashIn = "0,00";
            this.CashOut = "0,00";

            return Page();
        }

    }
}
