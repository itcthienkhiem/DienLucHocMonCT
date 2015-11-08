namespace Inventory.QuanLyTonDauKy
{
    partial class frmDanhSachTraNo
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
            this.gridDSChiTietTraNo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.So_luong_can_tru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_phieu_nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_phieu_nhap_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_chat_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSChiTietTraNo)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDSChiTietTraNo
            // 
            this.gridDSChiTietTraNo.AllowUserToAddRows = false;
            this.gridDSChiTietTraNo.AllowUserToDeleteRows = false;
            this.gridDSChiTietTraNo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.gridDSChiTietTraNo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDSChiTietTraNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDSChiTietTraNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDSChiTietTraNo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDSChiTietTraNo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridDSChiTietTraNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDSChiTietTraNo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Ma_vat_tu,
            this.Ten_vat_tu,
            this.So_luong_can_tru,
            this.Ma_phieu_nhap,
            this.Ma_phieu_nhap_no,
            this.ID_chat_luong});
            this.gridDSChiTietTraNo.Location = new System.Drawing.Point(12, 23);
            this.gridDSChiTietTraNo.MultiSelect = false;
            this.gridDSChiTietTraNo.Name = "gridDSChiTietTraNo";
            this.gridDSChiTietTraNo.ReadOnly = true;
            this.gridDSChiTietTraNo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridDSChiTietTraNo.RowHeadersVisible = false;
            this.gridDSChiTietTraNo.RowTemplate.Height = 30;
            this.gridDSChiTietTraNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDSChiTietTraNo.Size = new System.Drawing.Size(985, 422);
            this.gridDSChiTietTraNo.TabIndex = 115;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Ten_kho";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "Tên kho";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Ma_vat_tu
            // 
            this.Ma_vat_tu.DataPropertyName = "Ma_vat_tu";
            this.Ma_vat_tu.HeaderText = "Mã vật tư";
            this.Ma_vat_tu.Name = "Ma_vat_tu";
            this.Ma_vat_tu.ReadOnly = true;
            this.Ma_vat_tu.Width = 120;
            // 
            // Ten_vat_tu
            // 
            this.Ten_vat_tu.DataPropertyName = "Ten_vat_tu";
            this.Ten_vat_tu.HeaderText = "Tên vật tư";
            this.Ten_vat_tu.Name = "Ten_vat_tu";
            this.Ten_vat_tu.ReadOnly = true;
            // 
            // So_luong_can_tru
            // 
            this.So_luong_can_tru.DataPropertyName = "So_luong_can_tru";
            this.So_luong_can_tru.HeaderText = "Số lượng";
            this.So_luong_can_tru.Name = "So_luong_can_tru";
            this.So_luong_can_tru.ReadOnly = true;
            // 
            // Ma_phieu_nhap
            // 
            this.Ma_phieu_nhap.DataPropertyName = "Ma_phieu_nhap";
            this.Ma_phieu_nhap.HeaderText = "Mã phiếu trả";
            this.Ma_phieu_nhap.Name = "Ma_phieu_nhap";
            this.Ma_phieu_nhap.ReadOnly = true;
            // 
            // Ma_phieu_nhap_no
            // 
            this.Ma_phieu_nhap_no.DataPropertyName = "Ma_phieu_nhap_no";
            this.Ma_phieu_nhap_no.HeaderText = "Mã phiếu nhập nợ";
            this.Ma_phieu_nhap_no.Name = "Ma_phieu_nhap_no";
            this.Ma_phieu_nhap_no.ReadOnly = true;
            // 
            // ID_chat_luong
            // 
            this.ID_chat_luong.DataPropertyName = "ID_chat_luong";
            this.ID_chat_luong.HeaderText = "ID_chat_luong";
            this.ID_chat_luong.Name = "ID_chat_luong";
            this.ID_chat_luong.ReadOnly = true;
            this.ID_chat_luong.Visible = false;
            // 
            // frmDanhSachTraNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 477);
            this.Controls.Add(this.gridDSChiTietTraNo);
            this.Name = "frmDanhSachTraNo";
            this.Text = "frmDanhSachTraNo";
            ((System.ComponentModel.ISupportInitialize)(this.gridDSChiTietTraNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridDSChiTietTraNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_luong_can_tru;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_phieu_nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_phieu_nhap_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_chat_luong;
    }
}