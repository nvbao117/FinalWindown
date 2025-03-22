using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopManagement.BLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CoffeeShopManagement
{
    public partial class Home : Form
    {
        private CircularPictureBox pbAvatar;
        public Home()
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
            catch (Exception)
            {
                //MessageBox.Show($"Không thể tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LoadInfo()
        {
            pbAvatar = new CircularPictureBox();
            pbAvatar.Size = new Size(105, 97);
            pbAvatar.Location = new Point(192, 12);
            pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            AccountBLL.Instance.LoadAvatarFromDatabase(UIHelper.userNameFromLogin.UserName, pbAvatar);
            pnlHeader.Controls.Add(pbAvatar);

            Account acc = UIHelper.userNameFromLogin;
            pnlHome.BackColor = Color.FromArgb(255, 255, 255);
            lblHome.ForeColor = Color.Black;
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

            lblDisplayName.Text = acc.DisPlayName;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            UIHelper.MoveWindow(this, e);
        }

        private void Form02_Load(object sender, EventArgs e)
        {
            lblNumOfNhanVien.Text = AccountBLL.Instance.GetAccountCount().ToString();
            lblNumOfBan.Text = TableBLL.Instance.GetTableCount().ToString();
            lblNumOfThucUong.Text = FoodBLL.Instance.GetFoodCount().ToString();
            lblNumOfPhanLoai.Text = CategoryBLL.Instance.GetCategoryCount().ToString();
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
            UIHelper.SaveFormPosition(this);
            this.Hide();
            LoginForm loginForm = new LoginForm();
            UIHelper.RestoreFormPosition(loginForm);
            loginForm.Show();
        }

        private void lblAcountInfo_Click(object sender, EventArgs e)
        {
            Account_Information f = new Account_Information(UIHelper.userNameFromLogin, lblDisplayName);
            f.ShowDialog();
        }

        private void ChangeForm_Click(object sender, EventArgs e)
        {
            List<Panel> panels = new List<Panel> { pnlHome, pnlAdmin, pnlUser, pnlOrder, pnlCheckOut, pnlHelp };

            UIHelper.ChangePanelColor(sender, panels, UIHelper.userNameFromLogin, this);
        }

        private event EventHandler updateAccount;
        public event EventHandler UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
    }
}
