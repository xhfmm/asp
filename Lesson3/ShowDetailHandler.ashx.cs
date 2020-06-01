using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Lesson3
{
    /// <summary>
    /// ShowDetailHandler 的摘要说明
    /// </summary>
    public class ShowDetailHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            StringBuilder sb = new StringBuilder();
            sb.Append("<html><head></head><body><table>");//使用在程序中直接拼接字符串的页面生成方式
            //获取通过get方式传递过来的id值
            string id = context.Request.QueryString["id"];
            int showId = int.Parse(id);
            //通过id查询数据库获取相应数据
            string sql = "select * from User_info where Id= @Id;";
            //SqlParameter[] ps = { new SqlParameter("@Id", showId) };
            SqlParameter ps = new SqlParameter("@Id", showId);
            DataTable dt = SQLHelper.ExecuteDataTable(sql, ps);
            sb.AppendFormat("<tr><td>编号: </td><td>{0}</td></tr>", dt.Rows[0][0]);
            sb.AppendFormat("<tr><td>姓名: </td><td>{0}</td></tr>", dt.Rows[0][1]);
            sb.AppendFormat("<tr><td>年龄: </td><td>{0}</td></tr>", dt.Rows[0][2]);
            sb.AppendFormat("<tr><td>电话号码: </td><td>{0}</td></tr>", dt.Rows[0][3]);
            sb.AppendFormat("<tr><td>公司: </td><td>{0}</td></tr>", dt.Rows[0][4]);
            sb.AppendFormat("<tr><td>地址: </td><td>{0}</td></tr>", dt.Rows[0][5]);
            sb.Append("</table></body></html>");
            context.Response.Write(sb.ToString());//使用在程序中直接拼接字符串的页面生成方式


            //使用HTML模板的页面生成方式
            //string path = context.Request.MapPath"/ShowDetail.html"); //相 对路径转换为绝对路径
            //string textTemp = File.ReadAllText(path);
            //读取路径中的内容
            //string result = textTemp.Replace(" @trBody", sb.ToString()); //替换占位符
            //context.Response.Write(result);
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