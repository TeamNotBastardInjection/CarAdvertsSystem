﻿using System;
using System.Collections.Generic;
using System.Linq;

using CarAdvertsSystem.MVP.AdvertsSearcher;
using CarAdvertsSystem.WebFormsClient.Controls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CarAdvertsSystem.WebFormsClient
{
    [PresenterBinding(typeof(AdvertSearcherPresenter))]
    public partial class Default : MvpPage<AdvertSearcherViewModel>, IAdvertSearcherView
    {
        public event EventHandler OnCitiesGetData;
        public event EventHandler OnCategoriesGetData;
        public event EventHandler OnManufacturersGetData;
        public event EventHandler OnVehicleModelsGetData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.OnCategoriesGetData?.Invoke(this, null);
                this.CategoriesList.DataSource = this.Model.Categories.ToList();

                this.OnCitiesGetData?.Invoke(this, null);
                this.CitiesList.DataSource = this.Model.Cities.ToList();

                this.YearFrom.DataSource = GetYears();
                this.YearTo.DataSource = GetYears();

                this.DataBind();
            }
        }

        protected void CategoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OnManufacturersGetData?.Invoke(this, null);
            this.ManufacturersList.DataSource = this.Model.Manufacturers.ToList();
            this.DataBind();
        }

        protected void ManufacturersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OnVehicleModelsGetData?.Invoke(this, null);
            this.ModelsList.DataSource = this.Model.VehicleModels.ToList();
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

        protected void Search_Click(object sender, EventArgs e)
        {

            if (this.ModelsList.SelectedItem == null)
            {
                this.ModelListValidator.Text = Server.HtmlEncode("You have to select a Model!");
                this.ModelListValidator.Visible = true;
                return;
            }

            int inputMinPrice;
            bool minPriceVal = int.TryParse(this.MinPrice.Text, out inputMinPrice);

            int inputMaxPrice;
            bool maxPriceVal = int.TryParse(this.MaxPrice.Text, out inputMaxPrice);

            if (minPriceVal == false || maxPriceVal == false)
            {
                this.MinPrice.Text = "";
                this.MaxPrice.Text = "";
                this.PriceValidator.Text = Server.HtmlEncode("You have to enter a number!");
                this.PriceValidator.Visible = true;
                
                return;
            }

            if (inputMinPrice <= 0 || inputMaxPrice <= 0)
            {
                this.MinPrice.Text = "";
                this.MaxPrice.Text = "";
                this.PriceValidator.Text = "You have to enter a positive number!";
                this.PriceValidator.Visible = true;
                return;
                
            }

            var vechicleModelId = int.Parse(this.ModelsList.SelectedItem.Value);
            var cityId = int.Parse(this.CitiesList.SelectedItem.Value);
            var minPrice = int.Parse(this.MinPrice.Text);
            var maxPrice = int.Parse(this.MaxPrice.Text);
            var yearFrom = int.Parse(this.YearFrom.SelectedItem.Text);
            var yearTo = int.Parse(this.YearTo.SelectedItem.Text);
                  
            var queryParam = $"?v={vechicleModelId}&c={cityId}&mip={minPrice}&map={maxPrice}&yf={yearFrom}&yt={yearTo}";

            Response.Redirect("~/adverts" + queryParam);
        }     
    }
}