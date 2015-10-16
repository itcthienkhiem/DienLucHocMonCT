using System;
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
    public class clsChiTietPhieuXuatTam
    {
        public string Ma_phieu_xuat_tam;
        public string Ma_vat_tu;
        public int So_luong_de_nghi;
        public int So_luong_hoan_nhap;
        public int So_luong_giu_lai;
        public int so_luong_thuc_lanh;
        SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);

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
        public int Insert(SQLDAL dal)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            // insert
            try
            {
                using (var dbcxtransaction = help.ent.Database.BeginTransaction())
                {

                    var t = new Chi_Tiet_Phieu_Xuat_Tam //Make sure you have a table called test in DB
                    {
                        Ma_phieu_xuat_tam = this.Ma_phieu_xuat_tam,
                        Ma_vat_tu = this.Ma_vat_tu,                   // ID = Guid.NewGuid(),
                        So_luong_hoan_nhap = this.So_luong_hoan_nhap,
                        So_luong_giu_lai = this.So_luong_giu_lai,
                        So_luong_thuc_lanh = this.so_luong_thuc_lanh,
                        So_luong_de_nghi = this.So_luong_de_nghi,

                    };

                    help.ent.Chi_Tiet_Phieu_Xuat_Tam.Add(t);
                    help.ent.SaveChanges();
                    dbcxtransaction.Commit();
                    return 1;
                }
            }
            catch (Exception ex)
            {

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

            }
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

