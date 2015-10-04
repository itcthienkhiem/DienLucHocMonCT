namespace Inventory.DanhMuc
{
    partial class frmDMVatTu
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
            this.txtTenVatTu = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDonViTinh = new System.Windows.Forms.ComboBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSua = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gridDMVatTu = new System.Windows.Forms.DataGridView();
            this.Ma_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_don_vi_tinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mo_ta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.txtMaVatTu = new System.Windows.Forms.TextBox();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDMVatTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTenVatTu
            // 
            this.txtTenVatTu.Location = new System.Drawing.Point(342, 98);
            this.txtTenVatTu.Name = "txtTenVatTu";
            this.txtTenVatTu.Size = new System.Drawing.Size(171, 22);
            this.txtTenVatTu.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(269, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 14);
            this.label9.TabIndex = 33;
            this.label9.Text = "Tên vật tư";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 14);
            this.label4.TabIndex = 34;
            this.label4.Text = "Mã vật tư";
            // 
            // cboDonViTinh
            // 
            this.cboDonViTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonViTinh.FormattingEnabled = true;
            this.cboDonViTinh.Items.AddRange(new object[] {
            "",
            "Cái",
            "Bộ",
            "Mét"});
            this.cboDonViTinh.Location = new System.Drawing.Point(595, 99);
            this.cboDonViTinh.Name = "cboDonViTinh";
            this.cboDonViTinh.Size = new System.Drawing.Size(159, 22);
            this.cboDonViTinh.TabIndex = 32;
            this.cboDonViTinh.SelectionChangeCommitted += new System.EventHandler(this.cboDonViTinh_SelectionChangeCommitted);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnDong);
            this.pnlMenu.Controls.Add(this.label11);
            this.pnlMenu.Controls.Add(this.btnLuu);
            this.pnlMenu.Controls.Add(this.label10);
            this.pnlMenu.Controls.Add(this.btnHuyBo);
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
            this.pnlMenu.Size = new System.Drawing.Size(780, 92);
            this.pnlMenu.TabIndex = 36;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.close_gmc;
            this.btnDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDong.Location = new System.Drawing.Point(718, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(50, 50);
            this.btnDong.TabIndex = 4;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(728, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 14);
            this.label11.TabIndex = 5;
            this.label11.Text = "Đóng";
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.save_bmc;
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLuu.Location = new System.Drawing.Point(662, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(50, 50);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(672, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 14);
            this.label10.TabIndex = 3;
            this.label10.Text = "Lưu";
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.close_bmc;
            this.btnHuyBo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHuyBo.Location = new System.Drawing.Point(242, 11);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(50, 50);
            this.btnHuyBo.TabIndex = 2;
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.EnabledChanged += new System.EventHandler(this.btnHuyBo_EnabledChanged);
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(246, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "Hủy bỏ";
            // 
            // btnThem
            // 
            this.btnThem.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.addFile_omc;
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThem.Location = new System.Drawing.Point(9, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(50, 50);
            this.btnThem.TabIndex = 2;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.EnabledChanged += new System.EventHandler(this.btnThem_EnabledChanged);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
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
            // btnSua
            // 
            this.btnSua.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.edit_gmc;
            this.btnSua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSua.Location = new System.Drawing.Point(129, 10);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(50, 50);
            this.btnSua.TabIndex = 2;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.EnabledChanged += new System.EventHandler(this.btnSua_EnabledChanged);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.cancel_gmc;
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
            this.btnLamMoi.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.refresh_omc;
            this.btnLamMoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLamMoi.Location = new System.Drawing.Point(185, 10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(50, 50);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.EnabledChanged += new System.EventHandler(this.btnLamMoi_EnabledChanged);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(523, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 38;
            this.label2.Text = "Đơn vị tính";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(72, 126);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(695, 57);
            this.txtMoTa.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 14);
            this.label8.TabIndex = 40;
            this.label8.Text = "Mô tả";
            // 
            // gridDMVatTu
            // 
            this.gridDMVatTu.AllowUserToAddRows = false;
            this.gridDMVatTu.AllowUserToDeleteRows = false;
            this.gridDMVatTu.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.gridDMVatTu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDMVatTu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDMVatTu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDMVatTu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDMVatTu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridDMVatTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDMVatTu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_vat_tu,
            this.Ten_vat_tu,
            this.Ten_don_vi_tinh,
            this.Mo_ta});
            this.gridDMVatTu.Location = new System.Drawing.Point(9, 189);
            this.gridDMVatTu.MultiSelect = false;
            this.gridDMVatTu.Name = "gridDMVatTu";
            this.gridDMVatTu.ReadOnly = true;
            this.gridDMVatTu.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridDMVatTu.RowHeadersVisible = false;
            this.gridDMVatTu.RowTemplate.Height = 30;
            this.gridDMVatTu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDMVatTu.Size = new System.Drawing.Size(759, 215);
            this.gridDMVatTu.TabIndex = 42;
            this.gridDMVatTu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDMVatTu_CellClick);
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
            this.Ten_vat_tu.Width = 120;
            // 
            // Ten_don_vi_tinh
            // 
            this.Ten_don_vi_tinh.DataPropertyName = "Ten_don_vi_tinh";
            this.Ten_don_vi_tinh.HeaderText = "Đơn vị tính";
            this.Ten_don_vi_tinh.Name = "Ten_don_vi_tinh";
            this.Ten_don_vi_tinh.ReadOnly = true;
            // 
            // Mo_ta
            // 
            this.Mo_ta.DataPropertyName = "Mo_ta";
            this.Mo_ta.HeaderText = "Mô tả";
            this.Mo_ta.Name = "Mo_ta";
            this.Mo_ta.ReadOnly = true;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // txtMaVatTu
            // 
            this.txtMaVatTu.Location = new System.Drawing.Point(72, 98);
            this.txtMaVatTu.Name = "txtMaVatTu";
            this.txtMaVatTu.Size = new System.Drawing.Size(171, 22);
            this.txtMaVatTu.TabIndex = 35;
            // 
            // frmDMVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 425);
            this.Controls.Add(this.gridDMVatTu);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.txtMaVatTu);
            this.Controls.Add(this.txtTenVatTu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboDonViTinh);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDMVatTu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh Mục Vật Tư";
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDMVatTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTenVatTu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDonViTinh;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView gridDMVatTu;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_don_vi_tinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mo_ta;
        private System.Windows.Forms.TextBox txtMaVatTu;

    }
}