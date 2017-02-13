using CarAdvertsSystem.Data;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Repositories;
using CarAdvertsSystem.Data.Services;
using CarAdvertsSystem.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var context = new CarAdvertsSystemDbContext();
            IRepository<Advert> advertRepository = new GenericRepository<Advert>(context);
            var unitOfWork = new UnitOfWork(context);

            AdvertServices advService = new AdvertServices(advertRepository, unitOfWork);
            var advert = new Advert() { Title = "My First Advert Creation." };

            advService.AddAdvert(advert);
        }
    }
}