using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Inventory.EntityClass
{
    /// <summary>
    /// To-Do LIST
    /// - GET ALL DATA
    /// - Check Trùng Lập
    /// - Insert
    /// - Update
    /// - Delete
    /// </summary>
    public class clsDM_DonViTinh
    {
        //List var dùng trong DM Đơn Vị Tính
       public int ID_Don_vi_tinh;
       public string Ten_don_vi_tinh;
       //--~

       public clsDM_DonViTinh()
       {

       }

       /// <summary>
       /// Giữ kết nối DB từ App.config
       /// </summary>
       SqlConnection m_dbConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

       /// <summary>
       /// Get tất cả dữ liệu từ CSDL, dùng cho Grid
       /// </summary>
       /// <returns>DataTable</returns>
       public DataTable GetAll()
       {
           m_dbConnection.Open();

           DataTable dt = new DataTable();
           string sql = "";
           sql += "SELECT * ";
           sql += "FROM DM_Don_vi_tinh ";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);
           SqlDataAdapter da = new SqlDataAdapter(command);
           da.Fill(dt);
           m_dbConnection.Close();

           return dt;
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
           sql += "SELECT * FROM DM_Don_vi_tinh ";
           sql += "WHERE ID_Don_vi_tinh=@ID_Don_vi_tinh";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           command.Parameters.Add("@ID_Don_vi_tinh", SqlDbType.Int).Value = ID_Don_vi_tinh;
           
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
           sql += "INSERT INTO DM_Don_vi_tinh (Ten_don_vi_tinh) ";
           sql += "VALUES(@Ten_don_vi_tinh)";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           //command.Parameters.Add("@ID_Don_vi_tinh", SqlDbType.Int).Value = ID_Don_vi_tinh;
           command.Parameters.Add("@Ten_don_vi_tinh", SqlDbType.NVarChar, 50).Value = Ten_don_vi_tinh;

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
           sql += "UPDATE DM_Don_vi_tinh ";
           //sql += "Set ID_Don_vi_tinh=@ID_Don_vi_tinh, ";
           sql += "SET Ten_don_vi_tinh=@Ten_don_vi_tinh ";
           sql += "WHERE ID_Don_vi_tinh=@ID_Don_vi_tinh";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           command.Parameters.Add("@ID_Don_vi_tinh", SqlDbType.Int).Value = ID_Don_vi_tinh;
           command.Parameters.Add("@Ten_don_vi_tinh", SqlDbType.NVarChar, 50).Value = Ten_don_vi_tinh;

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
           sql += "Delete from DM_Don_vi_tinh ";
           sql += "WHERE ID_Don_vi_tinh=@ID_Don_vi_tinh";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           command.Parameters.Add("@ID_Don_vi_tinh", SqlDbType.Int).Value = ID_Don_vi_tinh;

           command.CommandType = CommandType.Text;

           //Run
           int result = command.ExecuteNonQuery();

           //Đóng
           m_dbConnection.Close();

           return result;
       }// End Delete
    }
}
