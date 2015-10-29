namespace Inventory.QuanLyTonDauKy
{
    partial class frmNoVatTu
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
            this.label9 = new System.Windows.Forms.Label();
            this.gridKhoMuonVT = new System.Windows.Forms.DataGridView();
            this.cbKhoChoMuon = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnTraNo = new System.Windows.Forms.Button();
            this.ID_kho_muon_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Kho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Kho_muon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_vat_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_phieu_xuat_tam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_chat_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_chat_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridKhoMuonVT)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 14);
            this.label9.TabIndex = 46;
            this.label9.Text = "Mã vật tư";
            // 
            // gridKhoMuonVT
            // 
            this.gridKhoMuonVT.AllowUserToAddRows = false;
            this.gridKhoMuonVT.AllowUserToDeleteRows = false;
            this.gridKhoMuonVT.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.gridKhoMuonVT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridKhoMuonVT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridKhoMuonVT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridKhoMuonVT.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridKhoMuonVT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridKhoMuonVT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridKhoMuonVT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_kho_muon_vat_tu,
            this.ID_Kho,
            this.ID_Kho_muon,
            this.Ma_vat_tu,
            this.Ma_phieu_xuat_tam,
            this.Id_chat_luong,
            this.Ten_chat_luong});
            this.gridKhoMuonVT.Location = new System.Drawing.Point(0, 140);
            this.gridKhoMuonVT.MultiSelect = false;
            this.gridKhoMuonVT.Name = "gridKhoMuonVT";
            this.gridKhoMuonVT.ReadOnly = true;
            this.gridKhoMuonVT.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridKhoMuonVT.RowHeadersVisible = false;
            this.gridKhoMuonVT.RowTemplate.Height = 30;
            this.gridKhoMuonVT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridKhoMuonVT.Size = new System.Drawing.Size(885, 301);
            this.gridKhoMuonVT.TabIndex = 48;
            // 
            // cbKhoChoMuon
            // 
            this.cbKhoChoMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbKhoChoMuon.FormattingEnabled = true;
            this.cbKhoChoMuon.Location = new System.Drawing.Point(64, 98);
            this.cbKhoChoMuon.Name = "cbKhoChoMuon";
            this.cbKhoChoMuon.Size = new System.Drawing.Size(198, 22);
            this.cbKhoChoMuon.TabIndex = 64;
            this.cbKhoChoMuon.SelectionChangeCommitted += new System.EventHandler(this.cbKhoNhap_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 14);
            this.label1.TabIndex = 65;
            this.label1.Text = "Danh sách các vật tư đã mượn từ kho khác";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(268, 91);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 36);
            this.btnXem.TabIndex = 66;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Trả nợ vật tư";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(830, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "Đóng";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.close_bmc;
            this.btnDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDong.Location = new System.Drawing.Point(820, 6);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(50, 50);
            this.btnDong.TabIndex = 2;
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(359, 30);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(222, 14);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Lưu ý: Ô màu vàng bắt buộc phải nhập";
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnTraNo);
            this.pnlMenu.Controls.Add(this.linkLabel1);
            this.pnlMenu.Controls.Add(this.btnDong);
            this.pnlMenu.Controls.Add(this.label7);
            this.pnlMenu.Controls.Add(this.label5);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(885, 92);
            this.pnlMenu.TabIndex = 45;
            // 
            // btnTraNo
            // 
            this.btnTraNo.Location = new System.Drawing.Point(17, 12);
            this.btnTraNo.Name = "btnTraNo";
            this.btnTraNo.Size = new System.Drawing.Size(75, 46);
            this.btnTraNo.TabIndex = 8;
            this.btnTraNo.Text = "Trả nợ";
            this.btnTraNo.UseVisualStyleBackColor = true;
            this.btnTraNo.Click += new System.EventHandler(this.btnTraNo_Click);
            // 
            // ID_kho_muon_vat_tu
            // 
            this.ID_kho_muon_vat_tu.DataPropertyName = "ID_kho_muon_vat_tu";
            this.ID_kho_muon_vat_tu.HeaderText = "ID";
            this.ID_kho_muon_vat_tu.Name = "ID_kho_muon_vat_tu";
            this.ID_kho_muon_vat_tu.ReadOnly = true;
            // 
            // ID_Kho
            // 
            this.ID_Kho.DataPropertyName = "ID_Kho";
            this.ID_Kho.HeaderText = "ID_Kho";
            this.ID_Kho.Name = "ID_Kho";
            this.ID_Kho.ReadOnly = true;
            // 
            // ID_Kho_muon
            // 
            this.ID_Kho_muon.DataPropertyName = "ID_Kho_muon";
            this.ID_Kho_muon.HeaderText = "ID_Kho_muon";
            this.ID_Kho_muon.Name = "ID_Kho_muon";
            this.ID_Kho_muon.ReadOnly = true;
            // 
            // Ma_vat_tu
            // 
            this.Ma_vat_tu.DataPropertyName = "Ma_vat_tu";
            this.Ma_vat_tu.HeaderText = "Ma_vat_tu";
            this.Ma_vat_tu.Name = "Ma_vat_tu";
            this.Ma_vat_tu.ReadOnly = true;
            // 
            // Ma_phieu_xuat_tam
            // 
            this.Ma_phieu_xuat_tam.DataPropertyName = "Ma_phieu_xuat_tam";
            this.Ma_phieu_xuat_tam.HeaderText = "Ma_phieu_xuat_tam";
            this.Ma_phieu_xuat_tam.Name = "Ma_phieu_xuat_tam";
            this.Ma_phieu_xuat_tam.ReadOnly = true;
            // 
            // Id_chat_luong
            // 
            this.Id_chat_luong.DataPropertyName = "Id_chat_luong";
            this.Id_chat_luong.HeaderText = "Id_chat_luong";
            this.Id_chat_luong.Name = "Id_chat_luong";
            this.Id_chat_luong.ReadOnly = true;
            // 
            // Ten_chat_luong
            // 
            this.Ten_chat_luong.DataPropertyName = "Ten_chat_luong";
            this.Ten_chat_luong.HeaderText = "Ten_chat_luong";
            this.Ten_chat_luong.Name = "Ten_chat_luong";
            this.Ten_chat_luong.ReadOnly = true;
            // 
            // frmNoVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 453);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbKhoChoMuon);
            this.Controls.Add(this.gridKhoMuonVT);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pnlMenu);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmNoVatTu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tồn Đầu Kỳ";
            this.Load += new System.EventHandler(this.frmTheGoiDau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridKhoMuonVT)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView gridKhoMuonVT;
        private System.Windows.Forms.ComboBox cbKhoChoMuon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnTraNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_kho_muon_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Kho;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Kho_muon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_vat_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_phieu_xuat_tam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_chat_luong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_chat_luong;
    }
}

