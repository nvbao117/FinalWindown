using CoffeeShopManagement.BLL;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CoffeeShopManagement
{
    public partial class ChartForm : Form
    {
        public ChartForm()
        {
            InitializeComponent();
            UIHelper.RestoreFormPosition(this);
            LoadInfo();
        }

        void LoadInfo()
        {
            pnlUser.BackColor = Color.FromArgb(255, 255, 255);
            lblUser.ForeColor = Color.Black;
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

            DateTime currentDate = DateTime.Now;
            DateTime checkIn = currentDate.AddMonths(-11);
            DateTime checkOut = currentDate;

            DataTable monthlyRevenueData = BillBLL.Instance.GetMonthlyRevenue(checkIn, checkOut);

            chartThongKeDoanhThu.Series.Clear();
            chartThongKeDoanhThu.ChartAreas.Clear();

            chartThongKeDoanhThu.ChartAreas.Add(new ChartArea());

            chartThongKeDoanhThu.ChartAreas[0].AxisX.Title = "Thời gian";
            chartThongKeDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu [VND]";

            chartThongKeDoanhThu.ChartAreas[0].AxisX.TitleFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            chartThongKeDoanhThu.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            chartThongKeDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";

            var series = new Series("Doanh Thu")
            {
                ChartType = SeriesChartType.Column
            };

            foreach (DataRow row in monthlyRevenueData.Rows)
            {
                string month = row["Tháng"].ToString();
                string year = row["Năm"].ToString();
                decimal revenue = Convert.ToDecimal(row["Doanh thu"]);

                string formattedRevenue = revenue.ToString("#,0");

                string monthYear = $"{month} - {year}";
                series.Points.AddXY(monthYear, revenue);

                series.Points.Last().Label = formattedRevenue;
            }

            chartThongKeDoanhThu.Series.Add(series);
        }

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            UIHelper.MoveWindow(this, e);
        }

        private void lblHiden_Click(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblExit_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ChartForm_Load(object sender, System.EventArgs e)
        {
            UIHelper.GlobalTimer.Tick += UpdateTimeLabel;
        }

        private void UpdateTimeLabel(object sender, EventArgs e)
        {
            lblTime.Text = UIHelper.CurrentTime;
        }

        private void ChangeForm_Click(object sender, EventArgs e)
        {
            List<Panel> panels = new List<Panel> { pnlHome, pnlAdmin, pnlUser, pnlOrder, pnlCheckOut, pnlHelp };

            UIHelper.ChangePanelColor(sender, panels, UIHelper.userNameFromLogin, this);
        }

        private void chartThongKeDoanhThu_Click(object sender, EventArgs e)
        {

        }
    }
}
