using FinanceSolution.Data;
using FinanceSolution.Data.Models;
using FinanceSolution.Inteface.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceSolution.Inteface.Pages.AccountAccruals
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

        public async Task<JsonResult> OnPostAccruals(DataTableAjaxPostModel model)
        {
            try
            {
                List<AccountAccrualsModel> pagto = _context.AccountAccruals
                    .Where((e) => e.IsDeleted == false)
                    .ToList();

                var result = pagto.Select(x => new {
                    Id = x.Id,
                    Description = x.Description,
                    Type = x.Type
                });

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
