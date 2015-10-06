using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

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
   public class clsDMVatTu
    {
       //List var dùng trong DM Vat Tu
       //public int ID_vat_tu; //Bị Remove @.@
       public string Ten_vat_tu;
       public string Ma_vat_tu;
       public string old_Ma_vat_tu;
       public int ID_Don_vi_tinh;
       public string ten_don_vi_tinh;
       public long Don_gia;

       public string Mo_ta;

       public SortedDictionary<string, int> dicDonViTinh = new SortedDictionary<string, int>();

       public int Selected_DonViTinh;
       //--~

       public clsDMVatTu()
       {

       }

       public clsDMVatTu(string mavt,string tenvt,string  dvt,string mota,long don_gia, int id_dvt)
       {
           this.Ma_vat_tu = mavt;
           this.Ten_vat_tu = tenvt;
           this.ten_don_vi_tinh = dvt;
           this.Mo_ta = mota;
           this.Don_gia = don_gia;
           this.ID_Don_vi_tinh = id_dvt;
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
           //string sql = "SELECT * FROM DM_Vat_Tu";
           string sql = "";
           sql += "SELECT DM_Vat_Tu.Ma_vat_tu, DM_Vat_Tu.Ten_vat_tu, DM_Don_vi_tinh.Ten_don_vi_tinh, DM_Vat_Tu.Mo_ta,DM_vat_tu.Don_gia, DM_Vat_Tu.id_don_vi_tinh ";
           sql += "FROM DM_Vat_Tu ";
        //   sql += "INNER ";
           sql +=   "JOIN DM_Don_vi_tinh ";
           sql +=   "ON DM_Vat_Tu.ID_Don_vi_tinh=DM_Don_vi_tinh.ID_Don_vi_tinh";

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
           dicDonViTinh.Clear();

           DataTable dt = new DataTable();
           string sql = "SELECT * FROM DM_Don_vi_tinh";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           SqlDataReader reader = command.ExecuteReader();
           while (reader.Read())
           {
               int ID_Don_vi_tinh = reader.GetInt32(0);
               string Ten_don_vi_tinh = reader.GetString(1);

               dicDonViTinh.Add(Ten_don_vi_tinh, ID_Don_vi_tinh);
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
           sql += "SELECT * FROM DM_Vat_Tu ";
           sql += "WHERE Ma_vat_tu=@Ma_vat_tu";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           command.Parameters.Add("@Ma_vat_tu", SqlDbType.Int).Value = Ma_vat_tu;
           
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
           sql += "INSERT INTO DM_Vat_Tu (Ma_vat_tu, Ten_vat_tu, ID_Don_vi_tinh, Mo_ta) ";
           sql += "VALUES(@Ma_vat_tu, @Ten_vat_tu, @ID_Don_vi_tinh, @Mo_ta)";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           command.Parameters.Add("@Ma_vat_tu", SqlDbType.VarChar, 50).Value = Ma_vat_tu;
           command.Parameters.Add("@Ten_vat_tu", SqlDbType.NVarChar, 50).Value = Ten_vat_tu;
           command.Parameters.Add("@ID_Don_vi_tinh", SqlDbType.Int).Value = ID_Don_vi_tinh;
           command.Parameters.Add("@Mo_ta", SqlDbType.NVarChar, 50).Value = Mo_ta;

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
           sql += "UPDATE DM_Vat_Tu ";
           sql += "Set Ma_vat_tu=@Ma_vat_tu, ";
           sql += "Ten_vat_tu=@Ten_vat_tu, ";
           sql += "ID_Don_vi_tinh=@ID_Don_vi_tinh, ";
           sql += "Mo_ta=@Mo_ta ";
           sql += "WHERE Ma_vat_tu=@old_Ma_vat_tu";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           command.Parameters.Add("@Ma_vat_tu", SqlDbType.VarChar, 50).Value = Ma_vat_tu;
           command.Parameters.Add("@old_Ma_vat_tu", SqlDbType.VarChar, 50).Value = old_Ma_vat_tu;
           command.Parameters.Add("@Ten_vat_tu", SqlDbType.NVarChar, 50).Value = Ten_vat_tu; 
           command.Parameters.Add("@ID_Don_vi_tinh", SqlDbType.Int).Value = ID_Don_vi_tinh;
           command.Parameters.Add("@Mo_ta", SqlDbType.NVarChar, 50).Value = Mo_ta;

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
           sql += "Delete from DM_Vat_Tu ";
           sql += "WHERE Ma_vat_tu=@Ma_vat_tu";

           SqlCommand command = new SqlCommand(sql, m_dbConnection);

           command.Parameters.Add("@Ma_vat_tu", SqlDbType.VarChar, 50).Value = Ma_vat_tu;

           command.CommandType = CommandType.Text;

           //Run
           int result = command.ExecuteNonQuery();

           //Đóng
           m_dbConnection.Close();

           return result;
       }// End Delete
    }
}
