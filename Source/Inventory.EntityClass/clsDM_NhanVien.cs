using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Inventory.Utilities;
namespace Inventory.EntityClass
{
    /// <summary>
    /// To-do LIST
    /// - Connection
    /// - Check duplicate rows
    /// - Insert
    /// - Update
    /// - Delete
    /// </summary>
    public class clsDM_NhanVien
    {
       //List var dùng trong DM Vat Tu
       public int ID_nhan_vien;
       public string Ten_nhan_vien;
       //public int ID_kho;
       public string Ma_nhan_vien;
       //public int Ten_kho;
       public bool Trang_thai;

       public SortedDictionary<string, int> dicKho = new SortedDictionary<string, int>();
       //--~

       public clsDM_NhanVien()
       {

       }
       public clsDM_NhanVien(int ID,string ma_nhan_vien, string ten_nhan_vien, bool trang_thai)
       {
           this.ID_nhan_vien = ID;
           this.Ma_nhan_vien = ma_nhan_vien;
           this.Ten_nhan_vien = ten_nhan_vien;
           this.Trang_thai = trang_thai;
       }

       /// <summary>
       /// Giữ kết nối DB từ App.config
       /// </summary>
       SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);

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
           sql += "SELECT DM_Nhan_Vien.ID_nhan_vien, DM_Nhan_Vien.Ten_nhan_vien, DM_Nhan_Vien.Ma_nhan_vien, DM_Nhan_Vien.Trang_thai ";
           sql += "FROM DM_Nhan_Vien ";
           //sql += "INNER ";
           //sql +=   "JOIN DM_Kho ";
           //sql +=   "ON DM_Nhan_Vien.ID_kho=DM_Kho.ID_kho";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);
           SqlDataAdapter da = new SqlDataAdapter(command);
           da.Fill(dt);
           m_dbConnection.Close();

           return dt;
       }
       // End GetAll

       /// <summary>
       /// Get tất cả DonViTInh
       /// </summary>
       /// <returns>DataTable</returns>
       public void GetDonViTinh()
       {
           m_dbConnection.Open();
           dicKho.Clear();

           DataTable dt = new DataTable();
           string sql = "SELECT * FROM DM_Kho";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           SqlDataReader reader = command.ExecuteReader();
           while (reader.Read())
           {
               int ID_kho = reader.GetInt32(0);
               string Ten_kho = reader.GetString(1);

               dicKho.Add(Ten_kho, ID_kho);
           }

           m_dbConnection.Close();

           //return dt;
       }
       // End GetAll

       /// <summary>
       /// Kiểm tra trùng lập trước khi ADD
       /// </summary>
       /// <returns></returns>
       public bool Checkduplicaterows()
       {
           //Mở
           m_dbConnection.Open();
           DataTable dt = new DataTable();

           //Chuẩn bị
           string sql = "";
           sql += "SELECT * FROM DM_Nhan_Vien ";
           sql += "WHERE ID_nhan_vien=@ID_nhan_vien";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           command.Parameters.Add("@ID_nhan_vien", SqlDbType.Int).Value = ID_nhan_vien;
           
           command.CommandType = CommandType.Text;

           //Run
           SqlDataAdapter da = new SqlDataAdapter(command);
           da.Fill(dt);

           //Đóng
           m_dbConnection.Close();

           if (dt.Rows.Count > 0)
           {
               return true;
           }
           return false;
       }
       // End Checkduplicaterows


       /// <summary>
       /// Insert ALL
       /// </summary>
       /// <returns></returns>
       public int Insert()
       {
           //command.Parameters.Add(new SqlParameter("@Ten_kho", Ten_kho));

           //Mở
           m_dbConnection.Open();

           //Chuẩn bị
           string sql = "";
           sql += "INSERT INTO DM_Nhan_Vien (Ten_nhan_vien, Ma_nhan_vien, Trang_thai) ";
           sql += "VALUES(@Ten_nhan_vien, @Ma_nhan_vien, @Trang_thai)";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           command.Parameters.Add("@Ten_nhan_vien", SqlDbType.NVarChar, 50).Value = Ten_nhan_vien;
           //command.Parameters.Add("@ID_kho", SqlDbType.Int).Value = ID_kho;
           command.Parameters.Add("@Ma_nhan_vien", SqlDbType.VarChar, 50).Value = Ma_nhan_vien;
           command.Parameters.Add("@Trang_thai", SqlDbType.Bit).Value = Trang_thai;

           command.CommandType = CommandType.Text;

           //Run
           int result = command.ExecuteNonQuery();

           //Đóng
           m_dbConnection.Close();
           
           return result;
       } //End Insert


       /// <summary>
       /// Update ALL
       /// </summary>
       /// <returns></returns>
       public int Update()
       {
           //Mở
           m_dbConnection.Open();

           //Chuẩn bị
           string sql = "";
           sql += "UPDATE DM_Nhan_Vien ";
           sql += "Set Ten_nhan_vien=@Ten_nhan_vien, ";
           sql += "Ma_nhan_vien=@Ma_nhan_vien, ";
           sql += "Trang_thai=@Trang_thai ";
           sql += "WHERE ID_nhan_vien=@ID_nhan_vien";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           command.Parameters.Add("@ID_nhan_vien", SqlDbType.Int).Value = ID_nhan_vien;
           command.Parameters.Add("@Ten_nhan_vien", SqlDbType.NVarChar, 50).Value = Ten_nhan_vien;
           command.Parameters.Add("@Ma_nhan_vien", SqlDbType.VarChar, 50).Value = Ma_nhan_vien;
           command.Parameters.Add("@Trang_thai", SqlDbType.Bit).Value = Trang_thai;

           command.CommandType = CommandType.Text;

           //Run
           int result = command.ExecuteNonQuery();

           //Đóng
           m_dbConnection.Close();

           return result;
       } // End Update


       /// <summary>
       /// Xoa by ID
       /// </summary>
       /// <returns>bool</returns>
       public int Delete()
       {
           //Mở
           m_dbConnection.Open();

           //Chuẩn bị
           string sql = "";
           sql += "Delete from DM_Nhan_Vien ";
           sql += "WHERE ID_nhan_vien=@ID_nhan_vien";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           command.Parameters.Add("@ID_nhan_vien", SqlDbType.Int).Value = ID_nhan_vien;

           command.CommandType = CommandType.Text;

           //Run
           int result = command.ExecuteNonQuery();

           //Đóng
           m_dbConnection.Close();

           return result;
       }// End Delete
    }
}
