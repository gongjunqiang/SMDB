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
    public partial class FrmStudentInfo : Form
    {
        public FrmStudentInfo()
        {
            InitializeComponent();
        }
        public FrmStudentInfo(StudentExt studentExt)
            :this()
        {
            this.lblStudentName.Text = studentExt.StudentName;
            this.lblGender.Text = studentExt.Gender;
            this.lblBirthday.Text = studentExt.Birthday.ToString("yyyyMMdd");
            this.lblClass.Text = studentExt.ClassName;
            this.lblStudentIdNo.Text = studentExt.StudentIdNo;
            this.lblCardNo.Text = studentExt.CardNo;
            this.lblPhoneNumber.Text = studentExt.PhoneNumber;
            this.lblAddress.Text = studentExt.StudentAddress;
            this.pbStu.Image = studentExt.StuImage.Length == 0 ? Image.FromFile("default.png"):
                (Image)SerializeObjectToString.DeserializeObject(studentExt.StuImage);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //关闭窗体时将frmStudentInfo值为null
        private void FrmStudentInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmStudentManage.frmStudentInfo = null;
        }
    }
}
