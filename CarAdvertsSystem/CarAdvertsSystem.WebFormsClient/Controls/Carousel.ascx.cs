using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarAdvertsSystem.WebFormsClient.Controls
{
    [ParseChildren(true)]
    public partial class Carousel : System.Web.UI.UserControl
    {
        private List<Image> images = new List<Image>();

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<Image> Images
        {
            get { return images; }
        }
    }


    [ParseChildren(false), PersistChildren(true)]
    public class Image : Control
    {
        public string Src { get; set; }
    }
}