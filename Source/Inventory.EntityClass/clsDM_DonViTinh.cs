using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Inventory.Utilities;
using Inventory.Models;
using System.Data.Entity;
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
       public object GetAll()
       {
           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {
               var dm = from d in help.ent.DM_Don_vi_tinh
                        select new
                        {
                            d.ID_Don_vi_tinh,
                            d.Ten_don_vi_tinh,
                            d.Trang_thai ,
                        };
               dbcxtransaction.Commit();
               return (object)dm.ToList();
           }

       
       }
       public int getMATuTen(string Ten, DatabaseHelper help)
       {
           
         
           {

               var dm = (from d in help.ent.DM_Don_vi_tinh
                         where d.Ten_don_vi_tinh == Ten
                         select new
                         {

                             d.ID_Don_vi_tinh,

                         }).ToList();
             
               return dm[0].ID_Don_vi_tinh;
           }
       }
       // End GetAll
       public int getMATuTen(string Ten)
       {
           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {

               var dm = (from d in help.ent.DM_Don_vi_tinh
                         where d.Ten_don_vi_tinh ==Ten
                         select new
                         {

                             d.ID_Don_vi_tinh,

                         }).ToList();
               dbcxtransaction.Commit();
               return dm[0].ID_Don_vi_tinh;
           }
       }
       public string getTenDVTTuMa(int madvt)
       {
           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {
               var dm = (from d in help.ent.DM_Don_vi_tinh
                         where d.ID_Don_vi_tinh == madvt
                        select new
                        {
                       
                            d.Ten_don_vi_tinh,
                          
                        }).ToList();
               dbcxtransaction.Commit();
               return dm[0].Ten_don_vi_tinh.ToString();
           }
       
       }
       public bool hasDuplicateRow(DatabaseHelper help)
       {
           
           bool has = help.ent.DM_Don_vi_tinh.Any(cus => cus.Ten_don_vi_tinh == Ten_don_vi_tinh);
           return has;

       }
       /// <summary>
       /// Kiểm tra trùng lập trước khi ADD
       /// [Update] Dùng ExecuteScalar để check 1 first cell, đổi tên hàm thân thiện hơn
       /// </summary>
       /// <returns></returns>
       public bool hasDuplicateRow()
       {
           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           bool has = help.ent.DM_Don_vi_tinh.Any(cus => cus.Ten_don_vi_tinh == Ten_don_vi_tinh);
           return has;




           //Mở
           //m_dbConnection.Open();

           ////Chuẩn bị
           //string sql = "";
           //sql += "SELECT Ten_don_vi_tinh FROM DM_Don_vi_tinh ";
           //sql += "WHERE Ten_don_vi_tinh=@Ten_don_vi_tinh";

           //SqlCommand command = new SqlCommand(sql, m_dbConnection);

           //command.Parameters.Add("@Ten_don_vi_tinh", SqlDbType.NVarChar, 50).Value = Ten_don_vi_tinh;
           
           //command.CommandType = CommandType.Text;

           ////Run

           ////Lấy 1 cell về check
           //var firstColumn = command.ExecuteScalar();

           ////Đóng
           //m_dbConnection.Close();

           ////Nếu có dữ liệu, thì trùng
           //if (firstColumn != null)
           //{
           //    return true;
           //}
           //return false;
       }
       // End Checkduplicaterows
    
       public int Insert(DatabaseHelper help)
       {
           //command.Parameters.Add(new SqlParameter("@Ten_kho", Ten_kho));

          
           // insert
           try
           {
               var t = new DM_Don_vi_tinh //Make sure you have a table called test in DB
               {
                   ID_Don_vi_tinh = this.ID_Don_vi_tinh,
                   Ten_don_vi_tinh = this.Ten_don_vi_tinh,
                   // ID = Guid.NewGuid(),

               };

               help.ent.DM_Don_vi_tinh.Add(t);
               help.ent.SaveChanges();
               return 1;
           }
           catch (Exception ex)
           {
               return 0;

           }
       }
       /// <summary>
       /// Insert ALL
       /// </summary>
       /// <returns></returns>
       public int Insert()
       {
           //command.Parameters.Add(new SqlParameter("@Ten_kho", Ten_kho));

           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           // insert
           try
           {
               var t = new DM_Don_vi_tinh //Make sure you have a table called test in DB
               {
                   ID_Don_vi_tinh = this.ID_Don_vi_tinh,
                   Ten_don_vi_tinh = this.Ten_don_vi_tinh,   
                   // ID = Guid.NewGuid(),
                   
               };

               help.ent.DM_Don_vi_tinh.Add(t);
               help.ent.SaveChanges();
               return 1;
           }
           catch (Exception ex)
           {
               return 0;

           }



           ////Mở
           //m_dbConnection.Open();

           ////Chuẩn bị
           //string sql = "";
           //sql += "INSERT INTO DM_Don_vi_tinh (Ten_don_vi_tinh) ";
           //sql += "VALUES(@Ten_don_vi_tinh)";

           //SqlCommand command = new SqlCommand(sql, m_dbConnection);

           ////command.Parameters.Add("@ID_Don_vi_tinh", SqlDbType.Int).Value = ID_Don_vi_tinh;
           //command.Parameters.Add("@Ten_don_vi_tinh", SqlDbType.NVarChar, 50).Value = Ten_don_vi_tinh;

           //command.CommandType = CommandType.Text;

           ////Run
           //int result = command.ExecuteNonQuery();

           ////Đóng
           //m_dbConnection.Close();
           
           //return result;
       } //End Insert


       /// <summary>
       /// Update ALL
       /// </summary>
       /// <returns></returns>
       public int Update(DM_Don_vi_tinh dvt)
       {



           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           int temp = 0;
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {
               using (var context = help.ent)
               {
                   context.DM_Don_vi_tinh.Attach(dvt);
                   context.Entry(dvt).State = EntityState.Modified;
                   temp = help.ent.SaveChanges();
                   dbcxtransaction.Commit();

               }


           }
           return temp;
           ////Mở
           //m_dbConnection.Open();

           ////Chuẩn bị
           //string sql = "";
           //sql += "UPDATE DM_Don_vi_tinh ";
           ////sql += "Set ID_Don_vi_tinh=@ID_Don_vi_tinh, ";
           //sql += "SET Ten_don_vi_tinh=@Ten_don_vi_tinh ";
           //sql += "WHERE ID_Don_vi_tinh=@ID_Don_vi_tinh";

           //SqlCommand command = new SqlCommand(sql, m_dbConnection);

           //command.Parameters.Add("@ID_Don_vi_tinh", SqlDbType.Int).Value = ID_Don_vi_tinh;
           //command.Parameters.Add("@Ten_don_vi_tinh", SqlDbType.NVarChar, 50).Value = Ten_don_vi_tinh;

           //command.CommandType = CommandType.Text;

           ////Run
           //int result = command.ExecuteNonQuery();

           ////Đóng
           //m_dbConnection.Close();

           //return result;
       } // End Update


       /// <summary>
       /// [Bug] Xóa Item có Liên Kết khóa ngoại với bảng Vật Tư
       /// </summary>
       /// <returns>bool</returns>
       public int Delete(DM_Don_vi_tinh dvt)
       {
           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           help.ent.DM_Don_vi_tinh.Attach(dvt);
           help.ent.DM_Don_vi_tinh.Remove(dvt);
           return help.ent.SaveChanges();



           //Mở
           //m_dbConnection.Open();

           ////Chuẩn bị
           //string sql = "";
           //sql += "Delete from DM_Don_vi_tinh ";
           //sql += "WHERE ID_Don_vi_tinh=@ID_Don_vi_tinh";

           //SqlCommand command = new SqlCommand(sql, m_dbConnection);

           //command.Parameters.Add("@ID_Don_vi_tinh", SqlDbType.Int).Value = ID_Don_vi_tinh;

           //command.CommandType = CommandType.Text;

           ////Run
           //int result = command.ExecuteNonQuery();

           ////Đóng
           //m_dbConnection.Close();

           //return result;
       }// End Delete
    }
}
