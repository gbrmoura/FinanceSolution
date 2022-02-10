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

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostRecords(DateTime begin, DateTime end)
        {

            try
            {
                var beginDate = begin;
                var endDate = end.AddHours(24);

                var query = _context.AccountEntry
                    .Include(x => x.AccountAccrual)
                    .Where(x => x.UserId == Int16.Parse(User.Identity.GetUserId()) && x.IsDeleted == false)
                    .Where(x => x.Date >= beginDate && x.Date <= endDate)
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

        public async Task<IActionResult> OnPostChartPizzaCashFlow(string type, DateTime begin, DateTime end)
        {

            try
            {
                var typeEnum = Enum.Parse<Data.Enums.AccountAccrualsEnum>(type);
                var beginDate = begin;
                var endDate = end.AddHours(24);

                var query = _context.AccountEntry
                    .Include(x => x.AccountAccrual)
                    .Where(x => x.UserId == Int16.Parse(User.Identity.GetUserId()) && x.IsDeleted == false && x.AccountAccrual.Type == typeEnum)
                    .Where(x => x.Date >= beginDate && x.Date <= endDate)
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
