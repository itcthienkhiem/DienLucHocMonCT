namespace coInventory.Mini.DanhMuc
{
    partial class frmDanhMucMucHuongDoiTuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucMucHuongDoiTuong));
            this.grdDM_MucHuongDoiTuong = new System.Windows.Forms.DataGridView();
            this.mucHuongDoiTuongIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MucHuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoiTuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.TableDanhMucMucHuongDoiTuong = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdDM_MucHuongDoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableDanhMucMucHuongDoiTuong)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDM_MucHuongDoiTuong
            // 
            this.grdDM_MucHuongDoiTuong.AllowUserToAddRows = false;
            this.grdDM_MucHuongDoiTuong.AllowUserToDeleteRows = false;
            this.grdDM_MucHuongDoiTuong.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.grdDM_MucHuongDoiTuong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDM_MucHuongDoiTuong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDM_MucHuongDoiTuong.AutoGenerateColumns = false;
            this.grdDM_MucHuongDoiTuong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDM_MucHuongDoiTuong.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDM_MucHuongDoiTuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdDM_MucHuongDoiTuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDM_MucHuongDoiTuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mucHuongDoiTuongIdDataGridViewTextBoxColumn,
            this.MucHuong,
            this.DoiTuong});
            this.grdDM_MucHuongDoiTuong.DataMember = "TableDanhMucMucHuongDoiTuong";
            this.grdDM_MucHuongDoiTuong.DataSource = this.dataSet1;
            this.grdDM_MucHuongDoiTuong.Location = new System.Drawing.Point(1, 92);
            this.grdDM_MucHuongDoiTuong.MultiSelect = false;
            this.grdDM_MucHuongDoiTuong.Name = "grdDM_MucHuongDoiTuong";
            this.grdDM_MucHuongDoiTuong.ReadOnly = true;
            this.grdDM_MucHuongDoiTuong.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdDM_MucHuongDoiTuong.RowHeadersVisible = false;
            this.grdDM_MucHuongDoiTuong.RowTemplate.Height = 30;
            this.grdDM_MucHuongDoiTuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDM_MucHuongDoiTuong.Size = new System.Drawing.Size(783, 469);
            this.grdDM_MucHuongDoiTuong.TabIndex = 9;
            // 
            // mucHuongDoiTuongIdDataGridViewTextBoxColumn
            // 
            this.mucHuongDoiTuongIdDataGridViewTextBoxColumn.DataPropertyName = "MucHuongDoiTuong_Id";
            this.mucHuongDoiTuongIdDataGridViewTextBoxColumn.HeaderText = "MucHuongDoiTuong_Id";
            this.mucHuongDoiTuongIdDataGridViewTextBoxColumn.Name = "mucHuongDoiTuongIdDataGridViewTextBoxColumn";
            this.mucHuongDoiTuongIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.mucHuongDoiTuongIdDataGridViewTextBoxColumn.Visible = false;
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
            // DoiTuong
            // 
            this.DoiTuong.DataPropertyName = "DoiTuong";
            this.DoiTuong.HeaderText = "Đối Tượng";
            this.DoiTuong.Name = "DoiTuong";
            this.DoiTuong.ReadOnly = true;
            this.DoiTuong.Width = 650;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.TableDanhMucMucHuongDoiTuong});
            // 
            // TableDanhMucMucHuongDoiTuong
            // 
            this.TableDanhMucMucHuongDoiTuong.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.TableDanhMucMucHuongDoiTuong.TableName = "TableDanhMucMucHuongDoiTuong";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "MucHuongDoiTuong_Id";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "MucHuong";
            this.dataColumn2.DataType = typeof(int);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "DoiTuong";
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
            this.label5.Location = new System.Drawing.Point(138, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Thêm";
            this.label5.Visible = false;
            this.label5.Click += new System.EventHandler(this.label5_Click);
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
            this.label3.Location = new System.Drawing.Point(202, 61);
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
            // frmDanhMucMucHuongDoiTuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.grdDM_MucHuongDoiTuong);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhMucMucHuongDoiTuong";
            this.Text = "Danh Mục Mức Hưởng Đối Tượng";
            this.Load += new System.EventHandler(this.frmDanhMucMucHuongDoiTuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDM_MucHuongDoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableDanhMucMucHuongDoiTuong)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDM_MucHuongDoiTuong;
        public System.Data.DataSet dataSet1;
        private System.Data.DataTable TableDanhMucMucHuongDoiTuong;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn mucHuongDoiTuongIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MucHuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoiTuong;
    }
}