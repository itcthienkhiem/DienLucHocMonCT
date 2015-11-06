using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inventory.Report
{
    public partial class frmReport_The_kho : Form
    {
        //clsChiTietPhieuXuatTam chitiet_pxt = new clsChiTietPhieuXuatTam();

        //string maPhieu = "";
        //DateTime ngay;
        //string truong_nhom;

        DataTable ct_thekho;

        string ma_vt;
        string ten_vt;
        string dvt;

        DataSet dsMyDataSet = new DataSet();

        public frmReport_The_kho()
        {
            InitializeComponent();
        }

        public frmReport_The_kho(DataTable ct_tk, string ma_vt, string ten_vt, string dvt)
        {
            InitializeComponent();
            this.ct_thekho = ct_tk.Copy();
            this.ma_vt = ma_vt;
            this.ten_vt = ten_vt;
            this.dvt = dvt;
        }

        private void frmReport_The_kho_Load(object sender, EventArgs e)
        {
            if (ct_thekho.Rows.Count > 0)
            {
                this.SetupDataSet();
                this.Viewreport();
            }
            else
            {
                MessageBox.Show("Thẻ kho đã chọn ko chứa dữ liệu!");
                //this.Close();
            }

            //this.reportViewerTheKho.RefreshReport();
        }

        private void SetupDataSet()
        {
            this.dsMyDataSet.Tables.Add(ct_thekho);
            ////this.dsMyDataSet.Tables.Add(PhieuNhapKho.GetThongTinPhieuNhap(maPhieu));

            //clsPhieuXuatTamVatTu PhieuXuat = new clsPhieuXuatTamVatTu();

            //DataTable dt = PhieuXuat.GetAll_byMaPhieu(maPhieu);

            ////dtNgayXuat.CustomFormat = "dd-MM-yyyy";
            //this.ngay = Convert.ToDateTime(dt.Rows[0]["Ngay_xuat"].ToString());
            ////cbMaNhanVien.SelectedValue = Int32.Parse(dt.Rows[0]["ID_nhan_vien"].ToString());

            //clsDM_NhanVien nv = new clsDM_NhanVien();
            //this.truong_nhom = nv.Get_TenNV(Int32.Parse(dt.Rows[0]["ID_nhan_vien"].ToString()));

        }



        private void Viewreport()
        {
            //Set trong property của rdlc, để ko print empty page
            //ConsumeContainerWhiteSpace = true

            //reset the report viewer
            this.reportViewerTheKho.Reset();

            //set processing to local mode
            this.reportViewerTheKho.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

            //load .rdlc file and add a datasource
            //this.reportViewer1.LocalReport.ReportPath = @"G:\[_Svn\Report\TestReport.rdlc";
            //"G:\[_Projects\Dien-Luc\Test\TestReport2\TestReport2\TestReport2\TestReport.rdlc"
            //this.reportViewerPhieuXuatTam.LocalReport.ReportPath = reportViewerPhieuXuatTam.AppSettings["Report_PhieuNhapKho"];

            this.reportViewerTheKho.LocalReport.ReportPath = @"Report_The_kho.rdlc";


            string sDataSourceName = "Chi_tiet_the_kho";

            this.reportViewerTheKho.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource(sDataSourceName, this.dsMyDataSet.Tables[0]));

            //sDataSourceName = "Phieu_Nhap_Kho";

            //this.reportViewerPhieuXuatTam.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource(sDataSourceName, this.dsMyDataSet.Tables[1]));


            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("Ma_vat_tu", this.ma_vt));
            parameters.Add(new ReportParameter("Ten_vat_tu", this.ten_vt));
            parameters.Add(new ReportParameter("Don_vi_tinh", this.dvt));
            reportViewerTheKho.LocalReport.SetParameters(parameters);

            //reportViewer1.ShowParameterPrompts = false;
            //reportViewer1.ShowPromptAreaButton = false;

            //Cấu hình cho pg
            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();

            // Set margins
            pg.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);

            // Set paper size
            pg.PaperSize = new PaperSize("A3", 1169, 1654); // 8.27 in x 11.69 in - "A3", 1169, 1654
            pg.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A3;

            pg.Landscape = false;

            // Update report and refresh
            this.reportViewerTheKho.SetPageSettings(pg);

            ////this.reportViewerPhieuNhapKho.AutoScaleDimensions = new System.Drawing.SizeF(500F, 500F);
            ////this.reportViewerPhieuNhapKho.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            // Switch to print Layout (optional)
            this.reportViewerTheKho.SetDisplayMode(DisplayMode.PrintLayout);

            //ZoomMode
            this.reportViewerTheKho.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.reportViewerTheKho.ZoomPercent = 100;

            //refresh viewer with above settings
            this.reportViewerTheKho.RefreshReport();

        }


        private Point _PrintingDPI;
        private int _PrintingIndex, _PrintingPageCount;
        private List<Stream> _PrintingStreams;
        private void reportViewerTheKho_Print(object sender, ReportPrintEventArgs e)
        {
            var ps = e.PrinterSettings; //printDialog1.PrinterSettings;

            var sb = new StringBuilder(1024);
            var xr = System.Xml.XmlWriter.Create(sb);
            xr.WriteStartElement("DeviceInfo");
            xr.WriteElementString("OutputFormat", "EMF");
            //This is only an estimate
            _PrintingPageCount = reportViewerTheKho.LocalReport.GetTotalPages();

            //Ensure EMF is recorded on a bitmap with the same resolution as the printer
            _PrintingDPI.X = ps.DefaultPageSettings.PrinterResolution.X;
            _PrintingDPI.Y = ps.DefaultPageSettings.PrinterResolution.Y;

            xr.WriteElementString("PrintDpiX", _PrintingDPI.X.ToString());
            xr.WriteElementString("PrintDpiY", _PrintingDPI.Y.ToString());

            xr.Close();

            //Estimate list capacity
            _PrintingStreams = new List<Stream>(_PrintingPageCount);

            //Render using the callback API
            Warning[] warnings;
            reportViewerTheKho.LocalReport.Render("Image",
                      sb.ToString(), lr_CreateStream, out warnings);

            //Reset all streams to the beginning
            foreach (var s in _PrintingStreams) s.Position = 0;

            e.PrinterSettings = ps;

            e.Cancel = true;

            //And print the document as normal
            var pd = new PrintDocument();

            pd.PrinterSettings = e.PrinterSettings;//ps;
            pd.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);

            pd.PrintPage += pd_PrintPage;
            pd.EndPrint += pd_EndPrint;

            //pd.Print();
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
            else
            {
                MessageBox.Show("Print Cancelled");
            }
        }

        Stream lr_CreateStream(string name, string extension,
                       Encoding encoding, string mimeType, bool willSeek)
        {
            //FileStreams could be used here to relieve memory pressure for big print jobs
            var stream = new MemoryStream();
            _PrintingStreams.Add(stream);
            return stream;
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //1. Avoid unintended rounding issues
            //   by specifying units directly as 100ths of a mm (GDI)
            //   This can be done by reading directly as a stream with no HDC
            var mf = new Metafile(_PrintingStreams[_PrintingIndex]);

            //2. Apply scaling to correct for dpi differences
            //   E.g. the mf.Width needs the PrintDpiX in order
            //        to be translated to a real width (in mm)
            var mfh = mf.GetMetafileHeader();
            e.Graphics.ScaleTransform(mfh.DpiX / _PrintingDPI.X,
                       mfh.DpiY / _PrintingDPI.Y, MatrixOrder.Prepend);

            //3. Apply scaling to fit to current page by shortest difference
            //   by comparing real page size with available printable area in 100ths of an inch
            var size = new PointF((float)mf.Size.Width / _PrintingDPI.X * 100.0f,
                                  (float)mf.Size.Height / _PrintingDPI.Y * 100.0f);
            size.X = (float)Math.Floor(e.PageSettings.PrintableArea.Width) / size.X;
            size.Y = (float)Math.Floor(e.PageSettings.PrintableArea.Height) / size.Y;
            var scale = Math.Min(size.X, size.Y);
            e.Graphics.ScaleTransform(scale, scale, MatrixOrder.Append);

            //4. Draw the image at the adjusted coordinates
            //   i.e. these are real coordinates so need to reverse the transform that is about
            //        to be applied so that when it is, these real coordinates will be the result.
            var points = new[] { new Point(e.PageSettings.Margins.Left, e.PageSettings.Margins.Top) };
            var matrix = e.Graphics.Transform;
            matrix.Invert();
            matrix.TransformPoints(points);
            //
            e.Graphics.DrawImageUnscaled(mf, points[0]);

            _PrintingIndex++;
            e.HasMorePages = (_PrintingIndex < _PrintingStreams.Count);
        }

        void pd_EndPrint(object sender, PrintEventArgs e)
        {
            //Cleanup: may get called multiple times
            foreach (var s in _PrintingStreams) s.Dispose();
            _PrintingStreams.Clear();
            //And reset for next time
            _PrintingIndex = 0;
        }
    }
}
