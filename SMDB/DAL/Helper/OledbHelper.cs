using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;


namespace DAL
{
    /// <summary>
    /// 访问Access数据库通用访问类
    /// </summary>
    public class OledbHelper
    {
        //适合Excel2003版本
        //private static string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel";
        //创建连接字符串(适用于excel2007以后的版本)  Microsoft.ACE.OLEDB.12.0
        private static string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';Extended Properties='Excel 12.0 Xml;HDR=Yes;IMEX=1;'";

        #region
        public static int Uplate(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //写入日志
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        public static object ExecuteScalar(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //写入日志
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static OleDbDataReader ExecuteReader(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                //写入日志
                throw ex;
            }
        }

        /// <summary>
        /// 执行返回数据集的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet DataSet(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                //写入日志
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion

        /// <summary>
        /// 将指定的Excel导入到数据集中
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataSet DataSet(string sql,string path)
        {
            OleDbConnection conn = new OleDbConnection(string.Format(connString, path));
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();

                #region 获取Excel表格的TableName
                List<string> tableName = new List<string>();
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                foreach (DataRow row in dt.Rows)
                {
                    string strSheetTableName = row["TABLE_NAME"].ToString();
                    //过滤无效SheetName   
                    if (strSheetTableName.Contains("$") && strSheetTableName.Replace("'", "").EndsWith("$"))
                    {
                        strSheetTableName = strSheetTableName.Replace("'", "");   //可能会有 '1X$' 出现
                        strSheetTableName = strSheetTableName.Substring(0, strSheetTableName.Length - 1);
                        tableName.Add(strSheetTableName);
                    }
                }
                #endregion

                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                //写入日志
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
