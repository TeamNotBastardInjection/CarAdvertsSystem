using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.AdvertDetail;
using CarAdvertsSystem.WebFormsClient.App_Start;
using Ninject;
using Ninject.Infrastructure.Language;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CarAdvertsSystem.WebFormsClient
{
    [PresenterBinding(typeof(AdvertDetailPresenter))]
    public partial class AdvertDetailView : MvpPage<AdvertDetailViewModel>, IAdvertDetailView
    {
        public event EventHandler<GetPicturesEventArgs> OnGetPicturesByAdvertId;
        public event EventHandler<GetAdvertsByIdEventArgs> OnGetAdvertsById;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(this.Request.QueryString["id"]);

            this.OnGetAdvertsById?.Invoke(this, new GetAdvertsByIdEventArgs(id));
            var adverts = this.Model.Adverts;
            this.AdvertDetailsView.DataSource = adverts.ToList();

            this.OnGetPicturesByAdvertId?.Invoke(this, new GetPicturesEventArgs(id));
            var pictures = this.Model.Pictures.ToList().AsQueryable();
            this.RepeaterImages.DataSource = pictures;

            this.DataBind();
        }

        //public IQueryable<Picture> GetPictures()
        //{
        //    var id = int.Parse(Request.QueryString["Id"]);
        //    this.OnGetPicturesByAdvertId?.Invoke(this, new GetPicturesEventArgs(id));

        //    var pictures = this.Model.Pictures.ToList().AsQueryable();
        //    return pictures;
        //}
    }
}