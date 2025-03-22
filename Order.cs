using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CoffeeShopManagement.BLL;
using CoffeeShopManagement.DTO;
using Menu = CoffeeShopManagement.DTO.Menu;

namespace CoffeeShopManagement
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
            LoadInfo();
            LoadTable();
        }



        private void ChangeForm_Click(object sender, EventArgs e)
        {
            List<Panel> panels = new List<Panel> { pnlHome, pnlAdmin, pnlUser, pnlOrder, pnlCheckOut, pnlHelp };

            UIHelper.ChangePanelColor(sender, panels, UIHelper.userNameFromLogin, this);
        }

        void LoadInfo()
        {
            Account acc = UIHelper.userNameFromLogin;
            lblDisplayName.Text = acc.DisPlayName.ToString();
            pnlOrder.BackColor = Color.FromArgb(255, 255,255);
            lblOrder.ForeColor = Color.Black;

            if (acc.Type == 0)
            {                
                lblTypeName.Text = "Nhân viên";
                lblAdmin.Enabled = false;
                pnlAdmin.Enabled = false;
                pnlAdmin.BackColor = Color.DarkGray;
            }
            else
            {
                lblTypeName.Text = "Admin";
            }
        }

        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<CoffeeShopManagement.DTO.TableFood> tableList = TableBLL.Instance.LoadTableList();

            foreach (CoffeeShopManagement.DTO.TableFood item in tableList)
            {
                Button btn = new Button() { Width = TableBLL.tableWidth, Height = TableBLL.tableHeight };

                btn.Text = item.Name + Environment.NewLine + item.Status;

                btn.Click += Btn_Click;
                btn.Tag = item;

                if (item.Status == "Trống")
                {
                    btn.BackColor = Color.FromArgb(195, 202, 209);
                }
                else
                {
                    btn.BackColor = Color.FromArgb(232, 145, 157);
                }

                btn.Font = new Font("Paytone One", 10, FontStyle.Regular);
                flpTable.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as CoffeeShopManagement.DTO.TableFood).ID;
            UIHelper.tableIDDatMon = tableID;
            lsvBill.Tag = (sender as Button).Tag;

            ShowBill(tableID);
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            float totalPrice = 0;
            List<Menu> listBillInfo = MenuBLL.Instance.GetListMenuByTable(id);
            foreach (Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());

                totalPrice += item.TotalPrice;

                lsvBill.Items.Add(lsvItem);

            }
            CultureInfo culture = new CultureInfo("vi-VN");

            lblTotalPrice.Text = totalPrice.ToString("c", culture);
        }

        private void Order_Load(object sender, EventArgs e)
        {
            UIHelper.GlobalTimer.Tick += UpdateTimeLabel;
        }

        private void UpdateTimeLabel(object sender, EventArgs e)
        {
            lblTime.Text = UIHelper.CurrentTime;
        }

        private void Order_FormClosing(object sender, FormClosingEventArgs e)
        {
            UIHelper.GlobalTimer.Tick -= UpdateTimeLabel;
        }

        private void panel9_MouseDown(object sender, MouseEventArgs e)
        {
            UIHelper.MoveWindow(this, e);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDatMon_Click(object sender, EventArgs e)
        {
            TableFood table = lsvBill.Tag as TableFood;

            if (table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn để đặt thức uống!", "Thông báo");
                return;
            }

            UIHelper.SaveFormPosition(this);
            OrderDrinks f = new OrderDrinks();
            UIHelper.RestoreFormPosition(f);
            f.Show();
            this.Close();
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            TableFood table = lsvBill.Tag as TableFood;
            if (table == null)
            {
                MessageBox.Show("Chọn bàn để thực hiện chức năng này!", "Thông báo");
                return;
            }

            UIHelper.tableIDSwitch = table.ID;
            Switch_Table f = new Switch_Table();
            f.FormClosed += (s, args) => LoadTable();
            f.Show();
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            TableFood table = lsvBill.Tag as TableFood;
            if (table == null)
            {
                MessageBox.Show("Chọn bàn để thực hiện chức năng này!", "Thông báo");
                return;
            }

            UIHelper.tableIDMerge = table.ID;
            Merge_Tables f = new Merge_Tables();
            f.FormClosed += (s, args) => LoadTable();
            f.Show();
        }
    }
}
