using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Inventory.EntityClass
{
   public class clsChi_Tiet_Phieu_Nhap_Vat_Tu
    {
        public int? ID_chi_tiet_phieu_nhap;
        public string Ma_phieu_nhap;
        public string Ma_vat_tu;
        public string Chat_luong;
        public string Don_vi;
        public int? So_luong_yeu_cau;
        public int? So_luong_thuc_nhap;
        public int? Don_gia;
        public int? Thanh_tien;
        public int? ID_Don_vi_tinh;
        //public int? ID_Don_vi_tinh;

        SqlConnection m_dbConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        public DataTable GetAll()
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Chi_Tiet_Phieu_Nhap_Vat_Tu";
            SqlCommand command = new SqlCommand(sql, m_dbConnection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }
        public int removebyKey(SQLDAL DAL, string ma_Phieunhap,string ma_vat_tu)
        {
            DAL.BeginTransaction();

            m_dbConnection = DAL.m_conn;
            if (m_dbConnection.State == ConnectionState.Closed)
                m_dbConnection.Open();
            string sql = "Delete from Chi_Tiet_Phieu_Nhap_Vat_Tu WHERE Ma_phieu_nhap=@Ma_phieu_nhap and ma_vat_tu =@ma_vat_tu";


            SqlCommand command = new SqlCommand(sql, m_dbConnection, DAL.m_trans);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", ma_Phieunhap));
            command.Parameters.Add(new SqlParameter("@Ma_vat_tu", ma_vat_tu));

            int result = command.ExecuteNonQuery();
            DAL.CommitTransaction();

            return result;
        }
        public DataTable GetAll(string ma_Phieunhap)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT Chi_Tiet_Phieu_Nhap_Vat_Tu.ma_vat_tu,dm_vat_tu.ten_vat_tu,Chi_Tiet_Phieu_Nhap_Vat_Tu.Chat_luong";
            sql += ", Chi_Tiet_Phieu_Nhap_Vat_Tu. So_luong_yeu_cau, Chi_Tiet_Phieu_Nhap_Vat_Tu. So_luong_thuc_lanh,Chi_Tiet_Phieu_Nhap_Vat_Tu.Thanh_tien, dm_vat_tu.Don_gia, dm_don_vi_tinh.ten_don_vi_tinh, Chi_Tiet_Phieu_Nhap_Vat_Tu.ID_don_vi_tinh FROM Chi_Tiet_Phieu_Nhap_Vat_Tu ";
            sql += " join dm_vat_tu on dm_vat_tu.ma_vat_tu = Chi_Tiet_Phieu_Nhap_Vat_Tu.ma_vat_tu";
            sql += " join dm_don_vi_tinh on dm_don_vi_tinh.ID_Don_vi_tinh =dm_vat_tu.ID_Don_vi_tinh ";
            sql+= " WHERE Ma_phieu_nhap=@Ma_phieu_nhap";
            SqlCommand command = new SqlCommand(sql, m_dbConnection);
            command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", ma_Phieunhap));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public bool CheckTonTaiSoDK()
        {

            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Chi_Tiet_Phieu_Nhap_Vat_Tu WHERE Ma_phieu_nhap=@Ma_phieu_nhap";
            SqlCommand command = new SqlCommand(sql, m_dbConnection);
            command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", Ma_phieu_nhap));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public int Insert(SQLDAL DAL)
        {
            DAL.BeginTransaction();
       
            m_dbConnection = DAL.m_conn;
            if (m_dbConnection.State == ConnectionState.Closed)
            m_dbConnection.Open();
            string sql = "";
            sql += "INSERT INTO Chi_Tiet_Phieu_Nhap_Vat_Tu (Ma_phieu_nhap,ma_vat_tu,Chat_luong,So_luong_yeu_cau,So_luong_thuc_lanh,don_gia,thanh_tien, ID_Don_vi_tinh) ";
            sql += "VALUES(@Ma_phieu_nhap,@ma_vat_tu,@Chat_luong,@So_luong_yeu_cau,@So_luong_thuc_lanh,@don_gia,@thanh_tien, @ID_Don_vi_tinh)";

            SqlCommand command = new SqlCommand(sql, m_dbConnection,DAL.m_trans);
            command.CommandType = CommandType.Text;

            //command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
            command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", Ma_phieu_nhap));
            command.Parameters.Add(new SqlParameter("@ma_vat_tu", Ma_vat_tu));
            command.Parameters.Add(new SqlParameter("@Chat_luong", Chat_luong));
            command.Parameters.Add(new SqlParameter("@Don_gia", Don_gia));
            command.Parameters.Add(new SqlParameter("@Thanh_tien", Thanh_tien));
            command.Parameters.Add(new SqlParameter("@So_luong_yeu_cau", So_luong_yeu_cau));
            command.Parameters.Add(new SqlParameter("@So_luong_thuc_lanh", So_luong_thuc_nhap));
           // command.Parameters.Add(new SqlParameter("@Dia_chi", Dia_chi));
            command.Parameters.Add(new SqlParameter("@ID_Don_vi_tinh", ID_Don_vi_tinh));


            //command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));

            int result = command.ExecuteNonQuery();
            DAL.CommitTransaction();

            return result;
        }

        public int Update(SQLDAL DAL)
        {
            DAL.BeginTransaction();
       
            m_dbConnection = DAL.m_conn;
            if (m_dbConnection.State == ConnectionState.Closed)
                m_dbConnection.Open();
            string sql = "";
            sql += "UPDATE Chi_Tiet_Phieu_Nhap_Vat_Tu ";
            sql += "Set Ma_phieu_nhap=@Ma_phieu_nhap,ma_vat_tu=@ma_vat_tu,Chat_luong=@Chat_luong,Don_vi=@Don_vi,So_luong_yeu_cau =@So_luong_yeu_cau,So_luong_thuc_nhap = @So_luong_thuc_nhap, ID_Don_vi_tinh= @ID_Don_vi_tinh ";
            sql += "WHERE Ma_phieu_nhap=@Ma_phieu_nhap";


            SqlCommand command = new SqlCommand(sql, m_dbConnection, DAL.m_trans);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", Ma_phieu_nhap));
            command.Parameters.Add(new SqlParameter("@ma_vat_tu", Ma_vat_tu));
            command.Parameters.Add(new SqlParameter("@Chat_luong", Chat_luong));
            command.Parameters.Add(new SqlParameter("@Don_vi", Don_vi));

            command.Parameters.Add(new SqlParameter("@So_luong_yeu_cau", So_luong_yeu_cau));
            command.Parameters.Add(new SqlParameter("@So_luong_thuc_nhap", So_luong_thuc_nhap));
            command.Parameters.Add(new SqlParameter("@ID_don_vi_tinh", ID_Don_vi_tinh));

            //command.Parameters.Add(new SqlParameter("@ID_kho", ID_kho));

            int result = command.ExecuteNonQuery();
            DAL.CommitTransaction();

            //m_dbConnection.Close();
            return result;
        }
        public int Delete(SQLDAL DAL)
        {
            DAL.BeginTransaction();
       
            m_dbConnection = DAL.m_conn;
            if (m_dbConnection.State == ConnectionState.Closed)
                m_dbConnection.Open();
            string sql = "Delete from Chi_Tiet_Phieu_Nhap_Vat_Tu WHERE Ma_phieu_nhap=@Ma_phieu_nhap and ma_vat_tu =@ma_vat_tu";


            SqlCommand command = new SqlCommand(sql, m_dbConnection, DAL.m_trans);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", Ma_phieu_nhap));
            command.Parameters.Add(new SqlParameter("@Ma_vat_tu", Ma_vat_tu));

            int result = command.ExecuteNonQuery();
            DAL.CommitTransaction();

            return result;
        }
    }
}
