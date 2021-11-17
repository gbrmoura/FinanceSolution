using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceSolution.Data.Models
{
    public class LancamentoArquivoModel
    {
        [Key]
        public Guid Codigo { get; set; }
        
        [Required]
        [MaxLength(120)]
        public string Nome { get; set; }
        
        [Required]
        public string Stream { get; set; }

        [Required]
        [MaxLength(5)]
        public string Extensao { get; set; }

        [ForeignKey("Lancamento")]
        public Guid LancamentoCodigo { get; set; }
        public LancamentoModel Lancamento { get; set; }

        private bool status = true;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}