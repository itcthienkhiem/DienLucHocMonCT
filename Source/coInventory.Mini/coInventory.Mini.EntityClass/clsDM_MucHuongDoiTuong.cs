using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace coInventory.Mini.EntityClass
{
    public class clsDM_MucHuongDoiTuong
    {
        public int MucHuongDoiTuong_Id;
        public int MucHuong;
        public string DoiTuong;

        private string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public DataTable GetAll()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "select * from DM_MucHuongDoiTuong order by MucHuong";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public void GetByKey(int intMucHuong)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_MucHuongDoiTuong WHERE MucHuong=@MucHuong";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MucHuong", intMucHuong));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                MucHuongDoiTuong_Id = int.Parse(dt.Rows[0]["MucHuongDoiTuong_Id"].ToString());
                MucHuong = int.Parse(dt.Rows[0]["MucHuong"].ToString());
                DoiTuong = dt.Rows[0]["DoiTuong"].ToString();
            }
        }


        public int Insert()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO DM_MucHuongDoiTuong (MucHuong, DoiTuong) ";
            sql += " VALUES(@MucHuong,@DoiTuong)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MucHuong", MucHuong));
            command.Parameters.Add(new SQLiteParameter("@DoiTuong", DoiTuong));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
        public int Update()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "";
            sql += "UPDATE DM_MucHuongDoiTuong ";
            sql += "SET MucHuong=@MucHuong,DoiTuong=@DoiTuong ";
            sql += "WHERE MucHuong=@MucHuong";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MucHuong", MucHuong));
            command.Parameters.Add(new SQLiteParameter("@DoiTuong", DoiTuong));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }


        public int Insert(SQLiteDAL DAL)
        {
        

            string sql = "";
            sql += "INSERT INTO DM_MucHuongDoiTuong (MucHuong, DoiTuong) ";
            sql += " VALUES(@MucHuong,@DoiTuong)";

            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MucHuong", MucHuong));
            command.Parameters.Add(new SQLiteParameter("@DoiTuong", DoiTuong));

            int result = command.ExecuteNonQuery();

            return result;
        }
        public int Update(SQLiteDAL DAL)
        {
           
            string sql = "";
            sql += "UPDATE DM_MucHuongDoiTuong ";
            sql += "SET MucHuong=@MucHuong,DoiTuong=@DoiTuong ";
            sql += "WHERE MucHuong=@MucHuong";


            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MucHuong", MucHuong));
            command.Parameters.Add(new SQLiteParameter("@DoiTuong", DoiTuong));

            int result = command.ExecuteNonQuery();
           
            return result;
        }


        public int Delete(int intMucHuong)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "Delete from DM_MucHuongDoiTuong WHERE MucHuong=@MucHuong";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MucHuong", intMucHuong));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public bool CheckTonTai(int intMucHuong)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT MucHuong FROM DM_MucHuongDoiTuong WHERE MucHuong=@MucHuong";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MucHuong", intMucHuong));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            clsDM_ICD obj = new clsDM_ICD();

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
