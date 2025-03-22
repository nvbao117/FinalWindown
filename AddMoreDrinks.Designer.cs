namespace CoffeeShopManagement
{
    partial class AddMoreDrinks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMoreDrinks));
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.nmSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrder
            // 
            this.lblOrder.Font = new System.Drawing.Font("Paytone One", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOrder.Location = new System.Drawing.Point(110, -1);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(113, 51);
            this.lblOrder.TabIndex = 0;
            this.lblOrder.Text = "ORDER";
            this.lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitPrice.Location = new System.Drawing.Point(12, 153);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(107, 30);
            this.lblUnitPrice.TabIndex = 1;
            this.lblUnitPrice.Text = "Đơn giá:";
            this.lblUnitPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNum
            // 
            this.lblNum.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.Location = new System.Drawing.Point(12, 107);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(107, 30);
            this.lblNum.TabIndex = 2;
            this.lblNum.Text = "Số lượng:";
            this.lblNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(107, 30);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Tên món:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMoney
            // 
            this.lblMoney.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney.Location = new System.Drawing.Point(12, 197);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(107, 30);
            this.lblMoney.TabIndex = 4;
            this.lblMoney.Text = "Thành tiền:";
            this.lblMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.LightGreen;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Paytone One", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(220, 242);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(84, 36);
            this.btnXacNhan.TabIndex = 6;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // lblTenMon
            // 
            this.lblTenMon.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMon.Location = new System.Drawing.Point(143, 60);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(161, 30);
            this.lblTenMon.TabIndex = 7;
            this.lblTenMon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nmSoLuong
            // 
            this.nmSoLuong.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmSoLuong.Location = new System.Drawing.Point(220, 107);
            this.nmSoLuong.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nmSoLuong.Name = "nmSoLuong";
            this.nmSoLuong.Size = new System.Drawing.Size(84, 30);
            this.nmSoLuong.TabIndex = 8;
            this.nmSoLuong.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nmSoLuong.ValueChanged += new System.EventHandler(this.nmSoLuong_ValueChanged);
            // 
            // lblDonGia
            // 
            this.lblDonGia.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonGia.Location = new System.Drawing.Point(143, 153);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(161, 30);
            this.lblDonGia.TabIndex = 9;
            this.lblDonGia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanhTien.Location = new System.Drawing.Point(143, 197);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(161, 30);
            this.lblThanhTien.TabIndex = 10;
            this.lblThanhTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.LightCoral;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Paytone One", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(163, 242);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(52, 36);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // AddMoreDrinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(228)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(316, 290);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.lblDonGia);
            this.Controls.Add(this.nmSoLuong);
            this.Controls.Add(this.lblTenMon);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.lblOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddMoreDrinks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm thức uống";
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.NumericUpDown nmSoLuong;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Button btnHuy;
    }
}