using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Model;

namespace SMDB
{
    public partial class FrmAttendance : Form
    {
        private AttendanceService attendanceService = new AttendanceService();
        private StudentService studentService = new StudentService();
        private int studentCount = 0;
        private List<StudentExt> studentList = new List<StudentExt>();
        public FrmAttendance()
        {
            InitializeComponent();
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            Timer1_Tick(null, null);
            this.dgvStudentList.AutoGenerateColumns = false;

            #region 显示学员总数以及打卡人数
            //显示学员总数以及打卡人数
            studentCount = attendanceService.GetStudentCount();
            //展示应到人数
            this.lblCount.Text = studentCount.ToString();
            SignStart();
            #endregion

            DataGridViewStyle.DgvStyle1(this.dgvStudentList);


        }

        private void SignStart()
        {
            //展示已经打卡人数
            this.lblReal.Text = attendanceService.GetAttdanceStudentCount().ToString();
            //展示缺勤人数
            this.lblAbsenceCount.Text = (studentCount - Convert.ToInt32(this.lblReal.Text)).ToString();
        }

    

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var time = DateTime.Now;
            this.lblYear.Text = time.Year.ToString();
            this.lblMonth.Text = time.Month.ToString();
            this.lblDay.Text = time.Day.ToString();
            this.lblTime.Text = time.ToLongTimeString();
            #region 星期展示
            switch (time.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    this.lblWeek.Text = "天";
                    break;
                case DayOfWeek.Monday:
                    this.lblWeek.Text = "一";
                    break;
                case DayOfWeek.Tuesday:
                    this.lblWeek.Text = "二";
                    break;
                case DayOfWeek.Wednesday:
                    this.lblWeek.Text = "三";
                    break;
                case DayOfWeek.Thursday:
                    this.lblWeek.Text = "四";
                    break;
                case DayOfWeek.Friday:
                    this.lblWeek.Text = "五";
                    break;
                case DayOfWeek.Saturday:
                    this.lblWeek.Text = "六";
                    break;
                default:
                    break;
            }
            #endregion
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 回车键打卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtStuCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && this.txtStuCardNo.Text.Trim().Length != 0)
            {
                try
                {
                    //展示学员信息
                    StudentExt studentInfo = studentService.GetStudebntByCardNo(this.txtStuCardNo.Text.Trim());
                    if (studentInfo == null)
                    {
                        this.lblStuName.Text = "";
                        this.lblStuId.Text = "";
                        this.lblStuClass.Text = "";
                        this.pbStu.Image = null;
                        this.lblInfo.Text = "打卡失败!";
                        MessageBox.Show("考勤卡号错误!", "提示信息");
                        return;
                    }
                    else
                    {
                        //学员信息展示
                        this.lblStuName.Text = studentInfo.StudentName;
                        this.lblStuId.Text = studentInfo.StudentId.ToString();
                        this.lblStuClass.Text = studentInfo.ClassName;
                        #region 判断照片是否为null或者""字符串
                        if (studentInfo.StuImage == null || studentInfo.StuImage.Length == 0)
                        {
                            this.pbStu.Image = Image.FromFile("default.png");
                        }
                        else
                        {
                            this.pbStu.Image = (Image)SerializeObjectToString.DeserializeObject(studentInfo.StuImage);
                        }
                        #endregion
                        //添加打卡信息
                        string result = attendanceService.AddRecord(this.txtStuCardNo.Text.Trim());
                        if (result != "success")
                        {
                            this.lblInfo.Text = "打卡失败！";
                            MessageBox.Show(result, "提示信息");
                        }
                        else
                        {
                            this.lblInfo.Text = "打卡成功！";
                            //更新打卡人员总数
                            SignStart();
                            //将学员信息同步展示到列表中
                            studentInfo.DTime = DateTime.Now;
                            studentList.Add(studentInfo);
                            this.dgvStudentList.DataSource = null;
                            this.dgvStudentList.DataSource = studentList;
                            //清空卡号,等待下一个打卡
                            this.txtStuCardNo.Text = "";
                            this.txtStuCardNo.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示信息");
                }
            }
        }

        private void FrmAttendance_Load(object sender, EventArgs e)
        {
            this.txtStuCardNo.Focus();
        }

        private void DgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgvStudentList,e);
        }
    }
}
