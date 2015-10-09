using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.SqlClient;
using System.Configuration;
using Inventory.EntityClass;

namespace Inventory.Report
{
    public partial class frmReport_Phieu_Nhap_Kho : Form
    {
        clsPhieuNhapKho PhieuNhapKho = new clsPhieuNhapKho();

        string maPhieu = "";

        DataSet dsMyDataSet = new DataSet();

        public frmReport_Phieu_Nhap_Kho()
        {
            InitializeComponent();
        }

        public frmReport_Phieu_Nhap_Kho(string maPhieu)
        {
            InitializeComponent();
            this.maPhieu = maPhieu;
        }

        private void frmReport_Phieu_Nhap_Kho_Load(object sender, EventArgs e)
        {
            if (!maPhieu.Equals(String.Empty))
            {
                this.SetupDataSet();
                this.Viewreport();
            }
            else
            {
                MessageBox.Show("Xin nhập mã phiếu");
                this.Close();
            }

            //this.reportViewerPhieuNhapKho.RefreshReport();
        }
        

        private void SetupDataSet()
        {
            this.dsMyDataSet.Tables.Add(PhieuNhapKho.GetChiTietPhieuNhap(maPhieu));
            this.dsMyDataSet.Tables.Add(PhieuNhapKho.GetThongTinPhieuNhap(maPhieu));
        }

        private void Viewreport()
        {
            //reset the report viewer
            this.reportViewerPhieuNhapKho.Reset();

            //set processing to local mode
            this.reportViewerPhieuNhapKho.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

            //check which report to test
            {
                //load .rdlc file and add a datasource
                //this.reportViewer1.LocalReport.ReportPath = @"G:\[_Svn\Report\TestReport.rdlc";
                //"G:\[_Projects\Dien-Luc\Test\TestReport2\TestReport2\TestReport2\TestReport.rdlc"
                //this.reportViewerPhieuNhapKho.LocalReport.ReportPath = @"Report_Nhap_Kho.rdlc";
                this.reportViewerPhieuNhapKho.LocalReport.ReportPath = ConfigurationManager.AppSettings["Report_PhieuNhapKho"];

                string sDataSourceName = "Chi_Tiet_Phieu_Nhap_Vat_Tu";

                this.reportViewerPhieuNhapKho.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource(sDataSourceName, this.dsMyDataSet.Tables[0]));

                sDataSourceName = "Phieu_Nhap_Kho";

                this.reportViewerPhieuNhapKho.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource(sDataSourceName, this.dsMyDataSet.Tables[1]));
            }

            //List<ReportParameter> parameters = new List<ReportParameter>();
            //parameters.Add(new ReportParameter("name", "Hey boy"));
            //reportViewer1.LocalReport.SetParameters(parameters);
            //reportViewer1.ShowParameterPrompts = false;
            //reportViewer1.ShowPromptAreaButton = false;

            System.Drawing.Printing.PageSettings pg = new PageSettings();
            // Set margins
            pg.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);

            // Set paper size 10.56895in, 4.03125in
            //pg.PaperSize = new PaperSize("A4", 827, 1169); // 8.27 in x 11.69 in
            //pg.RawKind = (int)PaperKind.A4;
            pg.Landscape = true;

            // Update report and refresh
            this.reportViewerPhieuNhapKho.SetPageSettings(pg);
            //this.reportViewer1.RefreshReport();

            this.reportViewerPhieuNhapKho.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.reportViewerPhieuNhapKho.AutoScaleDimensions = new System.Drawing.SizeF(500F, 500F);
            this.reportViewerPhieuNhapKho.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;


            //refresh viewer with above settings
            this.reportViewerPhieuNhapKho.RefreshReport();


            // Switch to print Layout (optional)
            //this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

        }
    }
}
