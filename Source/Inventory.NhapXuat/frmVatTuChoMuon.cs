using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
using Inventory.Report;
using Inventory.Models;
namespace Inventory.NhapXuat
{
    public partial class frmVatTuChoMuon : DevExpress.XtraEditors.XtraForm
    {
        public frmVatTuChoMuon()
        {
            InitializeComponent();
            init();
            clsGiaoDienChung.initCombobox(cbKhoNhanVatTu, new clsDM_Kho(), "Ten_kho", "ID_kho", "Ten_kho");
          
            //cbKhoNhanVatTu.DataSource = clsDM_Kho.getAll();
            //cbKhoNhanVatTu.DisplayMember = "Ten_kho";
            //cbKhoNhanVatTu.ValueMember = "ID_kho";
        }
        public void init()
        {
            //lay danh sach cac vat tu trong phieu nhap chua phan vao kho 
          
            clsChi_Tiet_Phieu_Nhap_Vat_Tu pnk = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
            gridDanhSachPhieuNhap.DataSource = pnk.GetAllVatTuChoMuonNo();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                idKho = (int)cbKhoNhanVatTu.SelectedValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn chưa chọn kho ");
            }

            //progressAll.Maximum = gridDanhSachPhieuNhap.Rows.Count;
            //backgroundWorker1.RunWorkerAsync();
            try
            {
                Int32 selectedRowCount = gridDanhSachPhieuNhap.CurrentCell.RowIndex;
                DataGridViewRow SelectedRow = gridDanhSachPhieuNhap.Rows[selectedRowCount];
                string mavt = SelectedRow.Cells["Ma_vat_tu"].Value.ToString();
                string maphieu = SelectedRow.Cells["Ma_phieu_nhap"].Value.ToString();
                if (cbKhoNhanVatTu.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn kho để phân vật tư");
                    return;
                }

                //  string soluong = SelectedRow.Cells["So_luong"].Value.ToString();
                string tenvt = SelectedRow.Cells["Ten_vat_tu"].Value.ToString();
                string tenkho = cbKhoNhanVatTu.Text;
                decimal soluong = decimal.Parse(SelectedRow.Cells["So_luong_thuc_lanh"].Value.ToString());
                //  string mavt = SelectedRow.Cells["Ma_vat_tu"].Value.ToString();
                int idcl = int.Parse(SelectedRow.Cells["ID_chat_luong"].Value.ToString());
                frmChiTietNhanVatTu ob = new frmChiTietNhanVatTu(this, maphieu, mavt, idKho, soluong, tenvt, tenkho, idcl);


                ob.Show(); //show child
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        
        }
        int idKho;
        private void InProgress()
        {
         
            if (chbChonTatCa.Checked == false)
            {
                try
                {
                    Int32 selectedRowCount = gridDanhSachPhieuNhap.CurrentCell.RowIndex;
                    DataGridViewRow SelectedRow = gridDanhSachPhieuNhap.Rows[selectedRowCount];
                    string mavt = SelectedRow.Cells["Ma_vat_tu"].Value.ToString();
                    string maphieu = SelectedRow.Cells["Ma_phieu_nhap"].Value.ToString();
                    if (cbKhoNhanVatTu.Text == "")
                    {
                        MessageBox.Show("Bạn chưa chọn kho để phân vật tư");
                        return;
                    }
                   
                    //  string soluong = SelectedRow.Cells["So_luong"].Value.ToString();
                    string tenvt = SelectedRow.Cells["Ten_vat_tu"].Value.ToString();
                    string tenkho = cbKhoNhanVatTu.Text;
                    decimal soluong = decimal.Parse(SelectedRow.Cells["So_luong_thuc_lanh"].Value.ToString());
                    //  string mavt = SelectedRow.Cells["Ma_vat_tu"].Value.ToString();
                    int idcl = int.Parse(SelectedRow.Cells["ID_chat_luong"].Value.ToString());
                    frmChiTietNhanVatTu ob = new frmChiTietNhanVatTu(this, maphieu, mavt, idKho, soluong, tenvt, tenkho, idcl);


                    ob.Show(); //show child
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
              
                //txtRunning.Visible = true;
                //progressAll.Visible = true;
                DatabaseHelper help = new DatabaseHelper();
                help.ConnectDatabase();
                using (var dbcxtransaction = help.ent.Database.BeginTransaction())
                {

                    for (int i = 0; i < gridDanhSachPhieuNhap.Rows.Count; i++)
                    {
                        string mavt = gridDanhSachPhieuNhap.Rows[i].Cells["Ma_vat_tu"].Value.ToString();
                        string maphieu = gridDanhSachPhieuNhap.Rows[i].Cells["Ma_phieu_nhap"].Value.ToString();
                       
                        string tenvt = gridDanhSachPhieuNhap.Rows[i].Cells["Ten_vat_tu"].Value.ToString();
                       // string tenkho = cbKhoNhanVatTu.Text;
                        decimal soluong = decimal.Parse(gridDanhSachPhieuNhap.Rows[i].Cells["So_luong_thuc_lanh"].Value.ToString());
                        int idcl = int.Parse(gridDanhSachPhieuNhap.Rows[i].Cells["ID_chat_luong"].Value.ToString());

                        clsXuLyDuLieuChung dc = new clsXuLyDuLieuChung();
                        DateTime ngayNhap = DateTime.Now;
                        try
                        {
                            if (dc.InsertTonKho(help, mavt, idKho, soluong, maphieu, ngayNhap, idcl,true) == 0)
                            {
                                dbcxtransaction.Rollback();
                                MessageBox.Show("Thêm thất bại tại dòng " + i);
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            dbcxtransaction.Rollback();
                            MessageBox.Show("Thêm thất bại tại dòng " + i);
                            return;
                        }
                        //dbcxtransaction.Commit();
                        backgroundWorker1.ReportProgress(i);
                        
                    }
                    dbcxtransaction.Commit();
                }

            }
        }
        void ob_FormClosed(object sender, FormClosedEventArgs e)
        {
            //process form close
            init();
        }

        void ob_ButtonClicked(object sender, EventArgs e)
        {
            //process button clicked
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            InProgress();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressAll.Value = e.ProgressPercentage;
            txtRunning.Text = String.Format("Progress: {0}", e.ProgressPercentage);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

    }
}
