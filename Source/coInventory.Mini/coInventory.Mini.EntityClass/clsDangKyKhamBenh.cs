using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace coInventory.Mini.EntityClass
{
   public class clsDangKyKhamBenh
    {
       public int KhamBenh_Id;
       public int? SoDKKCBBHYT;
       public string MaCSKCB;
       public string MaCSKCBBĐ;
       public string SoTheBHYT;
       public DateTime? TuNgay;
       public DateTime? DenNgay;
       public string HoTen;
       public DateTime? NgaySinh;
       public int GioiTinh;
       public string DiaChi;
       public string MaNoiSinhSong;
       public int LyDoVV;
       public string MaNoiChuyenDen;
       public DateTime? NgayDenKham;
       public bool ChungNhanKhongCTT;
       public string GhiChu;
       
       
        SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public DataTable GetAll()
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DangKyKhamBenh";
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
            string sql = "SELECT * FROM DangKyKhamBenh WHERE SoDKKCBBHYT=@SoDKKCBBHYT";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@SoDKKCBBHYT", strMa));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                KhamBenh_Id = int.Parse(dt.Rows[0]["KhamBenh_Id"].ToString());
                SoDKKCBBHYT = string.IsNullOrEmpty(dt.Rows[0]["SoDKKCBBHYT"].ToString()) ? int.MaxValue :int.Parse( dt.Rows[0]["SoDKKCBBHYT"].ToString());
                MaCSKCB = dt.Rows[0]["MaCSKCB"].ToString();
                MaCSKCBBĐ = dt.Rows[0]["MaCSKCBBĐ"].ToString();
                SoTheBHYT = dt.Rows[0]["SoTheBHYT"].ToString();

                TuNgay =dt.Rows[0]["TuNgay"]is DBNull?DateTime.MinValue: DateTime.Parse(dt.Rows[0]["TuNgay"].ToString());
                DenNgay = dt.Rows[0]["DenNgay"] is DBNull ? DateTime.MinValue : DateTime.Parse(dt.Rows[0]["DenNgay"].ToString());
                HoTen = dt.Rows[0]["HoTen"].ToString();
                NgaySinh = dt.Rows[0]["NgaySinh"] is DBNull ? DateTime.MinValue : DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
                GioiTinh = (dt.Rows[0]["GioiTinh"]) is DBNull ? int.MaxValue : int.Parse( dt.Rows[0]["GioiTinh"].ToString());
                DiaChi = string.IsNullOrEmpty(dt.Rows[0]["DiaChi"].ToString()) ? "" : dt.Rows[0]["DiaChi"].ToString();
                MaNoiSinhSong = string.IsNullOrEmpty(dt.Rows[0]["MaNoiSinhSong"].ToString()) ? "" : dt.Rows[0]["MaNoiSinhSong"].ToString();
                LyDoVV = dt.Rows[0]["LyDoVV"] is DBNull ? int.MinValue : Convert.ToInt32(dt.Rows[0]["LyDoVV"].ToString());
                MaNoiChuyenDen = string.IsNullOrEmpty(dt.Rows[0]["MaNoiChuyenDen"].ToString()) ? "" : dt.Rows[0]["MaNoiChuyenDen"].ToString();
                NgayDenKham =  dt.Rows[0]["NgayDenKham"] is DBNull? DateTime.MinValue:DateTime.Parse( dt.Rows[0]["NgayDenKham"].ToString());
                ChungNhanKhongCTT =dt.Rows[0]["ChungNhanKhongCTT"] is DBNull? false:bool.Parse( dt.Rows[0]["ChungNhanKhongCTT"].ToString());
                GhiChu = string.IsNullOrEmpty(dt.Rows[0]["GhiChu"].ToString()) ? "" : dt.Rows[0]["TrongDanhMucBHYT"].ToString();
               
            }
        }


        public int Insert()
        {
            m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO DangKyKhamBenh (SoDKKCBBHYT,MaCSKCB,MaCSKCBBĐ,SoTheBHYT,TuNgay,DenNgay,HoTen,NgaySinh,GioiTinh,DiaChi,MaNoiSinhSong,LyDoVV,MaNoiChuyenDen,NgayDenKham,ChungNhanKhongCTT,GhiChu) ";
            sql += "VALUES(@SoDKKCBBHYT,@MaCSKCB,@MaCSKCBBĐ,@SoTheBHYT,@TuNgay,@DenNgay,@HoTen,@NgaySinh,@GioiTinh,@DiaChi,@MaNoiSinhSong,@LyDoVV,@MaNoiChuyenDen,@NgayDenKham,@ChungNhanKhongCTT,@GhiChu)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@SoDKKCBBHYT", SoDKKCBBHYT));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", MaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCBBĐ", MaCSKCBBĐ));
            command.Parameters.Add(new SQLiteParameter("@SoTheBHYT", SoTheBHYT));
            command.Parameters.Add(new SQLiteParameter("@TuNgay", TuNgay));
            command.Parameters.Add(new SQLiteParameter("@DenNgay", DenNgay));
            command.Parameters.Add(new SQLiteParameter("@HoTen", HoTen));
            command.Parameters.Add(new SQLiteParameter("@NgaySinh", NgaySinh));
            command.Parameters.Add(new SQLiteParameter("@GioiTinh", GioiTinh));
            command.Parameters.Add(new SQLiteParameter("@DiaChi", DiaChi));
            command.Parameters.Add(new SQLiteParameter("@MaNoiSinhSong", MaNoiSinhSong));
            command.Parameters.Add(new SQLiteParameter("@LyDoVV", LyDoVV));
            command.Parameters.Add(new SQLiteParameter("@MaNoiChuyenDen", MaNoiChuyenDen));
            command.Parameters.Add(new SQLiteParameter("@NgayDenKham", NgayDenKham));
            command.Parameters.Add(new SQLiteParameter("@ChungNhanKhongCTT", ChungNhanKhongCTT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
        public int Update()
        {
            m_dbConnection.Open();

            string sql = "";
            sql += " UPDATE DangKyKhamBenh ";
            sql += " SET  SoDKKCBBHYT=@SoDKKCBBHYT ,MaCSKCB =@MaCSKCB,MaCSKCBBĐ=@MaCSKCBBĐ,SoTheBHYT=@SoTheBHYT,TuNgay=@TuNgay,DenNgay=@DenNgay,HoTen=@HoTen,NgaySinh=@NgaySinh,GioiTinh=@GioiTinh,DiaChi=@DiaChi,MaNoiSinhSong=@MaNoiSinhSong,LyDoVV=@LyDoVV,MaNoiChuyenDen=@MaNoiChuyenDen,NgayDenKham=@NgayDenKham,ChungNhanKhongCTT=@ChungNhanKhongCTT,GhiChu=@GhiChu";
            sql += " WHERE SoDKKCBBHYT=@SoDKKCBBHYT";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@SoDKKCBBHYT", SoDKKCBBHYT));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", MaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCBBĐ", MaCSKCBBĐ));
            command.Parameters.Add(new SQLiteParameter("@SoTheBHYT", SoTheBHYT));
            command.Parameters.Add(new SQLiteParameter("@TuNgay", TuNgay));
            command.Parameters.Add(new SQLiteParameter("@DenNgay", DenNgay));
            command.Parameters.Add(new SQLiteParameter("@HoTen", HoTen));
            command.Parameters.Add(new SQLiteParameter("@NgaySinh", NgaySinh));
            command.Parameters.Add(new SQLiteParameter("@GioiTinh", GioiTinh));
            command.Parameters.Add(new SQLiteParameter("@DiaChi", DiaChi));
            command.Parameters.Add(new SQLiteParameter("@MaNoiSinhSong", MaNoiSinhSong));
            command.Parameters.Add(new SQLiteParameter("@LyDoVV", LyDoVV));
            command.Parameters.Add(new SQLiteParameter("@MaNoiChuyenDen", MaNoiChuyenDen));
            command.Parameters.Add(new SQLiteParameter("@NgayDenKham", NgayDenKham));
            command.Parameters.Add(new SQLiteParameter("@ChungNhanKhongCTT", ChungNhanKhongCTT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }


        public int Insert(SQLiteDAL DAL)
        {
            string sql = "";
            sql += " INSERT INTO DangKyKhamBenh (SoDKKCBBHYT,MaCSKCB,MaCSKCBBĐ,SoTheBHYT,TuNgay,DenNgay,HoTen,NgaySinh,GioiTinh,DiaChi,MaNoiSinhSong,LyDoVV,MaNoiChuyenDen,NgayDenKham,ChungNhanKhongCTT,GhiChu)";
            sql += " VALUES(@SoDKKCBBHYT,@MaCSKCB,@MaCSKCBBĐ,@SoTheBHYT,@TuNgay,@DenNgay,@HoTen,@NgaySinh,@GioiTinh,@DiaChi,@MaNoiSinhSong,@LyDoVV,@MaNoiChuyenDen,@NgayDenKham,@ChungNhanKhongCTT,@GhiChu)";

            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@SoDKKCBBHYT", SoDKKCBBHYT));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", MaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCBBĐ", MaCSKCBBĐ));
            command.Parameters.Add(new SQLiteParameter("@SoTheBHYT", SoTheBHYT));
            command.Parameters.Add(new SQLiteParameter("@TuNgay", TuNgay));
            command.Parameters.Add(new SQLiteParameter("@DenNgay", DenNgay));
            command.Parameters.Add(new SQLiteParameter("@HoTen", HoTen));
            command.Parameters.Add(new SQLiteParameter("@NgaySinh", NgaySinh));
            command.Parameters.Add(new SQLiteParameter("@GioiTinh", GioiTinh));
            command.Parameters.Add(new SQLiteParameter("@DiaChi", DiaChi));
            command.Parameters.Add(new SQLiteParameter("@MaNoiSinhSong", MaNoiSinhSong));
            command.Parameters.Add(new SQLiteParameter("@LyDoVV", LyDoVV));
            command.Parameters.Add(new SQLiteParameter("@MaNoiChuyenDen", MaNoiChuyenDen));
            command.Parameters.Add(new SQLiteParameter("@NgayDenKham", NgayDenKham));
            command.Parameters.Add(new SQLiteParameter("@ChungNhanKhongCTT", ChungNhanKhongCTT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));

            int result = command.ExecuteNonQuery();
            //m_dbConnection.Close();
            return result;
        }
        public int Update(SQLiteDAL DAL)
        {
            string sql = "";
            sql += " UPDATE DangKyKhamBenh ";
            sql += " SET SoDKKCBBHYT=@SoDKKCBBHYT ,MaCSKCB =@MaCSKCB,MaCSKCBBĐ=@MaCSKCBBĐ,SoTheBHYT=@SoTheBHYT,TuNgay=@TuNgay,DenNgay=@DenNgay,HoTen=@HoTen,NgaySinh=@NgaySinh,GioiTinh=@GioiTinh,DiaChi=@DiaChi,MaNoiSinhSong=@MaNoiSinhSong,LyDoVV=@LyDoVV,MaNoiChuyenDen=@MaNoiChuyenDen,NgayDenKham=@NgayDenKham,ChungNhanKhongCTT=@ChungNhanKhongCTT,GhiChu=@GhiChu";
            sql += " WHERE SoDKKCBBHYT=@SoDKKCBBHYT";


            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@SoDKKCBBHYT", SoDKKCBBHYT));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", MaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCBBĐ", MaCSKCBBĐ));
            command.Parameters.Add(new SQLiteParameter("@SoTheBHYT", SoTheBHYT));
            command.Parameters.Add(new SQLiteParameter("@TuNgay", TuNgay));
            command.Parameters.Add(new SQLiteParameter("@DenNgay", DenNgay));
            command.Parameters.Add(new SQLiteParameter("@HoTen", HoTen));
            command.Parameters.Add(new SQLiteParameter("@NgaySinh", NgaySinh));
            command.Parameters.Add(new SQLiteParameter("@GioiTinh", GioiTinh));
            command.Parameters.Add(new SQLiteParameter("@DiaChi", DiaChi));
            command.Parameters.Add(new SQLiteParameter("@MaNoiSinhSong", MaNoiSinhSong));
            command.Parameters.Add(new SQLiteParameter("@LyDoVV", LyDoVV));
            command.Parameters.Add(new SQLiteParameter("@MaNoiChuyenDen", MaNoiChuyenDen));
            command.Parameters.Add(new SQLiteParameter("@NgayDenKham", NgayDenKham));
            command.Parameters.Add(new SQLiteParameter("@ChungNhanKhongCTT", ChungNhanKhongCTT));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));


            int result = command.ExecuteNonQuery();
            return result;
        }
        public bool XoaHoSo(string SoHoSo)
        {

            m_dbConnection.Open();

            string sql = "Delete from DangKyKhamBenh WHERE SoDKKCBBHYT=@SoDKKCBBHYT";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@SoDKKCBBHYT", SoHoSo));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();

            if (result == 1)
                return true;
            return false;
        }

        public int Delete(string strMa)
        {

            m_dbConnection.Open();

            string sql = "Delete from DangKyKhamBenh WHERE SoDKKCBBHYT=@SoDKKCBBHYT";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@SoDKKCBBHYT", strMa));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }
        public bool CheckTonTaiKCB(string strMa)
        {

            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM DANGKYKHAMBENH WHERE SoDKKCBBHYT=@SoDKKCBBHYT";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@SoDKKCBBHYT", strMa));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

           

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool CheckTonTai(string strMaVTYT)
        {

            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT DangKyKhamBenh FROM DM_VTYT WHERE SoDKKCBBHYT=@SoDKKCBBHYT";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@SoDKKCBBHYT", strMaVTYT));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            clsDM_VTYT obj = new clsDM_VTYT();

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
