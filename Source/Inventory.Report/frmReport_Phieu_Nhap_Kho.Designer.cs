namespace Inventory.Report
{
    partial class frmReport_Phieu_Nhap_Kho
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
            this.reportViewerPhieuNhapKho = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerPhieuNhapKho
            // 
            this.reportViewerPhieuNhapKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerPhieuNhapKho.Location = new System.Drawing.Point(0, 0);
            this.reportViewerPhieuNhapKho.Name = "reportViewerPhieuNhapKho";
            this.reportViewerPhieuNhapKho.Size = new System.Drawing.Size(1001, 475);
            this.reportViewerPhieuNhapKho.TabIndex = 0;
            // 
            // frmReport_Phieu_Nhap_Kho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 475);
            this.Controls.Add(this.reportViewerPhieuNhapKho);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmReport_Phieu_Nhap_Kho";
            this.Text = "Report Phiếu Nhập Kho";
            this.Load += new System.EventHandler(this.frmReport_Phieu_Nhap_Kho_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPhieuNhapKho;
    }
}