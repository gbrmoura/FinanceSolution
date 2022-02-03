using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinanceSolution.Data.Enums;

namespace FinanceSolution.Data.Models
{
    public class PaymentMethodModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]	
        [MaxLength(60)]
        public string Description { get; set; }
        public PaymentMethodEnum Type { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
        
    }
}
