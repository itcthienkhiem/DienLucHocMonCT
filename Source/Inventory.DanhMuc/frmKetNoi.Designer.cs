namespace Inventory.DanhMuc
{
    partial class frmKetNoi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenCSDL = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtServerName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTenCSDL);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPwd);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 163);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin kết nối cơ sở dữ liệu";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(131, 28);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(239, 22);
            this.txtServerName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label4.Location = new System.Drawing.Point(20, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tên CSDL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server Name";
            // 
            // txtTenCSDL
            // 
            this.txtTenCSDL.Location = new System.Drawing.Point(131, 110);
            this.txtTenCSDL.Name = "txtTenCSDL";
            this.txtTenCSDL.Size = new System.Drawing.Size(239, 22);
            this.txtTenCSDL.TabIndex = 15;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(131, 54);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(239, 22);
            this.txtUser.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.Location = new System.Drawing.Point(20, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.Location = new System.Drawing.Point(20, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(131, 84);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(239, 22);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.up_bmc;
            this.btnKetNoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKetNoi.Location = new System.Drawing.Point(120, 170);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(58, 54);
            this.btnKetNoi.TabIndex = 2;
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label5.Location = new System.Drawing.Point(129, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "Kết nối";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label6.Location = new System.Drawing.Point(239, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 14);
            this.label6.TabIndex = 19;
            this.label6.Text = "Hủy";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.cancel_gmc;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(223, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 54);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmKetNoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 252);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnKetNoi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKetNoi";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kết nối cơ sở dữ liệu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenCSDL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}