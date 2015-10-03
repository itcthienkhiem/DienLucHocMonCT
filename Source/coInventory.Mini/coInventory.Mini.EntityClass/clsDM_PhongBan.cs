using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace coInventory.Mini.EntityClass
{
  public  class clsDM_PhongBan
    {
      public int? PhongBan_Id;
      public string MaPhongBan;
      public string TenPhongBan;
      public string LoaiPhongBan;
      public bool? Active;
       SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);

      public DataTable GetAll()
      {

          m_dbConnection.Open();
          DataTable dt = new DataTable();
          string sql = "select * from DM_PhongBan order by MaPhongBan";
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
          string sql = "select * from DM_PhongBan Where Active=1 order by MaPhongBan";
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
          string sql = "SELECT * FROM DM_PhongBan WHERE MaPhongBan=@MaPhongBan";
          SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
          command.Parameters.Add(new SQLiteParameter("@MaPhongBan", strMa));
          SQLiteDataAdapter da = new SQLiteDataAdapter(command);
          da.Fill(dt);
          m_dbConnection.Close();

          if (dt.Rows.Count > 0)
          {
              MaPhongBan = (dt.Rows[0]["MaPhongBan"].ToString());
              TenPhongBan = dt.Rows[0]["TenPhongBan"].ToString();
              LoaiPhongBan = dt.Rows[0]["LoaiPhongBan"].ToString();
              Active = string.IsNullOrEmpty(dt.Rows[0]["Active"].ToString()) ? null : (bool?)dt.Rows[0]["Active"]; ;
              PhongBan_Id = int.Parse(dt.Rows[0]["PhongBan_Id"].ToString())  ;
          }
      }


      public int Insert()
      {
          //SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
          m_dbConnection.Open();

          string sql = "";
          sql += "INSERT INTO DM_PhongBan (MaPhongBan, TenPhongBan, LoaiPhongBan, Active) ";
          sql += " VALUES(@MaPhongBan,@TenPhongBan,@LoaiPhongBan,@Active)";

          SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
          command.CommandType = CommandType.Text;

          command.Parameters.Add(new SQLiteParameter("@MaPhongBan", MaPhongBan));
          command.Parameters.Add(new SQLiteParameter("@TenPhongBan", TenPhongBan));
          command.Parameters.Add(new SQLiteParameter("@LoaiPhongBan", LoaiPhongBan));
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
          sql += "UPDATE DM_PhongBan ";
          sql += "SET MaPhongBan=@MaPhongBan,TenPhongBan=@TenPhongBan,LoaiPhongBan=@LoaiPhongBan,Active=@Active ";
          sql += "WHERE MaPhongBan=@MaPhongBan";


          SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
          command.CommandType = CommandType.Text;

          command.Parameters.Add(new SQLiteParameter("@MaPhongBan", MaPhongBan));
          command.Parameters.Add(new SQLiteParameter("@TenPhongBan", TenPhongBan));
          command.Parameters.Add(new SQLiteParameter("@LoaiPhongBan", LoaiPhongBan));
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
          sql += "INSERT INTO DM_PhongBan (MaPhongBan, TenPhongBan, LoaiPhongBan, Active) ";
          sql += " VALUES(@MaPhongBan,@TenPhongBan,@LoaiPhongBan,@Active)";

          SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
          command.Transaction = DAL.m_trans;
          command.CommandType = CommandType.Text;

          command.Parameters.Add(new SQLiteParameter("@MaPhongBan", MaPhongBan));
          command.Parameters.Add(new SQLiteParameter("@TenPhongBan", TenPhongBan));
          command.Parameters.Add(new SQLiteParameter("@LoaiPhongBan", LoaiPhongBan));
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
          sql += "UPDATE DM_PhongBan ";
          sql += "SET MaPhongBan=@MaPhongBan,TenPhongBan=@TenPhongBan,LoaiPhongBan=@LoaiPhongBan,Active=@Active ";
          sql += "WHERE MaPhongBan=@MaPhongBan";


          SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
          command.Transaction = DAL.m_trans;
          command.CommandType = CommandType.Text;

          command.Parameters.Add(new SQLiteParameter("@MaPhongBan", MaPhongBan));
          command.Parameters.Add(new SQLiteParameter("@TenPhongBan", TenPhongBan));
          command.Parameters.Add(new SQLiteParameter("@LoaiPhongBan", LoaiPhongBan));
          command.Parameters.Add(new SQLiteParameter("@Active", Active));

          int result = command.ExecuteNonQuery();
          //m_dbConnection.Close();
          return result;
      }

      public int Delete(string strMa)
      {
          //SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
          m_dbConnection.Open();

          string sql = "Delete from DM_PhongBan WHERE MaPhongBan=@MaPhongBan";


          SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
          command.CommandType = CommandType.Text;

          command.Parameters.Add(new SQLiteParameter("@MaPhongBan", strMa));

          int result = command.ExecuteNonQuery();
          m_dbConnection.Close();
          return result;
      }

      public bool CheckTonTai(string strMa)
      {
          //SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
          m_dbConnection.Open();
          DataTable dt = new DataTable();
          string sql = "SELECT MaPhongBan FROM DM_PhongBan WHERE MaPhongBan=@MaPhongBan";
          SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
          command.Parameters.Add(new SQLiteParameter("@MaPhongBan", strMa));
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
