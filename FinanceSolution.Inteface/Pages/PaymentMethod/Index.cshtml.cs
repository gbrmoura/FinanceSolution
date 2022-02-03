using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceSolution.Data;
using FinanceSolution.Data.Models;
using FinanceSolution.Inteface.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinanceSolution.Inteface.ExtensionMethods;
using System.Data.Entity;

namespace FinanceSolution.Inteface.Pages.PaymentMethod
{
    public class IndexModel : PageModel
    {
        private FinanceSolutionContext _context;

        public IndexModel(FinanceSolutionContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult OnGet()
        {
            return Page();
        }

        [HttpPost]
        public async Task<JsonResult> OnPostPayment(DataTableAjaxPostModel model)
        {
            try
            {

                List<PaymentMethodModel> pagto = await _context.PaymentMethod
                    .Where((e) => e.UserId == Int16.Parse(User.Identity.GetUserId()) && e.IsDeleted == false)
                    .ToListAsync();

                var result = pagto.Select(x => new
                {
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
