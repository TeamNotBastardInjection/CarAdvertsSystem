using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using CarAdvertsSystem.MVP.AdvertCreator;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CarAdvertsSystem.WebFormsClient
{
    [PresenterBinding(typeof(AdvertCreatorPresenter))]
    public partial class AdvertCreator : MvpPage<AdvertCreatorViewModel>, IAdvertCreatorView
    {
        public event EventHandler OnCitiesGetData;
        public event EventHandler OnCategoriesGetData;
        public event EventHandler OnManufacturersGetData;
        public event EventHandler OnVehicleModelsGetData;
        public event EventHandler<CreateAdvertEventArgs> OnCreateAdvert;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.OnCitiesGetData?.Invoke(this, null);
                this.City.DataSource = this.Model.Cities.ToList();

                this.OnCategoriesGetData?.Invoke(this, null);
                this.Category.DataSource = this.Model.Categories.ToList();

                this.Year.DataSource = this.GetYears();

                this.DataBind();
            }
            
        }

        protected void CreateAdvert_Click(object sender, EventArgs e)
        {
            var title = this.AdvertTitle.Text;
            var cityId = int.Parse(this.City.SelectedItem.Value);
            var vechisleId = int.Parse(this.VechisleModel.SelectedItem.Value);
            var price = int.Parse(this.Price.Text);
            var power = int.Parse(this.Power.Text);
            var distanceCovarage = int.Parse(this.DistanceCovarage.Text);
            var description = this.Description.Text;
            var userId = User.Identity.GetUserId();

            this.OnCreateAdvert?.Invoke(this, new CreateAdvertEventArgs(title, userId, cityId, vechisleId, price, power, distanceCovarage, description));
        }

        protected void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OnManufacturersGetData?.Invoke(this, null);

            this.Manufacturer.DataSource = this.Model.Manufacturers.ToList();
            this.DataBind();
        }

        protected void Manufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OnVehicleModelsGetData?.Invoke(this, null);

            this.VechisleModel.DataSource = this.Model.VehicleModels.ToList();
            this.DataBind();
        }

        private IEnumerable<int> GetYears(int? minYear = 1980)
        {
            var years = new List<int>();
            var lastYear = DateTime.Now.Year;

            while (lastYear >= minYear)
            {
                years.Add(lastYear);
                lastYear--;
            }

            return years;
        }

    }
}