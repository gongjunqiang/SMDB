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
    public partial class FrmModifyPwd : Form
    {
        private AdminsService adminsService = new AdminsService();
        public FrmModifyPwd()
        {
            InitializeComponent();
        }

        private void FrmModifyPwd_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.frmModifyPwd = null;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //确认修改密码
        private void BtnModify_Click(object sender, EventArgs e)
        {
            #region 数据验证
            int oldPwd = this.txtOldPwd.BeginValiateIsEmpty();
            int newPwd = this.txtNewPwd.BeginValiateIsEmpty();
            int confirmPwd = this.txtNewPwdConfirm.BeginValiateIsEmpty();
            if (oldPwd * newPwd * confirmPwd == 0)
            {
                return;
            }

            var oldPwdStr = this.txtOldPwd.Text.Trim();
            if (oldPwdStr != Program.admins.LoginPwd)
            {
                MessageBox.Show("原密码错误！","提示信息");
                this.txtOldPwd.Focus();
                this.txtOldPwd.SelectAll();
                return;
            }

            if (this.txtNewPwd.Text.Trim().Length < 6)
            {
                MessageBox.Show("新密码不能小于6位！", "提示信息");
                this.txtNewPwd.Focus();
                this.txtNewPwd.SelectAll();
                return;
            }

            if (this.txtNewPwd.Text.Trim() != this.txtNewPwdConfirm.Text.Trim())
            {
                MessageBox.Show("两次输入密码不一致！", "提示信息");
                this.txtNewPwd.Focus();
                this.txtNewPwd.SelectAll();
                return;
            }
            #endregion
            Admins admins = Program.admins;
            admins.LoginPwd = this.txtNewPwd.Text;
            try
            {
                var result = adminsService.UpdatePwd(admins);
                if (result == 1)
                {
                    Program.admins.LoginPwd = admins.LoginPwd;
                    MessageBox.Show("密码修改成功！", "提示信息");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("密码修改异常，异常信息"+ ex.Message);
            }
        


        }
    }
}
