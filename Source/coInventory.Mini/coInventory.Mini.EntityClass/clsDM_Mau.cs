using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Configuration;

namespace coInventory.Mini.EntityClass
{
    public class clsDM_Mau : clsDM_XuLy
    {

        public int Mau_Id;
        public string MaMauVaChePhamMau;
        public string TenMauVaChePhamMau;
        public string MaLoaiMauVaChePhamMau;
        public string DonViTinh;
        public decimal? DonGiaBHYT;
        public decimal? DonGiaCSKCB;
        public string MaNhom1;
        public string MaNhom2;
        public bool? TrongDanhMucBHYT = true;
        public bool? Active = true;
        public string ThongTu;
        public string STTBYT;
        public string MaMauVaChePhamMauBYT;
        public string GhiChu;

        SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public DataTable GetAll()
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_MauVaChePhamMau";
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
            string sql = "SELECT * FROM DM_MauVaChePhamMau WHERE MaMauVaChePhamMau=@MaMauVaChePhamMau";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaMauVaChePhamMau", strMa));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                Mau_Id = int.Parse(dt.Rows[0]["Mau_Id"].ToString());
                MaMauVaChePhamMau = dt.Rows[0]["MaMauVaChePhamMau"].ToString();
                TenMauVaChePhamMau = dt.Rows[0]["TenMauVaChePhamMau"].ToString();
                MaLoaiMauVaChePhamMau = dt.Rows[0]["MaLoaiMauVaChePhamMau"].ToString();
                DonViTinh = (dt.Rows[0]["DonViTinh"].ToString());
                DonGiaBHYT = string.IsNullOrEmpty(dt.Rows[0]["DonGiaBHYT"].ToString()) ? null : (decimal?)dt.Rows[0]["DonGiaBHYT"];
                DonGiaCSKCB = string.IsNullOrEmpty(dt.Rows[0]["DonGiaCSKCB"].ToString()) ? null : (decimal?)dt.Rows[0]["DonGiaCSKCB"];
                MaNhom1 = dt.Rows[0]["MaNhom1"].ToString();
                MaNhom2 = (dt.Rows[0]["MaNhom2"].ToString());
                TrongDanhMucBHYT = string.IsNullOrEmpty(dt.Rows[0]["TrongDanhMucBHYT"].ToString()) ? null : (bool?)dt.Rows[0]["TrongDanhMucBHYT"];
                Active = string.IsNullOrEmpty(dt.Rows[0]["Active"].ToString()) ? null : (bool?)dt.Rows[0]["Active"];
                ThongTu = dt.Rows[0]["ThongTu"].ToString();
                STTBYT = dt.Rows[0]["STTBYT"].ToString();
                MaMauVaChePhamMauBYT = dt.Rows[0]["MaMauVaChePhamMauBYT"].ToString();
                GhiChu = dt.Rows[0]["GhiChu"].ToString();
            }

        }


        public int Insert()
        {
            m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO DM_MauVaChePhamMau (MaMauVaChePhamMau,TenMauVaChePhamMau,MaLoaiMauVaChePhamMau,DonViTinh,DonGiaBHYT,DonGiaCSKCB,MaNhom1,MaNhom2,TrongDanhMucBHYT,Active,ThongTu,STTBYT,MaMauVaChePhamMauBYT,GhiChu) ";
            sql += " VALUES(@MaMauVaChePhamMau,@TenMauVaChePhamMau,@MaLoaiMauVaChePhamMau,@DonViTinh,@DonGiaBHYT,@DonGiaCSKCB,@MaNhom1,@MaNhom2,@TrongDanhMucBHYT,@Active,@ThongTu,@STTBYT,@MaMauVaChePhamMauBYT,@GhiChu)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaMauVaChePhamMau", MaMauVaChePhamMau));
            command.Parameters.Add(new SQLiteParameter("@TenMauVaChePhamMau", TenMauVaChePhamMau));
            command.Parameters.Add(new SQLiteParameter("@MaLoaiMauVaChePhamMau", MaLoaiMauVaChePhamMau));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@DonGiaBHYT", DonGiaBHYT));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@ThongTu", ThongTu));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaMauVaChePhamMauBYT", MaMauVaChePhamMauBYT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public int Update()
        {
            m_dbConnection.Open();

            string sql = "";
            sql += "UPDATE DM_MauVaChePhamMau SET MaMauVaChePhamMau=@MaMauVaChePhamMau,TenMauVaChePhamMau=@TenMauVaChePhamMau,MaLoaiMauVaChePhamMau=@MaLoaiMauVaChePhamMau,DonViTinh=@DonViTinh,DonGiaBHYT=@DonGiaBHYT,MaNhom1=@MaNhom1,MaNhom2=@MaNhom2,";
            sql += "TrongDanhMucBHYT=@TrongDanhMucBHYT,Active=@Active,ThongTu=@ThongTu,STTBYT=@STTBYT,MaMauVaChePhamMauBYT=@MaMauVaChePhamMauBYT,GhiChu=@GhiChu,DonGiaCSKCB=@DonGiaCSKCB ";
            sql += "WHERE MaMauVaChePhamMau=@MaMauVaChePhamMau";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaMauVaChePhamMau", MaMauVaChePhamMau));
            command.Parameters.Add(new SQLiteParameter("@TenMauVaChePhamMau", TenMauVaChePhamMau));
            command.Parameters.Add(new SQLiteParameter("@MaLoaiMauVaChePhamMau", MaLoaiMauVaChePhamMau));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@DonGiaBHYT", DonGiaBHYT));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@ThongTu", ThongTu));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaMauVaChePhamMauBYT", MaMauVaChePhamMauBYT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));
            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
        //Insert Trans
        public int Insert(SQLiteDAL DAL)
        {

            string sql = "";
            sql += "INSERT INTO DM_MauVaChePhamMau (MaMauVaChePhamMau,TenMauVaChePhamMau,MaLoaiMauVaChePhamMau,DonViTinh,DonGiaBHYT,DonGiaCSKCB,MaNhom1,MaNhom2,TrongDanhMucBHYT,Active,ThongTu,STTBYT,MaMauVaChePhamMauBYT,GhiChu) ";
            sql += " VALUES(@MaMauVaChePhamMau,@TenMauVaChePhamMau,@MaLoaiMauVaChePhamMau,@DonViTinh,@DonGiaBHYT,@DonGiaCSKCB,@MaNhom1,@MaNhom2,@TrongDanhMucBHYT,@Active,@ThongTu,@STTBYT,@MaMauVaChePhamMauBYT,@GhiChu)";


            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaMauVaChePhamMau", MaMauVaChePhamMau));
            command.Parameters.Add(new SQLiteParameter("@TenMauVaChePhamMau", TenMauVaChePhamMau));
            command.Parameters.Add(new SQLiteParameter("@MaLoaiMauVaChePhamMau", MaLoaiMauVaChePhamMau));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@DonGiaBHYT", DonGiaBHYT));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@ThongTu", ThongTu));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaMauVaChePhamMauBYT", MaMauVaChePhamMauBYT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));

            int result = command.ExecuteNonQuery();
            return result;
        }
        //Update trans
        public int Update(SQLiteDAL DAL)
        {

            string sql = "";
            sql += "UPDATE DM_MauVaChePhamMau SET MaMauVaChePhamMau=@MaMauVaChePhamMau,TenMauVaChePhamMau=@TenMauVaChePhamMau,MaLoaiMauVaChePhamMau=@MaLoaiMauVaChePhamMau,DonViTinh=@DonViTinh,DonGiaBHYT=@DonGiaBHYT,MaNhom1=@MaNhom1,MaNhom2=@MaNhom2,";
            sql += "TrongDanhMucBHYT=@TrongDanhMucBHYT,Active=@Active,ThongTu=@ThongTu,STTBYT=@STTBYT,MaMauVaChePhamMauBYT=@MaMauVaChePhamMauBYT,GhiChu=@GhiChu,DonGiaCSKCB=@DonGiaCSKCB ";
            sql += "WHERE MaMauVaChePhamMau=@MaMauVaChePhamMau";



            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;

            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SQLiteParameter("@MaMauVaChePhamMau", MaMauVaChePhamMau));
            command.Parameters.Add(new SQLiteParameter("@TenMauVaChePhamMau", TenMauVaChePhamMau));
            command.Parameters.Add(new SQLiteParameter("@MaLoaiMauVaChePhamMau", MaLoaiMauVaChePhamMau));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@DonGiaBHYT", DonGiaBHYT));
            command.Parameters.Add(new SQLiteParameter("@DonGiaCSKCB", DonGiaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@TrongDanhMucBHYT", TrongDanhMucBHYT));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@ThongTu", ThongTu));
            command.Parameters.Add(new SQLiteParameter("@STTBYT", STTBYT));
            command.Parameters.Add(new SQLiteParameter("@MaMauVaChePhamMauBYT", MaMauVaChePhamMauBYT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));

            int result = command.ExecuteNonQuery();
            return result;
        }

        public int Delete(string strMa)
        {
            m_dbConnection.Open();

            string sql = "Delete from DM_MauVaChePhamMau WHERE MaMauVaChePhamMau=@MaMauVaChePhamMau";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SQLiteParameter("@MaMauVaChePhamMau", strMa));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public bool CheckTonTai(string strMa)
        {

            DataTable dt = new DataTable();
            string sql = "SELECT MaMauVaChePhamMau FROM DM_MauVaChePhamMau WHERE MaMauVaChePhamMau=@MaMauVaChePhamMau";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaMauVaChePhamMau", strMa));
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
