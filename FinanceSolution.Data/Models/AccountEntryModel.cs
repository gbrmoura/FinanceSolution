using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinanceSolution.Data.Enums;

namespace FinanceSolution.Data.Models
{
    public class AccountEntryModel
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public DateTime Date { get; set; }
        
        [ForeignKey("AccountAccruals")]
        public int AccountAccrualId { get; set; }
        public AccountAccrualsModel AccountAccrual { get; set; }

        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }
        public PaymentMethodModel PaymentMethod { get; set; }
        public List<AccountFileModel> AccountFile { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
    }
}