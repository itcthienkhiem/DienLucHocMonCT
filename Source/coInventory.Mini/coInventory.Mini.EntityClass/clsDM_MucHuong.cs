using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace coInventory.Mini.EntityClass
{
    public class clsDM_MucHuong
    {
        public int MucHuong_Id {get; set;}
        public int MucHuong { get; set; }
        public decimal PhanTram { get; set; }
        public bool Active { get; set; }


        private  string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public clsDM_MucHuong()
        {
            Active = true;
        }

        public DataTable GetAll()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "select * from DM_MucHuong order by MucHuong";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public DataTable GetAllActive()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "select * from DM_MucHuong Where Active=1 order by MucHuong";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public static List<clsDM_MucHuong> GetListMucHuong()
        {
            List<clsDM_MucHuong> lst = new List<clsDM_MucHuong>();
            SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "select * from DM_MucHuong Where Active=1 order by MucHuong";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            m_dbConnection.Close();

            foreach (DataRow row in dt.Rows)
            {
                clsDM_MucHuong mh = new clsDM_MucHuong();
                mh.MucHuong_Id = int.Parse(row["MucHuong_Id"].ToString());
                mh.MucHuong = int.Parse(row["MucHuong"].ToString());
                mh.PhanTram = (decimal)row["PhanTram"];
                mh.Active = (bool)row["Active"];
                lst.Add(mh);
            }
            return lst;
        }

        public void GetByKey(int intMucHuong)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_MucHuong WHERE MucHuong=@MucHuong";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MucHuong", intMucHuong));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                MucHuong_Id = int.Parse(dt.Rows[0]["MucHuong_Id"].ToString());
                MucHuong = int.Parse(dt.Rows[0]["MucHuong"].ToString());
                PhanTram = (decimal)dt.Rows[0]["PhanTram"];
                Active = (bool)dt.Rows[0]["Active"];
            }
        }


        public int Insert()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO DM_MucHuong (MucHuong, PhanTram, Active) ";
            sql += " VALUES(@MucHuong,@PhanTram,@Active)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MucHuong", MucHuong));
            command.Parameters.Add(new SQLiteParameter("@PhanTram", PhanTram));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
        public int Update()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "";
            sql += "UPDATE DM_MucHuong ";
            sql += "SET MucHuong=@MucHuong,PhanTram=@PhanTram,Active=@Active ";
            sql += "WHERE MucHuong=@MucHuong";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MucHuong", MucHuong));
            command.Parameters.Add(new SQLiteParameter("@PhanTram", PhanTram));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }


        public int Insert(SQLiteDAL DAL)
        {
           
            string sql = "";
            sql += "INSERT INTO DM_MucHuong (MucHuong, PhanTram, Active) ";
            sql += " VALUES(@MucHuong,@PhanTram,@Active)";

            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MucHuong", MucHuong));
            command.Parameters.Add(new SQLiteParameter("@PhanTram", PhanTram));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));

            int result = command.ExecuteNonQuery();
            //m_dbConnection.Close();
            return result;
        }
        public int Update(SQLiteDAL DAL)
        {
           
            string sql = "";
            sql += "UPDATE DM_MucHuong ";
            sql += "SET MucHuong=@MucHuong,PhanTram=@PhanTram,Active=@Active ";
            sql += "WHERE MucHuong=@MucHuong";


            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MucHuong", MucHuong));
            command.Parameters.Add(new SQLiteParameter("@PhanTram", PhanTram));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));

            int result = command.ExecuteNonQuery();
            //m_dbConnection.Close();
            return result;
        }



        public int Delete(int intMucHuong)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "Delete from DM_MucHuong WHERE MucHuong=@MucHuong";


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
            string sql = "SELECT MucHuong FROM DM_MucHuong WHERE MucHuong=@MucHuong";
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
