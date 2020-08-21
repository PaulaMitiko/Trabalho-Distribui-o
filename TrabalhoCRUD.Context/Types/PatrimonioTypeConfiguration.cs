using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoCRUD.Context.Models;

namespace TrabalhoCRUD.Context.Types
{
    public class PatrimonioTypeConfiguration : EntityTypeConfiguration<Patrimonio>
    {
        public PatrimonioTypeConfiguration()
        {
            HasKey(q => q.Id);

            Property(q => q.Equipamento).HasMaxLength(30);
            Property(q => q.Setor).HasMaxLength(20);
            Property(q => q.Responsavel).HasMaxLength(100);

            HasRequired(q => q.CentrosDistribuicao).WithMany().HasForeignKey(q => q.IdCentroDistribuicao);
        }
    }
}
