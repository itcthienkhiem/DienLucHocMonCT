using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Inventory.Utilities;
using Inventory.Models;
using System.Linq;
using System.Data.Entity;
namespace Inventory.EntityClass
{
   public class clsChi_Tiet_Phieu_Nhap_Vat_Tu
    {
        public int? ID_chi_tiet_phieu_nhap;
        public string Ma_phieu_nhap;
        public string Ma_vat_tu;
        public string Chat_luong;
        public string Don_vi;
        public int? So_luong_yeu_cau;
        public int? So_luong_thuc_nhap;
        public int? Don_gia;
        public int? Thanh_tien;
        public int? ID_Don_vi_tinh;
        public string Ten_DVT;
        //public int? ID_Don_vi_tinh;

        SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);
        public clsChi_Tiet_Phieu_Nhap_Vat_Tu()
        {
          //  var str = config.AppSettings.Settings["ConnectionString"].Value;
          //  m_dbConnection=new SqlConnection(
            
        }
        public object GetAll()
        {
           


            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = from d in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
                         join e in help.ent.DM_Don_vi_tinh on d.ID_Don_vi_tinh equals e.ID_Don_vi_tinh
                         select new
                         {
                             d.ID_chi_tiet_phieu_nhap_vat_tu,
                             d.Ma_phieu_nhap,
                             d.Ma_vat_tu,
                             d.Chat_luong,
                             d.So_luong_yeu_cau,
                             d.So_luong_thuc_lanh,
                             d.Don_gia,
                             d.Thanh_tien,
                             d.ID_Don_vi_tinh,
                             e.Ten_don_vi_tinh,
                             
                         };
                dbcxtransaction.Commit();
                return (object)dm.ToList();
            }
              


            //m_dbConnection.Open();
            //DataTable dt = new DataTable();
            //string sql = "SELECT * FROM Chi_Tiet_Phieu_Nhap_Vat_Tu";
            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //m_dbConnection.Close();
            //return dt;
        }
        public int remove(string ma_phieu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
             help.ent.Database.BeginTransaction();
            using (var ctx =  help.ent)
            {
                //var stud = (from s in ctx.Chi_Tiet_Phieu_Nhap_Vat_Tu
                //            where s.Ma_vat_tu == "Student1"
                //            select s).FirstOrDefault();
                var users = help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Where(u => u.Ma_vat_tu == ma_phieu);

                foreach (var u in users)
                {
                    help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Remove(u);
                }

            return  help.ent.SaveChanges();
              //  ctx.Chi_Tiet_Phieu_Nhap_Vat_Tu.DeleteObject(stud);

              //  int num = ctx.SaveChanges();
            }
        }
        public int removebyKey(SQLDAL DAL, string ma_Phieunhap,string ma_vat_tu)
        {
              DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                Chi_Tiet_Phieu_Nhap_Vat_Tu deptBook = new Chi_Tiet_Phieu_Nhap_Vat_Tu { Ma_vat_tu = ma_vat_tu,Ma_phieu_nhap = ma_Phieunhap };
                help.ent.Entry(deptBook).State = EntityState.Deleted;
                help.ent.SaveChanges();
                return 1;
            }
            return 0;

            //DAL.BeginTransaction();

            //m_dbConnection = DAL.m_conn;
            //if (m_dbConnection.State == ConnectionState.Closed)
            //    m_dbConnection.Open();
            //string sql = "Delete from Chi_Tiet_Phieu_Nhap_Vat_Tu WHERE Ma_phieu_nhap=@Ma_phieu_nhap and ma_vat_tu =@ma_vat_tu";


            //SqlCommand command = new SqlCommand(sql, m_dbConnection, DAL.m_trans);
            //command.CommandType = CommandType.Text;

            //command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", ma_Phieunhap));
            //command.Parameters.Add(new SqlParameter("@Ma_vat_tu", ma_vat_tu));

            //int result = command.ExecuteNonQuery();
            //DAL.CommitTransaction();

            //return result;
        }


        /// <summary>
        /// Lấy dữ liệu theo "Mã phiếu nhập"
        /// - Trả về Data để set lên frm
        /// </summary>
        /// <param name="ma_Phieunhap">The ma_ phieunhap.</param>
        /// <returns></returns>
        public DataTable GetAll(string ma_Phieunhap)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();

            var entryPoint = (from ep in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
                              join e in help.ent.DM_Don_vi_tinh on ep.ID_Don_vi_tinh equals e.ID_Don_vi_tinh
                              join u in help.ent.DM_Vat_Tu on ep.Ma_vat_tu equals u.Ma_vat_tu
                              where ep.Ma_phieu_nhap .Contains( ma_Phieunhap)

                              select new
                              {
                                  ID_vat_tu = ep.ID_chi_tiet_phieu_nhap_vat_tu,
                                  Ma_vat_tu = ep.Ma_vat_tu,
                                  Ten_vat_tu = u.Ten_vat_tu,
                                  Ten_don_vi_tinh = e.Ten_don_vi_tinh,
                                  Chat_luong = ep.Chat_luong,
                                  So_luong_yeu_cau = ep.So_luong_yeu_cau,
                                  So_luong_thuc_nhap = ep.So_luong_thuc_lanh,
                                  Thanh_tien = ep.Thanh_tien,
                                  Don_gia = ep.Don_gia,
                                  id_don_vi_tinh = ep.ID_Don_vi_tinh,
                                  Ten_DVT = e.Ten_don_vi_tinh,
                              }).ToList();
            //return entryPoint.ToList();

            DataTable table = new DataTable();
            table.Columns.Add("ID_vat_tu", typeof(int));
            table.Columns.Add("Ma_vat_tu", typeof(string));
            table.Columns.Add("Ten_vat_tu", typeof(string));
            table.Columns.Add("Ten_don_vi_tinh", typeof(string));
            table.Columns.Add("Chat_luong", typeof(string));
            table.Columns.Add("So_luong_yeu_cau", typeof(int?));
            table.Columns.Add("So_luong_thuc_nhap", typeof(int?));
            table.Columns.Add("Thanh_tien", typeof(int?));
            table.Columns.Add("id_don_vi_tinh", typeof(int?));
            table.Columns.Add("Ten_DVT", typeof(string));
            table.Columns.Add("Don_gia", typeof(string));
            entryPoint.ToList().ForEach((n) =>
            {
                DataRow row = table.NewRow();
                row.SetField<int>("ID_vat_tu", n.ID_vat_tu);
                row.SetField<string>("Ma_vat_tu", n.Ma_vat_tu);
                row.SetField<string>("Ten_vat_tu", n.Ten_vat_tu);
                row.SetField<string>("Ten_don_vi_tinh", n.Ten_don_vi_tinh);
                row.SetField<string>("Chat_luong", n.Chat_luong);
                row.SetField<int?>("So_luong_yeu_cau", n.So_luong_yeu_cau);
                row.SetField<int?>("So_luong_thuc_nhap", n.So_luong_thuc_nhap);
                row.SetField<int?>("Thanh_tien", n.Thanh_tien);
                row.SetField<int?>("id_don_vi_tinh", n.id_don_vi_tinh);
                row.SetField<string>("Ten_DVT", n.Ten_DVT);

                row.SetField<int?>("Don_gia", n.Don_gia);



                table.Rows.Add(row);
            });
            return table;
            //m_dbConnection.Open();
            //DataTable dt = new DataTable();


            //string sql = "";
            //sql += "SELECT ";
            //sql += "" + "Chi_Tiet_Phieu_Nhap_Vat_Tu.ma_vat_tu, ";
            //sql += "" + "dm_vat_tu.ten_vat_tu, ";
            //sql += "" + "Chi_Tiet_Phieu_Nhap_Vat_Tu.Chat_luong, ";
            //sql += "" + "Chi_Tiet_Phieu_Nhap_Vat_Tu.So_luong_yeu_cau, ";
            //sql += "" + "Chi_Tiet_Phieu_Nhap_Vat_Tu.So_luong_thuc_lanh, ";
            //sql += "" + "Chi_Tiet_Phieu_Nhap_Vat_Tu.Thanh_tien, ";
            //sql += "" + "dm_vat_tu.Don_gia, ";
            //sql += "" + "dm_don_vi_tinh.ten_don_vi_tinh, ";
            //sql += "" + "Chi_Tiet_Phieu_Nhap_Vat_Tu.ID_don_vi_tinh ";
            //sql += "FROM Chi_Tiet_Phieu_Nhap_Vat_Tu ";
            //sql += "INNER ";
            //sql += "" + "JOIN dm_vat_tu ";
            //sql += "" + "ON dm_vat_tu.ma_vat_tu = Chi_Tiet_Phieu_Nhap_Vat_Tu.ma_vat_tu ";
            //sql += "INNER ";
            //sql += "" + "JOIN dm_don_vi_tinh ";
            //sql += "" + "ON dm_don_vi_tinh.ID_Don_vi_tinh = dm_vat_tu.ID_Don_vi_tinh ";
            //sql += "WHERE Ma_phieu_nhap=@Ma_phieu_nhap";


            ////string sql = "SELECT Chi_Tiet_Phieu_Nhap_Vat_Tu.ma_vat_tu,dm_vat_tu.ten_vat_tu,Chi_Tiet_Phieu_Nhap_Vat_Tu.Chat_luong";
            ////sql += ", Chi_Tiet_Phieu_Nhap_Vat_Tu.So_luong_yeu_cau, Chi_Tiet_Phieu_Nhap_Vat_Tu. So_luong_thuc_lanh, Chi_Tiet_Phieu_Nhap_Vat_Tu.Thanh_tien, dm_vat_tu.Don_gia, dm_don_vi_tinh.ten_don_vi_tinh, Chi_Tiet_Phieu_Nhap_Vat_Tu.ID_don_vi_tinh FROM Chi_Tiet_Phieu_Nhap_Vat_Tu ";
            ////sql += " join dm_vat_tu on dm_vat_tu.ma_vat_tu = Chi_Tiet_Phieu_Nhap_Vat_Tu.ma_vat_tu";
            ////sql += " join dm_don_vi_tinh on dm_don_vi_tinh.ID_Don_vi_tinh =dm_vat_tu.ID_Don_vi_tinh ";
            ////sql+= " WHERE Ma_phieu_nhap=@Ma_phieu_nhap";

            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", ma_Phieunhap));
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            
            //m_dbConnection.Close();

            //return dt;
        }

        public bool CheckTonTaiSoDK()
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            bool has = help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Any(cus => cus.Ma_phieu_nhap == Ma_phieu_nhap);
            return has;


            //m_dbConnection.Open();
            //DataTable dt = new DataTable();
            //string sql = "SELECT * FROM Chi_Tiet_Phieu_Nhap_Vat_Tu WHERE Ma_phieu_nhap=@Ma_phieu_nhap";
            //SqlCommand command = new SqlCommand(sql, m_dbConnection);
            //command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", Ma_phieu_nhap));
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);
            //m_dbConnection.Close();

            //if (dt.Rows.Count > 0)
            //{
            //    return true;
            //}
            //return false;
        }
        public int Insert(SQLDAL DAL)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            // insert
            try
            {
                var t = new Chi_Tiet_Phieu_Nhap_Vat_Tu //Make sure you have a table called test in DB
                {
                    Ma_phieu_nhap = this.Ma_phieu_nhap,
                    Ma_vat_tu = this.Ma_vat_tu,                   // ID = Guid.NewGuid(),
                    Chat_luong = this.Chat_luong,
                    So_luong_yeu_cau = this.So_luong_yeu_cau,
                    So_luong_thuc_lanh = this.So_luong_thuc_nhap,
                    Don_gia = this.Don_gia,
                    Thanh_tien = this.Thanh_tien,
                    ID_Don_vi_tinh = this.ID_Don_vi_tinh,
                };

                help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Add(t);
                help.ent.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;

            }



           // DAL.BeginTransaction();
       
           // m_dbConnection = DAL.m_conn;
           // if (m_dbConnection.State == ConnectionState.Closed)
           // m_dbConnection.Open();
           // string sql = "";
           // sql += "INSERT INTO Chi_Tiet_Phieu_Nhap_Vat_Tu (Ma_phieu_nhap,ma_vat_tu,Chat_luong,So_luong_yeu_cau,So_luong_thuc_lanh,don_gia,thanh_tien, ID_Don_vi_tinh) ";
           // sql += "VALUES(@Ma_phieu_nhap,@ma_vat_tu,@Chat_luong,@So_luong_yeu_cau,@So_luong_thuc_lanh,@don_gia,@thanh_tien, @ID_Don_vi_tinh)";

           // SqlCommand command = new SqlCommand(sql, m_dbConnection,DAL.m_trans);
           // command.CommandType = CommandType.Text;

           // //command.Parameters.Add(new SQLiteParameter("@BangKe_Id", BangKe_Id));
           // command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", Ma_phieu_nhap));
           // command.Parameters.Add(new SqlParameter("@ma_vat_tu", Ma_vat_tu));
           // command.Parameters.Add(new SqlParameter("@Chat_luong", Chat_luong));
           // command.Parameters.Add(new SqlParameter("@Don_gia", Don_gia));
           // command.Parameters.Add(new SqlParameter("@Thanh_tien", Thanh_tien));
           // command.Parameters.Add(new SqlParameter("@So_luong_yeu_cau", So_luong_yeu_cau));
           // command.Parameters.Add(new SqlParameter("@So_luong_thuc_lanh", So_luong_thuc_nhap));
           //// command.Parameters.Add(new SqlParameter("@Dia_chi", Dia_chi));
           // command.Parameters.Add(new SqlParameter("@ID_Don_vi_tinh", ID_Don_vi_tinh));


           // //command.Parameters.Add(new SqlParameter("@ma_phieu_nhap", Ma_phieu_nhap));

           // int result = command.ExecuteNonQuery();
           // DAL.CommitTransaction();

           // return result;
        }

        public int Update(Chi_Tiet_Phieu_Nhap_Vat_Tu pn)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            int temp = 0;
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                using (var context = help.ent)
                {
                    context.Chi_Tiet_Phieu_Nhap_Vat_Tu.Attach(pn);
                    context.Entry(pn).State = EntityState.Modified;
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
            //sql += "UPDATE Chi_Tiet_Phieu_Nhap_Vat_Tu ";
            //sql += "Set Ma_phieu_nhap=@Ma_phieu_nhap,ma_vat_tu=@ma_vat_tu,Chat_luong=@Chat_luong,Don_vi=@Don_vi,So_luong_yeu_cau =@So_luong_yeu_cau,So_luong_thuc_nhap = @So_luong_thuc_nhap, ID_Don_vi_tinh= @ID_Don_vi_tinh ";
            //sql += "WHERE Ma_phieu_nhap=@Ma_phieu_nhap";


            //SqlCommand command = new SqlCommand(sql, m_dbConnection, DAL.m_trans);
            //command.CommandType = CommandType.Text;

            //command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", Ma_phieu_nhap));
            //command.Parameters.Add(new SqlParameter("@ma_vat_tu", Ma_vat_tu));
            //command.Parameters.Add(new SqlParameter("@Chat_luong", Chat_luong));
            //command.Parameters.Add(new SqlParameter("@Don_vi", Don_vi));

            //command.Parameters.Add(new SqlParameter("@So_luong_yeu_cau", So_luong_yeu_cau));
            //command.Parameters.Add(new SqlParameter("@So_luong_thuc_nhap", So_luong_thuc_nhap));
            //command.Parameters.Add(new SqlParameter("@ID_don_vi_tinh", ID_Don_vi_tinh));

            ////command.Parameters.Add(new SqlParameter("@ID_kho", ID_kho));

            //int result = command.ExecuteNonQuery();
            //DAL.CommitTransaction();

            ////m_dbConnection.Close();
            //return result;
        }
        //public int DeleteAllChitiet()
        //{
        //    DatabaseHelper help = new DatabaseHelper();
        //    help.ConnectDatabase();
        //    var queryChi_Tiet_Phieu_Nhap_Vat_Tu =
        //from Chi_Tiet_Phieu_Nhap_Vat_Tu in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
        //where
        //  Chi_Tiet_Phieu_Nhap_Vat_Tu.Ma_phieu_nhap == Convert.ToString(1)
        //select Chi_Tiet_Phieu_Nhap_Vat_Tu;
        //    foreach (var del in queryChi_Tiet_Phieu_Nhap_Vat_Tu)
        //    {
        //        help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.de(del);
        //    }
        //    help.ent.SubmitChanges();
        //    return 1;
        //}
    //    public int DeleteAll(string mapn, string ma_vat_tu)
    //    {
    //        DatabaseHelper help = new DatabaseHelper();
    //        help.ConnectDatabase();
    //        var queryChi_Tiet_Phieu_Nhap_Vat_Tu =
    //from Chi_Tiet_Phieu_Nhap_Vat_Tu in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
    //where
    //  Chi_Tiet_Phieu_Nhap_Vat_Tu.Ma_phieu_nhap == Convert.ToString(1) &&
    //  Chi_Tiet_Phieu_Nhap_Vat_Tu.Ma_vat_tu == Convert.ToString(1)
    //select Chi_Tiet_Phieu_Nhap_Vat_Tu;
    //        foreach (var del in queryChi_Tiet_Phieu_Nhap_Vat_Tu)
    //        {
    //            db.Chi_Tiet_Phieu_Nhap_Vat_Tu.DeleteOnSubmit(del);
    //        }
    //        help.ent.SubmitChanges();
    //        return 1; 
    //    }
        public int Delete(Chi_Tiet_Phieu_Nhap_Vat_Tu pn)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Attach(pn);
            help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Remove(pn);
            return help.ent.SaveChanges();

            //DAL.BeginTransaction();
       
            //m_dbConnection = DAL.m_conn;
            //if (m_dbConnection.State == ConnectionState.Closed)
            //    m_dbConnection.Open();
            //string sql = "Delete from Chi_Tiet_Phieu_Nhap_Vat_Tu WHERE Ma_phieu_nhap=@Ma_phieu_nhap and ma_vat_tu =@ma_vat_tu";


            //SqlCommand command = new SqlCommand(sql, m_dbConnection, DAL.m_trans);
            //command.CommandType = CommandType.Text;

            //command.Parameters.Add(new SqlParameter("@Ma_phieu_nhap", Ma_phieu_nhap));
            //command.Parameters.Add(new SqlParameter("@Ma_vat_tu", Ma_vat_tu));

            //int result = command.ExecuteNonQuery();
            //DAL.CommitTransaction();

            //return result;
        }
    }
}
