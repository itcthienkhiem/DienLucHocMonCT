namespace coInventory.Mini.DanhMuc
{
    partial class frmDanhMucPhongBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucPhongBan));
            this.grdDM_PhongBan = new System.Windows.Forms.DataGridView();
            this.PhongBan_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.TableDanhMucPhongBan = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnGetDM = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSua = new System.Windows.Forms.Label();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCotDuLieu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdDM_PhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableDanhMucPhongBan)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDM_PhongBan
            // 
            this.grdDM_PhongBan.AllowUserToAddRows = false;
            this.grdDM_PhongBan.AllowUserToDeleteRows = false;
            this.grdDM_PhongBan.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.grdDM_PhongBan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDM_PhongBan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDM_PhongBan.AutoGenerateColumns = false;
            this.grdDM_PhongBan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDM_PhongBan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDM_PhongBan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdDM_PhongBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDM_PhongBan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PhongBan_Id,
            this.MaPhongBan,
            this.TenPhongBan,
            this.LoaiPhongBan,
            this.activeDataGridViewCheckBoxColumn});
            this.grdDM_PhongBan.DataMember = "TableDanhMucPhongBan";
            this.grdDM_PhongBan.DataSource = this.dataSet1;
            this.grdDM_PhongBan.Location = new System.Drawing.Point(1, 127);
            this.grdDM_PhongBan.MultiSelect = false;
            this.grdDM_PhongBan.Name = "grdDM_PhongBan";
            this.grdDM_PhongBan.ReadOnly = true;
            this.grdDM_PhongBan.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdDM_PhongBan.RowTemplate.Height = 30;
            this.grdDM_PhongBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDM_PhongBan.Size = new System.Drawing.Size(1007, 602);
            this.grdDM_PhongBan.TabIndex = 7;
            this.grdDM_PhongBan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grdDM_ICD_RowPostPaint);
            // 
            // PhongBan_Id
            // 
            this.PhongBan_Id.DataPropertyName = "PhongBan_Id";
            this.PhongBan_Id.HeaderText = "PhongBan_Id";
            this.PhongBan_Id.Name = "PhongBan_Id";
            this.PhongBan_Id.ReadOnly = true;
            this.PhongBan_Id.Visible = false;
            this.PhongBan_Id.Width = 200;
            // 
            // MaPhongBan
            // 
            this.MaPhongBan.DataPropertyName = "MaPhongBan";
            this.MaPhongBan.HeaderText = "Mã Phòng Ban";
            this.MaPhongBan.Name = "MaPhongBan";
            this.MaPhongBan.ReadOnly = true;
            this.MaPhongBan.Width = 130;
            // 
            // TenPhongBan
            // 
            this.TenPhongBan.DataPropertyName = "TenPhongBan";
            this.TenPhongBan.HeaderText = "Tên Phòng Ban";
            this.TenPhongBan.Name = "TenPhongBan";
            this.TenPhongBan.ReadOnly = true;
            this.TenPhongBan.Width = 400;
            // 
            // LoaiPhongBan
            // 
            this.LoaiPhongBan.DataPropertyName = "LoaiPhongBan";
            this.LoaiPhongBan.HeaderText = "Loại Phòng Ban";
            this.LoaiPhongBan.Name = "LoaiPhongBan";
            this.LoaiPhongBan.ReadOnly = true;
            this.LoaiPhongBan.Visible = false;
            this.LoaiPhongBan.Width = 200;
            // 
            // activeDataGridViewCheckBoxColumn
            // 
            this.activeDataGridViewCheckBoxColumn.DataPropertyName = "Active";
            this.activeDataGridViewCheckBoxColumn.HeaderText = "Còn dùng";
            this.activeDataGridViewCheckBoxColumn.Name = "activeDataGridViewCheckBoxColumn";
            this.activeDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.TableDanhMucPhongBan});
            // 
            // TableDanhMucPhongBan
            // 
            this.TableDanhMucPhongBan.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
            this.TableDanhMucPhongBan.TableName = "TableDanhMucPhongBan";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "PhongBan_Id";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "MaPhongBan";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "TenPhongBan";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "LoaiPhongBan";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Active";
            this.dataColumn5.DataType = typeof(bool);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnGetDM);
            this.pnlMenu.Controls.Add(this.label1);
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
            this.pnlMenu.Size = new System.Drawing.Size(1008, 85);
            this.pnlMenu.TabIndex = 21;
            // 
            // btnGetDM
            // 
            this.btnGetDM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetDM.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.down_omc;
            this.btnGetDM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGetDM.Location = new System.Drawing.Point(961, 12);
            this.btnGetDM.Name = "btnGetDM";
            this.btnGetDM.Size = new System.Drawing.Size(35, 35);
            this.btnGetDM.TabIndex = 27;
            this.btnGetDM.UseVisualStyleBackColor = true;
            this.btnGetDM.Click += new System.EventHandler(this.btnGetDM_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(947, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 28;
            this.label1.Text = "Tải dữ liệu";
            // 
            // btnDong
            // 
            this.btnDong.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.close_gmc;
            this.btnDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDong.Location = new System.Drawing.Point(252, 10);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(50, 50);
            this.btnDong.TabIndex = 2;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(259, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "Đóng";
            // 
            // btnThem
            // 
            this.btnThem.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.addFile_omc;
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThem.Location = new System.Drawing.Point(12, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(50, 50);
            this.btnThem.TabIndex = 2;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "Làm mới";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Thêm";
            // 
            // btnSua
            // 
            this.btnSua.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.edit_gmc;
            this.btnSua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSua.Location = new System.Drawing.Point(132, 10);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(50, 50);
            this.btnSua.TabIndex = 2;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.cancel_bmc1;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXoa.Location = new System.Drawing.Point(72, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(50, 50);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.refresh_omc;
            this.btnLamMoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLamMoi.Location = new System.Drawing.Point(192, 10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(50, 50);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Xóa";
            // 
            // lblSua
            // 
            this.lblSua.AutoSize = true;
            this.lblSua.Location = new System.Drawing.Point(142, 61);
            this.lblSua.Name = "lblSua";
            this.lblSua.Size = new System.Drawing.Size(28, 14);
            this.lblSua.TabIndex = 3;
            this.lblSua.Text = "Sửa";
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Location = new System.Drawing.Point(318, 94);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(171, 22);
            this.txtGiaTri.TabIndex = 26;
            this.txtGiaTri.TextChanged += new System.EventHandler(this.txtGiaTri_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(274, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 14);
            this.label9.TabIndex = 24;
            this.label9.Text = "Giá trị";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "Trường dữ liệu";
            // 
            // cboCotDuLieu
            // 
            this.cboCotDuLieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCotDuLieu.FormattingEnabled = true;
            this.cboCotDuLieu.Items.AddRange(new object[] {
            "Mã Phòng Ban",
            "Tên  Phòng Ban"});
            this.cboCotDuLieu.Location = new System.Drawing.Point(106, 93);
            this.cboCotDuLieu.Name = "cboCotDuLieu";
            this.cboCotDuLieu.Size = new System.Drawing.Size(159, 22);
            this.cboCotDuLieu.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 14);
            this.label2.TabIndex = 22;
            // 
            // frmDanhMucPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.txtGiaTri);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCotDuLieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.grdDM_PhongBan);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhMucPhongBan";
            this.Text = "frmDanhMucICD";
            this.Load += new System.EventHandler(this.frmDanhMucPhongBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDM_PhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableDanhMucPhongBan)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDM_PhongBan;
        private System.Data.DataTable TableDanhMucPhongBan;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        public System.Data.DataSet dataSet1;
        private System.Windows.Forms.Panel pnlMenu;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn PhongBan_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiPhongBan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCotDuLieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetDM;
        private System.Windows.Forms.Label label1;
    }
}