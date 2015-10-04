namespace Inventory.DanhMuc
{
    partial class frmDMNhanVien
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
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataSet1 = new System.Data.DataSet();
            this.gridDMNhanVien = new System.Windows.Forms.DataGridView();
            this.ID_nhan_vien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_nhan_vien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_kho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trang_thai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboTenKho = new System.Windows.Forms.ComboBox();
            this.cbTrangThai = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDMNhanVien)).BeginInit();
            this.SuspendLayout();
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
            this.pnlMenu.Size = new System.Drawing.Size(908, 92);
            this.pnlMenu.TabIndex = 37;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.close_gmc;
            this.btnDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDong.Location = new System.Drawing.Point(846, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(50, 50);
            this.btnDong.TabIndex = 6;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(856, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 14);
            this.label11.TabIndex = 7;
            this.label11.Text = "Đóng";
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.save_bmc;
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLuu.Location = new System.Drawing.Point(790, 12);
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
            this.label10.Location = new System.Drawing.Point(800, 62);
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
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 32F);
            this.label3.Location = new System.Drawing.Point(396, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 52);
            this.label3.TabIndex = 3;
            this.label3.Text = "Không dùng";
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
            this.label2.Location = new System.Drawing.Point(334, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 44;
            this.label2.Text = "Tên Kho";
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Location = new System.Drawing.Point(109, 99);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(171, 22);
            this.txtTenNhanVien.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 14);
            this.label9.TabIndex = 41;
            this.label9.Text = "Tên Nhân Viên";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // gridDMNhanVien
            // 
            this.gridDMNhanVien.AllowUserToAddRows = false;
            this.gridDMNhanVien.AllowUserToDeleteRows = false;
            this.gridDMNhanVien.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.gridDMNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDMNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDMNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDMNhanVien.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDMNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridDMNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDMNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_nhan_vien,
            this.Ten_nhan_vien,
            this.Ten_kho,
            this.Trang_thai});
            this.gridDMNhanVien.Location = new System.Drawing.Point(9, 127);
            this.gridDMNhanVien.MultiSelect = false;
            this.gridDMNhanVien.Name = "gridDMNhanVien";
            this.gridDMNhanVien.ReadOnly = true;
            this.gridDMNhanVien.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridDMNhanVien.RowHeadersVisible = false;
            this.gridDMNhanVien.RowTemplate.Height = 30;
            this.gridDMNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDMNhanVien.Size = new System.Drawing.Size(887, 271);
            this.gridDMNhanVien.TabIndex = 46;
            // 
            // ID_nhan_vien
            // 
            this.ID_nhan_vien.DataPropertyName = "ID_nhan_vien";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ID_nhan_vien.DefaultCellStyle = dataGridViewCellStyle3;
            this.ID_nhan_vien.HeaderText = "ID Nhân Viên";
            this.ID_nhan_vien.Name = "ID_nhan_vien";
            this.ID_nhan_vien.ReadOnly = true;
            // 
            // Ten_nhan_vien
            // 
            this.Ten_nhan_vien.DataPropertyName = "Ten_nhan_vien";
            this.Ten_nhan_vien.HeaderText = "Tên nhân viên";
            this.Ten_nhan_vien.Name = "Ten_nhan_vien";
            this.Ten_nhan_vien.ReadOnly = true;
            this.Ten_nhan_vien.Width = 160;
            // 
            // Ten_kho
            // 
            this.Ten_kho.DataPropertyName = "Ten_kho";
            this.Ten_kho.HeaderText = "Tên Kho";
            this.Ten_kho.Name = "Ten_kho";
            this.Ten_kho.ReadOnly = true;
            // 
            // Trang_thai
            // 
            this.Trang_thai.DataPropertyName = "Trang_thai";
            this.Trang_thai.HeaderText = "Trạng thái";
            this.Trang_thai.Name = "Trang_thai";
            this.Trang_thai.ReadOnly = true;
            // 
            // cboTenKho
            // 
            this.cboTenKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenKho.FormattingEnabled = true;
            this.cboTenKho.Location = new System.Drawing.Point(394, 100);
            this.cboTenKho.Name = "cboTenKho";
            this.cboTenKho.Size = new System.Drawing.Size(159, 22);
            this.cboTenKho.TabIndex = 47;
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.AutoSize = true;
            this.cbTrangThai.Location = new System.Drawing.Point(721, 105);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(15, 14);
            this.cbTrangThai.TabIndex = 48;
            this.cbTrangThai.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbTrangThai.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(652, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 44;
            this.label8.Text = "Trạng thái";
            // 
            // frmDMNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 410);
            this.Controls.Add(this.cbTrangThai);
            this.Controls.Add(this.cboTenKho);
            this.Controls.Add(this.gridDMNhanVien);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenNhanVien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pnlMenu);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDMNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh Mục Nhân Viên";
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDMNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label10;
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
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.Label label9;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.DataGridView gridDMNhanVien;
        private System.Windows.Forms.ComboBox cboTenKho;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_nhan_vien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_nhan_vien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_kho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trang_thai;
        private System.Windows.Forms.CheckBox cbTrangThai;
        private System.Windows.Forms.Label label8;


    }
}