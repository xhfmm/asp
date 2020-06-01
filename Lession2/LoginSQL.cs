using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lession2
{
    public static class LoginSQL
    {
        public static bool Login(string name,string pwd)
        {
            string sql = "select count(*) from Login_info where UserName=@name and Password=@pwd";
            int result=(int)SQLHelper.ExecuteScalar(sql, new SqlParameter("@name", name), new SqlParameter("@pwd", pwd));
            return result > 0 ? true : false;
        }

    }
}