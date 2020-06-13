using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lesson4
{
    public partial class CookieLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String loginName = getName();
            if (Request.Cookies[loginName] == null)
            {
                HttpCookie hcookie = new HttpCookie(loginName);
                hcookie.Values["username"] = this.txtName.Text;//登录用户名
                hcookie.Values["lastVist"] = DateTime.Now.ToString();//上次访问时间
                hcookie.Values["nowVist"] = DateTime.Now.ToString();//本次访问时间
                hcookie.Values["count"] = "1";//该客户端用户访问次数
                hcookie.Expires = DateTime.Now.AddDays(30);//设置保存时间是30天
                Response.Cookies.Add(hcookie);
            }
            else
            {
                HttpCookie hcookie = new HttpCookie(loginName);
                hcookie.Values["username"] = this.txtName.Text;
                String lastVist = Request.Cookies[loginName]["nowVist"];
                hcookie.Values["lastVist"] = lastVist;
                hcookie.Values["nowVist"] = DateTime.Now.ToString();
                hcookie.Values["count"] = (Convert.ToInt32(Request.Cookies[loginName]["count"].ToString())+1).ToString();
                hcookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(hcookie);
            }
            Response.Redirect("CookieWelcome.aspx");
        }
        private String getName()
        {
            String uname = this.txtName.Text;
            Session["uname"] = uname;
            return uname;
        }
        
    }
}