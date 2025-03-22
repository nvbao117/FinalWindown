using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using CoffeeShopManagement.BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public partial class Account_Information : Form
    {
        public static Account userName;
        private Label lblDisplayName;
        public string SelectedImagePath { get; private set; }
        public Account_Information(Account userNameLogin, Label displayNameLabel)
        {
            InitializeComponent();
            userName = userNameLogin;
            lblDisplayName = displayNameLabel;
            LoadInfo();
            LoadAccountInformation();
        }

        // Load dữ liệu lên form
        void LoadInfo()
        {
            pbAvatar = new CircularPictureBox();
            pbAvatar.Size = new Size(110, 100);
            pbAvatar.Location = new Point(140, 8);
            pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            AccountBLL.Instance.LoadAvatarFromDatabase(UIHelper.userNameFromLogin.UserName, pbAvatar);
            this.Controls.Add(pbAvatar);
        }

        // Thoát form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Cập nhật thông cá nhân
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        // Hàm cập nhật dữ liệu thay đổi vào database
        void UpdateAccountInfo()
        {
            string displayName = txbDisplayName.Text;
            string password = txbPassword.Text;
            string newpass = txbNewPassword.Text;
            string reenterPass = txbRePassword.Text;
            string userName = txbUserName.Text;

            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Mật khẩu mới không trùng khớp!");
            }
            else
            {
                if (password == reenterPass && password == newpass && password != "")
                {
                    MessageBox.Show("Mật khẩu mới trùng với mật khẩu cũ!");
                    return;
                }
                bool result = AccountBLL.Instance.UpdateAccount(userName, displayName, password, newpass);
                if (result)
                {
                    UIHelper.userNameFromLogin.DisPlayName = displayName;
                    lblDisplayName.Text = displayName;
                    MessageBox.Show("Cập nhật thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu!");
                }
            }
        }

        // Load dữ liệu của tài khoản lên form
        private void Account_Information_Load(object sender, EventArgs e)
        {
            Account acc = UIHelper.userNameFromLogin;
            txbUserName.Text = acc.UserName;
            txbDisplayName.Text = acc.DisPlayName;            
        }

        // Đổi avatar và lưu AvatarPath vào cơ sở dữ liệu
        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    string directoryPath = Path.Combine(Application.StartupPath, "Resources");
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string fileName = Path.GetFileName(selectedFilePath);
                    string targetPath = Path.Combine(directoryPath, fileName);

                    try
                    {
                        if (pbAvatar.Image != null)
                        {
                            pbAvatar.Image.Dispose();
                            pbAvatar.Image = null;
                        }

                        using (FileStream sourceStream = new FileStream(selectedFilePath, FileMode.Open, FileAccess.Read))
                        {
                            using (FileStream destStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                            {
                                sourceStream.CopyTo(destStream);
                            }
                        }

                        using (FileStream fs = new FileStream(targetPath, FileMode.Open, FileAccess.Read))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                fs.CopyTo(ms);
                                pbAvatar.Image = Image.FromStream(ms);
                            }
                        }

                        string avatarPath = Path.Combine("Resources", fileName);
                        bool updateSuccess = AccountBLL.Instance.UpdateAvatar(userName.UserName, avatarPath);

                        if (updateSuccess)
                        {
                            UIHelper.userNameFromLogin.UpdateAvatar(targetPath);
                            this.Close();
                            MessageBox.Show("Cập nhật avatar thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật avatar thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Lỗi truy cập tệp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Lấy tài khoản từ lớp UIHelper
        private void LoadAccountInformation()
        {
            string userName = UIHelper.userNameFromLogin.UserName;

            bool success = AccountBLL.Instance.LoadAvatarFromDatabase(userName, pbAvatar);

            if (!success)
            {
                pbAvatar.Image = Properties.Resources.DefaultAvatar;
            }
        }
    }
}
