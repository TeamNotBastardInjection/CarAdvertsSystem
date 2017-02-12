using System.Data.Entity;
using CarAdvertsSystem.Data;
using CarAdvertsSystem.Data.Migrations;

namespace CarAdvertsSystem.WebFormsClient.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarAdvertsSystemDbContext, Configuration>());
            CarAdvertsSystemDbContext.Create().Database.CreateIfNotExists();
        }
    }
}