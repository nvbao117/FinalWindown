using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing;

namespace CoffeeShopManagement.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        private AccountDAO() { }

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        // Lấy danh sách loại tài khoản
        public List<int> GetListAccountType()
        {
            List<int> list = new List<int>();
            try
            {
                string query = "SELECT DISTINCT type FROM Account";
                DataTable data = DataProvider.Instance.ExecuteQuery(query);

                foreach (DataRow row in data.Rows)
                {
                    int accountType = Convert.ToInt32(row["type"]);
                    list.Add(accountType);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetListAccountType: {ex.Message}");
            }
            return list;
        }

        // Tìm account bằng tên hiển thị
        public List<Account> SearchAccountByDisplayName(string displayName)
        {
            List<Account> list = new List<Account>();
            try
            {
                string query = string.Format("SELECT * FROM Account WHERE [dbo].[fuConvertToUnsign1] (displayName) LIKE N'%' + [dbo].[fuConvertToUnsign1](N'{0}') + '%'", displayName);
                DataTable data = DataProvider.Instance.ExecuteQuery(query);

                foreach (DataRow item in data.Rows)
                {
                    Account acc = new Account(item);
                    list.Add(acc);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in SearchAccountByDisplayName: {ex.Message}");
            }
            return list;
        }

        // Kiểm tra tài khoản, mật khẩu nhập vào
        public bool Login(string userName, string passWord)
        {
            try
            {
                string query = "USP_Login @userName , @passWord";
                DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });

                return result.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Login: {ex.Message}");
                return false;
            }
        }

        // Hàm Update Account dùng cho - Thông tin tài khoản
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            try
            {
                string query = "EXEC USP_UpdateAccount @userName , @displayName , @password , @newPassword ";
                int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { userName, displayName, pass, newPass });

                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in UpdateAccount: {ex.Message}");
                return false;
            }
        }

        // Tìm account bằng userName
        public bool CheckAccountExists(string userName)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Account WHERE UserName = @userName";
                int result = (int)DataProvider.Instance.ExecuteScalar(query, new object[] { userName });
                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in CheckAccountExists: {ex.Message}");
                return false;
            }
        }

        // Lấy danh sách tài khoản 
        public DataTable GetListAccount()
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("SELECT UserName, DisplayName, Password, Type FROM Account");
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetListAccount: {ex.Message}");
                return null;
            }
        }

        public int GetAccountCount()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM Account WHERE type = 0");
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetAccountCount: {ex.Message}");
                return 0;
            }
        }

        // Lấy ra tài khoản từ UserName 
        public Account GetAccountByUserName(string userName)
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM ACCOUNT WHERE userName = '" + userName + "'");

                foreach (DataRow item in data.Rows)
                {
                    return new Account(item);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetAccountByUserName: {ex.Message}");
            }
            return null;
        }

        // Các hàm thêm, sửa, xóa Account dùng cho - Tài khoản
        public bool InsertAccount(string userName, string displayName, string password, int type)
        {
            try
            {
                string query = string.Format("INSERT Account (userName, displayName, type, passWord) VALUES (N'{0}', N'{1}', {2}, N'{3}')", userName, displayName, type, password);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in InsertAccount: {ex.Message}");
                return false;
            }
        }

        // Chỉnh sửa tên hiển thị, đổi mật khẩu tài khoản
        public bool UpdateAccount(string userName, string displayName, int type)
        {
            try
            {
                string query = string.Format("UPDATE Account SET displayName = N'{1}', type = {2} WHERE UserName = N'{0}' ", userName, displayName, type);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in UpdateAccount: {ex.Message}");
                return false;
            }
        }

        // Xóa tài khoản
        public bool DeleteAccount(string name)
        {
            try
            {
                string query = string.Format("DELETE Account WHERE UserName = N'{0}'", name);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in DeleteAccount: {ex.Message}");
                return false;
            }
        }

        // Reset passWord về 1
        public bool ResetPassword(string name, string displayName)
        {
            try
            {
                string query = string.Format("Update Account SET passWord = N'2024' WHERE userName = N'{0}' AND displayName = N'{1}'", name, displayName);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in ResetPassword: {ex.Message}");
                return false;
            }
        }

        // Đổi avatar
        public bool UpdateAvatar(string userName, string avatarPath)
        {
            try
            {
                string query = "UPDATE Account SET Avatar = @Avatar WHERE UserName = @UserName";
                int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { avatarPath, userName });

                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in UpdateAvatar: {ex.Message}");
                return false;
            }
        }

        // Lấy avatarPath từ database
        public bool LoadAvatarFromDatabase(string userName, PictureBox pbAvatar)
        {
            try
            {
                string query = "SELECT Avatar FROM [dbo].[Account] WHERE UserName = @UserName";

                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName });

                if (data.Rows.Count > 0)
                {
                    string avatarPath = data.Rows[0]["Avatar"].ToString();

                    if (!string.IsNullOrEmpty(avatarPath))
                    {
                        string fullPath = Path.Combine(Application.StartupPath, avatarPath);

                        if (File.Exists(fullPath))
                        {
                            pbAvatar.Image = Image.FromFile(fullPath);
                            return true;
                        }
                        else
                        {
                            //MessageBox.Show("Không tìm thấy file ảnh!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản không có ảnh đại diện!");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in LoadAvatarFromDatabase: {ex.Message}");
            }
            return false;
        }
    }
}
