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

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
