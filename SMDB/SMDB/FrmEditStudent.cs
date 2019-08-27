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
    public partial class FrmEditStudent : Form
    {
        private StudentClassService studentClassService = new StudentClassService();
        private StudentService studentService = new StudentService();
        public FrmEditStudent()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClassName.DataSource = studentClassService.GetAllClass();
            this.cboClassName.DisplayMember = "ClassName";
            this.cboClassName.ValueMember = "ClassId";
        }
        public FrmEditStudent(StudentExt studentExt)
             : this()
        {
            this.txtStudentId.Text = studentExt.StudentId.ToString();
            this.txtStudentName.Text = studentExt.StudentName;
            this.rdoMale.Checked = studentExt.Gender=="男";
            this.cboClassName.Text = studentExt.ClassName;
            this.dtpBirthday.Text = studentExt.Birthday.ToShortDateString();
            this.txtStudentIdNo.Text = studentExt.StudentIdNo;
            this.txtCardNo.Text = studentExt.CardNo;
            this.txtPhoneNumber.Text = studentExt.PhoneNumber;
            this.txtAddress.Text = studentExt.StudentAddress;
            this.pbStu.Image = studentExt.StuImage.Length == 0 ? Image.FromFile("default.png") :
                (Image)SerializeObjectToString.DeserializeObject(studentExt.StuImage);
            if (studentExt.Gender == "男")
            {
                this.rdoMale.Checked = true;
            }
            else
            {
                this.rdoFemale.Checked = true;
            }
        }

        private void FrmEditStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmStudentManage.frmEditStudent = null;
        }

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
        private void BtnClearImage_Click(object sender, EventArgs e)
        {
            this.pbStu.Image = null;
        }

        //提交修改
        private void BtnModify_Click(object sender, EventArgs e)
        {
            #region 数据验证
            if (this.txtStudentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("学生姓名不能为空!", "提示信息");
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

            var studentId = Convert.ToInt32(this.txtStudentId.Text.Trim());
            if (studentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim(), studentId))
            {
                MessageBox.Show("身份证号已经被其他学员使用!", "修改提示");
                this.txtStudentIdNo.SelectAll();
                this.txtStudentIdNo.Focus();
                return;
            }

            if (studentService.IsCradNoExisted(this.txtCardNo.Text.Trim(), studentId))
            {
                MessageBox.Show("考勤卡号已经被其他学员使用!", "修改提示");
                this.txtCardNo.SelectAll();
                this.txtCardNo.Focus();
                return;
            }
            #endregion

            Students student = new Students
            {
                StudentId = studentId,
                StudentName = this.txtStudentName.Text.Trim(),
                Gender = this.rdoMale.Checked?"男":"女",
                Birthday = Convert.ToDateTime(this.dtpBirthday.Text),
                StudentIdNo = this.txtStudentIdNo.Text.Trim(),
                CardNo = this.txtCardNo.Text.Trim(),
                StuImage = this.pbStu.Image != null ? SerializeObjectToString.SerializeObject(this.pbStu.Image) : "",
                Age = age,
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                StudentAddress = this.txtAddress.Text.Trim(),
                ClassId = Convert.ToInt32(this.cboClassName.SelectedValue),
            };

            try
            {
                var result = studentService.UpdateStudentInfo(student);
                if (result == 1)
                {
                    MessageBox.Show("学员信息修改成功!", "提示信息");

                    var item = FrmStudentManage.studentList.First(o => o.StudentId == studentId);
                    item.StudentName = this.txtStudentName.Text.Trim();
                    item.Gender = this.rdoMale.Checked ? "男" : "女";
                    item.StudentIdNo = this.txtStudentIdNo.Text;
                    item.Birthday = this.dtpBirthday.Value;
                    item.PhoneNumber = this.txtPhoneNumber.Text;
                    item.ClassName = this.cboClassName.Text;
                    //this.dgvStudentList.Refresh(); 


                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示信息");
            }

        }
    }
}
