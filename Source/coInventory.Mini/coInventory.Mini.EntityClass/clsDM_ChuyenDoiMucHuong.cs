using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace coInventory.Mini.EntityClass
{
    public class clsDM_ChuyenDoiMucHuong
    {
        public int ChuyenDoi_Id;
        public string DoiTuong;
        public int MucHuongCu;
        public int MucHuongMoi;

        private string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public DataTable GetAll()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "select * from DM_ChuyenDoi order by DoiTuong";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }


        public static List<clsDM_ChuyenDoiMucHuong> GetListChuyenDoi()
        {
            List<clsDM_ChuyenDoiMucHuong> lst = new List<clsDM_ChuyenDoiMucHuong>();
            SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "select * from DM_ChuyenDoi order by DoiTuong";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            m_dbConnection.Close();
            foreach (DataRow row in dt.Rows)
            {
                clsDM_ChuyenDoiMucHuong mh = new clsDM_ChuyenDoiMucHuong();
                mh.ChuyenDoi_Id = int.Parse(row["ChuyenDoi_Id"].ToString());
                mh.DoiTuong = row["DoiTuong"].ToString();
                mh.MucHuongCu = int.Parse(row["MucHuongCu"].ToString());
                mh.MucHuongMoi = int.Parse(row["MucHuongMoi"].ToString());
                lst.Add(mh);
            }
            return lst;
        }

        public void GetByKey(string strDoiTuong)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_ChuyenDoi WHERE DoiTuong = @DoiTuong";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@DoiTuong", strDoiTuong));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                ChuyenDoi_Id = int.Parse(dt.Rows[0]["ChuyenDoi_Id"].ToString());
                DoiTuong = dt.Rows[0]["DoiTuong"].ToString();
                MucHuongCu = int.Parse(dt.Rows[0]["MucHuongCu"].ToString());
                MucHuongMoi = int.Parse(dt.Rows[0]["MucHuongMoi"].ToString());
            }
        }


        public static int GetMucHuongMoi(string strSoTheBHYT)
        {
            string strDoiTuong = "";
            int intMucHuong = 0;
            strSoTheBHYT=strSoTheBHYT.Replace("-", "").Trim();
            if (strSoTheBHYT.Length >= 3)
            {
                strDoiTuong = strSoTheBHYT.Substring(0, 2);
                intMucHuong = int.Parse(strSoTheBHYT.Substring(2, 1));
            }

            SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT MucHuongMoi FROM DM_ChuyenDoi WHERE DoiTuong = @DoiTuong and MucHuongCu=@MucHuongCu";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@DoiTuong", strDoiTuong));
            command.Parameters.Add(new SQLiteParameter("@MucHuongCu", intMucHuong));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["MucHuongMoi"].ToString());
            }
            return intMucHuong;
        }


        public int Insert()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO DM_ChuyenDoi (DoiTuong, MucHuongCu, MucHuongMoi) ";
            sql += " VALUES(@DoiTuong,@MucHuongCu,@MucHuongMoi)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@DoiTuong", DoiTuong));
            command.Parameters.Add(new SQLiteParameter("@MucHuongCu", MucHuongCu));
            command.Parameters.Add(new SQLiteParameter("@MucHuongMoi", MucHuongMoi));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
        public int Update()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "";
            sql += "UPDATE DM_ChuyenDoi ";
            sql += "SET DoiTuong=@DoiTuong,MucHuongCu=@MucHuongCu,MucHuongMoi=@MucHuongMoi ";
            sql += "WHERE DoiTuong=@DoiTuong";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@DoiTuong", DoiTuong));
            command.Parameters.Add(new SQLiteParameter("@MucHuongCu", MucHuongCu));
            command.Parameters.Add(new SQLiteParameter("@MucHuongMoi", MucHuongMoi));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }


        public int Insert(SQLiteDAL DAL)
        {

            string sql = "";
            sql += "INSERT INTO DM_ChuyenDoi (DoiTuong, MucHuongCu, MucHuongMoi) ";
            sql += " VALUES(@DoiTuong,@MucHuongCu,@MucHuongMoi)";

            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@DoiTuong", DoiTuong));
            command.Parameters.Add(new SQLiteParameter("@MucHuongCu", MucHuongCu));
            command.Parameters.Add(new SQLiteParameter("@MucHuongMoi", MucHuongMoi));

            int result = command.ExecuteNonQuery();

            return result;
        }
        public int Update(SQLiteDAL DAL)
        {

            string sql = "";
            sql += "UPDATE DM_ChuyenDoi ";
            sql += "SET DoiTuong=@DoiTuong,MucHuongCu=@MucHuongCu,MucHuongMoi=@MucHuongMoi ";
            sql += "WHERE DoiTuong=@DoiTuong";


            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@DoiTuong", DoiTuong));
            command.Parameters.Add(new SQLiteParameter("@MucHuongCu", MucHuongCu));
            command.Parameters.Add(new SQLiteParameter("@MucHuongMoi", MucHuongMoi));

            int result = command.ExecuteNonQuery();

            return result;
        }


        public int Delete(string strDoiTuong)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "Delete from DM_ChuyenDoi WHERE DoiTuong=@DoiTuong";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@DoiTuong", strDoiTuong));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public bool CheckTonTai(string strDoiTuong)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT DoiTuong FROM DM_ChuyenDoi WHERE DoiTuong=@DoiTuong";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@DoiTuong", strDoiTuong));
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
