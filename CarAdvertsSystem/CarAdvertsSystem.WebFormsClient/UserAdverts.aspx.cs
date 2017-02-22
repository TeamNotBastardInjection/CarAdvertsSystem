using System;
using System.Linq;
using CarAdvertsSystem.Data.Services.Contracts;
using Microsoft.AspNet.Identity;
using Ninject;

namespace CarAdvertsSystem.WebFormsClient
{
    public partial class UserAdverts : System.Web.UI.Page
    {
        [Inject]
        public IAdvertServices AdvertService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = User.Identity.GetUserId();

            var adverts = this.AdvertService.GetAllAdvertsByUserId(userId);

            this.UserAdvertsList.DataSource = adverts.ToList();
            this.UserAdvertsList.DataBind();
        }
    }
}