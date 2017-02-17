using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdvertsSystem.Data.Services.Contracts;
using WebFormsMvp;

namespace CarAdvertsSystem.MVP.Search
{
    public class SearcherPresenter : Presenter<ISearchView>
    {
        private readonly IAdvertServices advertService;

        public SearcherPresenter(ISearchView view, IAdvertServices advertService) 
            : base(view)
        {
            this.advertService = advertService;

            this.View.OnSearchAdverts += View_OnSearchAdverts;
        }

        private void View_OnSearchAdverts(object sender, SearchEventArgs e)
        {
            //var adverts = this.advertService.GetAdvertsByMultipleParameters(e.VehcicleModelId, e.CityId, e.MinPrice,
            //    e.MaxPrice, e.YearFrom, e.YearTo);

            var adverts = this.advertService.GetAllAdverts();

            this.View.Model.Adverts = adverts;
        }
    }
}
