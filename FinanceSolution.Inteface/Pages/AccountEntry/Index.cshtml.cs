using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FinanceSolution.Data;
using FinanceSolution.Data.Models;
using FinanceSolution.Inteface.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSolution.Inteface.Pages.AccountEntry
{
    public class IndexModel : PageModel
    {
        private readonly FinanceSolutionContext _context;
        
        public IndexModel(FinanceSolutionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<JsonResult> OnPostEntrys(DataTableAjaxPostModel model)
        {
            try
            {
                var query = _context.AccountEntry.AsNoTracking()
                    .Include(x => x.AccountAccrual)
                    .Include(x => x.PaymentMethod)
                    .Where((e) => e.IsDeleted == false);

                var result = query.Select(x => new {
                    Id = x.Id,
                    Description = x.Description,
                    Value = x.Value,
                    Date = x.Date.ToString("dd/MM/yyyy hh:mm tt"),
                    Accruals = x.AccountAccrual.Description,
                    AccrualsType = x.AccountAccrual.Type,
                    PaymentMethod = x.PaymentMethod.Description,
                    PaymentType = x.PaymentMethod.Type
                }).ToList();

                var data = result
                    .Skip(model.start)
                    .Take(model.length)
                    .ToArray();

                return new JsonResult(new
                {
                    draw = model.draw,
                    recordsTotal = result.Count(),
                    recordsFiltered = result.Count(),
                    data = data,
                });
            }
            catch (Exception e)
            {
                return new JsonResult(new
                {
                    draw = model.draw,
                    recordsTotal = 0,
                    recordsFiltered = 0,
                    Exception = e,
                });
            }

        }

    }
}
