using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FinanceSolution.Data.Enums;

namespace FinanceSolution.Data.Models
{
    public class LancamentoTipoModel
    {
        [Key]
        public Guid Codigo { get; set; }

        [Required]
        [MaxLength(120)]
        public string Descricao { get; set; }

        [Required]
        [Range(1, 2)]
        public LancamentoTipoEnum Tipo { get; set; }

        private bool status = true;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}