using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanceSolution.Data.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [MaxLength(120)]
        public string Lastname { get; set; }

        [Required]
        public string Username { get; set; } 

        [Required]
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }        
    }
}
