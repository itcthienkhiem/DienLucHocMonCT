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
    /// To-Do LIST
    /// [x] GET ALL DATA
    /// [x] Check Trùng Lập
    /// [x] Insert
    /// [x] Update
    /// [x] Delete
    /// 
    /// [ ] Tối ưu Data
    /// [ ] Tối ưu nhập xuất với func
    /// [ ] Gom các hàm trùng lập về 1 func tổng quát
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
       SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);

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
       /// [Update] Dùng ExecuteScalar để check 1 first cell, đổi tên hàm thân thiện hơn
       /// </summary>
       /// <returns></returns>
       public bool hasDuplicateRow()
       {
           //Mở
           m_dbConnection.Open();

           //Chuẩn bị
           string sql = "";
           sql += "SELECT Ten_don_vi_tinh FROM DM_Don_vi_tinh ";
           sql += "WHERE Ten_don_vi_tinh=@Ten_don_vi_tinh";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           command.Parameters.Add("@Ten_don_vi_tinh", SqlDbType.NVarChar, 50).Value = Ten_don_vi_tinh;
           
           command.CommandType = CommandType.Text;

           //Run

           //Lấy 1 cell về check
           var firstColumn = command.ExecuteScalar();

           //Đóng
           m_dbConnection.Close();

           //Nếu có dữ liệu, thì trùng
           if (firstColumn != null)
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
       /// [Bug] Xóa Item có Liên Kết khóa ngoại với bảng Vật Tư
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
