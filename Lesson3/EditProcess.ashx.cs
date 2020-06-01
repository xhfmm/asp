using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lesson3
{
    /// <summary>
    /// EditProcess 的摘要说明
    /// </summary>
    public class EditProcess : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //获取用户发送过来的Id和用户数据
            int id = int.Parse(context.Request["hidId"]);//用隐藏域传递id值
            string name = context.Request["name"];
            string age = context.Request["age"]; 
            string number = context.Request["number"];
            string company = context.Request["company"];
            string address = context.Request["address"];

            string sql = "update User_info set Name=@name,Age=@age,Number=@number,Company=@company,Adress=@address where Id=@id";
            SqlParameter[] ps = {
                                    new SqlParameter("@id",id),
                                    new SqlParameter("@name",name),
                                    new SqlParameter("@age",age),
                                    new SqlParameter("@number",number),
                                    new SqlParameter("@company",company),
                                    new SqlParameter("@address",address)
                            };
            int result = SQLHelper.ExecuteNonQuery(sql, ps);
            if(result > 0)
            {
                context.Response.Redirect("ListHandler.ashx");
            }
            context.Response.Write("<script>alert('修改失败！！！');</script>");
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