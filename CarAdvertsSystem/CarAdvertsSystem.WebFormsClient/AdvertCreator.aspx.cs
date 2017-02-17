using CarAdvertsSystem.Data;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Repositories;
using CarAdvertsSystem.Data.Services;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.Data.UnitOfWork;
using CarAdvertsSystem.WebFormsClient.App_Start;
using Microsoft.AspNet.Identity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarAdvertsSystem.WebFormsClient
{
    public partial class AdvertCreator : System.Web.UI.Page
    {
        private readonly IAdvertServices advertService;
        private readonly ICategoryServices categoryService;
        private readonly IManufacturerServices manufacturerService;
        private readonly IVehicleModelServices vehicleModelServices;
        private readonly ICityServices cityService;

        public AdvertCreator()
        {
            this.advertService = NinjectWebCommon.Kernel.Get<IAdvertServices>();
            this.categoryService = NinjectWebCommon.Kernel.Get<ICategoryServices>();
            this.manufacturerService = NinjectWebCommon.Kernel.Get<IManufacturerServices>();
            this.vehicleModelServices = NinjectWebCommon.Kernel.Get<IVehicleModelServices>();
            this.cityService = NinjectWebCommon.Kernel.Get<ICityServices>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var cities = this.cityService.GetAllCities().ToList().AsQueryable();
                this.City.DataSource = cities;

                var categories = this.categoryService.GetAllCategories().ToList().AsQueryable();
                this.Category.DataSource = categories;

                this.Year.DataSource = this.GetYears();

                this.DataBind();
            }
            
        }

        protected void CreateAdvert_Click(object sender, EventArgs e)
        {
            var title = this.AdvertTitle.Text;
            var categoryId = int.Parse(this.Category.SelectedItem.Value);
            //var manufacturerId = int.Parse(this.Manufacturer.SelectedItem.Value);
            var cityId = int.Parse(this.City.SelectedItem.Value);
            var vechisleId = int.Parse(this.VechisleModel.SelectedItem.Value);
            var price = int.Parse(this.Price.Text);
            var power = int.Parse(this.Power.Text);
            var distanceCovarage = int.Parse(this.DistanceCovarage.Text);
            var description = this.Description.Text;
            var userId = User.Identity.GetUserId();

            var advert = new Advert()
            {
                Title = title,
                CityId = cityId,
                VehicleModelId = vechisleId,
                UserId = userId,
                Power = power,
                Price = price,
                DistanceCoverage = distanceCovarage,
                Description = description
            };

            this.advertService.AddAdvert(advert);
        }

        protected void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            var manufacturers = this.manufacturerService.GetAllManufacturers().ToList().AsQueryable();

            this.Manufacturer.DataSource = manufacturers;
            this.DataBind();
        }

        protected void Manufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var models = this.vehicleModelServices.GetAllVehicleModels().ToList().AsQueryable();

            this.VechisleModel.DataSource = models;
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