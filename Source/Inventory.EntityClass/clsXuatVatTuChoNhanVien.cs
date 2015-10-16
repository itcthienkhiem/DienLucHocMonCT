using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Inventory.Utilities;
using Inventory.Models;

namespace Inventory.EntityClass
{
    public class clsXuatVatTuChoNhanVien
    {
        public int? ID_Nhan_vien;
        public int? ID_kho;
        public string Ma_phieu_xuat_tam;
        public DateTime Ngay_xuat;
        public string Ly_do;
        public string Cong_trinh;
        public string Dia_chi;
        public DateTime Ngay_lap;

        SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);

        public clsXuatVatTuChoNhanVien()
        { }


        public DataTable getDSNhanVienNoVatTu()
        {




              DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {

                var entryPoint = (from ep in help.ent.No_vat_tu
                                  join e in help.ent.DM_Nhan_Vien on ep.ID_nhan_vien equals e.ID_nhan_vien
                                  join t in help.ent.Phieu_Xuat_Tam_Vat_Tu on ep.Ma_phieu_xuat_tam equals t.Ma_phieu_xuat_tam
                                  join s in help.ent.DM_Kho on t.ID_kho equals s.ID_kho
                                  join u in help.ent.DM_Vat_Tu on ep.Ma_vat_tu equals u.Ma_vat_tu
                                  where ep.Da_tra == false
                                  select new
                                  {
                                      e.Ma_nhan_vien,
                                      e.Ten_nhan_vien,
                                      ep.Ma_phieu_xuat_tam,
                                      ep.Ma_vat_tu,
                                      u.Ten_vat_tu,
                                      s.Ten_kho,
                                      ep.So_luong_giu_lai,
                                      ep.Da_tra,


                                  }).ToList()
              ;


                dbcxtransaction.Commit();

                return Utilities.clsThamSoUtilities.ToDataTable(entryPoint);
                ///m_dbConnection.Open();
            }
            //DataTable dt = new DataTable();
            //string sql = "";
            //sql += "SELECT ";
            //sql += "DM_Nhan_Vien.Ma_nhan_vien, ";
            //sql += "DM_Nhan_Vien.Ten_nhan_vien, ";
            //sql += "No_vat_tu.Ma_phieu_xuat_tam, ";
            //sql += "No_vat_tu.Ma_vat_tu, ";
            //sql += "DM_Vat_Tu.Ten_vat_tu, ";
            //sql += "DM_Kho.Ten_kho, ";
            //sql += "No_vat_tu.So_luong_giu_lai, ";
            //sql += "No_vat_tu.Da_tra, ";
            //sql += "CASE WHEN No_vat_tu.Da_tra = 'TRUE' THEN N'Đã trả' ELSE N'Chưa trả' END as Da_tra_text ";
            //sql += "FROM No_vat_tu ";
            //sql += "INNER ";
            //sql += "" + "JOIN DM_Nhan_Vien ";
            //sql += "" + "ON No_vat_tu.ID_nhan_vien=DM_Nhan_Vien.ID_nhan_vien ";
            //sql += "INNER ";
            //sql += "" + "JOIN Phieu_Xuat_Tam_Vat_Tu ";
            //sql += "" + "ON No_vat_tu.Ma_phieu_xuat_tam=Phieu_Xuat_Tam_Vat_Tu.Ma_phieu_xuat_tam ";
            //sql += "INNER ";
            //sql += "" + "JOIN DM_Kho ";
            //sql += "" + "ON Phieu_Xuat_Tam_Vat_Tu.ID_kho=DM_Kho.ID_kho ";
            //sql += "INNER ";
            //sql += "" + "JOIN DM_Vat_Tu ";
            //sql += "" + "ON No_vat_tu.Ma_vat_tu=DM_Vat_Tu.Ma_vat_tu ";
            //sql += "WHERE No_vat_tu.Da_tra=@Da_tra";

            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //SqlDataAdapter da = new SqlDataAdapter(command);

            //command.Parameters.Add("@Da_tra", SqlDbType.Bit).Value = false;

            //command.CommandType = CommandType.Text;

            //da.Fill(dt);
            //m_dbConnection.Close();

            //return dt;
        }

        public DataTable getDSNhanVienNoVatTu(string ID_nhan_vien)
        {
                DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {

                var entryPoint = (from ep in help.ent.No_vat_tu
                                  join e in help.ent.DM_Nhan_Vien on ep.ID_nhan_vien equals e.ID_nhan_vien
                                  join t in help.ent.Phieu_Xuat_Tam_Vat_Tu on ep.Ma_phieu_xuat_tam equals t.Ma_phieu_xuat_tam
                                  join s in help.ent.DM_Kho on t.ID_kho equals s.ID_kho
                                  join u in help.ent.DM_Vat_Tu on ep.Ma_vat_tu equals u.Ma_vat_tu
                                  where ep.Da_tra == false && ep.ID_nhan_vien == int.Parse(ID_nhan_vien)
                                  select new
                                  {
                                      e.Ma_nhan_vien,
                                      e.Ten_nhan_vien,
                                      ep.Ma_phieu_xuat_tam,
                                      ep.Ma_vat_tu,
                                      u.Ten_vat_tu,
                                      s.Ten_kho,
                                      ep.So_luong_giu_lai,
                                      ep.Da_tra,


                                  }).ToList()
              ;


                dbcxtransaction.Commit();

                return Utilities.clsThamSoUtilities.ToDataTable(entryPoint);

            }

            //m_dbConnection.Open();

            //DataTable dt = new DataTable();
            //string sql = "";
            //sql += "SELECT ";
            //sql += "DM_Nhan_Vien.Ma_nhan_vien, ";
            //sql += "DM_Nhan_Vien.Ten_nhan_vien, ";
            //sql += "No_vat_tu.Ma_phieu_xuat_tam, ";
            //sql += "No_vat_tu.Ma_vat_tu, ";
            //sql += "DM_Vat_Tu.Ten_vat_tu, ";
            //sql += "DM_Kho.Ten_kho, ";
            //sql += "No_vat_tu.So_luong_giu_lai, ";
            //sql += "No_vat_tu.Da_tra, ";
            //sql += "CASE WHEN No_vat_tu.Da_tra = 'TRUE' THEN N'Đã trả' ELSE N'Chưa trả' END as Da_tra_text ";
            //sql += "FROM No_vat_tu ";
            //sql += "INNER ";
            //sql += "" + "JOIN DM_Nhan_Vien ";
            //sql += "" + "ON No_vat_tu.ID_nhan_vien=DM_Nhan_Vien.ID_nhan_vien ";
            //sql += "INNER ";
            //sql += "" + "JOIN Phieu_Xuat_Tam_Vat_Tu ";
            //sql += "" + "ON No_vat_tu.Ma_phieu_xuat_tam=Phieu_Xuat_Tam_Vat_Tu.Ma_phieu_xuat_tam ";
            //sql += "INNER ";
            //sql += "" + "JOIN DM_Kho ";
            //sql += "" + "ON Phieu_Xuat_Tam_Vat_Tu.ID_kho=DM_Kho.ID_kho ";
            //sql += "INNER ";
            //sql += "" + "JOIN DM_Vat_Tu ";
            //sql += "" + "ON No_vat_tu.Ma_vat_tu=DM_Vat_Tu.Ma_vat_tu ";
            //sql += "WHERE No_vat_tu.Da_tra=@Da_tra ";
            //sql += "AND No_vat_tu.ID_nhan_vien=@ID_nhan_vien";

            //SqlCommand command = new SqlCommand(sql, m_dbConnection);

            //command.Parameters.Add("@Da_tra", SqlDbType.Bit).Value = false;
            //command.Parameters.Add("@ID_nhan_vien", SqlDbType.Int).Value = Int32.Parse(ID_nhan_vien);

            //command.CommandType = CommandType.Text;

            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //m_dbConnection.Close();

            //return dt;
        }
    }
}
