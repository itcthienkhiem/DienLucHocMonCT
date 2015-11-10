namespace Inventory.UserControls
{
    partial class UC_VatTu
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
            this.label4 = new System.Windows.Forms.Label();
            this.cbTenVatTu = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMaVatTu = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Tên vật tư";
            // 
            // cbTenVatTu
            // 
            this.cbTenVatTu.FormattingEnabled = true;
            this.cbTenVatTu.Location = new System.Drawing.Point(276, 17);
            this.cbTenVatTu.Name = "cbTenVatTu";
            this.cbTenVatTu.Size = new System.Drawing.Size(151, 21);
            this.cbTenVatTu.TabIndex = 67;
            this.cbTenVatTu.SelectedIndexChanged += new System.EventHandler(this.cbTenVatTu_SelectedIndexChanged);
            this.cbTenVatTu.SelectionChangeCommitted += new System.EventHandler(this.cbTenVatTu_SelectionChangeCommitted);
            this.cbTenVatTu.MouseEnter += new System.EventHandler(this.cbTenVatTu_MouseEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "Mã vật tư";
            // 
            // cbMaVatTu
            // 
            this.cbMaVatTu.FormattingEnabled = true;
            this.cbMaVatTu.Location = new System.Drawing.Point(63, 17);
            this.cbMaVatTu.Name = "cbMaVatTu";
            this.cbMaVatTu.Size = new System.Drawing.Size(151, 21);
            this.cbMaVatTu.TabIndex = 65;
            this.cbMaVatTu.SelectedIndexChanged += new System.EventHandler(this.cbMaVatTu_SelectedIndexChanged);
            this.cbMaVatTu.SelectionChangeCommitted += new System.EventHandler(this.cbMaVatTu_SelectionChangeCommitted);
            this.cbMaVatTu.MouseEnter += new System.EventHandler(this.cbMaVatTu_MouseEnter);
            // 
            // UC_VatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbTenVatTu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbMaVatTu);
            this.Name = "UC_VatTu";
            this.Size = new System.Drawing.Size(434, 54);
            this.Load += new System.EventHandler(this.UC_VatTu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTenVatTu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMaVatTu;
    }
}
