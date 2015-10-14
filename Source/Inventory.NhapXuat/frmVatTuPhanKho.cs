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
    public partial class frmVatTuPhanKho : Form
    {
        public frmVatTuPhanKho()
        {
            InitializeComponent();
            init();

            cbKhoNhanVatTu.DataSource = clsDM_Kho.getAll();
            cbKhoNhanVatTu.DisplayMember = "Ten_kho";
            cbKhoNhanVatTu.ValueMember = "ID_kho";
        }
        public void init()
        {
            //lay danh sach cac vat tu trong phieu nhap chua phan vao kho 
            clsChi_Tiet_Phieu_Nhap_Vat_Tu pnk = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
            gridDanhSachPhieuNhap.DataSource= pnk.GetAllChuaPhanKho();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = gridDanhSachPhieuNhap.CurrentCell.RowIndex;
            DataGridViewRow SelectedRow = gridDanhSachPhieuNhap.Rows[selectedRowCount];
            string mavt = SelectedRow.Cells["Ma_vat_tu"].Value.ToString();
            string maphieu = SelectedRow.Cells["Ma_phieu_nhap"].Value.ToString();
            int idKho =(int)cbKhoNhanVatTu.SelectedValue;
          //  string soluong = SelectedRow.Cells["So_luong"].Value.ToString();
            string tenvt = SelectedRow.Cells["Ten_vat_tu"].Value.ToString();
            string tenkho = cbKhoNhanVatTu.SelectedItem.ToString();
            int soluong=int.Parse( SelectedRow.Cells["So_luong"].Value.ToString());
          //  string mavt = SelectedRow.Cells["Ma_vat_tu"].Value.ToString();

            frmChiTietNhanVatTu ob = new frmChiTietNhanVatTu(this,maphieu,mavt,idKho,soluong,tenvt,tenkho);
           
       
            ob.Show(); //show child
            
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

    }
}
