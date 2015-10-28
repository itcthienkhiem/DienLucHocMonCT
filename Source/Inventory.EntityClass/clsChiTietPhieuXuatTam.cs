﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Inventory.Utilities;
using Inventory.Models;
using System.ComponentModel;
using System.Data.Entity;

namespace Inventory.EntityClass
{
    public class clsChiTietPhieuXuatTam: ObjecEntity
    {
        public string Ma_phieu_xuat_tam;

        public string Ma_vat_tu;
        public int So_luong_de_nghi;
        public int So_luong_hoan_nhap;
        public int So_luong_giu_lai;
        public int so_luong_thuc_lanh;
        public int Id_chat_luong;

        SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);


        public override System.Windows.Forms.AutoCompleteStringCollection getListToCombobox(string TenCot)
        {
            System.Windows.Forms.AutoCompleteStringCollection dataCollection = new System.Windows.Forms.AutoCompleteStringCollection();


            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Chi_Tiet_Phieu_Xuat_Tam
                          select d).ToList();
                dbcxtransaction.Commit();

                DataTable ds = Utilities.clsThamSoUtilities.ToDataTable(dm);

                foreach (DataRow row in ds.Rows)
                {
                    dataCollection.Add(row[TenCot].ToString());
                }
            }
            return dataCollection;
        }
        public override DataTable GetAllData()
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Chi_Tiet_Phieu_Xuat_Tam
                          select d).ToList();
                dbcxtransaction.Commit();

                return Utilities.clsThamSoUtilities.ToDataTable(dm);
            }
        }
        public bool isHasDuplicateRow(string Ma_phieu_xuat_tam)
        {


            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            bool has = help.ent.Chi_Tiet_Phieu_Xuat_Tam.Any(cus => cus.Ma_phieu_xuat_tam == Ma_phieu_xuat_tam);
            
            return has;
            //Mở
            ////m_dbConnection.Open();

            //////Chuẩn bị
            ////string sql = "";
            ////sql += "SELECT Ma_phieu_xuat_tam FROM Chi_Tiet_Phieu_xuat_tam ";
            ////sql += "WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam";

            ////SqlCommand command = new SqlCommand(sql, m_dbConnection);

            ////command.Parameters.Add("@Ma_phieu_xuat_tam", SqlDbType.VarChar, 50).Value = Ma_phieu_xuat_tam;

            ////command.CommandType = CommandType.Text;

            //////Run

            //////Lấy 1 cell về check
            ////var firstColumn = command.ExecuteScalar();

            //////Đóng
            ////m_dbConnection.Close();

            ////Nếu có dữ liệu, thì trùng
            //if (firstColumn != null)
            //{
            //    return true;
            //}
            //return false;
        }

        public System.Windows.Forms.AutoCompleteStringCollection getListMaPhieuXuatTam()
        {
            // m_dbConnection.Open();

            DataSet ds = new DataSet();
            System.Windows.Forms.AutoCompleteStringCollection dataCollection = new System.Windows.Forms.AutoCompleteStringCollection();

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Phieu_Xuat_Tam_Vat_Tu
                          select new
                          {
                              d.Ma_phieu_xuat_tam,

                          }).ToList();
                dbcxtransaction.Commit();

                DataTable dt = Utilities.clsThamSoUtilities.ToDataTable(dm);


                //string sql = "";
                //sql += "SELECT ";
                //sql += "Ma_phieu_xuat_tam ";
                //sql += "FROM Phieu_Xuat_Tam_Vat_Tu ";

                //SqlCommand command = new SqlCommand(sql, m_dbConnection);
                //SqlDataAdapter da = new SqlDataAdapter(command);
                //da.Fill(ds);
                //m_dbConnection.Close();

                foreach (DataRow row in dt.Rows)
                {
                    dataCollection.Add(row[0].ToString());
                }
            }
            return dataCollection;
        }

        public DataTable getAll_Ma_Phieu()
        {
            DataSet ds = new DataSet();
            System.Windows.Forms.AutoCompleteStringCollection dataCollection = new System.Windows.Forms.AutoCompleteStringCollection();

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Phieu_Xuat_Tam_Vat_Tu
                          select new
                          {
                              d.ID_phieu_xuat_tam,
                              d.Ma_phieu_xuat_tam,

                          }).ToList();
                dbcxtransaction.Commit();

                DataTable dt = Utilities.clsThamSoUtilities.ToDataTable(dm);

                //m_dbConnection.Open();

                //DataTable dt = new DataTable();

                //string sql = "";
                //sql += "SELECT ";
                //sql += "ID_phieu_xuat_tam, Ma_phieu_xuat_tam ";
                //sql += "FROM Phieu_Xuat_Tam_Vat_Tu";

                //SqlCommand command = new SqlCommand(sql, m_dbConnection);
                //SqlDataAdapter da = new SqlDataAdapter(command);
                //da.Fill(dt);
                //m_dbConnection.Close();

                return dt;
            }
        }

        public DataTable getAll_toGrid(string maPhieu)
        {
            if (m_dbConnection.State == ConnectionState.Closed)
                m_dbConnection.Open();

            DataTable dt = new DataTable();

            string sql = "SELECT Chi_tiet_Phieu_Xuat_Tam.Ma_vat_tu,DM_Vat_Tu.Ten_vat_tu,Chi_tiet_Phieu_Xuat_Tam.ID_kho,DM_Kho.Ten_kho,Chi_tiet_Phieu_Xuat_Tam.So_luong_de_nghi,Chi_tiet_Phieu_Xuat_Tam.So_luong_thuc_xuat,Chi_tiet_Phieu_Xuat_Tam.Da_duyet_xuat_vat_tu,Chi_tiet_Phieu_Xuat_Tam.So_luong_hoan_nhap,Chi_tiet_Phieu_Xuat_Tam.So_luong_giu_lai,Chi_tiet_Phieu_Xuat_Tam.Da_duyet_hoan_nhap_giu_lai,DM_Don_vi_tinh.Ten_don_vi_tinh,Chi_tiet_Phieu_Xuat_Tam.Id_chat_luong,Chat_luong.Loai_chat_luong FROM Chi_tiet_Phieu_Xuat_Tam ";
            sql += "join DM_Vat_Tu on DM_Vat_Tu.Ma_vat_tu =Chi_tiet_Phieu_Xuat_Tam.Ma_vat_tu ";
            sql += "join DM_Don_vi_tinh on DM_vat_tu.ID_Don_vi_tinh=DM_Don_vi_tinh.ID_Don_vi_tinh ";
            sql += "join DM_Kho on Chi_tiet_Phieu_Xuat_Tam.ID_kho=DM_Kho.ID_kho ";
            sql += "join Chat_luong on Chi_tiet_Phieu_Xuat_Tam.Id_chat_luong=Chat_luong.Id_chat_luong ";
            sql += "WHERE Chi_tiet_Phieu_Xuat_Tam.Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam ";

            SqlCommand command = new SqlCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add("@Ma_phieu_xuat_tam", SqlDbType.VarChar, 50).Value = maPhieu;
            SqlDataAdapter da = new SqlDataAdapter(command);

            da.Fill(dt);

            m_dbConnection.Close();
            return dt;
        }


        public DataTable GetAll(string maPhieu)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var entryPoint = (from ep in help.ent.Chi_Tiet_Phieu_Xuat_Tam
                                  join e in help.ent.Phieu_Xuat_Tam_Vat_Tu on ep.Ma_phieu_xuat_tam equals e.Ma_phieu_xuat_tam
                                  join t in help.ent.DM_Vat_Tu on ep.Ma_vat_tu equals t.Ma_vat_tu
                                  join s in help.ent.DM_Don_vi_tinh on t.ID_Don_vi_tinh equals s.ID_Don_vi_tinh

                                  where ep.Ma_phieu_xuat_tam == maPhieu
                                  select ep).ToList()
              ;

            
                dbcxtransaction.Commit();

                return Utilities.clsThamSoUtilities.ToDataTable(entryPoint);
            }
        }
        //m_dbConnection.Open();
        //DataTable dt = new DataTable();
        //string sql = "SELECT * FROM Chi_tiet_Phieu_Xuat_Tam ";
        //sql += "join Phieu_xuat_tam_vat_tu on Phieu_xuat_tam_vat_tu.ma_phieu_xuat_tam =Chi_tiet_Phieu_Xuat_Tam.ma_phieu_xuat_tam  ";
        //sql += "join DM_vat_tu on DM_vat_tu.ma_vat_tu =Chi_tiet_Phieu_Xuat_Tam.ma_vat_tu ";
        //sql += "join DM_Don_vi_tinh on DM_vat_tu.ID_don_vi_tinh =DM_Don_vi_tinh.ID_don_vi_tinh ";

        //sql += " WHERE Chi_tiet_Phieu_Xuat_Tam.Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam ";

        //SqlCommand command = new SqlCommand(sql, m_dbConnection);
        //command.Parameters.Add(new SqlParameter("@Ma_phieu_xuat_tam", maPhieu));
        //SqlDataAdapter da = new SqlDataAdapter(command);
        //da.Fill(dt);
        //m_dbConnection.Close();
        //return dt;


        public DataTable GetAll()
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {

                var entryPoint = (from ep in help.ent.Chi_Tiet_Phieu_Xuat_Tam
                                  select ep
                         ).ToList();
                return Utilities.clsThamSoUtilities.ToDataTable(entryPoint);
            }

            //m_dbConnection.Open();
            //DataTable dt = new DataTable();
            //string sql = "SELECT * FROM Chi_Tiet_Phieu_xuat_tam ";

            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //m_dbConnection.Close();
            //return dt;
        }
        public bool CheckTonTaiSoDK()
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            bool has = help.ent.Chi_Tiet_Phieu_Xuat_Tam.Any(cus => cus.Ma_phieu_xuat_tam == Ma_phieu_xuat_tam);
            return has;

            //m_dbConnection.Open();
            //DataTable dt = new DataTable();
            //string sql = "SELECT * FROM Chi_Tiet_Phieu_xuat_tam WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam";
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

        public DataTable GetDataTable(string maPhieu)
        {
            if (m_dbConnection.State == ConnectionState.Closed)
                m_dbConnection.Open();

            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Chi_tiet_Phieu_Xuat_Tam ";
            sql += "WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam ";

            SqlCommand command = new SqlCommand(sql, m_dbConnection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add("@Ma_phieu_xuat_tam", SqlDbType.VarChar, 50).Value = maPhieu;
            SqlDataAdapter da = new SqlDataAdapter(command);

            da.Fill(dt);

            m_dbConnection.Close();
            return dt;
        }


        public int CapNhapChiTietPhieuXuat(DataTable dt, string maPhieu, clsPhieuXuatTamVatTu phieuxuat)
        {
            //BeginTransaction
            SqlTransaction m_trans = null;
            SqlConnection m_conn = new SqlConnection(clsThamSoUtilities.connectionString);

            if (m_conn.State == ConnectionState.Closed)
                m_conn.Open();

            m_trans = m_conn.BeginTransaction();

            //Cập nhật phiếu xuất
            if (phieuxuat.CapNhapPhieuXuat(m_trans, m_conn) == -1)
            {
                m_trans.Rollback();
                m_conn.Close();
                return -1;
            }


            //B1: Get về dt vt theo mã phiếu có trong DB
            DataTable old_dt = GetDataTable(maPhieu);
            DataTable new_dt = dt.Copy();

            

            //Nếu mã phiếu này chưa có trong DB, thêm mới tất cả.
            if (old_dt.Rows.Count == 0)
            {
                for (int i=0; i < new_dt.Rows.Count; i++)
                {
                    if (Insert_row(maPhieu, new_dt, i, m_trans, m_conn) == -1)
                    {
                        m_trans.Rollback();
                        m_conn.Close();
                        return -1;
                    }
                }

                m_trans.Commit();
                m_conn.Close();
                return 1;
            } //End Insert mới


            //Nếu đã có trong DB, cập nhật theo table mới --> update cái đã có, insert cái chưa có
            for (int i = 0; i < new_dt.Rows.Count; i++)
            {
                DataRow selectedRow = new_dt.Rows[i];

                string Ma_vat_tu = selectedRow["Ma_vat_tu"].ToString();
                int ID_kho = Int32.Parse(selectedRow["ID_kho"].ToString());
                int Id_chat_luong = Int32.Parse(selectedRow["Id_chat_luong"].ToString());

                DataRow[] KiemTra = old_dt.Select("Ma_vat_tu = \'" + Ma_vat_tu + "\' AND ID_kho = \'" + ID_kho + "\' AND Id_chat_luong = \'" + Id_chat_luong + "\'");

                //Update data da co
                if (KiemTra.Length > 0)
                {
                    //Row đã cập nhật thì xóa đi
                    if (Update_row(maPhieu, new_dt, i, KiemTra[0], m_trans, m_conn) == -1)
                    {
                        m_trans.Rollback();
                        m_conn.Close();
                        return -1;
                    }
                    old_dt.Rows.Remove(KiemTra[0]);
                }
                else
                {
                    if (Insert_row(maPhieu, new_dt, i, m_trans, m_conn) == -1)
                    {
                        m_trans.Rollback();
                        m_conn.Close();
                        return -1;
                    }
                }
            }

            //Xử lý Xóa row ko có trong table mới
            if (old_dt.Rows.Count == 0)
            {
                m_trans.Commit();
                m_conn.Close();

                return 1;
            }

            for (int i = 0; i < old_dt.Rows.Count; i++)
            {
                if (Delete_row(maPhieu, old_dt, i, m_trans, m_conn) == -1)
                {
                    m_trans.Rollback();
                    m_conn.Close();
                    return -1;
                }
            }

            m_trans.Commit();
            m_conn.Close();

            return 1;
        }

        public int Delete_row(string maPhieu, DataTable dt, int row, SqlTransaction m_trans, SqlConnection m_conn)
        {
            if (m_conn.State == ConnectionState.Closed)
                m_conn.Open();

            string sql = "";
            sql += "DELETE FROM Chi_Tiet_Phieu_xuat_tam ";
            sql += "WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam AND Ma_vat_tu=@Ma_vat_tu AND ID_kho=@ID_kho";


            SqlCommand command = new SqlCommand(sql, m_conn, m_trans);
            command.CommandType = CommandType.Text;

            command.Parameters.Add("@Ma_phieu_xuat_tam", SqlDbType.VarChar, 50).Value = maPhieu;
            command.Parameters.Add("@Ma_vat_tu", SqlDbType.VarChar, 50).Value = dt.Rows[row]["Ma_vat_tu"].ToString();
            command.Parameters.Add("@ID_kho", SqlDbType.Int).Value = Int32.Parse(dt.Rows[row]["ID_kho"].ToString());

            int result = command.ExecuteNonQuery();

            return result;
        }

        /// <summary>
        /// Trường hợp Insert mới
        /// [ ] Nếu đã duyệt, thì trừ vào kho --> In processing...
        /// 
        /// </summary>
        public int Insert_row(string maPhieu, DataTable dt, int row, SqlTransaction m_trans, SqlConnection m_conn)
        {
            bool bDa_duyet_xuat_vat_tu =  bool.Parse(dt.Rows[row]["Da_duyet_xuat_vat_tu"].ToString());

            if (m_conn.State == ConnectionState.Closed)
                m_conn.Open();

            string sql = "";
            sql += "INSERT INTO Chi_Tiet_Phieu_xuat_tam (Ma_phieu_xuat_tam,Ma_vat_tu,ID_kho,So_luong_de_nghi,So_luong_thuc_xuat,Da_duyet_xuat_vat_tu,So_luong_hoan_nhap,So_luong_giu_lai,Da_duyet_hoan_nhap_giu_lai,Id_chat_luong) ";
            sql += "VALUES(@Ma_phieu_xuat_tam,@Ma_vat_tu,@ID_kho,@So_luong_de_nghi,@So_luong_thuc_xuat,@Da_duyet_xuat_vat_tu,@So_luong_hoan_nhap,@So_luong_giu_lai,@Da_duyet_hoan_nhap_giu_lai,@Id_chat_luong)";

            SqlCommand command = new SqlCommand(sql, m_conn, m_trans);
            command.CommandType = CommandType.Text;

            command.Parameters.Add("@Ma_phieu_xuat_tam", SqlDbType.VarChar, 50).Value = maPhieu;
            command.Parameters.Add("@Ma_vat_tu", SqlDbType.VarChar, 50).Value = dt.Rows[row]["Ma_vat_tu"].ToString();
            command.Parameters.Add("@ID_kho", SqlDbType.Int).Value = Int32.Parse(dt.Rows[row]["ID_kho"].ToString());
            command.Parameters.Add("@So_luong_de_nghi", SqlDbType.Float).Value = float.Parse(dt.Rows[row]["So_luong_de_nghi"].ToString());
            command.Parameters.Add("@So_luong_thuc_xuat", SqlDbType.Float).Value = float.Parse(dt.Rows[row]["So_luong_thuc_xuat"].ToString());
            command.Parameters.Add("@Da_duyet_xuat_vat_tu", SqlDbType.Bit).Value = bool.Parse(dt.Rows[row]["Da_duyet_xuat_vat_tu"].ToString());
            command.Parameters.Add("@So_luong_hoan_nhap", SqlDbType.Float).Value = float.Parse(dt.Rows[row]["So_luong_hoan_nhap"].ToString());
            command.Parameters.Add("@So_luong_giu_lai", SqlDbType.Float).Value = float.Parse(dt.Rows[row]["So_luong_giu_lai"].ToString());
            command.Parameters.Add("@Da_duyet_hoan_nhap_giu_lai", SqlDbType.Bit).Value = bool.Parse(dt.Rows[row]["Da_duyet_hoan_nhap_giu_lai"].ToString());
            command.Parameters.Add("@Id_chat_luong", SqlDbType.Int).Value = Int32.Parse(dt.Rows[row]["Id_chat_luong"].ToString());

            int result = command.ExecuteNonQuery();

            //Xử lý cập nhật SL tồn, nếu đã duyệt VT.
            //Nếu đã duyệt == true, và trong DB Đã Duyệt == false;
            //&& getBool_DaDuyetXuat(maPhieu, dt, row) == false
            if (bDa_duyet_xuat_vat_tu == true)
            {
                string sMaVT = dt.Rows[row]["Ma_vat_tu"].ToString();
                int iID_Kho = Int32.Parse(dt.Rows[row]["ID_kho"].ToString());
                int iID_ChatLuong = Int32.Parse(dt.Rows[row]["Id_chat_luong"].ToString());
                clsTonKho TonKho = new clsTonKho();
                Double SL_ConLai = TonKho.getSL(sMaVT, iID_Kho, iID_ChatLuong) - Double.Parse(dt.Rows[row]["So_luong_thuc_xuat"].ToString());

                string sql_UpdateTonKho = "";
                sql_UpdateTonKho += "UPDATE Ton_kho ";
                sql_UpdateTonKho += "Set So_luong=@So_luong ";
                sql_UpdateTonKho += "WHERE Ma_vat_tu=@Ma_vat_tu AND Id_chat_luong=@Id_chat_luong AND ID_kho=@ID_kho";

                SqlCommand command_UpdateTonKho = new SqlCommand(sql_UpdateTonKho, m_conn, m_trans);
                command_UpdateTonKho.CommandType = CommandType.Text;

                command_UpdateTonKho.Parameters.Add("@Ma_vat_tu", SqlDbType.VarChar, 50).Value = sMaVT;
                command_UpdateTonKho.Parameters.Add("@ID_kho", SqlDbType.Int).Value = iID_Kho;
                command_UpdateTonKho.Parameters.Add("@Id_chat_luong", SqlDbType.Int).Value = iID_ChatLuong;
                command_UpdateTonKho.Parameters.Add("@So_luong", SqlDbType.Float).Value = SL_ConLai;

                int result_UpdateTonKho = command_UpdateTonKho.ExecuteNonQuery();
                return result_UpdateTonKho;
            }

            return result;
        }

        //Chỉ dùng nội bộ, ko đóng connection
        public bool getBool_DaDuyetXuat(string maPhieu, DataTable dt_data, int row)
        {
            if (m_dbConnection.State == ConnectionState.Closed)
                m_dbConnection.Open();

            System.Data.DataTable dt = new DataTable();

            string sMaVT = dt_data.Rows[row]["Ma_vat_tu"].ToString();
            int iID_Kho = Int32.Parse(dt_data.Rows[row]["ID_kho"].ToString());
            int iID_ChatLuong = Int32.Parse(dt_data.Rows[row]["Id_chat_luong"].ToString());

            //Chuẩn bị 
            string sql = "";
            sql += "SELECT Da_duyet_xuat_vat_tu FROM Chi_Tiet_Phieu_Xuat_Tam ";
            sql += "WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam ";
            sql += "AND Ma_vat_tu=@Ma_vat_tu ";
            sql += "AND ID_Kho=@ID_Kho ";
            sql += "AND Id_chat_luong=@Id_chat_luong ";

            SqlCommand command = new SqlCommand(sql, m_dbConnection);

            command.Parameters.Add("@Ma_phieu_xuat_tam", SqlDbType.VarChar, 50).Value = maPhieu;
            command.Parameters.Add("@Ma_vat_tu", SqlDbType.VarChar, 50).Value = sMaVT;
            command.Parameters.Add("@ID_Kho", SqlDbType.Int).Value = iID_Kho;
            command.Parameters.Add("@Id_chat_luong", SqlDbType.Int).Value = iID_ChatLuong;

            command.CommandType = CommandType.Text;

            //Run
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);

            //Đóng
            m_dbConnection.Close();

            if (dt.Rows.Count > 0)
                return bool.Parse(dt.Rows[0]["Da_duyet_xuat_vat_tu"].ToString());
            else
                return false;
        }

        public bool getBool_DaDuyetXuat(string maPhieu, string sMaVT, int iID_Kho, int iID_ChatLuong)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Chi_Tiet_Phieu_Xuat_Tam
                          where d.Ma_phieu_xuat_tam == maPhieu &&
                                d.Ma_vat_tu == sMaVT &&
                                d.ID_kho == iID_Kho &&
                                d.Id_chat_luong == iID_ChatLuong
                          select new
                          {
                              d.Da_duyet_xuat_vat_tu
                          }).ToList();
                dbcxtransaction.Commit();

                DataTable dt = Utilities.clsThamSoUtilities.ToDataTable(dm);

                if (dt.Rows.Count > 0)
                    return bool.Parse(dt.Rows[0]["Da_duyet_xuat_vat_tu"].ToString());
                else
                    return true;
            }

            //if (m_dbConnection.State == ConnectionState.Closed)
            //    m_dbConnection.Open();

            //System.Data.DataTable dt = new DataTable();

            ////string sMaVT = dt_data.Rows[row]["Ma_vat_tu"].ToString();
            ////int iID_Kho = Int32.Parse(dt_data.Rows[row]["ID_kho"].ToString());
            ////int iID_ChatLuong = Int32.Parse(dt_data.Rows[row]["Id_chat_luong"].ToString());

            ////Chuẩn bị 
            //string sql = "";
            //sql += "SELECT Da_duyet_xuat_vat_tu FROM Chi_Tiet_Phieu_Xuat_Tam ";
            //sql += "WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam ";
            //sql += "AND Ma_vat_tu=@Ma_vat_tu ";
            //sql += "AND ID_Kho=@ID_Kho ";
            //sql += "AND Id_chat_luong=@Id_chat_luong ";

            //SqlCommand command = new SqlCommand(sql, m_dbConnection);

            //command.Parameters.Add("@Ma_phieu_xuat_tam", SqlDbType.VarChar, 50).Value = maPhieu;
            //command.Parameters.Add("@Ma_vat_tu", SqlDbType.VarChar, 50).Value = sMaVT;
            //command.Parameters.Add("@ID_Kho", SqlDbType.Int).Value = iID_Kho;
            //command.Parameters.Add("@Id_chat_luong", SqlDbType.Int).Value = iID_ChatLuong;

            //command.CommandType = CommandType.Text;

            ////Run
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);

            ////Đóng
            //m_dbConnection.Close();

            //if (dt.Rows.Count > 0)
            //    return bool.Parse(dt.Rows[0]["Da_duyet_xuat_vat_tu"].ToString());
            //else
            //    return false;
        }

        public int Update_row(string maPhieu, DataTable dt, int row, DataRow KiemTra, SqlTransaction m_trans, SqlConnection m_conn)
        {
            string sMaVT = dt.Rows[row]["Ma_vat_tu"].ToString();
            int iID_Kho = Int32.Parse(dt.Rows[row]["ID_kho"].ToString());
            int iID_ChatLuong = Int32.Parse(dt.Rows[row]["Id_chat_luong"].ToString());

            bool bDa_duyet_xuat_vat_tu = bool.Parse(dt.Rows[row]["Da_duyet_xuat_vat_tu"].ToString());
            bool bDa_duyet_xuat_in_DB = bool.Parse(KiemTra["Da_duyet_xuat_vat_tu"].ToString()); //getBool_DaDuyetXuat(maPhieu, sMaVT, iID_Kho, iID_ChatLuong);

            if (m_conn.State == ConnectionState.Closed)
                m_conn.Open();

            string sql = "";
            sql += "UPDATE Chi_Tiet_Phieu_Xuat_Tam ";
            sql += "Set So_luong_de_nghi=@So_luong_de_nghi,So_luong_thuc_xuat=@So_luong_thuc_xuat,Da_duyet_xuat_vat_tu=@Da_duyet_xuat_vat_tu,So_luong_hoan_nhap=@So_luong_hoan_nhap,So_luong_giu_lai=@So_luong_giu_lai,Da_duyet_hoan_nhap_giu_lai=@Da_duyet_hoan_nhap_giu_lai ";
            sql += "WHERE Ma_phieu_xuat_tam=@Ma_phieu_xuat_tam AND Ma_vat_tu=@Ma_vat_tu AND Id_chat_luong=@Id_chat_luong AND ID_kho=@ID_kho";


            SqlCommand command = new SqlCommand(sql, m_conn, m_trans);
            command.CommandType = CommandType.Text;

            command.Parameters.Add("@Ma_phieu_xuat_tam", SqlDbType.VarChar, 50).Value = maPhieu;
            command.Parameters.Add("@Ma_vat_tu", SqlDbType.VarChar, 50).Value = dt.Rows[row]["Ma_vat_tu"].ToString();
            command.Parameters.Add("@ID_kho", SqlDbType.Int).Value = Int32.Parse(dt.Rows[row]["ID_kho"].ToString());
            command.Parameters.Add("@So_luong_de_nghi", SqlDbType.Float).Value = float.Parse(dt.Rows[row]["So_luong_de_nghi"].ToString());
            command.Parameters.Add("@So_luong_thuc_xuat", SqlDbType.Float).Value = float.Parse(dt.Rows[row]["So_luong_thuc_xuat"].ToString());
            command.Parameters.Add("@Da_duyet_xuat_vat_tu", SqlDbType.Bit).Value = bool.Parse(dt.Rows[row]["Da_duyet_xuat_vat_tu"].ToString());
            command.Parameters.Add("@So_luong_hoan_nhap", SqlDbType.Float).Value = float.Parse(dt.Rows[row]["So_luong_hoan_nhap"].ToString());
            command.Parameters.Add("@So_luong_giu_lai", SqlDbType.Float).Value = float.Parse(dt.Rows[row]["So_luong_giu_lai"].ToString());
            command.Parameters.Add("@Da_duyet_hoan_nhap_giu_lai", SqlDbType.Bit).Value = bool.Parse(dt.Rows[row]["Da_duyet_hoan_nhap_giu_lai"].ToString());
            command.Parameters.Add("@Id_chat_luong", SqlDbType.Int).Value = Int32.Parse(dt.Rows[row]["Id_chat_luong"].ToString());

            int result = command.ExecuteNonQuery();

            //Xử lý cập nhật SL tồn, nếu đã duyệt VT.
            //Nếu đã duyệt == true, và trong DB Đã Duyệt == false;
            //&& getBool_DaDuyetXuat(maPhieu, dt, row) == false
            if (bDa_duyet_xuat_vat_tu == true && bDa_duyet_xuat_in_DB  == false)
            {
                //string sMaVT = dt.Rows[row]["Ma_vat_tu"].ToString();
                //int iID_Kho = Int32.Parse(dt.Rows[row]["ID_kho"].ToString());
                //int iID_ChatLuong = Int32.Parse(dt.Rows[row]["Id_chat_luong"].ToString());
                clsTonKho TonKho = new clsTonKho();
                Double SL_ConLai = TonKho.getSL(sMaVT, iID_Kho, iID_ChatLuong) - Double.Parse(dt.Rows[row]["So_luong_thuc_xuat"].ToString());

                string sql_UpdateTonKho = "";
                sql_UpdateTonKho += "UPDATE Ton_kho ";
                sql_UpdateTonKho += "Set So_luong=@So_luong ";
                sql_UpdateTonKho += "WHERE Ma_vat_tu=@Ma_vat_tu AND Id_chat_luong=@Id_chat_luong AND ID_kho=@ID_kho";

                SqlCommand command_UpdateTonKho = new SqlCommand(sql_UpdateTonKho, m_conn, m_trans);
                command_UpdateTonKho.CommandType = CommandType.Text;

                command_UpdateTonKho.Parameters.Add("@Ma_vat_tu", SqlDbType.VarChar, 50).Value = sMaVT;
                command_UpdateTonKho.Parameters.Add("@ID_kho", SqlDbType.Int).Value = iID_Kho;
                command_UpdateTonKho.Parameters.Add("@Id_chat_luong", SqlDbType.Int).Value = iID_ChatLuong;
                command_UpdateTonKho.Parameters.Add("@So_luong", SqlDbType.Float).Value = SL_ConLai;

                int result_UpdateTonKho = command_UpdateTonKho.ExecuteNonQuery();
                return result_UpdateTonKho;
            }
            return result;
        }




        public int Insert(SQLDAL dal)
        {

            //DatabaseHelper help = new DatabaseHelper();
            //help.ConnectDatabase();
            // insert
            //try
            //{
            //    using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            //    {

            //        var t = new Chi_Tiet_Phieu_Xuat_Tam //Make sure you have a table called test in DB
            //        {
            //            Ma_phieu_xuat_tam = this.Ma_phieu_xuat_tam,
            //            Ma_vat_tu = this.Ma_vat_tu,                   // ID = Guid.NewGuid(),
            //            So_luong_hoan_nhap = this.So_luong_hoan_nhap,
            //            So_luong_giu_lai = this.So_luong_giu_lai,
            //            So_luong_thuc_lanh = this.so_luong_thuc_lanh,
            //            So_luong_de_nghi = this.So_luong_de_nghi,

            //        };

            //        help.ent.Chi_Tiet_Phieu_Xuat_Tam.Add(t);
            //        help.ent.SaveChanges();
            //        dbcxtransaction.Commit();
            //        return 1;
            //    }
            //}
            //catch (Exception ex)
            //{

                return 0;

            //}

            //m_dbConnection = dal.m_conn;
            //if (m_dbConnection.State == ConnectionState.Closed)
            //    m_dbConnection.Open();

            //string sql = "";
            //sql += "INSERT INTO Chi_Tiet_Phieu_xuat_tam (ma_phieu_xuat_tam,Ma_vat_tu,So_luong_hoan_nhap,So_luong_giu_lai,so_luong_thuc_lanh) ";
            //sql += "VALUES(@ma_phieu_xuat_tam,@Ma_vat_tu,@So_luong_hoan_nhap,@So_luong_giu_lai,@so_luong_thuc_lanh)";

            //SqlCommand command = new SqlCommand(sql, m_dbConnection, dal.m_trans);
            //command.CommandType = CommandType.Text;

            ////command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
            //command.Parameters.Add(new SqlParameter("@ma_phieu_xuat_tam", Ma_phieu_xuat_tam));
            //command.Parameters.Add(new SqlParameter("@Ma_vat_tu", Ma_vat_tu));
            ////command.Parameters.Add(new SqlParameter("@So_luong_de_nghi", So_luong_de_nghi));
            //command.Parameters.Add(new SqlParameter("@So_luong_hoan_nhap", So_luong_hoan_nhap));
            //command.Parameters.Add(new SqlParameter("@So_luong_giu_lai", So_luong_giu_lai));
            //command.Parameters.Add(new SqlParameter("@so_luong_thuc_lanh", so_luong_thuc_lanh));

            //int result = command.ExecuteNonQuery();


            //return result;
        }

        public int Update(Chi_Tiet_Phieu_Xuat_Tam ctxt)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            int temp = 0;
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                using (var context = help.ent)
                {
                    context.Chi_Tiet_Phieu_Xuat_Tam.Attach(ctxt);
                    context.Entry(ctxt).State = EntityState.Modified;
                    temp = help.ent.SaveChanges();
                    dbcxtransaction.Commit();
                }
            }
            return temp;


            //DAL.BeginTransaction();

            //m_dbConnection = DAL.m_conn;
            //if (m_dbConnection.State == ConnectionState.Closed)
            //    m_dbConnection.Open();

            //string sql = "";
            //sql += "UPDATE Chi_Tiet_Phieu_xuat_tam ";
            //sql += "Set ma_phieu_xuat_tam=@ma_phieu_xuat_tam,Ma_vat_tu=@Ma_vat_tu,So_luong_de_nghi=@So_luong_de_nghi,So_luong_hoan_nhap=@So_luong_hoan_nhap,So_luong_giu_lai = @So_luong_giu_lai ,so_luong_thuc_lanh = @so_luong_thuc_lanh";
            //sql += "WHERE ma_phieu_xuat_tam=@ma_phieu_xuat_tam and ID_vat_tu = @ID_vat_tu";


            //SqlCommand command = new SqlCommand(sql, m_dbConnection, DAL.m_trans);
            //command.CommandType = CommandType.Text;

            //command.Parameters.Add(new SqlParameter("@ma_phieu_xuat_tam", Ma_phieu_xuat_tam));
            //command.Parameters.Add(new SqlParameter("@Ma_vat_tu", Ma_vat_tu));
            //command.Parameters.Add(new SqlParameter("@So_luong_de_nghi", So_luong_de_nghi));
            //command.Parameters.Add(new SqlParameter("@So_luong_hoan_nhap", So_luong_hoan_nhap));
            //command.Parameters.Add(new SqlParameter("@So_luong_giu_lai", So_luong_giu_lai));

            ////  command.Parameters.Add(new SqlParameter("@so_hoa_don", So_hoa_don));

            //int result = command.ExecuteNonQuery();
            //DAL.CommitTransaction();
            //return result;
        }
        public int Delete(Chi_Tiet_Phieu_Xuat_Tam ctxt)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {

                help.ent.Chi_Tiet_Phieu_Xuat_Tam.Attach(ctxt);
                help.ent.Chi_Tiet_Phieu_Xuat_Tam.Remove(ctxt);
                help.ent.SaveChanges();
                dbcxtransaction.Commit();
                return 1;
                //}
                //DAL.BeginTransaction();

                //m_dbConnection = DAL.m_conn;
                //if (m_dbConnection.State == ConnectionState.Closed)
                //    m_dbConnection.Open();
                //string sql = "Delete from Chi_Tiet_Phieu_xuat_tam WHERE ma_phieu_xuat_tam=@ma_phieu_xuat_tam and Ma_vat_tu = @Ma_vat_tu";


                //SqlCommand command = new SqlCommand(sql, m_dbConnection, DAL.m_trans);
                //command.CommandType = CommandType.Text;

                //command.Parameters.Add(new SqlParameter("@ma_phieu_xuat_tam", Ma_phieu_xuat_tam));
                //command.Parameters.Add(new SqlParameter("@Ma_vat_tu", Ma_vat_tu));

                //int result = command.ExecuteNonQuery();
                //DAL.CommitTransaction();
                //return result;
            }

        }
    }
}

    