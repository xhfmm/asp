using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lesson3
{
    /// <summary>
    /// Delete 的摘要说明
    /// </summary>
    public class Delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //获取通过get方式传递过来的id值
            //int id = int.Parse(context.Request.Querystring["id"]);
            string id = context.Request["id"];
            int showld = int.Parse(id);
            //通过id删除数据库相应数据
            string sql = "delete from User_Info where id=@id";
            //SglParameter pr=new SglParameter('@id",id);
            SqlParameter pr = new SqlParameter("@id", showld);
            int result = SQLHelper.ExecuteNonQuery(sql, pr);
            if (result > 0)
            {
                context.Response.Redirect("ListHandler.ashx");
                //context.Response.Write("<script>alert('删除成功');location='ListHandler.ashx';</script>");
            }
            else
            {
                context.Response.Write("删除失败!!!");
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