using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson4
{
    public partial class ApplicationCount2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Application.Lock();
            Application["Count2"] = Convert.ToInt32(Application["Count2"]) + 1;
            Application.UnLock();
            string str = "您是第" + Application["Count2"] + "位访问者";
            lbltxt.Text = str;
        }

    }
}