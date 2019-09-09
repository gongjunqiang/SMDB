using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ORM.Core
{
    /// <summary>
    /// 访问SQL Server数据库通用访问类
    /// </summary>
    public class SQLHelper
    {
        //定义数据库连接字符串
        private static readonly string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        private static readonly string a = @"Server=DESKTOP-DKRA2O6\SQLEXPRESS;Database=SMDB.Uid=sa;Pwd=195814";
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
                throw ex;
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
                //throw new Exception("方法public static object GetSignalResult执行异常", ex);
                throw ex;
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                //throw new Exception("方法public static SqlDataReader GetReader执行异常", ex);
                throw ex;
            }
        }

        /// <summary>
        /// 执行返回数据集的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <param name="isProcedure"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql,string tableName = null,bool isProcedure=false)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            //创建数据适配器对象
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //创建一个内存数据集
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                if (tableName != null)
                {
                    da.Fill(ds, tableName);
                }

                da.Fill(ds);//使用数据适配器填充数据集
                return ds;
            }
            catch (Exception ex)
            {
                //throw new Exception("方法public static DataSet GetDataSet执行异常", ex);
                throw ex;
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

        /// <summary>
        /// 通过事务提交数据：多条sql语句
        /// </summary>
        /// <param name="sqlList"></param>
        /// <returns></returns>
        public static bool UpdateByTran(List<string> sqlList)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();
                foreach (var sql in sqlList)
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();//提交事务：将数据保存到数据库，提交成功则事务会自动清空
                return true;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();//回滚事务，回滚成功事务也会自动清空
                }

                throw ex;
            }
            finally
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction = null;//清空事务
                }
                conn.Close();
            }
        }
    }
}
