namespace CoffeeShopManagement
{
    partial class Merge_Tables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Merge_Tables));
            this.lblChonBan = new System.Windows.Forms.Label();
            this.pnlBan1st = new System.Windows.Forms.Panel();
            this.lblBan1st = new System.Windows.Forms.Label();
            this.pnlBan2 = new System.Windows.Forms.Panel();
            this.lblBan2nd = new System.Windows.Forms.Label();
            this.cbChonBan = new System.Windows.Forms.ComboBox();
            this.pbChuyen = new System.Windows.Forms.PictureBox();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.pnlBan1st.SuspendLayout();
            this.pnlBan2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChonBan
            // 
            this.lblChonBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblChonBan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblChonBan.Font = new System.Drawing.Font("Paytone One", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblChonBan.Location = new System.Drawing.Point(10, 10);
            this.lblChonBan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChonBan.Name = "lblChonBan";
            this.lblChonBan.Size = new System.Drawing.Size(217, 34);
            this.lblChonBan.TabIndex = 18;
            this.lblChonBan.Text = "Chọn bàn để gộp";
            this.lblChonBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBan1st
            // 
            this.pnlBan1st.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pnlBan1st.Controls.Add(this.lblBan1st);
            this.pnlBan1st.Location = new System.Drawing.Point(11, 61);
            this.pnlBan1st.Name = "pnlBan1st";
            this.pnlBan1st.Size = new System.Drawing.Size(123, 106);
            this.pnlBan1st.TabIndex = 19;
            // 
            // lblBan1st
            // 
            this.lblBan1st.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblBan1st.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblBan1st.Font = new System.Drawing.Font("Paytone One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblBan1st.Location = new System.Drawing.Point(12, 38);
            this.lblBan1st.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBan1st.Name = "lblBan1st";
            this.lblBan1st.Size = new System.Drawing.Size(100, 34);
            this.lblBan1st.TabIndex = 18;
            this.lblBan1st.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBan2
            // 
            this.pnlBan2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlBan2.Controls.Add(this.lblBan2nd);
            this.pnlBan2.Location = new System.Drawing.Point(233, 61);
            this.pnlBan2.Name = "pnlBan2";
            this.pnlBan2.Size = new System.Drawing.Size(123, 106);
            this.pnlBan2.TabIndex = 20;
            // 
            // lblBan2nd
            // 
            this.lblBan2nd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblBan2nd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblBan2nd.Font = new System.Drawing.Font("Paytone One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblBan2nd.Location = new System.Drawing.Point(11, 38);
            this.lblBan2nd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBan2nd.Name = "lblBan2nd";
            this.lblBan2nd.Size = new System.Drawing.Size(100, 34);
            this.lblBan2nd.TabIndex = 19;
            this.lblBan2nd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbChonBan
            // 
            this.cbChonBan.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChonBan.FormattingEnabled = true;
            this.cbChonBan.Location = new System.Drawing.Point(233, 10);
            this.cbChonBan.Name = "cbChonBan";
            this.cbChonBan.Size = new System.Drawing.Size(122, 34);
            this.cbChonBan.TabIndex = 23;
            this.cbChonBan.SelectedIndexChanged += new System.EventHandler(this.cbChonBan_SelectedIndexChanged);
            // 
            // pbChuyen
            // 
            this.pbChuyen.Image = ((System.Drawing.Image)(resources.GetObject("pbChuyen.Image")));
            this.pbChuyen.Location = new System.Drawing.Point(140, 89);
            this.pbChuyen.Name = "pbChuyen";
            this.pbChuyen.Size = new System.Drawing.Size(87, 60);
            this.pbChuyen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbChuyen.TabIndex = 22;
            this.pbChuyen.TabStop = false;
            // 
            // btnThucHien
            // 
            this.btnThucHien.BackColor = System.Drawing.Color.Lime;
            this.btnThucHien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThucHien.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThucHien.Location = new System.Drawing.Point(124, 189);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(117, 38);
            this.btnThucHien.TabIndex = 21;
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.UseVisualStyleBackColor = false;
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // Merge_Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(228)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(367, 236);
            this.Controls.Add(this.lblChonBan);
            this.Controls.Add(this.pnlBan1st);
            this.Controls.Add(this.pnlBan2);
            this.Controls.Add(this.cbChonBan);
            this.Controls.Add(this.pbChuyen);
            this.Controls.Add(this.btnThucHien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Merge_Tables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gộp bàn";
            this.pnlBan1st.ResumeLayout(false);
            this.pnlBan2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbChuyen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblChonBan;
        private System.Windows.Forms.Panel pnlBan1st;
        private System.Windows.Forms.Label lblBan1st;
        private System.Windows.Forms.Panel pnlBan2;
        private System.Windows.Forms.Label lblBan2nd;
        private System.Windows.Forms.ComboBox cbChonBan;
        private System.Windows.Forms.PictureBox pbChuyen;
        private System.Windows.Forms.Button btnThucHien;
    }
}