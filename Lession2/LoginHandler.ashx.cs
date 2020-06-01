using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lession2
{
    /// <summary>
    /// LoginHeadler 的摘要说明
    /// </summary>
    public class LoginHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {            
            //context.Response.ContentType = "text/plain";
            string path = context.Request.MapPath("Login.html");
            string html = System.IO.File.ReadAllText(path);
            string _vs = context.Request.Form["_viewstate"];
            bool ispostback = !string.IsNullOrEmpty(_vs);
            if (ispostback)
            {
                string name = context.Request.Form["name"];
                string pwd = context.Request.Form["pwd"];
                if (LoginSQL.Login(name,pwd))
                {
                    HttpCookie cookie = new HttpCookie("Login");
                    cookie.Values.Add("name", name);
                    cookie.Values["pwd"] = pwd;
                    cookie.Expires = System.DateTime.Now.AddDays(3);
                    context.Response.Cookies.Add(cookie);
                    context.Response.Write("登录成功");

                }
                else
                {
                    html = html.Replace("@name", name).Replace("@pwd","").Replace("@msg", "登录失败");
                    context.Response.Write(html);
                }
            }
            else
            {
                HttpCookie getcookie = context.Request.Cookies["Login"];
                if(getcookie != null&& getcookie.HasKeys)
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

            //context.Response.Write("Hello World");
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