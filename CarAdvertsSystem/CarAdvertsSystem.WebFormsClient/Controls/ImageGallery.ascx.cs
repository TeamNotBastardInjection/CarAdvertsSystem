using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace CarAdvertsSystem.WebFormsClient.Controls
{
    public class MyImageInfo
    {
        public int width;
        public int height;
        public int size;
        public string lastModified;
    }

    public partial class ImageGallery : System.Web.UI.UserControl
    {
        private string pathVariable;
        private int maxImageHeight;
        private int maxImageWidth;
        private string breadCrumbClass;


        public string BaseImagePath
        {
            get { return this.pathVariable; }
            set
            {
                if (value.StartsWith("~"))
                {
                    this.pathVariable = (HttpContext.Current.Request.ApplicationPath + value.Substring(1)).Replace("//", "/");

                }
                else
                {
                    this.pathVariable = value;

                }

                this.pathVariable = pathVariable.TrimEnd('/');
            }
        }

        public int MaxImageWidth
        {
            get { return this.maxImageWidth; }
            set { this.maxImageWidth = value; }
        }

        public int MaxImageHeight
        {
            get { return this.maxImageHeight; }
            set { this.maxImageHeight = value; }
        }

        public string BreadcrumbClass
        {
            get { return this.breadCrumbClass; }
            set { this.breadCrumbClass = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.Load += new System.EventHandler(this.Page_Load);
        }

        public void Page_Load(Object sender, EventArgs e)
        {
            string[] images; //Stores JPEG and dir from current directory

            ArrayList pics = new ArrayList(); //Datasource for the Image Gallery (each element is a set of html code [a String] )

            //Two Variables that store the value of the directories the user clicks into
            string inSubpage = Request.QueryString["subpage"];

            if (inSubpage != null)
            {
                inSubpage = inSubpage.Trim('/');
            }
            else
            {
                inSubpage = "";
            }

            //Process the inSubpage and generate the links for the "top" ASP.NET label
            HandleDirectoryInput(inSubpage);

            //Generate the array of the files in the current directory
            images = BuildImagesArray(inSubpage);

            //Generate the code for each of the elements that will display
            foreach (string s in images)
            {
                //The elements that will be added is a JPEG
                string ext = Path.GetExtension(s).ToLower();

                if (ext == ".jpg" || ext == ".png" || ext == ".jpg")
                {
                    pics.Add(AddImage(s, inSubpage));
                }
                else
                {
                    pics.Add(AddDirectoryLink(s, inSubpage));
                }
            }

            dlPictures.DataSource = pics;
            dlPictures.DataBind();
        }

        private void HandleDirectoryInput(string inSubpage)
        {
            if (breadCrumbClass != null)
            {
                top.Text = "<div class=\"" + breadCrumbClass + "\">";
            }
            else
            {
                top.Text = "<div>";
            }

            if (inSubpage != null && inSubpage != "")
            {
                top.Text += "<a href=\"?subpage=\">home</a>";

                string[] pathparts = inSubpage.Split('/');
                StringBuilder path = new StringBuilder();

                foreach (string s in pathparts)
                {
                    path.Append(s);
                    top.Text += " / <a href=\"?subpage=" + Server.UrlEncode(path.ToString()) + "\">" + s + "</a>";
                    path.Append("/");
                }
            }
            else
            {
                top.Text += "";

            }

            top.Text += "</div>";
        }

        private string[] BuildImagesArray(string inSubpage)
        {
            string[] images;
            string s, html;

            string dirPath = Server.MapPath(Path.Combine(BaseImagePath, inSubpage));
            string[] dirs = Directory.GetDirectories(dirPath, "*");
            string[] jpgfiles = Directory.GetFiles(dirPath, "*.jpg");
            string[] pngfiles = Directory.GetFiles(dirPath, "*.png");
            string[] giffiles = Directory.GetFiles(dirPath, "*.gif");

            images = new string[jpgfiles.Length + pngfiles.Length + giffiles.Length + dirs.Length];
            int arrayPos = 0;

            if (dirs.Length != 0)
            {
                dirs.CopyTo(images, arrayPos);
                arrayPos += dirs.Length;
            }
            if (jpgfiles.Length != 0)
            {
                jpgfiles.CopyTo(images, arrayPos);
                arrayPos += jpgfiles.Length;
            }
            if (pngfiles.Length != 0)
            {
                pngfiles.CopyTo(images, arrayPos);
                arrayPos += pngfiles.Length;
            }
            if (giffiles.Length != 0)
            {
                giffiles.CopyTo(images, arrayPos);
                arrayPos += giffiles.Length;
            }

            //Sort the images together after the dirs
            Array.Sort(images, null, dirs.Length, images.Length - dirs.Length, null);

            return images;
        }

        private string AddImage(string s, string inSubpage)
        {
            Image currentImage;
            int imgHeight, imgWidth;
            MyImageInfo iInfo = new MyImageInfo();

            Cache.Remove(s);

            if (Cache[s] == null)
            {

                FileStream fs = new FileStream(s, FileMode.Open, FileAccess.Read, FileShare.Read);

                iInfo.size = (int)fs.Length / 1024;

                try
                {
                    currentImage = System.Drawing.Image.FromStream(fs);
                }
                catch (OutOfMemoryException e)
                {
                    return "There was an error loading file information for " + Path.GetFileName(s);
                }

                iInfo.height = currentImage.Height;
                iInfo.width = currentImage.Width;
                currentImage.Dispose();
                fs.Close();

                iInfo.lastModified = File.GetCreationTime(s).ToString("d", null);

                Trace.Write("Cache insert", s);
                Cache.Insert(s, iInfo, new CacheDependency(s));
            }
            else
            {
                Trace.Write("Cache hit", s);
                Trace.Write(Cache[s].ToString());
                iInfo = (MyImageInfo)Cache[s];
            }

            ScaleFactorCalculations(out imgHeight, out imgWidth, iInfo.height, iInfo.width);

            string filename = Path.GetFileName(s);


            string PathVar = Path.Combine(BaseImagePath, Path.Combine(inSubpage, filename));
            PathVar = PathVar.Replace("\\", "/");

            if (filename.Length > 20)
                filename = filename.Substring(0, 17) + "...";

            StringBuilder htmlout = new StringBuilder();

            htmlout.Append("<a href=\"");
            htmlout.Append(PathVar);
            htmlout.Append("\">");
            htmlout.Append("<img src=\""); 
            htmlout.Append(PathVar);
            htmlout.Append("\" width=\"");
            htmlout.Append(imgWidth);
            htmlout.Append("\" height=\"");
            htmlout.Append(imgHeight);
            htmlout.Append("\" alt=\"");
            htmlout.Append(filename);
            htmlout.Append("\" /></a>");
            htmlout.Append("<p class=\"galleryimageinfo\">");
            htmlout.Append("<a href=\"");
            htmlout.Append(PathVar);
            htmlout.Append("\">");
            htmlout.Append("</a></p>");

            return htmlout.ToString();
        }

        private string AddDirectoryLink(string s, string inSubpage)
        {
            try
            {
                string[] jpgfiles = Directory.GetFiles(s, "*.jpg");
                string[] pngfiles = Directory.GetFiles(s, "*.png");
                string[] giffiles = Directory.GetFiles(s, "*.gif");
                string[] dirsIn = Directory.GetDirectories(s);

                StringBuilder htmlout = new StringBuilder();

                htmlout.Append("<a href=\"?subpage=");
                htmlout.Append(Server.UrlEncode(inSubpage));
                htmlout.Append("/");
                htmlout.Append(Path.GetFileName(s));
                htmlout.Append("\"><img width=\"95\" height=\"75\" src=\"images/folder.gif\" /></a><br /><p class=\"galleryimageinfo\">");
                htmlout.Append(Path.GetFileName(s));
                htmlout.Append("<br />");
                htmlout.Append(dirsIn.Length);
                htmlout.Append(" directories<br />");
                htmlout.Append((jpgfiles.Length + pngfiles.Length + giffiles.Length));
                htmlout.Append(" images</p>");

                return htmlout.ToString();
            }
            catch
            {
                return s;
            }
        }

        private void ScaleFactorCalculations(out int imgHeight, out int imgWidth, int currHeight, int currWidth)
        {
            imgHeight = currHeight;
            imgWidth = currWidth;

            double widthFactor = (double)MaxImageHeight / (double)imgHeight;
            double heightFactor = (double)MaxImageWidth / (double)imgWidth;

            if (widthFactor < 1.0 || heightFactor < 1.0)
            {
                double scaleFactor = Math.Min(widthFactor, heightFactor);
                imgWidth = (int)(imgWidth * scaleFactor);
                imgHeight = (int)(imgHeight * scaleFactor);
            }
            else
            {
                double scaleFactor = Math.Max(widthFactor, heightFactor);
                imgWidth = (int)(imgWidth * scaleFactor);
                imgHeight = (int)(imgHeight * scaleFactor);
            }
        }
    }
}