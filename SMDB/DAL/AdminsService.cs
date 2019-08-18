using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 管理员表数据访问类
    /// </summary>
    public class AdminsService
    {
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        public Admins UserLogin(Admins admins)
        {
            string sql = "select * from Admins where AdminName='{0}' and LoginPwd='{1}'";
            sql = string.Format(sql,admins.AdminName,admins.LoginPwd);
            try
            {
                SqlDataReader reader = SQLHelper.GetReader(sql);
                if (reader.Read())
                {
                    admins.LoginId = Convert.ToInt32(reader["LoginId"]);
                    admins.AdminName = reader["AdminName"].ToString();
                    admins.LoginPwd = reader["LoginPwd"].ToString();
                }
                else
                {
                    admins = null;
                }
                reader.Close();
            }
            catch (SqlException)
            {
                throw new Exception("应用程序和数据库连接出现问题！");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return admins;
        }

    }
}
