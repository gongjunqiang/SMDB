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
            DataGridViewStyle.DgvStyle1(this.dgvScoreList);
        }

        private void Querr(int classId)
        {
            //定义方法的输出参数
            Dictionary<string,string> dic =null;
            List<string> list = null;
           
            try
            {
                List<StudentExt> scoreList = scoreListService.Query1(classId,out dic,out list);

                this.dgvScoreList.DataSource = scoreList;
                this.lblList.Items.AddRange(list.ToArray());
                this.lblAttendCount.Text = dic["stuCount"];
                this.lblCSharpAvg.Text = dic["avgCSharp"];
                this.lblDBAvg.Text = dic["avgDB"];
                this.lblCount.Text = dic["absentCount"];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


        #region 成绩统计
        //下拉框IndexChange事件：动态筛选
        private void CboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            int classId = -1;
            if (this.cboClass.SelectedIndex != -1)
            {
                classId = Convert.ToInt32(this.cboClass.SelectedValue);
            }

            Querr(classId);
    

            #region MyRegion
            //this.dgvScoreList.DataSource = null;
            //this.dgvScoreList.DataSource = scoreListService.QueryScoreList(classId);

            ////显示考试成绩统计信息
            //var item = scoreListService.QueryScoreInfo(classId);
            //this.lblAttendCount.Text = item["stuCount"];
            //this.lblCSharpAvg.Text = item["avgCharp"];
            //this.lblDBAvg.Text = item["avgDB"];
            //this.lblCount.Text = item["absentCount"];
            ////显示缺考人员列表

            //var absentInfo = scoreListService.QueryAbsentStudentList(classId);
            //this.lblList.Items.Clear();
            //if (absentInfo.Count == 0)
            //{
            //    this.lblList.Items.Add("无缺考人员");
            //}
            //else
            //{
            //    //两者取其一即可
            //    this.lblList.Items.AddRange(absentInfo.ToArray());
            //    //this.lblList.DataSource = absentInfo;
            //}
            #endregion
        }

        //统计全校成绩
        private void BtnStat_Click(object sender, EventArgs e)
        {
            this.cboClass.SelectedIndex = -1;
//            this.dgvScoreList.DataSource = null;
//            this.dgvScoreList.DataSource = scoreListService.QueryScoreList(0);
        }

        //行号展示
        private void DgvScoreList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgvScoreList,e);
        }
        #endregion

        /// <summary>
        /// 解析组合属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvScoreList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.Value is Students)
            {
                e.Value = (e.Value as Students).StudentId;
            }
            //if (e.ColumnIndex == 1 && e.Value is Students)
            //{
            //    e.Value = (e.Value as Students).StudentName;
            //}
            //if (e.ColumnIndex == 2 && e.Value is Students)
            //{
            //    e.Value = (e.Value as Students).Gender;
            //}

            //if (e.ColumnIndex == 3 && e.Value is StudentClass)
            //{
            //    e.Value = (e.Value as StudentClass).ClassName;
            //}

            //if (e.ColumnIndex == 4 && e.Value is ScoreList)
            //{
            //    e.Value = (e.Value as ScoreList).CSharp;
            //}

            //if (e.ColumnIndex == 5 && e.Value is ScoreList)
            //{
            //    e.Value = (e.Value as ScoreList).SQLServerDB;
            //}


        }
    }
}
