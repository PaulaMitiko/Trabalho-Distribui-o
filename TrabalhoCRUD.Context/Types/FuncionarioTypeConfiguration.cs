using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoCRUD.Context.Models;

namespace TrabalhoCRUD.Context.Types
{
    public class FuncionarioTypeConfiguration : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioTypeConfiguration() 
        {
            HasKey(q => q.Id);

            Property(q => q.DataNascimento).HasMaxLength(10);
            Property(q => q.Funcao).HasMaxLength(20);
            Property(q => q.Telefone).HasMaxLength(10);
            Property(q => q.Nome).HasMaxLength(100);
            Property(q => q.Cpf).HasMaxLength(11);
            Property(q => q.Rg).HasMaxLength(15);
            Property(q => q.Endereco).HasMaxLength(200);

            HasRequired(q => q.CentrosDistribuicao).WithMany().HasForeignKey(q => q.IdCentroDistribuicao);
        }
    }
}
