﻿using FinanceSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceSolution.Data.Models
{
    public class AccountAccrualsModel
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public AccountAccrualsEnum Type { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
    }
}
