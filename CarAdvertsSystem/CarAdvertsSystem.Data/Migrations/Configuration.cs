using System.Data.Entity.Migrations;

namespace CarAdvertsSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CarAdvertsSystem.Data.CarAdvertsSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarAdvertsSystem.Data.CarAdvertsSystemDbContext context)
        {

        }
    }
}
