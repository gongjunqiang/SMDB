using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DAL
{
    /// <summary>
    /// 从Excel导入数据
    /// </summary>
    public class ImportDataFromExcel
    {
        /// <summary>
        /// 将选择的Excel数据表查询后封装成对象集合
        /// </summary>
        /// <param name="path">excel路径</param>
        /// <returns></returns>
        public List<StudentExt> GetStudentByExcel(string path)
        {

            List<StudentExt> studentList = new List<StudentExt>();
            string sql = "select * from [Student$]";
            try
            {
                DataSet ds = OledbHelper.DataSet(sql, path);
                DataTable dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    studentList.Add(new StudentExt
                    {
                        StudentName = item["姓名"].ToString(),
                        Gender = item["性别"].ToString(),
                        Birthday = Convert.ToDateTime(item["出生日期"]),
                        StudentIdNo = item["身份证号"].ToString(),
                        PhoneNumber = item["电话号码"].ToString(),
                        CardNo = item["考勤卡号"].ToString(),
                        Age = DateTime.Now.Year - Convert.ToDateTime(item["出生日期"].ToString()).Year,
                        StudentAddress = item["家庭住址"].ToString(),
                        ClassId = Convert.ToInt32(item["班级编号"]),
                    });
                }
                return studentList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }



    }
}
