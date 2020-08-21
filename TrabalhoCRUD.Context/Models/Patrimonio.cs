using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoCRUD.Context.Models
{
    public class Patrimonio
    {
        public int Id { get; set; }
        public string Equipamento { get; set; }
        public string Setor { get; set; }
        public string Responsavel { get; set; }
        public int IdCentroDistribuicao { get; set; }

        public virtual CentroDistribuicao CentrosDistribuicao { get; set; }
    }
}
