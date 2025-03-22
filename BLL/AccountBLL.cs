using CoffeeShopManagement.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CoffeeShopManagement.DTO;
using System.Windows.Forms;

namespace CoffeeShopManagement.BLL
{
    public class AccountBLL
    {
        private static AccountBLL instance;

        private AccountBLL() { }

        public static AccountBLL Instance
        {
            get { if (instance == null) instance = new AccountBLL(); return instance; }
            private set { instance = value; }
        }

        public bool Login(string usernName, string password)
        {
            try
            {
                return AccountDAO.Instance.Login(usernName, password);
            }
            catch (Exception ex)
            {
                // Log exception
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public Account GetAccountByUserName(string userName)
        {
            try
            {
                return AccountDAO.Instance.GetAccountByUserName(userName);
            }
            catch (Exception ex)
            {
                // Log exception
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<int> GetListAccountType()
        {
            try
            {
                return AccountDAO.Instance.GetListAccountType();
            }
            catch (Exception ex)
            {
                // Log exception
                MessageBox.Show(ex.Message);
                return new List<int>();
            }
        }

        public bool CheckAccountExists(string userName)
        {
            try
            {
                return AccountDAO.Instance.CheckAccountExists(userName);
            }
            catch (Exception ex)
            {
                // Log exception
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool InsertAccount(string userName, string displayName, string password, int type)
        {
            try
            {
                return AccountDAO.Instance.InsertAccount(userName, displayName, password, type);
            }
            catch (Exception ex)
            {
                // Log exception
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            try
            {
                return AccountDAO.Instance.UpdateAccount(userName, displayName, pass, newPass);
            }
            catch (Exception ex)
            {
                // Log exception
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool UpdateAccount(string userName, string displayName, int type)
        {
            try
            {
                return AccountDAO.Instance.UpdateAccount(userName, displayName, type);
            }
            catch (Exception ex)
            {
                // Log exception
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool DeleteAccount(string name)
        {
            try
            {
                return AccountDAO.Instance.DeleteAccount(name);
            }
            catch (Exception ex)
            {
                // Log exception
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool LoadAvatarFromDatabase(string userName, PictureBox pbAvatar)
        {
            try
            {
                return AccountDAO.Instance.LoadAvatarFromDatabase(userName, pbAvatar);
            }
            catch (Exception ex)
            {
                // Log exception
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool UpdateAvatar(string userName, string avatarPath)
        {
            try
            {
                return AccountDAO.Instance.UpdateAvatar(userName, avatarPath);
            }
            catch (Exception ex)
            {
                // Log exception
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public DataTable GetListAccount()
        {
            try
            {
                return AccountDAO.Instance.GetListAccount();
            }
            catch (Exception ex)
            {
                // Log exception
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<Account> SearchAccountByDisplayName(string displayName)
        {
            try
            {
                return AccountDAO.Instance.SearchAccountByDisplayName(displayName);
            }
            catch (Exception ex)
            {
                // Log exception
                MessageBox.Show(ex.Message);
                return new List<Account>();
            }
        }

        public bool ResetPassword(string name, string displayName)
        {
            try
            {
                return AccountDAO.Instance.ResetPassword(name, displayName);
            }
            catch (Exception ex)
            {
                // Log exception
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public int GetAccountCount()
        {
            try
            {
                return AccountDAO.Instance.GetAccountCount();
            }
            catch (Exception ex)
            {
                // Log exception
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
}
