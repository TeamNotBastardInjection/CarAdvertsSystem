using System.Linq;

using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.MVP.AdvertDetail
{
    public class AdvertDetailViewModel
    {
        public IQueryable<Advert> Adverts { get; set; }

        public IQueryable<Picture> Pictures { get; set; }
    }
}
