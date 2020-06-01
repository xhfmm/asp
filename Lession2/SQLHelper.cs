using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Lession2
{
    public static class SQLHelper
    {
        private static string constr = ConfigurationManager.ConnectionStrings["connectStr"].ConnectionString;

        //执行增删改
        public static int ExecuteNonQuery(string sql,params SqlParameter[] pms)
        {
            using(SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd=new SqlCommand(sql,con))
                {
                    if (pms != null)
                    {
                        //将参数添加到Parameter集合中
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            
        }
        //查询
        public static object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        //将参数添加到Parameter集合中
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        //执行返回ExecuteReader
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(constr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (pms != null)
                {
                    //将参数添加到Parameter集合中
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    //关闭DataReader对象时，则关联的Connection对象也关闭
                }
                catch (SqlException e)
                {
                    con.Close();
                    con.Dispose();
                    throw e;
                }
            }
        }

        //执行返回DataTable
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter=new SqlDataAdapter (sql,constr))
            {
                if (pms!=null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
            //读取数据填充到本地数据库对象中
            adapter.Fill(dt);
            }
            return dt;
        }
    }


}
