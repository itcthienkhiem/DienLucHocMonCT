using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Inventory.Utilities;
namespace Inventory.EntityClass
{
   public  class clsPhieuXuatTamVatTu
    {
     //  public 
       public int? ID_Nhan_vien;
       public int? ID_kho;
       public string Ma_phieu_xuat_tam;
       public DateTime Ngay_xuat;
       public string Ly_do;
       public string Cong_trinh;
       public string Dia_chi;
       public DateTime Ngay_lap;
       public clsPhieuXuatTamVatTu()
       { 
       }
              SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);

         public DataTable GetAll(string maPhieu)
       {
           m_dbConnection.Open();
           DataTable dt = new DataTable();
           string sql = "SELECT * FROM Phieu_xuat_tam_vat_tu ";
           sql += "join Dm_nhan_vien on Dm_nhan_vien.ID_Nhan_vien  = Phieu_xuat_tam_vat_tu.ID_nhan_vien";
             sql +=" WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam";
           SqlCommand command = new SqlCommand(sql, m_dbConnection);
           command.Parameters.Add(new SqlParameter("@Ma_phieu_xuat_tam", maPhieu));
           SqlDataAdapter da = new SqlDataAdapter(command);
           da.Fill(dt);
           m_dbConnection.Close();
           return dt;
       }
       public DataTable GetAll()
       {
           m_dbConnection.Open();
           DataTable dt = new DataTable();
           string sql = "SELECT * FROM Phieu_xuat_tam_vat_tu ";

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
           string sql = "SELECT * FROM Phieu_xuat_tam_vat_tu WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam";
           SqlCommand command = new SqlCommand(sql, m_dbConnection);
           command.Parameters.Add(new SqlParameter("@Ma_phieu_xuat_tam", Ma_phieu_xuat_tam));
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
           sql += "INSERT INTO Phieu_xuat_tam_vat_tu (ma_phieu_xuat_tam,ID_kho,ID_nhan_vien,ngay_xuat,Ly_do,Cong_trinh,Dia_chi) ";
           sql += "VALUES(@ma_phieu_xuat_tam,@ID_kho,@ID_nhan_vien,@ngay_xuat,@Ly_do,@Cong_trinh,@Dia_chi)";

           SqlCommand command = new SqlCommand(sql, m_dbConnection,dal.m_trans);
           command.CommandType = CommandType.Text;

           //command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
           command.Parameters.Add(new SqlParameter("@Ma_phieu_xuat_tam", Ma_phieu_xuat_tam));
           command.Parameters.Add(new SqlParameter("@ID_kho", ID_kho));

           command.Parameters.Add(new SqlParameter("@ngay_xuat", Ngay_xuat.ToString("yyyy-MM-dd")));
           command.Parameters.Add(new SqlParameter("@ID_nhan_vien", ID_Nhan_vien));

           command.Parameters.Add(new SqlParameter("@Ly_do", Ly_do));

           command.Parameters.Add(new SqlParameter("@Cong_trinh", Cong_trinh));

           command.Parameters.Add(new SqlParameter("@Dia_chi", Dia_chi));

          // command.Parameters.Add(new SqlParameter("@Ly_do", Ly_do));

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
           sql += "UPDATE Phieu_xuat_tam_vat_tu ";
           sql += "Set ma_phieu_xuat_tam=@ma_phieu_xuat_tam,ID_kho=@ID_kho,ID_nhan_vien=@ID_nhan_vien,ngay_xuat=@ngay_xuat,Ly_do = @Ly_do ";
           sql += "WHERE ma_phieu_xuat_tam=@ma_phieu_xuat_tam";


           SqlCommand command = new SqlCommand(sql, m_dbConnection,DAL.m_trans);
           command.CommandType = CommandType.Text;

           command.Parameters.Add(new SqlParameter("@ma_phieu_xuat_tam", Ma_phieu_xuat_tam));
           command.Parameters.Add(new SqlParameter("@ID_kho", ID_kho));
           command.Parameters.Add(new SqlParameter("@ngay_xuat", Ngay_xuat.ToString("yyyy-MM-dd")));
           command.Parameters.Add(new SqlParameter("@ID_nhan_vien", ID_Nhan_vien));
         //  command.Parameters.Add(new SqlParameter("@so_hoa_don", So_hoa_don));
           command.Parameters.Add(new SqlParameter("@Ly_do", Ly_do));
           
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
           string sql = "Delete from Phieu_xuat_tam_vat_tu WHERE ma_phieu_xuat_tam=@ma_phieu_xuat_tam";


           SqlCommand command = new SqlCommand(sql, m_dbConnection, DAL.m_trans);
           command.CommandType = CommandType.Text;

           command.Parameters.Add(new SqlParameter("@ma_phieu_xuat_tam", Ma_phieu_xuat_tam));

           int result = command.ExecuteNonQuery();
           DAL.CommitTransaction();
           return result;
       }

    }
}

   