namespace Trepapp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Trepapp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Trepapp.Models.EscaladorDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Trepapp.Models.EscaladorDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            new Escalador
            {
                Nom = "EscaladorTest1",
                Llinatge = "EscaladorTest1",
                Edat = 22,
                CorreuElectronic = "test1@test.com",
                Federat = false
            };
        }
    }
}
