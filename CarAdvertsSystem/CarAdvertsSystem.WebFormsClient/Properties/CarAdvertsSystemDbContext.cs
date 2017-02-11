using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarAdvertsSystem.Data
{
    public class CarAdvertsSystemDbContext : IdentityDbContext<User>, ICarAdvertsSystemDbContext
    {
        public CarAdvertsSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static CarAdvertsSystemDbContext Create()
        {
            return new CarAdvertsSystemDbContext();
        }
    }
}
