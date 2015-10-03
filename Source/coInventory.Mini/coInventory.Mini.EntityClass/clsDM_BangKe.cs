using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace eHospital.Mini.EntityClass
{
  public  class clsDM_BangKe:clsDM_XuLy
    {
      public int BangKeID;
      public int LoaiBangKe;
      public string SoHoSo;
      public string Khoa;
      public string MaKhamChuaBenh;
      public string MaNguoiBenh;
      public string HoTen;
      public int GioiTinh;
      public DateTime NgaySinh;
      public string DiaChi;
      public string MaNoiSinhSong;
      public string SoTheBHYT;
      public DateTime TuNgayBH;
      public DateTime DenNgayBH;

      public bool CoBHYT;
      public bool TreEmKhongTheBHYT;
      public int MucHuong;
      public decimal PhanTramDuocHuong;
      public string MaCSKCBBanDau;
      public string TenCSKCBBanDau;
      public string MaCSKCB;
      public string MaChiNhanh;
      public string MaNoiChuyenDen;
      public string TenNoiChuyenDen;
      public DateTime NgayDenKham;
      public DateTime NgayKetThuc;
      public int SoNgayDieuTri;
      public DateTime NgayQuyetToan;
      public int TuyenKhamBenh;
      public string ChanDoan;
      public string BenhKhac;
      public string MaICD;
      public decimal TongChiPhi;
      public decimal BHYTThanhToan;
      public decimal NguoiBenhTra;
      public decimal NguonKhac;
      public decimal SoTienThanhToanToiDa;
      public decimal TienKham;
      public decimal TienGiuong;
      public decimal TienXN;
      public decimal TienCDHA;
      public decimal TienTDCN;
      public decimal TienPTTT;
      public decimal TienDichVuKTC;
      public decimal TienMau;
      public decimal TienThuoc;
      public decimal TienVTYT;
      public decimal TienVTYTTH;
      public int TienVTYTTT;
      public decimal TienVanChuyen;
      public decimal DVKTC_TinhToan;
      public decimal DVKTC_ThanhToan;
      public decimal ChiPhiNgoaiDinhSuat;
      public bool DaGuiBHYT;
      public DateTime NgayGuiBHYT;
      public string NguoiGuiBHYT;
      public DateTime NgayTao;
      public string NguoiTao;
      public DateTime NgayCapNhat;
      public string NguoiCapNhat;
      public string ChungNhanKhongCCT;
      public int NamSinh;
        public override System.Data.DataTable GetAll()
        {
           
               
                sql = "SELECT * FROM BANGKE";
               return  base.GetAll(); 
        }
    }
}
