using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;


namespace DAL
{
    /// <summary>
    /// 成绩表数据访问类
    /// </summary>
    public class ScoreListService
    {
        #region 使用DataSet保存学员成绩
        /// <summary>
        /// 获取成绩列表
        /// </summary>
        /// <returns>返回一个DataSet对象</returns>
        public DataSet GetScoreList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Students.StudentId,StudentName,Gender,ClassName,PhoneNumber,CSharp,SQLServerDB from Students");
            sql.Append(" left join StudentClass on Students.ClassId=StudentClass.ClassId");
            sql.Append(" left join ScoreList on Students.StudentId=ScoreList.StudentId");
            return SQLHelper.GetDataSet(sql.ToString());
        }
        #endregion

        #region 学员成绩查询
        /// <summary>
        /// 根基班级查询成绩
        /// </summary>
        /// <param name="classId"></param>
        /// <returns>返回一个学员成绩列表</returns>
        public List<StudentExt> QueryScoreList(int classId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Students.StudentId,StudentName,Gender,ClassName,PhoneNumber,CSharp,SQLServerDB from Students");
            sql.Append(" inner join StudentClass on Students.ClassId=StudentClass.ClassId");
            sql.Append(" inner join ScoreList on Students.StudentId=ScoreList.StudentId");
            if (classId != 0)
            {
                sql.Append(" where StudentClass.ClassId="+ classId);
            }
            List<StudentExt> scoreList = new List<StudentExt>();
            try
            {
                SqlDataReader reader = SQLHelper.GetReader(sql.ToString());
                while (reader.Read())
                {
                    scoreList.Add(new StudentExt
                    {
                        StudentId = Convert.ToInt32(reader["StudentId"]),
                        StudentName = reader["StudentName"].ToString(),
                        ClassName = reader["StudentName"].ToString(),
                        Gender = reader["StudentName"].ToString(),
                        CSharp = Convert.ToInt32(reader["StudentId"]),
                        SQLServerDB = Convert.ToInt32(reader["StudentId"]),

                    });
                }
                return scoreList;
            }
            catch (Exception ex)
            {
               throw new Exception("数据库访问异常："+ex.Message);
            }
        }

        #endregion





    }
}
