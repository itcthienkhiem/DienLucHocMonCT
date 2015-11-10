namespace Inventory.NhapXuat
{
    partial class frmTonKho
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbKho = new System.Windows.Forms.ComboBox();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.So_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_kho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTonKhoThuc = new System.Windows.Forms.DataGridView();
            this.btnXem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbChatLuong = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMaVatTu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTenVatTu = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTonKhoThuc)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 127;
            this.label3.Text = "Tên kho";
            // 
            // cbKho
            // 
            this.cbKho.FormattingEnabled = true;
            this.cbKho.Location = new System.Drawing.Point(77, 12);
            this.cbKho.Name = "cbKho";
            this.cbKho.Size = new System.Drawing.Size(152, 21);
            this.cbKho.TabIndex = 128;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
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
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Ten_vat_tu";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "So_luong";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "Ten_Don_vi_tinh";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "so_luong_thuc_lanh";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "ID_Don_vi_tinh";
            this.dataColumn10.DataType = typeof(short);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "So_luong_hoan_nhap";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "So_luong_giu_lai";
            // 
            // So_luong
            // 
            this.So_luong.DataPropertyName = "So_luong";
            this.So_luong.HeaderText = "Số lượng";
            this.So_luong.Name = "So_luong";
            this.So_luong.ReadOnly = true;
            // 
            // Ten_vat_tu
            // 
            this.Ten_vat_tu.DataPropertyName = "Ten_vat_tu";
            this.Ten_vat_tu.HeaderText = "Tên vật tư";
            this.Ten_vat_tu.Name = "Ten_vat_tu";
            this.Ten_vat_tu.ReadOnly = true;
            // 
            // Ma_vat_tu
            // 
            this.Ma_vat_tu.DataPropertyName = "Ma_vat_tu";
            this.Ma_vat_tu.HeaderText = "Mã vật tư";
            this.Ma_vat_tu.Name = "Ma_vat_tu";
            this.Ma_vat_tu.ReadOnly = true;
            this.Ma_vat_tu.Width = 120;
            // 
            // Ten_kho
            // 
            this.Ten_kho.DataPropertyName = "Ten_kho";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Ten_kho.DefaultCellStyle = dataGridViewCellStyle10;
            this.Ten_kho.HeaderText = "Tên kho";
            this.Ten_kho.Name = "Ten_kho";
            this.Ten_kho.ReadOnly = true;
            this.Ten_kho.Visible = false;
            // 
            // gridTonKhoThuc
            // 
            this.gridTonKhoThuc.AllowUserToAddRows = false;
            this.gridTonKhoThuc.AllowUserToDeleteRows = false;
            this.gridTonKhoThuc.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.AliceBlue;
            this.gridTonKhoThuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.gridTonKhoThuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTonKhoThuc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTonKhoThuc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTonKhoThuc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gridTonKhoThuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTonKhoThuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ten_kho,
            this.Ma_vat_tu,
            this.Ten_vat_tu,
            this.So_luong});
            this.gridTonKhoThuc.Location = new System.Drawing.Point(0, 66);
            this.gridTonKhoThuc.MultiSelect = false;
            this.gridTonKhoThuc.Name = "gridTonKhoThuc";
            this.gridTonKhoThuc.ReadOnly = true;
            this.gridTonKhoThuc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridTonKhoThuc.RowHeadersVisible = false;
            this.gridTonKhoThuc.RowTemplate.Height = 30;
            this.gridTonKhoThuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTonKhoThuc.Size = new System.Drawing.Size(1098, 471);
            this.gridTonKhoThuc.TabIndex = 126;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(475, 12);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(66, 44);
            this.btnXem.TabIndex = 129;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 130;
            this.label1.Text = "Chất lượng";
            // 
            // cbChatLuong
            // 
            this.cbChatLuong.FormattingEnabled = true;
            this.cbChatLuong.Location = new System.Drawing.Point(305, 13);
            this.cbChatLuong.Name = "cbChatLuong";
            this.cbChatLuong.Size = new System.Drawing.Size(152, 21);
            this.cbChatLuong.TabIndex = 131;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 134;
            this.label4.Text = "Mã vật tư";
            // 
            // cbMaVatTu
            // 
            this.cbMaVatTu.FormattingEnabled = true;
            this.cbMaVatTu.Location = new System.Drawing.Point(77, 39);
            this.cbMaVatTu.Name = "cbMaVatTu";
            this.cbMaVatTu.Size = new System.Drawing.Size(152, 21);
            this.cbMaVatTu.TabIndex = 135;
            this.cbMaVatTu.SelectedIndexChanged += new System.EventHandler(this.cbMaVatTu_SelectedIndexChanged);
            this.cbMaVatTu.SelectionChangeCommitted += new System.EventHandler(this.cbMaVatTu_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 132;
            this.label2.Text = "Tên vật tư";
            // 
            // cbTenVatTu
            // 
            this.cbTenVatTu.FormattingEnabled = true;
            this.cbTenVatTu.Location = new System.Drawing.Point(305, 39);
            this.cbTenVatTu.Name = "cbTenVatTu";
            this.cbTenVatTu.Size = new System.Drawing.Size(152, 21);
            this.cbTenVatTu.TabIndex = 133;
            this.cbTenVatTu.SelectedIndexChanged += new System.EventHandler(this.cbTenVatTu_SelectedIndexChanged);
            this.cbTenVatTu.SelectionChangeCommitted += new System.EventHandler(this.cbTenVatTu_SelectionChangeCommitted);
            // 
            // frmTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 540);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbMaVatTu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTenVatTu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbChatLuong);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridTonKhoThuc);
            this.Controls.Add(this.cbKho);
            this.Name = "frmTonKho";
            this.Text = "frmDanhSachVatTuTrongKho";
            this.Load += new System.EventHandler(this.frmDanhSachVatTuTrongKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTonKhoThuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbKho;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_luong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_kho;
        private System.Windows.Forms.DataGridView gridTonKhoThuc;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbChatLuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMaVatTu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTenVatTu;
    }
}