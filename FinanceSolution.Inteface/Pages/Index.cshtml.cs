using System;
using System.Linq;
using FinanceSolution.Data;
using FinanceSolution.Inteface.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FinanceSolution.Inteface.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        
        private readonly FinanceSolutionContext _context;
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
            var date = DateTime.Now;
            var query = _context.AccountEntry.Include(x => x.AccountAccrual).ToList();
            var entrys = query.Where(x => x.Date.Year == date.Year && x.Date.Month == date.Month).ToList();

            var cashIn = entrys.Where(x => x.AccountAccrual.Type == Data.Enums.AccountAccrualsEnum.CashInFlow).Sum(x => x.Value);
            var cashOut = entrys.Where(x => x.AccountAccrual.Type == Data.Enums.AccountAccrualsEnum.CashOutFlow).Sum(x => x.Value);
            var amount = cashIn - cashOut;

            this.CashIn = cashIn.ToString("C");
            this.CashOut = cashOut.ToString("C");
            this.Amount = amount.ToString("C");
            this.Date = date.ToString("MM/yyyy");

        }
    }
}
