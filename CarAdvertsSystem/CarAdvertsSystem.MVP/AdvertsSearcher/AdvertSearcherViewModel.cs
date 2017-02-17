using System.Linq;
using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.MVP.AdvertsSearcher
{
    public class AdvertSearcherViewModel
    {
        public IQueryable<City> Cities { get; set; }

        public IQueryable<Category> Categories { get; set; }

        public IQueryable<Manufacturer> Manufacturers { get; set; }

        public IQueryable<VehicleModel> VehicleModels { get; set; }
    }
}
