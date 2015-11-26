namespace Inventory.QuanLyTonDauKy
{
    partial class frmTheKho
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiaDiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gridTheKho = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_phieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_chi_tiet_the_kho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_loai_phieu_nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_xuat_chung_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dien_giai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_nhap_xuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL_Nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL_Xuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL_Ton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Da_quyet_toan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Loai_phieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_The_kho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbMaVatTu = new System.Windows.Forms.ComboBox();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbChatLuong = new System.Windows.Forms.ComboBox();
            this.dtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.cbTenVatTu = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridTheKho)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(423, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "THẺ KHO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(847, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "DANH ĐIỂM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "TÊN VÀ QUY CÁCH VẬT TƯ";
            // 
            // txtDiaDiem
            // 
            this.txtDiaDiem.Location = new System.Drawing.Point(28, 197);
            this.txtDiaDiem.Multiline = true;
            this.txtDiaDiem.Name = "txtDiaDiem";
            this.txtDiaDiem.ReadOnly = true;
            this.txtDiaDiem.Size = new System.Drawing.Size(187, 43);
            this.txtDiaDiem.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "ĐỊA ĐIỂM";
            // 
            // gridTheKho
            // 
            this.gridTheKho.AllowUserToAddRows = false;
            this.gridTheKho.AllowUserToDeleteRows = false;
            this.gridTheKho.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.gridTheKho.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTheKho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTheKho.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTheKho.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTheKho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridTheKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTheKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Ma_phieu,
            this.ID_chi_tiet_the_kho,
            this.ID_loai_phieu_nhap,
            this.Ngay_xuat_chung_tu,
            this.Dien_giai,
            this.Ngay_nhap_xuat,
            this.SL_Nhap,
            this.SL_Xuat,
            this.SL_Ton,
            this.Da_quyet_toan,
            this.Loai_phieu,
            this.ID_The_kho});
            this.gridTheKho.Location = new System.Drawing.Point(4, 307);
            this.gridTheKho.MultiSelect = false;
            this.gridTheKho.Name = "gridTheKho";
            this.gridTheKho.ReadOnly = true;
            this.gridTheKho.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridTheKho.RowHeadersVisible = false;
            this.gridTheKho.RowTemplate.Height = 30;
            this.gridTheKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTheKho.Size = new System.Drawing.Size(1111, 243);
            this.gridTheKho.TabIndex = 49;
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // Ma_phieu
            // 
            this.Ma_phieu.DataPropertyName = "Ma_phieu";
            this.Ma_phieu.HeaderText = "Mã phiếu";
            this.Ma_phieu.Name = "Ma_phieu";
            this.Ma_phieu.ReadOnly = true;
            // 
            // ID_chi_tiet_the_kho
            // 
            this.ID_chi_tiet_the_kho.DataPropertyName = "ID_chi_tiet_the_kho";
            this.ID_chi_tiet_the_kho.HeaderText = "ID_chi_tiet_the_kho";
            this.ID_chi_tiet_the_kho.Name = "ID_chi_tiet_the_kho";
            this.ID_chi_tiet_the_kho.ReadOnly = true;
            this.ID_chi_tiet_the_kho.Visible = false;
            // 
            // ID_loai_phieu_nhap
            // 
            this.ID_loai_phieu_nhap.DataPropertyName = "ID_loai_phieu_nhap";
            this.ID_loai_phieu_nhap.HeaderText = "ID_loai_phieu_nhap";
            this.ID_loai_phieu_nhap.Name = "ID_loai_phieu_nhap";
            this.ID_loai_phieu_nhap.ReadOnly = true;
            this.ID_loai_phieu_nhap.Visible = false;
            // 
            // Ngay_xuat_chung_tu
            // 
            this.Ngay_xuat_chung_tu.DataPropertyName = "Ngay_xuat_chung_tu";
            this.Ngay_xuat_chung_tu.HeaderText = "Ngày, tháng";
            this.Ngay_xuat_chung_tu.Name = "Ngay_xuat_chung_tu";
            this.Ngay_xuat_chung_tu.ReadOnly = true;
            // 
            // Dien_giai
            // 
            this.Dien_giai.DataPropertyName = "Dien_giai";
            this.Dien_giai.HeaderText = "Diễn giải";
            this.Dien_giai.Name = "Dien_giai";
            this.Dien_giai.ReadOnly = true;
            // 
            // Ngay_nhap_xuat
            // 
            this.Ngay_nhap_xuat.DataPropertyName = "Ngay_nhap_xuat";
            this.Ngay_nhap_xuat.HeaderText = "Ngày nhập, xuất";
            this.Ngay_nhap_xuat.Name = "Ngay_nhap_xuat";
            this.Ngay_nhap_xuat.ReadOnly = true;
            // 
            // SL_Nhap
            // 
            this.SL_Nhap.DataPropertyName = "SL_Nhap";
            this.SL_Nhap.HeaderText = "SL Nhập";
            this.SL_Nhap.Name = "SL_Nhap";
            this.SL_Nhap.ReadOnly = true;
            // 
            // SL_Xuat
            // 
            this.SL_Xuat.DataPropertyName = "SL_Xuat";
            this.SL_Xuat.HeaderText = "SL Xuất";
            this.SL_Xuat.Name = "SL_Xuat";
            this.SL_Xuat.ReadOnly = true;
            // 
            // SL_Ton
            // 
            this.SL_Ton.DataPropertyName = "SL_Ton";
            this.SL_Ton.HeaderText = "SL Tồn";
            this.SL_Ton.Name = "SL_Ton";
            this.SL_Ton.ReadOnly = true;
            // 
            // Da_quyet_toan
            // 
            this.Da_quyet_toan.DataPropertyName = "Da_quyet_toan";
            this.Da_quyet_toan.HeaderText = "Da_quyet_toan";
            this.Da_quyet_toan.Name = "Da_quyet_toan";
            this.Da_quyet_toan.ReadOnly = true;
            this.Da_quyet_toan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Da_quyet_toan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Da_quyet_toan.Visible = false;
            // 
            // Loai_phieu
            // 
            this.Loai_phieu.DataPropertyName = "Loai_phieu";
            this.Loai_phieu.HeaderText = "Loai_phieu";
            this.Loai_phieu.Name = "Loai_phieu";
            this.Loai_phieu.ReadOnly = true;
            this.Loai_phieu.Visible = false;
            // 
            // ID_The_kho
            // 
            this.ID_The_kho.DataPropertyName = "ID_The_kho";
            this.ID_The_kho.HeaderText = "ID_The_kho";
            this.ID_The_kho.Name = "ID_The_kho";
            this.ID_The_kho.ReadOnly = true;
            this.ID_The_kho.Visible = false;
            // 
            // cbMaVatTu
            // 
            this.cbMaVatTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaVatTu.FormattingEnabled = true;
            this.cbMaVatTu.Location = new System.Drawing.Point(794, 124);
            this.cbMaVatTu.Name = "cbMaVatTu";
            this.cbMaVatTu.Size = new System.Drawing.Size(207, 50);
            this.cbMaVatTu.TabIndex = 50;
            this.cbMaVatTu.SelectedIndexChanged += new System.EventHandler(this.cbMaVatTu_SelectedIndexChanged);
            this.cbMaVatTu.SelectionChangeCommitted += new System.EventHandler(this.cbMaVatTu_SelectionChangeCommitted_1);
            this.cbMaVatTu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMaVatTu_KeyDown);
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(794, 198);
            this.txtDVT.Multiline = true;
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.ReadOnly = true;
            this.txtDVT.Size = new System.Drawing.Size(207, 34);
            this.txtDVT.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(808, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Đơn vị";
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnPrint);
            this.pnlMenu.Controls.Add(this.label35);
            this.pnlMenu.Controls.Add(this.btnHuy);
            this.pnlMenu.Controls.Add(this.label7);
            this.pnlMenu.Controls.Add(this.btnDong);
            this.pnlMenu.Controls.Add(this.label9);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1093, 95);
            this.pnlMenu.TabIndex = 53;
            this.pnlMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMenu_Paint);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.printOut_omc;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(78, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(58, 54);
            this.btnPrint.TabIndex = 97;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(89, 69);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(32, 14);
            this.label35.TabIndex = 98;
            this.label35.Text = "Print";
            // 
            // btnHuy
            // 
            this.btnHuy.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.search_bmc;
            this.btnHuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHuy.Location = new System.Drawing.Point(13, 12);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(58, 54);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 14);
            this.label7.TabIndex = 5;
            this.label7.Text = "Xem";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.close_gmc;
            this.btnDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDong.Location = new System.Drawing.Point(963, 13);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(58, 54);
            this.btnDong.TabIndex = 2;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(975, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 14);
            this.label9.TabIndex = 3;
            this.label9.Text = "Đóng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Chất lượng";
            // 
            // cbChatLuong
            // 
            this.cbChatLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChatLuong.FormattingEnabled = true;
            this.cbChatLuong.Location = new System.Drawing.Point(29, 127);
            this.cbChatLuong.Name = "cbChatLuong";
            this.cbChatLuong.Size = new System.Drawing.Size(187, 47);
            this.cbChatLuong.TabIndex = 56;
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTuNgay.Location = new System.Drawing.Point(353, 233);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(187, 20);
            this.dtTuNgay.TabIndex = 74;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(289, 239);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 75;
            this.label10.Text = "Từ ngày";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(546, 235);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 77;
            this.label11.Text = "Đến ngày";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(605, 233);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(187, 20);
            this.dtDenNgay.TabIndex = 76;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(791, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 78;
            this.label12.Text = "Mã vật tư";
            // 
            // cbTenVatTu
            // 
            this.cbTenVatTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTenVatTu.FormattingEnabled = true;
            this.cbTenVatTu.Location = new System.Drawing.Point(261, 165);
            this.cbTenVatTu.Name = "cbTenVatTu";
            this.cbTenVatTu.Size = new System.Drawing.Size(466, 50);
            this.cbTenVatTu.TabIndex = 79;
            this.cbTenVatTu.SelectedIndexChanged += new System.EventHandler(this.cbTenVatTu_SelectedIndexChanged);
            this.cbTenVatTu.SelectionChangeCommitted += new System.EventHandler(this.cbTenVatTu_SelectionChangeCommitted);
            // 
            // frmTheKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 553);
            this.Controls.Add(this.cbTenVatTu);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtDenNgay);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtTuNgay);
            this.Controls.Add(this.cbChatLuong);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.txtDVT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbMaVatTu);
            this.Controls.Add(this.gridTheKho);
            this.Controls.Add(this.txtDiaDiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmTheKho";
            this.Text = "frmTheKho";
            this.Load += new System.EventHandler(this.frmTheKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridTheKho)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiaDiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView gridTheKho;
        private System.Windows.Forms.ComboBox cbMaVatTu;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbChatLuong;
        private System.Windows.Forms.DateTimePicker dtTuNgay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtDenNgay;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_phieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_chi_tiet_the_kho;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_loai_phieu_nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_xuat_chung_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dien_giai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_nhap_xuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL_Nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL_Xuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL_Ton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Da_quyet_toan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai_phieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_The_kho;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cbTenVatTu;
    }
}