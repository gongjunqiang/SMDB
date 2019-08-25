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
        public FrmEditStudent()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClassName.DataSource = studentClassService.GetAllClass();
            this.cboClassName.DisplayMember = "ClassName";
            this.cboClassName.ValueMember = "ClassId";
            this.cboClassName.SelectedIndex = -1;
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
    }
}
