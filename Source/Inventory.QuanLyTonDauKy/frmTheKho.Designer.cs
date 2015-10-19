namespace Inventory.QuanLyTonDauKy
{
    partial class frmTheKho
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenVatTu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.txtDiaDiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gridTheKho = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOHIEU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAY_THANG_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIEN_GIAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAY_NHAP_XUAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SO_LUONG_NHAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SO_LUONG_XUAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SO_LUONG_TON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KY_XAC_NHAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GHI_CHU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbMaVatTu = new System.Windows.Forms.ComboBox();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridTheKho)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(398, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "THẺ KHO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(768, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "DANH ĐIỂM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "TÊN VÀ QUY CÁCH VẬT TƯ";
            // 
            // txtTenVatTu
            // 
            this.txtTenVatTu.Location = new System.Drawing.Point(280, 111);
            this.txtTenVatTu.Multiline = true;
            this.txtTenVatTu.Name = "txtTenVatTu";
            this.txtTenVatTu.Size = new System.Drawing.Size(187, 34);
            this.txtTenVatTu.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "ĐƠN VỊ";
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(62, 22);
            this.txtDonVi.Multiline = true;
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Size = new System.Drawing.Size(187, 34);
            this.txtDonVi.TabIndex = 6;
            // 
            // txtDiaDiem
            // 
            this.txtDiaDiem.Location = new System.Drawing.Point(62, 74);
            this.txtDiaDiem.Multiline = true;
            this.txtDiaDiem.Name = "txtDiaDiem";
            this.txtDiaDiem.Size = new System.Drawing.Size(187, 34);
            this.txtDiaDiem.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "ĐỊA ĐIỂM";
            // 
            // gridTheKho
            // 
            this.gridTheKho.AllowUserToAddRows = false;
            this.gridTheKho.AllowUserToDeleteRows = false;
            this.gridTheKho.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.gridTheKho.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTheKho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTheKho.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTheKho.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTheKho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridTheKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTheKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.SOHIEU,
            this.NGAY_THANG_CT,
            this.DIEN_GIAI,
            this.NGAY_NHAP_XUAT,
            this.SO_LUONG_NHAP,
            this.SO_LUONG_XUAT,
            this.SO_LUONG_TON,
            this.KY_XAC_NHAN,
            this.GHI_CHU});
            this.gridTheKho.Location = new System.Drawing.Point(4, 151);
            this.gridTheKho.MultiSelect = false;
            this.gridTheKho.Name = "gridTheKho";
            this.gridTheKho.ReadOnly = true;
            this.gridTheKho.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridTheKho.RowHeadersVisible = false;
            this.gridTheKho.RowTemplate.Height = 30;
            this.gridTheKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTheKho.Size = new System.Drawing.Size(1111, 399);
            this.gridTheKho.TabIndex = 49;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // SOHIEU
            // 
            this.SOHIEU.HeaderText = "SOHIEU";
            this.SOHIEU.Name = "SOHIEU";
            this.SOHIEU.ReadOnly = true;
            // 
            // NGAY_THANG_CT
            // 
            this.NGAY_THANG_CT.HeaderText = "NGAY_THANG_CT";
            this.NGAY_THANG_CT.Name = "NGAY_THANG_CT";
            this.NGAY_THANG_CT.ReadOnly = true;
            // 
            // DIEN_GIAI
            // 
            this.DIEN_GIAI.HeaderText = "DIEN_GIAI";
            this.DIEN_GIAI.Name = "DIEN_GIAI";
            this.DIEN_GIAI.ReadOnly = true;
            // 
            // NGAY_NHAP_XUAT
            // 
            this.NGAY_NHAP_XUAT.HeaderText = "NGAY_NHAP_XUAT";
            this.NGAY_NHAP_XUAT.Name = "NGAY_NHAP_XUAT";
            this.NGAY_NHAP_XUAT.ReadOnly = true;
            // 
            // SO_LUONG_NHAP
            // 
            this.SO_LUONG_NHAP.HeaderText = "SO_LUONG_NHAP";
            this.SO_LUONG_NHAP.Name = "SO_LUONG_NHAP";
            this.SO_LUONG_NHAP.ReadOnly = true;
            // 
            // SO_LUONG_XUAT
            // 
            this.SO_LUONG_XUAT.HeaderText = "SO_LUONG_XUAT";
            this.SO_LUONG_XUAT.Name = "SO_LUONG_XUAT";
            this.SO_LUONG_XUAT.ReadOnly = true;
            // 
            // SO_LUONG_TON
            // 
            this.SO_LUONG_TON.HeaderText = "SO_LUONG_TON";
            this.SO_LUONG_TON.Name = "SO_LUONG_TON";
            this.SO_LUONG_TON.ReadOnly = true;
            // 
            // KY_XAC_NHAN
            // 
            this.KY_XAC_NHAN.HeaderText = "KY_XAC_NHAN";
            this.KY_XAC_NHAN.Name = "KY_XAC_NHAN";
            this.KY_XAC_NHAN.ReadOnly = true;
            // 
            // GHI_CHU
            // 
            this.GHI_CHU.HeaderText = "GHI_CHU";
            this.GHI_CHU.Name = "GHI_CHU";
            this.GHI_CHU.ReadOnly = true;
            // 
            // cbMaVatTu
            // 
            this.cbMaVatTu.FormattingEnabled = true;
            this.cbMaVatTu.Location = new System.Drawing.Point(732, 25);
            this.cbMaVatTu.Name = "cbMaVatTu";
            this.cbMaVatTu.Size = new System.Drawing.Size(187, 21);
            this.cbMaVatTu.TabIndex = 50;
            this.cbMaVatTu.DropDown += new System.EventHandler(this.comboBox_DropDown);
            this.cbMaVatTu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMaVatTu_KeyDown);
            this.cbMaVatTu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbMaVatTu_MouseDown);
            this.cbMaVatTu.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.comboBox_PreviewKeyDown);
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(732, 102);
            this.txtDVT.Multiline = true;
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(187, 34);
            this.txtDVT.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(746, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Đơn vị";
            // 
            // frmTheKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 553);
            this.Controls.Add(this.txtDVT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbMaVatTu);
            this.Controls.Add(this.gridTheKho);
            this.Controls.Add(this.txtDiaDiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDonVi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTenVatTu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmTheKho";
            this.Text = "frmTheKho";
            ((System.ComponentModel.ISupportInitialize)(this.gridTheKho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenVatTu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.TextBox txtDiaDiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView gridTheKho;
        private System.Windows.Forms.ComboBox cbMaVatTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOHIEU;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAY_THANG_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIEN_GIAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAY_NHAP_XUAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SO_LUONG_NHAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SO_LUONG_XUAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SO_LUONG_TON;
        private System.Windows.Forms.DataGridViewTextBoxColumn KY_XAC_NHAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn GHI_CHU;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label label6;
    }
}