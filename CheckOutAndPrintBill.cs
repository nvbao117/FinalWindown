using CoffeeShopManagement.BLL;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Menu = CoffeeShopManagement.DTO.Menu;
using System.Drawing.Printing;

namespace CoffeeShopManagement
{
    public partial class CheckOutAndPrintBill : Form
    {
        private int tableID = UIHelper.tableIDCheckOut;
        public CheckOutAndPrintBill()
        {
            InitializeComponent();
            UIHelper.RestoreFormPosition(this);
            LoadInfo();
        }

        void LoadInfo()
        {
            pnlCheckOut.BackColor = Color.FromArgb(255, 255, 255);
            lblCheckOut.ForeColor = Color.Black; 
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
            lblDisplayName.Text = acc.DisPlayName;
            ShowBillCheckOut();
            PrintBillIntoRichTextBox();
        }

        void ShowBillCheckOut()
        {
            lsvBill.Items.Clear();
            float totalPrice = 0;
            List<Menu> listBillInfo = MenuBLL.Instance.GetListMenuByTable(tableID);
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

        private void ChangeForm_Click(object sender, EventArgs e)
        {
            List<Panel> panels = new List<Panel> { pnlHome, pnlAdmin, pnlUser, pnlOrder, pnlCheckOut, pnlHelp };

            UIHelper.ChangePanelColor(sender, panels, UIHelper.userNameFromLogin, this);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            TableFood table = TableBLL.Instance.GetTableByID(tableID);

            if (lblTotalPrice.Text == "0,00 ₫")
                return;

            if (table == null)
                return;

            int iddBill = BillBLL.Instance.GetUnCheckBillIDByTableID(table.ID);
            int discount = (int)nmGiamGia.Value;
            string priceText = lblTotalPrice.Text;
            string cleanedText = priceText.Replace(" ₫", "").Replace(".", "").Replace(",", ".");
            double totalPrice = Convert.ToDouble(cleanedText);
            double discountPrice = totalPrice * discount / 100;
            bool boolDiscount = (discount != 0) ? true : false;
            double finalTotalPrice = (totalPrice - discountPrice);

            if (iddBill != -1)
            {
                if (boolDiscount)
                {
                    if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn: " + table.Name + "\nTổng tiền cần trả: {0} - {1} = {2}", totalPrice, discountPrice, finalTotalPrice + ",00 đ"),
                                    "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        BillBLL.Instance.CheckOut(iddBill, discount, (float)finalTotalPrice);
                        //ShowBillCheckOut();
                        var result =  MessageBox.Show("Thanh toán thành công!\nBạn có muốn xuất HÓA ĐƠN không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            ExportBill();
                        }

                        UIHelper.SaveFormPosition(this);
                        Form f = new CheckOut();
                        UIHelper.RestoreFormPosition(f);
                        f.Show();
                        this.Close();
                    }
                }
                else if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn: " + table.Name + "\nTổng tiền cần trả: {0}", totalPrice + ",00 đ"),
                                    "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillBLL.Instance.CheckOut(iddBill, discount, (float)finalTotalPrice);
                    //ShowBillCheckOut();
                    var result = MessageBox.Show("Thanh toán thành công!\nBạn có muốn xuất HÓA ĐƠN không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        ExportBill();
                    }

                    UIHelper.SaveFormPosition(this);
                    Form f = new CheckOut();
                    UIHelper.RestoreFormPosition(f);
                    f.Show();
                    this.Close();
                }
            }
        }

        private void CheckOutAndPrintBill_Load(object sender, EventArgs e)
        {
            UIHelper.GlobalTimer.Tick += UpdateTimeLabel;
        }

        private void UpdateTimeLabel(object sender, EventArgs e)
        {
            lblTime.Text = UIHelper.CurrentTime;
        }

        private void panel9_MouseDown(object sender, MouseEventArgs e)
        {
            UIHelper.MoveWindow(this, e);
        }

        private void CheckOutAndPrintBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            UIHelper.SaveFormPosition(this);
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

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            ExportBill();
        }

        private void PrintBillIntoRichTextBox()
        {
            List<Bill> bill = BillBLL.Instance.GetBillsByTableIDCheckOut(tableID);
            string maHD = "HD" + bill.FirstOrDefault().ID;
            string nhanVien = UIHelper.userNameFromLogin.DisPlayName;
            string ngay = DateTime.Now.ToString("dd/MM/yyyy");
            string thoiGian = DateTime.Now.ToString("HH:mm:ss");

            double tongTien = 0;
            double thanhToan = 0;

            foreach (ListViewItem item in lsvBill.Items)
            {
                tongTien += double.Parse(item.SubItems[3].Text);
            }
            double giamGia = (double)nmGiamGia.Value * tongTien / 100;
            thanhToan = tongTien - giamGia;

            string hoaDonContent = rtbHoaDon.Text;

            hoaDonContent = hoaDonContent.Replace("{MaHD}", maHD);
            hoaDonContent = hoaDonContent.Replace("{Date}", ngay);
            hoaDonContent = hoaDonContent.Replace("{NhanVien}", nhanVien);
            hoaDonContent = hoaDonContent.Replace("{Time}", thoiGian);

            string tenMonTemplate = "";
            foreach (ListViewItem item in lsvBill.Items)
            {
                string tenMon = item.SubItems[0].Text;
                string soLuong = item.SubItems[1].Text;
                string donGia = item.SubItems[2].Text;
                string thanhTien = item.SubItems[3].Text;

                tenMonTemplate += $" {tenMon,-29} {soLuong,-11} {donGia,-10} {thanhTien,13}\n";
            }
            hoaDonContent = hoaDonContent.Replace("{TenMon}", tenMonTemplate);

            string tongTienFormatted = tongTien.ToString("N0");
            string giamGiaFormatted = giamGia.ToString("N0");
            string thanhToanFormatted = thanhToan.ToString("N0");

            hoaDonContent = ReplaceValue(hoaDonContent, "Tổng", tongTienFormatted);
            hoaDonContent = ReplaceValue(hoaDonContent, "Giảm giá", giamGiaFormatted);
            hoaDonContent = ReplaceValue(hoaDonContent, "Thanh toán", thanhToanFormatted);

            rtbHoaDon.Text = hoaDonContent;
        }

        string ReplaceValue(string hoaDonContent, string keyword, string newValue)
        {
            int indexKeyword = hoaDonContent.IndexOf(keyword);
            if (indexKeyword >= 0)
            {
                int colonIndex = hoaDonContent.IndexOf(":", indexKeyword);
                int dongIndex = hoaDonContent.IndexOf("Đồng", colonIndex);

                if (colonIndex >= 0 && dongIndex >= 0)
                {
                    string partBefore = hoaDonContent.Substring(0, colonIndex + 1);
                    string partAfter = hoaDonContent.Substring(dongIndex);

                    hoaDonContent = partBefore + " " + newValue + " " + partAfter;
                }
            }
            return hoaDonContent;
        }

        private void nmGiamGia_ValueChanged(object sender, EventArgs e)
        {
            PrintBillIntoRichTextBox();
        }

        private void ExportBill()
        {
            string templateFilePath = Path.Combine(Application.StartupPath, "Temp.txt");

            if (!File.Exists(templateFilePath))
            {
                MessageBox.Show("Không tìm thấy file Temp.txt trong thư mục gốc của dự án!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string billTemplate = File.ReadAllText(templateFilePath);

            List<Bill> bill = BillBLL.Instance.GetBillsByTableIDCheckOut(tableID);
            string maHD = "HD" + bill.FirstOrDefault().ID;
            string nhanVien = UIHelper.userNameFromLogin.DisPlayName;
            string ngay = DateTime.Now.ToString("dd/MM/yyyy");
            string thoiGian = DateTime.Now.ToString("HH:mm:ss");

            double tongTien = 0;
            double thanhToan = 0;

            string tenMonTemplate = "";
            foreach (ListViewItem item in lsvBill.Items)
            {
                string tenMon = item.SubItems[0].Text;
                string soLuong = item.SubItems[1].Text;
                string donGia = item.SubItems[2].Text;
                string thanhTien = item.SubItems[3].Text;

                tenMonTemplate += $" {tenMon,-34} {soLuong,-13} {donGia,-12} {thanhTien,15}\n";

                tongTien += double.Parse(item.SubItems[3].Text);
            }

            double giamGia = (double)nmGiamGia.Value * tongTien / 100;
            thanhToan = tongTien - giamGia;

            string hoaDonContent = billTemplate
                .Replace("{MaHD}", maHD)
                .Replace("{Date}", ngay)
                .Replace("{NhanVien}", nhanVien)
                .Replace("{Time}", thoiGian)
                .Replace("{TenMon}", tenMonTemplate)
                .Replace("{Tong}", tongTien.ToString("N0"))
                .Replace("{GiamGia}", giamGia.ToString("N0"))
                .Replace("{Checkout}", thanhToan.ToString("N0"));

            string filePath = Path.Combine(Path.GetTempPath(), $"HoaDon_{maHD}.txt");
            File.WriteAllText(filePath, hoaDonContent);

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            {
                e.Graphics.DrawString(hoaDonContent, new Font("Courier New", 10), Brushes.Black, new PointF(50, 50));
            };
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
    }
}
