using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FinanceSolution.Data.Enums;

namespace FinanceSolution.Data.Models
{
    public class MetodoPagamentoModel
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        [MaxLength(120)]
        public string Descricao { get; set; }

        [Required]
        [Range(1, 4)]
        public MetodoPagamentoEnum Tipo { get; set; }
        public List<LancamentoModel> Lancamentos { get; set; }
        private bool status = true;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}