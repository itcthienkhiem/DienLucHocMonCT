namespace eHospital.Filters
{
    partial class eHospital
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoc = new System.Windows.Forms.Button();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbDieuKien = new System.Windows.Forms.ComboBox();
            this.cbbTruongDuLieu = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(649, 7);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(75, 23);
            this.btnLoc.TabIndex = 16;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Location = new System.Drawing.Point(457, 8);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(177, 20);
            this.txtGiaTri.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(413, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Giá trị";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(255, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Điều kiện";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Trường dữ liệu";
            // 
            // cbbDieuKien
            // 
            this.cbbDieuKien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDieuKien.FormattingEnabled = true;
            this.cbbDieuKien.Location = new System.Drawing.Point(318, 8);
            this.cbbDieuKien.Name = "cbbDieuKien";
            this.cbbDieuKien.Size = new System.Drawing.Size(89, 21);
            this.cbbDieuKien.TabIndex = 10;
            // 
            // cbbTruongDuLieu
            // 
            this.cbbTruongDuLieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTruongDuLieu.FormattingEnabled = true;
            this.cbbTruongDuLieu.Location = new System.Drawing.Point(102, 8);
            this.cbbTruongDuLieu.Name = "cbbTruongDuLieu";
            this.cbbTruongDuLieu.Size = new System.Drawing.Size(137, 21);
            this.cbbTruongDuLieu.TabIndex = 11;
            // 
            // eHospital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.txtGiaTri);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbDieuKien);
            this.Controls.Add(this.cbbTruongDuLieu);
            this.Name = "eHospital";
            this.Size = new System.Drawing.Size(763, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbDieuKien;
        private System.Windows.Forms.ComboBox cbbTruongDuLieu;
    }
}
