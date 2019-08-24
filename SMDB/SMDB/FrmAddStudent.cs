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
    public partial class FrmAddStudent : Form
    {

        private StudentClassService studentClassService = new StudentClassService();
        private StudentService studentService = new StudentService();
        private List<StudentExt> studentList = new List<StudentExt>();


        public FrmAddStudent()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClassName.DataSource = studentClassService.GetAllClass();
            this.cboClassName.DisplayMember = "ClassName";
            this.cboClassName.ValueMember = "ClassId";
            this.cboClassName.SelectedIndex = -1;
            this.dgvStudentList.AutoGenerateColumns = false;

        }

        //关闭窗体
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //选择照片
        private void BtnChoseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                this.pbStu.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        //清除照片
        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.pbStu.Image = null;
        }

        //添加学员   
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            #region 数据验证
            if (this.txtStudentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("学生姓名不能为空!", "提示信息");
                return;
            }

            if (this.rdoFemale.Checked == false && this.rdoMale.Checked == false)
            {
                MessageBox.Show("请选择性别!", "提示信息");
                return;
            }

            if (this.cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("请选择班级!", "提示信息");
                return;
            }

            var age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year;

            if (age < 18 || age > 35)
            {
                MessageBox.Show("年龄必须在18到35之间!", "提示信息");
                return;
            }

            if (!DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("身份证号不符合要求!", "提示信息");
                this.txtStudentIdNo.SelectAll();
                this.txtStudentIdNo.Focus();
                return;
            }

            //验证身份证号与出生日期是否一致
            var birthday = Convert.ToDateTime(this.dtpBirthday.Text).ToString("yyyyMMdd");
            if (!this.txtStudentIdNo.Text.Trim().Contains(birthday))
            {
                MessageBox.Show("身份证与出生日期不匹配!", "提示信息");
                this.txtStudentIdNo.SelectAll();
                this.txtStudentIdNo.Focus();
                return;
            }

            if (studentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("身份证号已经被其他学员使用!", "提示信息");
                this.txtStudentIdNo.SelectAll();
                this.txtStudentIdNo.Focus();
                return;
            }

            if (studentService.IsCradNoExisted(this.txtCardNo.Text.Trim()))
            {
                MessageBox.Show("考勤卡号已经被其他学员使用!", "提示信息");
                this.txtCardNo.SelectAll();
                this.txtCardNo.Focus();
                return;
            }



            #endregion

            #region 对象封装
            StudentExt student = new StudentExt
            {
                StudentName = this.txtStudentName.Text.Trim(),
                Gender = this.rdoFemale.Checked ? "女" : "男",
                Birthday = Convert.ToDateTime(this.dtpBirthday.Text),
                StudentIdNo = this.txtStudentIdNo.Text.Trim(),
                StuImage = this.pbStu.Image != null ? SerializeObjectToString.SerializeObject(this.pbStu.Image) : "",
                Age = age,
                CardNo = this.txtCardNo.Text.Trim(),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                StudentAddress = this.txtAddress.Text.Trim(),
                StudentId = Convert.ToInt32(this.cboClassName.SelectedValue),
                ClassName = this.cboClassName.Text
            };
            #endregion

            #region 后台调用
            try
            {
                var studenteId = studentService.AddNewStudent(student);
                if (studenteId > 1)
                {
                    student.ClassId = studenteId;
                    studentList.Add(student);
                    this.dgvStudentList.DataSource = null;
                    this.dgvStudentList.DataSource = studentList;
                    #region endregion询问是否继续添加
                    DialogResult result = MessageBox.Show("学员添加成功，是否继续添加?", "提示信息",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //清空数据
                        foreach (Control item in this.gbstuinfo.Controls)
                        {
                            if (item is TextBox)
                            {
                                item.Text = string.Empty;
                            }
                        }
                        this.cboClassName.SelectedIndex = -1;
                        this.rdoFemale.Checked = false;
                        this.rdoMale.Checked = false;
                        this.pbStu.Image = null;
                        this.txtStudentName.Focus();
                    }
                    else
                    {
                        this.Close();
                    }
                    # endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加学员出现访问异常："+ex.Message);
            }
            #endregion
        }


        //添加行号
        private void DgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //DataGridViewStyle.DgvRowPostPaint(this.dgvStudentList, e);
            try
            {
                //添加行号 
                SolidBrush v_SolidBrush = new SolidBrush(this.dgvStudentList.RowHeadersDefaultCellStyle.ForeColor);
                int v_LineNo = 0;
                v_LineNo = e.RowIndex + 1;
                string v_Line = v_LineNo.ToString();
                e.Graphics.DrawString(v_Line, e.InheritedRowStyle.Font, v_SolidBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加行号时发生错误，错误信息：" + ex.Message, "操作失败");
            }
        }
    }
}
