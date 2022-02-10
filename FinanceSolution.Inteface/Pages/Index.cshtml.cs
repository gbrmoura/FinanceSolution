using System;
using System.Linq;
using System.Threading.Tasks;
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
            var firstDateOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDateOfMonth = firstDateOfMonth.AddMonths(1).AddDays(-1);

            var query = _context.AccountEntry
                .Where(x => x.UserId == Int16.Parse(User.Identity.GetUserId()) && x.IsDeleted == false)
                .Where(x => x.Date >= firstDateOfMonth && x.Date <= lastDateOfMonth)
                .Include(x => x.AccountAccrual)
                .ToList();

            var cashIn = query.Where(x => x.AccountAccrual.Type == Data.Enums.AccountAccrualsEnum.CashInFlow).Sum(x => x.Value);
            var cashOut = query.Where(x => x.AccountAccrual.Type == Data.Enums.AccountAccrualsEnum.CashOutFlow).Sum(x => x.Value);
            var amount = cashIn - cashOut;

            this.CashIn = cashIn.ToString("C");
            this.CashOut = cashOut.ToString("C");
            this.Amount = amount.ToString("C");
            this.Date = date.ToString("MM/yyyy");

        }

        public async Task<IActionResult> OnPostChartAreaCashFlow()
        {
            try
            {
                var date = DateTime.Now;
                var firstDateOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDateOfMonth = firstDateOfMonth.AddMonths(1).AddDays(-1);

                var query = _context.AccountEntry
                    .Include(x => x.AccountAccrual)
                    .Where(x => x.UserId == Int16.Parse(User.Identity.GetUserId()) && x.IsDeleted == false)
                    .Where(x => x.Date >= firstDateOfMonth && x.Date <= lastDateOfMonth)
                    .ToList();

                return new JsonResult(new
                {
                    data = query,
                    recordsTotal = query.Count(),
                    recordsFiltered = query.Count(),
                });

            }
            catch (Exception e)
            {
                return new JsonResult(new
                {
                    recordsTotal = 0,
                    recordsFiltered = 0,
                    Exception = e,
                });
            }
        }

        public async Task<IActionResult> OnPostChartPizzaCashFlow(string type)
        {

            try
            {
                var date = DateTime.Now;
                var firstDateOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDateOfMonth = firstDateOfMonth.AddMonths(1).AddDays(-1);
                var typeEnum = Enum.Parse<Data.Enums.AccountAccrualsEnum>(type);

                var query = _context.AccountEntry
                    .Include(x => x.AccountAccrual)
                    .Where(x => x.UserId == Int16.Parse(User.Identity.GetUserId()) && x.IsDeleted == false && x.AccountAccrual.Type == typeEnum)
                    .Where(x => x.Date >= firstDateOfMonth && x.Date <= lastDateOfMonth)
                    .ToList();

                return new JsonResult(new
                {
                    data = query,
                    recordsTotal = query.Count(),
                    recordsFiltered = query.Count(),
                });

            }
            catch (Exception e)
            {
                return new JsonResult(new
                {
                    recordsTotal = 0,
                    recordsFiltered = 0,
                    Exception = e,
                });
            }

        }

    }
}
