using System;
using System.Linq;
using Bytes2you.Validation;
using CarAdvertsSystem.Data.Services.Contracts;
using WebFormsMvp;

namespace CarAdvertsSystem.MVP.AdvertsSearcher
{
    public class AdvertSearcherPresenter : Presenter<IAdvertSearcherView>
    {
        private readonly ICityServices cityService;
        private readonly IVehicleModelServices vehicleModelService;
        private readonly IManufacturerServices manufacturerService;
        private readonly ICategoryServices categoryService;

        public AdvertSearcherPresenter(
            IAdvertSearcherView view, 
            ICityServices cityService,
            IVehicleModelServices vehicleModelService,
            IManufacturerServices manufacturerService,
            ICategoryServices categoryService) 
            : base(view)
        {
            Guard.WhenArgument(view, "View is null.").IsNull().Throw();
            Guard.WhenArgument(cityService, "City Service is null.").IsNull().Throw();
            Guard.WhenArgument(vehicleModelService, "Vehicle Model Service is null.").IsNull().Throw();
            Guard.WhenArgument(manufacturerService, "Manufacturer Service is null.").IsNull().Throw();
            Guard.WhenArgument(categoryService, "Category Service is null.").IsNull().Throw();
            
            this.cityService = cityService;
            this.vehicleModelService = vehicleModelService;
            this.manufacturerService = manufacturerService;
            this.categoryService = categoryService;

            this.View.OnCitiesGetData += View_OnCitiesGetData;
            this.View.OnCategoriesGetData += View_OnCategoriesGetData;
            this.View.OnManufacturersGetData += View_OnManufacturersGetData;
            this.View.OnVehicleModelsGetData += View_OnVehicleModelsGetData;
        }

        public void View_OnVehicleModelsGetData(object sender, EventArgs e)
        {
            var vehicleModels = this.vehicleModelService.GetAllVehicleModels();
            this.View.Model.VehicleModels = vehicleModels;
        }

        public void View_OnManufacturersGetData(object sender, EventArgs e)
        {
            var manufacturers = this.manufacturerService.GetAllManufacturers();
            this.View.Model.Manufacturers = manufacturers;
        }

        public void View_OnCategoriesGetData(object sender, EventArgs e)
        {
            var categories = this.categoryService.GetAllCategories();
            this.View.Model.Categories = categories;
        }

        public void View_OnCitiesGetData(object sender, EventArgs e)
        {
            var cities = this.cityService.GetAllCities();
            this.View.Model.Cities = cities;
        }
    }

}
