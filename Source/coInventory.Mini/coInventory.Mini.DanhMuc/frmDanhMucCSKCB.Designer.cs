using coInventory.Mini.EntityClass;
namespace coInventory.Mini.DanhMuc
{
    partial class frmDanhMucCSKCB
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucCSKCB));
            this.grdMaster = new System.Windows.Forms.DataGridView();
            this.CSKCB_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCSKCB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCSKCB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSKCBBanDau = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.XepHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quy1Quy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoDuLieu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaCapTren = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.CSKCBBD = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCotDuLieu = new System.Windows.Forms.ComboBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnGetDM = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSua = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CSKCBBD)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdMaster
            // 
            this.grdMaster.AllowUserToAddRows = false;
            this.grdMaster.AllowUserToDeleteRows = false;
            this.grdMaster.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.grdMaster.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMaster.AutoGenerateColumns = false;
            this.grdMaster.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdMaster.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CSKCB_Id,
            this.MaCSKCB,
            this.TenCSKCB,
            this.CSKCBBanDau,
            this.XepHang,
            this.Active,
            this.DiaChi,
            this.MaTinh,
            this.Tuyen,
            this.Quy1Quy,
            this.CoDuLieu,
            this.MaCapTren});
            this.grdMaster.DataMember = "CSKCBBD";
            this.grdMaster.DataSource = this.dataSet1;
            this.grdMaster.Location = new System.Drawing.Point(0, 140);
            this.grdMaster.MultiSelect = false;
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ReadOnly = true;
            this.grdMaster.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdMaster.RowTemplate.Height = 30;
            this.grdMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMaster.Size = new System.Drawing.Size(1008, 588);
            this.grdMaster.TabIndex = 22;
            this.grdMaster.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grdMaster_RowPostPaint);
            // 
            // CSKCB_Id
            // 
            this.CSKCB_Id.DataPropertyName = "CSKCB_Id";
            this.CSKCB_Id.HeaderText = "ID";
            this.CSKCB_Id.Name = "CSKCB_Id";
            this.CSKCB_Id.ReadOnly = true;
            this.CSKCB_Id.Visible = false;
            // 
            // MaCSKCB
            // 
            this.MaCSKCB.DataPropertyName = "MaCSKCB";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.MaCSKCB.DefaultCellStyle = dataGridViewCellStyle3;
            this.MaCSKCB.HeaderText = "Mã CSKCB";
            this.MaCSKCB.Name = "MaCSKCB";
            this.MaCSKCB.ReadOnly = true;
            // 
            // TenCSKCB
            // 
            this.TenCSKCB.DataPropertyName = "TenCSKCB";
            this.TenCSKCB.HeaderText = "Tên CSKCB";
            this.TenCSKCB.Name = "TenCSKCB";
            this.TenCSKCB.ReadOnly = true;
            this.TenCSKCB.Width = 300;
            // 
            // CSKCBBanDau
            // 
            this.CSKCBBanDau.DataPropertyName = "CSKCBBanDau";
            this.CSKCBBanDau.HeaderText = "CSKCB BĐ";
            this.CSKCBBanDau.Name = "CSKCBBanDau";
            this.CSKCBBanDau.ReadOnly = true;
            this.CSKCBBanDau.Width = 60;
            // 
            // XepHang
            // 
            this.XepHang.DataPropertyName = "XepHang";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.XepHang.DefaultCellStyle = dataGridViewCellStyle4;
            this.XepHang.HeaderText = "Xếp Hạng";
            this.XepHang.Name = "XepHang";
            this.XepHang.ReadOnly = true;
            this.XepHang.Width = 70;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Còn Dùng";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Width = 70;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 250;
            // 
            // MaTinh
            // 
            this.MaTinh.DataPropertyName = "MaTinh";
            this.MaTinh.HeaderText = "Mã Tỉnh";
            this.MaTinh.Name = "MaTinh";
            this.MaTinh.ReadOnly = true;
            this.MaTinh.Width = 70;
            // 
            // Tuyen
            // 
            this.Tuyen.DataPropertyName = "Tuyen";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.Tuyen.DefaultCellStyle = dataGridViewCellStyle5;
            this.Tuyen.HeaderText = "Tuyến";
            this.Tuyen.Name = "Tuyen";
            this.Tuyen.ReadOnly = true;
            this.Tuyen.Width = 70;
            // 
            // Quy1Quy
            // 
            this.Quy1Quy.DataPropertyName = "Quy1Quy";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.Quy1Quy.DefaultCellStyle = dataGridViewCellStyle6;
            this.Quy1Quy.HeaderText = "Quy1Quy";
            this.Quy1Quy.Name = "Quy1Quy";
            this.Quy1Quy.ReadOnly = true;
            // 
            // CoDuLieu
            // 
            this.CoDuLieu.DataPropertyName = "CoDuLieu";
            this.CoDuLieu.HeaderText = "Có Dữ Liệu";
            this.CoDuLieu.Name = "CoDuLieu";
            this.CoDuLieu.ReadOnly = true;
            this.CoDuLieu.Width = 70;
            // 
            // MaCapTren
            // 
            this.MaCapTren.DataPropertyName = "MaCapTren";
            this.MaCapTren.HeaderText = "Mã Cấp Trên";
            this.MaCapTren.Name = "MaCapTren";
            this.MaCapTren.ReadOnly = true;
            this.MaCapTren.Width = 80;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.CSKCBBD});
            // 
            // CSKCBBD
            // 
            this.CSKCBBD.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn12});
            this.CSKCBBD.TableName = "CSKCBBD";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "CSKCB_Id";
            this.dataColumn1.ColumnName = "CSKCB_Id";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "MaCSKCB";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "TenCSKCB";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "CSKCBBanDau";
            this.dataColumn4.DataType = typeof(bool);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "XepHang";
            this.dataColumn5.DataType = typeof(int);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "Active";
            this.dataColumn6.DataType = typeof(bool);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "DiaChi";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "Tuyen";
            this.dataColumn8.DataType = typeof(int);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "Quy1Quy";
            this.dataColumn9.DataType = typeof(decimal);
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "CoDuLieu";
            this.dataColumn10.DataType = typeof(bool);
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "MaCapTren";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "MaTinh";
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Location = new System.Drawing.Point(311, 112);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(171, 22);
            this.txtGiaTri.TabIndex = 27;
            this.txtGiaTri.TextChanged += new System.EventHandler(this.txtGiaTri_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 14);
            this.label9.TabIndex = 25;
            this.label9.Text = "Giá trị";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 14);
            this.label4.TabIndex = 26;
            this.label4.Text = "Trường dữ liệu";
            // 
            // cboCotDuLieu
            // 
            this.cboCotDuLieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCotDuLieu.FormattingEnabled = true;
            this.cboCotDuLieu.Items.AddRange(new object[] {
            "Mã CSKB",
            "Tên CSKB"});
            this.cboCotDuLieu.Location = new System.Drawing.Point(99, 111);
            this.cboCotDuLieu.Name = "cboCotDuLieu";
            this.cboCotDuLieu.Size = new System.Drawing.Size(159, 22);
            this.cboCotDuLieu.TabIndex = 24;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnGetDM);
            this.pnlMenu.Controls.Add(this.btnDong);
            this.pnlMenu.Controls.Add(this.label7);
            this.pnlMenu.Controls.Add(this.btnThem);
            this.pnlMenu.Controls.Add(this.label1);
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
            this.pnlMenu.TabIndex = 28;
            // 
            // btnGetDM
            // 
            this.btnGetDM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetDM.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.down_omc;
            this.btnGetDM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGetDM.Location = new System.Drawing.Point(946, 10);
            this.btnGetDM.Name = "btnGetDM";
            this.btnGetDM.Size = new System.Drawing.Size(35, 35);
            this.btnGetDM.TabIndex = 2;
            this.btnGetDM.UseVisualStyleBackColor = true;
            this.btnGetDM.Click += new System.EventHandler(this.btnGetDM_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.close_gmc;
            this.btnDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDong.Location = new System.Drawing.Point(72, 10);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(50, 50);
            this.btnDong.TabIndex = 2;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "Đóng";
            // 
            // btnThem
            // 
            this.btnThem.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.addFile_omc;
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThem.Enabled = false;
            this.btnThem.Location = new System.Drawing.Point(132, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(50, 50);
            this.btnThem.TabIndex = 2;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Visible = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(932, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tải dữ liệu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "Làm mới";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Thêm";
            this.label5.Visible = false;
            // 
            // btnSua
            // 
            this.btnSua.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.edit_gmc;
            this.btnSua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(252, 10);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(50, 50);
            this.btnSua.TabIndex = 2;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.cancel_bmc1;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(192, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(50, 50);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Visible = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.refresh_omc;
            this.btnLamMoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLamMoi.Location = new System.Drawing.Point(12, 10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(50, 50);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Xóa";
            this.label3.Visible = false;
            // 
            // lblSua
            // 
            this.lblSua.AutoSize = true;
            this.lblSua.Location = new System.Drawing.Point(263, 61);
            this.lblSua.Name = "lblSua";
            this.lblSua.Size = new System.Drawing.Size(28, 14);
            this.lblSua.TabIndex = 3;
            this.lblSua.Text = "Sửa";
            this.lblSua.Visible = false;
            // 
            // frmDanhMucCSKCB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.txtGiaTri);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCotDuLieu);
            this.Controls.Add(this.grdMaster);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhMucCSKCB";
            this.Text = "frmDemo";
            this.Load += new System.EventHandler(this.frmDanhMucCSKCB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CSKCBBD)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdMaster;
        public System.Data.DataSet dataSet1;
        private System.Data.DataTable CSKCBBD;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCotDuLieu;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnGetDM;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSua;
        private System.Data.DataColumn dataColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSKCB_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCSKCB;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCSKCB;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CSKCBBanDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn XepHang;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quy1Quy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CoDuLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCapTren;


        //  private Control.UCFuntion ucFuntion1;

    }
}