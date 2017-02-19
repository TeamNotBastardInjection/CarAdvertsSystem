using System.Linq;
using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.MVP.Search
{
    public class SearchViewModel
    {
        public IQueryable<Advert> Adverts { get; set; }

        public string PicturePath { get; set; }
    }
}
