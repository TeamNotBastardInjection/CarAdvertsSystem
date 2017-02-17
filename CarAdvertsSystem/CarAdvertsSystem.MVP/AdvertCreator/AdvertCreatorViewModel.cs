using System.Linq;
using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.MVP.AdvertCreator
{
    public class AdvertCreatorViewModel
    {
        public IQueryable<City> Cities { get; set; }

        public IQueryable<Category> Categories { get; set; }

        public IQueryable<Manufacturer> Manufacturers { get; set; }

        public IQueryable<VehicleModel> VehicleModels { get; set; }
    }
}
