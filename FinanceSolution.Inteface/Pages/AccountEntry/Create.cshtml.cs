using System;
using System.Collections.Generic;
using System.Linq;
using FinanceSolution.Data;
using FinanceSolution.Data.Enums;
using FinanceSolution.Data.Models;
using FinanceSolution.Inteface.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSolution.Inteface.Pages.AccountEntry
{
    public class CreateModel : PageModel
    {

        [BindProperty]
        public AccountEntryModel AccountEntry { get; set; }

        [BindProperty]
        public List<AccountAccrualsModel> AccountAccruals { get; set; }
        
        [BindProperty]
        public List<PaymentMethodModel> AccountPayments { get; set; }

        private readonly FinanceSolutionContext _context;

        public CreateModel(FinanceSolutionContext context)
        {
            this._context = context;
        }

        public IActionResult OnGet()
        {
            AccountAccruals = _context.AccountAccruals
                .Where(x => x.IsDeleted == false)
                .ToList();
            
            AccountPayments = _context.PaymentMethod
                .Where(x => x.IsDeleted == false)
                .ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["error"] = true;
                return Page();
            }

            try 
            {
                
                if (!_context.AccountAccruals.Any(x => x.Id == AccountEntry.AccountAccrualId)) 
                {
                    ViewData["accountaccruals"] = true;
                    return Page();
                }

                if (!_context.PaymentMethod.Any(x => x.Id == AccountEntry.PaymentMethodId)) 
                {
                    ViewData["accountpayments"] = true;
                    return Page();
                }

                var userId = Int16.Parse(User.Identity.GetUserId());
                var user = _context.User.FirstOrDefault(x => x.Id == userId);

                if (user == null) {
                    ViewData["internal"] = true;
                    return Page();
                }

                AccountEntry.AccountAccrual = _context.AccountAccruals
                    .Where(x => x.Id == AccountEntry.AccountAccrualId)
                    .FirstOrDefault();

                AccountEntry.PaymentMethod = _context.PaymentMethod
                    .Where(x => x.Id == AccountEntry.PaymentMethodId)
                    .FirstOrDefault();

                AccountEntry.User = user;

                _context.AccountEntry.Add(AccountEntry);
                _context.SaveChanges();

                ViewData["success"] = true;
                return Page();
            }
            catch (Exception e)
            {
                ViewData["internal"] = true;
                return Page();
            }
        }

        public string GetPaymentMethodType(PaymentMethodEnum type)
        {
            switch(type)
            {
                case PaymentMethodEnum.Money:
                    return "Dinheiro";
                case PaymentMethodEnum.CreditCard:
                    return "Cartão de Crédito";
                case PaymentMethodEnum.DebitCard:
                    return "Cartão de Débito";
                case PaymentMethodEnum.PIX:
                    return "PIX";
                default:
                    return "";
            }
        }

        public string GetAccountAccrualType(AccountAccrualsEnum type)
        {
            switch(type)
            {
                case AccountAccrualsEnum.CashInFlow:
                    return "Entrada";
                case AccountAccrualsEnum.CashOutFlow:
                    return "Saída";
                default:
                    return "";
            }
        }

    }
}
