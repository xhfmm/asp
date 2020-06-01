using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Lesson3
{
    /// <summary>
    /// ListHandler 的摘要说明
    /// </summary>
    public class ListHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //拼接html字符串
            StringBuilder strbuilder = new StringBuilder();
            strbuilder.Append("<html><head></head><body><a href='AddInfo.html'>添加</a><br/>");
            //拼接table字符串
            strbuilder.Append("<table><tr><th>编号</th><th>姓名</th><th>年龄</th><th>电话号码 </th ><th>公司</th><th>住址</th><th>操作</th></tr>");
            //获取数据库中的数据
            string sql =" select * from User_info";
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            while (reader.Read())
            {
                strbuilder.AppendFormat("<tr><td>{0}</td> <td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td> <td>{5}</td>" +
                    "<td><a href='ShowDetailHandler.ashx?id={0}'>详情</a>&nbsp&nbsp" +
                    "<a onClick='return confirm(\"是否删除\")' href='Delete.ashx?id={0}'>删除</a>&nbsp&nbsp" +
                    "<a href='EditHandler.ashx?id={0}'>修改</a></td></tr>",
                    reader.GetInt32(0), reader[1], reader[2], reader[3], reader[4], reader[5]);
            }
            strbuilder.Append("</table>");
            strbuilder.Append("</body></html>");
            context.Response.Write(strbuilder.ToString());
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