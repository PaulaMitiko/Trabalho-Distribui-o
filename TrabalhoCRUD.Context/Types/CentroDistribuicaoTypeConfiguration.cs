using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoCRUD.Context.Models;

namespace TrabalhoCRUD.Context.Types
{
    public class CentroDistribuicaoTypeConfiguration : EntityTypeConfiguration<CentroDistribuicao>
    {
        public CentroDistribuicaoTypeConfiguration() 
        {
            HasKey(q => q.Id);

            Property(q => q.Cnpj).HasMaxLength(14);
            Property(q => q.RazaoSocial).HasMaxLength(100);
            Property(q => q.Telefone).HasMaxLength(20);
            Property(q => q.Tipo).HasMaxLength(50);
            Property(q => q.Endereco).HasMaxLength(200);

            HasMany(q => q.Funcionarios).WithRequired().HasForeignKey(q => q.IdCentroDistribuicao);
            HasMany(q => q.Patrimonios).WithRequired().HasForeignKey(q => q.IdCentroDistribuicao);

        }
    }
}
