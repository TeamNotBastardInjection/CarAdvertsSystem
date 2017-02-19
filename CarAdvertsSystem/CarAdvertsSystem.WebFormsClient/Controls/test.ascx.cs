using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarAdvertsSystem.WebFormsClient.Controls
{
    [ParseChildren(true)]
    [PersistChildren(true)]
    [ToolboxData("<{0}:CustomControlUno runat=server></{0}:CustomControlUno>")]
    public partial class test : System.Web.UI.UserControl, INamingContainer
    {
            private Control1ChildrenCollection _children;

            [PersistenceMode(PersistenceMode.InnerProperty)]
            public Control1ChildrenCollection Children
            {
                get
                {
                    if (_children == null)
                    {
                        _children = new Control1ChildrenCollection();
                    }
                    return _children;
                }
            }
        }

        public class Control1ChildrenCollection : List<Control1Child>
        {
        }

        public class Control1Child
        {
            public int IntegerProperty { get; set; }
        }
}