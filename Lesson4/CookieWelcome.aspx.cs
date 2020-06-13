using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson4
{
    public partial class CookieWelcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] == null)
            {
                Response.Redirect("CookieLogin.aspx");
            }
            else {
                String loginName = Session["uname"] as String;
                Response.Write("登录用户是: " + Request.Cookies[loginName]["username"].ToString()+ "<br/>");
                Response.Write("本次登录时间是: "+Request.Cookies[loginName]["nowVist"].ToString() + "<br/>");
                Response.Write("上次登录时间是: "+Request.Cookies[loginName]["lastVist"].ToString() + "<br/>");
                Response.Write("当前用户登录次数是:"+Request.Cookies[loginName]["count"].ToString() + "<br/>");
            }
        }
    }
}