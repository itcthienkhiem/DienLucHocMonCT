using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace coInventory.Mini.EntityClass
{
    public class clsBangKe
    {
        public int BangKe_Id;

        public int? LoaiBangKe;
        public string SoHoSo;
        public string Khoa;
        public string MaKhamChuaBenh;
        public string MaNguoiBenh;
        public string HoTen;
        public int? GioiTinh;
        public DateTime? NgaySinh;
        public int? NamSinh;
        public string DiaChi;
        public string MaNoiSinhSong;
        public string SoTheBHYT;
        public DateTime? TuNgayBH;
        public DateTime? DenNgayBH;
        public bool? CoBHYT = true;
        public bool? TreEmKhongTheBHYT = false;
        public int? MucHuong;
        public decimal? PhanTramDuocHuong;
        public string MaCSKCBBanDau;
        public string TenCSKCBBanDau;
        public string MaCSKCB;
        public string MaChiNhanh;
        public string MaNoiChuyenDen;
        public string TenNoiChuyenDen;
        public DateTime? NgayDenKham;
        public DateTime? NgayKetThuc;
        public int? SoNgayDieuTri;
        public DateTime? NgayQuyetToan;
        public int? TuyenKhamBenh;
        public string ChanDoan;
        public string BenhKhac;
        public string MaICD;
        public decimal? TongChiPhi;
        public decimal? BHYTThanhToan;
        public decimal? NguoiBenhTra;
        public decimal? NguonKhac;
        public decimal? SoTienThanhToanToiDa;
        public decimal? TienKham;
        public decimal? TienGiuong;
        public decimal? TienXN;
        public decimal? TienCDHA;
        public decimal? TienTDCN;
        public decimal? TienPTTT;
        public decimal? TienDichVuKTC;
        public decimal? TienMau;
        public decimal? TienThuoc;
        public decimal? TienVTYT;
        public decimal? TienVTYTTH;
        public decimal? TienVTYTTT;
        public decimal? TienVanChuyen;
        public decimal? DVKTC_TinhToan;
        public decimal? DVKTC_ThanhToan;
        public decimal? ChiPhiNgoaiDinhSuat;
        public bool? DaGuiBHYT;
        public DateTime? NgayGuiBHYT;
        public string NguoiGuiBHYT;
        public DateTime? NgayTao;
        public string NguoiTao;
        public DateTime? NgayCapNhat;
        public string NguoiCapNhat;
        public bool? ChungNhanKhongCCT;

        public int? BangKe_Id_BHXH;

        SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        public clsBangKe()
        {
            BangKe_Id = 0;
            LoaiBangKe = 0;
            SoHoSo = "";
            Khoa = "";
            MaKhamChuaBenh = "";
            MaNguoiBenh = "";
            HoTen = "";
            GioiTinh = 0;
            NgaySinh = DateTime.MinValue;
            NamSinh = 0;
            DiaChi = "";
            MaNoiSinhSong = "";
            SoTheBHYT = "";
            TuNgayBH = DateTime.MinValue;
            DenNgayBH = DateTime.MinValue;
            CoBHYT = true;
            TreEmKhongTheBHYT = false;
            MucHuong = 0;
            PhanTramDuocHuong = 0;
            MaCSKCBBanDau = "";
            TenCSKCBBanDau = "";
            MaCSKCB = "";
            MaChiNhanh = "";
            MaNoiChuyenDen = "";
            TenNoiChuyenDen = "";
            NgayDenKham = DateTime.MinValue;
            NgayKetThuc = DateTime.MinValue;
            SoNgayDieuTri = 0;
            NgayQuyetToan = DateTime.MinValue;
            TuyenKhamBenh = 0;
            ChanDoan = "";
            BenhKhac = "";
            MaICD = "";
            TongChiPhi = 0;
            BHYTThanhToan = 0;
            NguoiBenhTra = 0;
            NguonKhac = 0;
            SoTienThanhToanToiDa = 0;
            TienKham = 0;
            TienGiuong = 0;
            TienXN = 0;
            TienCDHA = 0;
            TienTDCN = 0;
            TienPTTT = 0;
            TienDichVuKTC = 0;
            TienMau = 0;
            TienThuoc = 0;
            TienVTYT = 0;
            TienVTYTTH = 0;
            TienVTYTTT = 0;
            TienVanChuyen = 0;
            DVKTC_TinhToan = 0;
            DVKTC_ThanhToan = 0;
            ChiPhiNgoaiDinhSuat = 0;
            DaGuiBHYT = false;
            //NgayGuiBHYT =DateTime.MinValue;
            NguoiGuiBHYT = "";
            //NgayTao = DateTime.MinValue;
            NguoiTao = "";
            //NgayCapNhat = DateTime.MinValue;
            NguoiCapNhat = "";
            ChungNhanKhongCCT = false;
        }
        //public DataTable Search()
        //{
        //    m_dbConnection.Open();
        //    DataTable dt = new DataTable();
        //    string sql = "SELECT * FROM BangKe ";
        //    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
        //    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
        //    da.Fill(dt);
        //    m_dbConnection.Close();
        //}
        /// <summary>
        /// Get ALL
        /// </summary>
        /// <returns>DataTable</returns>
        /// 
        public DataTable GetAll()
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BangKe";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public DataTable GetAll(int intLoaiBangKe)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BangKe Where LoaiBangKe=@LoaiBangKe";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@LoaiBangKe", intLoaiBangKe));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }
        public DataTable GetByKey(DateTime dateTuNgay, DateTime dateDenNgay, string intLoaiBangKe, string strSoKhamBenh, string HoTen, string Nam, string SoDKKBBHYT)
        {
            intLoaiBangKe = intLoaiBangKe.Replace("/BV", "").Replace("/TYT", "");
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * ";
            sql += " , case when  gioitinh = 1  then 'Nam' when  gioitinh = 0  then 'Nữ' else 'Khác' end as GioiTinhFull ";
            sql += " , case when loaibangke  = 1 then '01/BV' when loaibangke = 2  then  '02/BV' when   loaibangke = 3 then '03/TYT' end as LoaiBangKeFull ";
            sql += " , case when tuyenkhambenh  = 1 then 'Đúng Tuyến' when  tuyenkhambenh = 0  then  'Trái Tuyến' when tuyenkhambenh = 2  then  'Cấp cứu' end as TuyenKhamBenhFull ";
            sql += " FROM BangKe Where (LoaiBangKe=@LoaiBangKe or @LoaiBangKe = '') and (NgayQuyetToan between @TuNgay and @DenNgay) ";
            sql += " and (@HoTen = '' or HoTen like '%" + @HoTen + "%') and (@MaKhamChuaBenh = '' or MaKhamChuaBenh = @MaKhamChuaBenh) and (@Nam = '' or NamSinh = @Nam)";
            sql += " and (@SoDKKBBHYT = '' or SoHoSo = @SoDKKBBHYT) order by LoaiBangKe,Khoa ";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@LoaiBangKe", intLoaiBangKe));
            command.Parameters.Add(new SQLiteParameter("@TuNgay", new DateTime(dateTuNgay.Year, dateTuNgay.Month, dateTuNgay.Day)));
            command.Parameters.Add(new SQLiteParameter("@DenNgay", new DateTime(dateDenNgay.Year, dateDenNgay.Month, dateDenNgay.Day)));
            command.Parameters.Add(new SQLiteParameter("@HoTen", HoTen));
            command.Parameters.Add(new SQLiteParameter("@Nam", Nam));
            command.Parameters.Add(new SQLiteParameter("@MaKhamChuaBenh", strSoKhamBenh));
            command.Parameters.Add(new SQLiteParameter("@SoDKKBBHYT", SoDKKBBHYT));

            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }


        public DataTable GetByKey(DateTime dateTuNgay, DateTime dateDenNgay, int intLoaiBangKe)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BangKe Where LoaiBangKe=@LoaiBangKe and (NgayQuyetToan between @TuNgay and @DenNgay) order by BangKe_Id desc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@LoaiBangKe", intLoaiBangKe));
            command.Parameters.Add(new SQLiteParameter("@TuNgay", new DateTime(dateTuNgay.Year, dateTuNgay.Month, dateTuNgay.Day)));
            command.Parameters.Add(new SQLiteParameter("@DenNgay", new DateTime(dateDenNgay.Year, dateDenNgay.Month, dateDenNgay.Day)));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }


        public bool CheckTonTaiMaKhamChuaBenh(string strMaKhamChuaBenh)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BangKe WHERE MaKhamChuaBenh=@MaKhamChuaBenh";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaKhamChuaBenh", strMaKhamChuaBenh));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void GetByMaKhamChuaBenh(string strMaKhamChuaBenh)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BangKe WHERE MaKhamChuaBenh=@MaKhamChuaBenh";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaKhamChuaBenh", strMaKhamChuaBenh));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {

                BangKe_Id = Int32.Parse(dt.Rows[0]["BangKe_Id"].ToString());
                LoaiBangKe = Int32.Parse(dt.Rows[0]["LoaiBangKe"].ToString());
                SoHoSo = dt.Rows[0]["SoHoSo"].ToString();
                Khoa = dt.Rows[0]["Khoa"].ToString();
                MaKhamChuaBenh = dt.Rows[0]["MaKhamChuaBenh"].ToString();
                MaNguoiBenh = dt.Rows[0]["MaNguoiBenh"].ToString();
                HoTen = dt.Rows[0]["HoTen"].ToString();
                GioiTinh = string.IsNullOrEmpty(dt.Rows[0]["GioiTinh"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["GioiTinh"].ToString()); ;
                NgaySinh = string.IsNullOrEmpty(dt.Rows[0]["NgaySinh"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgaySinh"]; ;
                NamSinh = string.IsNullOrEmpty(dt.Rows[0]["NamSinh"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["NamSinh"].ToString()); ;
                DiaChi = dt.Rows[0]["DiaChi"].ToString();
                MaNoiSinhSong = dt.Rows[0]["MaNoiSinhSong"].ToString();
                SoTheBHYT = dt.Rows[0]["SoTheBHYT"].ToString();
                TuNgayBH = string.IsNullOrEmpty(dt.Rows[0]["TuNgayBH"].ToString()) ? null : (DateTime?)dt.Rows[0]["TuNgayBH"]; ;
                DenNgayBH = string.IsNullOrEmpty(dt.Rows[0]["DenNgayBH"].ToString()) ? null : (DateTime?)dt.Rows[0]["DenNgayBH"]; ;
                CoBHYT = string.IsNullOrEmpty(dt.Rows[0]["CoBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["CoBHYT"];
                TreEmKhongTheBHYT = string.IsNullOrEmpty(dt.Rows[0]["TreEmKhongTheBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["TreEmKhongTheBHYT"];
                MucHuong = string.IsNullOrEmpty(dt.Rows[0]["MucHuong"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["MucHuong"].ToString());
                PhanTramDuocHuong = string.IsNullOrEmpty(dt.Rows[0]["PhanTramDuocHuong"].ToString()) ? null : (decimal?)dt.Rows[0]["PhanTramDuocHuong"];
                MaCSKCBBanDau = dt.Rows[0]["MaCSKCBBanDau"].ToString();
                TenCSKCBBanDau = dt.Rows[0]["TenCSKCBBanDau"].ToString();
                MaCSKCB = dt.Rows[0]["MaCSKCB"].ToString();
                MaChiNhanh = dt.Rows[0]["MaChiNhanh"].ToString();
                MaNoiChuyenDen = dt.Rows[0]["MaNoiChuyenDen"].ToString();
                TenNoiChuyenDen = dt.Rows[0]["TenNoiChuyenDen"].ToString();
                NgayDenKham = string.IsNullOrEmpty(dt.Rows[0]["NgayDenKham"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayDenKham"]; ;
                NgayKetThuc = string.IsNullOrEmpty(dt.Rows[0]["NgayKetThuc"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayKetThuc"]; ;
                SoNgayDieuTri = string.IsNullOrEmpty(dt.Rows[0]["SoNgayDieuTri"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["SoNgayDieuTri"].ToString());
                NgayQuyetToan = string.IsNullOrEmpty(dt.Rows[0]["NgayQuyetToan"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayQuyetToan"];
                TuyenKhamBenh = string.IsNullOrEmpty(dt.Rows[0]["TuyenKhamBenh"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["TuyenKhamBenh"].ToString());
                ChanDoan = dt.Rows[0]["ChanDoan"].ToString();
                BenhKhac = dt.Rows[0]["BenhKhac"].ToString();
                MaICD = dt.Rows[0]["MaICD"].ToString();
                TongChiPhi = string.IsNullOrEmpty(dt.Rows[0]["TongChiPhi"].ToString()) ? null : (decimal?)dt.Rows[0]["TongChiPhi"];
                BHYTThanhToan = string.IsNullOrEmpty(dt.Rows[0]["BHYTThanhToan"].ToString()) ? null : (decimal?)dt.Rows[0]["BHYTThanhToan"];
                NguoiBenhTra = string.IsNullOrEmpty(dt.Rows[0]["NguoiBenhTra"].ToString()) ? null : (decimal?)dt.Rows[0]["NguoiBenhTra"];
                NguonKhac = string.IsNullOrEmpty(dt.Rows[0]["NguonKhac"].ToString()) ? null : (decimal?)dt.Rows[0]["NguonKhac"];
                SoTienThanhToanToiDa = string.IsNullOrEmpty(dt.Rows[0]["SoTienThanhToanToiDa"].ToString()) ? null : (decimal?)dt.Rows[0]["SoTienThanhToanToiDa"];
                TienKham = string.IsNullOrEmpty(dt.Rows[0]["TienKham"].ToString()) ? null : (decimal?)dt.Rows[0]["TienKham"];
                TienGiuong = string.IsNullOrEmpty(dt.Rows[0]["TienGiuong"].ToString()) ? null : (decimal?)dt.Rows[0]["TienGiuong"];
                TienXN = string.IsNullOrEmpty(dt.Rows[0]["TienXN"].ToString()) ? null : (decimal?)dt.Rows[0]["TienXN"];
                TienCDHA = string.IsNullOrEmpty(dt.Rows[0]["TienCDHA"].ToString()) ? null : (decimal?)dt.Rows[0]["TienCDHA"];
                TienTDCN = string.IsNullOrEmpty(dt.Rows[0]["TienTDCN"].ToString()) ? null : (decimal?)dt.Rows[0]["TienTDCN"];
                TienPTTT = string.IsNullOrEmpty(dt.Rows[0]["TienPTTT"].ToString()) ? null : (decimal?)dt.Rows[0]["TienPTTT"];
                TienDichVuKTC = string.IsNullOrEmpty(dt.Rows[0]["TienDichVuKTC"].ToString()) ? null : (decimal?)dt.Rows[0]["TienDichVuKTC"];
                TienMau = string.IsNullOrEmpty(dt.Rows[0]["TienMau"].ToString()) ? null : (decimal?)dt.Rows[0]["TienMau"];
                TienThuoc = string.IsNullOrEmpty(dt.Rows[0]["TienThuoc"].ToString()) ? null : (decimal?)dt.Rows[0]["TienThuoc"];
                TienVTYT = string.IsNullOrEmpty(dt.Rows[0]["TienVTYT"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVTYT"];
                TienVTYTTH = string.IsNullOrEmpty(dt.Rows[0]["TienVTYTTH"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVTYTTH"];
                TienVTYTTT = string.IsNullOrEmpty(dt.Rows[0]["TienVTYTTT"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVTYTTT"];
                TienVanChuyen = string.IsNullOrEmpty(dt.Rows[0]["TienVanChuyen"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVanChuyen"];
                DVKTC_TinhToan = string.IsNullOrEmpty(dt.Rows[0]["DVKTC_TinhToan"].ToString()) ? null : (decimal?)dt.Rows[0]["DVKTC_TinhToan"];
                DVKTC_ThanhToan = string.IsNullOrEmpty(dt.Rows[0]["DVKTC_ThanhToan"].ToString()) ? null : (decimal?)dt.Rows[0]["DVKTC_ThanhToan"];
                ChiPhiNgoaiDinhSuat = string.IsNullOrEmpty(dt.Rows[0]["ChiPhiNgoaiDinhSuat"].ToString()) ? null : (decimal?)dt.Rows[0]["ChiPhiNgoaiDinhSuat"];
                DaGuiBHYT = string.IsNullOrEmpty(dt.Rows[0]["DaGuiBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["DaGuiBHYT"];
                NgayGuiBHYT = string.IsNullOrEmpty(dt.Rows[0]["NgayGuiBHYT"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayGuiBHYT"]; ;
                NguoiGuiBHYT = dt.Rows[0]["NguoiGuiBHYT"].ToString();
                NgayTao = string.IsNullOrEmpty(dt.Rows[0]["NgayTao"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayTao"]; ;
                NguoiTao = dt.Rows[0]["NguoiTao"].ToString();
                NgayCapNhat = string.IsNullOrEmpty(dt.Rows[0]["NgayCapNhat"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayCapNhat"]; ;
                NguoiCapNhat = dt.Rows[0]["NguoiCapNhat"].ToString();
                ChungNhanKhongCCT = string.IsNullOrEmpty(dt.Rows[0]["ChungNhanKhongCCT"].ToString()) ? null : (bool?)dt.Rows[0]["ChungNhanKhongCCT"];
                BangKe_Id_BHXH = string.IsNullOrEmpty(dt.Rows[0]["BangKe_Id_BHXH"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["BangKe_Id_BHXH"].ToString());

            }
        }

        public void GetByKey(int intBangKe_Id)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BangKe WHERE BangKe_Id=@BangKe_Id";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", intBangKe_Id));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {

                BangKe_Id = Int32.Parse(dt.Rows[0]["BangKe_Id"].ToString());
                LoaiBangKe = Int32.Parse(dt.Rows[0]["LoaiBangKe"].ToString());
                SoHoSo = dt.Rows[0]["SoHoSo"].ToString();
                Khoa = dt.Rows[0]["Khoa"].ToString();
                MaKhamChuaBenh = dt.Rows[0]["MaKhamChuaBenh"].ToString();
                MaNguoiBenh = dt.Rows[0]["MaNguoiBenh"].ToString();
                HoTen = dt.Rows[0]["HoTen"].ToString();
                GioiTinh = string.IsNullOrEmpty(dt.Rows[0]["GioiTinh"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["GioiTinh"].ToString()); ;
                NgaySinh = string.IsNullOrEmpty(dt.Rows[0]["NgaySinh"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgaySinh"]; ;
                NamSinh = string.IsNullOrEmpty(dt.Rows[0]["NamSinh"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["NamSinh"].ToString()); ;
                DiaChi = dt.Rows[0]["DiaChi"].ToString();
                MaNoiSinhSong = dt.Rows[0]["MaNoiSinhSong"].ToString();
                SoTheBHYT = dt.Rows[0]["SoTheBHYT"].ToString();
                TuNgayBH = string.IsNullOrEmpty(dt.Rows[0]["TuNgayBH"].ToString()) ? null : (DateTime?)dt.Rows[0]["TuNgayBH"]; ;
                DenNgayBH = string.IsNullOrEmpty(dt.Rows[0]["DenNgayBH"].ToString()) ? null : (DateTime?)dt.Rows[0]["DenNgayBH"]; ;
                CoBHYT = string.IsNullOrEmpty(dt.Rows[0]["CoBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["CoBHYT"];
                TreEmKhongTheBHYT = string.IsNullOrEmpty(dt.Rows[0]["TreEmKhongTheBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["TreEmKhongTheBHYT"];
                MucHuong = string.IsNullOrEmpty(dt.Rows[0]["MucHuong"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["MucHuong"].ToString());
                PhanTramDuocHuong = string.IsNullOrEmpty(dt.Rows[0]["PhanTramDuocHuong"].ToString()) ? null : (decimal?)dt.Rows[0]["PhanTramDuocHuong"];
                MaCSKCBBanDau = dt.Rows[0]["MaCSKCBBanDau"].ToString();
                TenCSKCBBanDau = dt.Rows[0]["TenCSKCBBanDau"].ToString();
                MaCSKCB = dt.Rows[0]["MaCSKCB"].ToString();
                MaChiNhanh = dt.Rows[0]["MaChiNhanh"].ToString();
                MaNoiChuyenDen = dt.Rows[0]["MaNoiChuyenDen"].ToString();
                TenNoiChuyenDen = dt.Rows[0]["TenNoiChuyenDen"].ToString();
                NgayDenKham = string.IsNullOrEmpty(dt.Rows[0]["NgayDenKham"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayDenKham"]; ;
                NgayKetThuc = string.IsNullOrEmpty(dt.Rows[0]["NgayKetThuc"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayKetThuc"]; ;
                SoNgayDieuTri = string.IsNullOrEmpty(dt.Rows[0]["SoNgayDieuTri"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["SoNgayDieuTri"].ToString());
                NgayQuyetToan = string.IsNullOrEmpty(dt.Rows[0]["NgayQuyetToan"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayQuyetToan"];
                TuyenKhamBenh = string.IsNullOrEmpty(dt.Rows[0]["TuyenKhamBenh"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["TuyenKhamBenh"].ToString());
                ChanDoan = dt.Rows[0]["ChanDoan"].ToString();
                BenhKhac = dt.Rows[0]["BenhKhac"].ToString();
                MaICD = dt.Rows[0]["MaICD"].ToString();
                TongChiPhi = string.IsNullOrEmpty(dt.Rows[0]["TongChiPhi"].ToString()) ? null : (decimal?)dt.Rows[0]["TongChiPhi"];
                BHYTThanhToan = string.IsNullOrEmpty(dt.Rows[0]["BHYTThanhToan"].ToString()) ? null : (decimal?)dt.Rows[0]["BHYTThanhToan"];
                NguoiBenhTra = string.IsNullOrEmpty(dt.Rows[0]["NguoiBenhTra"].ToString()) ? null : (decimal?)dt.Rows[0]["NguoiBenhTra"];
                NguonKhac = string.IsNullOrEmpty(dt.Rows[0]["NguonKhac"].ToString()) ? null : (decimal?)dt.Rows[0]["NguonKhac"];
                SoTienThanhToanToiDa = string.IsNullOrEmpty(dt.Rows[0]["SoTienThanhToanToiDa"].ToString()) ? null : (decimal?)dt.Rows[0]["SoTienThanhToanToiDa"];
                TienKham = string.IsNullOrEmpty(dt.Rows[0]["TienKham"].ToString()) ? null : (decimal?)dt.Rows[0]["TienKham"];
                TienGiuong = string.IsNullOrEmpty(dt.Rows[0]["TienGiuong"].ToString()) ? null : (decimal?)dt.Rows[0]["TienGiuong"];
                TienXN = string.IsNullOrEmpty(dt.Rows[0]["TienXN"].ToString()) ? null : (decimal?)dt.Rows[0]["TienXN"];
                TienCDHA = string.IsNullOrEmpty(dt.Rows[0]["TienCDHA"].ToString()) ? null : (decimal?)dt.Rows[0]["TienCDHA"];
                TienTDCN = string.IsNullOrEmpty(dt.Rows[0]["TienTDCN"].ToString()) ? null : (decimal?)dt.Rows[0]["TienTDCN"];
                TienPTTT = string.IsNullOrEmpty(dt.Rows[0]["TienPTTT"].ToString()) ? null : (decimal?)dt.Rows[0]["TienPTTT"];
                TienDichVuKTC = string.IsNullOrEmpty(dt.Rows[0]["TienDichVuKTC"].ToString()) ? null : (decimal?)dt.Rows[0]["TienDichVuKTC"];
                TienMau = string.IsNullOrEmpty(dt.Rows[0]["TienMau"].ToString()) ? null : (decimal?)dt.Rows[0]["TienMau"];
                TienThuoc = string.IsNullOrEmpty(dt.Rows[0]["TienThuoc"].ToString()) ? null : (decimal?)dt.Rows[0]["TienThuoc"];
                TienVTYT = string.IsNullOrEmpty(dt.Rows[0]["TienVTYT"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVTYT"];
                TienVTYTTH = string.IsNullOrEmpty(dt.Rows[0]["TienVTYTTH"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVTYTTH"];
                TienVTYTTT = string.IsNullOrEmpty(dt.Rows[0]["TienVTYTTT"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVTYTTT"];
                TienVanChuyen = string.IsNullOrEmpty(dt.Rows[0]["TienVanChuyen"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVanChuyen"];
                DVKTC_TinhToan = string.IsNullOrEmpty(dt.Rows[0]["DVKTC_TinhToan"].ToString()) ? null : (decimal?)dt.Rows[0]["DVKTC_TinhToan"];
                DVKTC_ThanhToan = string.IsNullOrEmpty(dt.Rows[0]["DVKTC_ThanhToan"].ToString()) ? null : (decimal?)dt.Rows[0]["DVKTC_ThanhToan"];
                ChiPhiNgoaiDinhSuat = string.IsNullOrEmpty(dt.Rows[0]["ChiPhiNgoaiDinhSuat"].ToString()) ? null : (decimal?)dt.Rows[0]["ChiPhiNgoaiDinhSuat"];
                DaGuiBHYT = string.IsNullOrEmpty(dt.Rows[0]["DaGuiBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["DaGuiBHYT"];
                NgayGuiBHYT = string.IsNullOrEmpty(dt.Rows[0]["NgayGuiBHYT"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayGuiBHYT"]; ;
                NguoiGuiBHYT = dt.Rows[0]["NguoiGuiBHYT"].ToString();
                NgayTao = string.IsNullOrEmpty(dt.Rows[0]["NgayTao"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayTao"]; ;
                NguoiTao = dt.Rows[0]["NguoiTao"].ToString();
                NgayCapNhat = string.IsNullOrEmpty(dt.Rows[0]["NgayCapNhat"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayCapNhat"]; ;
                NguoiCapNhat = dt.Rows[0]["NguoiCapNhat"].ToString();
                ChungNhanKhongCCT = string.IsNullOrEmpty(dt.Rows[0]["ChungNhanKhongCCT"].ToString()) ? null : (bool?)dt.Rows[0]["ChungNhanKhongCCT"];
                BangKe_Id_BHXH = string.IsNullOrEmpty(dt.Rows[0]["BangKe_Id_BHXH"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["BangKe_Id_BHXH"].ToString());

            }
        }

        public bool CheckHoSo(string soHoSo)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT SoHoSo   FROM BangKe WHERE SoHoSo=@SoHoSo order by BangKe_ID desc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@SoHoSo", soHoSo));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                return true;
            } return false;

        }
        public void GetByKey(string strSoTheBHYT)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BangKe WHERE SoTheBHYT=@SoTheBHYT order by BangKe_ID desc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@SoTheBHYT", strSoTheBHYT));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {

                BangKe_Id = Int32.Parse(dt.Rows[0]["BangKe_Id"].ToString());
                LoaiBangKe = Int32.Parse(dt.Rows[0]["LoaiBangKe"].ToString());
                SoHoSo = dt.Rows[0]["SoHoSo"].ToString();
                Khoa = dt.Rows[0]["Khoa"].ToString();
                MaKhamChuaBenh = dt.Rows[0]["MaKhamChuaBenh"].ToString();
                MaNguoiBenh = dt.Rows[0]["MaNguoiBenh"].ToString();
                HoTen = dt.Rows[0]["HoTen"].ToString();
                GioiTinh = string.IsNullOrEmpty(dt.Rows[0]["GioiTinh"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["GioiTinh"].ToString()); ;
                NgaySinh = string.IsNullOrEmpty(dt.Rows[0]["NgaySinh"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgaySinh"]; ;
                NamSinh = string.IsNullOrEmpty(dt.Rows[0]["NamSinh"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["NamSinh"].ToString()); ;
                DiaChi = dt.Rows[0]["DiaChi"].ToString();
                MaNoiSinhSong = dt.Rows[0]["MaNoiSinhSong"].ToString();
                SoTheBHYT = dt.Rows[0]["SoTheBHYT"].ToString();
                TuNgayBH = string.IsNullOrEmpty(dt.Rows[0]["TuNgayBH"].ToString()) ? null : (DateTime?)dt.Rows[0]["TuNgayBH"]; ;
                DenNgayBH = string.IsNullOrEmpty(dt.Rows[0]["DenNgayBH"].ToString()) ? null : (DateTime?)dt.Rows[0]["DenNgayBH"]; ;
                CoBHYT = string.IsNullOrEmpty(dt.Rows[0]["CoBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["CoBHYT"];
                TreEmKhongTheBHYT = string.IsNullOrEmpty(dt.Rows[0]["TreEmKhongTheBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["TreEmKhongTheBHYT"];
                MucHuong = string.IsNullOrEmpty(dt.Rows[0]["MucHuong"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["MucHuong"].ToString());
                PhanTramDuocHuong = string.IsNullOrEmpty(dt.Rows[0]["PhanTramDuocHuong"].ToString()) ? null : (decimal?)dt.Rows[0]["PhanTramDuocHuong"];
                MaCSKCBBanDau = dt.Rows[0]["MaCSKCBBanDau"].ToString();
                TenCSKCBBanDau = dt.Rows[0]["TenCSKCBBanDau"].ToString();
                MaCSKCB = dt.Rows[0]["MaCSKCB"].ToString();
                MaChiNhanh = dt.Rows[0]["MaChiNhanh"].ToString();
                MaNoiChuyenDen = dt.Rows[0]["MaNoiChuyenDen"].ToString();
                TenNoiChuyenDen = dt.Rows[0]["TenNoiChuyenDen"].ToString();
                NgayDenKham = string.IsNullOrEmpty(dt.Rows[0]["NgayDenKham"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayDenKham"]; ;
                NgayKetThuc = string.IsNullOrEmpty(dt.Rows[0]["NgayKetThuc"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayKetThuc"]; ;
                SoNgayDieuTri = string.IsNullOrEmpty(dt.Rows[0]["SoNgayDieuTri"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["SoNgayDieuTri"].ToString());
                NgayQuyetToan = string.IsNullOrEmpty(dt.Rows[0]["NgayQuyetToan"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayQuyetToan"];
                TuyenKhamBenh = string.IsNullOrEmpty(dt.Rows[0]["TuyenKhamBenh"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["TuyenKhamBenh"].ToString());
                ChanDoan = dt.Rows[0]["ChanDoan"].ToString();
                BenhKhac = dt.Rows[0]["BenhKhac"].ToString();
                MaICD = dt.Rows[0]["MaICD"].ToString();
                TongChiPhi = string.IsNullOrEmpty(dt.Rows[0]["TongChiPhi"].ToString()) ? null : (decimal?)dt.Rows[0]["TongChiPhi"];
                BHYTThanhToan = string.IsNullOrEmpty(dt.Rows[0]["BHYTThanhToan"].ToString()) ? null : (decimal?)dt.Rows[0]["BHYTThanhToan"];
                NguoiBenhTra = string.IsNullOrEmpty(dt.Rows[0]["NguoiBenhTra"].ToString()) ? null : (decimal?)dt.Rows[0]["NguoiBenhTra"];
                NguonKhac = string.IsNullOrEmpty(dt.Rows[0]["NguonKhac"].ToString()) ? null : (decimal?)dt.Rows[0]["NguonKhac"];
                SoTienThanhToanToiDa = string.IsNullOrEmpty(dt.Rows[0]["SoTienThanhToanToiDa"].ToString()) ? null : (decimal?)dt.Rows[0]["SoTienThanhToanToiDa"];
                TienKham = string.IsNullOrEmpty(dt.Rows[0]["TienKham"].ToString()) ? null : (decimal?)dt.Rows[0]["TienKham"];
                TienGiuong = string.IsNullOrEmpty(dt.Rows[0]["TienGiuong"].ToString()) ? null : (decimal?)dt.Rows[0]["TienGiuong"];
                TienXN = string.IsNullOrEmpty(dt.Rows[0]["TienXN"].ToString()) ? null : (decimal?)dt.Rows[0]["TienXN"];
                TienCDHA = string.IsNullOrEmpty(dt.Rows[0]["TienCDHA"].ToString()) ? null : (decimal?)dt.Rows[0]["TienCDHA"];
                TienTDCN = string.IsNullOrEmpty(dt.Rows[0]["TienTDCN"].ToString()) ? null : (decimal?)dt.Rows[0]["TienTDCN"];
                TienPTTT = string.IsNullOrEmpty(dt.Rows[0]["TienPTTT"].ToString()) ? null : (decimal?)dt.Rows[0]["TienPTTT"];
                TienDichVuKTC = string.IsNullOrEmpty(dt.Rows[0]["TienDichVuKTC"].ToString()) ? null : (decimal?)dt.Rows[0]["TienDichVuKTC"];
                TienMau = string.IsNullOrEmpty(dt.Rows[0]["TienMau"].ToString()) ? null : (decimal?)dt.Rows[0]["TienMau"];
                TienThuoc = string.IsNullOrEmpty(dt.Rows[0]["TienThuoc"].ToString()) ? null : (decimal?)dt.Rows[0]["TienThuoc"];
                TienVTYT = string.IsNullOrEmpty(dt.Rows[0]["TienVTYT"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVTYT"];
                TienVTYTTH = string.IsNullOrEmpty(dt.Rows[0]["TienVTYTTH"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVTYTTH"];
                TienVTYTTT = string.IsNullOrEmpty(dt.Rows[0]["TienVTYTTT"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVTYTTT"];
                TienVanChuyen = string.IsNullOrEmpty(dt.Rows[0]["TienVanChuyen"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVanChuyen"];
                DVKTC_TinhToan = string.IsNullOrEmpty(dt.Rows[0]["DVKTC_TinhToan"].ToString()) ? null : (decimal?)dt.Rows[0]["DVKTC_TinhToan"];
                DVKTC_ThanhToan = string.IsNullOrEmpty(dt.Rows[0]["DVKTC_ThanhToan"].ToString()) ? null : (decimal?)dt.Rows[0]["DVKTC_ThanhToan"];
                ChiPhiNgoaiDinhSuat = string.IsNullOrEmpty(dt.Rows[0]["ChiPhiNgoaiDinhSuat"].ToString()) ? null : (decimal?)dt.Rows[0]["ChiPhiNgoaiDinhSuat"];
                DaGuiBHYT = string.IsNullOrEmpty(dt.Rows[0]["DaGuiBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["DaGuiBHYT"];
                NgayGuiBHYT = string.IsNullOrEmpty(dt.Rows[0]["NgayGuiBHYT"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayGuiBHYT"]; ;
                NguoiGuiBHYT = dt.Rows[0]["NguoiGuiBHYT"].ToString();
                NgayTao = string.IsNullOrEmpty(dt.Rows[0]["NgayTao"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayTao"]; ;
                NguoiTao = dt.Rows[0]["NguoiTao"].ToString();
                NgayCapNhat = string.IsNullOrEmpty(dt.Rows[0]["NgayCapNhat"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayCapNhat"]; ;
                NguoiCapNhat = dt.Rows[0]["NguoiCapNhat"].ToString();
                ChungNhanKhongCCT = string.IsNullOrEmpty(dt.Rows[0]["ChungNhanKhongCCT"].ToString()) ? null : (bool?)dt.Rows[0]["ChungNhanKhongCCT"];
                BangKe_Id_BHXH = string.IsNullOrEmpty(dt.Rows[0]["BangKe_Id_BHXH"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["BangKe_Id_BHXH"].ToString());

            }
        }


        public void GetBySoDK(string strSoDK)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BangKe WHERE SoHoSo=@SoHoSo order by BangKe_ID desc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@SoHoSo", strSoDK));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {

                BangKe_Id = Int32.Parse(dt.Rows[0]["BangKe_Id"].ToString());
                LoaiBangKe = Int32.Parse(dt.Rows[0]["LoaiBangKe"].ToString());
                SoHoSo = dt.Rows[0]["SoHoSo"].ToString();
                Khoa = dt.Rows[0]["Khoa"].ToString();
                MaKhamChuaBenh = dt.Rows[0]["MaKhamChuaBenh"].ToString();
                MaNguoiBenh = dt.Rows[0]["MaNguoiBenh"].ToString();
                HoTen = dt.Rows[0]["HoTen"].ToString();
                GioiTinh = string.IsNullOrEmpty(dt.Rows[0]["GioiTinh"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["GioiTinh"].ToString()); ;
                NgaySinh = string.IsNullOrEmpty(dt.Rows[0]["NgaySinh"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgaySinh"]; ;
                NamSinh = string.IsNullOrEmpty(dt.Rows[0]["NamSinh"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["NamSinh"].ToString()); ;
                DiaChi = dt.Rows[0]["DiaChi"].ToString();
                MaNoiSinhSong = dt.Rows[0]["MaNoiSinhSong"].ToString();
                SoTheBHYT = dt.Rows[0]["SoTheBHYT"].ToString();
                TuNgayBH = string.IsNullOrEmpty(dt.Rows[0]["TuNgayBH"].ToString()) ? null : (DateTime?)dt.Rows[0]["TuNgayBH"]; ;
                DenNgayBH = string.IsNullOrEmpty(dt.Rows[0]["DenNgayBH"].ToString()) ? null : (DateTime?)dt.Rows[0]["DenNgayBH"]; ;
                CoBHYT = string.IsNullOrEmpty(dt.Rows[0]["CoBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["CoBHYT"];
                TreEmKhongTheBHYT = string.IsNullOrEmpty(dt.Rows[0]["TreEmKhongTheBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["TreEmKhongTheBHYT"];
                MucHuong = string.IsNullOrEmpty(dt.Rows[0]["MucHuong"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["MucHuong"].ToString());
                PhanTramDuocHuong = string.IsNullOrEmpty(dt.Rows[0]["PhanTramDuocHuong"].ToString()) ? null : (decimal?)dt.Rows[0]["PhanTramDuocHuong"];
                MaCSKCBBanDau = dt.Rows[0]["MaCSKCBBanDau"].ToString();
                TenCSKCBBanDau = dt.Rows[0]["TenCSKCBBanDau"].ToString();
                MaCSKCB = dt.Rows[0]["MaCSKCB"].ToString();
                MaChiNhanh = dt.Rows[0]["MaChiNhanh"].ToString();
                MaNoiChuyenDen = dt.Rows[0]["MaNoiChuyenDen"].ToString();
                TenNoiChuyenDen = dt.Rows[0]["TenNoiChuyenDen"].ToString();
                NgayDenKham = string.IsNullOrEmpty(dt.Rows[0]["NgayDenKham"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayDenKham"]; ;
                NgayKetThuc = string.IsNullOrEmpty(dt.Rows[0]["NgayKetThuc"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayKetThuc"]; ;
                SoNgayDieuTri = string.IsNullOrEmpty(dt.Rows[0]["SoNgayDieuTri"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["SoNgayDieuTri"].ToString());
                NgayQuyetToan = string.IsNullOrEmpty(dt.Rows[0]["NgayQuyetToan"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayQuyetToan"];
                TuyenKhamBenh = string.IsNullOrEmpty(dt.Rows[0]["TuyenKhamBenh"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["TuyenKhamBenh"].ToString());
                ChanDoan = dt.Rows[0]["ChanDoan"].ToString();
                BenhKhac = dt.Rows[0]["BenhKhac"].ToString();
                MaICD = dt.Rows[0]["MaICD"].ToString();
                TongChiPhi = string.IsNullOrEmpty(dt.Rows[0]["TongChiPhi"].ToString()) ? null : (decimal?)dt.Rows[0]["TongChiPhi"];
                BHYTThanhToan = string.IsNullOrEmpty(dt.Rows[0]["BHYTThanhToan"].ToString()) ? null : (decimal?)dt.Rows[0]["BHYTThanhToan"];
                NguoiBenhTra = string.IsNullOrEmpty(dt.Rows[0]["NguoiBenhTra"].ToString()) ? null : (decimal?)dt.Rows[0]["NguoiBenhTra"];
                NguonKhac = string.IsNullOrEmpty(dt.Rows[0]["NguonKhac"].ToString()) ? null : (decimal?)dt.Rows[0]["NguonKhac"];
                SoTienThanhToanToiDa = string.IsNullOrEmpty(dt.Rows[0]["SoTienThanhToanToiDa"].ToString()) ? null : (decimal?)dt.Rows[0]["SoTienThanhToanToiDa"];
                TienKham = string.IsNullOrEmpty(dt.Rows[0]["TienKham"].ToString()) ? null : (decimal?)dt.Rows[0]["TienKham"];
                TienGiuong = string.IsNullOrEmpty(dt.Rows[0]["TienGiuong"].ToString()) ? null : (decimal?)dt.Rows[0]["TienGiuong"];
                TienXN = string.IsNullOrEmpty(dt.Rows[0]["TienXN"].ToString()) ? null : (decimal?)dt.Rows[0]["TienXN"];
                TienCDHA = string.IsNullOrEmpty(dt.Rows[0]["TienCDHA"].ToString()) ? null : (decimal?)dt.Rows[0]["TienCDHA"];
                TienTDCN = string.IsNullOrEmpty(dt.Rows[0]["TienTDCN"].ToString()) ? null : (decimal?)dt.Rows[0]["TienTDCN"];
                TienPTTT = string.IsNullOrEmpty(dt.Rows[0]["TienPTTT"].ToString()) ? null : (decimal?)dt.Rows[0]["TienPTTT"];
                TienDichVuKTC = string.IsNullOrEmpty(dt.Rows[0]["TienDichVuKTC"].ToString()) ? null : (decimal?)dt.Rows[0]["TienDichVuKTC"];
                TienMau = string.IsNullOrEmpty(dt.Rows[0]["TienMau"].ToString()) ? null : (decimal?)dt.Rows[0]["TienMau"];
                TienThuoc = string.IsNullOrEmpty(dt.Rows[0]["TienThuoc"].ToString()) ? null : (decimal?)dt.Rows[0]["TienThuoc"];
                TienVTYT = string.IsNullOrEmpty(dt.Rows[0]["TienVTYT"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVTYT"];
                TienVTYTTH = string.IsNullOrEmpty(dt.Rows[0]["TienVTYTTH"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVTYTTH"];
                TienVTYTTT = string.IsNullOrEmpty(dt.Rows[0]["TienVTYTTT"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVTYTTT"];
                TienVanChuyen = string.IsNullOrEmpty(dt.Rows[0]["TienVanChuyen"].ToString()) ? null : (decimal?)dt.Rows[0]["TienVanChuyen"];
                DVKTC_TinhToan = string.IsNullOrEmpty(dt.Rows[0]["DVKTC_TinhToan"].ToString()) ? null : (decimal?)dt.Rows[0]["DVKTC_TinhToan"];
                DVKTC_ThanhToan = string.IsNullOrEmpty(dt.Rows[0]["DVKTC_ThanhToan"].ToString()) ? null : (decimal?)dt.Rows[0]["DVKTC_ThanhToan"];
                ChiPhiNgoaiDinhSuat = string.IsNullOrEmpty(dt.Rows[0]["ChiPhiNgoaiDinhSuat"].ToString()) ? null : (decimal?)dt.Rows[0]["ChiPhiNgoaiDinhSuat"];
                DaGuiBHYT = string.IsNullOrEmpty(dt.Rows[0]["DaGuiBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["DaGuiBHYT"];
                NgayGuiBHYT = string.IsNullOrEmpty(dt.Rows[0]["NgayGuiBHYT"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayGuiBHYT"]; ;
                NguoiGuiBHYT = dt.Rows[0]["NguoiGuiBHYT"].ToString();
                NgayTao = string.IsNullOrEmpty(dt.Rows[0]["NgayTao"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayTao"]; ;
                NguoiTao = dt.Rows[0]["NguoiTao"].ToString();
                NgayCapNhat = string.IsNullOrEmpty(dt.Rows[0]["NgayCapNhat"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayCapNhat"]; ;
                NguoiCapNhat = dt.Rows[0]["NguoiCapNhat"].ToString();
                ChungNhanKhongCCT = string.IsNullOrEmpty(dt.Rows[0]["ChungNhanKhongCCT"].ToString()) ? null : (bool?)dt.Rows[0]["ChungNhanKhongCCT"];
                BangKe_Id_BHXH = string.IsNullOrEmpty(dt.Rows[0]["BangKe_Id_BHXH"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["BangKe_Id_BHXH"].ToString());

            }
        }


        /// <summary>
        /// Hàm Insert Trans
        /// </summary>
        /// <param name="DAL"></param>
        /// <returns></returns>

        public int Insert(SQLiteDAL DAL)
        {
            string sql = "";
            sql += "INSERT INTO BangKe (LoaiBangKe,SoHoSo,Khoa,MaKhamChuaBenh,MaNguoiBenh,HoTen,GioiTinh,NgaySinh,NamSinh,DiaChi,MaNoiSinhSong,SoTheBHYT,TuNgayBH,DenNgayBH,CoBHYT,TreEmKhongTheBHYT,MucHuong,PhanTramDuocHuong,MaCSKCBBanDau,TenCSKCBBanDau,MaCSKCB,MaChiNhanh,MaNoiChuyenDen,TenNoiChuyenDen,NgayDenKham,NgayKetThuc,SoNgayDieuTri,NgayQuyetToan,TuyenKhamBenh,ChanDoan,BenhKhac,MaICD,TongChiPhi,BHYTThanhToan,NguoiBenhTra,NguonKhac,SoTienThanhToanToiDa,TienKham,TienGiuong,TienXN,TienCDHA,TienTDCN,TienPTTT,TienDichVuKTC,TienMau,TienThuoc,TienVTYT,TienVTYTTH,TienVTYTTT,TienVanChuyen,DVKTC_TinhToan,DVKTC_ThanhToan,ChiPhiNgoaiDinhSuat,DaGuiBHYT,NgayGuiBHYT,NguoiGuiBHYT,NgayTao,NguoiTao,NgayCapNhat,NguoiCapNhat,ChungNhanKhongCCT,BangKe_Id_BHXH) ";
            sql += "VALUES(@LoaiBangKe,@SoHoSo,@Khoa,@MaKhamChuaBenh,@MaNguoiBenh,@HoTen,@GioiTinh,@NgaySinh,@NamSinh,@DiaChi,@MaNoiSinhSong,@SoTheBHYT,@TuNgayBH,@DenNgayBH,@CoBHYT,@TreEmKhongTheBHYT,@MucHuong,@PhanTramDuocHuong,@MaCSKCBBanDau,@TenCSKCBBanDau,@MaCSKCB,@MaChiNhanh,@MaNoiChuyenDen,@TenNoiChuyenDen,@NgayDenKham,@NgayKetThuc,@SoNgayDieuTri,@NgayQuyetToan,@TuyenKhamBenh,@ChanDoan,@BenhKhac,@MaICD,@TongChiPhi,@BHYTThanhToan,@NguoiBenhTra,@NguonKhac,@SoTienThanhToanToiDa,@TienKham,@TienGiuong,@TienXN,@TienCDHA,@TienTDCN,@TienPTTT,@TienDichVuKTC,@TienMau,@TienThuoc,@TienVTYT,@TienVTYTTH,@TienVTYTTT,@TienVanChuyen,@DVKTC_TinhToan,@DVKTC_ThanhToan,@ChiPhiNgoaiDinhSuat,@DaGuiBHYT,@NgayGuiBHYT,@NguoiGuiBHYT,@NgayTao,@NguoiTao,@NgayCapNhat,@NguoiCapNhat,@ChungNhanKhongCCT,@BangKe_Id_BHXH);";
            sql += " SELECT last_insert_rowid(); ";
            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            //command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
            command.Parameters.Add(new SQLiteParameter("@LoaiBangKe", LoaiBangKe));
            command.Parameters.Add(new SQLiteParameter("@SoHoSo", SoHoSo));
            command.Parameters.Add(new SQLiteParameter("@Khoa", Khoa));
            command.Parameters.Add(new SQLiteParameter("@MaKhamChuaBenh", MaKhamChuaBenh));
            command.Parameters.Add(new SQLiteParameter("@MaNguoiBenh", MaNguoiBenh));
            command.Parameters.Add(new SQLiteParameter("@HoTen", HoTen));
            command.Parameters.Add(new SQLiteParameter("@GioiTinh", GioiTinh));
            command.Parameters.Add(new SQLiteParameter("@NgaySinh", NgaySinh));
            command.Parameters.Add(new SQLiteParameter("@NamSinh", NamSinh));
            command.Parameters.Add(new SQLiteParameter("@DiaChi", DiaChi));
            command.Parameters.Add(new SQLiteParameter("@MaNoiSinhSong", MaNoiSinhSong));
            command.Parameters.Add(new SQLiteParameter("@SoTheBHYT", SoTheBHYT));
            command.Parameters.Add(new SQLiteParameter("@TuNgayBH", TuNgayBH));
            command.Parameters.Add(new SQLiteParameter("@DenNgayBH", DenNgayBH));
            command.Parameters.Add(new SQLiteParameter("@CoBHYT", CoBHYT));
            command.Parameters.Add(new SQLiteParameter("@TreEmKhongTheBHYT", TreEmKhongTheBHYT));
            command.Parameters.Add(new SQLiteParameter("@MucHuong", MucHuong));
            command.Parameters.Add(new SQLiteParameter("@PhanTramDuocHuong", PhanTramDuocHuong));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCBBanDau", MaCSKCBBanDau));
            command.Parameters.Add(new SQLiteParameter("@TenCSKCBBanDau", TenCSKCBBanDau));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", MaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaChiNhanh", MaChiNhanh));
            command.Parameters.Add(new SQLiteParameter("@MaNoiChuyenDen", MaNoiChuyenDen));
            command.Parameters.Add(new SQLiteParameter("@TenNoiChuyenDen", TenNoiChuyenDen));
            command.Parameters.Add(new SQLiteParameter("@NgayDenKham", NgayDenKham));
            command.Parameters.Add(new SQLiteParameter("@NgayKetThuc", NgayKetThuc));
            command.Parameters.Add(new SQLiteParameter("@SoNgayDieuTri", SoNgayDieuTri));
            command.Parameters.Add(new SQLiteParameter("@NgayQuyetToan", NgayQuyetToan));
            command.Parameters.Add(new SQLiteParameter("@TuyenKhamBenh", TuyenKhamBenh));
            command.Parameters.Add(new SQLiteParameter("@ChanDoan", ChanDoan));
            command.Parameters.Add(new SQLiteParameter("@BenhKhac", BenhKhac));
            command.Parameters.Add(new SQLiteParameter("@MaICD", MaICD));
            command.Parameters.Add(new SQLiteParameter("@TongChiPhi", TongChiPhi));
            command.Parameters.Add(new SQLiteParameter("@BHYTThanhToan", BHYTThanhToan));
            command.Parameters.Add(new SQLiteParameter("@NguoiBenhTra", NguoiBenhTra));
            command.Parameters.Add(new SQLiteParameter("@NguonKhac", NguonKhac));
            command.Parameters.Add(new SQLiteParameter("@SoTienThanhToanToiDa", SoTienThanhToanToiDa));
            command.Parameters.Add(new SQLiteParameter("@TienKham", TienKham));
            command.Parameters.Add(new SQLiteParameter("@TienGiuong", TienGiuong));
            command.Parameters.Add(new SQLiteParameter("@TienXN", TienXN));
            command.Parameters.Add(new SQLiteParameter("@TienCDHA", TienCDHA));
            command.Parameters.Add(new SQLiteParameter("@TienTDCN", TienTDCN));
            command.Parameters.Add(new SQLiteParameter("@TienPTTT", TienPTTT));
            command.Parameters.Add(new SQLiteParameter("@TienDichVuKTC", TienDichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@TienMau", TienMau));
            command.Parameters.Add(new SQLiteParameter("@TienThuoc", TienThuoc));
            command.Parameters.Add(new SQLiteParameter("@TienVTYT", TienVTYT));
            command.Parameters.Add(new SQLiteParameter("@TienVTYTTH", TienVTYTTH));
            command.Parameters.Add(new SQLiteParameter("@TienVTYTTT", TienVTYTTT));
            command.Parameters.Add(new SQLiteParameter("@TienVanChuyen", TienVanChuyen));
            command.Parameters.Add(new SQLiteParameter("@DVKTC_TinhToan", DVKTC_TinhToan));
            command.Parameters.Add(new SQLiteParameter("@DVKTC_ThanhToan", DVKTC_ThanhToan));
            command.Parameters.Add(new SQLiteParameter("@ChiPhiNgoaiDinhSuat", ChiPhiNgoaiDinhSuat));
            command.Parameters.Add(new SQLiteParameter("@DaGuiBHYT", DaGuiBHYT));
            command.Parameters.Add(new SQLiteParameter("@NgayGuiBHYT", NgayGuiBHYT));
            command.Parameters.Add(new SQLiteParameter("@NguoiGuiBHYT", NguoiGuiBHYT));
            command.Parameters.Add(new SQLiteParameter("@NgayTao", NgayTao));
            command.Parameters.Add(new SQLiteParameter("@NguoiTao", NguoiTao));
            command.Parameters.Add(new SQLiteParameter("@NgayCapNhat", NgayCapNhat));
            command.Parameters.Add(new SQLiteParameter("@NguoiCapNhat", NguoiCapNhat));
            command.Parameters.Add(new SQLiteParameter("@ChungNhanKhongCCT", ChungNhanKhongCCT));
            command.Parameters.Add(new SQLiteParameter("@BangKe_Id_BHXH", BangKe_Id_BHXH));
            int result = int.Parse(command.ExecuteScalar().ToString());
            return result;
        }

        /// <summary>
        /// Hàm Insert Normal
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {

            m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO DM_Thuoc (LoaiBangKe,SoHoSo,Khoa,MaKhamChuaBenh,MaNguoiBenh,HoTen,GioiTinh,NgaySinh,NamSinh,DiaChi,MaNoiSinhSong,SoTheBHYT,TuNgayBH,DenNgayBH,CoBHYT,TreEmKhongTheBHYT,MucHuong,PhanTramDuocHuong,MaCSKCBBanDau,TenCSKCBBanDau,MaCSKCB,MaChiNhanh,MaNoiChuyenDen,TenNoiChuyenDen,NgayDenKham,NgayKetThuc,SoNgayDieuTri,NgayQuyetToan,TuyenKhamBenh,ChanDoan,BenhKhac,MaICD,TongChiPhi,BHYTThanhToan,NguoiBenhTra,NguonKhac,SoTienThanhToanToiDa,TienKham,TienGiuong,TienXN,TienCDHA,TienTDCN,TienPTTT,TienDichVuKTC,TienMau,TienThuoc,TienVTYT,TienVTYTTH,TienVTYTTT,TienVanChuyen,DVKTC_TinhToan,DVKTC_ThanhToan,ChiPhiNgoaiDinhSuat,DaGuiBHYT,NgayGuiBHYT,NguoiGuiBHYT,NgayTao,NguoiTao,NgayCapNhat,NguoiCapNhat,ChungNhanKhongCCT,BangKe_Id_BHXH) ";
            sql += "VALUES(@LoaiBangKe,@SoHoSo,@Khoa,@MaKhamChuaBenh,@MaNguoiBenh,@HoTen,@GioiTinh,@NgaySinh,@NamSinh,@DiaChi,@MaNoiSinhSong,@SoTheBHYT,@TuNgayBH,@DenNgayBH,@CoBHYT,@TreEmKhongTheBHYT,@MucHuong,@PhanTramDuocHuong,@MaCSKCBBanDau,@TenCSKCBBanDau,@MaCSKCB,@MaChiNhanh,@MaNoiChuyenDen,@TenNoiChuyenDen,@NgayDenKham,@NgayKetThuc,@SoNgayDieuTri,@NgayQuyetToan,@TuyenKhamBenh,@ChanDoan,@BenhKhac,@MaICD,@TongChiPhi,@BHYTThanhToan,@NguoiBenhTra,@NguonKhac,@SoTienThanhToanToiDa,@TienKham,@TienGiuong,@TienXN,@TienCDHA,@TienTDCN,@TienPTTT,@TienDichVuKTC,@TienMau,@TienThuoc,@TienVTYT,@TienVTYTTH,@TienVTYTTT,@TienVanChuyen,@DVKTC_TinhToan,@DVKTC_ThanhToan,@ChiPhiNgoaiDinhSuat,@DaGuiBHYT,@NgayGuiBHYT,@NguoiGuiBHYT,@NgayTao,@NguoiTao,@NgayCapNhat,@NguoiCapNhat,@ChungNhanKhongCCT,@BangKe_Id_BHXH)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            //command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
            command.Parameters.Add(new SQLiteParameter("@LoaiBangKe", LoaiBangKe));
            command.Parameters.Add(new SQLiteParameter("@SoHoSo", SoHoSo));
            command.Parameters.Add(new SQLiteParameter("@Khoa", Khoa));
            command.Parameters.Add(new SQLiteParameter("@MaKhamChuaBenh", MaKhamChuaBenh));
            command.Parameters.Add(new SQLiteParameter("@MaNguoiBenh", MaNguoiBenh));
            command.Parameters.Add(new SQLiteParameter("@HoTen", HoTen));
            command.Parameters.Add(new SQLiteParameter("@GioiTinh", GioiTinh));
            command.Parameters.Add(new SQLiteParameter("@NgaySinh", NgaySinh));
            command.Parameters.Add(new SQLiteParameter("@NamSinh", NamSinh));
            command.Parameters.Add(new SQLiteParameter("@DiaChi", DiaChi));
            command.Parameters.Add(new SQLiteParameter("@MaNoiSinhSong", MaNoiSinhSong));
            command.Parameters.Add(new SQLiteParameter("@SoTheBHYT", SoTheBHYT));
            command.Parameters.Add(new SQLiteParameter("@TuNgayBH", TuNgayBH));
            command.Parameters.Add(new SQLiteParameter("@DenNgayBH", DenNgayBH));
            command.Parameters.Add(new SQLiteParameter("@CoBHYT", CoBHYT));
            command.Parameters.Add(new SQLiteParameter("@TreEmKhongTheBHYT", TreEmKhongTheBHYT));
            command.Parameters.Add(new SQLiteParameter("@MucHuong", MucHuong));
            command.Parameters.Add(new SQLiteParameter("@PhanTramDuocHuong", PhanTramDuocHuong));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCBBanDau", MaCSKCBBanDau));
            command.Parameters.Add(new SQLiteParameter("@TenCSKCBBanDau", TenCSKCBBanDau));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", MaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaChiNhanh", MaChiNhanh));
            command.Parameters.Add(new SQLiteParameter("@MaNoiChuyenDen", MaNoiChuyenDen));
            command.Parameters.Add(new SQLiteParameter("@TenNoiChuyenDen", TenNoiChuyenDen));
            command.Parameters.Add(new SQLiteParameter("@NgayDenKham", NgayDenKham));
            command.Parameters.Add(new SQLiteParameter("@NgayKetThuc", NgayKetThuc));
            command.Parameters.Add(new SQLiteParameter("@SoNgayDieuTri", SoNgayDieuTri));
            command.Parameters.Add(new SQLiteParameter("@NgayQuyetToan", NgayQuyetToan));
            command.Parameters.Add(new SQLiteParameter("@TuyenKhamBenh", TuyenKhamBenh));
            command.Parameters.Add(new SQLiteParameter("@ChanDoan", ChanDoan));
            command.Parameters.Add(new SQLiteParameter("@BenhKhac", BenhKhac));
            command.Parameters.Add(new SQLiteParameter("@MaICD", MaICD));
            command.Parameters.Add(new SQLiteParameter("@TongChiPhi", TongChiPhi));
            command.Parameters.Add(new SQLiteParameter("@BHYTThanhToan", BHYTThanhToan));
            command.Parameters.Add(new SQLiteParameter("@NguoiBenhTra", NguoiBenhTra));
            command.Parameters.Add(new SQLiteParameter("@NguonKhac", NguonKhac));
            command.Parameters.Add(new SQLiteParameter("@SoTienThanhToanToiDa", SoTienThanhToanToiDa));
            command.Parameters.Add(new SQLiteParameter("@TienKham", TienKham));
            command.Parameters.Add(new SQLiteParameter("@TienGiuong", TienGiuong));
            command.Parameters.Add(new SQLiteParameter("@TienXN", TienXN));
            command.Parameters.Add(new SQLiteParameter("@TienCDHA", TienCDHA));
            command.Parameters.Add(new SQLiteParameter("@TienTDCN", TienTDCN));
            command.Parameters.Add(new SQLiteParameter("@TienPTTT", TienPTTT));
            command.Parameters.Add(new SQLiteParameter("@TienDichVuKTC", TienDichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@TienMau", TienMau));
            command.Parameters.Add(new SQLiteParameter("@TienThuoc", TienThuoc));
            command.Parameters.Add(new SQLiteParameter("@TienVTYT", TienVTYT));
            command.Parameters.Add(new SQLiteParameter("@TienVTYTTH", TienVTYTTH));
            command.Parameters.Add(new SQLiteParameter("@TienVTYTTT", TienVTYTTT));
            command.Parameters.Add(new SQLiteParameter("@TienVanChuyen", TienVanChuyen));
            command.Parameters.Add(new SQLiteParameter("@DVKTC_TinhToan", DVKTC_TinhToan));
            command.Parameters.Add(new SQLiteParameter("@DVKTC_ThanhToan", DVKTC_ThanhToan));
            command.Parameters.Add(new SQLiteParameter("@ChiPhiNgoaiDinhSuat", ChiPhiNgoaiDinhSuat));
            command.Parameters.Add(new SQLiteParameter("@DaGuiBHYT", DaGuiBHYT));
            command.Parameters.Add(new SQLiteParameter("@NgayGuiBHYT", NgayGuiBHYT));
            command.Parameters.Add(new SQLiteParameter("@NguoiGuiBHYT", NguoiGuiBHYT));
            command.Parameters.Add(new SQLiteParameter("@NgayTao", NgayTao));
            command.Parameters.Add(new SQLiteParameter("@NguoiTao", NguoiTao));
            command.Parameters.Add(new SQLiteParameter("@NgayCapNhat", NgayCapNhat));
            command.Parameters.Add(new SQLiteParameter("@NguoiCapNhat", NguoiCapNhat));
            command.Parameters.Add(new SQLiteParameter("@ChungNhanKhongCCT", ChungNhanKhongCCT));
            command.Parameters.Add(new SQLiteParameter("@BangKe_Id_BHXH", BangKe_Id_BHXH));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
        /// <summary>
        /// Update Normal
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            m_dbConnection.Open();

            string sql = "";
            sql += "UPDATE BangKe ";
            sql += "Set LoaiBangKe=@LoaiBangKe ,SoHoSo=@SoHoSo ,Khoa=@Khoa ,MaKhamChuaBenh=@MaKhamChuaBenh ,MaNguoiBenh=@MaNguoiBenh ,HoTen=@HoTen ,GioiTinh=@GioiTinh ,NgaySinh=@NgaySinh ,NamSinh=@NamSinh ,DiaChi=@DiaChi ,MaNoiSinhSong=@MaNoiSinhSong ,SoTheBHYT=@SoTheBHYT ,TuNgayBH=@TuNgayBH ,DenNgayBH=@DenNgayBH ,CoBHYT=@CoBHYT ,TreEmKhongTheBHYT=@TreEmKhongTheBHYT ,MucHuong=@MucHuong ,PhanTramDuocHuong=@PhanTramDuocHuong ,MaCSKCBBanDau=@MaCSKCBBanDau ,TenCSKCBBanDau=@TenCSKCBBanDau ,MaCSKCB=@MaCSKCB ,MaChiNhanh=@MaChiNhanh ,MaNoiChuyenDen=@MaNoiChuyenDen ,TenNoiChuyenDen=@TenNoiChuyenDen ,NgayDenKham=@NgayDenKham ,NgayKetThuc=@NgayKetThuc ,SoNgayDieuTri=@SoNgayDieuTri ,NgayQuyetToan=@NgayQuyetToan ,TuyenKhamBenh=@TuyenKhamBenh ,ChanDoan=@ChanDoan ,BenhKhac=@BenhKhac ,MaICD=@MaICD ,TongChiPhi=@TongChiPhi ,BHYTThanhToan=@BHYTThanhToan ,NguoiBenhTra=@NguoiBenhTra ,NguonKhac=@NguonKhac ,SoTienThanhToanToiDa=@SoTienThanhToanToiDa ,TienKham=@TienKham ,TienGiuong=@TienGiuong ,TienXN=@TienXN ,TienCDHA=@TienCDHA ,TienTDCN=@TienTDCN ,TienPTTT=@TienPTTT ,TienDichVuKTC=@TienDichVuKTC ,TienMau=@TienMau ,TienThuoc=@TienThuoc ,TienVTYT=@TienVTYT ,TienVTYTTH=@TienVTYTTH ,TienVTYTTT=@TienVTYTTT ,TienVanChuyen=@TienVanChuyen ,DVKTC_TinhToan=@DVKTC_TinhToan ,DVKTC_ThanhToan=@DVKTC_ThanhToan ,ChiPhiNgoaiDinhSuat=@ChiPhiNgoaiDinhSuat ,DaGuiBHYT=@DaGuiBHYT ,NgayGuiBHYT=@NgayGuiBHYT ,NguoiGuiBHYT=@NguoiGuiBHYT ,NgayTao=@NgayTao ,NguoiTao=@NguoiTao ,NgayCapNhat=@NgayCapNhat ,NguoiCapNhat=@NguoiCapNhat ,ChungNhanKhongCCT=@ChungNhanKhongCCT,BangKe_Id_BHXH=@BangKe_Id_BHXH ";
            sql += "WHERE BangKe_Id=@BangKe_Id";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
            command.Parameters.Add(new SQLiteParameter("@LoaiBangKe", LoaiBangKe));
            command.Parameters.Add(new SQLiteParameter("@SoHoSo", SoHoSo));
            command.Parameters.Add(new SQLiteParameter("@Khoa", Khoa));
            command.Parameters.Add(new SQLiteParameter("@MaKhamChuaBenh", MaKhamChuaBenh));
            command.Parameters.Add(new SQLiteParameter("@MaNguoiBenh", MaNguoiBenh));
            command.Parameters.Add(new SQLiteParameter("@HoTen", HoTen));
            command.Parameters.Add(new SQLiteParameter("@GioiTinh", GioiTinh));
            command.Parameters.Add(new SQLiteParameter("@NgaySinh", NgaySinh));
            command.Parameters.Add(new SQLiteParameter("@NamSinh", NamSinh));
            command.Parameters.Add(new SQLiteParameter("@DiaChi", DiaChi));
            command.Parameters.Add(new SQLiteParameter("@MaNoiSinhSong", MaNoiSinhSong));
            command.Parameters.Add(new SQLiteParameter("@SoTheBHYT", SoTheBHYT));
            command.Parameters.Add(new SQLiteParameter("@TuNgayBH", TuNgayBH));
            command.Parameters.Add(new SQLiteParameter("@DenNgayBH", DenNgayBH));
            command.Parameters.Add(new SQLiteParameter("@CoBHYT", CoBHYT));
            command.Parameters.Add(new SQLiteParameter("@TreEmKhongTheBHYT", TreEmKhongTheBHYT));
            command.Parameters.Add(new SQLiteParameter("@MucHuong", MucHuong));
            command.Parameters.Add(new SQLiteParameter("@PhanTramDuocHuong", PhanTramDuocHuong));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCBBanDau", MaCSKCBBanDau));
            command.Parameters.Add(new SQLiteParameter("@TenCSKCBBanDau", TenCSKCBBanDau));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", MaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaChiNhanh", MaChiNhanh));
            command.Parameters.Add(new SQLiteParameter("@MaNoiChuyenDen", MaNoiChuyenDen));
            command.Parameters.Add(new SQLiteParameter("@TenNoiChuyenDen", TenNoiChuyenDen));
            command.Parameters.Add(new SQLiteParameter("@NgayDenKham", NgayDenKham));
            command.Parameters.Add(new SQLiteParameter("@NgayKetThuc", NgayKetThuc));
            command.Parameters.Add(new SQLiteParameter("@SoNgayDieuTri", SoNgayDieuTri));
            command.Parameters.Add(new SQLiteParameter("@NgayQuyetToan", NgayQuyetToan));
            command.Parameters.Add(new SQLiteParameter("@TuyenKhamBenh", TuyenKhamBenh));
            command.Parameters.Add(new SQLiteParameter("@ChanDoan", ChanDoan));
            command.Parameters.Add(new SQLiteParameter("@BenhKhac", BenhKhac));
            command.Parameters.Add(new SQLiteParameter("@MaICD", MaICD));
            command.Parameters.Add(new SQLiteParameter("@TongChiPhi", TongChiPhi));
            command.Parameters.Add(new SQLiteParameter("@BHYTThanhToan", BHYTThanhToan));
            command.Parameters.Add(new SQLiteParameter("@NguoiBenhTra", NguoiBenhTra));
            command.Parameters.Add(new SQLiteParameter("@NguonKhac", NguonKhac));
            command.Parameters.Add(new SQLiteParameter("@SoTienThanhToanToiDa", SoTienThanhToanToiDa));
            command.Parameters.Add(new SQLiteParameter("@TienKham", TienKham));
            command.Parameters.Add(new SQLiteParameter("@TienGiuong", TienGiuong));
            command.Parameters.Add(new SQLiteParameter("@TienXN", TienXN));
            command.Parameters.Add(new SQLiteParameter("@TienCDHA", TienCDHA));
            command.Parameters.Add(new SQLiteParameter("@TienTDCN", TienTDCN));
            command.Parameters.Add(new SQLiteParameter("@TienPTTT", TienPTTT));
            command.Parameters.Add(new SQLiteParameter("@TienDichVuKTC", TienDichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@TienMau", TienMau));
            command.Parameters.Add(new SQLiteParameter("@TienThuoc", TienThuoc));
            command.Parameters.Add(new SQLiteParameter("@TienVTYT", TienVTYT));
            command.Parameters.Add(new SQLiteParameter("@TienVTYTTH", TienVTYTTH));
            command.Parameters.Add(new SQLiteParameter("@TienVTYTTT", TienVTYTTT));
            command.Parameters.Add(new SQLiteParameter("@TienVanChuyen", TienVanChuyen));
            command.Parameters.Add(new SQLiteParameter("@DVKTC_TinhToan", DVKTC_TinhToan));
            command.Parameters.Add(new SQLiteParameter("@DVKTC_ThanhToan", DVKTC_ThanhToan));
            command.Parameters.Add(new SQLiteParameter("@ChiPhiNgoaiDinhSuat", ChiPhiNgoaiDinhSuat));
            command.Parameters.Add(new SQLiteParameter("@DaGuiBHYT", DaGuiBHYT));
            command.Parameters.Add(new SQLiteParameter("@NgayGuiBHYT", NgayGuiBHYT));
            command.Parameters.Add(new SQLiteParameter("@NguoiGuiBHYT", NguoiGuiBHYT));
            command.Parameters.Add(new SQLiteParameter("@NgayTao", NgayTao));
            command.Parameters.Add(new SQLiteParameter("@NguoiTao", NguoiTao));
            command.Parameters.Add(new SQLiteParameter("@NgayCapNhat", NgayCapNhat));
            command.Parameters.Add(new SQLiteParameter("@NguoiCapNhat", NguoiCapNhat));
            command.Parameters.Add(new SQLiteParameter("@ChungNhanKhongCCT", ChungNhanKhongCCT));
            command.Parameters.Add(new SQLiteParameter("@BangKe_Id_BHXH", BangKe_Id_BHXH));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
        /// <summary>
        /// Ham update Trans
        /// </summary>
        /// <param name="DAL"></param>
        /// <returns></returns>
        public int Update(SQLiteDAL DAL)
        {
            string sql = "";
            sql += "UPDATE BangKe ";
            sql += "Set LoaiBangKe=@LoaiBangKe ,SoHoSo=@SoHoSo ,Khoa=@Khoa ,MaKhamChuaBenh=@MaKhamChuaBenh ,MaNguoiBenh=@MaNguoiBenh ,HoTen=@HoTen ,GioiTinh=@GioiTinh ,NgaySinh=@NgaySinh ,NamSinh=@NamSinh ,DiaChi=@DiaChi ,MaNoiSinhSong=@MaNoiSinhSong ,SoTheBHYT=@SoTheBHYT ,TuNgayBH=@TuNgayBH ,DenNgayBH=@DenNgayBH ,CoBHYT=@CoBHYT ,TreEmKhongTheBHYT=@TreEmKhongTheBHYT ,MucHuong=@MucHuong ,PhanTramDuocHuong=@PhanTramDuocHuong ,MaCSKCBBanDau=@MaCSKCBBanDau ,TenCSKCBBanDau=@TenCSKCBBanDau ,MaCSKCB=@MaCSKCB ,MaChiNhanh=@MaChiNhanh ,MaNoiChuyenDen=@MaNoiChuyenDen ,TenNoiChuyenDen=@TenNoiChuyenDen ,NgayDenKham=@NgayDenKham ,NgayKetThuc=@NgayKetThuc ,SoNgayDieuTri=@SoNgayDieuTri ,NgayQuyetToan=@NgayQuyetToan ,TuyenKhamBenh=@TuyenKhamBenh ,ChanDoan=@ChanDoan ,BenhKhac=@BenhKhac ,MaICD=@MaICD ,TongChiPhi=@TongChiPhi ,BHYTThanhToan=@BHYTThanhToan ,NguoiBenhTra=@NguoiBenhTra ,NguonKhac=@NguonKhac ,SoTienThanhToanToiDa=@SoTienThanhToanToiDa ,TienKham=@TienKham ,TienGiuong=@TienGiuong ,TienXN=@TienXN ,TienCDHA=@TienCDHA ,TienTDCN=@TienTDCN ,TienPTTT=@TienPTTT ,TienDichVuKTC=@TienDichVuKTC ,TienMau=@TienMau ,TienThuoc=@TienThuoc ,TienVTYT=@TienVTYT ,TienVTYTTH=@TienVTYTTH ,TienVTYTTT=@TienVTYTTT ,TienVanChuyen=@TienVanChuyen ,DVKTC_TinhToan=@DVKTC_TinhToan ,DVKTC_ThanhToan=@DVKTC_ThanhToan ,ChiPhiNgoaiDinhSuat=@ChiPhiNgoaiDinhSuat ,DaGuiBHYT=@DaGuiBHYT ,NgayGuiBHYT=@NgayGuiBHYT ,NguoiGuiBHYT=@NguoiGuiBHYT ,NgayTao=@NgayTao ,NguoiTao=@NguoiTao ,NgayCapNhat=@NgayCapNhat ,NguoiCapNhat=@NguoiCapNhat ,ChungNhanKhongCCT=@ChungNhanKhongCCT,BangKe_Id_BHXH=@BangKe_Id_BHXH ";
            sql += "WHERE BangKe_Id=@BangKe_Id";

            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
            command.Parameters.Add(new SQLiteParameter("@LoaiBangKe", LoaiBangKe));
            command.Parameters.Add(new SQLiteParameter("@SoHoSo", SoHoSo));
            command.Parameters.Add(new SQLiteParameter("@Khoa", Khoa));
            command.Parameters.Add(new SQLiteParameter("@MaKhamChuaBenh", MaKhamChuaBenh));
            command.Parameters.Add(new SQLiteParameter("@MaNguoiBenh", MaNguoiBenh));
            command.Parameters.Add(new SQLiteParameter("@HoTen", HoTen));
            command.Parameters.Add(new SQLiteParameter("@GioiTinh", GioiTinh));
            command.Parameters.Add(new SQLiteParameter("@NgaySinh", NgaySinh));
            command.Parameters.Add(new SQLiteParameter("@NamSinh", NamSinh));
            command.Parameters.Add(new SQLiteParameter("@DiaChi", DiaChi));
            command.Parameters.Add(new SQLiteParameter("@MaNoiSinhSong", MaNoiSinhSong));
            command.Parameters.Add(new SQLiteParameter("@SoTheBHYT", SoTheBHYT));
            command.Parameters.Add(new SQLiteParameter("@TuNgayBH", TuNgayBH));
            command.Parameters.Add(new SQLiteParameter("@DenNgayBH", DenNgayBH));
            command.Parameters.Add(new SQLiteParameter("@CoBHYT", CoBHYT));
            command.Parameters.Add(new SQLiteParameter("@TreEmKhongTheBHYT", TreEmKhongTheBHYT));
            command.Parameters.Add(new SQLiteParameter("@MucHuong", MucHuong));
            command.Parameters.Add(new SQLiteParameter("@PhanTramDuocHuong", PhanTramDuocHuong));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCBBanDau", MaCSKCBBanDau));
            command.Parameters.Add(new SQLiteParameter("@TenCSKCBBanDau", TenCSKCBBanDau));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", MaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaChiNhanh", MaChiNhanh));
            command.Parameters.Add(new SQLiteParameter("@MaNoiChuyenDen", MaNoiChuyenDen));
            command.Parameters.Add(new SQLiteParameter("@TenNoiChuyenDen", TenNoiChuyenDen));
            command.Parameters.Add(new SQLiteParameter("@NgayDenKham", NgayDenKham));
            command.Parameters.Add(new SQLiteParameter("@NgayKetThuc", NgayKetThuc));
            command.Parameters.Add(new SQLiteParameter("@SoNgayDieuTri", SoNgayDieuTri));
            command.Parameters.Add(new SQLiteParameter("@NgayQuyetToan", NgayQuyetToan));
            command.Parameters.Add(new SQLiteParameter("@TuyenKhamBenh", TuyenKhamBenh));
            command.Parameters.Add(new SQLiteParameter("@ChanDoan", ChanDoan));
            command.Parameters.Add(new SQLiteParameter("@BenhKhac", BenhKhac));
            command.Parameters.Add(new SQLiteParameter("@MaICD", MaICD));
            command.Parameters.Add(new SQLiteParameter("@TongChiPhi", TongChiPhi));
            command.Parameters.Add(new SQLiteParameter("@BHYTThanhToan", BHYTThanhToan));
            command.Parameters.Add(new SQLiteParameter("@NguoiBenhTra", NguoiBenhTra));
            command.Parameters.Add(new SQLiteParameter("@NguonKhac", NguonKhac));
            command.Parameters.Add(new SQLiteParameter("@SoTienThanhToanToiDa", SoTienThanhToanToiDa));
            command.Parameters.Add(new SQLiteParameter("@TienKham", TienKham));
            command.Parameters.Add(new SQLiteParameter("@TienGiuong", TienGiuong));
            command.Parameters.Add(new SQLiteParameter("@TienXN", TienXN));
            command.Parameters.Add(new SQLiteParameter("@TienCDHA", TienCDHA));
            command.Parameters.Add(new SQLiteParameter("@TienTDCN", TienTDCN));
            command.Parameters.Add(new SQLiteParameter("@TienPTTT", TienPTTT));
            command.Parameters.Add(new SQLiteParameter("@TienDichVuKTC", TienDichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@TienMau", TienMau));
            command.Parameters.Add(new SQLiteParameter("@TienThuoc", TienThuoc));
            command.Parameters.Add(new SQLiteParameter("@TienVTYT", TienVTYT));
            command.Parameters.Add(new SQLiteParameter("@TienVTYTTH", TienVTYTTH));
            command.Parameters.Add(new SQLiteParameter("@TienVTYTTT", TienVTYTTT));
            command.Parameters.Add(new SQLiteParameter("@TienVanChuyen", TienVanChuyen));
            command.Parameters.Add(new SQLiteParameter("@DVKTC_TinhToan", DVKTC_TinhToan));
            command.Parameters.Add(new SQLiteParameter("@DVKTC_ThanhToan", DVKTC_ThanhToan));
            command.Parameters.Add(new SQLiteParameter("@ChiPhiNgoaiDinhSuat", ChiPhiNgoaiDinhSuat));
            command.Parameters.Add(new SQLiteParameter("@DaGuiBHYT", DaGuiBHYT));
            command.Parameters.Add(new SQLiteParameter("@NgayGuiBHYT", NgayGuiBHYT));
            command.Parameters.Add(new SQLiteParameter("@NguoiGuiBHYT", NguoiGuiBHYT));
            command.Parameters.Add(new SQLiteParameter("@NgayTao", NgayTao));
            command.Parameters.Add(new SQLiteParameter("@NguoiTao", NguoiTao));
            command.Parameters.Add(new SQLiteParameter("@NgayCapNhat", NgayCapNhat));
            command.Parameters.Add(new SQLiteParameter("@NguoiCapNhat", NguoiCapNhat));
            command.Parameters.Add(new SQLiteParameter("@ChungNhanKhongCCT", ChungNhanKhongCCT));
            command.Parameters.Add(new SQLiteParameter("@BangKe_Id_BHXH", BangKe_Id_BHXH));


            int result = command.ExecuteNonQuery();
            return result;
        }

        public int Delete(int intBangKe_Id)
        {
            m_dbConnection.Open();

            string sql = "Delete from BangKe WHERE BangKe_Id=@BangKe_Id";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", intBangKe_Id));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public int DeleteBangKeChiTiet(int BangKe_Id, SQLiteDAL DAL)
        {


            string sql = "Delete from BangKeChiTiet WHERE BangKe_Id=@BangKe_Id";


            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));

            int result = command.ExecuteNonQuery();
            return result;
        }
        public bool CheckTonTaiSoDK(string SoDK)
        {

            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT SoHoSo FROM BangKe WHERE SoHoSo=@SoHoSo";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@SoHoSo", SoDK));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public int Update_GuiBHXH()
        {
            m_dbConnection.Open();

            string sql = "";
            sql += "UPDATE BangKe ";
            sql += "SET DaGuiBHYT = @DaGuiBHYT, BangKe_Id_BHXH = @BangKe_Id_BHXH ";
            sql += "WHERE BangKe_Id=@BangKe_Id";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));            
            command.Parameters.Add(new SQLiteParameter("@DaGuiBHYT", DaGuiBHYT));
            command.Parameters.Add(new SQLiteParameter("@BangKe_Id_BHXH", BangKe_Id_BHXH));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

    }
}
