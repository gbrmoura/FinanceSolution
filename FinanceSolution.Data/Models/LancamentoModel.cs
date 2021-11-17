using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceSolution.Data.Models
{
    public class LancamentoModel
    {
        [Key]
        public Guid Codigo { get; set; }
        
        [Required]
        [MaxLength(120)]
        public string Descricao { get; set; }
        
        [Required]
        public float Valor { get; set; }
        public DateTime Data { get; set; }

        [Required]
        [MaxLength(240)]
        public string Observacao { get; set; }
        
        public List<LancamentoArquivoModel> LancamentoArquivos { get; set; }

        [ForeignKey("LancamentoTipo")]
        public Guid LancamentoTipoCodigo { get; set; }
        public LancamentoTipoModel LancamentoTipo { get; set; }

        [ForeignKey("MetodoPagamento")]
        public Guid MetodoPagamentoCodigo { get; set; }
        public MetodoPagamentoModel MetodoPagamento { get; set; }

        [ForeignKey("Usuario")]
        public Guid UsuarioCodigo { get; set; }
        public UsuarioModel Usuario { get; set; }

        private bool status = true;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}