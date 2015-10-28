using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
    public class clsChiTietGoiDau
    {
        public int ID_chi_tiet_GD;
        public int ID_VT_Goi_Dau;
        public double So_luong;
        public int ID_ma_phieu;
        public DateTime Ngay_nhap;
        public static DataTable GetAll(string mavt)
        {
            // lấy tất cả các phiếu nhập đã xác nhận và loại là hoàn nhập hoac nhap goi dau  lên
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Phieu_Nhap_Kho
                          join l in help.ent.Loai_Phieu_Nhap on d.ID_Loai_Phieu_Nhap equals l.ID_Loai_Phieu_Nhap
                          join ct in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu on d.Ma_phieu_nhap equals ct.Ma_phieu_nhap
                          join k in help.ent.DM_Kho on d.ID_kho equals k.ID_kho
                          join v in help.ent.DM_Vat_Tu on ct.Ma_vat_tu equals v.Ma_vat_tu


                          where d.Da_phan_kho == true && (d.isGoiDau == true || l.Ma_loai_phieu_nhap.Contains("T"))
                          && ct.Ma_vat_tu .Contains(mavt)
                          select new
                          {
                              d.Ma_phieu_nhap,
                              ct.Ma_vat_tu ,
                              d.Ngay_lap,
                              
                             so_luong= ct.So_luong_thuc_lanh,
                              d.ID_kho,
                              k.Ten_kho,
                              d.ID_Loai_Phieu_Nhap,
                              l.Ma_loai_phieu_nhap ,
                          }).ToList();
                dbcxtransaction.Commit();
                DataTable ds = Utilities.clsThamSoUtilities.ToDataTable(dm);
                return ds;
            }
        }

    }
}
