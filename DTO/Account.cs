using System;
using System.Data;

namespace CoffeeShopManagement.DTO
{
    public class Account
    {
        private string userName;
        private string password;
        private string disPlayName;
        private int type;
        private string avatar;

        public Account(string userName, string displayName, int type, string password = null, string avatar = null)
        {
            this.UserName = userName;
            this.DisPlayName = displayName;
            this.Type = type;
            this.Password = password;
            this.avatar = avatar;
        }

        public Account(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.DisPlayName = row["displayName"].ToString();
            this.Type = (int)row["type"];
            this.Password = row["password"].ToString();
            this.Avatar = row["avatar"].ToString();
        }

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string DisPlayName { get => disPlayName; set => disPlayName = value; }
        public int Type { get => type; set => type = value; }
        public string Avatar { get => avatar; set => avatar = value; }

        public event Action<string> AvatarChanged;

        public void UpdateAvatar(string newAvatarPath)
        {
            Avatar = newAvatarPath;
            AvatarChanged?.Invoke(newAvatarPath);
        }
    }
}
