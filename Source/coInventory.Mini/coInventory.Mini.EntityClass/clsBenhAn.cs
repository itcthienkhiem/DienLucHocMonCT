using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace coInventory.Mini.EntityClass
{
    public class clsBenhAn
    {
        public int BenhAn_Id { set; get; }
        public string SoLuuTru { set; get; }
        public string MaYTe { set; get; }
        public string HoTen { set; get; }
        public int? GioiTinh { set; get; }
        public string NoiChuyenDen { set; get; }
        public int? Tuoi { set; get; }
        public string DanToc { set; get; }
        public string DiaChi { set; get; }
        public string QuocTich { set; get; }
        public string NgheNghiep { set; get; }
        public string NoiLamViec { set; get; }
        public DateTime? GiaTriTu { set; get; }
        public DateTime? GiaTriDen { set; get; }
        public string SoTheBHYT { set; get; }
        public string TenCSKCB { set; get; }
        public string MaCSKCB { set; get; }
        public DateTime? NgayVao { set; get; }
        public DateTime? NgayRa { set; get; }
        public string DauHieu { set; get; }
        public string KetQua { set; get; }
        public string ChanDoan { set; get; }
        public string PhuongPhap { set; get; }
        public string TinhTrang { set; get; }
        public int? LyDo { set; get; }
        public DateTime? ChuyenTuyenHoi { set; get; }
        public string HuongDieuTri { set; get; }
        public string PhuongTienVanChuyen { set; get; }
        public string NguoiHoTong { set; get; }
        public string Loai { set; get; }
        public string ChanDoanGPBL { set; get; }
        public string LoiDanThayThuoc { set; get; }
        public string LyDoStr { set; get; }

        SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public clsBenhAn()
        {
        }

        public DataTable GetAll(string strLoai)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BenhAn Where Loai=@Loai";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@Loai", strLoai));

            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public DataTable GetByKey(string strSoLuuTru, string strLoai)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BenhAn Where Loai=@Loai and SoLuuTru=@SoLuuTru";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@Loai", strLoai));
            command.Parameters.Add(new SQLiteParameter("@SoLuuTru", strSoLuuTru));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        //public DataTable GetByKey(DateTime dateTuNgay, DateTime dateDenNgay, string strLoai)
        //{
        //    m_dbConnection.Open();
        //    DataTable dt = new DataTable();
        //    string sql = "SELECT * FROM BenhAn Where Loai=@Loai and (Ngay between @TuNgay and @DenNgay) order by BangKe_Id desc";
        //    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
        //    command.Parameters.Add(new SQLiteParameter("@Loai", strLoai));
        //    command.Parameters.Add(new SQLiteParameter("@TuNgay", new DateTime(dateTuNgay.Year, dateTuNgay.Month, dateTuNgay.Day)));
        //    command.Parameters.Add(new SQLiteParameter("@DenNgay", new DateTime(dateDenNgay.Year, dateDenNgay.Month, dateDenNgay.Day)));
        //    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
        //    da.Fill(dt);
        //    m_dbConnection.Close();
        //    return dt;
        //}

        public void GetBySoLuuTru(string strSoLuuTru, string strLoai)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BenhAn WHERE SoLuuTru=@SoLuuTru and Loai=@Loai";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@SoLuuTru", strSoLuuTru));
            command.Parameters.Add(new SQLiteParameter("@Loai", strLoai));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {

                BenhAn_Id = Int32.Parse(dt.Rows[0]["BenhAn_Id"].ToString());
                SoLuuTru = string.IsNullOrEmpty(dt.Rows[0]["SoLuuTru"].ToString()) ? "" : dt.Rows[0]["SoLuuTru"].ToString();
                MaYTe = string.IsNullOrEmpty(dt.Rows[0]["MaYTe"].ToString()) ? "" : dt.Rows[0]["MaYTe"].ToString();
                HoTen = string.IsNullOrEmpty(dt.Rows[0]["HoTen"].ToString()) ? "" : dt.Rows[0]["HoTen"].ToString();
                GioiTinh = string.IsNullOrEmpty(dt.Rows[0]["GioiTinh"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["GioiTinh"].ToString());
                NoiChuyenDen = string.IsNullOrEmpty(dt.Rows[0]["NoiChuyenDen"].ToString()) ? "" : dt.Rows[0]["NoiChuyenDen"].ToString();
                Tuoi = string.IsNullOrEmpty(dt.Rows[0]["Tuoi"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["Tuoi"].ToString());
                DanToc = string.IsNullOrEmpty(dt.Rows[0]["DanToc"].ToString()) ? "" : dt.Rows[0]["DanToc"].ToString();
                DiaChi = string.IsNullOrEmpty(dt.Rows[0]["DiaChi"].ToString()) ? "" : dt.Rows[0]["DiaChi"].ToString();
                QuocTich = string.IsNullOrEmpty(dt.Rows[0]["QuocTich"].ToString()) ? "" : dt.Rows[0]["QuocTich"].ToString();
                NgheNghiep = string.IsNullOrEmpty(dt.Rows[0]["NgheNghiep"].ToString()) ? "" : dt.Rows[0]["NgheNghiep"].ToString();
                NoiLamViec = string.IsNullOrEmpty(dt.Rows[0]["NoiLamViec"].ToString()) ? "" : dt.Rows[0]["NoiLamViec"].ToString();

                GiaTriTu = string.IsNullOrEmpty(dt.Rows[0]["GiaTriTu"].ToString()) ? null : (DateTime?)dt.Rows[0]["GiaTriTu"];
                GiaTriDen = string.IsNullOrEmpty(dt.Rows[0]["GiaTriDen"].ToString()) ? null : (DateTime?)dt.Rows[0]["GiaTriDen"];

                SoTheBHYT = string.IsNullOrEmpty(dt.Rows[0]["SoTheBHYT"].ToString()) ? "" : dt.Rows[0]["SoTheBHYT"].ToString();
                TenCSKCB = string.IsNullOrEmpty(dt.Rows[0]["TenCSKCB"].ToString()) ? "" : dt.Rows[0]["TenCSKCB"].ToString();
                MaCSKCB = string.IsNullOrEmpty(dt.Rows[0]["MaCSKCB"].ToString()) ? "" : dt.Rows[0]["MaCSKCB"].ToString();
                NgayVao = string.IsNullOrEmpty(dt.Rows[0]["NgayVao"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayVao"];
                NgayRa = string.IsNullOrEmpty(dt.Rows[0]["NgayRa"].ToString()) ? null : (DateTime?)dt.Rows[0]["NgayRa"];
                DauHieu = string.IsNullOrEmpty(dt.Rows[0]["DauHieu"].ToString()) ? "" : dt.Rows[0]["DauHieu"].ToString();
                KetQua = string.IsNullOrEmpty(dt.Rows[0]["KetQua"].ToString()) ? "" : dt.Rows[0]["KetQua"].ToString();
                ChanDoan = string.IsNullOrEmpty(dt.Rows[0]["ChanDoan"].ToString()) ? "" : dt.Rows[0]["ChanDoan"].ToString();
                PhuongPhap = string.IsNullOrEmpty(dt.Rows[0]["PhuongPhap"].ToString()) ? "" : dt.Rows[0]["PhuongPhap"].ToString();
                TinhTrang = string.IsNullOrEmpty(dt.Rows[0]["TinhTrang"].ToString()) ? "" : dt.Rows[0]["TinhTrang"].ToString();
                LyDo = string.IsNullOrEmpty(dt.Rows[0]["LyDo"].ToString()) ? null : (int?)Convert.ToInt32(dt.Rows[0]["LyDo"].ToString());
                LyDoStr = string.IsNullOrEmpty(dt.Rows[0]["LyDoStr"].ToString()) ? "" : dt.Rows[0]["LyDoStr"].ToString();
                ChuyenTuyenHoi = string.IsNullOrEmpty(dt.Rows[0]["ChuyenTuyenHoi"].ToString()) ? null : (DateTime?)dt.Rows[0]["ChuyenTuyenHoi"];
                HuongDieuTri = string.IsNullOrEmpty(dt.Rows[0]["HuongDieuTri"].ToString()) ? "" : dt.Rows[0]["HuongDieuTri"].ToString();
                PhuongTienVanChuyen = string.IsNullOrEmpty(dt.Rows[0]["PhuongTienVanChuyen"].ToString()) ? "" : dt.Rows[0]["PhuongTienVanChuyen"].ToString();
                NguoiHoTong = string.IsNullOrEmpty(dt.Rows[0]["NguoiHoTong"].ToString()) ? "" : dt.Rows[0]["NguoiHoTong"].ToString();
                Loai = string.IsNullOrEmpty(dt.Rows[0]["Loai"].ToString()) ? "" : dt.Rows[0]["Loai"].ToString();
                ChanDoanGPBL = string.IsNullOrEmpty(dt.Rows[0]["ChanDoanGPBL"].ToString()) ? "" : dt.Rows[0]["ChanDoanGPBL"].ToString();
                LoiDanThayThuoc = string.IsNullOrEmpty(dt.Rows[0]["LoiDanThayThuoc"].ToString()) ? "" : dt.Rows[0]["LoiDanThayThuoc"].ToString();


            }
        }
       

        public int Insert()
        {

            m_dbConnection.Open();

            string sql = "";
            sql += "INSERT INTO BenhAn (SoLuuTru,MaYTe,HoTen,GioiTinh,NoiChuyenDen,Tuoi,DanToc,DiaChi,QuocTich,NgheNghiep,NoiLamViec,GiaTriTu,GiaTriDen,SoTheBHYT,TenCSKCB,MaCSKCB,NgayVao,NgayRa,DauHieu,KetQua,ChanDoan,PhuongPhap,TinhTrang,LyDo,ChuyenTuyenHoi,HuongDieuTri,PhuongTienVanChuyen,NguoiHoTong,Loai,ChanDoanGPBL,LoiDanThayThuoc,LyDoStr) ";
            sql += "VALUES(@SoLuuTru,@MaYTe,@HoTen,@GioiTinh,@NoiChuyenDen,@Tuoi,@DanToc,@DiaChi,@QuocTich,@NgheNghiep,@NoiLamViec,@GiaTriTu,@GiaTriDen,@SoTheBHYT,@TenCSKCB,@MaCSKCB,@NgayVao,@NgayRa,@DauHieu,@KetQua,@ChanDoan,@PhuongPhap,@TinhTrang,@LyDo,@ChuyenTuyenHoi,@HuongDieuTri,@PhuongTienVanChuyen,@NguoiHoTong,@Loai,@ChanDoanGPBL,@LoiDanThayThuoc,@LyDoStr)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@BenhAn_Id", BenhAn_Id));
            command.Parameters.Add(new SQLiteParameter("@SoLuuTru", SoLuuTru));
            command.Parameters.Add(new SQLiteParameter("@MaYTe", MaYTe));
            command.Parameters.Add(new SQLiteParameter("@HoTen", HoTen));
            command.Parameters.Add(new SQLiteParameter("@GioiTinh", GioiTinh));
            command.Parameters.Add(new SQLiteParameter("@NoiChuyenDen", NoiChuyenDen));
            command.Parameters.Add(new SQLiteParameter("@Tuoi", Tuoi));
            command.Parameters.Add(new SQLiteParameter("@DanToc", DanToc));
            command.Parameters.Add(new SQLiteParameter("@DiaChi", DiaChi));
            command.Parameters.Add(new SQLiteParameter("@QuocTich", QuocTich));
            command.Parameters.Add(new SQLiteParameter("@NgheNghiep", NgheNghiep));
            command.Parameters.Add(new SQLiteParameter("@NoiLamViec", NoiLamViec));
            command.Parameters.Add(new SQLiteParameter("@GiaTriTu", GiaTriTu));
            command.Parameters.Add(new SQLiteParameter("@GiaTriDen", GiaTriDen));
            command.Parameters.Add(new SQLiteParameter("@SoTheBHYT", SoTheBHYT));
            command.Parameters.Add(new SQLiteParameter("@TenCSKCB", TenCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", MaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@NgayVao", NgayVao));
            command.Parameters.Add(new SQLiteParameter("@NgayRa", NgayRa));
            command.Parameters.Add(new SQLiteParameter("@DauHieu", DauHieu));
            command.Parameters.Add(new SQLiteParameter("@KetQua", KetQua));
            command.Parameters.Add(new SQLiteParameter("@ChanDoan", ChanDoan));
            command.Parameters.Add(new SQLiteParameter("@PhuongPhap", PhuongPhap));
            command.Parameters.Add(new SQLiteParameter("@TinhTrang", TinhTrang));
            command.Parameters.Add(new SQLiteParameter("@LyDo", LyDo));
            command.Parameters.Add(new SQLiteParameter("@ChuyenTuyenHoi", ChuyenTuyenHoi));
            command.Parameters.Add(new SQLiteParameter("@HuongDieuTri", HuongDieuTri));
            command.Parameters.Add(new SQLiteParameter("@PhuongTienVanChuyen", PhuongTienVanChuyen));
            command.Parameters.Add(new SQLiteParameter("@NguoiHoTong", NguoiHoTong));
            command.Parameters.Add(new SQLiteParameter("@Loai", Loai));
            command.Parameters.Add(new SQLiteParameter("@ChanDoanGPBL", ChanDoanGPBL));
            command.Parameters.Add(new SQLiteParameter("@LoiDanThayThuoc", LoiDanThayThuoc));
            command.Parameters.Add(new SQLiteParameter("@LyDoStr", LyDoStr));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public int Update()
        {
            m_dbConnection.Open();

            string sql = "";
            sql += "UPDATE BenhAn ";
            sql += "Set SoLuuTru=@SoLuuTru,MaYTe=@MaYTe,HoTen=@HoTen,GioiTinh=@GioiTinh,NoiChuyenDen=@NoiChuyenDen,Tuoi=@Tuoi,DanToc=@DanToc,DiaChi=@DiaChi,QuocTich=@QuocTich,NgheNghiep=@NgheNghiep,NoiLamViec=@NoiLamViec,GiaTriTu=@GiaTriTu,GiaTriDen=@GiaTriDen,SoTheBHYT=@SoTheBHYT,TenCSKCB=@TenCSKCB,MaCSKCB=@MaCSKCB,NgayVao=@NgayVao,NgayRa=@NgayRa,DauHieu=@DauHieu,KetQua=@KetQua,ChanDoan=@ChanDoan,PhuongPhap=@PhuongPhap,TinhTrang=@TinhTrang,LyDo=@LyDo,ChuyenTuyenHoi=@ChuyenTuyenHoi,HuongDieuTri=@HuongDieuTri,PhuongTienVanChuyen=@PhuongTienVanChuyen,NguoiHoTong=@NguoiHoTong,Loai=@Loai,ChanDoanGPBL=@ChanDoanGPBL,LoiDanThayThuoc=@LoiDanThayThuoc,LyDoStr =@LyDoStr ";
            sql += "WHERE BenhAn_Id=@BenhAn_Id";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@BenhAn_Id", BenhAn_Id));
            command.Parameters.Add(new SQLiteParameter("@SoLuuTru", SoLuuTru));
            command.Parameters.Add(new SQLiteParameter("@MaYTe", MaYTe));
            command.Parameters.Add(new SQLiteParameter("@HoTen", HoTen));
            command.Parameters.Add(new SQLiteParameter("@GioiTinh", GioiTinh));
            command.Parameters.Add(new SQLiteParameter("@NoiChuyenDen", NoiChuyenDen));
            command.Parameters.Add(new SQLiteParameter("@Tuoi", Tuoi));
            command.Parameters.Add(new SQLiteParameter("@DanToc", DanToc));
            command.Parameters.Add(new SQLiteParameter("@DiaChi", DiaChi));
            command.Parameters.Add(new SQLiteParameter("@QuocTich", QuocTich));
            command.Parameters.Add(new SQLiteParameter("@NgheNghiep", NgheNghiep));
            command.Parameters.Add(new SQLiteParameter("@NoiLamViec", NoiLamViec));
            command.Parameters.Add(new SQLiteParameter("@GiaTriTu", GiaTriTu));
            command.Parameters.Add(new SQLiteParameter("@GiaTriDen", GiaTriDen));
            command.Parameters.Add(new SQLiteParameter("@SoTheBHYT", SoTheBHYT));
            command.Parameters.Add(new SQLiteParameter("@TenCSKCB", TenCSKCB));
            command.Parameters.Add(new SQLiteParameter("@MaCSKCB", MaCSKCB));
            command.Parameters.Add(new SQLiteParameter("@NgayVao", NgayVao));
            command.Parameters.Add(new SQLiteParameter("@NgayRa", NgayRa));
            command.Parameters.Add(new SQLiteParameter("@DauHieu", DauHieu));
            command.Parameters.Add(new SQLiteParameter("@KetQua", KetQua));
            command.Parameters.Add(new SQLiteParameter("@ChanDoan", ChanDoan));
            command.Parameters.Add(new SQLiteParameter("@PhuongPhap", PhuongPhap));
            command.Parameters.Add(new SQLiteParameter("@TinhTrang", TinhTrang));
            command.Parameters.Add(new SQLiteParameter("@LyDo", LyDo));
            command.Parameters.Add(new SQLiteParameter("@ChuyenTuyenHoi", ChuyenTuyenHoi));
            command.Parameters.Add(new SQLiteParameter("@HuongDieuTri", HuongDieuTri));
            command.Parameters.Add(new SQLiteParameter("@PhuongTienVanChuyen", PhuongTienVanChuyen));
            command.Parameters.Add(new SQLiteParameter("@NguoiHoTong", NguoiHoTong));
            command.Parameters.Add(new SQLiteParameter("@Loai", Loai));
            command.Parameters.Add(new SQLiteParameter("@ChanDoanGPBL", ChanDoanGPBL));
            command.Parameters.Add(new SQLiteParameter("@LoiDanThayThuoc", LoiDanThayThuoc));
            command.Parameters.Add(new SQLiteParameter("@LyDoStr", LyDoStr));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public int Delete(int intBenhAn_Id)
        {
            m_dbConnection.Open();

            string sql = "Delete from BenhAn WHERE BenhAn_Id=@BenhAn_Id";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SQLiteParameter("@BenhAn_Id", intBenhAn_Id));

            int result = command.ExecuteNonQuery();
            m_dbConnection.Close();
            return result;
        }

        public bool CheckTonTaiSoLuuTru(string strSoLuuTru, string strLoai)
        {

            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT SoLuuTru FROM BenhAn WHERE SoLuuTru=@SoLuuTru and Loai=@Loai";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@SoLuuTru", strSoLuuTru));
            command.Parameters.Add(new SQLiteParameter("@Loai", strLoai));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

    }
}
