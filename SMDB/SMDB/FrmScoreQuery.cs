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
    public partial class FrmScoreQuery : Form
    {
        private StudentClassService studentClassService = new StudentClassService();
        private ScoreListService scoreListService = new ScoreListService();
        private DataSet da = null;//用来保存查询结果的数据集

        public FrmScoreQuery()
        {
            InitializeComponent();
            //基于DataTable绑定下拉框
            this.cboClass.DataSource = studentClassService.GetAllClasses().Tables[0];
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember = "ClassId";
            this.cboClass.SelectedIndex = -1;
            //成绩列表数据绑定
            da = scoreListService.GetScoreList();
            this.dgvScoreList.AutoGenerateColumns = false;
            this.dgvScoreList.DataSource = null;
            this.dgvScoreList.DataSource = da.Tables[0];
            DataGridViewStyle.DgvStyle3(dgvScoreList);

        }

        //显示行号
        private void DgvScoreList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(dgvScoreList,e);
        }

        //成绩快速浏览：txt=>change事件
        private void TxtScore_TextChanged(object sender, EventArgs e)
        {
            if (this.dgvScoreList.RowCount == 0)
            {
                return;
            }

            if (this.txtScore.Text.Trim().Length == 0)
            {
                return;
            }

            if (!DataValidate.IsInteger(this.txtScore.Text.Trim()))
            {
                this.txtScore.Text = "";
                this.txtScore.SelectAll();
                MessageBox.Show("成绩只能为整数！", "提示信息");
                return;
            }

            this.cboClass.SelectedIndex = -1;
            var item = this.txtScore.Text.Trim();
            int score = Convert.ToInt32(item);
            if (score > 100 || score < 0)
            {
                this.txtScore.Text = "";
                this.txtScore.SelectAll();
                MessageBox.Show("成绩只能在0-100之间！", "提示信息");
                return;
            }
            this.da.Tables[0].DefaultView.RowFilter = "CSharp>" + this.txtScore.Text.Trim();
        }

        //显示当前全部成绩
        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            this.da.Tables[0].DefaultView.RowFilter = "ClassName like '%%'";
            this.txtScore.Text = "";
        }

        //下拉列表change事件
        private void CboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (da == null) return;
            //this.txtScore.Text = "";
            var className = this.cboClass.Text;
            this.da.Tables[0].DefaultView.RowFilter = $"ClassName='{className}'";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (dgvScoreList.RowCount == 0)
            {
                MessageBox.Show("没有需要打印的成绩表！", "提示信息");
                return;
            }

            try
            {
                DataExport.Export(this.dgvScoreList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示信息");
            }
        }
    }
}
