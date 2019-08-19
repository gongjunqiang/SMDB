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
    /// 班级表数据访问类
    /// </summary>
    public class StudentClassService
    {
        /// <summary>
        /// 查询所以班级
        /// </summary>
        /// <returns></returns>
        public List<StudentClass> GetAllClass()
        {
            string sql = "select ClassId,ClassName from StudentClass";
            List<StudentClass> studentClasses = new List<StudentClass>();

            try
            {
                SqlDataReader reader = SQLHelper.GetReader(sql);
                while (reader.Read())
                {
                    studentClasses.Add(new StudentClass
                    {
                        ClassId = Convert.ToInt32(reader["ClassId"]),
                        ClassName = reader["ClassName"].ToString()
                    }); 
                }
                reader.Close();
                return studentClasses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取所有的班级，存放再数据集DataSet中
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllClasses()
        {
            string sql = "select ClassId,ClassName from StudentClass";
            return SQLHelper.GetDataSet(sql);
        }
    }
}
