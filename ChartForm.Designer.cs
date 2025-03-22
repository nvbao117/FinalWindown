namespace CoffeeShopManagement
{
    partial class ChartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label13;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblHiden = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblAdminName = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.lblHome = new System.Windows.Forms.Label();
            this.pnlAdmin = new System.Windows.Forms.Panel();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.lblOrder = new System.Windows.Forms.Label();
            this.pnlCheckOut = new System.Windows.Forms.Panel();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.pbIconCheckOut = new System.Windows.Forms.PictureBox();
            this.pnlHelp = new System.Windows.Forms.Panel();
            this.lblHelp = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.chartThongKeDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label13 = new System.Windows.Forms.Label();
            this.pnlTitleBar.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlHome.SuspendLayout();
            this.pnlAdmin.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            this.pnlCheckOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconCheckOut)).BeginInit();
            this.pnlHelp.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(89)))));
            label13.Location = new System.Drawing.Point(281, 94);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(79, 32);
            label13.TabIndex = 21;
            label13.Text = "Stats";
            label13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseDown);
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(44)))), ((int)(((byte)(33)))));
            this.pnlTitleBar.Controls.Add(this.lblTime);
            this.pnlTitleBar.Controls.Add(this.lblMenu);
            this.pnlTitleBar.Controls.Add(this.lblExit);
            this.pnlTitleBar.Controls.Add(this.lblHiden);
            this.pnlTitleBar.Controls.Add(this.panel10);
            this.pnlTitleBar.Controls.Add(label13);
            this.pnlTitleBar.Controls.Add(this.lblDisplayName);
            this.pnlTitleBar.Controls.Add(this.lblAdminName);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(1580, 160);
            this.pnlTitleBar.TabIndex = 21;
            this.pnlTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseDown);
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(225)))), ((int)(((byte)(230)))));
            this.lblTime.Location = new System.Drawing.Point(888, 21);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(307, 116);
            this.lblTime.TabIndex = 25;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseDown);
            // 
            // lblMenu
            // 
            this.lblMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.ForeColor = System.Drawing.Color.Red;
            this.lblMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMenu.Location = new System.Drawing.Point(16, 26);
            this.lblMenu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(223, 80);
            this.lblMenu.TabIndex = 24;
            this.lblMenu.Text = "Menu";
            this.lblMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseDown);
            // 
            // lblExit
            // 
            this.lblExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblExit.Location = new System.Drawing.Point(1527, 0);
            this.lblExit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(41, 59);
            this.lblExit.TabIndex = 23;
            this.lblExit.Text = "x";
            this.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblHiden
            // 
            this.lblHiden.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHiden.ForeColor = System.Drawing.Color.White;
            this.lblHiden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHiden.Location = new System.Drawing.Point(1463, 11);
            this.lblHiden.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHiden.Name = "lblHiden";
            this.lblHiden.Size = new System.Drawing.Size(56, 48);
            this.lblHiden.TabIndex = 22;
            this.lblHiden.Text = "—";
            this.lblHiden.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblHiden.Click += new System.EventHandler(this.lblHiden_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(54)))), ((int)(((byte)(39)))));
            this.panel10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel10.BackgroundImage")));
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel10.Location = new System.Drawing.Point(275, 20);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(100, 86);
            this.panel10.TabIndex = 4;
            this.panel10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseDown);
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblDisplayName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(196)))));
            this.lblDisplayName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDisplayName.Location = new System.Drawing.Point(404, 73);
            this.lblDisplayName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(429, 62);
            this.lblDisplayName.TabIndex = 5;
            this.lblDisplayName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDisplayName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseDown);
            // 
            // lblAdminName
            // 
            this.lblAdminName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblAdminName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAdminName.Location = new System.Drawing.Point(413, 11);
            this.lblAdminName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(420, 62);
            this.lblAdminName.TabIndex = 4;
            this.lblAdminName.Text = "Admin";
            this.lblAdminName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAdminName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseDown);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(169)))));
            this.flowLayoutPanel1.Controls.Add(this.pnlHome);
            this.flowLayoutPanel1.Controls.Add(this.pnlAdmin);
            this.flowLayoutPanel1.Controls.Add(this.pnlUser);
            this.flowLayoutPanel1.Controls.Add(this.pnlOrder);
            this.flowLayoutPanel1.Controls.Add(this.pnlCheckOut);
            this.flowLayoutPanel1.Controls.Add(this.pnlHelp);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 160);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(248, 674);
            this.flowLayoutPanel1.TabIndex = 22;
            // 
            // pnlHome
            // 
            this.pnlHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(44)))), ((int)(((byte)(33)))));
            this.pnlHome.Controls.Add(this.lblHome);
            this.pnlHome.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlHome.Location = new System.Drawing.Point(1, 1);
            this.pnlHome.Margin = new System.Windows.Forms.Padding(1);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(243, 108);
            this.pnlHome.TabIndex = 4;
            this.pnlHome.Click += new System.EventHandler(this.ChangeForm_Click);
            // 
            // lblHome
            // 
            this.lblHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHome.ForeColor = System.Drawing.Color.White;
            this.lblHome.Image = ((System.Drawing.Image)(resources.GetObject("lblHome.Image")));
            this.lblHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHome.Location = new System.Drawing.Point(15, 23);
            this.lblHome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(205, 70);
            this.lblHome.TabIndex = 0;
            this.lblHome.Text = "Home";
            this.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHome.Click += new System.EventHandler(this.ChangeForm_Click);
            // 
            // pnlAdmin
            // 
            this.pnlAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(44)))), ((int)(((byte)(33)))));
            this.pnlAdmin.Controls.Add(this.lblAdmin);
            this.pnlAdmin.Location = new System.Drawing.Point(1, 111);
            this.pnlAdmin.Margin = new System.Windows.Forms.Padding(1);
            this.pnlAdmin.Name = "pnlAdmin";
            this.pnlAdmin.Size = new System.Drawing.Size(243, 108);
            this.pnlAdmin.TabIndex = 3;
            this.pnlAdmin.Click += new System.EventHandler(this.ChangeForm_Click);
            // 
            // lblAdmin
            // 
            this.lblAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdmin.ForeColor = System.Drawing.Color.White;
            this.lblAdmin.Image = ((System.Drawing.Image)(resources.GetObject("lblAdmin.Image")));
            this.lblAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAdmin.Location = new System.Drawing.Point(15, 20);
            this.lblAdmin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(224, 70);
            this.lblAdmin.TabIndex = 5;
            this.lblAdmin.Text = "Admin";
            this.lblAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAdmin.Click += new System.EventHandler(this.ChangeForm_Click);
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(44)))), ((int)(((byte)(33)))));
            this.pnlUser.Controls.Add(this.lblUser);
            this.pnlUser.Location = new System.Drawing.Point(1, 221);
            this.pnlUser.Margin = new System.Windows.Forms.Padding(1);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(243, 108);
            this.pnlUser.TabIndex = 4;
            this.pnlUser.Click += new System.EventHandler(this.ChangeForm_Click);
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Image = ((System.Drawing.Image)(resources.GetObject("lblUser.Image")));
            this.lblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUser.Location = new System.Drawing.Point(24, 20);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(188, 70);
            this.lblUser.TabIndex = 7;
            this.lblUser.Text = "Stats";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUser.Click += new System.EventHandler(this.ChangeForm_Click);
            // 
            // pnlOrder
            // 
            this.pnlOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(44)))), ((int)(((byte)(33)))));
            this.pnlOrder.Controls.Add(this.lblOrder);
            this.pnlOrder.Location = new System.Drawing.Point(1, 331);
            this.pnlOrder.Margin = new System.Windows.Forms.Padding(1);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(243, 108);
            this.pnlOrder.TabIndex = 4;
            this.pnlOrder.Click += new System.EventHandler(this.ChangeForm_Click);
            // 
            // lblOrder
            // 
            this.lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.ForeColor = System.Drawing.Color.White;
            this.lblOrder.Image = ((System.Drawing.Image)(resources.GetObject("lblOrder.Image")));
            this.lblOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOrder.Location = new System.Drawing.Point(19, 22);
            this.lblOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(185, 70);
            this.lblOrder.TabIndex = 3;
            this.lblOrder.Text = "Order";
            this.lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOrder.Click += new System.EventHandler(this.ChangeForm_Click);
            // 
            // pnlCheckOut
            // 
            this.pnlCheckOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(44)))), ((int)(((byte)(33)))));
            this.pnlCheckOut.Controls.Add(this.lblCheckOut);
            this.pnlCheckOut.Controls.Add(this.pbIconCheckOut);
            this.pnlCheckOut.Location = new System.Drawing.Point(1, 441);
            this.pnlCheckOut.Margin = new System.Windows.Forms.Padding(1);
            this.pnlCheckOut.Name = "pnlCheckOut";
            this.pnlCheckOut.Size = new System.Drawing.Size(243, 108);
            this.pnlCheckOut.TabIndex = 4;
            this.pnlCheckOut.Click += new System.EventHandler(this.ChangeForm_Click);
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOut.ForeColor = System.Drawing.Color.White;
            this.lblCheckOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCheckOut.Location = new System.Drawing.Point(89, 0);
            this.lblCheckOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(115, 108);
            this.lblCheckOut.TabIndex = 2;
            this.lblCheckOut.Text = "Check out";
            this.lblCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCheckOut.Click += new System.EventHandler(this.ChangeForm_Click);
            // 
            // pbIconCheckOut
            // 
            this.pbIconCheckOut.Image = ((System.Drawing.Image)(resources.GetObject("pbIconCheckOut.Image")));
            this.pbIconCheckOut.Location = new System.Drawing.Point(15, 21);
            this.pbIconCheckOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbIconCheckOut.Name = "pbIconCheckOut";
            this.pbIconCheckOut.Size = new System.Drawing.Size(67, 66);
            this.pbIconCheckOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIconCheckOut.TabIndex = 3;
            this.pbIconCheckOut.TabStop = false;
            this.pbIconCheckOut.Click += new System.EventHandler(this.ChangeForm_Click);
            // 
            // pnlHelp
            // 
            this.pnlHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(44)))), ((int)(((byte)(33)))));
            this.pnlHelp.Controls.Add(this.lblHelp);
            this.pnlHelp.Location = new System.Drawing.Point(1, 551);
            this.pnlHelp.Margin = new System.Windows.Forms.Padding(1);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(243, 108);
            this.pnlHelp.TabIndex = 4;
            this.pnlHelp.Click += new System.EventHandler(this.ChangeForm_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.ForeColor = System.Drawing.Color.White;
            this.lblHelp.Image = ((System.Drawing.Image)(resources.GetObject("lblHelp.Image")));
            this.lblHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHelp.Location = new System.Drawing.Point(19, 20);
            this.lblHelp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(185, 70);
            this.lblHelp.TabIndex = 1;
            this.lblHelp.Text = "Help";
            this.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHelp.Click += new System.EventHandler(this.ChangeForm_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.chartThongKeDoanhThu);
            this.panel9.Location = new System.Drawing.Point(248, 160);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1331, 674);
            this.panel9.TabIndex = 23;
            // 
            // chartThongKeDoanhThu
            // 
            this.chartThongKeDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(169)))));
            this.chartThongKeDoanhThu.BorderlineColor = System.Drawing.SystemColors.Window;
            chartArea4.AxisX.Title = "Thời gian";
            chartArea4.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisY.Title = "Doanh thu (VND)";
            chartArea4.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.Name = "ChartArea1";
            this.chartThongKeDoanhThu.ChartAreas.Add(chartArea4);
            this.chartThongKeDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chartThongKeDoanhThu.Legends.Add(legend4);
            this.chartThongKeDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.chartThongKeDoanhThu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartThongKeDoanhThu.Name = "chartThongKeDoanhThu";
            series4.ChartArea = "ChartArea1";
            series4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.Legend = "Legend1";
            series4.LegendText = "Biểu Đồ Thống Kê";
            series4.Name = "Chart";
            this.chartThongKeDoanhThu.Series.Add(series4);
            this.chartThongKeDoanhThu.Size = new System.Drawing.Size(1331, 674);
            this.chartThongKeDoanhThu.TabIndex = 0;
            title4.BorderWidth = 2;
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.ForeColor = System.Drawing.Color.Red;
            title4.Name = "Title1";
            title4.Text = "Biểu đồ thống kê doanh thu theo tháng";
            this.chartThongKeDoanhThu.Titles.Add(title4);
            this.chartThongKeDoanhThu.Click += new System.EventHandler(this.chartThongKeDoanhThu_Click);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 834);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChartForm";
            this.Load += new System.EventHandler(this.ChartForm_Load);
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlHome.ResumeLayout(false);
            this.pnlAdmin.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.pnlOrder.ResumeLayout(false);
            this.pnlCheckOut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIconCheckOut)).EndInit();
            this.pnlHelp.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeDoanhThu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblHiden;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblAdminName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Panel pnlAdmin;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Panel pnlCheckOut;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.PictureBox pbIconCheckOut;
        private System.Windows.Forms.Panel pnlHelp;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKeDoanhThu;
    }
}