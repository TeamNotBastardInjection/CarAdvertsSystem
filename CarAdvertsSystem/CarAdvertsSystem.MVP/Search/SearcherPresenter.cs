using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
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
            Guard.WhenArgument(view, "Parameter view is null!!!").IsNull().Throw();
            Guard.WhenArgument(advertService, "Parameter advertService is null!!!").IsNull().Throw();
            Guard.WhenArgument(pictureSerrvice, "Parameter pictureSerrvice is null!!!").IsNull().Throw();

            this.advertService = advertService;
            this.pictureSerrvice = pictureSerrvice;

            this.View.OnSearchAdverts += View_OnSearchAdverts;
            this.View.OnGetPicturePath += View_OnGetPicturePath;
        }

        public void View_OnGetPicturePath(object sender, GetPicturePathEventArgs e)
        {
            Guard.WhenArgument(e.AdvertId, "Advert Id is negative!!!").IsLessThan(1).Throw();

            var path = this.pictureSerrvice.GetFirstPicturesNameByAdvertId(e.AdvertId);
            this.View.Model.PicturePath = path;
        }

        public void View_OnSearchAdverts(object sender, SearchEventArgs e)
        {
            Guard.WhenArgument(e.VehcicleModelId, "VehicleModelId is not positive!!!").IsLessThan(1).Throw();
            Guard.WhenArgument(e.CityId, "City Id is not positive!!!").IsLessThan(1).Throw();
            Guard.WhenArgument(e.MinPrice, "Min price is negative!!!").IsLessThan(0).Throw();
            Guard.WhenArgument(e.MaxPrice, "Max price is negative!!!").IsLessThan(0).Throw();
            Guard.WhenArgument(e.YearFrom, "Year from is negative!!!").IsLessThan(0).Throw();
            Guard.WhenArgument(e.YearTo, "Year to is negative!!!").IsLessThan(0).Throw();


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
