using CoffeeShopManagement.DTO;
using CoffeeShopManagement.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace CoffeeShopManagement
{
    public partial class Switch_Table : Form
    {
        public Switch_Table()
        {
            InitializeComponent();
            LoadInfo();
        }

        void LoadInfo()
        {
            this.MaximizeBox = false;
            LoadListTableIntoComboBox();
        }

        void LoadListTableIntoComboBox()
        {
            List<TableFood> list = TableBLL.Instance.LoadTableList();
            cbChonBan.DataSource = list;
            cbChonBan.DisplayMember = "Name";
            TableFood table = TableBLL.Instance.GetTableByID(UIHelper.tableIDSwitch);
            lblBan1st.Text = table.Name.ToString();
        }

        private void cbChonBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChonBan.SelectedItem is TableFood selectedTable)
            {
                lblBan2nd.Text = selectedTable.Name;
            }
            else
            {
                lblBan2nd.Text = "Chưa chọn bàn";
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            int id1 = UIHelper.tableIDSwitch;

            string table2ndName = cbChonBan.Text;
            TableFood table2nd = TableBLL.Instance.GetTableByName(table2ndName);

            if (table2nd == null)
            {
                MessageBox.Show("Bàn không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id2 = table2nd.ID;

            if (id1 == id2)
            {
                MessageBox.Show("Vui lòng chọn 2 bàn khác nhau để thực hiện chức năng này!", "Thông báo");
                return;
            }

            if (MessageBox.Show(
                string.Format(
                    "Bạn có thật sự muốn Chuyển bàn {0} qua bàn {1}",
                    TableBLL.Instance.GetTableByID(UIHelper.tableIDSwitch).Name,
                    table2nd.Name),
                "Thông báo",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TableBLL.Instance.SwitchTable(id1, id2);
                this.Close();
            }
        }
    }
}
