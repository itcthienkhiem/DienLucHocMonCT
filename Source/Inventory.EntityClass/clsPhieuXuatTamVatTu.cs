﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Inventory.Utilities;
using Inventory.Models;
using System.Data.Entity;
//using System.Windows.Forms;

namespace Inventory.EntityClass
{
    public class clsPhieuXuatTamVatTu
    {
        //  public 
        public int ID_Nhan_vien;
        public int ID_kho;
        public string Ma_phieu_xuat_tam;
        public DateTime Ngay_xuat;
        public string Ly_do;
        public string Cong_trinh;
        public string Dia_chi;
        public DateTime Ngay_lap;
        public bool isGiuLai = false;
        public bool isHoanNhap = false;
        public bool Da_duyet = false;
        public int ID_phieu_xuat_tam;
        public clsPhieuXuatTamVatTu()
        {
        }
        SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);

        public bool chkPhieuXuatTam(string sMa_phieu_xuat_tam)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            bool has = help.ent.Phieu_Xuat_Tam_Vat_Tu.Any(cus => cus.Ma_phieu_xuat_tam == sMa_phieu_xuat_tam);
            return has;
        }

        public DataTable GetAll(string maPhieu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Phieu_Xuat_Tam_Vat_Tu
                          join e in help.ent.DM_Nhan_Vien on d.ID_nhan_vien equals e.ID_nhan_vien
                          where d.Ma_phieu_xuat_tam == maPhieu
                          select d).ToList();
                dbcxtransaction.Commit();

                return Utilities.clsThamSoUtilities.ToDataTable(dm);
            }




            //m_dbConnection.Open();
            //DataTable dt = new DataTable();
            //string sql = "SELECT * FROM Phieu_xuat_tam_vat_tu ";
            //sql += "join Dm_nhan_vien on Dm_nhan_vien.ID_Nhan_vien  = Phieu_xuat_tam_vat_tu.ID_nhan_vien";
            //  sql +=" WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam";
            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //command.Parameters.Add(new SqlParameter("@Ma_phieu_xuat_tam", maPhieu));
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //m_dbConnection.Close();
            // return dt;
        }
        public int Insert()
        {
            try
            {
                DatabaseHelper help = new DatabaseHelper();
                help.ConnectDatabase();
                using (var dbcxtransaction = help.ent.Database.BeginTransaction())
                {
                    var item = new Phieu_Xuat_Tam_Vat_Tu();
                    item.ID_kho = this.ID_kho;
                    item.ID_nhan_vien = this.ID_Nhan_vien;
                    item.isGiuLai = this.isGiuLai;
                    item.isHoanNhap = this.isHoanNhap;
                    item.Ly_do = this.Ly_do;
                    item.Cong_trinh = this.Cong_trinh;
                    item.Dia_chi = this.Dia_chi;
                    item.Ngay_xuat = this.Ngay_xuat;
                    item.Ma_phieu_xuat_tam = this.Ma_phieu_xuat_tam;
                    item.Da_duyet = this.Da_duyet;


                    help.ent.Phieu_Xuat_Tam_Vat_Tu.Add(item);
                    help.ent.SaveChanges();
                    dbcxtransaction.Commit();
                    return 1;


                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public int TimMaPhieu(string maphieu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Phieu_Xuat_Tam_Vat_Tu
                          where d.Ma_phieu_xuat_tam == maphieu
                          select d).FirstOrDefault();
                if (dm == null)
                    return -1;
                return dm.ID_phieu_xuat_tam;
            }
        }
        public int Insert(DatabaseHelper help)
        {
            var item = new Phieu_Xuat_Tam_Vat_Tu();
            item.ID_kho = this.ID_kho;
            item.ID_nhan_vien = this.ID_Nhan_vien;
            item.isGiuLai = this.isGiuLai;
            item.isHoanNhap = this.isHoanNhap;
            item.Ly_do = this.Ly_do;
            item.Cong_trinh = this.Cong_trinh;
            item.Dia_chi = this.Dia_chi;
            item.Ngay_xuat = this.Ngay_xuat;
            item.Ma_phieu_xuat_tam = this.Ma_phieu_xuat_tam;
            item.Da_duyet = this.Da_duyet;
            item.ID_phieu_xuat_tam = this.ID_phieu_xuat_tam;
            help.ent.Phieu_Xuat_Tam_Vat_Tu.Add(item);
          
           return  help.ent.SaveChanges();
        }
        public int Update(DatabaseHelper help)
        {
            try
            {
                  {
                    var item = new Phieu_Xuat_Tam_Vat_Tu();
                    item.ID_kho = this.ID_kho;
                    item.ID_nhan_vien = this.ID_Nhan_vien;
                    item.isGiuLai = this.isGiuLai;
                    item.isHoanNhap = this.isHoanNhap;
                    item.Ly_do = this.Ly_do;
                    item.Cong_trinh = this.Cong_trinh;
                    item.Dia_chi = this.Dia_chi;
                    item.Ngay_xuat = this.Ngay_xuat;
                    item.Ma_phieu_xuat_tam = this.Ma_phieu_xuat_tam;
                    item.Da_duyet = this.Da_duyet;
                    item.ID_phieu_xuat_tam = this.ID_phieu_xuat_tam;
                    help.ent.Phieu_Xuat_Tam_Vat_Tu.Attach(item);
                    help.ent.Entry(item).State = EntityState.Modified;
                    help.ent.SaveChanges();
                    var ctpxt = new Chi_Tiet_Phieu_Xuat_Tam();
                    var dm = (from d in help.ent.Chi_Tiet_Phieu_Xuat_Tam
                              where d.Ma_phieu_xuat_tam == item.Ma_phieu_xuat_tam
                              select d
                                  ).ToList();
                    if (dm == null)
                    {
                       
                        return 1;
                    }
                    for (int i = 0; i < dm.Count; i++)
                    {
                        help.ent.Chi_Tiet_Phieu_Xuat_Tam.Attach(dm[i]);
                        help.ent.Chi_Tiet_Phieu_Xuat_Tam.Remove(dm[i]);
                        help.ent.SaveChanges();
                    }


                  
                    return 1;


                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public DataTable GetAll_byMaPhieu(string maPhieu)
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();

            string sql = "SELECT * FROM Phieu_Xuat_Tam_Vat_Tu ";
            sql += "join DM_Nhan_Vien on DM_Nhan_Vien.ID_nhan_vien=Phieu_Xuat_Tam_Vat_Tu.ID_nhan_vien ";
            sql += "WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam";
            SqlCommand command = new SqlCommand(sql, m_dbConnection);
            command.Parameters.Add(new SqlParameter("@Ma_phieu_xuat_tam", maPhieu));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();
            return dt;
        }

        public int GetMaxID()
        {
            m_dbConnection.Open();
            DataTable dt = new DataTable();

            string sql = "SELECT MAX(ID_phieu_xuat_tam) as maxid FROM Phieu_Xuat_Tam_Vat_Tu ";

            SqlCommand command = new SqlCommand(sql, m_dbConnection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            if (dt.Rows.Count == 0 || dt.Rows[0]["maxid"].ToString().Equals(string.Empty))
            {
                return 0;
            }

            return Int32.Parse(dt.Rows[0]["maxid"].ToString());
        }

        public int CapNhapPhieuXuat(SqlTransaction m_trans, SqlConnection m_conn)
        {
            if (m_conn.State == ConnectionState.Closed)
                m_conn.Open();

            if (chkPhieuXuatTam(Ma_phieu_xuat_tam) == true)
            {
                //update
                return Update_PhieuXuat(m_trans, m_conn);
            }
            else
            {
                //Insert
                return Insert_PhieuXuat(m_trans, m_conn);
            }
        }

        public int Insert_PhieuXuat(SqlTransaction m_trans, SqlConnection m_conn)
        {
            //SqlTransaction m_trans = null;

            //m_dbConnection.Open();
            //m_trans = m_dbConnection.BeginTransaction();

            if (m_conn.State == ConnectionState.Closed)
                m_conn.Open();

            string sql = "";
            sql += "INSERT INTO Phieu_xuat_tam_vat_tu (Ma_phieu_xuat_tam,ID_kho,ID_nhan_vien,Ngay_xuat,Ly_do,Cong_trinh,Dia_chi,Da_duyet) ";
            sql += "VALUES(@Ma_phieu_xuat_tam,@ID_kho,@ID_nhan_vien,@Ngay_xuat,@Ly_do,@Cong_trinh,@Dia_chi,@Da_duyet)";

            SqlCommand command = new SqlCommand(sql, m_conn, m_trans);
            command.CommandType = CommandType.Text;

            command.Parameters.Add("@Ma_phieu_xuat_tam", SqlDbType.VarChar, 50).Value = Ma_phieu_xuat_tam;
            command.Parameters.Add("@ID_kho", SqlDbType.Int).Value = ID_kho;
            command.Parameters.Add("@ID_nhan_vien", SqlDbType.Int).Value = ID_Nhan_vien;
            command.Parameters.Add("@Ngay_xuat", SqlDbType.DateTime, 50).Value = Ngay_xuat.ToString("yyyy-MM-dd");
            command.Parameters.Add("@Ly_do", SqlDbType.NVarChar, 50).Value = Ly_do;
            command.Parameters.Add("@Cong_trinh", SqlDbType.NVarChar, 50).Value = Cong_trinh;
            command.Parameters.Add("@Dia_chi", SqlDbType.NVarChar, 50).Value = Dia_chi;
            command.Parameters.Add("@Da_duyet", SqlDbType.Bit).Value = Da_duyet;

            int result = command.ExecuteNonQuery();

            //m_trans.Commit();
            //m_dbConnection.Close();

            return result;
        }

        public int Update_PhieuXuat(SqlTransaction m_trans, SqlConnection m_conn)
        {
            //SqlTransaction m_trans = null;

            //m_dbConnection.Open();
            //m_trans = m_dbConnection.BeginTransaction();

            if (m_conn.State == ConnectionState.Closed)
                m_conn.Open();

            string sql = "";
            sql += "UPDATE Phieu_xuat_tam_vat_tu ";
            sql += "Set ID_kho=@ID_kho,ID_nhan_vien=@ID_nhan_vien,Ngay_xuat=@Ngay_xuat,Ly_do=@Ly_do,Cong_trinh=@Cong_trinh,Dia_chi=@Dia_chi,Da_duyet=@Da_duyet ";
            sql += "WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam";

            //string sql = "";
            //sql += "INSERT INTO Phieu_xuat_tam_vat_tu (Ma_phieu_xuat_tam,ID_kho,ID_nhan_vien,Ngay_xuat,Ly_do,Cong_trinh,Dia_chi,Da_duyet) ";
            //sql += "VALUES(@Ma_phieu_xuat_tam,@ID_kho,@ID_nhan_vien,@Ngay_xuat,@Ly_do,@Cong_trinh,@Dia_chi,@Da_duyet)";

            SqlCommand command = new SqlCommand(sql, m_conn, m_trans);
            command.CommandType = CommandType.Text;

            command.Parameters.Add("@Ma_phieu_xuat_tam", SqlDbType.VarChar, 50).Value = Ma_phieu_xuat_tam;
            command.Parameters.Add("@ID_kho", SqlDbType.Int).Value = ID_kho;
            command.Parameters.Add("@ID_nhan_vien", SqlDbType.Int).Value = ID_Nhan_vien;
            command.Parameters.Add("@Ngay_xuat", SqlDbType.DateTime, 50).Value = Ngay_xuat.ToString("yyyy-MM-dd");
            command.Parameters.Add("@Ly_do", SqlDbType.NVarChar, 50).Value = Ly_do;
            command.Parameters.Add("@Cong_trinh", SqlDbType.NVarChar, 50).Value = Cong_trinh;
            command.Parameters.Add("@Dia_chi", SqlDbType.NVarChar, 50).Value = Dia_chi;
            command.Parameters.Add("@Da_duyet", SqlDbType.Bit).Value = Da_duyet;

            int result = command.ExecuteNonQuery();

            //m_trans.Commit();
            //m_dbConnection.Close();

            return result;
        }

        public DataTable GetAll()
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Phieu_Xuat_Tam_Vat_Tu

                          select d).ToList();
                dbcxtransaction.Commit();

                return Utilities.clsThamSoUtilities.ToDataTable(dm);
            }



            //m_dbConnection.Open();
            //DataTable dt = new DataTable();
            //string sql = "SELECT * FROM Phieu_xuat_tam_vat_tu ";

            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //m_dbConnection.Close();
            //return dt;
        }

        public DataTable GetAll_DSPhieuXuat(string MaNV, string TenNV)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Phieu_Xuat_Tam_Vat_Tu
                          join e in help.ent.DM_Nhan_Vien on d.ID_nhan_vien equals e.ID_nhan_vien
                          join k in help.ent.DM_Kho on d.ID_kho equals k.ID_kho
                          where e.Ma_nhan_vien.Contains(MaNV) && e.Ten_nhan_vien.Contains(TenNV)
                          select new
                          {
                              d.Ma_phieu_xuat_tam,
                              e.Ten_nhan_vien,
                              k.Ten_kho,
                              d.Ngay_xuat,
                              d.Ly_do,
                              d.Cong_trinh,
                              d.Dia_chi,
                              d.Da_duyet,
                              d.ID_phieu_xuat_tam,
                              d.isHoanNhap ,
                          }).ToList();
                dbcxtransaction.Commit();

                return Utilities.clsThamSoUtilities.ToDataTable(dm);
            }






            ////m_dbConnection.Open();

            ////DataTable dt = new DataTable();
            //////string sql = "SELECT * FROM DM_Vat_Tu";
            ////string sql = "";
            ////sql += "SELECT ";
            ////sql += "Phieu_Xuat_Tam_Vat_Tu.Ma_phieu_xuat_tam, ";
            ////sql += "DM_Nhan_Vien.Ten_nhan_vien, ";
            ////sql += "DM_Kho.Ten_kho, ";
            ////sql += "Phieu_Xuat_Tam_Vat_Tu.Ngay_xuat, ";
            ////sql += "Phieu_Xuat_Tam_Vat_Tu.Ly_do, ";
            ////sql += "Phieu_Xuat_Tam_Vat_Tu.Cong_trinh, ";
            ////sql += "Phieu_Xuat_Tam_Vat_Tu.Dia_chi ";
            ////sql += "FROM Phieu_Xuat_Tam_Vat_Tu ";
            ////sql += "INNER ";
            ////sql += "JOIN DM_Kho ";
            ////sql += "ON Phieu_Xuat_Tam_Vat_Tu.ID_kho=DM_Kho.ID_kho ";
            ////sql += "INNER ";
            ////sql += "JOIN DM_Nhan_Vien ";
            ////sql += "ON Phieu_Xuat_Tam_Vat_Tu.ID_nhan_vien=DM_Nhan_Vien.ID_nhan_vien";

            ////SqlCommand command = new SqlCommand(sql, m_dbConnection);
            ////SqlDataAdapter da = new SqlDataAdapter(command);
            ////da.Fill(dt);
            ////m_dbConnection.Close();

            //return dt;
        }

        public DataTable GetAll_NV_no_VT(int ID_NV)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from nvt in help.ent.No_vat_tu
                          //join pxt in help.ent.Phieu_Xuat_Tam_Vat_Tu on nvt.ID_nhan_vien equals pxt.ID_nhan_vien
                          join vt in help.ent.DM_Vat_Tu on nvt.Ma_vat_tu equals vt.Ma_vat_tu
                          join cl in help.ent.Chat_luong on nvt.Id_chat_luong equals cl.Id_chat_luong
                          //join kho in help.ent.DM_Kho on pxt.ID_kho equals kho.ID_kho
                          join dvt in help.ent.DM_Don_vi_tinh on vt.ID_Don_vi_tinh equals dvt.ID_Don_vi_tinh
                          where nvt.ID_nhan_vien == ID_NV && nvt.Da_tra == false
                          select new
                          {
                              nvt.ID_No_vat_tu,
                              nvt.Ma_vat_tu,
                              vt.Ten_vat_tu,
                              nvt.Id_chat_luong,
                              cl.Loai_chat_luong,
                              //pxt.ID_kho,
                              //kho.Ten_kho,
                              nvt.So_luong_giu_lai,
                              dvt.Ten_don_vi_tinh
                          }).ToList();
                dbcxtransaction.Commit();

                return Utilities.clsThamSoUtilities.ToDataTable(dm);
            }
        }

        public DataTable Get_NV_no_VT_IDKho(int ID_NV)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from nvt in help.ent.No_vat_tu
                          join pxt in help.ent.Phieu_Xuat_Tam_Vat_Tu on nvt.ID_nhan_vien equals pxt.ID_nhan_vien
                          join kho in help.ent.DM_Kho on pxt.ID_kho equals kho.ID_kho
                          where nvt.ID_nhan_vien == ID_NV && nvt.Da_tra == false
                          select new
                          {
                              pxt.ID_kho,
                              kho.Ten_kho

                          }).ToList();
                dbcxtransaction.Commit();

                return Utilities.clsThamSoUtilities.ToDataTable(dm);
            }
        }

        public DataTable GetAll_NV_no_VT_v2(int ID_NV)
        {
            m_dbConnection.Open();

            DataTable dt = new DataTable();
            string sql = "";
            sql += "SELECT ";
            sql += "No_vat_tu.ID_No_vat_tu, ";
            sql += "No_vat_tu.Ma_vat_tu, ";
            //sql += "DM_Kho.Ten_kho, ";
            //sql += "Phieu_Xuat_Tam_Vat_Tu.Ngay_xuat, ";
            //sql += "Phieu_Xuat_Tam_Vat_Tu.Ly_do, ";
            //sql += "Phieu_Xuat_Tam_Vat_Tu.Cong_trinh, ";
            //sql += "Phieu_Xuat_Tam_Vat_Tu.Dia_chi ";
            sql += "FROM No_vat_tu ";
            sql += "INNER ";
            sql += "JOIN DM_Vat_Tu ";
            sql += "ON No_vat_tu.Ma_vat_tu=DM_Vat_Tu.Ma_vat_tu ";
            sql += "INNER ";
            sql += "JOIN Phieu_Xuat_Tam_Vat_Tu ";
            sql += "ON Phieu_Xuat_Tam_Vat_Tu.ID_nhan_vien=No_vat_tu.ID_nhan_vien ";
            sql += "INNER ";
            sql += "JOIN Chat_luong ";
            sql += "ON Chat_luong.Id_chat_luong=No_vat_tu.Id_chat_luong ";
            sql += "INNER ";
            sql += "JOIN DM_Don_vi_tinh ";
            sql += "ON DM_Don_vi_tinh.ID_Don_vi_tinh=DM_Vat_Tu.ID_Don_vi_tinh ";
            sql += "INNER ";
            sql += "JOIN DM_Kho ";
            sql += "ON DM_Kho.ID_kho=Phieu_Xuat_Tam_Vat_Tu.ID_kho ";
            sql += "WHERE No_vat_tu.ID_nhan_vien=@ID_nhan_vien AND No_vat_tu.Da_tra = 'False'";

            SqlCommand command = new SqlCommand(sql, m_dbConnection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            return dt;
        }


        public bool CheckTonTaiSoDK()
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            bool has = help.ent.Phieu_Xuat_Tam_Vat_Tu.Any(cus => cus.Ma_phieu_xuat_tam == Ma_phieu_xuat_tam);
            return has;

            //m_dbConnection.Open();
            //DataTable dt = new DataTable();
            //string sql = "SELECT * FROM Phieu_xuat_tam_vat_tu WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam";
            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //command.Parameters.Add(new SqlParameter("@Ma_phieu_xuat_tam", Ma_phieu_xuat_tam));
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //m_dbConnection.Close();

            //if (dt.Rows.Count > 0)
            //{
            //    return true;
            //}
            //return false;
        }
        public bool CheckTonTaiSoDK(DatabaseHelper help ,string maPhieu)
        {
           
            bool has = help.ent.Phieu_Xuat_Tam_Vat_Tu.Any(cus => cus.Ma_phieu_xuat_tam == maPhieu);
            return has;

            //m_dbConnection.Open();
            //DataTable dt = new DataTable();
            //string sql = "SELECT * FROM Phieu_xuat_tam_vat_tu WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam";
            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //command.Parameters.Add(new SqlParameter("@Ma_phieu_xuat_tam", Ma_phieu_xuat_tam));
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //m_dbConnection.Close();

            //if (dt.Rows.Count > 0)
            //{
            //    return true;
            //}
            //return false;
        }
        public bool CheckTonTaiSoDK(string maPhieu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            bool has = help.ent.Phieu_Xuat_Tam_Vat_Tu.Any(cus => cus.Ma_phieu_xuat_tam == maPhieu);
            return has;

            //m_dbConnection.Open();
            //DataTable dt = new DataTable();
            //string sql = "SELECT * FROM Phieu_xuat_tam_vat_tu WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam";
            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //command.Parameters.Add(new SqlParameter("@Ma_phieu_xuat_tam", Ma_phieu_xuat_tam));
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //m_dbConnection.Close();

            //if (dt.Rows.Count > 0)
            //{
            //    return true;
            //}
            //return false;
        }

        public bool chkNV_no_VT(int ID_NV)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            bool has = help.ent.No_vat_tu.Any(cus => cus.ID_nhan_vien == ID_NV && cus.Da_tra == false);
            return has;

            //m_dbConnection.Open();
            //DataTable dt = new DataTable();
            //string sql = "SELECT * FROM Phieu_xuat_tam_vat_tu WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam";
            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //command.Parameters.Add(new SqlParameter("@Ma_phieu_xuat_tam", Ma_phieu_xuat_tam));
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //m_dbConnection.Close();

            //if (dt.Rows.Count > 0)
            //{
            //    return true;
            //}
            //return false;
        }

        public int Insert(SQLDAL dal)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            // insert
            try
            {
                using (var dbcxtransaction = help.ent.Database.BeginTransaction())
                {

                    var t = new Phieu_Xuat_Tam_Vat_Tu //Make sure you have a table called test in DB
                    {
                        Ma_phieu_xuat_tam = this.Ma_phieu_xuat_tam,
                        ID_kho = this.ID_kho,                   // ID = Guid.NewGuid(),
                        ID_nhan_vien = this.ID_Nhan_vien,
                        Ngay_xuat = this.Ngay_xuat,
                        Ly_do = this.Ly_do,
                        Cong_trinh = this.Cong_trinh,
                        Dia_chi = this.Dia_chi,
                    };

                    help.ent.Phieu_Xuat_Tam_Vat_Tu.Add(t);
                    help.ent.SaveChanges();
                    dbcxtransaction.Commit();
                    return 1;
                }
            }
            catch (Exception ex)
            {

                return 0;

            }

            // dal.BeginTransaction();

            // m_dbConnection = dal.m_conn;
            // if(m_dbConnection.State == ConnectionState.Closed)
            //     m_dbConnection.Open();

            // string sql = "";
            // sql += "INSERT INTO Phieu_xuat_tam_vat_tu (ma_phieu_xuat_tam,ID_kho,ID_nhan_vien,ngay_xuat,Ly_do,Cong_trinh,Dia_chi) ";
            // sql += "VALUES(@ma_phieu_xuat_tam,@ID_kho,@ID_nhan_vien,@ngay_xuat,@Ly_do,@Cong_trinh,@Dia_chi)";

            // SqlCommand command = new SqlCommand(sql, m_dbConnection,dal.m_trans);
            // command.CommandType = CommandType.Text;

            // //command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
            // command.Parameters.Add(new SqlParameter("@Ma_phieu_xuat_tam", Ma_phieu_xuat_tam));
            // command.Parameters.Add(new SqlParameter("@ID_kho", ID_kho));

            // command.Parameters.Add(new SqlParameter("@ngay_xuat", Ngay_xuat.ToString("yyyy-MM-dd")));
            // command.Parameters.Add(new SqlParameter("@ID_nhan_vien", ID_Nhan_vien));

            // command.Parameters.Add(new SqlParameter("@Ly_do", Ly_do));

            // command.Parameters.Add(new SqlParameter("@Cong_trinh", Cong_trinh));

            // command.Parameters.Add(new SqlParameter("@Dia_chi", Dia_chi));

            //// command.Parameters.Add(new SqlParameter("@Ly_do", Ly_do));

            // //command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));

            // int result = command.ExecuteNonQuery();
            // dal.CommitTransaction();

            // return result;
        }

        public int Update(Phieu_Xuat_Tam_Vat_Tu pxt)
        {


            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            int temp = 0;
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                using (var context = help.ent)
                {
                    context.Phieu_Xuat_Tam_Vat_Tu.Attach(pxt);
                    context.Entry(pxt).State = EntityState.Modified;
                    temp = help.ent.SaveChanges();
                    dbcxtransaction.Commit();

                }


            }
            return temp;

            //  DAL.BeginTransaction();

            //  m_dbConnection = DAL.m_conn;
            //  if (m_dbConnection.State == ConnectionState.Closed)
            //  m_dbConnection.Open();

            //  string sql = "";
            //  sql += "UPDATE Phieu_xuat_tam_vat_tu ";
            //  sql += "Set ma_phieu_xuat_tam=@ma_phieu_xuat_tam,ID_kho=@ID_kho,ID_nhan_vien=@ID_nhan_vien,ngay_xuat=@ngay_xuat,Ly_do = @Ly_do ";
            //  sql += "WHERE ma_phieu_xuat_tam=@ma_phieu_xuat_tam";


            //  SqlCommand command = new SqlCommand(sql, m_dbConnection,DAL.m_trans);
            //  command.CommandType = CommandType.Text;

            //  command.Parameters.Add(new SqlParameter("@ma_phieu_xuat_tam", Ma_phieu_xuat_tam));
            //  command.Parameters.Add(new SqlParameter("@ID_kho", ID_kho));
            //  command.Parameters.Add(new SqlParameter("@ngay_xuat", Ngay_xuat.ToString("yyyy-MM-dd")));
            //  command.Parameters.Add(new SqlParameter("@ID_nhan_vien", ID_Nhan_vien));
            ////  command.Parameters.Add(new SqlParameter("@so_hoa_don", So_hoa_don));
            //  command.Parameters.Add(new SqlParameter("@Ly_do", Ly_do));

            //  int result = command.ExecuteNonQuery();
            //  DAL.CommitTransaction();
            //  return result;
        }
        public int Delete(Phieu_Xuat_Tam_Vat_Tu pxt)
        {


            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            help.ent.Phieu_Xuat_Tam_Vat_Tu.Attach(pxt);
            help.ent.Phieu_Xuat_Tam_Vat_Tu.Remove(pxt);
            return help.ent.SaveChanges();

            //DAL.BeginTransaction();

            //m_dbConnection = DAL.m_conn;
            //if (m_dbConnection.State == ConnectionState.Closed)
            //m_dbConnection.Open();
            //string sql = "Delete from Phieu_xuat_tam_vat_tu WHERE ma_phieu_xuat_tam=@ma_phieu_xuat_tam";


            //SqlCommand command = new SqlCommand(sql, m_dbConnection, DAL.m_trans);
            //command.CommandType = CommandType.Text;

            //command.Parameters.Add(new SqlParameter("@ma_phieu_xuat_tam", Ma_phieu_xuat_tam));

            //int result = command.ExecuteNonQuery();
            //DAL.CommitTransaction();
            //return result;
        }
        public int Delete(string maphieu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            //   help.ent.Database.BeginTransaction();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var recordsToDeleteCT = (from c in help.ent.Chi_Tiet_Phieu_Xuat_Tam where c.Ma_phieu_xuat_tam == maphieu select c).ToList<Chi_Tiet_Phieu_Xuat_Tam>();
                if (recordsToDeleteCT.Count > 0)
                {
                    foreach (var record in recordsToDeleteCT)
                    {
                        help.ent.Chi_Tiet_Phieu_Xuat_Tam.Attach(record);
                        help.ent.Chi_Tiet_Phieu_Xuat_Tam.Remove(record);
                    }
                }
                help.ent.SaveChanges();
                var recordsToDelete = (from c in help.ent.Phieu_Xuat_Tam_Vat_Tu where c.Ma_phieu_xuat_tam == maphieu select c).ToList<Phieu_Xuat_Tam_Vat_Tu>();
                if (recordsToDelete.Count > 0)
                {
                    foreach (var record in recordsToDelete)
                    {
                        help.ent.Phieu_Xuat_Tam_Vat_Tu.Attach(record);
                        help.ent.Phieu_Xuat_Tam_Vat_Tu.Remove(record);
                    }
                }
                help.ent.SaveChanges();
                dbcxtransaction.Commit();
                return 1;
            }
            return 0;
        }
        public int Delete(DatabaseHelper help, string maphieu)
        {

            {
                var recordsToDeleteCT = (from c in help.ent.Chi_Tiet_Phieu_Xuat_Tam where c.Ma_phieu_xuat_tam == maphieu select c).ToList<Chi_Tiet_Phieu_Xuat_Tam>();
                if (recordsToDeleteCT.Count > 0)
                {
                    foreach (var record in recordsToDeleteCT)
                    {
                        help.ent.Chi_Tiet_Phieu_Xuat_Tam.Attach(record);
                        help.ent.Chi_Tiet_Phieu_Xuat_Tam.Remove(record);
                    }
                }
                help.ent.SaveChanges();
                var recordsToDelete = (from c in help.ent.Phieu_Xuat_Tam_Vat_Tu where c.Ma_phieu_xuat_tam == maphieu select c).ToList<Phieu_Xuat_Tam_Vat_Tu>();
                if (recordsToDelete.Count > 0)
                {
                    foreach (var record in recordsToDelete)
                    {
                        help.ent.Phieu_Xuat_Tam_Vat_Tu.Attach(record);
                        help.ent.Phieu_Xuat_Tam_Vat_Tu.Remove(record);
                    }
                }
                help.ent.SaveChanges();

                return 1;
            }
            return 0;
        }
        public static string RandomMaPhieu()
        {
            DateTime today = DateTime.Today;
            string year = today.ToString("yy");
            string month = today.ToString("MM");
            string day = today.ToString("dd");
            //kiểm tra xem ngày hiện tại có mã số nào chưa ?\
            //nếu có thì dd.mm.yy.xx+1 vào
            //nếu chưa có thì tạo dd.mm.yy.00

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            var showPiece = (help.ent.Chi_Tiet_Phieu_Xuat_Tam
               .FirstOrDefault(p => p.Ma_phieu_xuat_tam == help.ent.Chi_Tiet_Phieu_Xuat_Tam.Max(x => x.Ma_phieu_xuat_tam)));
            if (showPiece != null && showPiece.Ma_phieu_xuat_tam.Contains(day + "." + month + "." + year))
            {
                string[] temp = showPiece.Ma_phieu_xuat_tam.Split('.');
                int value = int.Parse(temp[temp.Length]) + 1;
                return day + month + year + showPiece;
            }
            else
            {
                //   showPiece.Ma_phieu_xuat_tam.Split
                return (string)(day + "." + month + "." + year + "." + "0000");
            }
        }
    }
}

