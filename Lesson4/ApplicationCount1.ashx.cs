using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson4
{
    /// <summary>
    /// ApplicationCount1 的摘要说明
    /// </summary>
    public class ApplicationCount1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string path = context.Request.MapPath("ApplicationCount1.html");
            string html = System.IO.File.ReadAllText(path);
            string _vs = context.Request.Form["_viewstate"];
            bool ispostback = !string.IsNullOrEmpty(_vs);
            if (ispostback)
            {
                string name = context.Request.Form["username"];
                string pwd = context.Request.Form["pwd"];
                if (name=="xhf" && pwd=="123456")
                {
                    HttpCookie cookie = new HttpCookie("Login");
                    cookie.Values.Add("name", name);
                    cookie.Values["pwd"] = pwd;
                    cookie.Expires = System.DateTime.Now.AddDays(3);
                    context.Response.Cookies.Add(cookie);
                    context.Response.Write("<h2>一般处理程序<h2>");
                    context.Response.Write("登录成功");
                    context.Application.Lock();
                    context.Application["Count"] = Convert.ToInt32(context.Application["Count"]) + 1;
                    context.Application.UnLock();
                    context.Response.Write("<br>您是第" + context.Application["Count"].ToString() + "位访问者");
                }
                else
                {
                    html = html.Replace("@name", name).Replace("@pwd", "").Replace("@msg", "登录失败");
                    context.Response.Write(html);
                }
            }
            else
            {
                HttpCookie getcookie = context.Request.Cookies["Login"];
                if (getcookie != null && getcookie.HasKeys)
                {
                    string getname = getcookie["name"];
                    string getpwd = getcookie["pwd"];
                    html = html.Replace("@name", getname).Replace("@pwd", getpwd).Replace("@msg", "");
                    context.Response.Write(html);
                }
                else
                {
                    html = html.Replace("@name", "").Replace("@pwd", "").Replace("@msg", "");
                    context.Response.Write(html);
                }
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}