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
        public FrmImportData()
        {
            InitializeComponent();
            this.dgvStudentList.AutoGenerateColumns = false;

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

        }
    }
}
