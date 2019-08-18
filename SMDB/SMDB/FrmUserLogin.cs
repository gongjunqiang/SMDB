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
            //【1】数据验证
            var adminName = this.txtAdminName.BeginValiateIsEmpty();
            var adminPwd = this.txtAdminPwd.BeginValiateIsEmpty();
            var item = adminName * adminPwd;
            if (item == 0)
            {
                return;
            }
            //登录账号和密码不能带有危险字符

            //【2】对象封装
            Admins admins = new Admins
            {
                AdminName = this.txtAdminName.Text,
                LoginPwd = this.txtAdminPwd.Text
            };
            
            try
            {
                //【3】和后台交互
                Program.admins = adminsService.UserLogin(admins);
                //【4】处理交互结果
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

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #region 改善用户体验
        private void TxtAdminName_KeyDown(object sender, KeyEventArgs e)
        {

            var adminName = this.txtAdminName.BeginValiateIsEmpty();
            if (adminName == 0)
            {
                return;
            }

            //两种方法都可以
            //if (e.KeyValue == 13)
            //{
            //    this.txtAdminPwd.Focus();
            //}
            if (e.KeyCode == Keys.Enter)
            {
                this.txtAdminPwd.Focus();
                this.txtAdminPwd.SelectAll();
            }
        }

        private void TxtAdminPwd_KeyDown(object sender, KeyEventArgs e)
        {
            var adminPwd = this.txtAdminPwd.BeginValiateIsEmpty();
            if (adminPwd == 0)
            {
                return;
            }

            BtnLogin_Click(null, null);
        }
        #endregion
        //键盘事件

    }
}
