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
    public partial class FrmUserLogin : Form
    {
        private AdminsService adminsService = new AdminsService();
        public FrmUserLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var adminName = this.txtAdminName.BeginValiateIsEmpty();
            var adminPwd = this.txtAdminPwd.BeginValiateIsEmpty();
            var item = adminName * adminPwd;
            if (item == 0)
            {
                return;
            }
            Admins admins = new Admins
            {
                AdminName = this.txtAdminName.Text,
                LoginPwd = this.txtAdminPwd.Text
            };
            try
            {
                Program.admins = adminsService.UserLogin(admins);
                if (Program.admins != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误，登录失败!", "提示信息");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作异常");
            }

        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
