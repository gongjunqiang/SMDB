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
    /// 菜单树形节点数据访问类
    /// </summary>
    public class MenulistService
    {
        public List<Menulist> GetAllMenu()
        {
            string sql = "select MenuId,MenuName,MenuCode,ParentId from Menulist";
            List<Menulist> menulist = new List<Menulist>();
            try
            {
                SqlDataReader reader = SQLHelper.GetReader(sql);
                while (reader.Read())
                {
                    menulist.Add(new Menulist
                    {
                        MenuId = Convert.ToInt32(reader["MenuId"]),
                        MenuName = reader["MenuName"].ToString(),
                        MenuCode = reader["MenuCode"].ToString(),
                        ParentId = reader["ParentId"].ToString(),
                    });
                }
                reader.Close();
                return menulist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
