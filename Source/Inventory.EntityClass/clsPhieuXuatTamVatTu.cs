using System;
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
        public int? ID_Nhan_vien;
        public int? ID_kho;
        public string Ma_phieu_xuat_tam;
        public DateTime Ngay_xuat;
        public string Ly_do;
        public string Cong_trinh;
        public string Dia_chi;
        public DateTime Ngay_lap;
        public clsPhieuXuatTamVatTu()
        {
        }
        SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);



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

        public DataTable GetAll_DSPhieuXuat()
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Phieu_Xuat_Tam_Vat_Tu
                          join e in help.ent.DM_Nhan_Vien on d.ID_nhan_vien equals e.ID_nhan_vien
                          join k in help.ent.DM_Kho on d.ID_kho equals k.ID_kho

                          select new
                          {
                              d.Ma_phieu_xuat_tam,
                              e.Ten_nhan_vien,
                              k.Ten_kho,
                              d.Ngay_xuat,
                              d.Ly_do,
                              d.Cong_trinh,
                              d.Dia_chi,

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
            if (showPiece!=null&& showPiece.Ma_phieu_xuat_tam.Contains(day + "." + month + "." + year))
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

