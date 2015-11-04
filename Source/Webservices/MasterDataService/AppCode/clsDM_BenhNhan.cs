using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Xml;
using System.Configuration;
using FptFramework.DAL;
namespace MasterDataService.AppCode
{
    /// <summary>
    /// Summary description for clsDM_BenhNhan
    /// </summary>
    /// 
    [DataContract]
    public class clsDM_BenhNhan
    {

        private System.Int32 mvarTinhTrangHonNhan_Id;

        private System.String mvarDienThoaiBan;

        private System.DateTime mvarNgayHetHan_Passport;

        private System.String mvarCTBH_1;

        private System.String mvarCTBH_2;
        private System.String mvarCTBH_3;
        //---

        private System.String mvarLanguageId;

        private System.Int32 mvarUserID;

        private System.String mvarFreePara;

        private System.Int32 mvarBenhNhan_Id;

        private System.String mvarMaYTe;

        private System.String mvarMaBenhVien;

        private System.String mvarSoVaoVien;

        private System.String mvarTenBenhNhan;

        private System.String mvarHo;

        private System.String mvarTen;

        private System.String mvarGioiTinh;

        private System.DateTime mvarNgaySinh;

        private System.Int16 mvarNamSinh;

        private System.String mvarSoNha;

        private System.String mvarDiaChi;

        private System.Int32 mvarNhomMau_Id;

        private System.Int32 mvarYeuToRh_Id;

        private System.String mvarTienSuDiUng;

        private System.String mvarSoLuuTruNgoaiTru;

        private System.String mvarSoLuuTruNoiTru;

        private System.Int32 mvarQuocTich_Id;

        private System.Int32 mvarTinhThanh_Id;

        private System.Int32 mvarQuanHuyen_Id;

        private System.Int32 mvarXaPhuong_Id;

        private System.Int32 mvarDanToc_Id;

        private System.Int32 mvarNgheNghiep_Id;

        private System.Boolean mvarVietKieu;

        private System.Boolean mvarNguoiNuocNgoai;

        private System.String mvarCMND;

        private System.String mvarHoChieu;

        private System.String mvarTenKhongDau;

        private System.String mvarGhiChu;

        private System.DateTime mvarNgayTao;

        private System.Int32 mvarNguoiTao_Id;

        private System.DateTime mvarNgayCapNhat;

        private System.Int32 mvarNguoiCapNhat_Id;

        private System.DateTime mvarNgayCapThe;

        private System.Int16 mvarNamCapThe;

        private System.DateTime mvarThoiGianCapThe;

        private System.Int32 mvarNhanVien_Id;

        private System.String mvarTienSuBenh;

        private System.String mvarTienSuHutThuocLa;

        private System.Int32 mvarDonViCongTac_Id;

        private System.String mvarSoDienThoai;

        private System.String mvarDiaChiThuongTru;

        private System.String mvarDiaChiLienLac;

        private System.String mvarEmail;

        private System.String mvarDiaChiCoQuan;

        private System.Boolean mvarTuVong;

        private System.DateTime mvarNgayTuVong;

        private System.DateTime mvarThoiGianTuVong;

        private System.Int32 mvarNguyenNhanTuVong_Id;

        private System.Int32 mvarNguoiGhiNhanTuVong_Id;

        private System.DateTime mvarThoiGianGhiNhanTuVong;

        private System.Int32 mvarCountNotes;

        private System.String mvarTienCan;

        private System.String mvarBenhManTinh;

        private System.String mvarBenhDiTruyen;

        private System.String mvarChiDinhDacBiet;

        private System.Int32 mvarNguoiLienHe_Id;

        private System.String mvarNguoiLienHe;

        private System.Int32 mvarMoiQuanHe_Id;

        private System.String mvarDiaChi_NLH;

        private System.String mvarDienThoai_NLH;

        private System.String mvarHoTruocTen;

        private System.DateTime mvarNgayCapCMND;

        private System.String mvarNoiCapCMND;


        private System.String mvarThuocLa;

        private System.String mvarVanDong;

        private System.String mvarRuou;

        private System.String mvarCaPhe;

        private System.String mvarTra;

        private System.String mvarThuocDangDung;

        private System.String mvarDCTamTru;

        private System.Int32 mvarQuocGia_Id;
        private System.String mvarBenhNhanCu_Id;
        private System.Int32 mvarMaster_Id;

        private System.String mvarSite;
        private System.DateTime mvarNgayTaoBenhNhan;
        private System.String mvarGoiPACS;
        private System.String mvarPIDPACS;
        private System.Boolean mvarTinhTrang;

        #region "Propertise"
        [DataMember]
        public System.Boolean TinhTrang
        {
            get { return mvarTinhTrang; }
            set { mvarTinhTrang = value; }
        }
        [DataMember]
        public System.String PIDPACS
        {
            get { return mvarPIDPACS; }
            set { mvarPIDPACS = value; }
        }
        [DataMember]
        public System.String GoiPACS
        {
            get { return mvarGoiPACS; }
            set { mvarGoiPACS = value; }
        }
        [DataMember]
        public System.DateTime NgayTaoBenhNhan
        {
            get { return mvarNgayTaoBenhNhan; }
            set { mvarNgayTaoBenhNhan = value; }
        }
        [DataMember]
        public System.String Site
        {
            get { return mvarSite; }
            set { mvarSite = value; }
        }

        [DataMember]
        public System.Int32 Master_Id
        {
            get { return mvarMaster_Id; }
            set { mvarMaster_Id = value; }
        }


        //--MyQDH
        [DataMember]
        public System.Int32 TinhTrangHonNhan_Id
        {
            get { return mvarTinhTrangHonNhan_Id; }
            set { mvarTinhTrangHonNhan_Id = value; }
        }
        [DataMember]
        public System.String DienThoaiBan
        {
            get { return mvarDienThoaiBan; }
            set { mvarDienThoaiBan = value; }
        }
        [DataMember]
        public System.DateTime NgayHetHan_Passport
        {
            get { return mvarNgayHetHan_Passport; }
            set { mvarNgayHetHan_Passport = value; }
        }
        [DataMember]
        public System.String CTBH_1
        {
            get { return mvarCTBH_1; }
            set { mvarCTBH_1 = value; }
        }
        [DataMember]
        public System.String CTBH_2
        {
            get { return mvarCTBH_1; }
            set { mvarCTBH_2 = value; }
        }
        [DataMember]
        public System.String CTBH_3
        {
            get { return mvarCTBH_3; }
            set { mvarCTBH_3 = value; }
        }
        //------------------------------------------
        [DataMember]
        public System.String LanguageId
        {
            get { return mvarLanguageId; }
            set { mvarLanguageId = value; }
        }
        [DataMember]
        public System.Int32 UserID
        {
            get { return mvarUserID; }
            set { mvarUserID = value; }
        }
        [DataMember]
        public System.String FreePara
        {
            get { return mvarFreePara; }
            set { mvarFreePara = value; }
        }
        [DataMember]
        public System.Int32 BenhNhan_Id
        {
            get { return mvarBenhNhan_Id; }
            set { mvarBenhNhan_Id = value; }
        }
        [DataMember]

        public System.String MaYTe
        {
            get { return mvarMaYTe; }
            set { mvarMaYTe = value; }
        }
        [DataMember]
        public System.String MaBenhVien
        {
            get { return mvarMaBenhVien; }
            set { mvarMaBenhVien = value; }
        }
        [DataMember]
        public System.String SoVaoVien
        {
            get { return mvarSoVaoVien; }
            set { mvarSoVaoVien = value; }
        }
        [DataMember]
        public System.String TenBenhNhan
        {
            get { return mvarTenBenhNhan; }
            set { mvarTenBenhNhan = value; }
        }
        [DataMember]
        public System.String Ho
        {
            get { return mvarHo; }
            set { mvarHo = value; }
        }
        [DataMember]
        public System.String Ten
        {
            get { return mvarTen; }
            set { mvarTen = value; }
        }
        [DataMember]
        public System.String GioiTinh
        {
            get { return mvarGioiTinh; }
            set { mvarGioiTinh = value; }
        }
        [DataMember]
        public System.DateTime NgaySinh
        {
            get { return mvarNgaySinh; }
            set { mvarNgaySinh = value; }
        }
        [DataMember]
        public System.Int16 NamSinh
        {
            get { return mvarNamSinh; }
            set { mvarNamSinh = value; }
        }
        [DataMember]
        public System.String SoNha
        {
            get { return mvarSoNha; }
            set { mvarSoNha = value; }
        }
        [DataMember]
        public System.String DiaChi
        {
            get { return mvarDiaChi; }
            set { mvarDiaChi = value; }
        }
        [DataMember]
        public System.Int32 NhomMau_Id
        {
            get { return mvarNhomMau_Id; }
            set { mvarNhomMau_Id = value; }
        }
        [DataMember]
        public System.Int32 YeuToRh_Id
        {
            get { return mvarYeuToRh_Id; }
            set { mvarYeuToRh_Id = value; }
        }
        [DataMember]
        public System.String TienSuDiUng
        {
            get { return mvarTienSuDiUng; }
            set { mvarTienSuDiUng = value; }
        }
        [DataMember]
        public System.String SoLuuTruNgoaiTru
        {
            get { return mvarSoLuuTruNgoaiTru; }
            set { mvarSoLuuTruNgoaiTru = value; }
        }
        [DataMember]
        public System.String SoLuuTruNoiTru
        {
            get { return mvarSoLuuTruNoiTru; }
            set { mvarSoLuuTruNoiTru = value; }
        }
        [DataMember]
        public System.Int32 QuocTich_Id
        {
            get { return mvarQuocTich_Id; }
            set { mvarQuocTich_Id = value; }
        }
        [DataMember]
        public System.Int32 TinhThanh_Id
        {
            get { return mvarTinhThanh_Id; }
            set { mvarTinhThanh_Id = value; }
        }
        [DataMember]
        public System.Int32 QuanHuyen_Id
        {
            get { return mvarQuanHuyen_Id; }
            set { mvarQuanHuyen_Id = value; }
        }
        [DataMember]
        public System.Int32 XaPhuong_Id
        {
            get { return mvarXaPhuong_Id; }
            set { mvarXaPhuong_Id = value; }
        }
        [DataMember]
        public System.Int32 DanToc_Id
        {
            get { return mvarDanToc_Id; }
            set { mvarDanToc_Id = value; }
        }
        [DataMember]
        public System.Int32 NgheNghiep_Id
        {
            get { return mvarNgheNghiep_Id; }
            set { mvarNgheNghiep_Id = value; }
        }
        [DataMember]
        public System.Boolean VietKieu
        {
            get { return mvarVietKieu; }
            set { mvarVietKieu = value; }
        }
        [DataMember]
        public System.Boolean NguoiNuocNgoai
        {
            get { return mvarNguoiNuocNgoai; }
            set { mvarNguoiNuocNgoai = value; }
        }
        [DataMember]
        public System.String CMND
        {
            get { return mvarCMND; }
            set { mvarCMND = value; }
        }
        [DataMember]

        public System.String HoChieu
        {
            get { return mvarHoChieu; }
            set { mvarHoChieu = value; }
        }
        [DataMember]
        public System.String TenKhongDau
        {
            get { return mvarTenKhongDau; }
            set { mvarTenKhongDau = value; }
        }
        [DataMember]
        public System.String GhiChu
        {
            get { return mvarGhiChu; }
            set { mvarGhiChu = value; }
        }
        [DataMember]
        public System.DateTime NgayTao
        {
            get { return mvarNgayTao; }
            set { mvarNgayTao = value; }
        }
        [DataMember]
        public System.Int32 NguoiTao_Id
        {
            get { return mvarNguoiTao_Id; }
            set { mvarNguoiTao_Id = value; }
        }
        [DataMember]
        public System.DateTime NgayCapNhat
        {
            get { return mvarNgayCapNhat; }
            set { mvarNgayCapNhat = value; }
        }
        [DataMember]
        public System.Int32 NguoiCapNhat_Id
        {
            get { return mvarNguoiCapNhat_Id; }
            set { mvarNguoiCapNhat_Id = value; }
        }
        [DataMember]
        public System.DateTime NgayCapThe
        {
            get { return mvarNgayCapThe; }
            set { mvarNgayCapThe = value; }
        }
        [DataMember]
        public System.Int16 NamCapThe
        {
            get { return mvarNamCapThe; }
            set { mvarNamCapThe = value; }
        }
        [DataMember]
        public System.DateTime ThoiGianCapThe
        {
            get { return mvarThoiGianCapThe; }
            set { mvarThoiGianCapThe = value; }
        }
        [DataMember]
        public System.Int32 NhanVien_Id
        {
            get { return mvarNhanVien_Id; }
            set { mvarNhanVien_Id = value; }
        }
        [DataMember]
        public System.String TienSuBenh
        {
            get { return mvarTienSuBenh; }
            set { mvarTienSuBenh = value; }
        }
        [DataMember]
        public System.String TienSuHutThuocLa
        {
            get { return mvarTienSuHutThuocLa; }
            set { mvarTienSuHutThuocLa = value; }
        }
        [DataMember]
        public System.Int32 DonViCongTac_Id
        {
            get { return mvarDonViCongTac_Id; }
            set { mvarDonViCongTac_Id = value; }
        }
        [DataMember]
        public System.String SoDienThoai
        {
            get { return mvarSoDienThoai; }
            set { mvarSoDienThoai = value; }
        }
        [DataMember]
        public System.String DiaChiThuongTru
        {
            get { return mvarDiaChiThuongTru; }
            set { mvarDiaChiThuongTru = value; }
        }
        [DataMember]
        public System.String DiaChiLienLac
        {
            get { return mvarDiaChiLienLac; }
            set { mvarDiaChiLienLac = value; }
        }
        [DataMember]
        public System.String Email
        {
            get { return mvarEmail; }
            set { mvarEmail = value; }
        }
        [DataMember]
        public System.String DiaChiCoQuan
        {
            get { return mvarDiaChiCoQuan; }
            set { mvarDiaChiCoQuan = value; }
        }
        [DataMember]
        public System.Boolean TuVong
        {
            get { return mvarTuVong; }
            set { mvarTuVong = value; }
        }
        [DataMember]
        public System.DateTime NgayTuVong
        {
            get { return mvarNgayTuVong; }
            set { mvarNgayTuVong = value; }
        }
        [DataMember]
        public System.DateTime ThoiGianTuVong
        {
            get { return mvarThoiGianTuVong; }
            set { mvarThoiGianTuVong = value; }
        }
        [DataMember]
        public System.Int32 NguyenNhanTuVong_Id
        {
            get { return mvarNguyenNhanTuVong_Id; }
            set { mvarNguyenNhanTuVong_Id = value; }
        }
        [DataMember]
        public System.Int32 NguoiGhiNhanTuVong_Id
        {
            get { return mvarNguoiGhiNhanTuVong_Id; }
            set { mvarNguoiGhiNhanTuVong_Id = value; }
        }
        [DataMember]
        public System.DateTime ThoiGianGhiNhanTuVong
        {
            get { return mvarThoiGianGhiNhanTuVong; }
            set { mvarThoiGianGhiNhanTuVong = value; }
        }
        [DataMember]
        public System.Int32 CountNotes
        {
            get { return mvarCountNotes; }
            set { mvarCountNotes = value; }
        }
        [DataMember]
        public System.String TienCan
        {
            get { return mvarTienCan; }
            set { mvarTienCan = value; }
        }
        [DataMember]
        public System.String BenhManTinh
        {
            get { return mvarBenhManTinh; }
            set { mvarBenhManTinh = value; }
        }
        [DataMember]
        public System.String BenhDiTruyen
        {
            get { return mvarBenhDiTruyen; }
            set { mvarBenhDiTruyen = value; }
        }
        [DataMember]
        public System.String ChiDinhDacBiet
        {
            get { return mvarChiDinhDacBiet; }
            set { mvarChiDinhDacBiet = value; }
        }
        [DataMember]
        public System.Int32 NguoiLienHe_Id
        {
            get { return mvarNguoiLienHe_Id; }
            set { mvarNguoiLienHe_Id = value; }
        }
        [DataMember]
        public System.String NguoiLienHe
        {
            get { return mvarNguoiLienHe; }
            set { mvarNguoiLienHe = value; }
        }
        [DataMember]
        public System.Int32 MoiQuanHe_Id
        {
            get { return mvarMoiQuanHe_Id; }
            set { mvarMoiQuanHe_Id = value; }
        }
        [DataMember]
        public System.String DiaChi_NLH
        {
            get { return mvarDiaChi_NLH; }
            set { mvarDiaChi_NLH = value; }
        }
        [DataMember]
        public System.String DienThoai_NLH
        {
            get { return mvarDienThoai_NLH; }
            set { mvarDienThoai_NLH = value; }
        }
        [DataMember]
        public System.String HoTruocTen
        {
            get { return mvarHoTruocTen; }
            set { mvarHoTruocTen = value; }
        }
        [DataMember]
        public System.DateTime NgayCapCMND
        {
            get { return mvarNgayCapCMND; }
            set { mvarNgayCapCMND = value; }
        }
        [DataMember]
        public System.String NoiCapCMND
        {
            get { return mvarNoiCapCMND; }
            set { mvarNoiCapCMND = value; }
        }
        [DataMember]
        public System.String ThuocLa
        {
            get { return mvarThuocLa; }
            set { mvarThuocLa = value; }
        }
        [DataMember]
        public System.String VanDong
        {
            get { return mvarVanDong; }
            set { mvarVanDong = value; }
        }
        [DataMember]
        public System.String Ruou
        {
            get { return mvarRuou; }
            set { mvarRuou = value; }
        }
        [DataMember]
        public System.String CaPhe
        {
            get { return mvarCaPhe; }
            set { mvarCaPhe = value; }
        }
        [DataMember]
        public System.String Tra
        {
            get { return mvarTra; }
            set { mvarTra = value; }
        }
        [DataMember]
        public System.String ThuocDangDung
        {
            get { return mvarThuocDangDung; }
            set { mvarThuocDangDung = value; }
        }
        [DataMember]
        public System.String DCTamTru
        {
            get { return mvarDCTamTru; }
            set { mvarDCTamTru = value; }
        }
        [DataMember]
        public System.Int32 QuocGia_Id
        {
            get { return mvarQuocGia_Id; }
            set { mvarQuocGia_Id = value; }
        }
        [DataMember]
        public System.String BenhNhanCu_Id
        {
            get { return mvarBenhNhanCu_Id; }
            set { mvarBenhNhanCu_Id = value; }
        }
        #endregion
        public clsDM_BenhNhan(clsDM_BenhNhan BN)
        {

            this.Master_Id = BN.Master_Id;
            this.Site = BN.Site;
            this.BenhNhan_Id = BN.BenhNhan_Id;
            this.MaYTe = BN.MaYTe;
            this.MaBenhVien = BN.MaBenhVien;
            this.SoVaoVien = BN.SoVaoVien;
            this.TenBenhNhan = BN.TenBenhNhan;
            this.Ho = BN.Ho;
            this.Ten = BN.Ten;
            this.GioiTinh = BN.GioiTinh;
            this.NgaySinh = BN.NgaySinh;
            this.NamSinh = BN.NamSinh;
            this.SoNha = BN.SoNha;
            this.DiaChi = BN.DiaChi;
            this.NhomMau_Id = BN.NhomMau_Id;
            this.YeuToRh_Id = BN.YeuToRh_Id;
            this.TienSuDiUng = BN.TienSuDiUng;
            this.SoLuuTruNgoaiTru = BN.SoLuuTruNgoaiTru;
            this.SoLuuTruNoiTru = BN.SoLuuTruNoiTru;
            this.QuocTich_Id = BN.QuocTich_Id;
            this.TinhThanh_Id = BN.TinhThanh_Id;
            this.QuanHuyen_Id = BN.QuanHuyen_Id;
            this.XaPhuong_Id = BN.XaPhuong_Id;
            this.DanToc_Id = BN.DanToc_Id;
            this.NgheNghiep_Id = BN.NgheNghiep_Id;
            this.VietKieu = BN.VietKieu;
            this.NguoiNuocNgoai = BN.NguoiNuocNgoai;
            this.CMND = BN.CMND;
            this.HoChieu = BN.HoChieu;
            this.TenKhongDau = BN.TenKhongDau;
            this.GhiChu = BN.GhiChu;
            this.NgayTao = BN.NgayTao;
            this.NguoiTao_Id = BN.NguoiTao_Id;
            this.NgayCapNhat = BN.NgayCapNhat;
            this.NguoiCapNhat_Id = BN.NguoiCapNhat_Id;
            this.NgayCapThe = BN.NgayCapThe;
            this.NamCapThe = BN.NamCapThe;
            this.ThoiGianCapThe = BN.ThoiGianCapThe;
            this.NhanVien_Id = BN.NhanVien_Id;
            this.TienSuBenh = BN.TienSuBenh;
            this.TienSuHutThuocLa = BN.TienSuHutThuocLa;
            this.DonViCongTac_Id = BN.DonViCongTac_Id;
            this.SoDienThoai = BN.SoDienThoai;
            this.DiaChiThuongTru = BN.DiaChiThuongTru;
            this.DiaChiLienLac = BN.DiaChiLienLac;
            this.Email = BN.Email;
            this.DiaChiCoQuan = BN.DiaChiCoQuan;
            this.TuVong = BN.TuVong;
            this.NgayTuVong = BN.NgayTuVong;
            this.ThoiGianTuVong = BN.ThoiGianTuVong;
            this.NguyenNhanTuVong_Id = BN.NguyenNhanTuVong_Id;
            this.NguoiGhiNhanTuVong_Id = BN.NguoiGhiNhanTuVong_Id;
            this.ThoiGianGhiNhanTuVong = BN.ThoiGianGhiNhanTuVong;
            this.CountNotes = BN.CountNotes;
            this.NgayTaoBenhNhan = BN.NgayTaoBenhNhan;
            this.TienCan = BN.TienCan;
            this.BenhManTinh = BN.BenhManTinh;
            this.BenhDiTruyen = BN.BenhDiTruyen;
            this.ChiDinhDacBiet = BN.ChiDinhDacBiet;
            this.MoiQuanHe_Id = BN.MoiQuanHe_Id;
            this.DiaChi_NLH = BN.DiaChi_NLH;
            this.DienThoai_NLH = BN.DienThoai_NLH;
            this.NguoiLienHe_Id = BN.NguoiLienHe_Id;
            this.NguoiLienHe = BN.NguoiLienHe;
            this.TinhTrangHonNhan_Id = BN.TinhTrangHonNhan_Id;
            this.DienThoaiBan = BN.DienThoaiBan;
            this.NgayHetHan_Passport = BN.NgayHetHan_Passport;
            this.CTBH_1 = BN.CTBH_1;
            this.CTBH_2 = BN.CTBH_2;
            this.CTBH_3 = BN.CTBH_3;
            this.HoTruocTen = BN.HoTruocTen;
            this.NgayCapCMND = BN.NgayCapCMND;
            this.NoiCapCMND = BN.NoiCapCMND;
            this.GoiPACS = BN.GoiPACS;
            this.PIDPACS = BN.PIDPACS;
            this.ThuocLa = BN.ThuocLa;
            this.VanDong = BN.VanDong;
            this.Ruou = BN.Ruou;
            this.CaPhe = BN.CaPhe;
            this.Tra = BN.Tra;
            this.ThuocDangDung = BN.ThuocDangDung;
            this.DCTamTru = BN.DCTamTru;
            this.QuocGia_Id = BN.QuocGia_Id;
            this.BenhNhanCu_Id = BN.BenhNhanCu_Id;
            this.TinhTrang = BN.TinhTrang;





        }


        public DataAccess Createm_Dal()
        {

            var connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            // string conStr = "";
            DataSet ds = new DataSet();
            //if (File.Exists(path))
            //{
            //    XmlDocument doc = new XmlDocument();
            //    doc.Load(path);
            //    XmlNodeList nodelist = doc.GetElementsByTagName("AppConnectionString");
            //    if ((nodelist.Count > 0))
            //    {
            //        XmlNode node = nodelist.Item(0).Attributes.GetNamedItem("ConnectionString_eLab");
            //        conStr = node.InnerText.Trim();
            //    }
            //}
            DataAccess m_Dal = new DataAccess(FptFramework.DAL.EnumProviders.SQLClient, connectionString, false);
            m_Dal.CommandType = CommandType.StoredProcedure;
            m_Dal.Parameters.Clear();
            return m_Dal;
        }

        public DataSet GetDsBenhNhanTrung()
        {
            DataAccess m_Dal = Createm_Dal();
            m_Dal.CommandText = "sp_DM_BenhNhan";

            m_Dal.CommandType = CommandType.StoredProcedure;
            m_Dal.Parameters.Clear();

            m_Dal.Parameters.Add(new ParamStruct("@Action", DbType.String, "GetDsBenhNhanTrung", ParameterDirection.Input, 50));
            m_Dal.Parameters.Add(new ParamStruct("@LanguageID", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarLanguageId), ParameterDirection.Input, 2));
            m_Dal.Parameters.Add(new ParamStruct("@UserID", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarUserID), ParameterDirection.Input, 4));
            m_Dal.Parameters.Add(new ParamStruct("@FreePara", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarFreePara), ParameterDirection.InputOutput, 1000));

            m_Dal.Parameters.Add(new ParamStruct("@TenBenhNhan", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTenBenhNhan), ParameterDirection.Input, 40));
            m_Dal.Parameters.Add(new ParamStruct("@GioiTinh", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarGioiTinh), ParameterDirection.Input, 1));
            m_Dal.Parameters.Add(new ParamStruct("@NamSinh", DbType.Int16, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNamSinh), ParameterDirection.Input, 2));

            return m_Dal.ExecDataSet();
        }



        public string AddNew()
        {
            //connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInfo"]);
            try
            {


                DataAccess m_Dal = Createm_Dal();
                DataSet ds = new DataSet();
                m_Dal.CommandText = "sp_DM_BenhNhan";

                m_Dal.CommandType = CommandType.StoredProcedure;
                m_Dal.Parameters.Clear();

                m_Dal.Parameters.Add(new ParamStruct("@Action", DbType.String, "AddNew", ParameterDirection.Input, 50));
                m_Dal.Parameters.Add(new ParamStruct("@LanguageID", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarLanguageId), ParameterDirection.Input, 2));
                m_Dal.Parameters.Add(new ParamStruct("@UserID", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarUserID), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@FreePara", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarFreePara), ParameterDirection.InputOutput, 1000));

                m_Dal.Parameters.Add(new ParamStruct("@Master_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarMaster_Id), ParameterDirection.InputOutput, 20));
                m_Dal.Parameters.Add(new ParamStruct("@Site", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarSite), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@BenhNhan_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarBenhNhan_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@MaYTe", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarMaYTe), ParameterDirection.Input, 20));
                m_Dal.Parameters.Add(new ParamStruct("@MaBenhVien", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarMaBenhVien), ParameterDirection.Input, 6));
                m_Dal.Parameters.Add(new ParamStruct("@SoVaoVien", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(mvarSoVaoVien), ParameterDirection.Input, 10));
                m_Dal.Parameters.Add(new ParamStruct("@TenBenhNhan", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTenBenhNhan), ParameterDirection.Input, 40));
                m_Dal.Parameters.Add(new ParamStruct("@Ho", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarHo), ParameterDirection.Input, 20));
                m_Dal.Parameters.Add(new ParamStruct("@Ten", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTen), ParameterDirection.Input, 20));
                m_Dal.Parameters.Add(new ParamStruct("@GioiTinh", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarGioiTinh), ParameterDirection.Input, 1));
                m_Dal.Parameters.Add(new ParamStruct("@NgaySinh", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgaySinh.Date), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@NamSinh", DbType.Int16, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNamSinh), ParameterDirection.Input, 2));
                m_Dal.Parameters.Add(new ParamStruct("@SoNha", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarSoNha), ParameterDirection.Input, 150));
                m_Dal.Parameters.Add(new ParamStruct("@DiaChi", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDiaChi), ParameterDirection.Input, 150));
                m_Dal.Parameters.Add(new ParamStruct("@NhomMau_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNhomMau_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@YeuToRh_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarYeuToRh_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@TienSuDiUng", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTienSuDiUng), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@SoLuuTruNgoaiTru", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarSoLuuTruNgoaiTru), ParameterDirection.Input, 10));
                m_Dal.Parameters.Add(new ParamStruct("@SoLuuTruNoiTru", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarSoLuuTruNoiTru), ParameterDirection.Input, 10));
                m_Dal.Parameters.Add(new ParamStruct("@QuocTich_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarQuocTich_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@TinhThanh_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTinhThanh_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@QuanHuyen_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarQuanHuyen_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@XaPhuong_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarXaPhuong_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@DanToc_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDanToc_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@NgheNghiep_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgheNghiep_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@VietKieu", DbType.Boolean, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarVietKieu), ParameterDirection.Input, 2));
                m_Dal.Parameters.Add(new ParamStruct("@NguoiNuocNgoai", DbType.Boolean, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNguoiNuocNgoai), ParameterDirection.Input, 2));
                m_Dal.Parameters.Add(new ParamStruct("@CMND", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarCMND), ParameterDirection.Input, 9));
                m_Dal.Parameters.Add(new ParamStruct("@HoChieu", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarHoChieu), ParameterDirection.Input, 15));
                m_Dal.Parameters.Add(new ParamStruct("@TenKhongDau", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTenKhongDau), ParameterDirection.Input, 40));
                m_Dal.Parameters.Add(new ParamStruct("@GhiChu", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarGhiChu), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@NgayTao", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgayTao), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@NguoiTao_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNguoiTao_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@NgayCapNhat", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgayCapNhat), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@NguoiCapNhat_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNguoiCapNhat_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@NgayCapThe", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgayCapThe.Date), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@NamCapThe", DbType.Int16, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNamCapThe), ParameterDirection.Input, 2));
                m_Dal.Parameters.Add(new ParamStruct("@ThoiGianCapThe", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarThoiGianCapThe), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@NhanVien_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNhanVien_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@TienSuBenh", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTienSuBenh), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@TienSuHutThuocLa", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTienSuHutThuocLa), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@DonViCongTac_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDonViCongTac_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@SoDienThoai", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarSoDienThoai), ParameterDirection.Input, 30));
                m_Dal.Parameters.Add(new ParamStruct("@DiaChiThuongTru", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDiaChiThuongTru), ParameterDirection.Input, 150));
                m_Dal.Parameters.Add(new ParamStruct("@DiaChiLienLac", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDiaChiLienLac), ParameterDirection.Input, 150));
                m_Dal.Parameters.Add(new ParamStruct("@Email", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarEmail), ParameterDirection.Input, 50));
                m_Dal.Parameters.Add(new ParamStruct("@DiaChiCoQuan", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDiaChiCoQuan), ParameterDirection.Input, 150));
                m_Dal.Parameters.Add(new ParamStruct("@TuVong", DbType.Boolean, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTuVong), ParameterDirection.Input, 2));
                m_Dal.Parameters.Add(new ParamStruct("@NgayTuVong", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgayTuVong), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@ThoiGianTuVong", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarThoiGianTuVong.Date), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@NguyenNhanTuVong_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNguyenNhanTuVong_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@NguoiGhiNhanTuVong_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNguoiGhiNhanTuVong_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@ThoiGianGhiNhanTuVong", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarThoiGianGhiNhanTuVong), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@CountNotes", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarCountNotes), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@TienCan", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTienCan), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@BenhManTinh", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarBenhManTinh), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@BenhDiTruyen", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarBenhDiTruyen), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@ChiDinhDacBiet", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarChiDinhDacBiet), ParameterDirection.Input, 500));

                m_Dal.Parameters.Add(new ParamStruct("@NguoiLienHe_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNguoiLienHe_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@NguoiLienHe", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNguoiLienHe), ParameterDirection.Input, 100));
                m_Dal.Parameters.Add(new ParamStruct("@MoiQuanHe_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarMoiQuanHe_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@DiaChi_NLH", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDiaChi_NLH), ParameterDirection.Input, 150));
                m_Dal.Parameters.Add(new ParamStruct("@DienThoai_NLH", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDienThoai_NLH), ParameterDirection.Input, 30));
                m_Dal.Parameters.Add(new ParamStruct("@TinhTrangHonNhan_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTinhTrangHonNhan_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@DienThoaiBan", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDienThoaiBan), ParameterDirection.Input, 20));
                m_Dal.Parameters.Add(new ParamStruct("@NgayHetHan_Passport", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgayHetHan_Passport), ParameterDirection.Input, 50));
                m_Dal.Parameters.Add(new ParamStruct("@CTBH_1", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarCTBH_1), ParameterDirection.Input, 100));
                m_Dal.Parameters.Add(new ParamStruct("@CTBH_2", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarCTBH_2), ParameterDirection.Input, 100));
                m_Dal.Parameters.Add(new ParamStruct("@CTBH_3", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarCTBH_3), ParameterDirection.Input, 100));
                m_Dal.Parameters.Add(new ParamStruct("@HoTruocTen", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarHoTruocTen), ParameterDirection.Input, 1));

                m_Dal.Parameters.Add(new ParamStruct("@NgayCapCMND", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgayCapCMND), ParameterDirection.Input, 50));
                m_Dal.Parameters.Add(new ParamStruct("@NoiCapCMND", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNoiCapCMND), ParameterDirection.Input, 500));

                m_Dal.Parameters.Add(new ParamStruct("@ThuocLa", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarThuocLa), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@VanDong", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarVanDong), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@Ruou", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarRuou), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@CaPhe", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarCaPhe), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@Tra", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTra), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@ThuocDangDung", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarThuocDangDung), ParameterDirection.Input, 500));

                m_Dal.Parameters.Add(new ParamStruct("@DCTamTru", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDCTamTru), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@QuocGia_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarQuocGia_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@BenhNhanCu_Id", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarBenhNhanCu_Id), ParameterDirection.Input, 20));


                m_Dal.ExecNonQuery();
                this.mvarMaster_Id = (int)FptFramework.Common.clsCommon.GetValue((object)m_Dal.Parameters.get_Item("@Master_Id").Value, mvarMaster_Id.GetType().ToString());

                return mvarMaster_Id.ToString();
                
            }


            catch (Exception ex)
            {
                return "# " +ex.Message;
            }

        }

        public string Update()
        {
            //connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInfo"]);
            try
            {


                DataAccess m_Dal = Createm_Dal();
                DataSet ds = new DataSet();
                m_Dal.CommandText = "sp_DM_BenhNhan";

                m_Dal.CommandType = CommandType.StoredProcedure;
                m_Dal.Parameters.Clear();

                m_Dal.Parameters.Add(new ParamStruct("@Action", DbType.String, "Update", ParameterDirection.Input, 50));
                m_Dal.Parameters.Add(new ParamStruct("@LanguageID", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarLanguageId), ParameterDirection.Input, 2));
                m_Dal.Parameters.Add(new ParamStruct("@UserID", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarUserID), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@FreePara", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarFreePara), ParameterDirection.InputOutput, 1000));

                m_Dal.Parameters.Add(new ParamStruct("@Master_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarMaster_Id), ParameterDirection.InputOutput, 20));
                m_Dal.Parameters.Add(new ParamStruct("@Site", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarSite), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@BenhNhan_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarBenhNhan_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@MaYTe", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarMaYTe), ParameterDirection.Input, 20));
                m_Dal.Parameters.Add(new ParamStruct("@MaBenhVien", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarMaBenhVien), ParameterDirection.Input, 6));
                m_Dal.Parameters.Add(new ParamStruct("@SoVaoVien", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(mvarSoVaoVien), ParameterDirection.Input, 10));
                m_Dal.Parameters.Add(new ParamStruct("@TenBenhNhan", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTenBenhNhan), ParameterDirection.Input, 40));
                m_Dal.Parameters.Add(new ParamStruct("@Ho", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarHo), ParameterDirection.Input, 20));
                m_Dal.Parameters.Add(new ParamStruct("@Ten", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTen), ParameterDirection.Input, 20));
                m_Dal.Parameters.Add(new ParamStruct("@GioiTinh", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarGioiTinh), ParameterDirection.Input, 1));
                m_Dal.Parameters.Add(new ParamStruct("@NgaySinh", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgaySinh.Date), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@NamSinh", DbType.Int16, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNamSinh), ParameterDirection.Input, 2));
                m_Dal.Parameters.Add(new ParamStruct("@SoNha", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarSoNha), ParameterDirection.Input, 150));
                m_Dal.Parameters.Add(new ParamStruct("@DiaChi", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDiaChi), ParameterDirection.Input, 150));
                m_Dal.Parameters.Add(new ParamStruct("@NhomMau_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNhomMau_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@YeuToRh_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarYeuToRh_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@TienSuDiUng", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTienSuDiUng), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@SoLuuTruNgoaiTru", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarSoLuuTruNgoaiTru), ParameterDirection.Input, 10));
                m_Dal.Parameters.Add(new ParamStruct("@SoLuuTruNoiTru", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarSoLuuTruNoiTru), ParameterDirection.Input, 10));
                m_Dal.Parameters.Add(new ParamStruct("@QuocTich_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarQuocTich_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@TinhThanh_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTinhThanh_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@QuanHuyen_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarQuanHuyen_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@XaPhuong_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarXaPhuong_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@DanToc_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDanToc_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@NgheNghiep_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgheNghiep_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@VietKieu", DbType.Boolean, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarVietKieu), ParameterDirection.Input, 2));
                m_Dal.Parameters.Add(new ParamStruct("@NguoiNuocNgoai", DbType.Boolean, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNguoiNuocNgoai), ParameterDirection.Input, 2));
                m_Dal.Parameters.Add(new ParamStruct("@CMND", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarCMND), ParameterDirection.Input, 9));
                m_Dal.Parameters.Add(new ParamStruct("@HoChieu", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarHoChieu), ParameterDirection.Input, 15));
                m_Dal.Parameters.Add(new ParamStruct("@TenKhongDau", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTenKhongDau), ParameterDirection.Input, 40));
                m_Dal.Parameters.Add(new ParamStruct("@GhiChu", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarGhiChu), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@NgayTao", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgayTao), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@NguoiTao_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNguoiTao_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@NgayCapNhat", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgayCapNhat), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@NguoiCapNhat_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNguoiCapNhat_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@NgayCapThe", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgayCapThe.Date), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@NamCapThe", DbType.Int16, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNamCapThe), ParameterDirection.Input, 2));
                m_Dal.Parameters.Add(new ParamStruct("@ThoiGianCapThe", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarThoiGianCapThe), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@NhanVien_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNhanVien_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@TienSuBenh", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTienSuBenh), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@TienSuHutThuocLa", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTienSuHutThuocLa), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@DonViCongTac_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDonViCongTac_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@SoDienThoai", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarSoDienThoai), ParameterDirection.Input, 30));
                m_Dal.Parameters.Add(new ParamStruct("@DiaChiThuongTru", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDiaChiThuongTru), ParameterDirection.Input, 150));
                m_Dal.Parameters.Add(new ParamStruct("@DiaChiLienLac", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDiaChiLienLac), ParameterDirection.Input, 150));
                m_Dal.Parameters.Add(new ParamStruct("@Email", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarEmail), ParameterDirection.Input, 50));
                m_Dal.Parameters.Add(new ParamStruct("@DiaChiCoQuan", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDiaChiCoQuan), ParameterDirection.Input, 150));
                m_Dal.Parameters.Add(new ParamStruct("@TuVong", DbType.Boolean, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTuVong), ParameterDirection.Input, 2));
                m_Dal.Parameters.Add(new ParamStruct("@NgayTuVong", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgayTuVong), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@ThoiGianTuVong", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarThoiGianTuVong.Date), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@NguyenNhanTuVong_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNguyenNhanTuVong_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@NguoiGhiNhanTuVong_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNguoiGhiNhanTuVong_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@ThoiGianGhiNhanTuVong", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarThoiGianGhiNhanTuVong), ParameterDirection.Input, 16));
                m_Dal.Parameters.Add(new ParamStruct("@CountNotes", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarCountNotes), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@TienCan", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTienCan), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@BenhManTinh", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarBenhManTinh), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@BenhDiTruyen", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarBenhDiTruyen), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@ChiDinhDacBiet", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarChiDinhDacBiet), ParameterDirection.Input, 500));

                m_Dal.Parameters.Add(new ParamStruct("@NguoiLienHe_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNguoiLienHe_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@NguoiLienHe", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNguoiLienHe), ParameterDirection.Input, 100));
                m_Dal.Parameters.Add(new ParamStruct("@MoiQuanHe_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarMoiQuanHe_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@DiaChi_NLH", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDiaChi_NLH), ParameterDirection.Input, 150));
                m_Dal.Parameters.Add(new ParamStruct("@DienThoai_NLH", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDienThoai_NLH), ParameterDirection.Input, 30));
                m_Dal.Parameters.Add(new ParamStruct("@TinhTrangHonNhan_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTinhTrangHonNhan_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@DienThoaiBan", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDienThoaiBan), ParameterDirection.Input, 20));
                m_Dal.Parameters.Add(new ParamStruct("@NgayHetHan_Passport", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgayHetHan_Passport), ParameterDirection.Input, 50));
                m_Dal.Parameters.Add(new ParamStruct("@CTBH_1", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarCTBH_1), ParameterDirection.Input, 100));
                m_Dal.Parameters.Add(new ParamStruct("@CTBH_2", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarCTBH_2), ParameterDirection.Input, 100));
                m_Dal.Parameters.Add(new ParamStruct("@CTBH_3", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarCTBH_3), ParameterDirection.Input, 100));
                m_Dal.Parameters.Add(new ParamStruct("@HoTruocTen", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarHoTruocTen), ParameterDirection.Input, 1));

                m_Dal.Parameters.Add(new ParamStruct("@NgayCapCMND", DbType.DateTime, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNgayCapCMND), ParameterDirection.Input, 50));
                m_Dal.Parameters.Add(new ParamStruct("@NoiCapCMND", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarNoiCapCMND), ParameterDirection.Input, 500));

                m_Dal.Parameters.Add(new ParamStruct("@ThuocLa", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarThuocLa), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@VanDong", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarVanDong), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@Ruou", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarRuou), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@CaPhe", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarCaPhe), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@Tra", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarTra), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@ThuocDangDung", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarThuocDangDung), ParameterDirection.Input, 500));

                m_Dal.Parameters.Add(new ParamStruct("@DCTamTru", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarDCTamTru), ParameterDirection.Input, 500));
                m_Dal.Parameters.Add(new ParamStruct("@QuocGia_Id", DbType.Int32, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarQuocGia_Id), ParameterDirection.Input, 4));
                m_Dal.Parameters.Add(new ParamStruct("@BenhNhanCu_Id", DbType.String, FptFramework.Common.clsCommon.GetValueDBNull(this.mvarBenhNhanCu_Id), ParameterDirection.Input, 20));

                m_Dal.ExecNonQuery();

                this.mvarMaster_Id = (int)FptFramework.Common.clsCommon.GetValue((object)m_Dal.Parameters.get_Item("@Master_Id").Value, mvarMaster_Id.GetType().ToString());

                return mvarMaster_Id.ToString();


            }


            catch (Exception ex)
            {
                return "# " + ex.Message;
            }

        }

    }
}