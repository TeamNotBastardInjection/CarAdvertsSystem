using System;

using CarAdvertsSystem.Data.Services.Contracts;

using WebFormsMvp;
using Bytes2you.Validation;

namespace CarAdvertsSystem.MVP.AdvertCreator
{
    public class AdvertCreatorPresenter : Presenter<IAdvertCreatorView>
    {
        private readonly ICityServices cityService;
        private readonly IManufacturerServices manufacturerService;
        private readonly IVehicleModelServices vehicleModelService;
        private readonly ICategoryServices categoryService;

        public AdvertCreatorPresenter(
            IAdvertCreatorView view,
            ICityServices cityService,
            IManufacturerServices manufacturerService,
            IVehicleModelServices vehicleModelService, 
            ICategoryServices categoryService) 
            : base(view)
        {
            Guard.WhenArgument(cityService, "City Service is null!!!").IsNull().Throw();
            Guard.WhenArgument(manufacturerService, "Manufacturer Service is null!!!").IsNull().Throw();
            Guard.WhenArgument(vehicleModelService, "Vehicle Model Service is null!!!").IsNull().Throw();
            Guard.WhenArgument(categoryService, "Category Service is null!!!").IsNull().Throw();
            Guard.WhenArgument(view, "View is Null!!!").IsNull().Throw();

            this.cityService = cityService;
            this.manufacturerService = manufacturerService;
            this.categoryService = categoryService;
            this.vehicleModelService = vehicleModelService;

            this.View.OnCitiesGetData += View_OnCitiesGetData;
            this.View.OnCategoriesGetData += View_OnCategoriesGetData;
            this.View.OnManufacturersGetData += View_OnManufacturersGetData;
            this.View.OnVehicleModelsGetData += View_OnVehicleModelsGetData;
        }

        private void View_OnVehicleModelsGetData(object sender, EventArgs e)
        {
            this.View.Model.VehicleModels = this.vehicleModelService.GetAllVehicleModels();
        }

        private void View_OnManufacturersGetData(object sender, EventArgs e)
        {
            this.View.Model.Manufacturers = this.manufacturerService.GetAllManufacturers();
        }

        private void View_OnCategoriesGetData(object sender, EventArgs e)
        {
            this.View.Model.Categories = this.categoryService.GetAllCategories();
        }

        private void View_OnCitiesGetData(object sender, EventArgs e)
        {
            this.View.Model.Cities = this.cityService.GetAllCities();
        }
    }
}
