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
    public partial class FrmImportData : Form
    {
        private List<StudentExt> studentList = null;
        private ImportDataFromExcel fromExcel = new ImportDataFromExcel();
        private StudentService studentService =new StudentService(); 
        public FrmImportData()
        {
            InitializeComponent();
            this.dgvStudentList.AutoGenerateColumns = false;
            DataGridViewStyle.DgvStyle1(this.dgvStudentList);
        }

        //从excel导入数据
        private void BtnChoseExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult dialogResult = openFile.ShowDialog();
            string filePath = string.Empty;
            if (dialogResult == DialogResult.OK)
            {
                filePath = openFile.FileName;//获取Excel路径
            }
            try
            {
                this.studentList = fromExcel.GetStudentByExcel(filePath);
                this.dgvStudentList.DataSource = null;
                this.dgvStudentList.DataSource = studentList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"提示信息");
            }
        }

        //保存到数据库
        private void BtnSaveToDB_Click(object sender, EventArgs e)
        {
            //【1】判断是否有数据
            if (this.studentList.Count == 0)
            {
                MessageBox.Show("没有需要保存的学员！", "提示信息");
                return;
            }
            //【2】遍历集合：方法一：遍历一次保存一次；方法二：遍历生成SQL语句，通过事务提交
            foreach (var student in this.studentList)
            {
                if (studentService.IsIdNoExisted(student.StudentIdNo))
                {
                    MessageBox.Show("身份证号已经被其他学员使用!", "提示信息");
                    return;
                }

                if (studentService.IsCradNoExisted(student.CardNo))
                {
                    MessageBox.Show("考勤卡号已经被其他学员使用!", "提示信息");
                    return;
                }
            }

            try
            {
                var result = studentService.Import(studentList);
                if (result)
                {
                    MessageBox.Show("考勤卡号已经被其他学员使用!", "提示信息");
                    this.studentList.Clear();
                    this.dgvStudentList.DataSource = null;
                }
                else
                {
                    MessageBox.Show("数据导入失败!", "提示信息");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "提示信息");
            }

        }

        private void DgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgvStudentList,e);
        }
    }
}
