using System.Linq;

using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.MVP.EditAdverts
{
    public class EditAdvertsViewModel
    {
        public IQueryable<Advert> Adverts { get; set; }
    }
}
