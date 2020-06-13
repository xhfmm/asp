using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson4
{
    public partial class ApplicationCount3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(Application["Count3"]);
            LabCount.Text = count.ToString();
       
        }
    }
}