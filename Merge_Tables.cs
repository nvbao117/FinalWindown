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
    public partial class Merge_Tables : Form
    {
        public Merge_Tables()
        {
            InitializeComponent();
            LoadInfo();
        }

        void LoadInfo()
        {
            this.MaximizeBox = false;
            List<TableFood> list = TableBLL.Instance.LoadTableList();
            cbChonBan.DataSource = list;
            cbChonBan.DisplayMember = "Name";
            TableFood table = TableBLL.Instance.GetTableByID(UIHelper.tableIDMerge);
            lblBan1st.Text = table.Name.ToString();
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            int id1 = UIHelper.tableIDMerge;

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
                    "Bạn có thật sự muốn gộp bàn {0} với bàn {1}?",
                    TableBLL.Instance.GetTableByID(id1).Name,
                    table2nd.Name),
                "Thông báo",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TableBLL.Instance.MergeTable(id1, id2);

                this.Close();
            }
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
    }
}
