using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace SMDB
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            //显示当前用户信息
            this.lblCurrentUser.Text = Program.admins.AdminName + "]";
            //显示主窗体背景
            this.splitContainer.Panel2.BackgroundImage = Image.FromFile("mainbg.png");
            this.splitContainer.Panel2.BackgroundImageLayout = ImageLayout.Stretch;
            //权限限定

            //显示版本号
            this.lblVersion.Text = "版本号：" + ConfigurationManager.AppSettings["persion"];
        }

        #region 子窗体嵌入
        private void OpenFrm(Form form)
        {
            foreach (Control item in this.splitContainer.Panel2.Controls)
            {
                if (item is Form)
                {
                    Form objForm = (Form)item;
                    objForm.Close();
                }
            }
            form.TopLevel = false;//将窗体设为非顶级控件
            form.FormBorderStyle = FormBorderStyle.None;//去掉窗体边狂
            form.Parent = this.splitContainer.Panel2;//指定窗体的父容器
            form.Dock = DockStyle.Fill;//设置子窗体随着父容器大小自动填充
            form.Show();
        }

        //添加学员
        private void BtnAddStu_Click(object sender, EventArgs e)
        {
            FrmAddStudent frmAddStudent = new FrmAddStudent();
            OpenFrm(frmAddStudent);
        }

        //学员管理
        private void BtnStuManage_Click(object sender, EventArgs e)
        {
            FrmStudentManage frmStudentManage = new FrmStudentManage();
            OpenFrm(frmStudentManage);
        }

        //考勤打卡
        private void BtnCard_Click(object sender, EventArgs e)
        {
            FrmAttendance frmAttendance = new FrmAttendance();
            OpenFrm(frmAttendance);
        }

        //考勤查询
        private void BtnAttendanceQuery_Click(object sender, EventArgs e)
        {
            FrmAttendanceQuery frmAttendanceQuery = new FrmAttendanceQuery();
            OpenFrm(frmAttendanceQuery);
        }

        //成绩浏览
        private void BtnScoreQuery_Click(object sender, EventArgs e)
        {
            FrmScoreQuery frmScoreQuery = new FrmScoreQuery();
            OpenFrm(frmScoreQuery);
        }

        //成绩分析
        private void BtnScoreAnalasys_Click(object sender, EventArgs e)
        {
            FrmScoreManage frmScoreManage = new FrmScoreManage();
            OpenFrm(frmScoreManage);
        }

        //批量导入
        private void BtnImportStu_Click(object sender, EventArgs e)
        {
            FrmImportData frmImportData = new FrmImportData();
            OpenFrm(frmImportData);
        }
        #endregion


        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确认退出?","退出询问",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (dialogResult != DialogResult.OK)
            {
                e.Cancel = true;//告诉窗体事件关闭这个任务取消
         
            }
        }

        public static FrmUserLogin userLogin = null;
        //切换账号
        private void BtnChangeAccount_Click(object sender, EventArgs e)
        {
            if (userLogin == null)
            {
                userLogin = new FrmUserLogin();
                userLogin.Text = "【账号切换】";
            }
            else
            {
                userLogin.Activate();//激活只能在最小化的时候起作用
                userLogin.WindowState = FormWindowState.Normal;
            }
            DialogResult dialogResult = userLogin.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.lblCurrentUser.Text = Program.admins.AdminName + "]";
            }
        }

        //修改密码
        public static FrmModifyPwd frmModifyPwd = null;
        private void BtnModifyPwd_Click(object sender, EventArgs e)
        {
            if (frmModifyPwd == null)
            {
                frmModifyPwd = new FrmModifyPwd();
                frmModifyPwd.ShowDialog();

            }
            else
            {
                frmModifyPwd.Activate();//激活只能在最小化的时候起作用
                frmModifyPwd.WindowState = FormWindowState.Normal;
            }
        }
    }
}
