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
        private readonly IPictureServices pictureSerrvice;

        public SearcherPresenter(ISearchView view, IAdvertServices advertService, IPictureServices pictureSerrvice) 
            : base(view)
        {
            this.advertService = advertService;
            this.pictureSerrvice = pictureSerrvice;

            this.View.OnSearchAdverts += View_OnSearchAdverts;
            this.View.OnGetPicturePath += View_OnGetPicturePath;
        }

        private void View_OnGetPicturePath(object sender, GetPicturePathEventArgs e)
        {
            var path =  this.pictureSerrvice.GetFirstPicturesNameByAdvertId(e.AdvertId);
            this.View.Model.PicturePath = path;
        }

        private void View_OnSearchAdverts(object sender, SearchEventArgs e)
        {
            var adverts = this.advertService.GetAdvertsByMultipleParameters(
                e.VehcicleModelId,
                e.CityId, 
                e.MinPrice,
                e.MaxPrice, 
                e.YearFrom,
                e.YearTo);

            //var adverts = this.advertService.GetAllAdverts();

            this.View.Model.Adverts = adverts;
        }
    }
}
