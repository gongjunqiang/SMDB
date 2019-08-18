using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    /// <summary>
    /// 访问SQL Server数据库通用访问类
    /// </summary>
    public class SQLHelper
    {
        //定义数据库连接字符串
        private static readonly string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();


        /// <summary>
        /// 执行insert、delete、update等操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static int Update(string sql, SqlParameter[] sqlParameters = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (sqlParameters != null)
            {
                cmd.Parameters.AddRange(sqlParameters);
            }

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("方法public static int Update执行异常", ex);
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// 执行单一结果查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSignalResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("方法public static object GetSignalResult执行异常", ex);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行结果集查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception("方法public static SqlDataReader GetReader执行异常", ex);
            }
        }

        /// <summary>
        /// 执行返回数据集的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            //创建数据适配器对象
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds);//使用数据适配器填充数据集
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("方法public static DataSet GetDataSet执行异常", ex);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerTime()
        {
            var serverTime = Convert.ToDateTime(GetSignalResult("select getdate()"));
            return serverTime;
        }


    }
}
