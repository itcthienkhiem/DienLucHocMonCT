﻿namespace Inventory.NhapXuat
{
    partial class frmDanhSachPhieuNhap
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridDanhSachPhieuNhap = new System.Windows.Forms.DataGridView();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSua = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.Ma_phieu_nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_kho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_lap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ly_do = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.So_hoa_don = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cong_trinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dia_Chi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSachPhieuNhap)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridDanhSachPhieuNhap
            // 
            this.gridDanhSachPhieuNhap.AllowUserToAddRows = false;
            this.gridDanhSachPhieuNhap.AllowUserToDeleteRows = false;
            this.gridDanhSachPhieuNhap.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            this.gridDanhSachPhieuNhap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridDanhSachPhieuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDanhSachPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDanhSachPhieuNhap.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDanhSachPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridDanhSachPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDanhSachPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_phieu_nhap,
            this.Ten_kho,
            this.Ngay_lap,
            this.Ly_do,
            this.So_hoa_don,
            this.Cong_trinh,
            this.Dia_Chi});
            this.gridDanhSachPhieuNhap.Location = new System.Drawing.Point(1, 98);
            this.gridDanhSachPhieuNhap.MultiSelect = false;
            this.gridDanhSachPhieuNhap.Name = "gridDanhSachPhieuNhap";
            this.gridDanhSachPhieuNhap.ReadOnly = true;
            this.gridDanhSachPhieuNhap.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridDanhSachPhieuNhap.RowHeadersVisible = false;
            this.gridDanhSachPhieuNhap.RowTemplate.Height = 30;
            this.gridDanhSachPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDanhSachPhieuNhap.Size = new System.Drawing.Size(710, 359);
            this.gridDanhSachPhieuNhap.TabIndex = 52;
            this.gridDanhSachPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridgridDanhSachPhieuNhap_CellClick);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnHuy);
            this.pnlMenu.Controls.Add(this.label2);
            this.pnlMenu.Controls.Add(this.btnLuu);
            this.pnlMenu.Controls.Add(this.label10);
            this.pnlMenu.Controls.Add(this.btnDong);
            this.pnlMenu.Controls.Add(this.label7);
            this.pnlMenu.Controls.Add(this.btnThem);
            this.pnlMenu.Controls.Add(this.label6);
            this.pnlMenu.Controls.Add(this.label5);
            this.pnlMenu.Controls.Add(this.btnSua);
            this.pnlMenu.Controls.Add(this.btnXoa);
            this.pnlMenu.Controls.Add(this.btnLamMoi);
            this.pnlMenu.Controls.Add(this.label3);
            this.pnlMenu.Controls.Add(this.lblSua);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(711, 92);
            this.pnlMenu.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hủy bỏ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 14);
            this.label10.TabIndex = 3;
            this.label10.Text = "Save";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(659, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "Đóng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "Làm mới";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Thêm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Xóa";
            // 
            // lblSua
            // 
            this.lblSua.AutoSize = true;
            this.lblSua.Location = new System.Drawing.Point(140, 61);
            this.lblSua.Name = "lblSua";
            this.lblSua.Size = new System.Drawing.Size(28, 14);
            this.lblSua.TabIndex = 3;
            this.lblSua.Text = "Sửa";
            // 
            // btnHuy
            // 
            this.btnHuy.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.cancel_bmc1;
            this.btnHuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHuy.Location = new System.Drawing.Point(297, 12);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(50, 50);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.save_bmc;
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLuu.Location = new System.Drawing.Point(241, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(50, 50);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.cancel_bmc;
            this.btnDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDong.Location = new System.Drawing.Point(649, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(50, 50);
            this.btnDong.TabIndex = 2;
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.addFile_omc;
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThem.Location = new System.Drawing.Point(9, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(50, 50);
            this.btnThem.TabIndex = 2;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.edit_gmc;
            this.btnSua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSua.Location = new System.Drawing.Point(129, 10);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(50, 50);
            this.btnSua.TabIndex = 2;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.cancel_omc;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXoa.Location = new System.Drawing.Point(69, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(50, 50);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.refresh_omc;
            this.btnLamMoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLamMoi.Location = new System.Drawing.Point(185, 10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(50, 50);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // Ma_phieu_nhap
            // 
            this.Ma_phieu_nhap.DataPropertyName = "Ma_phieu_nhap";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Ma_phieu_nhap.DefaultCellStyle = dataGridViewCellStyle6;
            this.Ma_phieu_nhap.HeaderText = "Mã phiếu nhập";
            this.Ma_phieu_nhap.Name = "Ma_phieu_nhap";
            this.Ma_phieu_nhap.ReadOnly = true;
            // 
            // Ten_kho
            // 
            this.Ten_kho.DataPropertyName = "Ten_kho";
            this.Ten_kho.HeaderText = "Tên Kho";
            this.Ten_kho.Name = "Ten_kho";
            this.Ten_kho.ReadOnly = true;
            // 
            // Ngay_lap
            // 
            this.Ngay_lap.DataPropertyName = "Ngay_lap";
            this.Ngay_lap.HeaderText = "Ngày lập";
            this.Ngay_lap.Name = "Ngay_lap";
            this.Ngay_lap.ReadOnly = true;
            // 
            // Ly_do
            // 
            this.Ly_do.DataPropertyName = "Ly_do";
            this.Ly_do.HeaderText = "Lý do nhập";
            this.Ly_do.Name = "Ly_do";
            this.Ly_do.ReadOnly = true;
            // 
            // So_hoa_don
            // 
            this.So_hoa_don.DataPropertyName = "So_hoa_don";
            this.So_hoa_don.HeaderText = "Số hóa đơn";
            this.So_hoa_don.Name = "So_hoa_don";
            this.So_hoa_don.ReadOnly = true;
            // 
            // Cong_trinh
            // 
            this.Cong_trinh.DataPropertyName = "Cong_trinh";
            this.Cong_trinh.HeaderText = "Công Trình";
            this.Cong_trinh.Name = "Cong_trinh";
            this.Cong_trinh.ReadOnly = true;
            // 
            // Dia_Chi
            // 
            this.Dia_Chi.DataPropertyName = "Dia_Chi";
            this.Dia_Chi.HeaderText = "Địa chỉ";
            this.Dia_Chi.Name = "Dia_Chi";
            this.Dia_Chi.ReadOnly = true;
            // 
            // frmDanhSachPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 458);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.gridDanhSachPhieuNhap);
            this.Name = "frmDanhSachPhieuNhap";
            this.Text = "frmDanhSachPhieuNhap";
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSachPhieuNhap)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridDanhSachPhieuNhap;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSua;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_phieu_nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_kho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_lap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ly_do;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_hoa_don;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cong_trinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dia_Chi;

    }
}