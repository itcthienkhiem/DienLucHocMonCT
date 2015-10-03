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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridMaster = new System.Windows.Forms.DataGridView();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetDM = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
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
            this.Ma_phieu_nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_kho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_phieu_nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kho_nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_lap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ly_do_nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.So_hoa_don = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridMaster
            // 
            this.gridMaster.AllowUserToAddRows = false;
            this.gridMaster.AllowUserToDeleteRows = false;
            this.gridMaster.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.gridMaster.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMaster.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridMaster.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_phieu_nhap,
            this.ID_kho,
            this.ID_phieu_nhap,
            this.Kho_nhap,
            this.Ngay_lap,
            this.Ly_do_nhap,
            this.So_hoa_don});
            this.gridMaster.Location = new System.Drawing.Point(1, 98);
            this.gridMaster.MultiSelect = false;
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.ReadOnly = true;
            this.gridMaster.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridMaster.RowHeadersVisible = false;
            this.gridMaster.RowTemplate.Height = 30;
            this.gridMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMaster.Size = new System.Drawing.Size(1109, 528);
            this.gridMaster.TabIndex = 52;
            this.gridMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMaster_CellClick);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.button1);
            this.pnlMenu.Controls.Add(this.label2);
            this.pnlMenu.Controls.Add(this.btnGetDM);
            this.pnlMenu.Controls.Add(this.btnSave);
            this.pnlMenu.Controls.Add(this.label10);
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
            this.pnlMenu.Size = new System.Drawing.Size(1110, 92);
            this.pnlMenu.TabIndex = 53;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(298, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hủy bỏ";
            // 
            // btnGetDM
            // 
            this.btnGetDM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetDM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGetDM.Location = new System.Drawing.Point(1037, 11);
            this.btnGetDM.Name = "btnGetDM";
            this.btnGetDM.Size = new System.Drawing.Size(40, 40);
            this.btnGetDM.TabIndex = 2;
            this.btnGetDM.UseVisualStyleBackColor = true;
            this.btnGetDM.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Location = new System.Drawing.Point(623, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 50);
            this.btnSave.TabIndex = 2;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(633, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 14);
            this.label10.TabIndex = 3;
            this.label10.Text = "Save";
            // 
            // btnDong
            // 
            this.btnDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDong.Location = new System.Drawing.Point(242, 11);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(50, 50);
            this.btnDong.TabIndex = 2;
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 61);
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1025, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tải dữ liệu";
            this.label1.Visible = false;
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
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXoa.Location = new System.Drawing.Point(69, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(50, 50);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLamMoi.Location = new System.Drawing.Point(185, 10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(50, 50);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.UseVisualStyleBackColor = true;
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
            // Ma_phieu_nhap
            // 
            this.Ma_phieu_nhap.DataPropertyName = "Ma_phieu_nhap";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Ma_phieu_nhap.DefaultCellStyle = dataGridViewCellStyle3;
            this.Ma_phieu_nhap.HeaderText = "Mã phiếu nhập";
            this.Ma_phieu_nhap.Name = "Ma_phieu_nhap";
            this.Ma_phieu_nhap.ReadOnly = true;
            // 
            // ID_kho
            // 
            this.ID_kho.DataPropertyName = "ID_kho";
            this.ID_kho.HeaderText = "ID_kho";
            this.ID_kho.Name = "ID_kho";
            this.ID_kho.ReadOnly = true;
            this.ID_kho.Visible = false;
            // 
            // ID_phieu_nhap
            // 
            this.ID_phieu_nhap.DataPropertyName = "ID_phieu_nhap";
            this.ID_phieu_nhap.HeaderText = "ID_phieu_nhap";
            this.ID_phieu_nhap.Name = "ID_phieu_nhap";
            this.ID_phieu_nhap.ReadOnly = true;
            this.ID_phieu_nhap.Visible = false;
            // 
            // Kho_nhap
            // 
            this.Kho_nhap.DataPropertyName = "Kho_nhap";
            this.Kho_nhap.HeaderText = "Kho Nhập";
            this.Kho_nhap.Name = "Kho_nhap";
            this.Kho_nhap.ReadOnly = true;
            // 
            // Ngay_lap
            // 
            this.Ngay_lap.DataPropertyName = "Ngay_lap";
            this.Ngay_lap.HeaderText = "Ngày lập";
            this.Ngay_lap.Name = "Ngay_lap";
            this.Ngay_lap.ReadOnly = true;
            // 
            // Ly_do_nhap
            // 
            this.Ly_do_nhap.DataPropertyName = "Ly_do_nhap";
            this.Ly_do_nhap.HeaderText = "Lý do nhập";
            this.Ly_do_nhap.Name = "Ly_do_nhap";
            this.Ly_do_nhap.ReadOnly = true;
            // 
            // So_hoa_don
            // 
            this.So_hoa_don.DataPropertyName = "So_hoa_don";
            this.So_hoa_don.HeaderText = "Số hóa đơn";
            this.So_hoa_don.Name = "So_hoa_don";
            this.So_hoa_don.ReadOnly = true;
            // 
            // frmDanhSachPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 627);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.gridMaster);
            this.Name = "frmDanhSachPhieuNhap";
            this.Text = "frmDanhSachPhieuNhap";
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridMaster;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetDM;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label10;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_phieu_nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_kho;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_phieu_nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kho_nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_lap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ly_do_nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_hoa_don;

    }
}