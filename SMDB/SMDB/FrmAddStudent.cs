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
    }
}
