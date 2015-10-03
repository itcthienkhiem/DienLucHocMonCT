using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace coInventory.Mini.EntityClass
{
    public class clsDM_Thuoc
    {
        public int Thuoc_Id;
        public string MaThuoc;
        public string TenThuoc;
        public string TenHoatChat;
        public string DonViTinh;
        public string QuyCach;
        public string NhaSanXuat;
        public string NuocSanXuat;
        public string SoDangKy;
        public DateTime? HanSuDung;
        public string NongDo;
        public string DangBaoChe;
        public string TieuChuan;
        public int? NhomThuoc;
        public decimal? DonGiaMua;
        public decimal? DonGiaThau;
        public decimal? DonGiaCSKCB;
        public decimal? SoLuong;
        public string MaNhom1;
        public string MaNhom2;
        public bool? TrongDanhMucBHYT = true;
        public bool? TrongThau = true;
        public bool? Active = true;
        public bool? ThuocDieuTriK = false;
        public decimal? TyLeThanhToan;
        public string MaNhaThau;
        public int? Nam;
        public string STTBYT;
        public string MaThuocBYT;
        public string MaThuocBYT2;
        public string TenThuocBYT;
        public string GhiChu;

        public string HanSuDung_Str;


        SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public DataTable GetAllALL()
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "";

            sql += " Select MaChiPhi, TenChiPhi, DonViTinh, DonGiaBHYT, DonGiaCSKCB, LoaiChiPhi, ";
            sql += " CASE WHEN LoaiChiPhi='T' THEN 'Thuốc' ";
            sql += " WHEN LoaiChiPhi='D' THEN 'Dịch vụ'";

            sql += " WHEN LoaiChiPhi='V' THEN 'Vật tư y tế'";
            sql += " ELSE 'Máu và chế phẩm' ";
            sql += " END as Nhom ";

            sql += " from (";
            sql += " Select MaThuoc as MaChiPhi, TenThuoc as TenChiPhi, DonViTinh as DonViTinh, DonGiaThau as DonGiaBHYT,DonGiaCSKCB as DonGiaCSKCB, 'T' as LoaiChiPhi";
            sql += " from DM_Thuoc";
            sql += " Where Active=1";

            sql += " Union ";

            sql += " Select MaDichVu as MaChiPhi, TenDichVu as TenChiPhi, DonViTinh as DonViTinh, DonGiaBHYT as DonGiaBHYT,DonGiaCSKCB as DonGiaCSKCB,'D' as LoaiChiPhi ";
            sql += " from DM_DichVu";
            sql += " Where Active=1";

            sql += " Union ";

            sql += " Select MaVTYT as MaChiPhi, TenVTYT as TenChiPhi, DonViTinh as DonViTinh, DonGiaThau as DonGiaBHYT,DonGiaCSKCB as DonGiaCSKCB,'V' as LoaiChiPhi ";
            sql += " from DM_VTYT";
            sql += " Where Active=1";

            sql += " Union ";

            sql += " Select MaMauVaChePhamMau as MaChiPhi, TenMauVaChePhamMau as TenChiPhi, DonViTinh as DonViTinh, DonGiaBHYT as DonGiaBHYT,DonGiaCSKCB as DonGiaCSKCB, 'M' as LoaiChiPhi";
            sql += " from DM_MauVaChePhamMau";
            sql += " Where Active=1";

            sql += ")";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }




        /// <summary>
        /// Get ALL
        /// </summary>
        /// <returns>DataTable</returns>
        /// 
        public DataTable GetAll()
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_Thuoc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }
        /// <summary>
        /// Get by Ma
        /// </summary>
        /// <param name="strMaThuoc">objDMThuoc</param>
        public void GetByKey(string strMaThuoc)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_Thuoc WHERE MaThuoc=@MaThuoc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaThuoc", strMaThuoc));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                Thuoc_Id = Int32.Parse(dt.Rows[0]["Thuoc_Id"].ToString());
                MaThuoc = dt.Rows[0]["MaThuoc"].ToString();
                TenThuoc = dt.Rows[0]["TenThuoc"].ToString();
                TenHoatChat = dt.Rows[0]["TenHoatChat"].ToString();
                DonViTinh = dt.Rows[0]["DonViTinh"].ToString();
                QuyCach = dt.Rows[0]["QuyCach"].ToString();
                NhaSanXuat = dt.Rows[0]["NhaSanXuat"].ToString();
                NuocSanXuat = dt.Rows[0]["NuocSanXuat"].ToString();
                SoDangKy = dt.Rows[0]["SoDangKy"].ToString();
                HanSuDung = string.IsNullOrEmpty(dt.Rows[0]["HanSuDung"].ToString()) ? null : (DateTime?)dt.Rows[0]["HanSuDung"];
                NongDo = dt.Rows[0]["NongDo"].ToString();
                DangBaoChe = dt.Rows[0]["DangBaoChe"].ToString();
                TieuChuan = dt.Rows[0]["TieuChuan"].ToString();
                NhomThuoc = string.IsNullOrEmpty(dt.Rows[0]["NhomThuoc"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["NhomThuoc"].ToString());
                DonGiaMua = string.IsNullOrEmpty(dt.Rows[0]["DonGiaMua"].ToString()) ? null : (decimal?)dt.Rows[0]["DonGiaMua"];
                DonGiaThau = string.IsNullOrEmpty(dt.Rows[0]["DonGiaThau"].ToString()) ? null : (decimal?)dt.Rows[0]["DonGiaThau"];
                DonGiaCSKCB = string.IsNullOrEmpty(dt.Rows[0]["DonGiaCSKCB"].ToString()) ? null : (decimal?)dt.Rows[0]["DonGiaCSKCB"];
                SoLuong = string.IsNullOrEmpty(dt.Rows[0]["SoLuong"].ToString()) ? null : (decimal?)dt.Rows[0]["SoLuong"];
                MaNhom1 = dt.Rows[0]["MaNhom1"].ToString();
                MaNhom2 = dt.Rows[0]["MaNhom2"].ToString();
                TrongDanhMucBHYT = string.IsNullOrEmpty(dt.Rows[0]["TrongDanhMucBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["TrongDanhMucBHYT"];
                TrongThau = string.IsNullOrEmpty(dt.Rows[0]["TrongThau"].ToString()) ? null : (bool?)dt.Rows[0]["TrongThau"]; ;
                Active = string.IsNullOrEmpty(dt.Rows[0]["Active"].ToString()) ? null : (bool?)dt.Rows[0]["Active"]; ;
                ThuocDieuTriK = string.IsNullOrEmpty(dt.Rows[0]["ThuocDieuTriK"].ToString()) ? null : (bool?)dt.Rows[0]["ThuocDieuTriK"]; ;
                TyLeThanhToan = string.IsNullOrEmpty(dt.Rows[0]["TyLeThanhToan"].ToString()) ? null : (decimal?)dt.Rows[0]["TyLeThanhToan"]; ;
                MaNhaThau = dt.Rows[0]["MaNhaThau"].ToString();
                Nam = string.IsNullOrEmpty(dt.Rows[0]["Nam"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["Nam"].ToString());
                STTBYT = dt.Rows[0]["STTBYT"].ToString();
                MaThuocBYT = dt.Rows[0]["MaThuocBYT"].ToString();
                MaThuocBYT2 = dt.Rows[0]["MaThuocBYT2"].ToString();
                TenThuocBYT = dt.Rows[0]["TenThuocBYT"].ToString();
                GhiChu = dt.Rows[0]["GhiChu"].ToString();
                HanSuDung_Str = dt.Rows[0]["HanSuDung_Str"].ToString();

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
            sql += "INSERT INTO DM_Thuoc (MaThuoc,TenThuoc,TenHoatChat,DonViTinh,QuyCach,NhaSanXuat,NuocSanXuat,SoDangKy,HanSuDung,NongDo,DangBaoChe,TieuChuan,NhomThuoc,DonGiaMua,DonGiaThau,DonGiaCSKCB,SoLuong,MaNhom1,MaNhom2,TrongDanhMucBHYT,TrongThau,Active,ThuocDieuTriK,TyLeThanhToan,MaNhaThau,Nam,STTBYT,MaThuocBYT,MaThuocBYT2,TenThuocBYT,GhiChu,HanSuDung_Str) ";
            sql += "VALUES(@MaThuoc,@TenThuoc,@TenHoatChat,@DonViTinh,@QuyCach,@NhaSanXuat,@NuocSanXuat,@SoDangKy,@HanSuDung,@NongDo,@DangBaoChe,@TieuChuan,@NhomThuoc,@DonGiaMua,@DonGiaThau,@DonGiaCSKCB,@SoLuong,@MaNhom1,@MaNhom2,@TrongDanhMucBHYT,@TrongThau,@Active,@ThuocDieuTriK,@TyLeThanhToan,@MaNhaThau,@Nam,@STTBYT,@MaThuocBYT,@MaThuocBYT2,@TenThuocBYT,@GhiChu,@HanSuDung_Str)";

            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaThuoc", MaThuoc));
            command.Parameters.Add(new SQLiteParameter("@TenThuoc", TenThuoc));
            command.Parameters.Add(new SQLiteParameter("@TenHoatChat", TenHoatChat));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@QuyCach", QuyCach));
            command.Parameters.Add(new SQLiteParameter("@NhaSanXuat", NhaSanXuat));
            command.Parameters.Add(new SQLiteParameter("@NuocSanXuat", NuocSanXuat));
            command.Parameters.Add(new SQLiteParameter("@SoDangKy", SoDangKy));
            command.Parameters.Add(new SQLiteParameter("@HanSuDung", HanSuDung));
            command.Parameters.Add(new SQLiteParameter("@NongDo", NongDo));
            command.Parameters.Add(new SQLiteParameter("@DangBaoChe", DangBaoChe));
            command.Parameters.Add(new SQLiteParameter("@TieuChuan", TieuChuan));
            command.Parameters.Add(new SQLiteParameter("@NhomThuoc", NhomThuoc));
            command.Parameters.Add(new SQLiteParameter("@DonGiaMua", DonGiaMua));
            command.Parameters.Add(new SQLiteParameter("@DonGiaThau", DonGiaThau));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@SoLuong", SoLuong));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@TrongThau", TrongThau));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@ThuocDieuTriK", ThuocDieuTriK));
            command.Parameters.Add(new SQLiteParameter("@TyLeThanhToan", TyLeThanhToan));
            command.Parameters.Add(new SQLiteParameter("@MaNhaThau", MaNhaThau));
            command.Parameters.Add(new SQLiteParameter("@Nam", Nam));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaThuocBYT", MaThuocBYT));
            command.Parameters.Add(new SQLiteParameter("@MaThuocBYT2", MaThuocBYT2));
            command.Parameters.Add(new SQLiteParameter("@TenThuocBYT", TenThuocBYT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));
            command.Parameters.Add(new SQLiteParameter("@HanSuDung_Str", HanSuDung_Str));
            int result = command.ExecuteNonQuery();
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
            sql += "INSERT INTO DM_Thuoc (MaThuoc,TenThuoc,TenHoatChat,DonViTinh,QuyCach,NhaSanXuat,NuocSanXuat,SoDangKy,HanSuDung,NongDo,DangBaoChe,TieuChuan,NhomThuoc,DonGiaMua,DonGiaThau,DonGiaCSKCB,SoLuong,MaNhom1,MaNhom2,TrongDanhMucBHYT,TrongThau,Active,ThuocDieuTriK,TyLeThanhToan,MaNhaThau,Nam,STTBYT,MaThuocBYT,MaThuocBYT2,TenThuocBYT,GhiChu,HanSuDung_Str) ";
            sql += "VALUES(@MaThuoc,@TenThuoc,@TenHoatChat,@DonViTinh,@QuyCach,@NhaSanXuat,@NuocSanXuat,@SoDangKy,@HanSuDung,@NongDo,@DangBaoChe,@TieuChuan,@NhomThuoc,@DonGiaMua,@DonGiaThau,@DonGiaCSKCB,@SoLuong,@MaNhom1,@MaNhom2,@TrongDanhMucBHYT,@TrongThau,@Active,@ThuocDieuTriK,@TyLeThanhToan,@MaNhaThau,@Nam,@STTBYT,@MaThuocBYT,@MaThuocBYT2,@TenThuocBYT,@GhiChu,@HanSuDung_Str)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaThuoc", MaThuoc));
            command.Parameters.Add(new SQLiteParameter("@TenThuoc", TenThuoc));
            command.Parameters.Add(new SQLiteParameter("@TenHoatChat", TenHoatChat));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@QuyCach", QuyCach));
            command.Parameters.Add(new SQLiteParameter("@NhaSanXuat", NhaSanXuat));
            command.Parameters.Add(new SQLiteParameter("@NuocSanXuat", NuocSanXuat));
            command.Parameters.Add(new SQLiteParameter("@SoDangKy", SoDangKy));
            command.Parameters.Add(new SQLiteParameter("@HanSuDung", HanSuDung));
            command.Parameters.Add(new SQLiteParameter("@NongDo", NongDo));
            command.Parameters.Add(new SQLiteParameter("@DangBaoChe", DangBaoChe));
            command.Parameters.Add(new SQLiteParameter("@TieuChuan", TieuChuan));
            command.Parameters.Add(new SQLiteParameter("@NhomThuoc", NhomThuoc));
            command.Parameters.Add(new SQLiteParameter("@DonGiaMua", DonGiaMua));
            command.Parameters.Add(new SQLiteParameter("@DonGiaThau", DonGiaThau));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@SoLuong", SoLuong));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@TrongThau", TrongThau));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@ThuocDieuTriK", ThuocDieuTriK));
            command.Parameters.Add(new SQLiteParameter("@TyLeThanhToan", TyLeThanhToan));
            command.Parameters.Add(new SQLiteParameter("@MaNhaThau", MaNhaThau));
            command.Parameters.Add(new SQLiteParameter("@Nam", Nam));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaThuocBYT", MaThuocBYT));
            command.Parameters.Add(new SQLiteParameter("@MaThuocBYT2", MaThuocBYT2));
            command.Parameters.Add(new SQLiteParameter("@TenThuocBYT", TenThuocBYT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));
            command.Parameters.Add(new SQLiteParameter("@HanSuDung_Str", HanSuDung_Str));

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
            sql += "UPDATE DM_Thuoc ";
            sql += "SET MaThuoc=@MaThuoc,TenThuoc=@TenThuoc,TenHoatChat=@TenHoatChat,DonViTinh=@DonViTinh,";
            sql += "QuyCach=@QuyCach,NhaSanXuat=@NhaSanXuat,NuocSanXuat=@NuocSanXuat,SoDangKy=@SoDangKy,HanSuDung=@HanSuDung,NongDo=@NongDo,DangBaoChe=@DangBaoChe,TieuChuan=@TieuChuan,NhomThuoc=@NhomThuoc,";
            sql += "DonGiaMua=@DonGiaMua,DonGiaThau=@DonGiaThau,DonGiaCSKCB=@DonGiaCSKCB,SoLuong=@SoLuong,MaNhom1=@MaNhom1,MaNhom2=@MaNhom2,";
            sql += "TrongDanhMucBHYT=@TrongDanhMucBHYT,TrongThau=@TrongThau,Active=@Active,ThuocDieuTriK=@ThuocDieuTriK,TyLeThanhToan=@TyLeThanhToan,MaNhaThau=@MaNhaThau,Nam=@Nam,STTBYT=@STTBYT,MaThuocBYT=@MaThuocBYT,MaThuocBYT2=@MaThuocBYT2,TenThuocBYT=@TenThuocBYT,GhiChu=@GhiChu,HanSuDung_Str=@HanSuDung_Str ";
            sql += "WHERE MaThuoc=@MaThuoc";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@Thuoc_Id", Thuoc_Id));
            command.Parameters.Add(new SQLiteParameter("@MaThuoc", MaThuoc));
            command.Parameters.Add(new SQLiteParameter("@TenThuoc", TenThuoc));
            command.Parameters.Add(new SQLiteParameter("@TenHoatChat", TenHoatChat));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@QuyCach", QuyCach));
            command.Parameters.Add(new SQLiteParameter("@NhaSanXuat", NhaSanXuat));
            command.Parameters.Add(new SQLiteParameter("@NuocSanXuat", NuocSanXuat));
            command.Parameters.Add(new SQLiteParameter("@SoDangKy", SoDangKy));
            command.Parameters.Add(new SQLiteParameter("@HanSuDung", HanSuDung));
            command.Parameters.Add(new SQLiteParameter("@NongDo", NongDo));
            command.Parameters.Add(new SQLiteParameter("@DangBaoChe", DangBaoChe));
            command.Parameters.Add(new SQLiteParameter("@TieuChuan", TieuChuan));
            command.Parameters.Add(new SQLiteParameter("@NhomThuoc", NhomThuoc));
            command.Parameters.Add(new SQLiteParameter("@DonGiaMua", DonGiaMua));
            command.Parameters.Add(new SQLiteParameter("@DonGiaThau", DonGiaThau));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@SoLuong", SoLuong));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@TrongThau", TrongThau));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@ThuocDieuTriK", ThuocDieuTriK));
            command.Parameters.Add(new SQLiteParameter("@TyLeThanhToan", TyLeThanhToan));
            command.Parameters.Add(new SQLiteParameter("@MaNhaThau", MaNhaThau));
            command.Parameters.Add(new SQLiteParameter("@Nam", Nam));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaThuocBYT", MaThuocBYT));
            command.Parameters.Add(new SQLiteParameter("@MaThuocBYT2", MaThuocBYT2));
            command.Parameters.Add(new SQLiteParameter("@TenThuocBYT", TenThuocBYT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));
            command.Parameters.Add(new SQLiteParameter("@HanSuDung_Str", HanSuDung_Str));

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
            sql += "UPDATE DM_Thuoc ";
            sql += "SET MaThuoc=@MaThuoc,TenThuoc=@TenThuoc,TenHoatChat=@TenHoatChat,DonViTinh=@DonViTinh,";
            sql += "QuyCach=@QuyCach,NhaSanXuat=@NhaSanXuat,NuocSanXuat=@NuocSanXuat,SoDangKy=@SoDangKy,HanSuDung=@HanSuDung,NongDo=@NongDo,DangBaoChe=@DangBaoChe,TieuChuan=@TieuChuan,NhomThuoc=@NhomThuoc,";
            sql += "DonGiaMua=@DonGiaMua,DonGiaThau=@DonGiaThau,DonGiaCSKCB=@DonGiaCSKCB,SoLuong=@SoLuong,MaNhom1=@MaNhom1,MaNhom2=@MaNhom2,";
            sql += "TrongDanhMucBHYT=@TrongDanhMucBHYT,TrongThau=@TrongThau,Active=@Active,ThuocDieuTriK=@ThuocDieuTriK,TyLeThanhToan=@TyLeThanhToan,MaNhaThau=@MaNhaThau,Nam=@Nam,STTBYT=@STTBYT,MaThuocBYT=@MaThuocBYT,MaThuocBYT2=@MaThuocBYT2,TenThuocBYT=@TenThuocBYT,GhiChu=@GhiChu,HanSuDung_Str=@HanSuDung_Str ";
            sql += "WHERE MaThuoc=@MaThuoc";


            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@Thuoc_Id", Thuoc_Id));
            command.Parameters.Add(new SQLiteParameter("@MaThuoc", MaThuoc));
            command.Parameters.Add(new SQLiteParameter("@TenThuoc", TenThuoc));
            command.Parameters.Add(new SQLiteParameter("@TenHoatChat", TenHoatChat));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@QuyCach", QuyCach));
            command.Parameters.Add(new SQLiteParameter("@NhaSanXuat", NhaSanXuat));
            command.Parameters.Add(new SQLiteParameter("@NuocSanXuat", NuocSanXuat));
            command.Parameters.Add(new SQLiteParameter("@SoDangKy", SoDangKy));
            command.Parameters.Add(new SQLiteParameter("@HanSuDung", HanSuDung));
            command.Parameters.Add(new SQLiteParameter("@NongDo", NongDo));
            command.Parameters.Add(new SQLiteParameter("@DangBaoChe", DangBaoChe));
            command.Parameters.Add(new SQLiteParameter("@TieuChuan", TieuChuan));
            command.Parameters.Add(new SQLiteParameter("@NhomThuoc", NhomThuoc));
            command.Parameters.Add(new SQLiteParameter("@DonGiaMua", DonGiaMua));
            command.Parameters.Add(new SQLiteParameter("@DonGiaThau", DonGiaThau));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@SoLuong", SoLuong));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@TrongThau", TrongThau));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@ThuocDieuTriK", ThuocDieuTriK));
            command.Parameters.Add(new SQLiteParameter("@TyLeThanhToan", TyLeThanhToan));
            command.Parameters.Add(new SQLiteParameter("@MaNhaThau", MaNhaThau));
            command.Parameters.Add(new SQLiteParameter("@Nam", Nam));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaThuocBYT", MaThuocBYT));
            command.Parameters.Add(new SQLiteParameter("@MaThuocBYT2", MaThuocBYT2));
            command.Parameters.Add(new SQLiteParameter("@TenThuocBYT", TenThuocBYT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));
            command.Parameters.Add(new SQLiteParameter("@HanSuDung_Str", HanSuDung_Str));

            int result = command.ExecuteNonQuery();
            return result;
        }

        public int Delete(string strMaThuoc)
        {
            m_dbConnection.Open();

            string sql = "Delete from DM_THUOC WHERE MaThuoc=@MaThuoc";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaThuoc", strMaThuoc));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public bool CheckTonTai(string strMaThuoc)
        {

            DataTable dt = new DataTable();
            string sql = "SELECT MaThuoc FROM DM_Thuoc WHERE MaThuoc=@MaThuoc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaThuoc", strMaThuoc));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
