using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceSolution.Data.Models
{
    public class UsuarioModel
    {
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int MyProperty { get; set; }
    }
}
