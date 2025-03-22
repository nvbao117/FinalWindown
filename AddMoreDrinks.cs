using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using CoffeeShopManagement.BLL;
using System;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public partial class AddMoreDrinks : Form
    {
        private Food F;
        private DataGridView dtgvDatMon;
        public AddMoreDrinks(Food food, DataGridView dtgv)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            F = food;
            this.dtgvDatMon = dtgv;
            LoadInfo();
        }

        void LoadInfo()
        {
            lblTenMon.Text = F.Name;
            lblDonGia.Text = F.Price.ToString("N0", System.Globalization.CultureInfo.InvariantCulture).Replace(",", " ");
            nmSoLuong.Value = 2;
            lblThanhTien.Text = F.Price.ToString("N0", System.Globalization.CultureInfo.InvariantCulture).Replace(",", " ");
        }

        private void nmSoLuong_ValueChanged(object sender, EventArgs e)
        {
            int soLuong = (int)nmSoLuong.Value;
            float donGia = F.Price;
            lblThanhTien.Text = (soLuong * donGia).ToString("N0", System.Globalization.CultureInfo.InvariantCulture).Replace(",", " ");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string tenMon = F.Name;
            float donGia = F.Price;
            int soLuong = (int)nmSoLuong.Value;

            bool isExists = false;

            foreach (DataGridViewRow row in dtgvDatMon.Rows)
            {
                if (row.Cells["TenMon"].Value.ToString() == tenMon)
                {
                    int currentSoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    currentSoLuong += soLuong;
                    row.Cells["SoLuong"].Value = currentSoLuong;
                    row.Cells["ThanhTien"].Value = currentSoLuong * donGia;
                    isExists = true;
                    break;
                }
            }

            if (!isExists)
            {
                dtgvDatMon.Rows.Add(tenMon, soLuong, donGia, soLuong * donGia);
            }

            TableFood table = TableBLL.Instance.GetTableByID(UIHelper.tableIDDatMon);
            string foodName = F.Name;

            int idBill = BillBLL.Instance.GetUnCheckBillIDByTableID(table.ID);
            int foodID = FoodBLL.Instance.GetFoodByName(foodName).ID;

            int count = 0;
            foreach (DataGridViewRow row in dtgvDatMon.Rows)
            {
                if (row.Cells["TenMon"].Value.ToString() == foodName)
                {
                    count = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    break;
                }
            }

            bool foodExistsInBill = BillInfoBLL.Instance.IsFoodExistsInBill(idBill, foodID);

            if (foodExistsInBill)
            {
                BillInfoBLL.Instance.UpdateFoodCountInBill(idBill, foodID, count);
            }
            else
            {
                if (idBill == -1)
                {
                    BillBLL.Instance.InsertBill(table.ID);
                    BillInfoBLL.Instance.InsertBillInfo(BillBLL.Instance.GetMaxIDBill(), foodID, count);
                }
                else
                {
                    BillInfoBLL.Instance.InsertBillInfo(idBill, foodID, count);
                }
            }

            this.Close();
        }
    }
}
