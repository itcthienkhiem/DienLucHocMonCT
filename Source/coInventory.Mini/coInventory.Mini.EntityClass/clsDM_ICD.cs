using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace coInventory.Mini.EntityClass
{
    public class clsDM_ICD
    {
        public int ICD_Id;
        public string MaICD;
        public string TenICD;
        public bool? NgoaiDinhSuat = false;
        public bool? Active = true;

        private SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public DataTable GetAll()
        {
           
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "select * from DM_ICD order by MaICD";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public DataTable GetAllActive()
        {

            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "select * from DM_ICD Where Active=1 order by MaICD";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public void GetByKey(string strMa)
        {
            //SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_ICD WHERE MaICD=@MaICD";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaICD", strMa));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                ICD_Id = int.Parse(dt.Rows[0]["ICD_Id"].ToString());
                MaICD = dt.Rows[0]["MaICD"].ToString();
                TenICD = dt.Rows[0]["TenICD"].ToString();
                NgoaiDinhSuat = string.IsNullOrEmpty(dt.Rows[0]["NgoaiDinhSuat"].ToString()) ? null : (bool?)dt.Rows[0]["NgoaiDinhSuat"]; ;
                Active = string.IsNullOrEmpty(dt.Rows[0]["Active"].ToString()) ? null : (bool?)dt.Rows[0]["Active"]; ;                
            }
        }


        public int Insert()
        {
            //SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO DM_ICD (MaICD, TenICD, NgoaiDinhSuat, Active) ";
            sql += " VALUES(@MaICD,@TenICD,@NgoaiDinhSuat,@Active)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaICD", MaICD));
            command.Parameters.Add(new SQLiteParameter("@TenICD", TenICD));
            command.Parameters.Add(new SQLiteParameter("@NgoaiDinhSuat", NgoaiDinhSuat));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
        public int Update()
        {
            //SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "";
            sql += "UPDATE DM_ICD ";
            sql += "SET MaICD=@MaICD,TenICD=@TenICD,NgoaiDinhSuat=@NgoaiDinhSuat,Active=@Active ";
            sql += "WHERE MaICD=@MaICD";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaICD", MaICD));
            command.Parameters.Add(new SQLiteParameter("@TenICD", TenICD));
            command.Parameters.Add(new SQLiteParameter("@NgoaiDinhSuat", NgoaiDinhSuat));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            
            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public int Insert(SQLiteDAL DAL)
        {
            //SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            //m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO DM_ICD (MaICD, TenICD, NgoaiDinhSuat, Active) ";
            sql += " VALUES(@MaICD,@TenICD,@NgoaiDinhSuat,@Active)";

            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaICD", MaICD));
            command.Parameters.Add(new SQLiteParameter("@TenICD", TenICD));
            command.Parameters.Add(new SQLiteParameter("@NgoaiDinhSuat", NgoaiDinhSuat));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));

            int result = command.ExecuteNonQuery();
            //m_dbConnection.Close();
            return result;
        }
        public int Update(SQLiteDAL DAL)
        {
            //SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            //m_dbConnection.Open();

            string sql = "";
            sql += "UPDATE DM_ICD ";
            sql += "SET MaICD=@MaICD,TenICD=@TenICD,NgoaiDinhSuat=@NgoaiDinhSuat,Active=@Active ";
            sql += "WHERE MaICD=@MaICD";


            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaICD", MaICD));
            command.Parameters.Add(new SQLiteParameter("@TenICD", TenICD));
            command.Parameters.Add(new SQLiteParameter("@NgoaiDinhSuat", NgoaiDinhSuat));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));

            int result = command.ExecuteNonQuery();
            //m_dbConnection.Close();
            return result;
        }

        public int Delete(string strMa)
        {
            //SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "Delete from DM_ICD WHERE MaICD=@MaICD";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaICD", strMa));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public bool CheckTonTai(string strMa)
        {
            //SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT MaICD FROM DM_ICD WHERE MaICD=@MaICD";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaICD", strMa));
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
