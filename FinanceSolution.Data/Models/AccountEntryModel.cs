using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinanceSolution.Data.Enums;

namespace FinanceSolution.Data.Models
{
    public class AccountEntryModel
    {
        [Key]
        public int Id { get; set; }
        public float Value { get; set; }
        public DateTime Date { get; set; }
        
        [ForeignKey("AccountAccruals")]
        public int AccountAccrualsId { get; set; }
        public AccountAccrualsModel AccountAccrual { get; set; }

        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }
        public PaymentMethodModel PaymentMethod { get; set; }

        [ForeignKey("AccountFile")]
        public int AccountFileId { get; set; }
        public AccountFileModel AccountFile { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
    }
}