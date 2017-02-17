using System.Linq;
using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.MVP.AdvertCreator
{
    public class AdvertSearcherViewModel
    {
        public IQueryable<Advert> Adverts { get; set; }
    }
}
