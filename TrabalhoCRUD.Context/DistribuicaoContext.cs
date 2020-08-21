using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrabalhoCRUD.Context.Models;

namespace TrabalhoCRUD.Context
{
    public class DistribuicaoContext : DbContext
    {
        public DistribuicaoContext() : base("DefaultConnection")
        { 
        }

        public DbSet<CentroDistribuicao> CentrosDistribuicao { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Patrimonio> Patrimonios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
