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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gridTonDauKy = new System.Windows.Forms.DataGridView();
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridTonDauKy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(291, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "THẺ KHO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(495, 34);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(280, 111);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 34);
            this.textBox1.TabIndex = 3;
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
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(62, 22);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(187, 34);
            this.textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(62, 74);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(187, 34);
            this.textBox4.TabIndex = 8;
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
            // gridTonDauKy
            // 
            this.gridTonDauKy.AllowUserToAddRows = false;
            this.gridTonDauKy.AllowUserToDeleteRows = false;
            this.gridTonDauKy.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            this.gridTonDauKy.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridTonDauKy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTonDauKy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTonDauKy.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTonDauKy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridTonDauKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTonDauKy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.gridTonDauKy.Location = new System.Drawing.Point(4, 151);
            this.gridTonDauKy.MultiSelect = false;
            this.gridTonDauKy.Name = "gridTonDauKy";
            this.gridTonDauKy.ReadOnly = true;
            this.gridTonDauKy.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridTonDauKy.RowHeadersVisible = false;
            this.gridTonDauKy.RowTemplate.Height = 30;
            this.gridTonDauKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTonDauKy.Size = new System.Drawing.Size(1111, 399);
            this.gridTonDauKy.TabIndex = 49;
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
            this.NGAY_THANG_CT.HeaderText = "Column1";
            this.NGAY_THANG_CT.Name = "NGAY_THANG_CT";
            this.NGAY_THANG_CT.ReadOnly = true;
            // 
            // DIEN_GIAI
            // 
            this.DIEN_GIAI.HeaderText = "Column1";
            this.DIEN_GIAI.Name = "DIEN_GIAI";
            this.DIEN_GIAI.ReadOnly = true;
            // 
            // NGAY_NHAP_XUAT
            // 
            this.NGAY_NHAP_XUAT.HeaderText = "Column1";
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(475, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 50;
            // 
            // frmTheKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 553);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.gridTonDauKy);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmTheKho";
            this.Text = "frmTheKho";
            ((System.ComponentModel.ISupportInitialize)(this.gridTonDauKy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView gridTonDauKy;
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
        private System.Windows.Forms.ComboBox comboBox1;
    }
}