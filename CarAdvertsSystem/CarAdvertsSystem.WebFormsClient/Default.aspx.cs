using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.WebFormsClient.App_Start;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace CarAdvertsSystem.WebFormsClient
{
    public partial class Default : Page
    {
        private ICategoryServices categoriesService;
        private IManufacturerServices manufacturerService;
        private IVehicleModelServices vehicleModelServices;
        private IAdvertServices advertService;

        public Default()
        {
            this.categoriesService = NinjectWebCommon.Kernel.Get<ICategoryServices>();
            this.manufacturerService = NinjectWebCommon.Kernel.Get<IManufacturerServices>();
            this.vehicleModelServices = NinjectWebCommon.Kernel.Get<IVehicleModelServices>();
            this.advertService = NinjectWebCommon.Kernel.Get<IAdvertServices>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var categories = categoriesService.GetAllCategories().ToList().AsQueryable();
                this.CategoriesList.DataSource = categories;

                this.YearFrom.DataSource = GetYears();
                this.YearTo.DataSource = GetYears();

                this.DataBind();
            }
        }

        protected void CategoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var manufacturers = this.manufacturerService.GetAllManufacturers().ToList().AsQueryable();

            this.ManufacturersList.DataSource = manufacturers;
            this.DataBind();
        }

        protected void ManufacturersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var models = this.vehicleModelServices.GetAllVehicleModels().ToList().AsQueryable();

            this.ModelsList.DataSource = models;
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

        protected void YearFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var minYear = int.Parse(this.YearFrom.SelectedItem.Value);
            this.YearTo.DataSource = GetYears(minYear);
            this.DataBind();
        }

        // this logic must be in MVP
        protected void Search_Click(object sender, EventArgs e)
        {
            var category = int.Parse(this.CategoriesList.SelectedItem.Value);
            var manufacturer = int.Parse(this.ManufacturersList.SelectedItem.Value);
            var model = int.Parse(this.ManufacturersList.SelectedItem.Value);
            var minPrice = int.Parse(this.MinPrice.Text);
            var maxPrice = int.Parse(this.MaxPrice.Text);
            var yearFrom = int.Parse(this.YearFrom.SelectedItem.Text);
            var yearTo = int.Parse(this.YearTo.SelectedItem.Text);

            // Triabva da se naprvi da raboti pravilno zaiavkata
            var adverts = this.advertService.GetAllAdverts()
                                .Where(a => a.VehicleModelId == model)
                                .Where(a => a.Price >= minPrice)
                                .Where(a => a.Price <= maxPrice)
                                .Where(a => a.Year >= yearFrom)
                                .Where(a => a.Year <= yearTo)
                                .ToList()
                                .AsQueryable();

            this.ResultAdverts.DataSource = adverts;
            this.DataBind();
            this.ResultAdverts.Visible = true;
        }
    }
}