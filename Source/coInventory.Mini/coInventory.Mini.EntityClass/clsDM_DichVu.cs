using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Configuration;

namespace coInventory.Mini.EntityClass
{
  public  class clsDM_DichVu
    {
        public int DichVu_Id;
        public string MaDichVu;
        public string TenDichVu;
        public string MaLoaiDichVu;
        public string DonViTinh;
        public decimal? DonGiaBHYT;
        public decimal? DonGiaCSKCB;
        public string MaNhom1;
        public string MaNhom2;
        public bool? TrongDanhMucBHYT = true;
        public bool? DichVuKTC = false;
        public bool? Active = true;
        public string ThongTu;
        public string STTBYT;
        public string MaKhac;
        public string MaLoaiChiPhi;
        public string MaDichVuBYT;
        public string GhiChu;

         SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public DataTable GetAll()
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_DichVu";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public void GetByKey(string strMa)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_DichVu WHERE MaDichVu=@MaDichVu";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaDichVu", strMa));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                DichVu_Id = int.Parse(dt.Rows[0]["DichVu_Id"].ToString());
                MaDichVu = dt.Rows[0]["MaDichVu"].ToString();
                TenDichVu = dt.Rows[0]["TenDichVu"].ToString();
                MaLoaiDichVu = dt.Rows[0]["MaLoaiDichVu"].ToString();
                DonViTinh = dt.Rows[0]["DonViTinh"].ToString();
                DonGiaBHYT = string.IsNullOrEmpty(dt.Rows[0]["DonGiaBHYT"].ToString()) ? null : (decimal?)dt.Rows[0]["DonGiaBHYT"];
                DonGiaCSKCB = string.IsNullOrEmpty(dt.Rows[0]["DonGiaCSKCB"].ToString()) ? null : (decimal?)dt.Rows[0]["DonGiaCSKCB"];
                MaNhom1 = dt.Rows[0]["MaNhom1"].ToString();
                MaNhom2 = dt.Rows[0]["MaNhom2"].ToString();
                TrongDanhMucBHYT = string.IsNullOrEmpty(dt.Rows[0]["TrongDanhMucBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["TrongDanhMucBHYT"];
                Active = string.IsNullOrEmpty(dt.Rows[0]["Active"].ToString()) ? null : (bool?)dt.Rows[0]["Active"];
                DichVuKTC = string.IsNullOrEmpty(dt.Rows[0]["DichVuKTC"].ToString()) ? null : (bool?)dt.Rows[0]["DichVuKTC"]; 
               
                ThongTu = dt.Rows[0]["ThongTu"].ToString();
                STTBYT = dt.Rows[0]["STTBYT"].ToString();
                MaKhac = dt.Rows[0]["MaKhac"].ToString();
              

                MaLoaiChiPhi = dt.Rows[0]["MaLoaiChiPhi"].ToString();
                MaDichVuBYT = dt.Rows[0]["MaDichVuBYT"].ToString();
                GhiChu = dt.Rows[0]["GhiChu"].ToString();
            }
        }


        public int Insert()
        {

            m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO DM_DichVu (MaDichVu,TenDichVu,MaLoaiDichVu,DonViTinh,DonGiaBHYT,DonGiaCSKCB,MaNhom1,MaNhom2,TrongDanhMucBHYT,Active, DichVuKTC,ThongTu,STTBYT,MaKhac,MaLoaiChiPhi,MaDichVuBYT,GhiChu) ";
            sql += " VALUES(@MaDichVu,@TenDichVu,@MaLoaiDichVu,@DonViTinh,@DonGiaBHYT,@DonGiaCSKCB,@MaNhom1,@MaNhom2,@TrongDanhMucBHYT,@Active,@DichVuKTC,@ThongTu,@STTBYT,@MaKhac,@MaLoaiChiPhi,@MaDichVuBYT,@GhiChu)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaDichVu", MaDichVu));
            command.Parameters.Add(new SQLiteParameter("@TenDichVu", TenDichVu));
            command.Parameters.Add(new SQLiteParameter("@MaLoaiDichVu", MaLoaiDichVu));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@DonGiaBHYT", DonGiaBHYT));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@DichVuKTC", DichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@ThongTu", ThongTu));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaKhac", MaKhac));
            command.Parameters.Add(new SQLiteParameter("@MaLoaiChiPhi", MaLoaiChiPhi));
            command.Parameters.Add(new SQLiteParameter("@MaDichVuBYT", MaDichVuBYT));

            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        //Insert trans
        public int Insert(SQLiteDAL DAL)
        {
            string sql = "";
            sql += "INSERT INTO DM_DichVu (MaDichVu,TenDichVu,MaLoaiDichVu,DonViTinh,DonGiaBHYT,DonGiaCSKCB,MaNhom1,MaNhom2,TrongDanhMucBHYT,Active,DichVuKTC,ThongTu,STTBYT,MaKhac,MaLoaiChiPhi,MaDichVuBYT,GhiChu) ";
            sql += " VALUES(@MaDichVu,@TenDichVu,@MaLoaiDichVu,@DonViTinh,@DonGiaBHYT,@DonGiaCSKCB,@MaNhom1,@MaNhom2,@TrongDanhMucBHYT,@Active,@DichVuKTC,@ThongTu,@STTBYT,@MaKhac,@MaLoaiChiPhi,@MaDichVuBYT,@GhiChu)";

            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaDichVu", MaDichVu));
            command.Parameters.Add(new SQLiteParameter("@TenDichVu", TenDichVu));
            command.Parameters.Add(new SQLiteParameter("@MaLoaiDichVu", MaLoaiDichVu));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@DonGiaBHYT", DonGiaBHYT));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@DichVuKTC", DichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@ThongTu", ThongTu));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaKhac", MaKhac));
            command.Parameters.Add(new SQLiteParameter("@MaLoaiChiPhi", MaLoaiChiPhi));
            command.Parameters.Add(new SQLiteParameter("@MaDichVuBYT", MaDichVuBYT));

            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));

            int result = command.ExecuteNonQuery();
            return result;
        }

        public int Update()
        {
            m_dbConnection.Open();

            string sql = "";
            sql += "UPDATE DM_DichVu SET MaDichVu=@MaDichVu,TenDichVu=@TenDichVu,MaLoaiDichVu=@MaLoaiDichVu,DonViTinh=@DonViTinh,DonGiaBHYT=@DonGiaBHYT,DonGiaCSKCB = @DonGiaCSKCB,MaNhom1=@MaNhom1,MaNhom2=@MaNhom2,";
            sql += "TrongDanhMucBHYT=@TrongDanhMucBHYT,Active=@Active,DichVuKTC=@DichVuKTC,ThongTu=@ThongTu,STTBYT=@STTBYT,MaKhac=@MaKhac,MaLoaiChiPhi=@MaLoaiChiPhi,MaDichVuBYT=@MaDichVuBYT,GhiChu=@GhiChu ";
            sql += "WHERE MaDichVu=@MaDichVu";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;


            command.Parameters.Add(new SQLiteParameter("@MaDichVu", MaDichVu));
            command.Parameters.Add(new SQLiteParameter("@TenDichVu", TenDichVu));
            command.Parameters.Add(new SQLiteParameter("@MaLoaiDichVu", MaLoaiDichVu));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@DonGiaBHYT", DonGiaBHYT));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@DichVuKTC", DichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@ThongTu", ThongTu));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaKhac", MaKhac));
            command.Parameters.Add(new SQLiteParameter("@MaLoaiChiPhi", MaLoaiChiPhi));
            command.Parameters.Add(new SQLiteParameter("@MaDichVuBYT", MaDichVuBYT));

            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
       
      //Update Trans
        public int Update(SQLiteDAL DAL)
        {
            

            string sql = "";
            sql += "UPDATE DM_DichVu SET MaDichVu=@MaDichVu,TenDichVu=@TenDichVu,MaLoaiDichVu=@MaLoaiDichVu,DonViTinh=@DonViTinh,DonGiaBHYT=@DonGiaBHYT,DonGiaCSKCB = @DonGiaCSKCB,MaNhom1=@MaNhom1,MaNhom2=@MaNhom2,";
            sql += "TrongDanhMucBHYT=@TrongDanhMucBHYT,Active=@Active,DichVuKTC=@DichVuKTC,ThongTu=@ThongTu,STTBYT=@STTBYT,MaKhac=@MaKhac,MaLoaiChiPhi=@MaLoaiChiPhi,MaDichVuBYT=@MaDichVuBYT,GhiChu=@GhiChu ";
            sql += "WHERE MaDichVu=@MaDichVu";



            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;


            command.Parameters.Add(new SQLiteParameter("@MaDichVu", MaDichVu));
            command.Parameters.Add(new SQLiteParameter("@TenDichVu", TenDichVu));
            command.Parameters.Add(new SQLiteParameter("@MaLoaiDichVu", MaLoaiDichVu));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@DonGiaBHYT", DonGiaBHYT));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@DichVuKTC", DichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@ThongTu", ThongTu));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaKhac", MaKhac));
            command.Parameters.Add(new SQLiteParameter("@MaLoaiChiPhi", MaLoaiChiPhi));
            command.Parameters.Add(new SQLiteParameter("@MaDichVuBYT", MaDichVuBYT));

            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));

            int result = command.ExecuteNonQuery();
          
            return result;
        }

        public int Delete(string strMa)
        {
            m_dbConnection.Open();

            string sql = "Delete from DM_DichVu WHERE MaDichVu=@MaDichVu";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaDichVu", strMa));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public bool CheckTonTai(string strMa)
        {

            DataTable dt = new DataTable();
            string sql = "SELECT MaDichVu FROM DM_DichVu WHERE MaDichVu=@MaDichVu";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaDichVu", strMa));
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
