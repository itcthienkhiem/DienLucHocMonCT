using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;

namespace Inventory.NhapXuat
{
    /// <summary>
    /// Ẩn sửa, xóa, save
    /// Chọn lưới --> Add thêm chi tiết --> link qua nhập kho
    /// Danh phiếu xuất --> tương tự, tùy theo DB
    /// ?
    /// </summary>
    public partial class frmDanhSachPhieuNhap : Form
    {
       //
        public frmDanhSachPhieuNhap()
        {
            InitializeComponent();
            clsPhieuNhapKho phieuNhap = new clsPhieuNhapKho();
            gridMaster .DataSource =   phieuNhap.GetAll();
        }

        private void gridMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmNhapKho nhapkho = new frmNhapKho();
            nhapkho.Show();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
             Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;

            clsPhieuNhapKho phieuNhap = new clsPhieuNhapKho();
            //phieuNhap.ID_phieu_nhap =int.Parse( gridMaster.Rows[selectedRowCount].Cells["ID_phieu_nhap"].Value.ToString());
            phieuNhap.ID_kho =int.Parse( gridMaster.Rows[selectedRowCount].Cells["ID_kho"].Value.ToString());
            phieuNhap.Ngay_lap =DateTime.Parse( gridMaster.Rows[selectedRowCount].Cells["Ngay_lap"].Value.ToString());
            phieuNhap.Ly_do =( gridMaster.Rows[selectedRowCount].Cells["Ly_do"].Value.ToString());
            phieuNhap.So_hoa_don =( gridMaster.Rows[selectedRowCount].Cells["So_hoa_don"].Value.ToString());
            
            //DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieuNhap.ID_phieu_nhap);
            //for(int i =0;i<chiTietPhieuNhap.Rows.Count;i++)
            //{
            //    clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
            //    chitiet.ID_chi_tiet_phieu_nhap=int.Parse( chiTietPhieuNhap.Rows[i]["ID_chi_tiet_phieu_nhap"].ToString());
            //    chitiet.ID_phieu_nhap=int.Parse( chiTietPhieuNhap.Rows[i]["ID_phieu_nhap"].ToString());
            //    chitiet.ID_vat_tu=int.Parse( chiTietPhieuNhap.Rows[i]["ID_vat_tu"].ToString());
            //    chitiet.Chat_luong=( chiTietPhieuNhap.Rows[i]["Chat_luong"].ToString());
            //    chitiet.So_luong_yeu_cau=int.Parse( chiTietPhieuNhap.Rows[i]["So_luong_yeu_cau"].ToString());
            //    chitiet.So_luong_thuc_nhap=int.Parse( chiTietPhieuNhap.Rows[i]["So_luong_thuc_nhap"].ToString());
            //    phieuNhap.lstChiTietPhieuNhap.Add(chitiet);
            //}
           
          //  int id_PhieuNhap =int.Parse( gridMaster.Rows[selectedRowCount].Cells["ID_phieu_nhap"].Value.ToString());
            
          //  DataTable tbChiTiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(id_PhieuNhap);

            frmNhapKho nhapkho = new frmNhapKho(enumStatus.Sua,phieuNhap);
            nhapkho.Show();
        }

    }
}
