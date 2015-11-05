namespace Inventory.NhapXuat
{
    partial class frmBuTruPhieu
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
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaPhieuNhap = new System.Windows.Forms.TextBox();
            this.gridDanhSachPhieuNhap = new System.Windows.Forms.DataGridView();
            this.dataSet1 = new System.Data.DataSet();
            this.dtPhieuNhap = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbPhieuNo = new System.Windows.Forms.ComboBox();
            this.btnCanTru = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataSet2 = new System.Data.DataSet();
            this.dtPhieuNhapNo = new System.Data.DataTable();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.ID_chat_luong_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_chi_tiet_phieu_nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_vat_tu_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_vat_tu_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chat_luong_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.so_luong_thuc_lanh_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.Ma_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_chat_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.so_luong_thuc_lanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chat_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSachPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPhieuNhap)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPhieuNhapNo)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(68, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Mã số cấn trừ";
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(153, 12);
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(156, 20);
            this.txtMaPhieuNhap.TabIndex = 51;
            // 
            // gridDanhSachPhieuNhap
            // 
            this.gridDanhSachPhieuNhap.AllowUserToAddRows = false;
            this.gridDanhSachPhieuNhap.AllowUserToDeleteRows = false;
            this.gridDanhSachPhieuNhap.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.gridDanhSachPhieuNhap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDanhSachPhieuNhap.AutoGenerateColumns = false;
            this.gridDanhSachPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDanhSachPhieuNhap.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDanhSachPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridDanhSachPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDanhSachPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_vat_tu,
            this.dataGridViewTextBoxColumn1,
            this.Ten_vat_tu,
            this.ID_chat_luong,
            this.so_luong_thuc_lanh,
            this.chat_luong});
            this.gridDanhSachPhieuNhap.DataMember = "dtPhieuNhap";
            this.gridDanhSachPhieuNhap.DataSource = this.dataSet1;
            this.gridDanhSachPhieuNhap.Location = new System.Drawing.Point(1, 19);
            this.gridDanhSachPhieuNhap.MultiSelect = false;
            this.gridDanhSachPhieuNhap.Name = "gridDanhSachPhieuNhap";
            this.gridDanhSachPhieuNhap.ReadOnly = true;
            this.gridDanhSachPhieuNhap.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridDanhSachPhieuNhap.RowHeadersVisible = false;
            this.gridDanhSachPhieuNhap.RowTemplate.Height = 30;
            this.gridDanhSachPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDanhSachPhieuNhap.Size = new System.Drawing.Size(780, 273);
            this.gridDanhSachPhieuNhap.TabIndex = 53;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dtPhieuNhap});
            // 
            // dtPhieuNhap
            // 
            this.dtPhieuNhap.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn12});
            this.dtPhieuNhap.TableName = "dtPhieuNhap";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Ma_vat_tu";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Ten_vat_tu";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "ID_chat_luong";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "chat_luong";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "so_luong_thuc_lanh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Mã phiếu nợ";
            // 
            // cbbPhieuNo
            // 
            this.cbbPhieuNo.FormattingEnabled = true;
            this.cbbPhieuNo.Location = new System.Drawing.Point(153, 40);
            this.cbbPhieuNo.Name = "cbbPhieuNo";
            this.cbbPhieuNo.Size = new System.Drawing.Size(156, 21);
            this.cbbPhieuNo.TabIndex = 55;
            this.cbbPhieuNo.SelectionChangeCommitted += new System.EventHandler(this.cbbPhieuNo_SelectionChangeCommitted);
            this.cbbPhieuNo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbbPhieuNo_MouseDown);
            // 
            // btnCanTru
            // 
            this.btnCanTru.Location = new System.Drawing.Point(335, 16);
            this.btnCanTru.Name = "btnCanTru";
            this.btnCanTru.Size = new System.Drawing.Size(75, 39);
            this.btnCanTru.TabIndex = 56;
            this.btnCanTru.Text = "Bù trừ";
            this.btnCanTru.UseVisualStyleBackColor = true;
            this.btnCanTru.Click += new System.EventHandler(this.btnCanTru_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridDanhSachPhieuNhap);
            this.groupBox1.Location = new System.Drawing.Point(1, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(789, 309);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách vật tư trong phiếu nhập";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(3, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 291);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách vật tư trong phiếu nợ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_chat_luong_no,
            this.ID_chi_tiet_phieu_nhap,
            this.Ma_vat_tu_no,
            this.Ten_vat_tu_no,
            this.chat_luong_no,
            this.so_luong_thuc_lanh_no});
            this.dataGridView1.DataMember = "dtPhieuNhapNo";
            this.dataGridView1.DataSource = this.dataSet2;
            this.dataGridView1.Location = new System.Drawing.Point(2, 19);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 263);
            this.dataGridView1.TabIndex = 54;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "NewDataSet";
            this.dataSet2.Tables.AddRange(new System.Data.DataTable[] {
            this.dtPhieuNhapNo});
            // 
            // dtPhieuNhapNo
            // 
            this.dtPhieuNhapNo.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11});
            this.dtPhieuNhapNo.TableName = "dtPhieuNhapNo";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "Ma_vat_tu";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "Ten_vat_tu";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "ID_chat_luong";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "chat_luong";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "so_luong_thuc_lanh";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "ID_chi_tiet_phieu_nhap";
            // 
            // ID_chat_luong_no
            // 
            this.ID_chat_luong_no.DataPropertyName = "ID_chat_luong";
            this.ID_chat_luong_no.HeaderText = "ID_chat_luong";
            this.ID_chat_luong_no.Name = "ID_chat_luong_no";
            this.ID_chat_luong_no.ReadOnly = true;
            this.ID_chat_luong_no.Visible = false;
            // 
            // ID_chi_tiet_phieu_nhap
            // 
            this.ID_chi_tiet_phieu_nhap.DataPropertyName = "ID_chi_tiet_phieu_nhap";
            this.ID_chi_tiet_phieu_nhap.HeaderText = "ID_chi_tiet_phieu_nhap";
            this.ID_chi_tiet_phieu_nhap.Name = "ID_chi_tiet_phieu_nhap";
            this.ID_chi_tiet_phieu_nhap.ReadOnly = true;
            this.ID_chi_tiet_phieu_nhap.Visible = false;
            // 
            // Ma_vat_tu_no
            // 
            this.Ma_vat_tu_no.DataPropertyName = "Ma_vat_tu";
            this.Ma_vat_tu_no.HeaderText = "Ma_vat_tu";
            this.Ma_vat_tu_no.Name = "Ma_vat_tu_no";
            this.Ma_vat_tu_no.ReadOnly = true;
            // 
            // Ten_vat_tu_no
            // 
            this.Ten_vat_tu_no.DataPropertyName = "Ten_vat_tu";
            this.Ten_vat_tu_no.HeaderText = "Ten_vat_tu";
            this.Ten_vat_tu_no.Name = "Ten_vat_tu_no";
            this.Ten_vat_tu_no.ReadOnly = true;
            // 
            // chat_luong_no
            // 
            this.chat_luong_no.DataPropertyName = "chat_luong";
            this.chat_luong_no.HeaderText = "chat_luong";
            this.chat_luong_no.Name = "chat_luong_no";
            this.chat_luong_no.ReadOnly = true;
            // 
            // so_luong_thuc_lanh_no
            // 
            this.so_luong_thuc_lanh_no.DataPropertyName = "so_luong_thuc_lanh";
            this.so_luong_thuc_lanh_no.HeaderText = "so_luong_thuc_lanh";
            this.so_luong_thuc_lanh_no.Name = "so_luong_thuc_lanh_no";
            this.so_luong_thuc_lanh_no.ReadOnly = true;
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "ID_chi_tiet_phieu_nhap";
            // 
            // Ma_vat_tu
            // 
            this.Ma_vat_tu.DataPropertyName = "Ma_vat_tu";
            this.Ma_vat_tu.HeaderText = "Ma_vat_tu";
            this.Ma_vat_tu.Name = "Ma_vat_tu";
            this.Ma_vat_tu.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID_chi_tiet_phieu_nhap";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID_chi_tiet_phieu_nhap";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Ten_vat_tu
            // 
            this.Ten_vat_tu.DataPropertyName = "Ten_vat_tu";
            this.Ten_vat_tu.HeaderText = "Ten_vat_tu";
            this.Ten_vat_tu.Name = "Ten_vat_tu";
            this.Ten_vat_tu.ReadOnly = true;
            // 
            // ID_chat_luong
            // 
            this.ID_chat_luong.DataPropertyName = "ID_chat_luong";
            this.ID_chat_luong.HeaderText = "ID_chat_luong";
            this.ID_chat_luong.Name = "ID_chat_luong";
            this.ID_chat_luong.ReadOnly = true;
            // 
            // so_luong_thuc_lanh
            // 
            this.so_luong_thuc_lanh.DataPropertyName = "so_luong_thuc_lanh";
            this.so_luong_thuc_lanh.HeaderText = "Số lượng";
            this.so_luong_thuc_lanh.Name = "so_luong_thuc_lanh";
            this.so_luong_thuc_lanh.ReadOnly = true;
            // 
            // chat_luong
            // 
            this.chat_luong.DataPropertyName = "chat_luong";
            this.chat_luong.HeaderText = "chat_luong";
            this.chat_luong.Name = "chat_luong";
            this.chat_luong.ReadOnly = true;
            // 
            // frmBuTruPhieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 668);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCanTru);
            this.Controls.Add(this.cbbPhieuNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMaPhieuNhap);
            this.Name = "frmBuTruPhieu";
            this.Text = "frmBuTruPhieu";
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSachPhieuNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPhieuNhap)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPhieuNhapNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaPhieuNhap;
        private System.Windows.Forms.DataGridView gridDanhSachPhieuNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbPhieuNo;
        private System.Windows.Forms.Button btnCanTru;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dtPhieuNhap;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataSet dataSet2;
        private System.Data.DataTable dtPhieuNhapNo;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_chat_luong_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_chi_tiet_phieu_nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_vat_tu_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_vat_tu_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn chat_luong_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn so_luong_thuc_lanh_no;
        private System.Data.DataColumn dataColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_chat_luong;
        private System.Windows.Forms.DataGridViewTextBoxColumn so_luong_thuc_lanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn chat_luong;
        private System.Data.DataColumn dataColumn12;
    }
}