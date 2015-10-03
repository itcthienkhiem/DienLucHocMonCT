using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Inventory.EntityClass
{
   public class clsThongTinKetNoi
    {
       public string server_Name;
       public string user_Name;
       public string passwd;
       public string ten_CSDL;
       public SqlConnection connection;
       public clsThongTinKetNoi() { }
       public clsThongTinKetNoi(string _servername, string _user_name, string _passwd, string _ten_CSDL )
       {
           server_Name = _servername;
           user_Name = _user_name;
           passwd = _passwd;
           ten_CSDL = _ten_CSDL;
       }
       public bool Connect()
       {
           try{
           connection = new SqlConnection();
           string connStr = @"Data Source="+server_Name+";Initial Catalog="+ten_CSDL+";User ID="+user_Name+";password="+passwd; // chuỗi kết nối đến CSDL
            connection .ConnectionString = connStr;
           connection.Open();
           connection.Close();
               return true;
           }
           catch(Exception ex){
            return false;
           }
       }
    }
}
