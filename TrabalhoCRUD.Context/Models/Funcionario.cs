using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoCRUD.Context.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string DataNascimento { get; set; }
        public string Funcao { get; set; }
        public string Telefone { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Endereco { get; set; }
        public int IdCentroDistribuicao { get; set; }

        public virtual CentroDistribuicao CentrosDistribuicao { get; set; }
    }
}
