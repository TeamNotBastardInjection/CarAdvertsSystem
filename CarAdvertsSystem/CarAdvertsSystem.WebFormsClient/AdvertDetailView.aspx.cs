using System;
using System.Linq;
using System.Web.UI;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.AdvertDetail;
using CarAdvertsSystem.WebFormsClient.App_Start;
using Ninject;
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

            //var adverts = this.advertService.GetAllAdverts().Where(a => a.Id == id).ToList();
            var adverts = this.Model.Adverts;
            this.AdvertDetailsView.DataSource = adverts;
            this.AdvertDetailsView.DataBind();
        }
    }
}