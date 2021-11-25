using System.Collections.Generic;
using System.Linq;
using FinanceSolution.Data;
using FinanceSolution.Data.Models;
using FinanceSolution.Inteface.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSolution.Inteface.Pages.MetodoPagamento
{
    public class IndexModel : PageModel
    {
        private FinanceSolutionContext context;

        public IndexModel(FinanceSolutionContext context)
        {
            this.context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    
        public IActionResult OnPostPagto(DataTableAjaxPostModel model)
        {
            List<MetodoPagamentoModel> pagto = context.MetodoPagamento
                .Where((e) => e.Status == true)                
                .ToList();
            
            var result = pagto.Select(x => new{
                Codigo = x.Codigo,
                Descricao = x.Descricao,
                Status = x.Status
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

    }
}
