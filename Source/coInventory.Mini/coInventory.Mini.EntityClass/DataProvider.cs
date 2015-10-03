using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace eHospital.Mini.EntityClass
{
    public class DataProvider
    {
        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public DataProvider()
        {
            
        }
       
        public int ExecuteNonQuery(string sql)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
        public DataTable ExecuteTable(string sql)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;


        }
       
    }
}
