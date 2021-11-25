using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanceSolution.Data.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        [MaxLength(120)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(120)]
        public string Sobrenome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
        public List<LancamentoModel> Lancamentos { get; set; }
        private bool status = true;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        
    }
}
