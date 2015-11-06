namespace Inventory.Report
{
    partial class frmReport_phieu_xuat_tam_vat_tu
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
            this.reportViewerPhieuXuatTam = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerPhieuXuatTam
            // 
            this.reportViewerPhieuXuatTam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerPhieuXuatTam.Location = new System.Drawing.Point(0, 0);
            this.reportViewerPhieuXuatTam.Name = "reportViewerPhieuXuatTam";
            this.reportViewerPhieuXuatTam.Size = new System.Drawing.Size(916, 393);
            this.reportViewerPhieuXuatTam.TabIndex = 0;
            this.reportViewerPhieuXuatTam.Print += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.reportViewerPhieuXuatTam_Print);
            // 
            // frmReport_phieu_xuat_tam_vat_tu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 393);
            this.Controls.Add(this.reportViewerPhieuXuatTam);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "frmReport_phieu_xuat_tam_vat_tu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[Report] Phiếu xuất tạm vật tư";
            this.Load += new System.EventHandler(this.frmReport_phieu_xuat_tam_vat_tu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPhieuXuatTam;
    }
}