using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceSolution.Data;
using FinanceSolution.Data.Models;
using FinanceSolution.Inteface.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSolution.Inteface.Pages.PaymentMethod
{
    public class IndexModel : PageModel
    {
        private FinanceSolutionContext context;

        public IndexModel(FinanceSolutionContext context)
        {
            this.context = context;
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
                List<PaymentMethodModel> pagto = context.PaymentMethod
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
                    data = result,
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
