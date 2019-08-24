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
    public partial class FrmStudentManage : Form
    {
        private StudentClassService studentClassService = new StudentClassService();
        private StudentService studentService = new StudentService();
        private List<StudentExt> studentList = null;
        public FrmStudentManage()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClass.DataSource = studentClassService.GetAllClass();
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember = "ClassId";
            this.cboClass.SelectedIndex = -1;
            this.dgvStudentList.AutoGenerateColumns = false;
            this.btnNameDESC.Enabled = false;
            this.btnStuIdDESC.Enabled = false;


        }

        /// <summary>
        /// 根据班级查询学生列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (this.cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("请选择班级！","提示信息");
                return;
            }
            var classId = Convert.ToInt32(this.cboClass.SelectedValue);
            try
            {
                this.studentList = studentService.GetStudentByClassId(classId);
                if (studentList.Count==0)
                {
                    MessageBox.Show("此班级暂无学生");
                    return;
                }
                this.btnNameDESC.Enabled = true;
                this.btnStuIdDESC.Enabled = true;
                this.dgvStudentList.DataSource = null;
                this.dgvStudentList.DataSource = studentList;
                DataGridViewStyle.DgvStyle1(dgvStudentList);
            }
            catch (Exception ex)
            {
                throw new Exception("查询学员信息异常："+ex.Message);
            }
        }

        //显示行号
        private void DgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(dgvStudentList, e);
        }

        //按照姓名降序排列
        private void BtnNameDESC_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0)
            {
                return;
            }
            this.studentList.Sort(new NameDesc());
            this.dgvStudentList.Refresh();
        }

        //按照学号降序排列
        private void BtnStuIdDESC_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0)
            {
                return;
            }
            this.studentList.Sort(new StudentIdDesc());
            this.dgvStudentList.Refresh();
        }

        //根据学号查询并显示学员信息
        public static FrmStudentInfo frmStudentInfo = null;


        private void BtnQueryById_Click(object sender, EventArgs e)
        {

            if (this.txtStudentId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入学员学号","提示信息") ;
                return;
            }
            int studentId = Convert.ToInt32(this.txtStudentId.Text.Trim());
            var studentInfo = studentService.GetStudebntByStudentId(studentId);
            if (studentInfo == null)
            {
                MessageBox.Show("学员学号错误，暂无此学员！", "提示信息");
                return;
            }

            if (frmStudentInfo == null)
            {
                frmStudentInfo = new FrmStudentInfo(studentInfo);
                frmStudentInfo.ShowDialog();
            }
            else
            {
                frmStudentInfo.Activate();
                frmStudentInfo.WindowState = FormWindowState.Normal;
            }

          



        }
    }

    #region 实现排序
    class NameDesc : IComparer<StudentExt>
    {
        public int Compare(StudentExt x, StudentExt y)
        {
            return y.StudentName.CompareTo(x.StudentName);
        }
    }

    class StudentIdDesc : IComparer<StudentExt>
    {
        public int Compare(StudentExt x, StudentExt y)
        {
            return y.StudentId.CompareTo(x.StudentId);
        }
    }




    #endregion
}
