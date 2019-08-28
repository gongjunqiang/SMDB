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
        public static List<StudentExt> studentList = null;
        public FrmStudentManage()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClass.DataSource = studentClassService.GetAllClass();
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember = "ClassId";
            this.cboClass.SelectedIndex = -1;
            this.dgvStudentList.AutoGenerateColumns = false;
            //禁用排序按钮
            this.btnNameDESC.Enabled = false;
            this.btnStuIdDESC.Enabled = false;
        }

        #region 查询学员列表
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

            var a = this.cboClass.SelectedValue;
            var classId = Convert.ToInt32(this.cboClass.SelectedValue);
            try
            {
                studentList = studentService.GetStudentByClassId(classId);
                if (studentList.Count==0)
                {
                    this.dgvStudentList.DataSource = null;
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
            studentList.Sort(new NameDesc());
            this.dgvStudentList.Refresh();
        }

        //按照学号降序排列
        private void BtnStuIdDESC_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0)
            {
                return;
            }
            studentList.Sort(new StudentIdDesc());
            this.dgvStudentList.Refresh();
        }
        #endregion

        #region 显示学员信息
        //根据学号查询并显示学员信息
        public static FrmStudentInfo frmStudentInfo = null;
        private void BtnQueryById_Click(object sender, EventArgs e)
        {

            if (this.txtStudentId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入学员学号","提示信息") ;
                return;
            }
            if (!DataValidate.IsInteger(this.txtStudentId.Text.Trim()))
            {
                MessageBox.Show("学号必须为整数！", "提示信息");
                this.txtStudentId.Focus();
                this.txtStudentId.SelectAll();
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

        //双击显示学员信息
        private void DgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvStudentList.Rows.Count != 0)
            {
                int studentId = Convert.ToInt32(this.dgvStudentList.CurrentRow.Cells["StudentId"].Value);
                var studentInfo = studentService.GetStudebntByStudentId(studentId);
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

        //键盘KeyDown事件:显示学员信息
        private void TxtStudentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtStudentId.Text.Trim().Length != 0 && e.KeyValue == 13)
            {
                BtnQueryById_Click(null, null);
            }

            //if (e.KeyCode == Keys.Enter)
            //{

            //}
        }

        #endregion

        #region 修改学员信息
        public static FrmEditStudent frmEditStudent = null;
        private void BtnEidt_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("请选择您需要修改的学员对象！", "提示信息");
                return;
            }

            int studentId = Convert.ToInt32(this.dgvStudentList.CurrentRow.Cells["StudentId"].Value);
            var studentInfo = studentService.GetStudebntByStudentId(studentId);

            if (frmEditStudent == null)
            {
                frmEditStudent = new FrmEditStudent(studentInfo);
                DialogResult result = frmEditStudent.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //同步刷新
                    //方法一：
                    //BtnQuery_Click(null, null);
                    //更新studentList，刷新dgv
                    //方法二：
                    this.dgvStudentList.Refresh(); 
                }
            }
            else
            {
                frmEditStudent.Activate();
                frmEditStudent.WindowState = FormWindowState.Normal;
            }
        }

        //鼠标右键修改学员信息
        private void TsmiModifyStu_Click(object sender, EventArgs e)
        {
            BtnEidt_Click(null, null);
        }
        #endregion

       

        #region 删除学员
        //删除学员
        private void BtnDel_Click(object sender, EventArgs e)
        {
            #region 删除验证
            if (this.dgvStudentList.RowCount == 0)
            {
                MessageBox.Show("没有需要删除的学员对象！", "删除提示");
                return;
            }
            if (this.dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("请选择需要删除的学员！", "删除提示");
                return;
            }
            #endregion

            #region 后台调用
            DialogResult dialogResult = MessageBox.Show("是否确认删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
            Students student = new Students
            {
                StudentId = Convert.ToInt32(this.dgvStudentList.CurrentRow.Cells["StudentId"].Value)
            };
            try
            {
                var deleteCount = studentService.DeleteStudent(student);
                if (deleteCount == 1)
                {
                    //刷新列表
                    //BtnQuery_Click(null, null);

                    studentList.Remove(studentList.First(o => o.StudentId == student.StudentId));
                    this.dgvStudentList.DataSource = null;
                    this.dgvStudentList.DataSource = studentList;
                    this.dgvStudentList.Refresh();
                    MessageBox.Show("学员删除成功！", "删除提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除学员异常：" + ex.Message,"提示信息");
            }
            #endregion

        }
        //右键删除学员
        private void TsmidDeleteStu_Click(object sender, EventArgs e)
        {
            BtnDel_Click(null,null);
        }
        #endregion


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
