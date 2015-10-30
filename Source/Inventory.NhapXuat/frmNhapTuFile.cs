using Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
using System.DirectoryServices;
using Inventory.Models;
using System.Threading;
using System.Diagnostics;
namespace Inventory.NhapXuat
{
    public partial class frmNhapTuFile : Form
    {

        public frmNhapTuFile()
        {
            InitializeComponent();   // To report progress from the background worker we need to set this property
            countLabel = "/" + count.ToString();
         
        }
        int count = 0;
        delegate void StringParameterDelegate(string value);
        String countLabel;
        //When your button is clicked to process the loops, start a thread for process the loops
        public void StartProcessingButtonClick(object sender, EventArgs e)
        {
            Thread queryRunningThread = new Thread(new ThreadStart(ProcessLoop));
            queryRunningThread.Name = "ProcessLoop";
            queryRunningThread.IsBackground = true;
            queryRunningThread.Start();
        }

        private void ProcessLoop()
        {
            for (int i = 0; i < count; i++)
            {

                UpdateProgressLabel("Step " + i.ToString() + countLabel);
            }
        }

        void UpdateProgressLabel(string value)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UpdateProgressLabel), new object[] { value });
                return;
            }
            // Must be on the UI thread if we've got this far
            labelProgress.Text = value;
            Progressbar.Value = int.Parse(value);
        }
        private void btnDuyetFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open excel File";
            theDialog.Filter = "xlsx files|*.xlsx";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                txtTenDuongDan.Text = (theDialog.FileName.ToString());
            }
            try
            {

            }



            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        DataTable tb = null;
        private void ReadFile(FileStream stream)
        {
            IExcelDataReader excelReader = null;
            if (stream.Name.Split('.')[1].Equals("xls"))
            {

                //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            else
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            DataSet result = excelReader.AsDataSet();

            //4. DataSet - Create column names from first row
            //  excelReader.IsFirstRowAsColumnNames = true;
            //  DataSet result = excelReader.AsDataSet();
            //  ChuanHoaDuLieu(result);
            //  gridDanhSachPhieuNhap.DataSource = ChuanHoaDuLieu(result);
            gridDanhSachPhieuNhap.DataSource = result.Tables[cbChonSheet.SelectedIndex];
            this.gridDanhSachPhieuNhap.Sort(this.gridDanhSachPhieuNhap.Columns["column1"], ListSortDirection.Ascending);
            tb = result.Tables[cbChonSheet.SelectedIndex].Copy();


            DataView dv = tb.DefaultView;
            //   Sort data
            dv.Sort = "column1";
            //   Convert back your sorted DataView to DataTable
            tb = dv.ToTable();
            RemoveAllRowsNULL(tb);
            gridDanhSachPhieuNhap.DataSource = tb;
            //5. Data Reader methods
            //while (excelReader.Read())
            //{
            //    //excelReader.GetInt32(0);
            //}
            //clsPhieuNhapKho pn = new clsPhieuNhapKho();

            //6. Free resources (IExcelDataReader is IDisposable)
        }
        public void RemoveAllRowsNULL(DataTable tb)
        {
            //xóa hết các dòng rỗng
            for (int i = tb.Rows.Count - 1; i >= 0; i--)
                if (tb.Rows[i]["column1"].ToString() == "")
                    tb.Rows.RemoveAt(i);
            //xóa hết các cột rỗng 
            for (int i = tb.Columns.Count - 1; i >= 0; i--)
                if (tb.Rows[0][i].ToString() == "")
                    tb.Columns.RemoveAt(i);

        }
        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            } return newSortDirection;


        }


        private void gridDanhSachPhieuNhap_Sorted(object sender, EventArgs e)
        {

        }



        private void btnSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbChonSheet.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn sheet hiển thị!");
                    return;
                }
                FileStream stream = File.Open(txtTenDuongDan.Text, FileMode.Open, FileAccess.Read);

                //lấy định dạng 
                //nếu 2003 
                ReadFile(stream);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          
            btnDuyetFile_Click(sender, e);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string Loai_PN;
        private void btnChuyenDoi_Click(object sender, EventArgs e)
        {
            try
            {
                 Loai_PN = cbLPN.Text;
                Progressbar.Maximum = tb.Rows.Count;
                backgroundWorker1.RunWorkerAsync();
                //Thread queryRunningThread = new Thread(new ThreadStart(ChuyenDoi));
                //queryRunningThread.Name = "ProcessLoop";
                //queryRunningThread.IsBackground = true;
                //queryRunningThread.Start();
                // ChuyenDoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex));
            }
        }
        /// <summary>
        /// hàm này tiến hành cập nhật lại CSDL rất lớn liên quang 5000 dòng
        /// 
        /// </summary>
        public void ChuyenDoi()
        {
            //    Progressbar.Value=0;
            //  countLabel = tb.Rows.Count.ToString();
         //   
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            // insert
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < tb.Rows.Count - 1; i++)
                    {
                        string Ma_phieu_nhap = tb.Rows[i]["column1"].ToString();
                        DateTime Ngay_lap = DateTime.Parse(tb.Rows[i]["column2"].ToString());
                        string Kho_nhan = tb.Rows[i]["column3"].ToString();
                        string Ly_do = tb.Rows[i]["column4"].ToString();
                        string Ma_vat_tu = tb.Rows[i]["column5"].ToString();
                        string Ten_vat_tu = tb.Rows[i]["column6"].ToString();
                        string Chat_luong = tb.Rows[i]["column7"].ToString();

                        string DVT = tb.Rows[i]["column8"].ToString();
                        string So_luong_thuc_lanh = tb.Rows[i]["column9"].ToString();
                        string Don_gia = tb.Rows[i]["column10"].ToString();
                        string Thanh_tien = tb.Rows[i]["column11"].ToString();
                    // tb.Rows[i]["column12"].ToString()??"XD";
                        //kiểm tra xem dòng đó có trùng với phiếu nhận trong bảng pn chưa     
                        clsPhieuNhapKho pnk = new clsPhieuNhapKho();
                        if (pnk.CheckTonTaiSoDK(Ma_phieu_nhap, help) == false)
                        {
                            pnk.Ma_phieu_nhap = Ma_phieu_nhap;
                            pnk.isGoiDau = chbGoiDau.Checked;
                            pnk.Ngay_lap = Ngay_lap;
                            pnk.Kho_nhan = Kho_nhan;
                            pnk.Ly_do = Ly_do;
                            clsLoaiPhieuNhap LPN = new clsLoaiPhieuNhap();
                            LPN.Ma_LPN = Loai_PN;
                            
                            pnk.ID_Loai_Phieu_Nhap = LPN.GetFirst(help);

                            if (pnk.Insert(help) == 0)
                            {
                                dbcxtransaction.Rollback();
                                MessageBox.Show("insert thất bại tại dòng !" + i);
                                return;
                            }

                        }
                        clsChi_Tiet_Phieu_Nhap_Vat_Tu ctpn = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
                        ctpn.Ma_vat_tu = Ma_vat_tu;
                        ctpn.Ma_phieu_nhap = Ma_phieu_nhap;
                        ctpn.ID_Chat_luong = Chat_luong.Contains("mới") ? 1 : 2;
                        //kiểm tra xem vật tư đã có trong csdl chưa nếu chưa thêm vào 
                        clsDM_DonViTinh DMDVT = new clsDM_DonViTinh();
                        if (ctpn.CheckTonTaiSoDK(help)==false)
                        {

                            DMDVT.Ten_don_vi_tinh = DVT;

                            //  DMDVT.ID_Don_vi_tinh = ctpn.ID_Don_vi_tinh;

                            if (DMDVT.hasDuplicateRow(help) == false)
                            {
                                //nếu chưa có thì insert dòng mới 
                                DMDVT.Insert(help);
                            }





                            //tiến hành insert 5000 dòng dữ liệu từ phiếu nhập
                        }
                        ctpn.ID_Don_vi_tinh = DMDVT.getMATuTen(DVT, help);
                        //kiểm tra mã vật tư đã tồn tại chưa trong CSDL
                        clsDMVatTu vt = new clsDMVatTu();
                        vt.Ma_vat_tu = Ma_vat_tu;
                        vt.Ten_vat_tu = Ten_vat_tu;
                        vt.ID_Don_vi_tinh = ctpn.ID_Don_vi_tinh;
                        if (vt.KiemTraTrungMa(help) == false)
                        {
                            vt.Insert(help);
                        }
                        ctpn.So_luong_thuc_lanh = decimal.Parse(So_luong_thuc_lanh);
                        ctpn.Insert(help);
                        backgroundWorker1.ReportProgress(i);
                       // System.Threading.Thread.Sleep(100); 
                        // Simulate long task 

                        //  queryRunningThread.Abort();

                    }
                    dbcxtransaction.Commit();
                    backgroundWorker1.ReportProgress(0);
                    MessageBox.Show("Thêm thành công!");
                }
                catch (Exception ex)
                {
                    dbcxtransaction.Rollback();  // Get stack trace for the exception with source file information
                    MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex));

                    return;

                }

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ChuyenDoi();
            // Your background task goes here 

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progressbar.Value = e.ProgressPercentage;
            lbTxt.Text = String.Format("Progress: {0}", e.ProgressPercentage);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void frmNhapTuFile_Load(object sender, EventArgs e)
        {
            clsGiaoDienChung.initCombobox(cbLPN, new clsLoaiPhieuNhap(), "Ma_loai_phieu_nhap", "ID_loai_phieu_nhap", "Ma_loai_phieu_nhap");
       
        }
    }
}
