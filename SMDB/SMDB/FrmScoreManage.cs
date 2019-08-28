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
    public partial class FrmScoreManage : Form
    {
        private StudentClassService studentClassService = new StudentClassService();
        private ScoreListService scoreListService = new ScoreListService();
        public FrmScoreManage()
        {
            InitializeComponent();
            //班级下拉列表绑定
            this.cboClass.DataSource = studentClassService.GetAllClasses().Tables[0];
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember = "ClassId";
            this.cboClass.SelectedIndex = -1;

            //将下拉框的事件关联
            this.cboClass.SelectedIndexChanged += new System.EventHandler(this.CboClass_SelectedIndexChanged);
            this.dgvScoreList.AutoGenerateColumns = false;
        }

        #region 成绩统计
        //下拉框IndexChange事件：动态筛选
        private void CboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.cboClass.SelectedIndex == -1)
            //{
            //    MessageBox.Show("请选择班级！", "提示信息");
            //    return;
            //}
            this.dgvScoreList.DataSource = null;
            this.dgvScoreList.DataSource = scoreListService.QueryScoreList(Convert.ToInt32(this.cboClass.SelectedValue));
            DataGridViewStyle.DgvStyle1(this.dgvScoreList);
        }

        //统计全校成绩
        private void BtnStat_Click(object sender, EventArgs e)
        {
            this.cboClass.SelectedIndex = -1;
            this.dgvScoreList.DataSource = null;
            this.dgvScoreList.DataSource = scoreListService.QueryScoreList(0);
        }

        //行号展示
        private void DgvScoreList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgvScoreList,e);
        }
        #endregion

    }
}
