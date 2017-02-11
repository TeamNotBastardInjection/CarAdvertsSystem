using System.Data.Entity.Migrations;

namespace CarAdvertsSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CarAdvertsSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarAdvertsSystemDbContext context)
        {

        }
    }
}
