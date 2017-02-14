using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarAdvertsSystem.Data
{
    public class CarAdvertsSystemDbContext : IdentityDbContext<User>, ICarAdvertsSystemDbContext
    {
        public CarAdvertsSystemDbContext()
            : base("CarAdvertsDb")
        {
        }

        public virtual IDbSet<Advert> Adverts { get; set; }
        public virtual IDbSet<City> Cities { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }
        public virtual IDbSet<VehicleModel> VehicleModels { get; set; }

        public static CarAdvertsSystemDbContext Create()
        {
            return new CarAdvertsSystemDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
