namespace Inventory.QuanLyKhoVatTu
{
    partial class frmDanhSachVatTuTrongKho
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Ten_kho.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            this.gridTonKhoThuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridTonKhoThuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTonKhoThuc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTonKhoThuc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTonKhoThuc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridTonKhoThuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTonKhoThuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ten_kho,
            this.Ma_vat_tu,
            this.Ten_vat_tu,
            this.So_luong});
            this.gridTonKhoThuc.Location = new System.Drawing.Point(0, 54);
            this.gridTonKhoThuc.MultiSelect = false;
            this.gridTonKhoThuc.Name = "gridTonKhoThuc";
            this.gridTonKhoThuc.ReadOnly = true;
            this.gridTonKhoThuc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridTonKhoThuc.RowHeadersVisible = false;
            this.gridTonKhoThuc.RowTemplate.Height = 30;
            this.gridTonKhoThuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTonKhoThuc.Size = new System.Drawing.Size(1098, 383);
            this.gridTonKhoThuc.TabIndex = 126;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(235, 7);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(66, 31);
            this.btnXem.TabIndex = 129;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // frmDanhSachVatTuTrongKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 540);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridTonKhoThuc);
            this.Controls.Add(this.cbKho);
            this.Name = "frmDanhSachVatTuTrongKho";
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
    }
}