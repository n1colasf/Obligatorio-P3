using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ConsoleApp1.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<Dominio.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Dominio.Context";
        }

        protected override void Seed(Dominio.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}