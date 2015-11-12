namespace Inventory.QuanLyTonDauKy
{
    partial class frmDanhSachPhieuNo
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
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataTable1 = new System.Data.DataTable();
            this.dataSet1 = new System.Data.DataSet();
            this.gridDanhSachPhieuNhap = new System.Windows.Forms.DataGridView();
            this.Ma_phieu_nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kho_nhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.So_hoa_don = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cong_trinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dia_chi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_loai_phieu_nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kho_xuat_ra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_phieu_nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_kho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_kho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngay_lap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ly_do = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isNhapNgoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCanTru = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isGoiDau = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Da_phan_kho = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSachPhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "So_luong_giu_lai";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "So_luong_hoan_nhap";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "ID_Don_vi_tinh";
            this.dataColumn10.DataType = typeof(short);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "so_luong_thuc_lanh";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "Ten_Don_vi_tinh";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "So_luong";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Ten_vat_tu";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Ma_vat_tu";
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn6,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn4,
            this.dataColumn5});
            this.dataTable1.TableName = "Table1";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
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
            this.Ma_phieu_nhap,
            this.Kho_nhan,
            this.So_hoa_don,
            this.Cong_trinh,
            this.Dia_chi,
            this.ID_loai_phieu_nhap,
            this.Kho_xuat_ra,
            this.ID_phieu_nhap,
            this.ID_kho,
            this.Ten_kho,
            this.ngay_lap,
            this.Ly_do,
            this.isNhapNgoai,
            this.isCanTru,
            this.isGoiDau,
            this.Da_phan_kho});
            this.gridDanhSachPhieuNhap.Location = new System.Drawing.Point(-4, 12);
            this.gridDanhSachPhieuNhap.MultiSelect = false;
            this.gridDanhSachPhieuNhap.Name = "gridDanhSachPhieuNhap";
            this.gridDanhSachPhieuNhap.ReadOnly = true;
            this.gridDanhSachPhieuNhap.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridDanhSachPhieuNhap.RowHeadersVisible = false;
            this.gridDanhSachPhieuNhap.RowTemplate.Height = 30;
            this.gridDanhSachPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDanhSachPhieuNhap.Size = new System.Drawing.Size(1075, 433);
            this.gridDanhSachPhieuNhap.TabIndex = 146;
            // 
            // Ma_phieu_nhap
            // 
            this.Ma_phieu_nhap.DataPropertyName = "Ma_phieu_nhap";
            this.Ma_phieu_nhap.HeaderText = "Mã phiếu";
            this.Ma_phieu_nhap.Name = "Ma_phieu_nhap";
            this.Ma_phieu_nhap.ReadOnly = true;
            // 
            // Kho_nhan
            // 
            this.Kho_nhan.HeaderText = "Kho_nhan";
            this.Kho_nhan.Name = "Kho_nhan";
            this.Kho_nhan.ReadOnly = true;
            this.Kho_nhan.Visible = false;
            // 
            // So_hoa_don
            // 
            this.So_hoa_don.DataPropertyName = "So_hoa_don";
            this.So_hoa_don.HeaderText = "So_hoa_don";
            this.So_hoa_don.Name = "So_hoa_don";
            this.So_hoa_don.ReadOnly = true;
            this.So_hoa_don.Visible = false;
            // 
            // Cong_trinh
            // 
            this.Cong_trinh.DataPropertyName = "Cong_trinh";
            this.Cong_trinh.HeaderText = "Công trình";
            this.Cong_trinh.Name = "Cong_trinh";
            this.Cong_trinh.ReadOnly = true;
            this.Cong_trinh.Visible = false;
            // 
            // Dia_chi
            // 
            this.Dia_chi.DataPropertyName = "Dia_chi";
            this.Dia_chi.HeaderText = "Địa chỉ";
            this.Dia_chi.Name = "Dia_chi";
            this.Dia_chi.ReadOnly = true;
            // 
            // ID_loai_phieu_nhap
            // 
            this.ID_loai_phieu_nhap.DataPropertyName = "ID_loai_phieu_nhap";
            this.ID_loai_phieu_nhap.HeaderText = "ID_loai_phieu_nhap";
            this.ID_loai_phieu_nhap.Name = "ID_loai_phieu_nhap";
            this.ID_loai_phieu_nhap.ReadOnly = true;
            this.ID_loai_phieu_nhap.Visible = false;
            // 
            // Kho_xuat_ra
            // 
            this.Kho_xuat_ra.DataPropertyName = "Kho_xuat_ra";
            this.Kho_xuat_ra.HeaderText = "Kho xuất ra";
            this.Kho_xuat_ra.Name = "Kho_xuat_ra";
            this.Kho_xuat_ra.ReadOnly = true;
            // 
            // ID_phieu_nhap
            // 
            this.ID_phieu_nhap.DataPropertyName = "ID_phieu_nhap";
            this.ID_phieu_nhap.HeaderText = "ID_phieu_nhap";
            this.ID_phieu_nhap.Name = "ID_phieu_nhap";
            this.ID_phieu_nhap.ReadOnly = true;
            this.ID_phieu_nhap.Visible = false;
            // 
            // ID_kho
            // 
            this.ID_kho.DataPropertyName = "ID_kho";
            this.ID_kho.HeaderText = "ID_kho";
            this.ID_kho.Name = "ID_kho";
            this.ID_kho.ReadOnly = true;
            this.ID_kho.Visible = false;
            // 
            // Ten_kho
            // 
            this.Ten_kho.DataPropertyName = "Ten_kho";
            this.Ten_kho.HeaderText = "Tên kho";
            this.Ten_kho.Name = "Ten_kho";
            this.Ten_kho.ReadOnly = true;
            // 
            // ngay_lap
            // 
            this.ngay_lap.DataPropertyName = "ngay_lap";
            this.ngay_lap.HeaderText = "Ngày lập";
            this.ngay_lap.Name = "ngay_lap";
            this.ngay_lap.ReadOnly = true;
            // 
            // Ly_do
            // 
            this.Ly_do.DataPropertyName = "Ly_do";
            this.Ly_do.HeaderText = "Lý do";
            this.Ly_do.Name = "Ly_do";
            this.Ly_do.ReadOnly = true;
            // 
            // isNhapNgoai
            // 
            this.isNhapNgoai.DataPropertyName = "isNhapNgoai";
            this.isNhapNgoai.HeaderText = "Nhập ngoài";
            this.isNhapNgoai.Name = "isNhapNgoai";
            this.isNhapNgoai.ReadOnly = true;
            // 
            // isCanTru
            // 
            this.isCanTru.DataPropertyName = "isCanTru";
            this.isCanTru.HeaderText = "Cấn trừ";
            this.isCanTru.Name = "isCanTru";
            this.isCanTru.ReadOnly = true;
            this.isCanTru.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isCanTru.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isCanTru.Visible = false;
            // 
            // isGoiDau
            // 
            this.isGoiDau.DataPropertyName = "isGoiDau";
            this.isGoiDau.HeaderText = "Gối đầu";
            this.isGoiDau.Name = "isGoiDau";
            this.isGoiDau.ReadOnly = true;
            this.isGoiDau.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isGoiDau.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isGoiDau.Visible = false;
            // 
            // Da_phan_kho
            // 
            this.Da_phan_kho.DataPropertyName = "Da_phan_kho";
            this.Da_phan_kho.HeaderText = "Đã xác nhận";
            this.Da_phan_kho.Name = "Da_phan_kho";
            this.Da_phan_kho.ReadOnly = true;
            this.Da_phan_kho.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Da_phan_kho.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmDanhSachPhieuNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 463);
            this.Controls.Add(this.gridDanhSachPhieuNhap);
            this.Name = "frmDanhSachPhieuNo";
            this.Text = "frmDanhSachPhieuNo";
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSachPhieuNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.DataGridView gridDanhSachPhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_phieu_nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kho_nhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_hoa_don;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cong_trinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dia_chi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_loai_phieu_nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kho_xuat_ra;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_phieu_nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_kho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_kho;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngay_lap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ly_do;
        private System.Windows.Forms.DataGridViewTextBoxColumn isNhapNgoai;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCanTru;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isGoiDau;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Da_phan_kho;
    }
}