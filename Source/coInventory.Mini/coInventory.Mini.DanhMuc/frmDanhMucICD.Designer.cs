namespace coInventory.Mini.DanhMuc
{
    partial class frmDanhMucICD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucICD));
            this.grdDM_ICD = new System.Windows.Forms.DataGridView();
            this.ICD_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaICD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenICD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgoaiDinhSuat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.TableDanhMucICD = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
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
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCotDuLieu = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdDM_ICD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableDanhMucICD)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDM_ICD
            // 
            this.grdDM_ICD.AllowUserToAddRows = false;
            this.grdDM_ICD.AllowUserToDeleteRows = false;
            this.grdDM_ICD.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.grdDM_ICD.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDM_ICD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDM_ICD.AutoGenerateColumns = false;
            this.grdDM_ICD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDM_ICD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDM_ICD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdDM_ICD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDM_ICD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ICD_Id,
            this.MaICD,
            this.TenICD,
            this.NgoaiDinhSuat,
            this.Active});
            this.grdDM_ICD.DataMember = "TableDanhMucICD";
            this.grdDM_ICD.DataSource = this.dataSet1;
            this.grdDM_ICD.Location = new System.Drawing.Point(1, 127);
            this.grdDM_ICD.MultiSelect = false;
            this.grdDM_ICD.Name = "grdDM_ICD";
            this.grdDM_ICD.ReadOnly = true;
            this.grdDM_ICD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdDM_ICD.RowTemplate.Height = 30;
            this.grdDM_ICD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDM_ICD.Size = new System.Drawing.Size(783, 434);
            this.grdDM_ICD.TabIndex = 7;
            this.grdDM_ICD.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grdDM_ICD_RowPostPaint);
            // 
            // ICD_Id
            // 
            this.ICD_Id.DataPropertyName = "ICD_Id";
            this.ICD_Id.HeaderText = "ICD_Id";
            this.ICD_Id.Name = "ICD_Id";
            this.ICD_Id.ReadOnly = true;
            this.ICD_Id.Visible = false;
            // 
            // MaICD
            // 
            this.MaICD.DataPropertyName = "MaICD";
            this.MaICD.HeaderText = "Mã ICD";
            this.MaICD.Name = "MaICD";
            this.MaICD.ReadOnly = true;
            // 
            // TenICD
            // 
            this.TenICD.DataPropertyName = "TenICD";
            this.TenICD.HeaderText = "Tên ICD";
            this.TenICD.Name = "TenICD";
            this.TenICD.ReadOnly = true;
            this.TenICD.Width = 400;
            // 
            // NgoaiDinhSuat
            // 
            this.NgoaiDinhSuat.DataPropertyName = "NgoaiDinhSuat";
            this.NgoaiDinhSuat.HeaderText = "Ngoài Định Suất";
            this.NgoaiDinhSuat.Name = "NgoaiDinhSuat";
            this.NgoaiDinhSuat.ReadOnly = true;
            this.NgoaiDinhSuat.Width = 120;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Còn Dùng";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Width = 80;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.TableDanhMucICD});
            // 
            // TableDanhMucICD
            // 
            this.TableDanhMucICD.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
            this.TableDanhMucICD.TableName = "TableDanhMucICD";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "ICD_Id";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "MaICD";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "TenICD";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "NgoaiDinhSuat";
            this.dataColumn4.DataType = typeof(bool);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Active";
            this.dataColumn5.DataType = typeof(bool);
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
            this.pnlMenu.Size = new System.Drawing.Size(784, 85);
            this.pnlMenu.TabIndex = 21;
            // 
            // btnGetDM
            // 
            this.btnGetDM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetDM.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.down_omc;
            this.btnGetDM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGetDM.Location = new System.Drawing.Point(722, 10);
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
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(708, 47);
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
            this.label5.Location = new System.Drawing.Point(140, 61);
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
            this.label3.Location = new System.Drawing.Point(203, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Xóa";
            this.label3.Visible = false;
            // 
            // lblSua
            // 
            this.lblSua.AutoSize = true;
            this.lblSua.Location = new System.Drawing.Point(262, 61);
            this.lblSua.Name = "lblSua";
            this.lblSua.Size = new System.Drawing.Size(28, 14);
            this.lblSua.TabIndex = 3;
            this.lblSua.Text = "Sửa";
            this.lblSua.Visible = false;
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Location = new System.Drawing.Point(314, 92);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(171, 22);
            this.txtGiaTri.TabIndex = 26;
            this.txtGiaTri.TextChanged += new System.EventHandler(this.txtGiaTri_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 14);
            this.label9.TabIndex = 24;
            this.label9.Text = "Giá trị";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 95);
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
            "Mã ICD",
            "Tên ICD"});
            this.cboCotDuLieu.Location = new System.Drawing.Point(102, 91);
            this.cboCotDuLieu.Name = "cboCotDuLieu";
            this.cboCotDuLieu.Size = new System.Drawing.Size(159, 22);
            this.cboCotDuLieu.TabIndex = 23;
            // 
            // frmDanhMucICD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.txtGiaTri);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCotDuLieu);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.grdDM_ICD);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhMucICD";
            this.Text = "frmDanhMucICD";
            this.Load += new System.EventHandler(this.frmDanhMucICD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDM_ICD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableDanhMucICD)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDM_ICD;
        private System.Data.DataTable TableDanhMucICD;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        public System.Data.DataSet dataSet1;
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
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCotDuLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ICD_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaICD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenICD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NgoaiDinhSuat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
    }
}