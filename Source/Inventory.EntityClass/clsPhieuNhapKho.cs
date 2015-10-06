using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Inventory.EntityClass
{

    /// <summary>
    /// [ ] func GetALL
    /// [ ]
    /// </summary>
    public class clsPhieuNhapKho
    {
        public string Ma_phieu_nhap;
        public int ID_kho;
        public DateTime Ngay_lap;
        public string Ly_do;
        public string So_hoa_don;
        public string Dia_chi;
        public string Cong_trinh;


        public List<clsChi_Tiet_Phieu_Nhap_Vat_Tu> lstChiTietPhieuNhap = new List<clsChi_Tiet_Phieu_Nhap_Vat_Tu>();
        SqlConnection m_dbConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public clsPhieuNhapKho()
        {
        }

        /// <summary>
        /// Get tất cả dữ liệu từ CSDL, dùng cho Grid
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAll()
        {
            m_dbConnection.Open();

            DataTable dt = new DataTable();
            //string sql = "SELECT * FROM DM_Vat_Tu";
            string sql = "";
            sql += "SELECT ";
            sql +=      "Phieu_Nhap_Kho.Ma_phieu_nhap, ";
            sql +=      "DM_Kho.Ten_kho, ";
            sql +=      "Phieu_Nhap_Kho.Ngay_lap, ";
            sql +=      "Phieu_Nhap_Kho.Ly_do, ";
            sql +=      "Phieu_Nhap_Kho.So_hoa_don, ";
            sql +=      "Phieu_Nhap_Kho.Cong_trinh, ";
            sql +=      "Phieu_Nhap_Kho.Dia_Chi ";
            sql += "FROM Phieu_Nhap_Kho ";
            sql += "INNER ";
            sql +=      "JOIN DM_Kho ";
            sql +=      "ON Phieu_Nhap_Kho.ID_kho=DM_Kho.ID_kho";

            SqlCommand command = new SqlCommand(sql, m_dbConnection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            return dt;
        }
        // End GetAll

        //public DataTable GetAll()
        //{
        //    m_dbConnection.Open();
        //    DataTable dt = new DataTable();

        //    string sql = "SELECT * FROM Phieu_Nhap_Kho ";

        //    SqlCommand command = new SqlCommand(sql, m_dbConnection);
        //    SqlDataAdapter da = new SqlDataAdapter(command);
        //    da.Fill(dt);
        //    m_dbConnection.Close();
        //    return dt;
        //}

        public DataTable GetAll(string maPhieu)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();

            string sql = "SELECT * FROM Phieu_Nhap_Kho WHERE Ma_phieu_nhap=@Ma_phieu_nhap";
            SqlCommand command = new SqlCommand(sql, m_dbConnection);
            command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", maPhieu));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);

            m_dbConnection.Close();
            return dt;
        }

        
        public bool CheckTonTaiSoDK()
        {

            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Phieu_Nhap_Kho WHERE ma_phieu_nhap=@ma_phieu_nhap";
            SqlCommand command = new SqlCommand(sql, m_dbConnection);
            command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public int Insert(SQLDAL dal)
        {
            dal.BeginTransaction();
       
            m_dbConnection = dal.m_conn;
            if(m_dbConnection.State == ConnectionState.Closed)
                m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO Phieu_Nhap_Kho (ma_phieu_nhap,ID_kho,Ngay_lap,ly_do,Dia_chi,Cong_trinh) ";
            sql += "VALUES(@ma_phieu_nhap,@ID_kho,@Ngay_lap,@ly_do,@Dia_chi,@Cong_trinh)";

            SqlCommand command = new SqlCommand(sql, m_dbConnection,dal.m_trans);
            command.CommandType = CommandType.Text;

            //command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
            command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));
            command.Parameters.Add(new SqlParameter("@ID_kho", ID_kho));
            command.Parameters.Add(new SqlParameter("@Ngay_lap", Ngay_lap.ToString("yyyy-MM-dd")));
            command.Parameters.Add(new SqlParameter("@Ly_do", Ly_do));
            //  command.Parameters.Add(new SqlParameter("@So_hoa_don", So_hoa_don));
            command.Parameters.Add(new SqlParameter("@Dia_chi", Dia_chi));
            command.Parameters.Add(new SqlParameter("@Cong_trinh", Cong_trinh));


            //command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));

            int result = command.ExecuteNonQuery();
            dal.CommitTransaction();
           
            return result;
        }

        public int Update(SQLDAL DAL)
        {
            DAL.BeginTransaction();
       
            m_dbConnection = DAL.m_conn;
            if (m_dbConnection.State == ConnectionState.Closed)
            m_dbConnection.Open();

            string sql = "";
            sql += "UPDATE Phieu_Nhap_Kho ";
            sql += "Set ma_phieu_nhap=@ma_phieu_nhap,ID_kho=@ID_kho,Ngay_lap=@Ngay_lap,ly_do=@ly_do,dia_chi = @dia_chi,cong_trinh = @cong_trinh ";
            sql += "WHERE ma_phieu_nhap=@ma_phieu_nhap";


            SqlCommand command = new SqlCommand(sql, m_dbConnection,DAL.m_trans);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));
            command.Parameters.Add(new SqlParameter("@ID_kho", ID_kho));
            command.Parameters.Add(new SqlParameter("@Ngay_lap", Ngay_lap.ToString("yyyy-MM-dd")));
            command.Parameters.Add(new SqlParameter("@ly_do", Ly_do));
            //  command.Parameters.Add(new SqlParameter("@so_hoa_don", So_hoa_don));
            command.Parameters.Add(new SqlParameter("@dia_chi", Dia_chi));
            command.Parameters.Add(new SqlParameter("@Cong_trinh", Cong_trinh));
           
            int result = command.ExecuteNonQuery();
            DAL.CommitTransaction();
            return result;
        }
        public int Delete(SQLDAL DAL)
        {
            DAL.BeginTransaction();
       
            m_dbConnection = DAL.m_conn;
            if (m_dbConnection.State == ConnectionState.Closed)
            m_dbConnection.Open();
            string sql = "Delete from Phieu_Nhap_Kho WHERE ma_phieu_nhap=@ma_phieu_nhap";


            SqlCommand command = new SqlCommand(sql, m_dbConnection, DAL.m_trans);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));

            int result = command.ExecuteNonQuery();
            DAL.CommitTransaction();
            return result;
        }

    }
}
