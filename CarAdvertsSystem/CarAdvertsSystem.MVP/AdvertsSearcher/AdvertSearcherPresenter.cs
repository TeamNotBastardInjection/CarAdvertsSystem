using System;
using System.Linq;
using Bytes2you.Validation;
using CarAdvertsSystem.Data.Services.Contracts;
using WebFormsMvp;

namespace CarAdvertsSystem.MVP.AdvertsSearcher
{
    public class AdvertSearcherPresenter : Presenter<IAdvertSearcherView>
    {
        private readonly IAdvertServices advertService;
        private readonly ICityServices cityService;
        private readonly IVehicleModelServices vehicleModelService;
        private readonly IManufacturerServices manufacturerService;
        private readonly ICategoryServices categoryService;

        public AdvertSearcherPresenter(
            IAdvertSearcherView view, 
            IAdvertServices advertService,
            ICityServices cityService,
            IVehicleModelServices vehicleModelService,
            IManufacturerServices manufacturerService,
            ICategoryServices categoryService) 
            : base(view)
        {
            Guard.WhenArgument(view, "View is null.").IsNull().Throw();
            Guard.WhenArgument(advertService, "Advert Service is null.").IsNull().Throw();
            Guard.WhenArgument(cityService, "City Service is null.").IsNull().Throw();
            Guard.WhenArgument(vehicleModelService, "Vehicle Mode lService is null.").IsNull().Throw();
            Guard.WhenArgument(categoryService, "Category Service is null.").IsNull().Throw();

            this.advertService = advertService;
            this.cityService = cityService;
            this.vehicleModelService = vehicleModelService;
            this.manufacturerService = manufacturerService;
            this.categoryService = categoryService;

            this.View.OnCitiesGetData += View_OnCitiesGetData;
            this.View.OnCategoriesGetData += View_OnCategoriesGetData;
            this.View.OnManufacturersGetData += View_OnManufacturersGetData;
            this.View.OnVehicleModelsGetData += View_OnVehicleModelsGetData;
            this.View.OnSearchAdverts += View_OnSearchAdverts;
        }

        private void View_OnSearchAdverts(object sender, SearchAdvertsEventArgs e)
        {
            var adverts = this.advertService.GetAllAdverts()
                                .Where(a => a.VehicleModelId == e.VehcicleModelId)
                                //.Where(a => a.Price >= minPrice)
                                //.Where(a => a.Price <= maxPrice)
                                //.Where(a => a.Year >= yearFrom)
                                //.Where(a => a.Year <= yearTo)
                                .ToList()
                                .AsQueryable();

            this.View.Model.Adverts = adverts;
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
