using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
//using WebService.Model;
using System.Data.SQLite;

namespace coInventory.Mini.EntityClass
{
    /// <summary>
    /// class này lưu trử các phương thức chung cho việc xữ lý csdl 
    /// Người tạo: khiemnt3
    /// </summary>
    public abstract class clsDM_XuLy
    {
        protected string sql;
        protected string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public virtual int Delete()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();




            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;


            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
        public virtual DataTable GetAll()
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
        public virtual object GetByKey(string strMa) { return null; }
        public virtual int Insert() { return 0; }
        public virtual int Update() { return 0; }
        public virtual int Insert(SQLiteDAL DA) { return 0; }
        public virtual int Update(SQLiteDAL DAL) { return 0; }
        public virtual int Delete(string strMaThuoc) { return 0; }

    }
}
