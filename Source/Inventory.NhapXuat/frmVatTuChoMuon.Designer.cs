﻿namespace Inventory.NhapXuat
{
    partial class frmVatTuChoMuon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnHuy = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.gridDanhSachPhieuNhap = new System.Windows.Forms.DataGridView();
            this.Ma_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Da_phan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_chi_tiet_phieu_nhap_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_phieu_nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_lap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.So_luong_thuc_lanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Da_duyet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_loai_chat_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chat_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbKhoNhanVatTu = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbChonTatCa = new System.Windows.Forms.CheckBox();
            this.progressAll = new System.Windows.Forms.ProgressBar();
            this.txtRunning = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.uC_VatTu1 = new Inventory.UserControls.UC_VatTu();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSachPhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.close_bmc;
            this.btnHuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHuy.Location = new System.Drawing.Point(119, 10);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(50, 50);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hủy bỏ";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.close_bmc;
            this.btnDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDong.Location = new System.Drawing.Point(726, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(50, 50);
            this.btnDong.TabIndex = 2;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(736, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "Đóng";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 61);
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
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnHuy);
            this.pnlMenu.Controls.Add(this.label2);
            this.pnlMenu.Controls.Add(this.btnDong);
            this.pnlMenu.Controls.Add(this.label7);
            this.pnlMenu.Controls.Add(this.btnThem);
            this.pnlMenu.Controls.Add(this.label6);
            this.pnlMenu.Controls.Add(this.label5);
            this.pnlMenu.Controls.Add(this.btnLamMoi);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(788, 92);
            this.pnlMenu.TabIndex = 55;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.refresh_omc;
            this.btnLamMoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLamMoi.Location = new System.Drawing.Point(63, 10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(50, 50);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // gridDanhSachPhieuNhap
            // 
            this.gridDanhSachPhieuNhap.AllowUserToAddRows = false;
            this.gridDanhSachPhieuNhap.AllowUserToDeleteRows = false;
            this.gridDanhSachPhieuNhap.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.gridDanhSachPhieuNhap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDanhSachPhieuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDanhSachPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDanhSachPhieuNhap.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDanhSachPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridDanhSachPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDanhSachPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_vat_tu,
            this.Ten_vat_tu,
            this.Da_phan,
            this.ID_chi_tiet_phieu_nhap_vat_tu,
            this.Ma_phieu_nhap,
            this.Ngay_lap,
            this.So_luong_thuc_lanh,
            this.Da_duyet,
            this.ID_loai_chat_luong,
            this.Chat_luong});
            this.gridDanhSachPhieuNhap.Location = new System.Drawing.Point(0, 155);
            this.gridDanhSachPhieuNhap.MultiSelect = false;
            this.gridDanhSachPhieuNhap.Name = "gridDanhSachPhieuNhap";
            this.gridDanhSachPhieuNhap.ReadOnly = true;
            this.gridDanhSachPhieuNhap.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridDanhSachPhieuNhap.RowHeadersVisible = false;
            this.gridDanhSachPhieuNhap.RowTemplate.Height = 30;
            this.gridDanhSachPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDanhSachPhieuNhap.Size = new System.Drawing.Size(788, 287);
            this.gridDanhSachPhieuNhap.TabIndex = 54;
            // 
            // Ma_vat_tu
            // 
            this.Ma_vat_tu.DataPropertyName = "Ma_vat_tu";
            this.Ma_vat_tu.HeaderText = "Mã vật tư";
            this.Ma_vat_tu.Name = "Ma_vat_tu";
            this.Ma_vat_tu.ReadOnly = true;
            // 
            // Ten_vat_tu
            // 
            this.Ten_vat_tu.DataPropertyName = "Ten_vat_tu";
            this.Ten_vat_tu.HeaderText = "Tên vật tư";
            this.Ten_vat_tu.Name = "Ten_vat_tu";
            this.Ten_vat_tu.ReadOnly = true;
            // 
            // Da_phan
            // 
            this.Da_phan.DataPropertyName = "Da_phan";
            this.Da_phan.HeaderText = "Da_phan";
            this.Da_phan.Name = "Da_phan";
            this.Da_phan.ReadOnly = true;
            this.Da_phan.Visible = false;
            // 
            // ID_chi_tiet_phieu_nhap_vat_tu
            // 
            this.ID_chi_tiet_phieu_nhap_vat_tu.DataPropertyName = "ID_chi_tiet_phieu_nhap_vat_tu";
            this.ID_chi_tiet_phieu_nhap_vat_tu.HeaderText = "ID_chi_tiet_phieu_nhap_vat_tu";
            this.ID_chi_tiet_phieu_nhap_vat_tu.Name = "ID_chi_tiet_phieu_nhap_vat_tu";
            this.ID_chi_tiet_phieu_nhap_vat_tu.ReadOnly = true;
            this.ID_chi_tiet_phieu_nhap_vat_tu.Visible = false;
            // 
            // Ma_phieu_nhap
            // 
            this.Ma_phieu_nhap.DataPropertyName = "Ma_phieu_nhap";
            this.Ma_phieu_nhap.HeaderText = "Ma_phieu_nhap";
            this.Ma_phieu_nhap.Name = "Ma_phieu_nhap";
            this.Ma_phieu_nhap.ReadOnly = true;
            // 
            // Ngay_lap
            // 
            this.Ngay_lap.DataPropertyName = "Ngay_lap";
            this.Ngay_lap.HeaderText = "Ngay_lap";
            this.Ngay_lap.Name = "Ngay_lap";
            this.Ngay_lap.ReadOnly = true;
            // 
            // So_luong_thuc_lanh
            // 
            this.So_luong_thuc_lanh.DataPropertyName = "So_luong_thuc_lanh";
            this.So_luong_thuc_lanh.HeaderText = "Số lượng ";
            this.So_luong_thuc_lanh.Name = "So_luong_thuc_lanh";
            this.So_luong_thuc_lanh.ReadOnly = true;
            // 
            // Da_duyet
            // 
            this.Da_duyet.DataPropertyName = "Da_duyet";
            this.Da_duyet.HeaderText = "Da_duyet";
            this.Da_duyet.Name = "Da_duyet";
            this.Da_duyet.ReadOnly = true;
            this.Da_duyet.Visible = false;
            // 
            // ID_loai_chat_luong
            // 
            this.ID_loai_chat_luong.DataPropertyName = "ID_loai_chat_luong";
            this.ID_loai_chat_luong.HeaderText = "ID_loai_chat_luong";
            this.ID_loai_chat_luong.Name = "ID_loai_chat_luong";
            this.ID_loai_chat_luong.ReadOnly = true;
            this.ID_loai_chat_luong.Visible = false;
            // 
            // Chat_luong
            // 
            this.Chat_luong.DataPropertyName = "Chat_luong";
            this.Chat_luong.HeaderText = "Chat_luong";
            this.Chat_luong.Name = "Chat_luong";
            this.Chat_luong.ReadOnly = true;
            // 
            // cbKhoNhanVatTu
            // 
            this.cbKhoNhanVatTu.FormattingEnabled = true;
            this.cbKhoNhanVatTu.Location = new System.Drawing.Point(90, 110);
            this.cbKhoNhanVatTu.Name = "cbKhoNhanVatTu";
            this.cbKhoNhanVatTu.Size = new System.Drawing.Size(151, 21);
            this.cbKhoNhanVatTu.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Kho Cho Mượn";
            // 
            // chbChonTatCa
            // 
            this.chbChonTatCa.AutoSize = true;
            this.chbChonTatCa.Enabled = false;
            this.chbChonTatCa.Location = new System.Drawing.Point(691, 142);
            this.chbChonTatCa.Name = "chbChonTatCa";
            this.chbChonTatCa.Size = new System.Drawing.Size(81, 17);
            this.chbChonTatCa.TabIndex = 57;
            this.chbChonTatCa.Text = "Chọn tất cả";
            this.chbChonTatCa.UseVisualStyleBackColor = true;
            this.chbChonTatCa.Visible = false;
            // 
            // progressAll
            // 
            this.progressAll.Enabled = false;
            this.progressAll.Location = new System.Drawing.Point(646, 113);
            this.progressAll.Name = "progressAll";
            this.progressAll.Size = new System.Drawing.Size(142, 23);
            this.progressAll.TabIndex = 58;
            this.progressAll.Visible = false;
            // 
            // txtRunning
            // 
            this.txtRunning.AutoSize = true;
            this.txtRunning.Enabled = false;
            this.txtRunning.Location = new System.Drawing.Point(712, 95);
            this.txtRunning.Name = "txtRunning";
            this.txtRunning.Size = new System.Drawing.Size(13, 13);
            this.txtRunning.TabIndex = 59;
            this.txtRunning.Text = "0";
            this.txtRunning.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // uC_VatTu1
            // 
            this.uC_VatTu1.Location = new System.Drawing.Point(247, 95);
            this.uC_VatTu1.Name = "uC_VatTu1";
            this.uC_VatTu1.Size = new System.Drawing.Size(434, 54);
            this.uC_VatTu1.TabIndex = 64;
            // 
            // frmVatTuChoMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 438);
            this.Controls.Add(this.uC_VatTu1);
            this.Controls.Add(this.txtRunning);
            this.Controls.Add(this.progressAll);
            this.Controls.Add(this.chbChonTatCa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbKhoNhanVatTu);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.gridDanhSachPhieuNhap);
            this.Name = "frmVatTuChoMuon";
            this.Text = "frmVatTuPhanKho";
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSachPhieuNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView gridDanhSachPhieuNhap;
        private System.Windows.Forms.ComboBox cbKhoNhanVatTu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbChonTatCa;
        private System.Windows.Forms.ProgressBar progressAll;
        private System.Windows.Forms.Label txtRunning;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Da_phan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_chi_tiet_phieu_nhap_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_phieu_nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_lap;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_luong_thuc_lanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Da_duyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_loai_chat_luong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chat_luong;
        private UserControls.UC_VatTu uC_VatTu1;
    }
}