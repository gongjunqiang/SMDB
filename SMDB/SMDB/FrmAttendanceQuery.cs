using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using DAL;

namespace SMDB
{
    public partial class FrmAttendanceQuery : Form
    {
        private AttendanceService attendanceService = new AttendanceService();
        public FrmAttendanceQuery()
        {
            InitializeComponent();
            this.dgvStudentList.AutoGenerateColumns = false;
            DataGridViewStyle.DgvStyle1(dgvStudentList);

            //应到的人数

            //studentCount = attendanceService.GetStudentCount();
            //展示应到人数
            this.lblCount.Text = attendanceService.GetStudentCount().ToString(); 
            

        }

        //查询
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            //根据日期和学员姓名获取考勤记录
            List<StudentExt> studentList = attendanceService.GetAttendanceRecordByTime(this.dtpTime.Value,this.txtName.Text.Trim());
            this.dgvStudentList.DataSource = null;
            this.dgvStudentList.DataSource = studentList;
            //根据日期查询考勤统计信息
            //【1】展示应到人数
            this.lblCount.Text = attendanceService.GetStudentCount().ToString();
            //【2】展示实到人数
            this.lblReal.Text = attendanceService.GetAttdanceStudentCount(this.dtpTime.Value).ToString();
            //【3】展示缺勤人数
            this.lblAbsenceCount.Text = (Convert.ToInt32(this.lblCount.Text) - Convert.ToInt32(this.lblReal.Text)).ToString();
        }

        private void DgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgvStudentList, e);
        }
    }
}
