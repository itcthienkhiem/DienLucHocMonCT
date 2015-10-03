using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace coInventory.Mini.EntityClass
{
    public class clsBangKeChiTiet
    {
        public int BangKeChiTiet_Id;
        public int BangKe_Id;
        public string MaChiPhi;
        public string MaPhu;
        public string TenChiPhi;
        public string DonViTinh;
        public decimal SoLuong; public decimal PhanTramDuocHuong;
        public decimal DonGiaBHYT;
        public decimal ThanhTienBHYT;
        public decimal BHYTThanhToan;
        public decimal NguonKhac;
        public decimal NguoiBenhTra;
        public decimal ChiPhiNgoaiDinhSuat;
        public string MaNhom1;
        public string MaNhom2;
        public string MaLoaiChiPhi;
        public bool VTYTDichVuKTC = false;
        public bool DichVuKTC = false;
        public string GhiChu;
        public decimal TyLeThanhToan;

        public clsBangKeChiTiet()
        { 
             BangKeChiTiet_Id=0;
         BangKe_Id=0;
         MaChiPhi="";
         MaPhu = "";
         TenChiPhi = "";
         DonViTinh = "";
         SoLuong = 0; PhanTramDuocHuong = 0;
         DonGiaBHYT = 0;
         ThanhTienBHYT = 0;
         BHYTThanhToan = 0;
         NguonKhac = 0;
         NguoiBenhTra = 0;
         ChiPhiNgoaiDinhSuat = 0;
         MaNhom1 = "";
         MaNhom2 = "";
         MaLoaiChiPhi = "";
         VTYTDichVuKTC = false;
         DichVuKTC = false;
         GhiChu = "";
         TyLeThanhToan = 100;
        }
        SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        public DataTable GetByID(int id )
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BangKeChiTiet where BangKe_Id = "+id;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
         }
        public DataTable GetAll(int intBangKe_Id)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT *,  ";
            sql += " CASE WHEN MaLoaiChiPhi='T' THEN 'Thuốc' ";
            sql += " WHEN MaLoaiChiPhi='D' THEN 'Dịch vụ'";

            sql += " WHEN MaLoaiChiPhi='V' THEN 'Vật tư y tế'";
            sql += " ELSE 'Máu và chế phẩm' ";
            sql += " END as GroupName ";
            sql += " FROM BangKeChiTiet Where BangKe_Id = @BangKe_Id";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", intBangKe_Id));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public void GetByKey(string intBangKeChiTiet_Id)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BangKeChiTiet Where BangKeChiTiet_Id = @BangKeChiTiet_Id";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@MaThuoc", intBangKeChiTiet_Id));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {


            }
        }

        /// <summary>
        /// Hàm Insert Trans
        /// </summary>
        /// <param name="DAL"></param>
        /// <returns></returns>

        public int Insert(SQLiteDAL DAL)
        {
            string sql = "";
            sql += "INSERT INTO BangKeChiTiet (BangKe_Id,MaChiPhi,MaPhu,TenChiPhi,DonViTinh,SoLuong,PhanTramDuocHuong,DonGiaBHYT,ThanhTienBHYT,BHYTThanhToan,NguonKhac,NguoiBenhTra,ChiPhiNgoaiDinhSuat,MaNhom1,MaNhom2,MaLoaiChiPhi,VTYTDichVuKTC,DichVuKTC,GhiChu,TyLeThanhToan) ";
            sql += "VALUES(@BangKe_Id,@MaChiPhi,@MaPhu,@TenChiPhi,@DonViTinh,@SoLuong,@PhanTramDuocHuong,@DonGiaBHYT,@ThanhTienBHYT,@BHYTThanhToan,@NguonKhac,@NguoiBenhTra,@ChiPhiNgoaiDinhSuat,@MaNhom1,@MaNhom2,@MaLoaiChiPhi,@VTYTDichVuKTC,@DichVuKTC,@GhiChu,@TyLeThanhToan)";

            SQLiteCommand command = new SQLiteCommand(sql, DAL.m_conn);
            command.Transaction = DAL.m_trans;
            command.CommandType = CommandType.Text;

            //command.Parameters.Add(new SQLiteParameter("@BangKeChiTiet_Id", );
            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
            command.Parameters.Add(new SQLiteParameter("@MaChiPhi", MaChiPhi));
            command.Parameters.Add(new SQLiteParameter("@MaPhu", MaPhu));
            command.Parameters.Add(new SQLiteParameter("@TenChiPhi", TenChiPhi));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@SoLuong", SoLuong));
            command.Parameters.Add(new SQLiteParameter("@PhanTramDuocHuong", PhanTramDuocHuong));
            command.Parameters.Add(new SQLiteParameter("@DonGiaBHYT", DonGiaBHYT));
            command.Parameters.Add(new SQLiteParameter("@ThanhTienBHYT", ThanhTienBHYT));
            command.Parameters.Add(new SQLiteParameter("@BHYTThanhToan", BHYTThanhToan));
            command.Parameters.Add(new SQLiteParameter("@NguonKhac", NguonKhac));
            command.Parameters.Add(new SQLiteParameter("@NguoiBenhTra", NguoiBenhTra));
            command.Parameters.Add(new SQLiteParameter("@ChiPhiNgoaiDinhSuat", ChiPhiNgoaiDinhSuat));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@MaLoaiChiPhi", MaLoaiChiPhi));
            command.Parameters.Add(new SQLiteParameter("@VTYTDichVuKTC", VTYTDichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@DichVuKTC", DichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));
            command.Parameters.Add(new SQLiteParameter("@TyLeThanhToan", TyLeThanhToan));



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
            sql += "INSERT INTO BangKeChiTiet (BangKe_Id,MaChiPhi,MaPhu,TenChiPhi,DonViTinh,SoLuong,PhanTramDuocHuong,DonGiaBHYT,ThanhTienBHYT,BHYTThanhToan,NguonKhac,NguoiBenhTra,ChiPhiNgoaiDinhSuat,MaNhom1,MaNhom2,MaLoaiChiPhi,VTYTDichVuKTC,DichVuKTC,GhiChu,TyLeThanhToan) ";
            sql += "VALUES(@BangKe_Id,@MaChiPhi,@MaPhu,@TenChiPhi,@DonViTinh,@SoLuong,@PhanTramDuocHuong,@DonGiaBHYT,@ThanhTienBHYT,@BHYTThanhToan,@NguonKhac,@NguoiBenhTra,@ChiPhiNgoaiDinhSuat,@MaNhom1,@MaNhom2,@MaLoaiChiPhi,@VTYTDichVuKTC,@DichVuKTC,@GhiChu,@TyLeThanhToan)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            //command.Parameters.Add(new SQLiteParameter("@BangKeChiTiet_Id", );
            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
            command.Parameters.Add(new SQLiteParameter("@MaChiPhi", MaChiPhi));
            command.Parameters.Add(new SQLiteParameter("@MaPhu", MaPhu));
            command.Parameters.Add(new SQLiteParameter("@TenChiPhi", TenChiPhi));
            command.Parameters.Add(new SQLiteParameter("@DonViTinh", DonViTinh));
            command.Parameters.Add(new SQLiteParameter("@SoLuong", SoLuong));
            command.Parameters.Add(new SQLiteParameter("@PhanTramDuocHuong", PhanTramDuocHuong));
            command.Parameters.Add(new SQLiteParameter("@DonGiaBHYT", DonGiaBHYT));
            command.Parameters.Add(new SQLiteParameter("@ThanhTienBHYT", ThanhTienBHYT));
            command.Parameters.Add(new SQLiteParameter("@BHYTThanhToan", BHYTThanhToan));
            command.Parameters.Add(new SQLiteParameter("@NguonKhac", NguonKhac));
            command.Parameters.Add(new SQLiteParameter("@NguoiBenhTra", NguoiBenhTra));
            command.Parameters.Add(new SQLiteParameter("@ChiPhiNgoaiDinhSuat", ChiPhiNgoaiDinhSuat));
            command.Parameters.Add(new SQLiteParameter("@MaNhom1", MaNhom1));
            command.Parameters.Add(new SQLiteParameter("@MaNhom2", MaNhom2));
            command.Parameters.Add(new SQLiteParameter("@MaLoaiChiPhi", MaLoaiChiPhi));
            command.Parameters.Add(new SQLiteParameter("@VTYTDichVuKTC", VTYTDichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@DichVuKTC", DichVuKTC));
            command.Parameters.Add(new SQLiteParameter("@GhiChu", GhiChu));
            command.Parameters.Add(new SQLiteParameter("@TyLeThanhToan", TyLeThanhToan));
            

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }


        public int Delete(int BangKe_Id)
        {
            m_dbConnection.Open();

            string sql = "Delete from BangKeChiTiet WHERE BangKe_Id=@BangKe_Id";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }


        
    }
}
