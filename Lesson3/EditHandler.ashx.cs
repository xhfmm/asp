using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Lesson3
{
    /// <summary>
    /// EditHandler 的摘要说明
    /// </summary>
    public class EditHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //获取通过get方式传递过来的id值
            int id = int.Parse(context.Request["id"]);
            //通过id查询数据库获取相应数据
            string sql = "select * from User_info where Id= @id;";
            //sgqlParameter[] ps = { new SqlParameter"@id", id) };
            SqlParameter ps = new SqlParameter("@id", id) ;
            DataTable dt = SQLHelper.ExecuteDataTable(sql, ps);
            //读取HTML模板
            string strResult = File.ReadAllText(context.Request.MapPath("Edit.html"));
            //用查询到的数据替换占位符
            strResult = strResult.Replace("@name", dt.Rows[0]["Name"].ToString());
            strResult = strResult.Replace("@age", dt.Rows[0]["Age"].ToString());
            strResult = strResult.Replace("@number", dt.Rows[0]["Number"].ToString());
            strResult = strResult.Replace("@company", dt.Rows[0]["Company"].ToString());
            strResult = strResult.Replace("@address", dt.Rows[0]["Adress"].ToString());
            strResult = strResult.Replace("@Id", dt.Rows[0]["Id"].ToString());
            context.Response.Write(strResult);
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