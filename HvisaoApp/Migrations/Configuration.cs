namespace HvisaoApp.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.BancoContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "HvisaoApp.Models.BancoContexto";
        }

        protected override void Seed(Models.BancoContexto context)
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
        }
    }
}