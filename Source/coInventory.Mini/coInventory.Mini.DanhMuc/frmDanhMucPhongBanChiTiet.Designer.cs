namespace coInventory.Mini.DanhMuc
{
    partial class frmDanhMucPhongBanChiTiet
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucPhongBanChiTiet));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaPhongBan = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lblCapNhat = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.txtTenPhongBan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoaiPhongBan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Phòng Ban";
            // 
            // txtMaPhongBan
            // 
            this.txtMaPhongBan.BackColor = System.Drawing.SystemColors.Info;
            this.txtMaPhongBan.Location = new System.Drawing.Point(108, 10);
            this.txtMaPhongBan.Name = "txtMaPhongBan";
            this.txtMaPhongBan.Size = new System.Drawing.Size(215, 20);
            this.txtMaPhongBan.TabIndex = 0;
            this.txtMaPhongBan.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaPhongBan_Validating);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(284, 146);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(26, 13);
            this.label22.TabIndex = 128;
            this.label22.Text = "Hủy";
            // 
            // lblCapNhat
            // 
            this.lblCapNhat.AutoSize = true;
            this.lblCapNhat.Location = new System.Drawing.Point(212, 147);
            this.lblCapNhat.Name = "lblCapNhat";
            this.lblCapNhat.Size = new System.Drawing.Size(50, 13);
            this.lblCapNhat.TabIndex = 127;
            this.lblCapNhat.Text = "Cập nhật";
            // 
            // btnHuy
            // 
            this.btnHuy.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.cancel_omc;
            this.btnHuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHuy.Location = new System.Drawing.Point(273, 94);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(50, 50);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.save_bmc;
            this.btnCapNhat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCapNhat.Location = new System.Drawing.Point(212, 94);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(50, 50);
            this.btnCapNhat.TabIndex = 4;
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // txtTenPhongBan
            // 
            this.txtTenPhongBan.BackColor = System.Drawing.SystemColors.Info;
            this.txtTenPhongBan.Location = new System.Drawing.Point(108, 39);
            this.txtTenPhongBan.Name = "txtTenPhongBan";
            this.txtTenPhongBan.Size = new System.Drawing.Size(215, 20);
            this.txtTenPhongBan.TabIndex = 1;
            this.txtTenPhongBan.Validating += new System.ComponentModel.CancelEventHandler(this.txtTenPhongBan_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 129;
            this.label2.Text = "Tên Phòng Ban";
            // 
            // txtLoaiPhongBan
            // 
            this.txtLoaiPhongBan.Location = new System.Drawing.Point(108, 94);
            this.txtLoaiPhongBan.Name = "txtLoaiPhongBan";
            this.txtLoaiPhongBan.Size = new System.Drawing.Size(80, 20);
            this.txtLoaiPhongBan.TabIndex = 2;
            this.txtLoaiPhongBan.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 131;
            this.label3.Text = "Loại Phòng Ban";
            this.label3.Visible = false;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Checked = true;
            this.cbActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbActive.Location = new System.Drawing.Point(108, 65);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(72, 17);
            this.cbActive.TabIndex = 3;
            this.cbActive.Text = "Còn dùng";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmDanhMucPhongBanChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 170);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.txtLoaiPhongBan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTenPhongBan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblCapNhat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.txtMaPhongBan);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhMucPhongBanChiTiet";
            this.Text = "frmDanhMucPhongBanChiTiet";
            this.Load += new System.EventHandler(this.frmDanhMucPhongBanChiTiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaPhongBan;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblCapNhat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.TextBox txtTenPhongBan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLoaiPhongBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}