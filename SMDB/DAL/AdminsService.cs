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

        /// <summary>
        /// 管理员密码修改
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        public int UpdatePwd(Admins admins)
        {
            string sql = "update Admins set LoginPwd={0} where AdminName='{1}' and LoginId='{2}'";
            sql = string.Format(sql, admins.LoginPwd, admins.AdminName, admins.LoginId);
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (Exception ex)
            {

                throw new Exception("修改密码出现数据库访问错误！",ex);
            }
        }
    }
}
