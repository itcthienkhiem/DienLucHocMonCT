using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace coInventory.Mini.EntityClass
{
    public class clsDM_VTYT
    {
        public int VTYT_Id;
        public string MaVTYT;
        public string TenVTYT;
        public string TenHoatChat;
        public string DonViTinh;
        public string QuyCach;
        public string NhaSanXuat;
        public string NuocSanXuat;
        public string SoDangKy;
        public DateTime? HanSuDung;
        public decimal? SoLuong;
        public decimal? DonGiaMua;
        public decimal? DonGiaThau;
        public decimal? DonGiaCSKCB;
        public string MaNhom1;
        public string MaNhom2;
        public bool? TrongDanhMucBHYT = true;
        public bool? VTYTThayThe = false;
        public bool? VTYTDichVuKTC = false;
        public bool? TrongThau = true;
        public bool? Active = true;
        public int? Nam;
        public string STTBYT;
        public string MaVTYTBYT;
        public string TenVTYTBYT;
        public string GhiChu;

        SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public DataTable GetAll()
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_VTYT";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public void GetByKey(string strMaVTYT)
        {

            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_VTYT WHERE MaVTYT=@MaVTYT";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaVTYT", strMaVTYT));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                VTYT_Id = int.Parse(dt.Rows[0]["VTYT_Id"].ToString());
                MaVTYT = dt.Rows[0]["MaVTYT"].ToString();
                TenVTYT = dt.Rows[0]["TenVTYT"].ToString();
                TenHoatChat = dt.Rows[0]["TenHoatChat"].ToString();
                DonViTinh = dt.Rows[0]["DonViTinh"].ToString();
                QuyCach = dt.Rows[0]["QuyCach"].ToString();
                NhaSanXuat = dt.Rows[0]["NhaSanXuat"].ToString();
                NuocSanXuat = dt.Rows[0]["NuocSanXuat"].ToString();
                SoDangKy = dt.Rows[0]["SoDangKy"].ToString();
                HanSuDung = string.IsNullOrEmpty(dt.Rows[0]["HanSuDung"].ToString()) ? null : (DateTime?)dt.Rows[0]["HanSuDung"];
                SoLuong = string.IsNullOrEmpty(dt.Rows[0]["SoLuong"].ToString()) ? null : (decimal?)dt.Rows[0]["SoLuong"]; ;
                DonGiaMua = string.IsNullOrEmpty(dt.Rows[0]["DonGiaMua"].ToString()) ? null : (decimal?)dt.Rows[0]["DonGiaMua"];
                DonGiaThau = string.IsNullOrEmpty(dt.Rows[0]["DonGiaThau"].ToString()) ? null : (decimal?)dt.Rows[0]["DonGiaThau"];
                DonGiaCSKCB = string.IsNullOrEmpty(dt.Rows[0]["DonGiaCSKCB"].ToString()) ? null : (decimal?)dt.Rows[0]["DonGiaCSKCB"]; ;
                MaNhom1 = dt.Rows[0]["MaNhom1"].ToString();
                MaNhom2 = dt.Rows[0]["MaNhom2"].ToString();
                TrongDanhMucBHYT = string.IsNullOrEmpty(dt.Rows[0]["TrongDanhMucBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["TrongDanhMucBHYT"];
                TrongThau = string.IsNullOrEmpty(dt.Rows[0]["TrongThau"].ToString()) ? null : (bool?)dt.Rows[0]["TrongThau"];
                Active = string.IsNullOrEmpty(dt.Rows[0]["Active"].ToString()) ? null : (bool?)dt.Rows[0]["Active"];
                VTYTThayThe = string.IsNullOrEmpty(dt.Rows[0]["VTYTThayThe"].ToString()) ? null : (bool?)dt.Rows[0]["VTYTThayThe"];
                VTYTDichVuKTC = string.IsNullOrEmpty(dt.Rows[0]["VTYTDichVuKTC"].ToString()) ? null : (bool?)dt.Rows[0]["VTYTDichVuKTC"];
                Nam = string.IsNullOrEmpty(dt.Rows[0]["Nam"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["Nam"].ToString());
                STTBYT = dt.Rows[0]["STTBYT"].ToString();
                MaVTYTBYT = dt.Rows[0]["MaVTYTBYT"].ToString();
                TenVTYTBYT = dt.Rows[0]["TenVTYTBYT"].ToString();
                GhiChu = dt.Rows[0]["GhiChu"].ToString();
            }
        }


        public int Insert()
        {
            m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO DM_VTYT (MaVTYT,TenVTYT,TenHoatChat,DonViTinh,QuyCach,NhaSanXuat,NuocSanXuat,SoDangKy,HanSuDung,SoLuong,DonGiaMua,DonGiaThau,DonGiaCSKCB,MaNhom1,MaNhom2,TrongDanhMucBHYT,VTYTThayThe,VTYTDichVuKTC,TrongThau,Active,Nam,STTBYT,MaVTYTBYT,TenVTYTBYT,GhiChu) ";
            sql += "VALUES(@MaVTYT,@TenVTYT,@TenHoatChat,@DonViTinh,@QuyCach,@NhaSanXuat,@NuocSanXuat,@SoDangKy,@HanSuDung,@SoLuong,@DonGiaMua,@DonGiaThau,@DonGiaCSKCB,@MaNhom1,@MaNhom2,@TrongDanhMucBHYT,@VTYTThayThe,@VTYTDichVuKTC,@TrongThau,@Active,@Nam,@STTBYT,@MaVTYTBYT,@TenVTYTBYT,@GhiChu)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaVTYT", MaVTYT));
            command.Parameters.Add(new SQLiteParameter("@TenVTYT", TenVTYT));
            command.Parameters.Add(new SQLiteParameter("@TenHoatChat", TenHoatChat));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@QuyCach", QuyCach));
            command.Parameters.Add(new SQLiteParameter("@NhaSanXuat", NhaSanXuat));
            command.Parameters.Add(new SQLiteParameter("@NuocSanXuat", NuocSanXuat));
            command.Parameters.Add(new SQLiteParameter("@SoDangKy", SoDangKy));
            command.Parameters.Add(new SQLiteParameter("@HanSuDung", HanSuDung));
            command.Parameters.Add(new SQLiteParameter("@DonGiaMua", DonGiaMua));
            command.Parameters.Add(new SQLiteParameter("@DonGiaThau", DonGiaThau));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@SoLuong", SoLuong));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@TrongThau", TrongThau));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@VTYTThayThe", VTYTThayThe));
            command.Parameters.Add(new SQLiteParameter("@VTYTDichVuKTC", VTYTDichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@Nam", Nam));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaVTYTBYT", MaVTYTBYT));
            command.Parameters.Add(new SQLiteParameter("@TenVTYTBYT", TenVTYTBYT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
        public int Update()
        {
            m_dbConnection.Open();

            string sql = "";
            sql += " UPDATE DM_VTYT ";
            sql += " SET MaVTYT=@MaVTYT,TenVTYT=@TenVTYT,TenHoatChat=@TenHoatChat,DonViTinh=@DonViTinh,QuyCach=@QuyCach,NhaSanXuat=@NhaSanXuat,NuocSanXuat=@NuocSanXuat,SoDangKy=@SoDangKy,HanSuDung=@HanSuDung,SoLuong=@SoLuong,DonGiaMua=@DonGiaMua,DonGiaThau=@DonGiaThau,DonGiaCSKCB=@DonGiaCSKCB,MaNhom1=@MaNhom1,MaNhom2=@MaNhom2,TrongDanhMucBHYT=@TrongDanhMucBHYT,VTYTThayThe=@VTYTThayThe,VTYTDichVuKTC=@VTYTDichVuKTC,TrongThau=@TrongThau,Active=@Active,Nam=@Nam,STTBYT=@STTBYT,MaVTYTBYT=@MaVTYTBYT,TenVTYTBYT=@TenVTYTBYT,GhiChu=@GhiChu";
            sql += " WHERE MaVTYT=@MaVTYT";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaVTYT", MaVTYT));
            command.Parameters.Add(new SQLiteParameter("@TenVTYT", TenVTYT));
            command.Parameters.Add(new SQLiteParameter("@TenHoatChat", TenHoatChat));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@QuyCach", QuyCach));
            command.Parameters.Add(new SQLiteParameter("@NhaSanXuat", NhaSanXuat));
            command.Parameters.Add(new SQLiteParameter("@NuocSanXuat", NuocSanXuat));
            command.Parameters.Add(new SQLiteParameter("@SoDangKy", SoDangKy));
            command.Parameters.Add(new SQLiteParameter("@HanSuDung", HanSuDung));
            command.Parameters.Add(new SQLiteParameter("@DonGiaMua", DonGiaMua));
            command.Parameters.Add(new SQLiteParameter("@DonGiaThau", DonGiaThau));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@SoLuong", SoLuong));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@TrongThau", TrongThau));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@VTYTThayThe", VTYTThayThe));
            command.Parameters.Add(new SQLiteParameter("@VTYTDichVuKTC", VTYTDichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@Nam", Nam));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaVTYTBYT", MaVTYTBYT));
            command.Parameters.Add(new SQLiteParameter("@TenVTYTBYT", TenVTYTBYT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));


            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }


        public int Insert(SQLiteDAL DAL)
        {
            string sql = "";
            sql += " INSERT INTO DM_VTYT (MaVTYT,TenVTYT,TenHoatChat,DonViTinh,QuyCach,NhaSanXuat,NuocSanXuat,SoDangKy,HanSuDung,SoLuong,DonGiaMua,DonGiaThau,DonGiaCSKCB,MaNhom1,MaNhom2,TrongDanhMucBHYT,VTYTThayThe,VTYTDichVuKTC,TrongThau,Active,Nam,STTBYT,MaVTYTBYT,TenVTYTBYT,GhiChu) ";
            sql += " VALUES(@MaVTYT,@TenVTYT,@TenHoatChat,@DonViTinh,@QuyCach,@NhaSanXuat,@NuocSanXuat,@SoDangKy,@HanSuDung,@SoLuong,@DonGiaMua,@DonGiaThau,@DonGiaCSKCB,@MaNhom1,@MaNhom2,@TrongDanhMucBHYT,@VTYTThayThe,@VTYTDichVuKTC,@TrongThau,@Active,@Nam,@STTBYT,@MaVTYTBYT,@TenVTYTBYT,@GhiChu)";

            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaVTYT", MaVTYT));
            command.Parameters.Add(new SQLiteParameter("@TenVTYT", TenVTYT));
            command.Parameters.Add(new SQLiteParameter("@TenHoatChat", TenHoatChat));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@QuyCach", QuyCach));
            command.Parameters.Add(new SQLiteParameter("@NhaSanXuat", NhaSanXuat));
            command.Parameters.Add(new SQLiteParameter("@NuocSanXuat", NuocSanXuat));
            command.Parameters.Add(new SQLiteParameter("@SoDangKy", SoDangKy));
            command.Parameters.Add(new SQLiteParameter("@HanSuDung", HanSuDung));
            command.Parameters.Add(new SQLiteParameter("@DonGiaMua", DonGiaMua));
            command.Parameters.Add(new SQLiteParameter("@DonGiaThau", DonGiaThau));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@SoLuong", SoLuong));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@TrongThau", TrongThau));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@VTYTThayThe", VTYTThayThe));
            command.Parameters.Add(new SQLiteParameter("@VTYTDichVuKTC", VTYTDichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@Nam", Nam));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaVTYTBYT", MaVTYTBYT));
            command.Parameters.Add(new SQLiteParameter("@TenVTYTBYT", TenVTYTBYT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));

            int result = command.ExecuteNonQuery();
            //m_dbConnection.Close();
            return result;
        }
        public int Update(SQLiteDAL DAL)
        {
            string sql = "";
            sql += " UPDATE DM_VTYT ";
            sql += " SET MaVTYT=@MaVTYT,TenVTYT=@TenVTYT,TenHoatChat=@TenHoatChat,DonViTinh=@DonViTinh,QuyCach=@QuyCach,NhaSanXuat=@NhaSanXuat,NuocSanXuat=@NuocSanXuat,SoDangKy=@SoDangKy,HanSuDung=@HanSuDung,SoLuong=@SoLuong,DonGiaMua=@DonGiaMua,DonGiaThau=@DonGiaThau,DonGiaCSKCB=@DonGiaCSKCB,MaNhom1=@MaNhom1,MaNhom2=@MaNhom2,TrongDanhMucBHYT=@TrongDanhMucBHYT,VTYTThayThe=@VTYTThayThe,VTYTDichVuKTC=@VTYTDichVuKTC,TrongThau=@TrongThau,Active=@Active,Nam=@Nam,STTBYT=@STTBYT,MaVTYTBYT=@MaVTYTBYT,TenVTYTBYT=@TenVTYTBYT,GhiChu=@GhiChu";
            sql += " WHERE MaVTYT=@MaVTYT";


            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaVTYT", MaVTYT));
            command.Parameters.Add(new SQLiteParameter("@TenVTYT", TenVTYT));
            command.Parameters.Add(new SQLiteParameter("@TenHoatChat", TenHoatChat));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@QuyCach", QuyCach));
            command.Parameters.Add(new SQLiteParameter("@NhaSanXuat", NhaSanXuat));
            command.Parameters.Add(new SQLiteParameter("@NuocSanXuat", NuocSanXuat));
            command.Parameters.Add(new SQLiteParameter("@SoDangKy", SoDangKy));
            command.Parameters.Add(new SQLiteParameter("@HanSuDung", HanSuDung));
            command.Parameters.Add(new SQLiteParameter("@DonGiaMua", DonGiaMua));
            command.Parameters.Add(new SQLiteParameter("@DonGiaThau", DonGiaThau));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@SoLuong", SoLuong));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@TrongThau", TrongThau));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@VTYTThayThe", VTYTThayThe));
            command.Parameters.Add(new SQLiteParameter("@VTYTDichVuKTC", VTYTDichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@Nam", Nam));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaVTYTBYT", MaVTYTBYT));
            command.Parameters.Add(new SQLiteParameter("@TenVTYTBYT", TenVTYTBYT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));


            int result = command.ExecuteNonQuery();
            return result;
        }

        public int Delete(string strMaVTYT)
        {

            m_dbConnection.Open();

            string sql = "Delete from DM_VTYT WHERE MaVTYT=@MaVTYT";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaVTYT", strMaVTYT));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public bool CheckTonTai(string strMaVTYT)
        {

            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT MaVTYT FROM DM_VTYT WHERE MaVTYT=@MaVTYT";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaVTYT", strMaVTYT));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            clsDM_VTYT obj = new clsDM_VTYT();

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
