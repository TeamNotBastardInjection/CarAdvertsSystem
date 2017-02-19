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
            this.UploadFiles();

            var title = this.AdvertTitle.Text;
            var cityId = int.Parse(this.City.SelectedItem.Value);
            var vechisleId = int.Parse(this.VechisleModel.SelectedItem.Value);
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
                vechisleId, 
                price, 
                power, 
                distanceCovarage, 
                description, 
                year,
                this.PictureFilePaths));

            ErrorSuccessNotifier.AddSuccessMessage("Advert Added Yolo!!!");
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

        //protected void UploadButton_Click(object sender, EventArgs e)
        //{
        //    if (FileUploadControl.HasFile)
        //    {
        //        string filename = Path.GetFileName(FileUploadControl.FileName);
        //        FileUploadControl.SaveAs(Server.MapPath("~/Uploaded_Files/") + filename);
        //        StatusLabel.Text = "Upload status: File uploaded!";
        //    }
        //}

        /// <summary>
        /// Upload and save multiple files;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UploadFiles()
        {
            var filePaths = new List<string>();
            if (UploadImages.HasFiles)
            {
                // Rename files to be with unique names and save them
                foreach (HttpPostedFile uploadedFile in UploadImages.PostedFiles)
                {
                    // Get file extension and create new file name
                    FileInfo fi = new FileInfo(uploadedFile.FileName);
                    string ext = fi.Extension;
                    var newFileName = $"{counter}{ext}";

                    // Save file to a server side
                    uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Uploaded_Files/"), newFileName));

                    // Save file path to a Sql database
                    filePaths.Add(newFileName);

                    // Add file name to the control
                    listofuploadedfiles.Text += String.Format("{0}<br />", uploadedFile.FileName);

                    counter++;
                }
            }

            this.PictureFilePaths = filePaths;
        }
    }
}