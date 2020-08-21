namespace TrabalhoCRUD.Context.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TrabalhoCRUD.Context.DistribuicaoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TrabalhoCRUD.Context.DistribuicaoContext context)
        {
        }
    }
}
