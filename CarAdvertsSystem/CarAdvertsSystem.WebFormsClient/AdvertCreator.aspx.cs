using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using CarAdvertsSystem.MVP.AdvertCreator;

using Microsoft.AspNet.Identity;

using WebFormsMvp;
using WebFormsMvp.Web;
using System.Web;
using CarAdvertsSystem.WebFormsClient.Controls;

namespace CarAdvertsSystem.WebFormsClient
{
    [PresenterBinding(typeof(AdvertCreatorPresenter))]
    public partial class AdvertCreator : MvpPage<AdvertCreatorViewModel>, IAdvertCreatorView
    {
        private static int counter = 1;
        
        public event EventHandler OnCitiesGetData;
        public event EventHandler OnCategoriesGetData;
        public event EventHandler OnManufacturersGetData;
        public event EventHandler OnVehicleModelsGetData;
        public event EventHandler<CreateAdvertEventArgs> OnCreateAdvert;

        public ICollection<string> PictureFilePaths { get; private set; }

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
            if (this.VehicleModel.SelectedItem == null)
            {
                this.VehicleModelValidator.Text = Server.HtmlEncode("You have to select a Model!");
                this.VehicleModelValidator.Visible = true;
                return;
            }

            var isUploaded = this.UploadFiles();
            if (isUploaded == false)
            {
                return;
            }

            var title = this.AdvertTitle.Text;
            var cityId = int.Parse(this.City.SelectedItem.Value);
            var vehicleId = int.Parse(this.VehicleModel.SelectedItem.Value);
            var price = int.Parse(this.Price.Text);
            var year = int.Parse(this.Year.SelectedItem.Value);
            var power = int.Parse(this.Power.Text);
            var distanceCovarage = int.Parse(this.DistanceCovarage.Text);
            var description = this.Description.Text;
            var userId = User.Identity.GetUserId();

            this.OnCreateAdvert?.Invoke(this, new CreateAdvertEventArgs(
                title, 
                userId, 
                cityId, 
                vehicleId, 
                price, 
                power, 
                distanceCovarage, 
                description, 
                year,
                this.PictureFilePaths));

            ErrorSuccessNotifier.AddSuccessMessage("Advert Added!!");

            Response.Redirect("~/UserAdverts.aspx");
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

            this.VehicleModel.DataSource = this.Model.VehicleModels.ToList();
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

        /// <summary>
        /// Upload and save multiple files;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected bool UploadFiles()
        {           
            var isUploaded = false;
            var filePaths = new List<string>();
            if (UploadImages.HasFiles)
            {
                try
                {
                    if (UploadImages.PostedFile.ContentType == "image/jpeg" || UploadImages.PostedFile.ContentType == "image/png")
                    {
                        var largestAllowedPictureSize = 5 * 1048576;

                        if (UploadImages.PostedFile.ContentLength < largestAllowedPictureSize)
                        {
                            foreach (HttpPostedFile uploadedFile in UploadImages.PostedFiles)
                            {
                                // Get file extension and create new file name
                                FileInfo fi = new FileInfo(uploadedFile.FileName);
                                string ext = fi.Extension;
                                var newFileName = $"{counter}{ext}";

                                // Save file to a server side
                                uploadedFile.SaveAs(Path.Combine(Server.MapPath("~/Uploaded_Files/"), newFileName));

                                // Save file path to a Sql database
                                filePaths.Add(newFileName);

                                // Add file name to the control
                                ListOfPictures.Text += $"{uploadedFile.FileName}<br />";

                                counter++;
                            }

                            isUploaded = true;
                        }
                        else
                        {
                            ListOfPictures.Text = "The File has to be less up to 5MB!";
                            ListOfPictures.Visible = true;
                        }
                    }
                    else
                    {
                        ListOfPictures.Text = "Only .jpeg files allowed!";
                        ListOfPictures.Visible = true;
                    }
                }
                catch (Exception e)
                {
                    ListOfPictures.Text =
                        "The file could not be uploaded it has to be up to 5MB and only .jpeg allowed!: " + e.Message;
                    ListOfPictures.Visible = true;
                }
            }

            this.PictureFilePaths = filePaths;
            return isUploaded;
        }
    }
}