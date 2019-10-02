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
    /// 打卡记录表访问类
    /// </summary>
    public class AttendanceService
    {
        #region 考勤人数初始化获取
        /// <summary>
        /// 获取学员总数
        /// </summary>
        /// <returns></returns>
        public int GetStudentCount()
        {
            string sql = "select count(1) from Students";
            try
            {
                return (int)SQLHelper.GetSignalResult(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取已经打卡学员人数
        /// </summary>
        /// <returns></returns>
        public int GetAttdanceStudentCount()
        {
            return QuerySignAttendanceCount(" where datepart(DAY,DTime)=datepart(DAY,getdate())");
        }

        /// <summary>
        /// 根据时间获取打卡人数
        /// </summary>
        /// <param name="dtime"></param>
        /// <returns></returns>
        public int GetAttdanceStudentCount(DateTime dtime)
        {
            return QuerySignAttendanceCount($" where datepart(DAY,DTime)=datepart(DAY,'{dtime}')");
        }

        /// <summary>
        /// 查询打卡人数
        /// </summary>
        /// <param name="whereSql"></param>
        /// <returns></returns>
        private int QuerySignAttendanceCount(string whereSql)
        {
            string sql = "select count(distinct CardNo)  from Attendance";
            sql += whereSql;
            try
            {
                return (int)SQLHelper.GetSignalResult(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 考勤打卡
        /// <summary>
        /// 添加打卡记录
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public string AddRecord(string cardNo)
        {
            string sql = $"insert into Attendance(CardNo) values('{cardNo}')";
            try
            {
                SQLHelper.ExecuteNonQuery(sql,null);
                return "success";
            }
            catch (Exception ex)
            {
                return "打卡失败，系统异常！"+ex.Message;
            }
        }

        #region 根据考勤卡号获取学员详细信息
        /// <summary>
        /// 根据考勤卡号获取学员详细信息:自己的思路
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public StudentExt GetStudentInfoByCardNo(string cardNo)
        {
            string sql = "select top 1 DTime,StudentId,Students.CardNo,StudentName,Gender,ClassName,StudentClass.ClassId from Students";
            sql += " inner join Attendance on Students.CardNo=Attendance.CardNo";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId";
            sql += " where Students.CardNo='{0}' order by DTime Desc";
            sql = string.Format(sql, cardNo);
            StudentExt studentExt = null;
            try
            {
                SqlDataReader reader = SQLHelper.GetReader(sql);
                if (reader.Read())
                {
                    studentExt = new StudentExt
                    {
                        DTime = Convert.ToDateTime(reader["DTime"]),
                        StudentId = Convert.ToInt32(reader["StudentId"]),
                        CardNo = reader["CardNo"].ToString(),
                        StudentName = reader["StudentName"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        ClassName = reader["ClassName"].ToString(),
                    };
                }
                return studentExt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region 考勤统计
        /// <summary>
        /// 根据日期和学员姓名获取考勤记录
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public List<StudentExt> GetAttendanceRecordByTime(DateTime signtime,string studentName)
        {
            string sql = "select DTime,StudentId,Students.CardNo,StudentName,Gender,ClassName,StudentClass.ClassId from Students";
            sql += " inner join Attendance on Students.CardNo=Attendance.CardNo";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId";
            sql += " where datepart(DAY,DTime)=datepart(DAY,'{0}')";
            sql = string.Format(sql, signtime);
            if (studentName!=null && studentName.Length != 0)
            {
                sql += string.Format(" and StudentName='{0}'", studentName); 
            }
            sql += " order by DTime Desc";
            List<StudentExt> studentList = new List<StudentExt>();
            try
            {
                SqlDataReader reader = SQLHelper.GetReader(sql);
                while (reader.Read())
                {
                    studentList.Add ( new StudentExt
                    {
                        DTime = Convert.ToDateTime(reader["DTime"]),
                        StudentId = Convert.ToInt32(reader["StudentId"]),
                        CardNo = reader["CardNo"].ToString(),
                        StudentName = reader["StudentName"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        ClassName = reader["ClassName"].ToString(),
                    });
                }
                return studentList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion
    }
}
