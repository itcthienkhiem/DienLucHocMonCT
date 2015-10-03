using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace coInventory.Mini.EntityClass
{
    public class clsBangKeChanDoan
    {
        public int ChuanDoan_Id;
        public int BangKe_Id;
        public string MaICD;
        public int STT;

         SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public DataTable GetAll(int intBangKe_Id)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BangKeChanDoan Where BangKe_Id = @BangKe_Id";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", intBangKe_Id));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

         public int Insert(SQLiteDAL DAL)
        {
            string sql = "";
            sql += "INSERT INTO BangKeChanDoan (BangKe_Id,MaICD,STT) ";
            sql += "VALUES(@BangKe_Id,@MaICD,@STT)";

            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            //command.Parameters.Add(new SQLiteParameter("@BangKeChiTiet_Id", );
            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
            command.Parameters.Add(new SQLiteParameter("@MaICD", MaICD));
            command.Parameters.Add(new SQLiteParameter("@STT", STT));

            int result = command.ExecuteNonQuery();
            return result;
        }

        /// <summary>
        /// Hàm Insert Normal
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {

            m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO BangKeChanDoan (BangKe_Id,MaICD,STT) ";
            sql += "VALUES(@BangKe_Id,@MaICD,@STT)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

             command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
            command.Parameters.Add(new SQLiteParameter("@MaICD", MaICD));
            command.Parameters.Add(new SQLiteParameter("@STT", STT));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }


        public int Delete(int BangKe_Id)
        {
            m_dbConnection.Open();

            string sql = "Delete from BangKeChanDoan WHERE BangKe_Id=@BangKe_Id";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
    }
}
