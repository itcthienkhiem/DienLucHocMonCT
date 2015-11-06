namespace Inventory.NhapXuat
{
    partial class frmNhapTuFile
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtTenDuongDan = new System.Windows.Forms.TextBox();
            this.gridDanhSachPhieuNhap = new System.Windows.Forms.DataGridView();
            this.cbChonSheet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChuyenDoi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Progressbar = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lbTxt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLPN = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbKhoNhan = new System.Windows.Forms.ComboBox();
            this.rdoBuTru = new System.Windows.Forms.RadioButton();
            this.rdoPhieuGoiDau = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSachPhieuNhap)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtTenDuongDan
            // 
            this.txtTenDuongDan.Location = new System.Drawing.Point(518, 17);
            this.txtTenDuongDan.Multiline = true;
            this.txtTenDuongDan.Name = "txtTenDuongDan";
            this.txtTenDuongDan.Size = new System.Drawing.Size(300, 28);
            this.txtTenDuongDan.TabIndex = 2;
            // 
            // gridDanhSachPhieuNhap
            // 
            this.gridDanhSachPhieuNhap.AllowUserToAddRows = false;
            this.gridDanhSachPhieuNhap.AllowUserToDeleteRows = false;
            this.gridDanhSachPhieuNhap.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue;
            this.gridDanhSachPhieuNhap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridDanhSachPhieuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDanhSachPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDanhSachPhieuNhap.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDanhSachPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridDanhSachPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDanhSachPhieuNhap.Location = new System.Drawing.Point(-2, 212);
            this.gridDanhSachPhieuNhap.MultiSelect = false;
            this.gridDanhSachPhieuNhap.Name = "gridDanhSachPhieuNhap";
            this.gridDanhSachPhieuNhap.ReadOnly = true;
            this.gridDanhSachPhieuNhap.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridDanhSachPhieuNhap.RowHeadersVisible = false;
            this.gridDanhSachPhieuNhap.RowTemplate.Height = 30;
            this.gridDanhSachPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDanhSachPhieuNhap.Size = new System.Drawing.Size(963, 346);
            this.gridDanhSachPhieuNhap.TabIndex = 53;
            this.gridDanhSachPhieuNhap.Sorted += new System.EventHandler(this.gridDanhSachPhieuNhap_Sorted);
            // 
            // cbChonSheet
            // 
            this.cbChonSheet.FormattingEnabled = true;
            this.cbChonSheet.Items.AddRange(new object[] {
            "Sheet0",
            "Sheet1",
            "Sheet2",
            "Sheet3",
            "Sheet4",
            "Sheet5",
            "Sheet6",
            "Sheet7"});
            this.cbChonSheet.Location = new System.Drawing.Point(80, 24);
            this.cbChonSheet.Name = "cbChonSheet";
            this.cbChonSheet.Size = new System.Drawing.Size(121, 21);
            this.cbChonSheet.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Chọn sheet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Đường dẫn";
            // 
            // btnXoa
            // 
            this.btnXoa.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.down_bmc;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXoa.Location = new System.Drawing.Point(1, 6);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(50, 50);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnSheet_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThem.Location = new System.Drawing.Point(824, 19);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(50, 26);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "...";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnDuyetFile_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(906, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "Đóng";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.close_gmc;
            this.btnDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDong.Location = new System.Drawing.Point(896, 6);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(50, 50);
            this.btnDong.TabIndex = 2;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.label4);
            this.pnlMenu.Controls.Add(this.btnChuyenDoi);
            this.pnlMenu.Controls.Add(this.label3);
            this.pnlMenu.Controls.Add(this.btnDong);
            this.pnlMenu.Controls.Add(this.label7);
            this.pnlMenu.Controls.Add(this.btnXoa);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(961, 92);
            this.pnlMenu.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Chuyển đổi ";
            // 
            // btnChuyenDoi
            // 
            this.btnChuyenDoi.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.up_bmc;
            this.btnChuyenDoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChuyenDoi.Location = new System.Drawing.Point(63, 6);
            this.btnChuyenDoi.Name = "btnChuyenDoi";
            this.btnChuyenDoi.Size = new System.Drawing.Size(50, 50);
            this.btnChuyenDoi.TabIndex = 9;
            this.btnChuyenDoi.UseVisualStyleBackColor = true;
            this.btnChuyenDoi.Click += new System.EventHandler(this.btnChuyenDoi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Đọc file";
            // 
            // Progressbar
            // 
            this.Progressbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Progressbar.Location = new System.Drawing.Point(-2, 192);
            this.Progressbar.Name = "Progressbar";
            this.Progressbar.Size = new System.Drawing.Size(963, 23);
            this.Progressbar.TabIndex = 62;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgress.Location = new System.Drawing.Point(384, 166);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 25);
            this.labelProgress.TabIndex = 63;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lbTxt
            // 
            this.lbTxt.AutoSize = true;
            this.lbTxt.Location = new System.Drawing.Point(349, 175);
            this.lbTxt.Name = "lbTxt";
            this.lbTxt.Size = new System.Drawing.Size(35, 13);
            this.lbTxt.TabIndex = 64;
            this.lbTxt.Text = "label6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Chọn loại phiếu";
            // 
            // cbLPN
            // 
            this.cbLPN.FormattingEnabled = true;
            this.cbLPN.Location = new System.Drawing.Point(312, 19);
            this.cbLPN.Name = "cbLPN";
            this.cbLPN.Size = new System.Drawing.Size(121, 21);
            this.cbLPN.TabIndex = 67;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(213, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 69;
            this.label8.Text = "Chọn Kho Nhận";
            // 
            // cbKhoNhan
            // 
            this.cbKhoNhan.FormattingEnabled = true;
            this.cbKhoNhan.Location = new System.Drawing.Point(312, 46);
            this.cbKhoNhan.Name = "cbKhoNhan";
            this.cbKhoNhan.Size = new System.Drawing.Size(121, 21);
            this.cbKhoNhan.TabIndex = 70;
            // 
            // rdoBuTru
            // 
            this.rdoBuTru.AutoSize = true;
            this.rdoBuTru.Location = new System.Drawing.Point(119, 50);
            this.rdoBuTru.Name = "rdoBuTru";
            this.rdoBuTru.Size = new System.Drawing.Size(82, 17);
            this.rdoBuTru.TabIndex = 71;
            this.rdoBuTru.TabStop = true;
            this.rdoBuTru.Text = "Phiếu bù trừ";
            this.rdoBuTru.UseVisualStyleBackColor = true;
            // 
            // rdoPhieuGoiDau
            // 
            this.rdoPhieuGoiDau.AutoSize = true;
            this.rdoPhieuGoiDau.Location = new System.Drawing.Point(50, 50);
            this.rdoPhieuGoiDau.Name = "rdoPhieuGoiDau";
            this.rdoPhieuGoiDau.Size = new System.Drawing.Size(63, 17);
            this.rdoPhieuGoiDau.TabIndex = 72;
            this.rdoPhieuGoiDau.TabStop = true;
            this.rdoPhieuGoiDau.Text = "Gối đầu";
            this.rdoPhieuGoiDau.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbLPN);
            this.groupBox1.Controls.Add(this.rdoPhieuGoiDau);
            this.groupBox1.Controls.Add(this.cbChonSheet);
            this.groupBox1.Controls.Add(this.rdoBuTru);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbKhoNhan);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTenDuongDan);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(0, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(946, 75);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // frmNhapTuFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 557);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbTxt);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.Progressbar);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.gridDanhSachPhieuNhap);
            this.Name = "frmNhapTuFile";
            this.Text = "frmNhapTuFile";
            this.Load += new System.EventHandler(this.frmNhapTuFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSachPhieuNhap)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtTenDuongDan;
        private System.Windows.Forms.DataGridView gridDanhSachPhieuNhap;
        private System.Windows.Forms.ComboBox cbChonSheet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnChuyenDoi;
        private System.Windows.Forms.ProgressBar Progressbar;
        private System.Windows.Forms.Label labelProgress;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lbTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbLPN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbKhoNhan;
        private System.Windows.Forms.RadioButton rdoBuTru;
        private System.Windows.Forms.RadioButton rdoPhieuGoiDau;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}