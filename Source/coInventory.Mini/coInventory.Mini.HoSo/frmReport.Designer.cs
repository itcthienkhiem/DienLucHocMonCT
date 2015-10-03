namespace coInventory.Mini.HoSo
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.repordView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rpDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            this.SuspendLayout();
            // 
            // repordView
            // 
            this.repordView.ActiveViewIndex = -1;
            this.repordView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.repordView.Cursor = System.Windows.Forms.Cursors.Default;
            this.repordView.DisplayGroupTree = false;
            this.repordView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.repordView.Location = new System.Drawing.Point(0, 0);
            this.repordView.Name = "repordView";
            this.repordView.SelectionFormula = "";
            this.repordView.Size = new System.Drawing.Size(784, 562);
            this.repordView.TabIndex = 0;
            this.repordView.ViewTimeSelectionFormula = "";
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.repordView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer repordView;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpDocument;
    }
}