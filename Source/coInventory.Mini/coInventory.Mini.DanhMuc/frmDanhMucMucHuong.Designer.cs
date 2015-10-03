namespace coInventory.Mini.DanhMuc
{
    partial class frmDanhMucMucHuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucMucHuong));
            this.grdDM_MucHuong = new System.Windows.Forms.DataGridView();
            this.MucHuong_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MucHuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhanTram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.TableDanhMucMucHuong = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.lblSua = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnGetDM = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdDM_MucHuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableDanhMucMucHuong)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDM_MucHuong
            // 
            this.grdDM_MucHuong.AllowUserToAddRows = false;
            this.grdDM_MucHuong.AllowUserToDeleteRows = false;
            this.grdDM_MucHuong.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.grdDM_MucHuong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDM_MucHuong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDM_MucHuong.AutoGenerateColumns = false;
            this.grdDM_MucHuong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDM_MucHuong.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDM_MucHuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdDM_MucHuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDM_MucHuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MucHuong_Id,
            this.MucHuong,
            this.PhanTram,
            this.Active});
            this.grdDM_MucHuong.DataMember = "TableDanhMucMucHuong";
            this.grdDM_MucHuong.DataSource = this.dataSet1;
            this.grdDM_MucHuong.Location = new System.Drawing.Point(1, 92);
            this.grdDM_MucHuong.MultiSelect = false;
            this.grdDM_MucHuong.Name = "grdDM_MucHuong";
            this.grdDM_MucHuong.ReadOnly = true;
            this.grdDM_MucHuong.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdDM_MucHuong.RowHeadersVisible = false;
            this.grdDM_MucHuong.RowTemplate.Height = 30;
            this.grdDM_MucHuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDM_MucHuong.Size = new System.Drawing.Size(783, 469);
            this.grdDM_MucHuong.TabIndex = 8;
            // 
            // MucHuong_Id
            // 
            this.MucHuong_Id.DataPropertyName = "MucHuong_Id";
            this.MucHuong_Id.HeaderText = "MucHuong_Id";
            this.MucHuong_Id.Name = "MucHuong_Id";
            this.MucHuong_Id.ReadOnly = true;
            this.MucHuong_Id.Visible = false;
            // 
            // MucHuong
            // 
            this.MucHuong.DataPropertyName = "MucHuong";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MucHuong.DefaultCellStyle = dataGridViewCellStyle3;
            this.MucHuong.HeaderText = "Mức Hưởng";
            this.MucHuong.Name = "MucHuong";
            this.MucHuong.ReadOnly = true;
            this.MucHuong.Width = 110;
            // 
            // PhanTram
            // 
            this.PhanTram.DataPropertyName = "PhanTram";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PhanTram.DefaultCellStyle = dataGridViewCellStyle4;
            this.PhanTram.HeaderText = "Phần Trăm";
            this.PhanTram.Name = "PhanTram";
            this.PhanTram.ReadOnly = true;
            this.PhanTram.Width = 110;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Còn Dùng";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.TableDanhMucMucHuong});
            // 
            // TableDanhMucMucHuong
            // 
            this.TableDanhMucMucHuong.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn5});
            this.TableDanhMucMucHuong.TableName = "TableDanhMucMucHuong";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "MucHuong_Id";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "MucHuong";
            this.dataColumn2.DataType = typeof(int);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "PhanTram";
            this.dataColumn3.DataType = typeof(decimal);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Active";
            this.dataColumn5.DataType = typeof(bool);
            // 
            // lblSua
            // 
            this.lblSua.AutoSize = true;
            this.lblSua.Location = new System.Drawing.Point(261, 61);
            this.lblSua.Name = "lblSua";
            this.lblSua.Size = new System.Drawing.Size(28, 14);
            this.lblSua.TabIndex = 3;
            this.lblSua.Text = "Sửa";
            this.lblSua.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Xóa";
            this.label3.Visible = false;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Thêm";
            this.label5.Visible = false;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "Đóng";
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
            this.pnlMenu.TabIndex = 22;
            // 
            // frmDanhMucMucHuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.grdDM_MucHuong);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhMucMucHuong";
            this.Text = "Danh Mục Mức Hưởng";
            this.Load += new System.EventHandler(this.frmDanhMucMucHuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDM_MucHuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableDanhMucMucHuong)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDM_MucHuong;
        public System.Data.DataSet dataSet1;
        private System.Data.DataTable TableDanhMucMucHuong;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn5;
        private System.Windows.Forms.Label lblSua;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnGetDM;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MucHuong_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn MucHuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhanTram;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
    }
}