using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using WebFormsMvp;

namespace CarAdvertsSystem.MVP.AdvertDetail
{
    public class AdvertDetailPresenter : Presenter<IAdvertDetailView>
    {
        private readonly IPictureServices pictureService;
        private readonly IAdvertServices advertService;

        public AdvertDetailPresenter(IAdvertDetailView view, IPictureServices pictureService, IAdvertServices advertService) 
            : base(view)
        {
            Guard.WhenArgument(view, "View Instance is Null").IsNull().Throw();
            Guard.WhenArgument(pictureService, "Picture Service is Null").IsNull().Throw();
            Guard.WhenArgument(advertService, "Advert Service is Null").IsNull().Throw();

            this.pictureService = pictureService;
            this.advertService = advertService;

            this.View.OnGetPicturesByAdvertId += View_OnGetPicturesByAdvertId;
            this.View.OnGetAdvertsById += View_OnGetAdvertsById;
        }

        private void View_OnGetAdvertsById(object sender, GetAdvertsByIdEventArgs e)
        {
            var adverts = this.advertService.GetById(e.AdvertId);
            var advertCollection = new List<Advert>();

            advertCollection.Add(adverts);

            this.View.Model.Adverts = advertCollection.AsQueryable();
        }

        private void View_OnGetPicturesByAdvertId(object sender, GetPicturesEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
