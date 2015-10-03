using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace coInventory.Mini.EntityClass
{
    public class clsBaoCao
    {
        SQLiteConnection m_dbConnection = new SQLiteConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public DataTable GetBangKeNhom1(int intBangKe_Id)
        {

            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "";
            sql += "Select bk.*, ";

            sql += "bkct.MaChiPhi CT_MaChiPhi";
            sql += ",bkct.MaPhu as CT_MaPhu";
            sql += ",bkct.TenChiPhi as CT_TenChiPhi";
            sql += ",bkct.DonViTinh as CT_DonViTinh";
            sql += ",bkct.SoLuong as CT_SoLuong";
            sql += ",bkct.PhanTramDuocHuong as CT_PhanTramDuocHuong";
            sql += ",bkct.DonGiaBHYT as CT_DonGiaBHYT";
            sql += ",bkct.ThanhTienBHYT as CT_ThanhTienBHYT";
            sql += ",bkct.BHYTThanhToan as CT_BHYTThanhToan";
            sql += ",bkct.NguonKhac as CT_NguonKhac";
            sql += ",bkct.NguoiBenhTra as CT_NguoiBenhTra";
            sql += ",bkct.ChiPhiNgoaiDinhSuat as CT_ChiPhiNgoaiDinhSuat";
            sql += ",bkct.MaNhom1 as CT_MaNhom1";
            sql += ",bkct.MaNhom2 as CT_MaNhom2";
            sql += ",bkct.MaLoaiChiPhi as CT_MaLoaiChiPhi";
            sql += ",bkct.GhiChu as CT_GhiChu";

            //Nhóm
            sql += ", CASE ";

            sql += " WHEN MaNhom1='01' THEN '1. Khám bệnh' ";

            sql += " WHEN MaNhom1='02' THEN '2. Ngày điều trị ngoại trú'";

            sql += " WHEN MaNhom1='03' THEN '3. Xét nghiệm'";

            sql += " WHEN MaNhom1='04' THEN '4. Chẩn đoán hình ảnh'";

            sql += " WHEN MaNhom1='05' THEN '5. Thăm dò chức năng'";

            sql += " WHEN MaNhom1='06' THEN '6. Thủ thuật, phẫu thuật'";

            sql += " WHEN MaNhom1='07' THEN '7. Dịch vụ kỹ cao chi phí lớn'";

            sql += " WHEN MaNhom1='08' THEN '8. Máu và chế phẩm máu'";

            sql += " WHEN MaNhom1='09.1' THEN '9.1. Thuốc trong danh mục BHYT'";

            sql += " WHEN MaNhom1='09.2' THEN '9.2. Thuốc ngoài danh mục BHYT'";

            sql += " WHEN MaNhom1='09.3' THEN '9.3. Thuốc điều trị ung thư, chống thải ghép ngoài danh mục'";

            sql += " WHEN MaNhom1='10.1' THEN '10.1. Vật tư y tế trong danh mục BHYT'";

            sql += " WHEN MaNhom1='10.2' THEN '10.2. Vật tư y tế ngoài danh mục BHYT'";

            sql += " WHEN MaNhom1='11' THEN '11. Vận chuyển'";

            sql += " WHEN MaNhom1='12' THEN '12. Ngày giường chuyên khoa'";

            sql += " ELSE 'Khác' END as Nhom1";
            //End nhom

            //Field order by cho dep
            sql += ", CASE ";

            sql += " WHEN MaNhom1='01' THEN 1 ";

            sql += " WHEN MaNhom1='02' THEN 2";

            sql += " WHEN MaNhom1='03' THEN 3";

            sql += " WHEN MaNhom1='04' THEN 4";

            sql += " WHEN MaNhom1='05' THEN 5";

            sql += " WHEN MaNhom1='06' THEN 6";

            sql += " WHEN MaNhom1='07' THEN 7";

            sql += " WHEN MaNhom1='08' THEN 8";

            sql += " WHEN MaNhom1='09.1' THEN 9";

            sql += " WHEN MaNhom1='09.2' THEN 9.1";

            sql += " WHEN MaNhom1='09.3' THEN 9.3";

            sql += " WHEN MaNhom1='10.1' THEN 10.1";

            sql += " WHEN MaNhom1='10.2' THEN 10.2";

            sql += " WHEN MaNhom1='11' THEN 11";

            sql += " WHEN MaNhom1='12' THEN 12";

            sql += " ELSE 13 END as STT";
            //end

            sql += " From BangKe bk ";

            sql += " join BangKeChiTiet bkct on bk.BangKe_Id = bkct.BangKe_Id ";

            sql += " Where bk.BangKe_Id=@BangKe_Id order by STT";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", intBangKe_Id));

            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public DataTable GetBangKeNhom2(int intBangKe_Id)
        {

            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "";
            sql += "Select *, ";

            sql += " CASE ";

            sql += " WHEN MaNhom1='01' THEN 'Khám bệnh' ";

            sql += " WHEN MaNhom1='02' THEN 'Ngày điều trị ngoại trú'";

            sql += " WHEN MaNhom1='03' THEN 'Xét nghiệm'";

            sql += " WHEN MaNhom1='04' THEN 'Chẩn đoán hình ảnh'";

            sql += " WHEN MaNhom1='05' THEN 'Thăm dò chức năng'";

            sql += " WHEN MaNhom1='06' THEN 'Thủ thuật, phẫu thuật'";

            sql += " WHEN MaNhom1='07' THEN 'Dịch vụ kỹ cao chi phí lớn'";

            sql += " WHEN MaNhom1='08' THEN 'Máu và chế phẩm máu'";

            sql += " WHEN MaNhom1='09.1' THEN 'Thuốc trong danh mục BHYT'";

            sql += " WHEN MaNhom1='09.2' THEN 'Thuốc ngoài danh mục BHYT'";

            sql += " WHEN MaNhom1='09.3' THEN 'Thuốc điều trị ung thư, chống thải ghép ngoài danh mục'";

            sql += " WHEN MaNhom1='10.1' THEN 'Vật tư y tế trong danh mục BHYT'";

            sql += " WHEN MaNhom1='10.2' THEN 'Vật tư y tế ngoài danh mục BHYT'";

            sql += " WHEN MaNhom1='11' THEN 'Vận chuyển'";

            sql += " WHEN MaNhom1='12' THEN 'Ngày giường chuyên khoa'";

            sql += " ELSE ' ' END as Nhom1";

            sql += " From BangKe bk ";

            sql += " join BangKeChiTiet bkct on bk.BangKe_Id = bkct.BangKe_Id ";

            sql += " Where bk.BangKe_Id=@BangKe_Id ";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", intBangKe_Id));

            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public DataTable GetBySoLuuTru(string strSoLuuTru,string strLoai)
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
                return dt;
        }

    }


}
