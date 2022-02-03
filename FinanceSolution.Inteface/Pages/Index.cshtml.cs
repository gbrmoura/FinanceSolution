using System;
using FinanceSolution.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSolution.Inteface.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        
        

        public readonly FinanceSolutionContext _context;
        public IndexModel(FinanceSolutionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Date { get; set; }
        
        [BindProperty]
        public string Amount { get; set; }

        [BindProperty]
        public string CashIn { get; set; }

        [BindProperty]
        public string CashOut { get; set; }

        public void OnGet()
        {
            this.Date = DateTime.Now.ToString("MM/yyyy");
            
            var entrys = _context.AccountEntry;
            

        }
    }
}
