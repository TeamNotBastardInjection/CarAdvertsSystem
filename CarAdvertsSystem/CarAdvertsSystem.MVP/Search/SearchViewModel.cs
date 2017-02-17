using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.MVP.Search
{
    public class SearchViewModel
    {
        public IQueryable<Advert> Adverts { get; set; }
    }
}
