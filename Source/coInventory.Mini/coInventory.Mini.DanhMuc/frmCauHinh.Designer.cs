namespace coInventory.Mini.DanhMuc
{
    partial class frmCauHinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCauHinh));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPathCSDL = new System.Windows.Forms.TextBox();
            this.btnChon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboMayIn = new System.Windows.Forms.ComboBox();
            this.btnMacDinhMayIn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnSaoLuu = new System.Windows.Forms.Button();
            this.btnPathBackup = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPathBackup = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường dẫn CSDL";
            // 
            // txtPathCSDL
            // 
            this.txtPathCSDL.Location = new System.Drawing.Point(126, 20);
            this.txtPathCSDL.Name = "txtPathCSDL";
            this.txtPathCSDL.Size = new System.Drawing.Size(427, 22);
            this.txtPathCSDL.TabIndex = 12;
            // 
            // btnChon
            // 
            this.btnChon.Location = new System.Drawing.Point(559, 19);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(29, 23);
            this.btnChon.TabIndex = 13;
            this.btnChon.TabStop = false;
            this.btnChon.Text = "...";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên đăng nhập";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(126, 27);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(142, 22);
            this.txtTenDangNhap.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(126, 57);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(142, 22);
            this.txtMatKhau.TabIndex = 2;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTenDangNhap);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMatKhau);
            this.groupBox1.Location = new System.Drawing.Point(4, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đăng nhập hệ thống eClaim";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cboMayIn);
            this.groupBox3.Controls.Add(this.btnMacDinhMayIn);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(4, 406);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(507, 69);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chọn máy in";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(403, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 14);
            this.label10.TabIndex = 9;
            this.label10.Text = "Mặc định";
            // 
            // cboMayIn
            // 
            this.cboMayIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMayIn.FormattingEnabled = true;
            this.cboMayIn.ItemHeight = 14;
            this.cboMayIn.Location = new System.Drawing.Point(126, 28);
            this.cboMayIn.Name = "cboMayIn";
            this.cboMayIn.Size = new System.Drawing.Size(260, 22);
            this.cboMayIn.TabIndex = 0;
            // 
            // btnMacDinhMayIn
            // 
            this.btnMacDinhMayIn.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.printOut_omc;
            this.btnMacDinhMayIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMacDinhMayIn.Location = new System.Drawing.Point(410, 12);
            this.btnMacDinhMayIn.Name = "btnMacDinhMayIn";
            this.btnMacDinhMayIn.Size = new System.Drawing.Size(40, 40);
            this.btnMacDinhMayIn.TabIndex = 1;
            this.btnMacDinhMayIn.TabStop = false;
            this.btnMacDinhMayIn.UseVisualStyleBackColor = true;
            this.btnMacDinhMayIn.Click += new System.EventHandler(this.btnMacDinhMayIn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 14);
            this.label9.TabIndex = 7;
            this.label9.Text = "Máy in";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::coInventory.Mini.DanhMuc.Properties.Resources.save_bmc;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Location = new System.Drawing.Point(541, 416);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 40);
            this.btnSave.TabIndex = 4;
            this.btnSave.TabStop = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(524, 458);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 14);
            this.label11.TabIndex = 9;
            this.label11.Text = "Lưu cấu hình";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.progressBar);
            this.groupBox4.Controls.Add(this.btnRestore);
            this.groupBox4.Controls.Add(this.btnSaoLuu);
            this.groupBox4.Controls.Add(this.btnPathBackup);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.btnChon);
            this.groupBox4.Controls.Add(this.txtPathBackup);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtPathCSDL);
            this.groupBox4.Location = new System.Drawing.Point(4, 290);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(596, 110);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cấu hình cơ sở dữ liệu";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(309, 78);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(244, 23);
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(217, 79);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 15;
            this.btnRestore.TabStop = false;
            this.btnRestore.Text = "Phục hồi";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnSaoLuu
            // 
            this.btnSaoLuu.Location = new System.Drawing.Point(125, 78);
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.Size = new System.Drawing.Size(75, 23);
            this.btnSaoLuu.TabIndex = 14;
            this.btnSaoLuu.TabStop = false;
            this.btnSaoLuu.Text = "Sao lưu";
            this.btnSaoLuu.UseVisualStyleBackColor = true;
            this.btnSaoLuu.Click += new System.EventHandler(this.btnSaoLuu_Click);
            // 
            // btnPathBackup
            // 
            this.btnPathBackup.Location = new System.Drawing.Point(559, 49);
            this.btnPathBackup.Name = "btnPathBackup";
            this.btnPathBackup.Size = new System.Drawing.Size(29, 23);
            this.btnPathBackup.TabIndex = 15;
            this.btnPathBackup.TabStop = false;
            this.btnPathBackup.Text = "...";
            this.btnPathBackup.UseVisualStyleBackColor = true;
            this.btnPathBackup.Click += new System.EventHandler(this.btnPathBackup_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 14);
            this.label13.TabIndex = 0;
            this.label13.Text = "Đường dẫn Sao Lưu";
            // 
            // txtPathBackup
            // 
            this.txtPathBackup.Location = new System.Drawing.Point(126, 49);
            this.txtPathBackup.Name = "txtPathBackup";
            this.txtPathBackup.ReadOnly = true;
            this.txtPathBackup.Size = new System.Drawing.Size(427, 22);
            this.txtPathBackup.TabIndex = 14;
            // 
            // frmCauHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 481);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCauHinh";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cấu hình hệ thống";
            this.Load += new System.EventHandler(this.frmCauHinh_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCauHinh_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPathCSDL;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboMayIn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnMacDinhMayIn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnPathBackup;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPathBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnSaoLuu;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}