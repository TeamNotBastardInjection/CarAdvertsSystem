using CarAdvertsSystem.Data;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Repositories;
using CarAdvertsSystem.Data.Services;
using CarAdvertsSystem.Data.UnitOfWork;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CarAdvertsSystem.WebFormsClient
{
    public partial class MyTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateAdvert_Click(object sender, EventArgs e)
        {
            var title = this.AdvertTitle.Text;
            var cityId = int.Parse(this.IdOfCity.Text);
            var vechisleId = int.Parse(this.IdVechisle.Text);

            //MembershipUser membershipUser = Membership.GetUser();
            //string userID = membershipUser.ProviderUserKey.ToString();

            var userId = User.Identity.GetUserId();


        var context = new CarAdvertsSystemDbContext();
            IRepository<Advert> advertRepository = new GenericRepository<Advert>(context);
            var unitOfWork = new UnitOfWork(context);

            AdvertServices advService = new AdvertServices(advertRepository, unitOfWork);
            var advert = new Advert() { Title = title, CityId = cityId, VehicleModelId = vechisleId, UserId = userId };

            advService.AddAdvert(advert);
        }
    }
}