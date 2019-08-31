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
                        CSharp = Convert.ToInt32(reader["CSharp"]),
                        SQLServerDB = Convert.ToInt32(reader["SQLServerDB"]),

                    });
                }
                return scoreList;
            }
            catch (Exception ex)
            {
               throw new Exception("数据库访问异常："+ex.Message);
            }
        }

        /// <summary>
        /// 获取考试成绩统计信息
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public Dictionary<string, string> QueryScoreInfo(int classId)
        {
            string sql = "select stuCount=count(1),avgCharp=avg(CSharp),avgDB=avg(SQLServerDB)";
            sql += " from Students inner join ScoreList on Students.StudentId = ScoreList.StudentId";
            if (classId != 0)
            {
                sql += " where ClassId=" + classId;
            }
            sql += ";select absentCount=count(1) from Students where StudentId not in(select StudentId from ScoreList)";

            if (classId != 0)
            {
                sql += " and ClassId=" + classId;
            }

            SqlDataReader reader = SQLHelper.GetReader(sql);
            Dictionary<string, string> scoreInfo = null;
            if (reader.Read())
            {
                scoreInfo = new Dictionary<string, string>();
                scoreInfo.Add("stuCount", reader["stuCount"].ToString());
                scoreInfo.Add("avgCharp", reader["avgCharp"].ToString());
                scoreInfo.Add("avgDB", reader["avgDB"].ToString());
            }
            if (reader.NextResult())
            {
                if (reader.Read())
                {
                    scoreInfo.Add("absentCount", reader["absentCount"].ToString());
                }
            }
            reader.Close();
            return scoreInfo;
        }

        /// <summary>
        /// 查询缺考人员名单
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<string> QueryAbsentStudentList(int classId)
        {
            string sql = "select StudentName from Students where StudentId not in(select StudentId from ScoreList)";

            if (classId != 0)
            {
                sql += " and ClassId=" + classId;
            }
            List<string> absentStudentList = new List<string>();
            try
            {
                SqlDataReader reader = SQLHelper.GetReader(sql);
                while (reader.Read())
                {
                    absentStudentList.Add(reader["StudentName"].ToString());
                }
                reader.Close();
                return absentStudentList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 组合实体
        public List<QueryExt> Query(int classId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Students.StudentId,StudentName,Gender,ClassName,PhoneNumber,CSharp,SQLServerDB from Students");
            sql.Append(" inner join StudentClass on Students.ClassId=StudentClass.ClassId");
            sql.Append(" inner join ScoreList on Students.StudentId=ScoreList.StudentId");
            if (classId != 0)
            {
                sql.Append(" where StudentClass.ClassId=" + classId);
            }
            List<QueryExt> scoreList = new List<QueryExt>();
            try
            {
                SqlDataReader reader = SQLHelper.GetReader(sql.ToString());
                while (reader.Read())
                {
                    scoreList.Add(new QueryExt
                    {
                        StudentObj = new Students
                        {
                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            StudentName = reader["StudentName"].ToString(),
                            Gender = reader["StudentName"].ToString(),
                        },
                        ClassObj = new StudentClass
                        {
                            ClassName = reader["StudentName"].ToString(),
                        },
                        ScoreObj = new ScoreList
                        {

                            CSharp = Convert.ToInt32(reader["CSharp"]),
                            SQLServerDB = Convert.ToInt32(reader["SQLServerDB"]),
                        }
                    });
                }
                return scoreList;
            }
            catch (Exception ex)
            {
                throw new Exception("数据库访问异常：" + ex.Message);
            }
        }


        #endregion





    }
}
