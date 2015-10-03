using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace coInventory.Mini.EntityClass
{
    public class clsDM_LuongCoSo
    {
        public int LuongCoSo_Id;
        public DateTime TuNgay;
        public decimal LuongCoSo;

        private string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public DataTable GetAll()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "select * from DM_LuongCoSo order by TuNgay";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public static decimal GetLuongCoSo()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "select LuongCoSo from DM_LuongCoSo order by TuNgay desc";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            m_dbConnection.Close();
            if (dt.Rows.Count > 0)
            {
                return (decimal)dt.Rows[0]["LuongCoSo"];
            }
            return 0;
        }

        public void GetByKey(int intLuongCoSo_Id)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_LuongCoSo WHERE LuongCoSo_Id = @LuongCoSo_Id";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@LuongCoSo_Id", intLuongCoSo_Id));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                LuongCoSo_Id = int.Parse(dt.Rows[0]["LuongCoSo_Id"].ToString());
                TuNgay = (DateTime)dt.Rows[0]["TuNgay"];
                LuongCoSo = (decimal)dt.Rows[0]["LuongCoSo"];
            }
        }


        public int Insert()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO DM_LuongCoSo (TuNgay, LuongCoSo) ";
            sql += " VALUES(@TuNgay,@LuongCoSo)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@TuNgay", TuNgay));
            command.Parameters.Add(new SQLiteParameter("@LuongCoSo", LuongCoSo));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
        public int Update()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "";
            sql += "UPDATE DM_LuongCoSo ";
            sql += "SET TuNgay=@TuNgay,LuongCoSo=@LuongCoSo ";
            sql += "WHERE LuongCoSo_Id=@LuongCoSo_Id";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@LuongCoSo_Id", LuongCoSo_Id));
            command.Parameters.Add(new SQLiteParameter("@TuNgay", TuNgay));
            command.Parameters.Add(new SQLiteParameter("@LuongCoSo", LuongCoSo));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }


        public int Insert(SQLiteDAL DAL)
        {
           

            string sql = "";
            sql += "INSERT INTO DM_LuongCoSo (TuNgay, LuongCoSo) ";
            sql += " VALUES(@TuNgay,@LuongCoSo)";

            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@TuNgay", TuNgay));
            command.Parameters.Add(new SQLiteParameter("@LuongCoSo", LuongCoSo));

            int result = command.ExecuteNonQuery();
            return result;
        }
        public int Update(SQLiteDAL DAL)
        {
            string sql = "";
            sql += "UPDATE DM_LuongCoSo ";
            sql += "SET TuNgay=@TuNgay,LuongCoSo=@LuongCoSo ";
            sql += "WHERE LuongCoSo_Id=@LuongCoSo_Id";


            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@LuongCoSo_Id", LuongCoSo_Id));
            command.Parameters.Add(new SQLiteParameter("@TuNgay", TuNgay));
            command.Parameters.Add(new SQLiteParameter("@LuongCoSo", LuongCoSo));

            int result = command.ExecuteNonQuery();
            
            return result;
        }

        public int Delete(int intLuongCoSo_Id)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "Delete from DM_LuongCoSo WHERE LuongCoSo_Id=@LuongCoSo_Id";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@LuongCoSo_Id", intLuongCoSo_Id));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public bool CheckTonTai(int intLuongCoSo_Id)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT LuongCoSo_Id FROM DM_LuongCoSo WHERE LuongCoSo_Id=@LuongCoSo_Id";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@LuongCoSo_Id", intLuongCoSo_Id));
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
