using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinanceSolution.Data;
using System.Linq;
using System;
using FinanceSolution.Inteface.ExtensionMethods;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FinanceSolution.Inteface.Pages.AccountEntry
{
    public class DeleteModel : PageModel
    {
        private readonly FinanceSolutionContext _context;

        public DeleteModel(FinanceSolutionContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
            
                var entry = _context.AccountEntry.AsNoTracking()
                    .Where(x => x.UserId == Int16.Parse(User.Identity.GetUserId()))
                    .Where(e => e.Id == id && e.IsDeleted == false)
                    .FirstOrDefault();

                if (entry == null)
                {
                    ViewData["notFound"] = true;
                    return Page();
                }

                entry.IsDeleted = true;
                entry.IsModified = true;

                _context.AccountEntry.Update(entry);
                await _context.SaveChangesAsync();

                ViewData["success"] = true;
                return Page();
            }
            catch (Exception e)
            {
                ViewData["internal"] = true;
                return Page();
            }
        }
    }
}
