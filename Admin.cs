using CoffeeShopManagement.BLL;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public partial class Admin : Form
    {
        private CircularPictureBox pbAvatar;
        public Admin()
        {
            InitializeComponent();
            UIHelper.userNameFromLogin.AvatarChanged += UpdateAvatar;
            LoadInfo();
        }

        private void UpdateAvatar(string obj)
        {
            try
            {
                if (pbAvatar.Image != null)
                {
                    pbAvatar.Image.Dispose();
                }

                pbAvatar.Image = Image.FromFile(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeForm_Click(object sender, EventArgs e)
        {
            List<Panel> panels = new List<Panel> { pnlHome, pnlAdmin, pnlUser, pnlOrder, pnlCheckOut, pnlHelp };

            UIHelper.ChangePanelColor(sender, panels, UIHelper.userNameFromLogin, this);
        }

        void LoadInfo()
        {
            pbAvatar = new CircularPictureBox();
            pbAvatar.Size = new Size(105, 97);
            pbAvatar.Location = new Point(192, 12);
            pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            AccountBLL.Instance.LoadAvatarFromDatabase(UIHelper.userNameFromLogin.UserName, pbAvatar);
            pnlHeader.Controls.Add(pbAvatar);
            pnlAdmin.BackColor = Color.FromArgb(255, 255, 255); 
            lblAdmin.ForeColor = Color.Black; 

            Account acc = UIHelper.userNameFromLogin;

            lblDisplayName.Text = acc.DisPlayName;
            if (acc.Type == 0)
            {
                lblAdminName.Text = "Nhân viên";
                lblAdmin.Enabled = false;
                pnlAdmin.Enabled = false;
                pnlAdmin.BackColor = Color.DarkGray;
            }
            else
            {
                lblAdminName.Text = "Admin";
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            UIHelper.MoveWindow(this, e);
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

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void lblAcountInfo_Click(object sender, EventArgs e)
        {
            Account_Information f = new Account_Information(UIHelper.userNameFromLogin, lblDisplayName);
            f.ShowDialog();
        }
    }
}
