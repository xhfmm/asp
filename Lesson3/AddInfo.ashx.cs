using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lesson3
{
    /// <summary>
    /// AddInfo 的摘要说明
    /// </summary>
    public class AddInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/htm!";
            //拿出所有的数据
            string name = context.Request.Form["name"];
            //int age;
            //int.TryParselcontext.Request.Form["age"], out age);
            int age = Convert.ToInt32(context.Request.Form["age"]);
            string number = context.Request.Form["number"];
            string company = context.Request.Form["company"];
            string address = context.Request.Form["address"];
            //插入到数据
            string sql="insert into User_info(Name, Age, Number, Company, Adress)values(@name, @age, @number, @company, @address); ";
            SqlParameter[] ps = {
                                    new SqlParameter("@name",name),
                                    new SqlParameter("@age",age),
                                    new SqlParameter("@number",number),
                                    new SqlParameter("@company",company),
                                    new SqlParameter("@address",address)
                                };
            int result = SQLHelper.ExecuteNonQuery(sql, ps);
            if (result > 0)
            {
                context.Response.Redirect("ListHandler.ashx");
            }
            context.Response.Write("<script>alert('添加失败！！！');</script>");
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