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
    /// 学生表数据访问类
    /// </summary>
    public class StudentService
    {
        #region 添加学员
        /// <summary>
        /// 判断身份证号是否存在
        /// </summary>
        /// <param name="studentIdNo"></param>
        /// <returns></returns>
        public bool IsIdNoExisted(string studentIdNo)
        {
            string sql = "select count(1) from Students where StudentIdNo=" + studentIdNo;
            var count = (int)SQLHelper.GetSignalResult(sql);
            return count == 1 ? true : false;
        }

        /// <summary>
        /// 判断考勤卡号是否存在
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public bool IsCradNoExisted(string cardNo)
        {
            string sql = "select count(1) from Students where CardNo=" + cardNo;
            var count = (int)SQLHelper.GetSignalResult(sql);
            return count == 1 ? true : false;
        }


        /// <summary>
        /// 添加学员
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns>返回学员编号</returns>
        public int AddNewStudent(StudentExt student)
        {
            string sql = "insert into Students(StudentName, Gender, Birthday, StudentIdNo, CardNo, StuImage, Age, PhoneNumber, StudentAddress, ClassId)";
            sql += " values('{0}','{1}','{2}',{3},'{4}','{5}',{6},'{7}','{8}',{9});";
            sql += "select @@identity";
            sql = string.Format(sql, student.StudentName, student.Gender, student.Birthday, student.StudentIdNo, student.CardNo,
                  student.StuImage, student.Age, student.PhoneNumber, student.StudentAddress, student.StudentId);
            //SqlParameter[] sqlParameters = new SqlParameter[]
            //{
            //    new SqlParameter("@StudentName",student.StudentName),
            //    new SqlParameter("@Gender",student.Gender),
            //    new SqlParameter("@Birthday",student.Birthday.ToString("yyyyMMdd")),
            //    new SqlParameter("@StudentIdNo",student.StudentIdNo),
            //    new SqlParameter("@CardNo",student.CardNo),
            //    new SqlParameter("@StuImage",student.StuImage),
            //    new SqlParameter("@Age",student.Age),
            //    new SqlParameter("@PhoneNumber",student.PhoneNumber),
            //    new SqlParameter("@StudentAddress",student.StudentAddress),
            //    new SqlParameter("@ClassId",student.ClassId),
            //};

            try
            {
                //返回学号
                return Convert.ToInt32( SQLHelper.GetSignalResult(sql));
            }         
            catch (Exception ex)
            {
                throw new Exception("添加学员时数据库访问异常！"+ex.Message);
            }
        }
        #endregion

        #region 学员管理
        /// <summary>
        /// 根据班级Id查询学生列表
        /// </summary>
        /// <param name="classId"></param>
        /// <returns>返回学生列表</returns>
        public List<StudentExt> GetStudentByClassId(int classId)
        {
            string sql = "select StudentId,StudentName, Gender, Birthday, StudentIdNo, PhoneNumber, ClassName";
            sql += " from Students inner join StudentClass on Students.ClassId=StudentClass.ClassId";
            sql += " where StudentClass.ClassId="+ classId;
            List<StudentExt> studentList = new List<StudentExt>();
            try
            {
                SqlDataReader reader = SQLHelper.GetReader(sql);
                while (reader.Read())
                {
                    studentList.Add(new StudentExt
                    {
                        StudentId = Convert.ToInt32(reader["StudentId"]),
                        StudentName = reader["StudentName"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        Birthday = Convert.ToDateTime( reader["Birthday"]),
                        StudentIdNo = reader["StudentIdNo"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        ClassName = reader["ClassName"].ToString(),
                    }); ;
                }
                reader.Close();
                return studentList;
            }
            catch (Exception ex)
            {
                throw new Exception("查询学生列表时数据库访问异常"+ex.Message);
            }
        }

        /// <summary>
        /// 根据学员学号查询学员信息
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public StudentExt GetStudebntByStudentId(int studentId)
        {
            string sql = "select StudentId, StudentName, Gender, Birthday, StudentIdNo, CardNo, StuImage, PhoneNumber, StudentAddress, ClassName";
            sql += " from Students inner join StudentClass on Students.ClassId=StudentClass.ClassId";
            sql += " where StudentId=" + studentId;
            StudentExt studentInfo = null;
            try
            {
                SqlDataReader reader = SQLHelper.GetReader(sql);
                if (reader.Read())
                {
                    studentInfo = new StudentExt
                    {
                        StudentId = Convert.ToInt32(reader["StudentId"]),
                        StudentName = reader["StudentName"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        Birthday = Convert.ToDateTime(reader["Birthday"]),
                        StudentIdNo = reader["StudentIdNo"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        CardNo = reader["CardNo"].ToString(),
                        StuImage = reader["StuImage"].ToString(),
                        StudentAddress = reader["StudentAddress"].ToString(),
                        ClassName = reader["ClassName"].ToString(),
                    }; 
                }
                reader.Close();
                return studentInfo;
            }
            catch (Exception ex)
            {
                throw new Exception("获取学生信息时数据库访问异常" + ex.Message);
            }
        }
        #endregion


    }
}
