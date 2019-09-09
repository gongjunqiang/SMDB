using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;
using ORM.Core;

namespace DAL
{
    /// <summary>
    /// 学生表数据访问类
    /// </summary>
    public class StudentService
    {

        private DbContext db = new DbContext();
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
        /// <param name="student"></param>
        /// <returns>返回学员编号</returns>
        public int AddNewStudent(Students student)
        {
            //string sql = "insert into Students(StudentName, Gender, Birthday, StudentIdNo, CardNo, StuImage, Age, PhoneNumber, StudentAddress, ClassId)";
            //sql += " values('{0}','{1}','{2}',{3},'{4}','{5}',{6},'{7}','{8}',{9});";
            //sql += "select @@identity";
            //sql = string.Format(sql, student.StudentName, student.Gender, student.Birthday, student.StudentIdNo, student.CardNo,
            //      student.StuImage, student.Age, student.PhoneNumber, student.StudentAddress, student.ClassId);
            ////SqlParameter[] sqlParameters = new SqlParameter[]
            ////{
            ////    new SqlParameter("@StudentName",student.StudentName),
            ////    new SqlParameter("@Gender",student.Gender),
            ////    new SqlParameter("@Birthday",student.Birthday.ToString("yyyyMMdd")),
            ////    new SqlParameter("@StudentIdNo",student.StudentIdNo),
            ////    new SqlParameter("@CardNo",student.CardNo),
            ////    new SqlParameter("@StuImage",student.StuImage),
            ////    new SqlParameter("@Age",student.Age),
            ////    new SqlParameter("@PhoneNumber",student.PhoneNumber),
            ////    new SqlParameter("@StudentAddress",student.StudentAddress),
            ////    new SqlParameter("@ClassId",student.ClassId),
            ////};

            //try
            //{

            //    //返回学号
            //    return Convert.ToInt32(SQLHelper.GetSignalResult(sql));
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("添加学员时数据库访问异常！" + ex.Message);
            //}
            return db.AddModel(student);
        }

        public bool Import(List<StudentExt> studentList)
        {
            string sql = "insert into Students(StudentName, Gender, Birthday, StudentIdNo, CardNo, Age, PhoneNumber, StudentAddress, ClassId)";
            sql += " values('{0}','{1}','{2}',{3},'{4}',{5},'{6}','{7}',{8});";
            List<string> sqlList = new List<string>();
            foreach (var student in studentList)
            {
                string sql1 = string.Format(sql, student.StudentName, student.Gender, student.Birthday, student.StudentIdNo, student.CardNo,
                    student.Age, student.PhoneNumber, student.StudentAddress, student.ClassId);
                sqlList.Add(sql1);
            }
            //将Slq语句提交到数据库
            try
            {
                //返回学号
                return SQLHelper.UpdateByTran(sqlList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region 学员信息查询
        /// <summary>
        /// 根据班级Id查询学生列表
        /// </summary>
        /// <param name="classId"></param>
        /// <returns>返回学生列表</returns>
        public List<StudentExt> GetStudentByClassId(int classId)
        {
            string sql = "select StudentId,StudentName, Gender, Birthday, StudentIdNo, PhoneNumber, ClassName";
            sql += " from Students inner join StudentClass on Students.ClassId=StudentClass.ClassId";
            sql += " where StudentClass.ClassId=" + classId;
            List<StudentExt> studentList = new List<StudentExt>();
            SqlDataReader reader = SQLHelper.GetReader(sql);
            //try
            //{
            //    while (reader.Read())
            //    {
            //        studentList.Add(new StudentExt
            //        {
            //            StudentId = Convert.ToInt32(reader["StudentId"]),
            //            StudentName = reader["StudentName"].ToString(),
            //            Gender = reader["Gender"].ToString(),
            //            Birthday = Convert.ToDateTime(reader["Birthday"]),
            //            StudentIdNo = reader["StudentIdNo"].ToString(),
            //            PhoneNumber = reader["PhoneNumber"].ToString(),
            //            ClassName = reader["ClassName"].ToString(),
            //        }); ;
            //    }
            //    reader.Close();
            //    return studentList;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("查询学生列表时数据库访问异常" + ex.Message);
            //}
            return db.GetAllModeList<StudentExt>(reader);
        }

        /// <summary>
        /// 根据学员学号查询学员信息
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public StudentExt GetStudebntByStudentId(int studentId)
        {
            return QueryStudent($" where StudentId={studentId}");
        }
        #endregion

        #region 修改学员信息
        /// <summary>
        /// 修改学员信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int UpdateStudentInfo(Students student)
        {
            return db.Update(student);

            StringBuilder sql = new StringBuilder();
            sql.Append("update Students set StudentName=@StudentName, Gender=@Gender, Birthday=@Birthday, StudentIdNo=@StudentIdNo,");
            sql.Append(" CardNo=@CardNo, StuImage=@StuImage, PhoneNumber=@PhoneNumber, StudentAddress=@StudentAddress, ClassId=@ClassId,");
            sql.Append(" Age=@Age where StudentId="+ student.StudentId);
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@StudentName",student.StudentName),
                new SqlParameter("@Gender",student.Gender),
                new SqlParameter("@Birthday",student.Birthday.ToString("yyyyMMdd")),
                new SqlParameter("@StudentIdNo",student.StudentIdNo),
                new SqlParameter("@CardNo",student.CardNo),
                new SqlParameter("@StuImage",student.StuImage),
                new SqlParameter("@Age",student.Age),
                new SqlParameter("@PhoneNumber",student.PhoneNumber),
                new SqlParameter("@StudentAddress",student.StudentAddress),
                new SqlParameter("@ClassId",student.ClassId),
            };

            try
            {
                return SQLHelper.Update(sql.ToString(), sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("跟新学员信息时数据库访问异常！" + ex.Message);
            }
        }

        /// <summary>
        /// 修改学员信息判断身份证号和其他学员是否重复
        /// </summary>
        /// <param name="studentIdNo">新的身份证号</param>
        /// <param name="studentId">当前学员学号</param>
        /// <returns></returns>
        public bool IsIdNoExisted(string studentIdNo,int studentId)
        {
            string sql = $"select count(1) from Students where StudentIdNo={studentIdNo} and StudentId<>{studentId}";
            var count = (int)SQLHelper.GetSignalResult(sql);
            return count == 1 ? true : false;
        }

        /// <summary>
        /// 修改学员信息判断考勤卡号和其他学员是否重复
        /// </summary>
        /// <param name="cardNo"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public bool IsCradNoExisted(string cardNo,int studentId)
        {
            string sql = $"select count(1) from Students where CardNo={cardNo} and StudentId<>{studentId}";
            var count = (int)SQLHelper.GetSignalResult(sql);
            return count == 1 ? true : false;
        }
        #endregion

        #region 删除学员
        /// <summary>
        /// 根据学员对象发生异常
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public int DeleteStudent(int studentId)
        {
            var sql = "delete from Students where StudentId=" + studentId;
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    throw new Exception("该学员被其他数据表引用，不能直接删除");
                }
                else
                {
                    throw new Exception("删除学员时数据库操作异常：" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据学员对象发生异常
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int DeleteStudent(Students student)
        {
            return db.Delete(student);
            var sql = "delete from Students where StudentId=" + student.StudentId;
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    throw new Exception("该学员被其他数据表引用，不能直接删除");
                }
                else
                {
                    throw new Exception("删除学员时数据库操作异常：\r\n" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 根据卡号获取学员信息
        /// <summary>
        /// 根据学员学号查询学员信息
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public StudentExt GetStudebntByCardNo(string cardNo)
        {
            return QueryStudent($" where CardNo='{cardNo}'");
        }
        #endregion

        #region privateMethod
        /// <summary>
        /// 查询学员信息
        /// </summary>
        /// <param name="whereSql"></param>
        /// <returns></returns>
        private StudentExt QueryStudent(string whereSql)
        {
            string sql = "select StudentId, StudentName, Gender, Birthday, StudentIdNo, CardNo, StuImage, PhoneNumber, StudentAddress, Students.ClassId,ClassName";
            sql += " from Students inner join StudentClass on Students.ClassId=StudentClass.ClassId";
            sql += whereSql;
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
                        StuImage = reader["StuImage"] == null ? "" : reader["StuImage"].ToString(),
                        StudentAddress = reader["StudentAddress"].ToString(),
                        ClassId = Convert.ToInt32(reader["ClassId"]),
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
