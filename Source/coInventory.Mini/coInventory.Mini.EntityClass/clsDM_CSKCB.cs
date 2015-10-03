using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
//using WebService.Model;
using System.Collections;

namespace coInventory.Mini.EntityClass
{
    public class clsDM_CSKCB
    {

        public int CSKCB_Id;
        public string MaCSKCB;
        public string MaTinh;
        public string TenCSKCB;
        public bool? CSKCBBanDau = true;
        public int XepHang;
        public bool? Active = true;
        public string DiaChi;
        public int Tuyen;
        public decimal Quy1Quy;
        public bool? CoDuLieu = true;
        public string MaCapTren;

        SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public DataTable GetAll()
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_CSKCB";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public DataTable GetAllActive()
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_CSKCB Where Active=1";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }
       
        public void GetByKey(string strMa)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DM_CSKCB WHERE MaCSKCB=@MaCSKCB";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", strMa));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                CSKCB_Id =int.Parse( dt.Rows[0]["CSKCB_Id"].ToString());
                MaCSKCB = dt.Rows[0]["MaCSKCB"].ToString();
                MaTinh = dt.Rows[0]["MaTinh"].ToString();
                TenCSKCB = dt.Rows[0]["TenCSKCB"].ToString();
                CSKCBBanDau = string.IsNullOrEmpty(dt.Rows[0]["CSKCBBanDau"].ToString()) ? null : (bool?)dt.Rows[0]["CSKCBBanDau"];
                XepHang = string.IsNullOrEmpty(dt.Rows[0]["XepHang"].ToString()) ? 0 : int.Parse(dt.Rows[0]["XepHang"].ToString());
                Active = string.IsNullOrEmpty(dt.Rows[0]["Active"].ToString()) ? null : (bool?)dt.Rows[0]["Active"];
                DiaChi = dt.Rows[0]["DiaChi"].ToString();
                Tuyen = int.Parse(dt.Rows[0]["Tuyen"].ToString());
                Quy1Quy = decimal.Parse(dt.Rows[0]["Quy1Quy"].ToString());
                CoDuLieu = string.IsNullOrEmpty(dt.Rows[0]["CoDuLieu"].ToString()) ? null : (bool?)dt.Rows[0]["CoDuLieu"];   
                MaCapTren = dt.Rows[0]["MaCapTren"].ToString();                
            }
            
        }

        public int Insert()
        {
            m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO DM_CSKCB (MaCSKCB,MaTinh,TenCSKCB,CSKCBBanDau,XepHang,Active,DiaChi,Tuyen,Quy1Quy,CoDuLieu,MaCapTren) ";
            sql += " VALUES(@MaCSKCB,@MaTinh,@TenCSKCB,@CSKCBBanDau,@XepHang,@Active,@DiaChi,@Tuyen,@Quy1Quy,@CoDuLieu,@MaCapTren)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", MaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaTinh", MaTinh));
            command.Parameters.Add(new SQLiteParameter("@TenCSKCB", TenCSKCB));
            command.Parameters.Add(new SQLiteParameter("@CSKCBBanDau", CSKCBBanDau));
            command.Parameters.Add(new SQLiteParameter("@XepHang", XepHang));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@DiaChi", DiaChi));
            command.Parameters.Add(new SQLiteParameter("@Tuyen", Tuyen));
            command.Parameters.Add(new SQLiteParameter("@Quy1Quy", Quy1Quy));
            command.Parameters.Add(new SQLiteParameter("@CoDuLieu", CoDuLieu));
            command.Parameters.Add(new SQLiteParameter("@MaCapTren", MaCapTren));
            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        //Insert Trans
        public int Insert(SQLiteDAL DAL)
        {
            
            string sql = "";
            sql += "INSERT INTO DM_CSKCB (MaCSKCB,MaTinh,TenCSKCB,CSKCBBanDau,XepHang,Active,DiaChi,Tuyen,Quy1Quy,CoDuLieu,MaCapTren) ";
            sql += " VALUES(@MaCSKCB,@MaTinh,@TenCSKCB,@CSKCBBanDau,@XepHang,@Active,@DiaChi,@Tuyen,@Quy1Quy,@CoDuLieu,@MaCapTren)";

            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", MaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaTinh", MaTinh));
            command.Parameters.Add(new SQLiteParameter("@TenCSKCB", TenCSKCB));
            command.Parameters.Add(new SQLiteParameter("@CSKCBBanDau", CSKCBBanDau));
            command.Parameters.Add(new SQLiteParameter("@XepHang", XepHang));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@DiaChi", DiaChi));
            command.Parameters.Add(new SQLiteParameter("@Tuyen", Tuyen));
            command.Parameters.Add(new SQLiteParameter("@Quy1Quy", Quy1Quy));
            command.Parameters.Add(new SQLiteParameter("@CoDuLieu", CoDuLieu));
            command.Parameters.Add(new SQLiteParameter("@MaCapTren", MaCapTren));

            int result = command.ExecuteNonQuery();           
            return result;
        }

        public int Update()
        {

            m_dbConnection.Open();
                
            string sql = "";
            sql += "UPDATE DM_CSKCB SET MaCSKCB=@MaCSKCB,MaTinh=@MaTinh,TenCSKCB=@TenCSKCB,CSKCBBanDau=@CSKCBBanDau,XepHang=@XepHang,Active=@Active,DiaChi=@DiaChi,Tuyen=@Tuyen,Quy1Quy=@Quy1Quy,CoDuLieu=@CoDuLieu,MaCapTren =@MaCapTren ";
            sql += "WHERE MaCSKCB=@MaCSKCB";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", MaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaTinh", MaTinh));
            command.Parameters.Add(new SQLiteParameter("@TenCSKCB", TenCSKCB));
            command.Parameters.Add(new SQLiteParameter("@CSKCBBanDau", CSKCBBanDau));
            command.Parameters.Add(new SQLiteParameter("@XepHang", XepHang));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@DiaChi", DiaChi));
            command.Parameters.Add(new SQLiteParameter("@Tuyen", Tuyen));
            command.Parameters.Add(new SQLiteParameter("@Quy1Quy", Quy1Quy));
            command.Parameters.Add(new SQLiteParameter("@CoDuLieu", CoDuLieu));
            command.Parameters.Add(new SQLiteParameter("@MaCapTren", MaCapTren));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        //update trans
        public int Update(SQLiteDAL DAL)
        {        

            string sql = "";
            sql += "UPDATE DM_CSKCB SET MaCSKCB=@MaCSKCB,MaTinh=@MaTinh,TenCSKCB=@TenCSKCB,CSKCBBanDau=@CSKCBBanDau,XepHang=@XepHang,Active=@Active,DiaChi=@DiaChi,Tuyen=@Tuyen,Quy1Quy=@Quy1Quy,CoDuLieu=@CoDuLieu,MaCapTren =@MaCapTren ";
            sql += "WHERE MaCSKCB=@MaCSKCB";

            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", MaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaTinh", MaTinh));
            command.Parameters.Add(new SQLiteParameter("@TenCSKCB", TenCSKCB));
            command.Parameters.Add(new SQLiteParameter("@CSKCBBanDau", CSKCBBanDau));
            command.Parameters.Add(new SQLiteParameter("@XepHang", XepHang));
            command.Parameters.Add(new SQLiteParameter("@Active", Active));
            command.Parameters.Add(new SQLiteParameter("@DiaChi", DiaChi));
            command.Parameters.Add(new SQLiteParameter("@Tuyen", Tuyen));
            command.Parameters.Add(new SQLiteParameter("@Quy1Quy", Quy1Quy));
            command.Parameters.Add(new SQLiteParameter("@CoDuLieu", CoDuLieu));
            command.Parameters.Add(new SQLiteParameter("@MaCapTren", MaCapTren));

            int result = command.ExecuteNonQuery();
            return result;
        }

        public int Delete(string strMaCSKCB)
        {
            m_dbConnection.Open();

            string sql = "Delete from DM_CSKCB WHERE MaCSKCB=@MaCSKCB";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", strMaCSKCB));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public bool CheckTonTai(string strMa)
        {

            DataTable dt = new DataTable();
            string sql = "SELECT MaCSKCB FROM DM_CSKCB WHERE MaCSKCB=@MaCSKCB";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", strMa));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
      
    }
}
