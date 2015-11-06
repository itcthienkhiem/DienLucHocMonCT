namespace Inventory.Report
{
    partial class frmReport_The_kho
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
            this.reportViewerTheKho = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerTheKho
            // 
            this.reportViewerTheKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerTheKho.Location = new System.Drawing.Point(0, 0);
            this.reportViewerTheKho.Name = "reportViewerTheKho";
            this.reportViewerTheKho.Size = new System.Drawing.Size(1028, 418);
            this.reportViewerTheKho.TabIndex = 0;
            this.reportViewerTheKho.Print += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.reportViewerTheKho_Print);
            // 
            // frmReport_The_kho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 418);
            this.Controls.Add(this.reportViewerTheKho);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmReport_The_kho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[Report] Thẻ kho";
            this.Load += new System.EventHandler(this.frmReport_The_kho_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerTheKho;
    }
}