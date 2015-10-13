namespace Inventory.QuanLyTonDauKy
{
    partial class frmNhapTonDauKy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cbTenVatTu = new System.Windows.Forms.ComboBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblSua = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnCheckMaVatTu = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbMaVatTu = new System.Windows.Forms.ComboBox();
            this.dtNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.gridTonDauKy = new System.Windows.Forms.DataGridView();
            this.Ten_kho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.So_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbKhoNhap = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTonDauKy)).BeginInit();
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
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Ma_vat_tu";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hủy bỏ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(310, 117);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 14);
            this.label22.TabIndex = 112;
            this.label22.Text = "Mã vật tư";
            // 
            // cbTenVatTu
            // 
            this.cbTenVatTu.FormattingEnabled = true;
            this.cbTenVatTu.Location = new System.Drawing.Point(401, 143);
            this.cbTenVatTu.Name = "cbTenVatTu";
            this.cbTenVatTu.Size = new System.Drawing.Size(198, 22);
            this.cbTenVatTu.TabIndex = 110;
            this.cbTenVatTu.SelectionChangeCommitted += new System.EventHandler(this.cbTenVatTu_SelectionChangeCommitted);
            // 
            // btnHuy
            // 
            this.btnHuy.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.cancel_bmc;
            this.btnHuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHuy.Location = new System.Drawing.Point(289, 12);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(50, 50);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.save_bmc;
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLuu.Location = new System.Drawing.Point(233, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(50, 50);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(245, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 14);
            this.label10.TabIndex = 3;
            this.label10.Text = "Lưu";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.close_bmc;
            this.btnDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDong.Location = new System.Drawing.Point(923, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(50, 50);
            this.btnDong.TabIndex = 2;
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.addFile_omc;
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThem.Location = new System.Drawing.Point(9, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(50, 50);
            this.btnThem.TabIndex = 2;
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "Làm mới";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Thêm";
            // 
            // btnSua
            // 
            this.btnSua.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.edit_gmc;
            this.btnSua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSua.Location = new System.Drawing.Point(121, 12);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(50, 50);
            this.btnSua.TabIndex = 2;
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.refresh_omc;
            this.btnLamMoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLamMoi.Location = new System.Drawing.Point(177, 12);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(50, 50);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // lblSua
            // 
            this.lblSua.AutoSize = true;
            this.lblSua.Location = new System.Drawing.Point(129, 67);
            this.lblSua.Name = "lblSua";
            this.lblSua.Size = new System.Drawing.Size(28, 14);
            this.lblSua.TabIndex = 3;
            this.lblSua.Text = "Sửa";
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnXoa);
            this.pnlMenu.Controls.Add(this.label11);
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
            this.pnlMenu.Controls.Add(this.btnLamMoi);
            this.pnlMenu.Controls.Add(this.lblSua);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(985, 99);
            this.pnlMenu.TabIndex = 95;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(931, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Đóng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1324, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "Đóng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(681, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 14);
            this.label8.TabIndex = 97;
            this.label8.Text = "Số lượng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(681, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 14);
            this.label4.TabIndex = 96;
            this.label4.Text = "Ngày lập";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(772, 143);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(199, 22);
            this.txtSoLuong.TabIndex = 98;
            // 
            // btnCheckMaVatTu
            // 
            this.btnCheckMaVatTu.Enabled = false;
            this.btnCheckMaVatTu.Location = new System.Drawing.Point(563, 112);
            this.btnCheckMaVatTu.Name = "btnCheckMaVatTu";
            this.btnCheckMaVatTu.Size = new System.Drawing.Size(36, 25);
            this.btnCheckMaVatTu.TabIndex = 105;
            this.btnCheckMaVatTu.Text = "...";
            this.btnCheckMaVatTu.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(308, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 14);
            this.label9.TabIndex = 94;
            this.label9.Text = "Tên vật tư";
            // 
            // cbMaVatTu
            // 
            this.cbMaVatTu.FormattingEnabled = true;
            this.cbMaVatTu.Location = new System.Drawing.Point(402, 114);
            this.cbMaVatTu.Name = "cbMaVatTu";
            this.cbMaVatTu.Size = new System.Drawing.Size(153, 22);
            this.cbMaVatTu.TabIndex = 111;
            this.cbMaVatTu.SelectionChangeCommitted += new System.EventHandler(this.cbMaVatTu_SelectionChangeCommitted);
            // 
            // dtNgayNhap
            // 
            this.dtNgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dtNgayNhap.Enabled = false;
            this.dtNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayNhap.Location = new System.Drawing.Point(773, 115);
            this.dtNgayNhap.Name = "dtNgayNhap";
            this.dtNgayNhap.Size = new System.Drawing.Size(198, 22);
            this.dtNgayNhap.TabIndex = 109;
            // 
            // gridTonDauKy
            // 
            this.gridTonDauKy.AllowUserToAddRows = false;
            this.gridTonDauKy.AllowUserToDeleteRows = false;
            this.gridTonDauKy.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue;
            this.gridTonDauKy.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gridTonDauKy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTonDauKy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTonDauKy.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTonDauKy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.gridTonDauKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTonDauKy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ten_kho,
            this.Ma_vat_tu,
            this.Ten_vat_tu,
            this.So_luong});
            this.gridTonDauKy.Location = new System.Drawing.Point(0, 185);
            this.gridTonDauKy.MultiSelect = false;
            this.gridTonDauKy.Name = "gridTonDauKy";
            this.gridTonDauKy.ReadOnly = true;
            this.gridTonDauKy.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridTonDauKy.RowHeadersVisible = false;
            this.gridTonDauKy.RowTemplate.Height = 30;
            this.gridTonDauKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTonDauKy.Size = new System.Drawing.Size(985, 260);
            this.gridTonDauKy.TabIndex = 113;
            this.gridTonDauKy.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTonDauKy_CellClick);
            // 
            // Ten_kho
            // 
            this.Ten_kho.DataPropertyName = "Ten_kho";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Ten_kho.DefaultCellStyle = dataGridViewCellStyle12;
            this.Ten_kho.HeaderText = "Tên kho";
            this.Ten_kho.Name = "Ten_kho";
            this.Ten_kho.ReadOnly = true;
            // 
            // Ma_vat_tu
            // 
            this.Ma_vat_tu.DataPropertyName = "Ma_vat_tu";
            this.Ma_vat_tu.HeaderText = "Mã vật tư";
            this.Ma_vat_tu.Name = "Ma_vat_tu";
            this.Ma_vat_tu.ReadOnly = true;
            this.Ma_vat_tu.Width = 120;
            // 
            // Ten_vat_tu
            // 
            this.Ten_vat_tu.DataPropertyName = "Ten_vat_tu";
            this.Ten_vat_tu.HeaderText = "Tên vật tư";
            this.Ten_vat_tu.Name = "Ten_vat_tu";
            this.Ten_vat_tu.ReadOnly = true;
            // 
            // So_luong
            // 
            this.So_luong.DataPropertyName = "So_luong";
            this.So_luong.HeaderText = "Số lượng";
            this.So_luong.Name = "So_luong";
            this.So_luong.ReadOnly = true;
            // 
            // cbKhoNhap
            // 
            this.cbKhoNhap.FormattingEnabled = true;
            this.cbKhoNhap.Location = new System.Drawing.Point(75, 113);
            this.cbKhoNhap.Name = "cbKhoNhap";
            this.cbKhoNhap.Size = new System.Drawing.Size(152, 22);
            this.cbKhoNhap.TabIndex = 115;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 14);
            this.label3.TabIndex = 114;
            this.label3.Text = "Tên kho";
            // 
            // btnXoa
            // 
            this.btnXoa.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.cancel_gmc;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXoa.Location = new System.Drawing.Point(65, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(50, 50);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(77, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 14);
            this.label11.TabIndex = 9;
            this.label11.Text = "Xóa";
            // 
            // frmNhapTonDauKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 445);
            this.Controls.Add(this.cbKhoNhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridTonDauKy);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.cbTenVatTu);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.btnCheckMaVatTu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbMaVatTu);
            this.Controls.Add(this.dtNgayNhap);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmNhapTonDauKy";
            this.Text = "frmNhapTonDauKy";
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTonDauKy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cbTenVatTu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblSua;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnCheckMaVatTu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbMaVatTu;
        private System.Windows.Forms.DateTimePicker dtNgayNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridTonDauKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_kho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_luong;
        private System.Windows.Forms.ComboBox cbKhoNhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label label11;
    }
}