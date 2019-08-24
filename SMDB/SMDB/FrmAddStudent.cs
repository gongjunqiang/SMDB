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
        public static List<StudentClass> studentClasses = null;
        public FrmAddStudent()
        {
            InitializeComponent();
            //初始化班级下拉框
            studentClasses = studentClassService.GetAllClass();
            this.cboClassName.DataSource = studentClasses;
            this.cboClassName.DisplayMember = "ClassName";
            this.cboClassName.ValueMember = "ClassId";
            this.cboClassName.SelectedIndex = -1;





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
                MessageBox.Show("学生姓名不能为空!","提示信息");
                return;
            }

            if (this.rdoFemale.Checked==false && this.rdoMale.Checked == false)
            {
                MessageBox.Show("请选择性别!", "提示信息");
                return;
            }

            if (this.cboClassName.SelectedIndex==-1)
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



            #endregion
        }
    }
}
