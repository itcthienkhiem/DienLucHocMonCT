﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Inventory.Utilities;
using Inventory.Models;
using System.Data.Entity;

namespace Inventory.EntityClass
{

    /// <summary>
    /// [ ] func GetALL
    /// [ ]
    /// </summary>
    public class clsPhieuNhapKho
    {
        public string Ma_phieu_nhap;
        //  public int ID_kho;
        public DateTime Ngay_lap;
        public string Ly_do;
        public string So_hoa_don;
        public string Dia_chi;
        public string Cong_trinh;
        public int? ID_Loai_Phieu_Nhap;
        public int ID_phieu_nhap;
        public string Kho_nhan;
        public string Kho_xuat_ra;
        public bool Da_phan_kho;
        public int ID_khoNhan;
        public bool isNhapNgoai;
        public bool isCanTru = false;
        public bool isGoiDau=false;
        public bool isKNMN = false;
        public bool isDaTraNo = false;
        public bool isToTrinh = false;
        public bool isKNTN = false;
        public string Ten_kho_muon;
        public bool isKCTN = false;
        public bool isKCMN = false;
        public bool isNVMN = false;
        public DateTime ngay_xac_nhan = DateTime.Now;
        public List<clsChi_Tiet_Phieu_Nhap_Vat_Tu> lstChiTietPhieuNhap = new List<clsChi_Tiet_Phieu_Nhap_Vat_Tu>();
        SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);

        public clsPhieuNhapKho()
        {
        }

        public int GetIDPhieu(string maphieu )
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            var entryPoint = (from ep in help.ent.Phieu_Nhap_Kho where ep.Ma_phieu_nhap.Equals(maphieu) select new { ep.ID_phieu_nhap}).FirstOrDefault();
            return entryPoint.ID_phieu_nhap;
        }

        /// <summary>
        /// lấy tất cả danh sách theo điều kiện đã duyệt hay chưa duyệt 
        /// </summary>
        /// <param name="status"> true: đã duyệt, false : chưa duyệt</param>
        /// <returns></returns>
        public DataTable GetAll(bool status,string value)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();

            var entryPoint = (from ep in help.ent.Phieu_Nhap_Kho
                              join e in help.ent.DM_Kho on ep.ID_kho equals e.ID_kho
                              where ep.Da_phan_kho.ToString().Contains(status.ToString()) && ep.ID_Loai_Phieu_Nhap.ToString().Contains(value)

                              select new
                              {
                                  ep.Ma_phieu_nhap,
                                  ep.Kho_nhan,
                                  ep.Ngay_lap,
                                  ep.Ly_do,
                                  ep.So_hoa_don,
                                  ep.Cong_trinh,
                                  ep.Dia_Chi,
                                  ep.ID_Loai_Phieu_Nhap,
                                  ep.Kho_xuat_ra,
                                  ep.Da_phan_kho,
                                  ep.ID_phieu_nhap,
                                  ep.ID_kho,
                                  e.Ten_kho,
                                  ep.isGoiDau,
                              }).ToList();
            // return entryPoint;


            return Utilities.clsThamSoUtilities.ToDataTable(entryPoint);

        }


        public static int? GetMaxValue()
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();

            var maxEntity = help.ent.Phieu_Nhap_Kho.OrderByDescending(x => x.ID_phieu_nhap).FirstOrDefault();
            // return entryPoint;



            if (maxEntity == null)
                return null;
            return maxEntity.ID_phieu_nhap;

        }
        /// <summary>
        /// Get tất cả dữ liệu từ CSDL, dùng cho Grid 
        /// 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();

            var entryPoint = (from ep in help.ent.Phieu_Nhap_Kho
                              join e in help.ent.DM_Kho on ep.ID_kho equals e.ID_kho

                              select new
                              {
                                  ep.Ma_phieu_nhap,
                                  ep.Kho_nhan,
                                  ep.Ngay_lap,
                                  ep.Ly_do,
                                  ep.So_hoa_don,
                                  ep.Cong_trinh,
                                  ep.Dia_Chi,
                                  ep.ID_Loai_Phieu_Nhap,
                                  ep.Kho_xuat_ra,
                                  ep.Da_phan_kho,
                                  ep.ID_phieu_nhap,
                                  ep.ID_kho,
                                  e.Ten_kho,
                                  ep.isGoiDau,
                              }).ToList();
            return Utilities.clsThamSoUtilities.ToDataTable(entryPoint);
        }


        /// <summary>
        /// ham xu ly thong tin neu phieu nhap vao la X thi tien hanh kiem tra xem co ton tai phieu no nao co soluong 
        /// </summary>
        /// <returns></returns>
        public static bool XuLyKiemTraPhieuNhapLaX(string maphieu)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();

            var entryPoint = (from ep in help.ent.Phieu_Nhap_Kho
                              join e in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu on ep.Ma_phieu_nhap equals e.Ma_phieu_nhap
                              where ep.Ma_phieu_nhap == maphieu
                              select new { 
                                e.Ma_vat_tu,
                                e.So_luong_thuc_lanh,

                              }).FirstOrDefault();
            if (entryPoint != null)
            {
                var entryPointNo = (from ep in help.ent.Phieu_Nhap_Kho
                                  join e in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu on ep.Ma_phieu_nhap equals e.Ma_phieu_nhap
                                  where ep.isNhapNgoai == true && ep.isCanTru == false  
                                  select new
                                  {

                                      e.Ma_vat_tu,
                                      e.So_luong_thuc_lanh,

                                  }).FirstOrDefault();
            }



                              //join e in help.ent.DM_Kho on ep.ID_kho equals e.ID_kho
                              //where ep.isNhapNgoai == true
                              //select new
                              //{
                              //    ep.Ma_phieu_nhap,
                              //    ep.Kho_nhan,
                              //    ep.Ngay_lap,
                              //    ep.Ly_do,
                              //    ep.So_hoa_don,
                              //    ep.Cong_trinh,
                              //    ep.Dia_Chi,
                              //    ep.ID_Loai_Phieu_Nhap,
                              //    ep.Kho_xuat_ra,
                              //    ep.Da_phan_kho,
                              //    ep.ID_phieu_nhap,
                              //    ep.ID_kho,
                              //    e.Ten_kho,
                              //    ep.isGoiDau,
                              //    ep.isCanTru,
                              //    ep.isNhapNgoai,
                              //}).ToList();
            return true;
        }
        
        /// <summary>
        /// ham kiem tra xem trong so vat tu trong phieu no co phieu nao co vat tu da co trong phieu cho muon ko ?
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllPhieuChoMuonNo()
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();

            var entryPoint = (from ep in help.ent.Phieu_Nhap_Kho
                              join e in help.ent.DM_Kho on ep.ID_kho equals e.ID_kho
                              where ep.isNhapNgoai ==true
                              select new
                              {
                                  ep.Ma_phieu_nhap,
                                  ep.Kho_nhan,
                                  ep.Ngay_lap,
                                  ep.Ly_do,
                                  ep.So_hoa_don,
                                  ep.Cong_trinh,
                                  ep.Dia_Chi,
                                  ep.ID_Loai_Phieu_Nhap,
                                  ep.Kho_xuat_ra,
                                  ep.Da_phan_kho,
                                  ep.ID_phieu_nhap,
                                  ep.ID_kho,
                                  e.Ten_kho,
                                  ep.isGoiDau,
                                  ep.isCanTru,
                                  ep.isNhapNgoai,
                              }).ToList();
            return Utilities.clsThamSoUtilities.ToDataTable(entryPoint);
        }
        public static bool CheckGetAllPhieuChoMuon(string maphieu)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            var entryPointPN = (from ep in help.ent.Phieu_Nhap_Kho
                                join e in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu on ep.Ma_phieu_nhap equals e.Ma_phieu_nhap
                                where ep.Ma_phieu_nhap == maphieu
                                select new
                                {
                                    e.Ma_vat_tu,
                                    e.So_luong_thuc_lanh,
                                }
                                    ).ToList();



            for (int i = 0; i < entryPointPN.Count; i++)
            {
                string ma_vat_tu = entryPointPN[i].Ma_vat_tu;
                var entryPointCT = (from ep in help.ent.Phieu_Nhap_Kho
                                    join e in help.ent.DM_Kho on ep.ID_kho equals e.ID_kho
                                    join f in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu on ep.Ma_phieu_nhap equals f.Ma_phieu_nhap
                                    where ep.isNhapNgoai == true && ep.Da_phan_kho == true && ep.isCanTru == false
                                    && ep.isKNMN == true 
                                    && f.Ma_vat_tu == ma_vat_tu && f.So_luong_thuc_lanh >0
                                    select new
                                    {
                                        ep.Ma_phieu_nhap,
                                        ep.Kho_nhan,
                                        ep.Ngay_lap,
                                        ep.Ly_do,
                                        ep.So_hoa_don,
                                        ep.Cong_trinh,
                                        ep.Dia_Chi,
                                        ep.ID_Loai_Phieu_Nhap,
                                        ep.Kho_xuat_ra,
                                        ep.Da_phan_kho,
                                        ep.ID_phieu_nhap,
                                        ep.ID_kho,
                                        e.Ten_kho,
                                        ep.isGoiDau,
                                        ep.isCanTru,
                                        ep.isNhapNgoai,
                                        ep.isKNTN,
                                    }).ToList();
                if (entryPointCT != null && entryPointCT.Count >0 )
                    return true;

            }
            return false;
        }

        /// <summary>
        ///  lay danh sach phieu no da duoc duyet 
        /// </summary>
        /// <returns></returns>
        public static bool GetAllPhieuNoDaDuyet(string maphieu)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
              var entryPointPN = (from ep in help.ent.Phieu_Nhap_Kho
                              join e in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu on ep.Ma_phieu_nhap equals e.Ma_phieu_nhap
                              where ep.Ma_phieu_nhap == maphieu
                                      select new {
            e.Ma_vat_tu ,
            e.So_luong_thuc_lanh,
        }
                                      ).ToList();



              for (int i = 0; i < entryPointPN.Count; i++)
              {
                  string ma_vat_tu = entryPointPN[i].Ma_vat_tu;
                  var entryPointCT = (from ep in help.ent.Phieu_Nhap_Kho
                                    join e in help.ent.DM_Kho on ep.ID_kho equals e.ID_kho
                                      join f in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu on ep.Ma_phieu_nhap equals f.Ma_phieu_nhap
                                    where ep.Da_phan_kho == true && ep.isCanTru == false 
                                    && ep.isToTrinh == true
                                    && f.Ma_vat_tu == ma_vat_tu && f.So_luong_thuc_lanh > 0
                                    select new
                                    {
                                        ep.Ma_phieu_nhap,
                                        ep.Kho_nhan,
                                        ep.Ngay_lap,
                                        ep.Ly_do,
                                        ep.So_hoa_don,
                                        ep.Cong_trinh,
                                        ep.Dia_Chi,
                                        ep.ID_Loai_Phieu_Nhap,
                                        ep.Kho_xuat_ra,
                                        ep.Da_phan_kho,
                                        ep.ID_phieu_nhap,
                                        ep.ID_kho,
                                        e.Ten_kho,
                                        ep.isGoiDau,
                                        ep.isCanTru,
                                        ep.isNhapNgoai,
                                        ep.isKNTN,
                                    }).ToList();
                  if (entryPointCT != null && entryPointCT.Count > 0)
                      return true;

              }
              return false;
        }

        public static bool KTVTChuaDuyet(string ma_Phieunhap)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();


            var entryPoint = (from ep in help.ent.Phieu_Nhap_Kho
                              where ep.Ma_phieu_nhap.Equals(ma_Phieunhap) && ep.Da_phan_kho == true
                              select ep).ToList();

            if (entryPoint.Count == 0)
                return false;// chua co phan tu nao da duyet trong danh sach
            return true;
        }
        public DataTable SearchDSPN(bool? status, string ten_kho, string nhapngoai, string cantru)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();

            if (status == null)
            {
                var entryPoint = (from ep in help.ent.Phieu_Nhap_Kho
                                  join e in help.ent.DM_Kho on ep.ID_kho equals e.ID_kho
                                  where e.Ten_kho.Contains(ten_kho)
                                  && ep.isNhapNgoai.ToString().Contains(nhapngoai) && ep.isCanTru.ToString().Contains(cantru)

                                  select new
                                  {
                                     ma_phieu = ep.Ma_phieu_nhap,
                                      ep.Kho_nhan,
                                    ngay_lap=  ep.Ngay_lap,
                                    ly_do=  ep.Ly_do,
                                      ep.So_hoa_don,
                                      ep.Cong_trinh,
                                      ep.Dia_Chi,
                                      ep.ID_Loai_Phieu_Nhap,
                                      ep.Kho_xuat_ra,
                                      ep.Da_phan_kho,
                                      ep.ID_phieu_nhap,
                                      ep.ID_kho,
                                     Ten_kho= e.Ten_kho,
                                    isGoiDau =  ep.isGoiDau,
                                   isCanTru=   ep.isCanTru,
                                   isNhapNgoai=   ep.isNhapNgoai,
                                     isKNMN = ep.isKNMN,
                                     ngay_xac_nhan = ep.ngay_xac_nhan,
                                     isKNTN = ep.isKNTN,
                                     isKCMN = ep.isKCMN,
                                     isKCTN = ep.isKCTN,
                                     isToTrinh = ep.isToTrinh,
                                     isNVMN = ep.isNVMN,

                                  }

           ).ToList();
                return Utilities.clsThamSoUtilities.ToDataTable(entryPoint);
            }
            else
            {
               var  entryPoint = (from ep in help.ent.Phieu_Nhap_Kho
                              join e in help.ent.DM_Kho on ep.ID_kho equals e.ID_kho
                                  where e.Ten_kho.Contains(ten_kho) && ep.Da_phan_kho.Value.ToString().Contains( status .Value.ToString())
                              select new
                              {
                                  ma_phieu = ep.Ma_phieu_nhap,
                                  ep.Kho_nhan,
                                  ngay_lap = ep.Ngay_lap,
                                  ly_do = ep.Ly_do,
                                  ep.So_hoa_don,
                                  ep.Cong_trinh,
                                  ep.Dia_Chi,
                                  ep.ID_Loai_Phieu_Nhap,
                                  ep.Kho_xuat_ra,
                                  ep.Da_phan_kho,
                                  ep.ID_phieu_nhap,
                                  ep.ID_kho,
                                  Ten_kho = e.Ten_kho,
                                  isGoiDau = ep.isGoiDau,
                                  isCanTru = ep.isCanTru,
                                  isNhapNgoai = ep.isNhapNgoai,
                                  isKNMN = ep.isKNMN,
                                  ngay_xac_nhan = ep.ngay_xac_nhan,
                                  isKNTN = ep.isKNTN,
                                  isKCMN = ep.isKCMN,
                                  isKCTN = ep.isKCTN,
                                  isToTrinh = ep.isToTrinh,
                                  isNVMN = ep.isNVMN,
                              }

           ).ToList();
               return Utilities.clsThamSoUtilities.ToDataTable(entryPoint);
            }
         
        }

        /// <summary>
        /// ham nay lay len danh sach cac phieu nhap chua phan kho 
        /// chua can tru 
        /// gom 2 loai : phieu tu to trinh va phieu tu muon ngoai 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="ten_kho"></param>
        /// <param name="nhapngoai"></param>
        /// <param name="cantru"></param>
        /// <returns></returns>
        public DataTable SearchDSPN( string ten_kho, string nhapngoai, string cantru)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();

        
            {
                var entryPoint = (from ep in help.ent.Phieu_Nhap_Kho
                                  join e in help.ent.DM_Kho on ep.ID_kho equals e.ID_kho
                                  where e.Ten_kho.Contains(ten_kho)
                                  && ep.isNhapNgoai.ToString().Contains(nhapngoai) && ep.isCanTru.ToString().Contains(cantru)
                                  && ep.Da_phan_kho == false

                                  select new
                                  {
                                      ma_phieu = ep.Ma_phieu_nhap,
                                      ep.Kho_nhan,
                                      ngay_lap = ep.Ngay_lap,
                                      ly_do = ep.Ly_do,
                                      ep.So_hoa_don,
                                      ep.Cong_trinh,
                                      ep.Dia_Chi,
                                      ep.ID_Loai_Phieu_Nhap,
                                      ep.Kho_xuat_ra,
                                      ep.Da_phan_kho,
                                      ep.ID_phieu_nhap,
                                      ep.ID_kho,
                                      Ten_kho = e.Ten_kho,
                                      isGoiDau = ep.isGoiDau,
                                      isCanTru = ep.isCanTru,
                                      isNhapNgoai = ep.isNhapNgoai,
                                      isChoMuonNgoai = ep.isKNMN,
                                      ngay_xac_nhan = ep.ngay_xac_nhan,
                                  }

           ).ToList();
                return Utilities.clsThamSoUtilities.ToDataTable(entryPoint);
            }
          
              

        }
        public static DataTable GetAllPhieuNo()
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();

            var entryPoint = (from ep in help.ent.Phieu_Nhap_Kho
                              join e in help.ent.DM_Kho on ep.ID_kho equals e.ID_kho
                              where ep.isNhapNgoai == true
                              && ep.isToTrinh == false
                              select new
                              {
                                  ep.Ma_phieu_nhap,
                                  ep.Kho_nhan,
                                  ep.Ngay_lap,
                                  ep.Ly_do,
                                  ep.So_hoa_don,
                                  ep.Cong_trinh,
                                  ep.Dia_Chi,
                                  ep.ID_Loai_Phieu_Nhap,
                                  ep.Kho_xuat_ra,
                                  ep.Da_phan_kho,
                                  ep.ID_phieu_nhap,
                                  ep.ID_kho,
                                  e.Ten_kho,
                                  ep.isGoiDau,
                                  ep.isCanTru,
                                  ep.isNhapNgoai,
                              }).ToList();
            return Utilities.clsThamSoUtilities.ToDataTable(entryPoint);
        }

        public DataTable GetAllPhieuNo(string maPhieu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            var entryPoint = (from ep in help.ent.Phieu_Nhap_Kho
                              join e in help.ent.DM_Kho on ep.ID_kho equals e.ID_kho
                         

                              where ep.Ma_phieu_nhap == maPhieu
                              select new
                              {
                                  ep.Ma_phieu_nhap,
                                  ep.Kho_nhan,
                                  ep.Ngay_lap,
                                  ep.Ly_do,
                                  ep.So_hoa_don,
                                  ep.Cong_trinh,
                                  ep.Dia_Chi,
                                  ep.ID_Loai_Phieu_Nhap,
                                  ep.Kho_xuat_ra,
                                  ep.Da_phan_kho,
                                  ep.ID_phieu_nhap,
                                  ep.ID_kho,
                                  e.Ten_kho,
                                  ep.isGoiDau,
                                  ep.Ten_kho_muon ,
                                  ep.isKNTN,
                                  ep.isKNMN,
                                  ep.isKCMN,
                                  ep.isKCTN,
                              }

        ).ToList();

            return Utilities.clsThamSoUtilities.ToDataTable(entryPoint);
        }
        public DataTable GetAll(string maPhieu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            var entryPoint = (from ep in help.ent.Phieu_Nhap_Kho
                             join e in help.ent.DM_Kho on ep.ID_kho equals e.ID_kho
                              join ls in help.ent.Loai_Phieu_Nhap on ep.ID_Loai_Phieu_Nhap equals ls.ID_Loai_Phieu_Nhap
                             
                             where ep.Ma_phieu_nhap == maPhieu
            select new
            {
            ep.Ma_phieu_nhap,
                             ep.Kho_nhan,
            ep.Ngay_lap,
            ep.Ly_do,
            ep.So_hoa_don,
            ep.Cong_trinh,
            ep.Dia_Chi,
            ep.ID_Loai_Phieu_Nhap,
            ep.Kho_xuat_ra,
            ep.Da_phan_kho,
            ep.ID_phieu_nhap,
            ep.ID_kho ,
            ep.isCanTru ,
            e.Ten_kho,
            ep.isGoiDau ,
            ls.Ten_loai_phieu_nhap,
                
        }

        ).ToList();
         
            return Utilities.clsThamSoUtilities.ToDataTable(entryPoint);
        }
        public static Phieu_Nhap_Kho GetPhieuNhap( DatabaseHelper help,string maPhieu)
        {
          

            var entryPoint = (from ep in help.ent.Phieu_Nhap_Kho
                              where ep.Ma_phieu_nhap.Equals(maPhieu)
                              select ep

        ).FirstOrDefault();

            return entryPoint;
        }


        public static Phieu_Nhap_Kho GetPhieuNhap(string maPhieu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            var entryPoint = (from ep in help.ent.Phieu_Nhap_Kho
                             where ep.Ma_phieu_nhap .Equals(maPhieu)
                            select ep

        ).FirstOrDefault();

            return entryPoint;
        }

        public DataTable GetChiTietPhieuNhap(string Ma_phieu_nhap)
        {



            return GetAll(Ma_phieu_nhap);
            //return table;

            //m_dbConnection.Open();

            //DataTable dt = new DataTable();
            ////string sql = "SELECT * FROM DM_Vat_Tu";
            ////SELECT ROW_NUMBER() OVER (ORDER BY Ma_phieu_nhap) AS rn, * FROM Chi_Tiet_Phieu_Nhap_Vat_Tu
            //string sql = "";
            //sql += "SELECT ";
            //sql += "" + "ROW_NUMBER() OVER (ORDER BY Chi_Tiet_Phieu_Nhap_Vat_Tu.Ma_phieu_nhap) AS Stt, ";
            //sql += "" + "DM_Vat_Tu.Ma_vat_tu, ";
            //sql += "" + "DM_Vat_Tu.Ten_vat_tu, ";
            //sql += "" + "Chi_Tiet_Phieu_Nhap_Vat_Tu.Chat_luong, ";
            //sql += "" + "DM_Don_vi_tinh.Ten_don_vi_tinh, ";
            //sql += "" + "Chi_Tiet_Phieu_Nhap_Vat_Tu.So_luong_yeu_cau, ";
            //sql += "" + "Chi_Tiet_Phieu_Nhap_Vat_Tu.So_luong_thuc_lanh, ";
            //sql += "" + "Chi_Tiet_Phieu_Nhap_Vat_Tu.Don_gia, ";
            //sql += "" + "Chi_Tiet_Phieu_Nhap_Vat_Tu.Thanh_tien ";
            //sql += "FROM Chi_Tiet_Phieu_Nhap_Vat_Tu ";
            //sql += "INNER ";
            //sql += "" + "JOIN DM_Vat_Tu ";
            //sql += "" + "ON DM_Vat_Tu.Ma_vat_tu=Chi_Tiet_Phieu_Nhap_Vat_Tu.Ma_vat_tu ";
            //sql += "INNER ";
            //sql += "" + "JOIN DM_Don_vi_tinh ";
            //sql += "" + "ON DM_Don_vi_tinh.ID_Don_vi_tinh=Chi_Tiet_Phieu_Nhap_Vat_Tu.ID_Don_vi_tinh ";
            //sql += "WHERE Chi_Tiet_Phieu_Nhap_Vat_Tu.Ma_phieu_nhap=@Ma_phieu_nhap";

            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", Ma_phieu_nhap));

            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //m_dbConnection.Close();

            //return dt;
        }

        public DataTable GetThongTinPhieuNhap(string Ma_phieu_nhap)
        {

            return GetAll(Ma_phieu_nhap);

            //m_dbConnection.Open();

            //DataTable dt = new DataTable();

            //string sql = "";
            //sql += "SELECT ";
            //sql += "" + "DM_Kho.Ten_kho, ";
            //sql += "" + "CONVERT(VARCHAR(10), Phieu_Nhap_Kho.Ngay_lap, 102) as Ngay_lap, ";
            //sql += "" + "Phieu_Nhap_Kho.Ly_do, ";
            //sql += "" + "Phieu_Nhap_Kho.So_hoa_don, ";
            //sql += "" + "Phieu_Nhap_Kho.Cong_trinh, ";
            //sql += "" + "Phieu_Nhap_Kho.Dia_Chi ";
            //sql += "FROM Phieu_Nhap_Kho ";
            //sql += "INNER ";
            //sql += "" + "JOIN DM_Kho ";
            //sql += "" + "ON Phieu_Nhap_Kho.ID_kho=DM_Kho.ID_kho ";
            //sql += "WHERE Phieu_Nhap_Kho.Ma_phieu_nhap=@Ma_phieu_nhap";

            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", Ma_phieu_nhap));

            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //m_dbConnection.Close();

            //return dt;
        }
        public DataTable GetThongTinPhieuMuonNo(string Ma_phieu_nhap)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            var entryPoint = (from ep in help.ent.Phieu_Nhap_Kho
                              join e in help.ent.DM_Kho on ep.ID_kho equals e.ID_kho
                            
                              where ep.Ma_phieu_nhap == Ma_phieu_nhap
                              select new
                              {
                                  ep.Ma_phieu_nhap,
                                  ep.Kho_nhan,
                                  ep.Ngay_lap,
                                  ep.Ly_do,
                                  ep.So_hoa_don,
                                  ep.Cong_trinh,
                                  ep.Dia_Chi,
                                  ep.ID_Loai_Phieu_Nhap,
                                  ep.Kho_xuat_ra,
                                  ep.Da_phan_kho,
                                  ep.ID_phieu_nhap,
                                  ep.ID_kho,
                                  ep.isCanTru,
                                  e.Ten_kho,
                                  ep.isGoiDau,
                                 

                              }

        ).ToList();

            return Utilities.clsThamSoUtilities.ToDataTable(entryPoint);

          
        }

        //public bool CheckTonTaiSoDK()
        //{
        //    DatabaseHelper help = new DatabaseHelper();
        //    help.ConnectDatabase();
        //    bool has = help.ent.Phieu_Nhap_Kho.Any(cus => cus.Ma_phieu_nhap == Ma_phieu_nhap);
        //    return has;



        //    //m_dbConnection.Open();
        //    //DataTable dt = new DataTable();
        //    //string sql = "SELECT * FROM Phieu_Nhap_Kho WHERE ma_phieu_nhap=@ma_phieu_nhap";
        //    //SqlCommand command = new SqlCommand(sql, m_dbConnection);
        //    //command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));
        //    //SqlDataAdapter da = new SqlDataAdapter(command);
        //    //da.Fill(dt);
        //    //m_dbConnection.Close();

        //    //if (dt.Rows.Count > 0)
        //    //{
        //    //    return true;
        //    //}
        //    //return false;
        //}
        public bool CheckTonTaiSoDK(string Ma_phieu_nhap, DatabaseHelper help)
        {
            
            bool has = help.ent.Phieu_Nhap_Kho.Any(cus => cus.Ma_phieu_nhap == Ma_phieu_nhap);
            return has;


            //m_dbConnection.Open();
            //DataTable dt = new DataTable();
            //string sql = "SELECT * FROM Phieu_Nhap_Kho WHERE ma_phieu_nhap=@ma_phieu_nhap";
            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //m_dbConnection.Close();

            //if (dt.Rows.Count > 0)
            //{
            //    return true;
            //}
            //return false;
        }
        public bool CheckTonTaiSoDK(string Ma_phieu_nhap)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            bool has = help.ent.Phieu_Nhap_Kho.Any(cus => cus.Ma_phieu_nhap == Ma_phieu_nhap);
            return has;


            //m_dbConnection.Open();
            //DataTable dt = new DataTable();
            //string sql = "SELECT * FROM Phieu_Nhap_Kho WHERE ma_phieu_nhap=@ma_phieu_nhap";
            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //m_dbConnection.Close();

            //if (dt.Rows.Count > 0)
            //{
            //    return true;
            //}
            //return false;
        }

        public int Insert(SQLDAL dal)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            // insert
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                try
                {
                    var t = new Phieu_Nhap_Kho //Make sure you have a table called test in DB
                    {
                        Ma_phieu_nhap = this.Ma_phieu_nhap,
                        Kho_nhan = this.Kho_nhan,
                        Ngay_lap = this.Ngay_lap,
                        Ly_do = this.Ly_do,
                        So_hoa_don = this.So_hoa_don,
                        Cong_trinh = this.Cong_trinh,
                        Dia_Chi = this.Dia_chi,
                        ID_Loai_Phieu_Nhap = this.ID_Loai_Phieu_Nhap,
                        Kho_xuat_ra = this.Kho_xuat_ra,
                        Da_phan_kho = this.Da_phan_kho,
                     //   ID_phieu_nhap = this.ID_phieu_nhap,
                         ID_kho = this.ID_khoNhan,
                         isGoiDau = this.isGoiDau,
                    };

                    help.ent.Phieu_Nhap_Kho.Add(t);
                    help.ent.SaveChanges();
                    dbcxtransaction.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    dbcxtransaction.Rollback();

                    return 0;
                }
            }
        }
        /// <summary>
        /// hàm insert này dùng transaction để insert
        /// </summary>
        /// <param name="help"></param>
        /// <returns></returns>
        public int Insert(DatabaseHelper help)
        {

            // insert
          
            {
                try
                {
                    var t = new Phieu_Nhap_Kho //Make sure you have a table called test in DB
                    {
                        Ma_phieu_nhap = this.Ma_phieu_nhap??"",
                        Kho_nhan = this.Kho_nhan??"",
                        Ngay_lap = this.Ngay_lap,
                        Ly_do = this.Ly_do??"",
                        So_hoa_don = this.So_hoa_don ?? "",
                        Cong_trinh = this.Cong_trinh ?? "",
                        Dia_Chi = this.Dia_chi ?? "",
                        ID_Loai_Phieu_Nhap = this.ID_Loai_Phieu_Nhap ==null?null:this.ID_Loai_Phieu_Nhap,
                        Kho_xuat_ra = this.Kho_xuat_ra ?? "",
                        Da_phan_kho = this.Da_phan_kho==null?false:this.Da_phan_kho,
                        ID_kho = this.ID_khoNhan,
                        Ngay_nhap_vat_tu = DateTime.Today,
                        isGoiDau = this.isGoiDau,
                        isNhapNgoai = this.isNhapNgoai,
                        isCanTru = this.isCanTru,
                        isKNMN = this.isKNMN,
                        isDaTraNo = this.isDaTraNo,
                        isKNTN = this.isKNTN,
                        ngay_xac_nhan = this.ngay_xac_nhan,
                        isToTrinh = this.isToTrinh,
                        isKCTN = this.isKCTN,
                        isKCMN = this.isKCMN,
                        isNVMN = this.isNVMN,
                        Ten_kho_muon = this.Ten_kho_muon,
                    };

                    help.ent.Phieu_Nhap_Kho.Add(t);
                    help.ent.SaveChanges();

                    return 1;
                }
                catch (Exception ex)
                {


                    return 0;
                }
            }
        }


        //dal.BeginTransaction();

        //m_dbConnection = dal.m_conn;
        //if(m_dbConnection.State == ConnectionState.Closed)
        //    m_dbConnection.Open();

        //string sql = "";
        //sql += "INSERT INTO Phieu_Nhap_Kho (ma_phieu_nhap,ID_kho,Ngay_lap,ly_do,Dia_chi,Cong_trinh) ";
        //sql += "VALUES(@ma_phieu_nhap,@ID_kho,@Ngay_lap,@ly_do,@Dia_chi,@Cong_trinh)";

        //SqlCommand command = new SqlCommand(sql, m_dbConnection,dal.m_trans);
        //command.CommandType = CommandType.Text;

        ////command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
        //command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));
        //command.Parameters.Add(new SqlParameter("@ID_kho", ID_kho));
        //command.Parameters.Add(new SqlParameter("@Ngay_lap", Ngay_lap.ToString("yyyy-MM-dd")));
        //command.Parameters.Add(new SqlParameter("@Ly_do", Ly_do));
        ////  command.Parameters.Add(new SqlParameter("@So_hoa_don", So_hoa_don));
        //command.Parameters.Add(new SqlParameter("@Dia_chi", Dia_chi));
        //command.Parameters.Add(new SqlParameter("@Cong_trinh", Cong_trinh));


        ////command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));

        //int result = command.ExecuteNonQuery();
        //dal.CommitTransaction();


        public int Update(  DatabaseHelper help,Phieu_Nhap_Kho nk)
        {

            int temp = 0;
            {
              
                {
                    help.ent.Phieu_Nhap_Kho.Attach(nk);
                    help.ent.Entry(nk).State = EntityState.Modified;
                    temp = help.ent.SaveChanges();
                   

                }

                // dbcxtransaction.Commit();
            }
            return temp;



        }
        public int Update(Phieu_Nhap_Kho nk)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            int temp = 0;
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                using (var context = help.ent)
                {
                    context.Phieu_Nhap_Kho.Attach(nk);
                    context.Entry(nk).State = EntityState.Modified;
                    temp = help.ent.SaveChanges();
                    dbcxtransaction.Commit();

                }

                // dbcxtransaction.Commit();
            }
            return temp;


          
        }
        public int Delete(string ma_phieu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            //   help.ent.Database.BeginTransaction();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var recordsToDeleteCT = (from c in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu where c.Ma_phieu_nhap == ma_phieu select c).ToList<Chi_Tiet_Phieu_Nhap_Vat_Tu>();
                if (recordsToDeleteCT.Count > 0)
                {
                    foreach (var record in recordsToDeleteCT)
                    {
                        help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Attach(record);
                        help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Remove(record);
                    }
                }
                help.ent.SaveChanges();
                var recordsToDelete = (from c in help.ent.Phieu_Nhap_Kho where c.Ma_phieu_nhap == ma_phieu select c).ToList<Phieu_Nhap_Kho>();
                if (recordsToDelete.Count > 0)
                {
                    foreach (var record in recordsToDelete)
                    {
                        help.ent.Phieu_Nhap_Kho.Attach(record);
                        help.ent.Phieu_Nhap_Kho.Remove(record);
                    }
                }
                help.ent.SaveChanges();
                dbcxtransaction.Commit();
                return 1;
            }
            return 0;
            //DatabaseHelper help = new DatabaseHelper();
            //help.ConnectDatabase();
            //using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            //{


            //    help.ent.Phieu_Nhap_Kho.Attach(nk);
            //    help.ent.Phieu_Nhap_Kho.Remove(nk);
            //    if (help.ent.SaveChanges() == 1)
            //    {
            //        dbcxtransaction.Commit();
            //        return 1;
            //    }
            //    else
            //        dbcxtransaction.Rollback();
            //}
            //return 0;
            //DAL.BeginTransaction();

            //m_dbConnection = DAL.m_conn;
            //if (m_dbConnection.State == ConnectionState.Closed)
            //m_dbConnection.Open();
            //string sql = "Delete from Phieu_Nhap_Kho WHERE ma_phieu_nhap=@ma_phieu_nhap";


            //SqlCommand command = new SqlCommand(sql, m_dbConnection, DAL.m_trans);
            //command.CommandType = CommandType.Text;

            //command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));

            //int result = command.ExecuteNonQuery();
            //DAL.CommitTransaction();
            //return result;
        }


      
    }
}
