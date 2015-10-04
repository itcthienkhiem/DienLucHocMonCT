using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Inventory.EntityClass
{
  
 public   class clsPhieuNhapKho
    {
//     public int ID_phieu_nhap;
     public string Ma_phieu_nhap;
     public int ID_kho;
     public DateTime Ngay_lap;
     public string Ly_do;
     public string So_hoa_don;
     public string Dia_chi;
     public List<clsChi_Tiet_Phieu_Nhap_Vat_Tu> lstChiTietPhieuNhap = new List<clsChi_Tiet_Phieu_Nhap_Vat_Tu>();
       SqlConnection m_dbConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
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
       public DataTable GetAll()
       {
           m_dbConnection.Open();
           DataTable dt = new DataTable();
           string sql = "SELECT * FROM Phieu_Nhap_Kho ";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);
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
       public int Insert()
       {

           m_dbConnection.Open();

           string sql = "";
           sql += "INSERT INTO Phieu_Nhap_Kho (ma_phieu_nhap,ID_kho,Ngay_lap,ly_do,Dia_chi) ";
           sql += "VALUES(@ma_phieu_nhap,@ID_kho,@Ngay_lap,@ly_do,@Dia_chi)";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);
           command.CommandType = CommandType.Text;

           //command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
           command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));
           command.Parameters.Add(new SqlParameter("@ID_kho", ID_kho));
           command.Parameters.Add(new SqlParameter("@Ngay_lap", Ngay_lap.ToString("yyyy-MM-dd")));
           command.Parameters.Add(new SqlParameter("@Ly_do", Ly_do));
         //  command.Parameters.Add(new SqlParameter("@So_hoa_don", So_hoa_don));
           command.Parameters.Add(new SqlParameter("@Dia_chi", Dia_chi));


           //command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));

           int result = command.ExecuteNonQuery();
           m_dbConnection.Close();
           return result;
       }

       public int Update()
       {
           m_dbConnection.Open();

           string sql = "";
           sql += "UPDATE Phieu_Nhap_Kho ";
           sql += "Set ma_phieu_nhap=@ma_phieu_nhap,ID_kho=@ID_kho,Ngay_lap=@Ngay_lap,ly_do=@ly_do,so_hoa_don =@so_hoa_don,@dia_chi";
           sql += "WHERE ma_phieu_nhap=@ma_phieu_nhap";


           SqlCommand command = new SqlCommand(sql, m_dbConnection);
           command.CommandType = CommandType.Text;

           command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));
           command.Parameters.Add(new SqlParameter("@ID_kho", ID_kho));
           command.Parameters.Add(new SqlParameter("@Ngay_lap", Ngay_lap.ToString("yyyy-MM-dd")));
           command.Parameters.Add(new SqlParameter("@ly_do", Ly_do));
           command.Parameters.Add(new SqlParameter("@so_hoa_don", So_hoa_don));
           command.Parameters.Add(new SqlParameter("@dia_chi", Dia_chi));
           //command.Parameters.Add(new SqlParameter("@ID_kho", ID_kho));

           int result = command.ExecuteNonQuery();
           m_dbConnection.Close();
           return result;
       }
       public int Delete()
       {
           m_dbConnection.Open();

           string sql = "Delete from Phieu_Nhap_Kho WHERE ma_phieu_nhap=@ma_phieu_nhap";


           SqlCommand command = new SqlCommand(sql, m_dbConnection);
           command.CommandType = CommandType.Text;

           command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));

           int result = command.ExecuteNonQuery();
           m_dbConnection.Close();
           return result;
       }

    }
}
