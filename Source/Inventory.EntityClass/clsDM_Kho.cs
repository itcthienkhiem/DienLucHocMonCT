using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Inventory.Utilities;
using Inventory.Models;
using System.Linq;
using System.Data.Entity;
namespace Inventory.EntityClass
{
   public class clsDM_Kho
    {
        public int? ID_kho;
        public string Ten_kho;
       public clsDM_Kho()
       { 
       
       }

       SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);

       public static object getAll()
       {
           //using (var context = Entities.ent)
           //{
           //    return context.DM_Kho.ToList();
           //}
           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           using (var dbcxtransaction =help.ent.Database.BeginTransaction())
           {
               var dm = from d in help.ent.DM_Kho
                        select new
                        {
                            d.ID_kho,
                            d.Ten_kho
                        };
               dbcxtransaction.Commit();
             //  help.CloseDatabase();
               return (object)dm.ToList();
           }
              
          

       }
       //public DataTable GetAll()
       //{
       //    m_dbConnection.Open();
       //    DataTable dt = new DataTable();
       //    string sql = "SELECT * FROM DM_kho";
       //    SqlCommand command = new SqlCommand(sql, m_dbConnection);
       //    SqlDataAdapter da = new SqlDataAdapter(command);
       //    da.Fill(dt);
       //    m_dbConnection.Close();
       //    return dt;
       //}

       public bool CheckTonTaiSoDK()
       {
           return false;

         //  bool has = DM_Kho.Any(cus => cus.Ten_kho == Ten_kho);
         //  return has;

           //m_dbConnection.Open();
           //DataTable dt = new DataTable();
           //string sql = "SELECT * FROM DM_kho WHERE ten_kho=@ten_kho";
           //SqlCommand command = new SqlCommand(sql, m_dbConnection);
           //command.Parameters.Add(new SqlParameter("@ten_kho", Ten_kho));
           //SqlDataAdapter da = new SqlDataAdapter(command);
           //da.Fill(dt);
           //m_dbConnection.Close();

           //if (dt.Rows.Count > 0)
           //{
           //    return true;
           //}
           //return false;
       }
       public int Insert()
       {

          // var id = Guid.NewGuid();
           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           // insert
         //  var context = new DatabaseEntities();
           try
           {
               var t = new DM_Kho //Make sure you have a table called test in DB
               {
                   ID_kho = this.ID_kho,
                   Ten_kho = this.Ten_kho,
                   // ID = Guid.NewGuid(),
               };

               help.ent.DM_Kho.Add(t);
               help.ent.SaveChanges();
             //  help.CloseDatabase();
               return 1;
           }
           catch (Exception ex)
           {
               return 0;

           }
           


           //m_dbConnection.Open();

           //string sql = "";
           //sql += "INSERT INTO DM_Kho (Ten_kho) ";
           //sql += "VALUES(@Ten_kho)";

           //SqlCommand command = new SqlCommand(sql, m_dbConnection);
           //command.CommandType = CommandType.Text;

           ////command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
           //command.Parameters.Add(new SqlParameter("@Ten_kho", Ten_kho));

           //int result = command.ExecuteNonQuery();
           //m_dbConnection.Close();
           //return result;
       }

       public int Update(DM_Kho kho)
       {
           //var temp = Entities.ent;

           //var original = Entities.ent.DM_Kho.Find(this.ID_kho);
           //var dbCtx = Entities.ent.DM_Kho;
             
           //    3. Mark entity as modified
           //    Entities.ent.Entry(original).State = System.Data.Entity.EntityState.Modified;

           //    4. call SaveChanges
           //    Entities.ent.SaveChanges();

           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           int temp = 0;
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {
               using (var context = help.ent)
               {
                   context.DM_Kho.Attach(kho);
                   context.Entry(kho).State = EntityState.Modified;
                   temp = help.ent.SaveChanges();
                   dbcxtransaction.Commit();
                  
               }

              
           }
       //    help.CloseDatabase();
           return temp;
               //using (var db = Entities.ent)
               //{
               //    var result = db.DM_Kho.SingleOrDefault(b => b.ID_kho == ID_kho);
               //    if (result != null)
               //    {
               //        result.Ten_kho = Ten_kho;
               //        db.SaveChanges();
                       
                      
               //        return 1;
               //    }
               //}
               //return 0;
           

           //m_dbConnection.Open();

           //string sql = "";
           //sql += "UPDATE DM_Kho ";
           //sql += "Set Ten_Kho=@Ten_Kho ";
           //sql += "WHERE ID_kho=@ID_kho";


           //SqlCommand command = new SqlCommand(sql, m_dbConnection);
           //command.CommandType = CommandType.Text;

           //command.Parameters.Add(new SqlParameter("@ID_kho", ID_kho));
           //command.Parameters.Add(new SqlParameter("@Ten_Kho", Ten_kho));

           //int result = command.ExecuteNonQuery();
           //m_dbConnection.Close();
       
       }

       public int Delete(DM_Kho dm)
       {
           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
         //  var employer = new Employ { Id = 1 };
           help.ent.DM_Kho.Attach(dm);
           help.ent.DM_Kho.Remove(dm);
          return help.ent.SaveChanges();

           //m_dbConnection.Open();

           ////string sql = "Delete from DM_Kho WHERE Ten_kho=@Ten_kho";
           //string sql = "Delete from DM_Kho WHERE ID_kho=@ID_kho";

           //SqlCommand command = new SqlCommand(sql, m_dbConnection);
           //command.CommandType = CommandType.Text;

           ////command.Parameters.Add(new SqlParameter("@Ten_kho", Ten_kho));
           //command.Parameters.Add(new SqlParameter("@ID_kho", ID_kho));

           //int result = command.ExecuteNonQuery();
           //m_dbConnection.Close();
           //return result;
       }

       //Dictionary<int, string> usernameDict;
       //public Dictionary<int, string> GetAll()
       //{
          
       //}

       //// Then in the GetValue(int userId) method, do this:
       //public string GetValue(int userId)
       //{
       //    // Add some error handling and whatnot. 
       //    // And a better name for this method is GetUsername(int userId)
       //    return this.usernameDict[userId];
       //}
       //public static object GetDataFromDB(string query)
       //{
       //    string return_value = string.Empty;
       //  //  SqlConnection sql_conn;

       //    var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
       //    var settings = configFile.AppSettings.Settings;
       //    string server_Name = settings["server_Name"].Value;
       //    string user_Name = settings["user_Name"].Value;
       //    string passwd = settings["passwd"].Value;
       //    string ten_CSDL = settings["ten_CSDL"].Value;
       //    string cnnstr = @"Data Source=" + server_Name + ";Initial Catalog=" + ten_CSDL + ";User ID=" + user_Name + ";password=" + passwd; // chuỗi kết nối đến CSDL
       //    Dictionary<int, string> dictionary = new Dictionary<int, string>();
       //    using (SqlConnection connection = new SqlConnection(cnnstr))
       //    {
       //        connection.Open();

       //        using (SqlCommand command = new SqlCommand(query, connection))
       //        {
       //            using (SqlDataReader reader = command.ExecuteReader())
       //            {
       //                while (reader.Read())
       //                {
       //                    dictionary.Add(reader.GetInt32(0), reader.GetString(1));
       //                }
       //            }
       //        }
       //        connection.Close();
       //    }
       //    return dictionary;

       //} 

     
    }
}
