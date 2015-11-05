namespace Inventory.NhapXuat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridDanhSachPhieuNhap = new System.Windows.Forms.DataGridView();
            this.Ma_phieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_kho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngay_lap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ly_do = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isGoiDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isNhapNgoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCanTru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSua = new System.Windows.Forms.Label();
            this.rdoDaDuyet = new System.Windows.Forms.RadioButton();
            this.rdoChuaDuyet = new System.Windows.Forms.RadioButton();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.rdoAllGird = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbKho = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnTruNo = new System.Windows.Forms.Button();
            this.btnDuyetPhieu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSachPhieuNhap)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.Ma_phieu,
            this.Ten_kho,
            this.ngay_lap,
            this.Ly_do,
            this.isGoiDau,
            this.isNhapNgoai,
            this.isCanTru});
            this.gridDanhSachPhieuNhap.Location = new System.Drawing.Point(1, 193);
            this.gridDanhSachPhieuNhap.MultiSelect = false;
            this.gridDanhSachPhieuNhap.Name = "gridDanhSachPhieuNhap";
            this.gridDanhSachPhieuNhap.ReadOnly = true;
            this.gridDanhSachPhieuNhap.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridDanhSachPhieuNhap.RowHeadersVisible = false;
            this.gridDanhSachPhieuNhap.RowTemplate.Height = 30;
            this.gridDanhSachPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDanhSachPhieuNhap.Size = new System.Drawing.Size(849, 264);
            this.gridDanhSachPhieuNhap.TabIndex = 52;
            this.gridDanhSachPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridgridDanhSachPhieuNhap_CellClick);
            this.gridDanhSachPhieuNhap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDanhSachPhieuNhap_CellContentClick);
            // 
            // Ma_phieu
            // 
            this.Ma_phieu.DataPropertyName = "Ma_phieu";
            this.Ma_phieu.HeaderText = "Mã phiếu";
            this.Ma_phieu.Name = "Ma_phieu";
            this.Ma_phieu.ReadOnly = true;
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
            // isGoiDau
            // 
            this.isGoiDau.DataPropertyName = "isGoiDau";
            this.isGoiDau.HeaderText = "Gối đầu";
            this.isGoiDau.Name = "isGoiDau";
            this.isGoiDau.ReadOnly = true;
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
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.label8);
            this.pnlMenu.Controls.Add(this.btnTruNo);
            this.pnlMenu.Controls.Add(this.btnDuyetPhieu);
            this.pnlMenu.Controls.Add(this.label1);
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
            this.pnlMenu.Size = new System.Drawing.Size(850, 92);
            this.pnlMenu.TabIndex = 53;
            this.pnlMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMenu_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Duyệt Phiếu";
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
            this.label7.Location = new System.Drawing.Point(798, 62);
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
            // rdoDaDuyet
            // 
            this.rdoDaDuyet.AutoSize = true;
            this.rdoDaDuyet.Location = new System.Drawing.Point(113, 72);
            this.rdoDaDuyet.Name = "rdoDaDuyet";
            this.rdoDaDuyet.Size = new System.Drawing.Size(70, 17);
            this.rdoDaDuyet.TabIndex = 54;
            this.rdoDaDuyet.Text = "Đã Duyệt";
            this.rdoDaDuyet.UseVisualStyleBackColor = true;
            // 
            // rdoChuaDuyet
            // 
            this.rdoChuaDuyet.AutoSize = true;
            this.rdoChuaDuyet.Location = new System.Drawing.Point(201, 72);
            this.rdoChuaDuyet.Name = "rdoChuaDuyet";
            this.rdoChuaDuyet.Size = new System.Drawing.Size(81, 17);
            this.rdoChuaDuyet.TabIndex = 55;
            this.rdoChuaDuyet.Text = "Chưa Duyệt";
            this.rdoChuaDuyet.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(318, 19);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 48);
            this.btnTimKiem.TabIndex = 56;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // rdoAllGird
            // 
            this.rdoAllGird.AutoSize = true;
            this.rdoAllGird.Checked = true;
            this.rdoAllGird.Location = new System.Drawing.Point(50, 72);
            this.rdoAllGird.Name = "rdoAllGird";
            this.rdoAllGird.Size = new System.Drawing.Size(57, 17);
            this.rdoAllGird.TabIndex = 57;
            this.rdoAllGird.TabStop = true;
            this.rdoAllGird.Text = "Tất Cả";
            this.rdoAllGird.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbbKho);
            this.groupBox1.Controls.Add(this.rdoDaDuyet);
            this.groupBox1.Controls.Add(this.rdoChuaDuyet);
            this.groupBox1.Controls.Add(this.rdoAllGird);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Location = new System.Drawing.Point(9, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(782, 89);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Kho";
            // 
            // cbbKho
            // 
            this.cbbKho.FormattingEnabled = true;
            this.cbbKho.Location = new System.Drawing.Point(75, 19);
            this.cbbKho.Name = "cbbKho";
            this.cbbKho.Size = new System.Drawing.Size(213, 21);
            this.cbbKho.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(425, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 14);
            this.label8.TabIndex = 9;
            this.label8.Text = "Trừ nợ";
            // 
            // btnTruNo
            // 
            this.btnTruNo.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.Calendar;
            this.btnTruNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTruNo.Location = new System.Drawing.Point(424, 12);
            this.btnTruNo.Name = "btnTruNo";
            this.btnTruNo.Size = new System.Drawing.Size(50, 50);
            this.btnTruNo.TabIndex = 8;
            this.btnTruNo.UseVisualStyleBackColor = true;
            this.btnTruNo.Click += new System.EventHandler(this.btnTruNo_Click);
            // 
            // btnDuyetPhieu
            // 
            this.btnDuyetPhieu.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.up_bmc;
            this.btnDuyetPhieu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDuyetPhieu.Location = new System.Drawing.Point(363, 12);
            this.btnDuyetPhieu.Name = "btnDuyetPhieu";
            this.btnDuyetPhieu.Size = new System.Drawing.Size(50, 50);
            this.btnDuyetPhieu.TabIndex = 6;
            this.btnDuyetPhieu.UseVisualStyleBackColor = true;
            this.btnDuyetPhieu.Click += new System.EventHandler(this.btnDuyetPhieu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.close_bmc;
            this.btnHuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHuy.Location = new System.Drawing.Point(297, 12);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(50, 50);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.EnabledChanged += new System.EventHandler(this.btnHuy_EnabledChanged);
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
            this.btnLuu.EnabledChanged += new System.EventHandler(this.btnLuu_EnabledChanged);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.close_bmc;
            this.btnDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDong.Location = new System.Drawing.Point(788, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(50, 50);
            this.btnDong.TabIndex = 2;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
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
            this.btnXoa.EnabledChanged += new System.EventHandler(this.btnXoa_EnabledChanged);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
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
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // frmDanhSachPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 458);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.gridDanhSachPhieuNhap);
            this.Name = "frmDanhSachPhieuNhap";
            this.Text = "frmDanhSachPhieuNhap";
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSachPhieuNhap)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.RadioButton rdoDaDuyet;
        private System.Windows.Forms.RadioButton rdoChuaDuyet;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.RadioButton rdoAllGird;
        private System.Windows.Forms.Button btnDuyetPhieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_phieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_kho;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngay_lap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ly_do;
        private System.Windows.Forms.DataGridViewTextBoxColumn isGoiDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn isNhapNgoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn isCanTru;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnTruNo;

    }
}