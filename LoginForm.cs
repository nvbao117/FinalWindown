using CoffeeShopManagement.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopManagement.DTO;
using CoffeeShopManagement.BLL; 

namespace CoffeeShopManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            UIHelper.RestoreFormPosition(this);
        }

        private void lblHiden_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

            
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassword.Text;

            if (AccountBLL.Instance.Login(userName, passWord))
            {
                Account loginAccount = AccountBLL.Instance.GetAccountByUserName(userName); 
                UIHelper.userNameFromLogin = loginAccount;

                UIHelper.SaveFormPosition(this);
                this.Hide();
                Home homeForm = new Home();
                UIHelper.RestoreFormPosition(homeForm);
                homeForm.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo");
            }
        }

        private void lblFogetPassword_Click(object sender, EventArgs e)
        {
            ForgetPassword f = new ForgetPassword();
            f.ShowDialog();
        }

        private void txbUserName_Click(object sender, EventArgs e)
        {
            if (txbPassword.Text == "")
            {
                txbPassword.Text = "Mật khẩu";
            }
            txbUserName.Clear();
        }

        private void txbPassword_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text == "")
            {
                txbUserName.Text = "Tên tài khoản";
            }
            txbPassword.Clear();
        }

        private void pnlLogin_MouseDown(object sender, MouseEventArgs e)
        {
            UIHelper.MoveWindow(this, e);
        }

    }
}
