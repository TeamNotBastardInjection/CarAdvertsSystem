using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.WebFormsClient.App_Start;
using Ninject;

namespace CarAdvertsSystem.WebFormsClient
{
    public partial class AdvertDetailView : System.Web.UI.Page
    {
        private readonly IAdvertServices advertService;

        public AdvertDetailView()
        {
            this.advertService = NinjectWebCommon.Kernel.Get<IAdvertServices>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(this.Request.QueryString["id"]);

            var adverts = this.advertService.GetAllAdverts().Where(a => a.Id == id).ToList();

            this.AdvertDetailsView.DataSource = adverts;
            this.AdvertDetailsView.DataBind();
        }
    }
}