using Inventory.Models;
using Inventory.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace Inventory.EntityClass
{
    public class clsTonKho
    {
        public int ID_ton_kho;
        public int ID_kho;
        public string Ma_vat_tu;
        public double So_luong;

        SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);

        /// <summary>
        /// lấy tất cả danh sách mã vật tư
        /// </summary>
        public System.Windows.Forms.AutoCompleteStringCollection getListMaVatTu(int ID_kho)
        {
            m_dbConnection.Open();

            DataSet ds = new DataSet();
            System.Windows.Forms.AutoCompleteStringCollection dataCollection = new System.Windows.Forms.AutoCompleteStringCollection();

            string sql = "";
            sql += "SELECT ";
            sql += "Ma_vat_tu ";
            sql += "FROM Ton_kho ";
            sql += "WHERE ID_kho=@ID_kho";

            SqlCommand command = new SqlCommand(sql, m_dbConnection);

            command.Parameters.Add("@ID_kho", SqlDbType.Int).Value = ID_kho;

            command.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
            m_dbConnection.Close();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dataCollection.Add(row[0].ToString());
            }

            return dataCollection;
        }

        /// <summary>
        /// lấy tất cả danh sách Tên vật tư
        /// </summary>
        public System.Windows.Forms.AutoCompleteStringCollection getListTenVatTu(int ID_kho)
        {
            m_dbConnection.Open();

            DataSet ds = new DataSet();
            System.Windows.Forms.AutoCompleteStringCollection dataCollection = new System.Windows.Forms.AutoCompleteStringCollection();

            string sql = "";
            sql += "SELECT ";
            sql += "DM_Vat_Tu.Ten_vat_tu ";
            sql += "FROM Ton_kho ";
            sql += "JOIN DM_Vat_Tu ";
            sql += "ON DM_Vat_Tu.Ma_vat_tu = Ton_kho.Ma_vat_tu ";
            sql += "WHERE Ton_kho.ID_kho=@ID_kho";

            SqlCommand command = new SqlCommand(sql, m_dbConnection);

            command.Parameters.Add("@ID_kho", SqlDbType.Int).Value = ID_kho;

            command.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
            m_dbConnection.Close();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dataCollection.Add(row[0].ToString());
            }

            return dataCollection;
        }

        /// <summary>
        /// lấy tất cả thông tin vật tư
        /// </summary>
        /// <returns></returns>
        public DataTable getAll_Ma_Ten_VatTu(int ID_kho)
        {
            m_dbConnection.Open();

            DataTable dt = new DataTable();

            string sql = "";
            sql += "SELECT ";
            sql += "DM_Vat_Tu.ID_Vat_tu, Ton_kho.Ma_vat_tu, DM_Vat_Tu.Ten_vat_tu ";
            sql += "FROM Ton_kho ";
            sql += "JOIN DM_Vat_Tu ";
            sql += "ON DM_Vat_Tu.Ma_vat_tu = Ton_kho.Ma_vat_tu ";
            sql += "WHERE Ton_kho.ID_kho=@ID_kho";

            SqlCommand command = new SqlCommand(sql, m_dbConnection);

            command.Parameters.Add("@ID_kho", SqlDbType.Int).Value = ID_kho;

            command.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

            return dt;
        }

        public Double getSL(string Ma_vat_tu, int ID_Kho, int Id_chat_luong)
        {

            m_dbConnection.Open();
            System.Data.DataTable dt = new DataTable();

            //Chuẩn bị
            string sql = "";
            sql += "SELECT So_luong FROM Ton_kho ";
            sql += "WHERE Ma_vat_tu=@Ma_vat_tu ";
            sql += "AND ID_Kho=@ID_Kho ";
            sql += "AND Id_chat_luong=@Id_chat_luong ";

            SqlCommand command = new SqlCommand(sql, m_dbConnection);

            command.Parameters.Add("@Ma_vat_tu", SqlDbType.VarChar, 50).Value = Ma_vat_tu;
            command.Parameters.Add("@ID_Kho", SqlDbType.Int).Value = ID_Kho;
            command.Parameters.Add("@Id_chat_luong", SqlDbType.Int).Value = Id_chat_luong;

            command.CommandType = CommandType.Text;

            //Run
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);

            //Đóng
            m_dbConnection.Close();
            if (dt.Rows.Count > 0)
                return Double.Parse(dt.Rows[0]["So_luong"].ToString());
            else
                return 0;
        }

        public string getSL_from_MaVatTu(string Ma_vat_tu, string ID_Kho)
        {
            return getAllVT(ID_kho, Ma_vat_tu).ToString();

            //m_dbConnection.Open();
            //System.Data.DataTable dt = new DataTable();

            ////Chuẩn bị
            //string sql = "";
            //sql += "SELECT So_luong FROM Ton_kho ";
            //sql += "WHERE Ma_vat_tu=@Ma_vat_tu ";
            //sql += "AND ID_Kho=@ID_Kho ";

            //SqlCommand command = new SqlCommand(sql, m_dbConnection);

            //command.Parameters.Add("@Ma_vat_tu", SqlDbType.VarChar, 50).Value = Ma_vat_tu;
            //command.Parameters.Add("@ID_Kho", SqlDbType.Int).Value = Int32.Parse(ID_Kho);

            //command.CommandType = CommandType.Text;

            ////Run
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //da.Fill(dt);

            ////Đóng
            //m_dbConnection.Close();

            //return dt.Rows[0]["So_luong"].ToString();
        }

        public static object getAll()
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = from d in help.ent.Ton_kho
                         join e in help.ent.DM_Vat_Tu on d.Ma_vat_tu equals e.Ma_vat_tu
                         select new
                         {
                             d.ID_ton_kho,
                             d.ID_kho,
                             d.Ma_vat_tu,
                             e.Ten_vat_tu,
                             d.So_luong,
                         };
                dbcxtransaction.Commit();
                return (object)dm.ToList();
            }



        }


        /// <summary>
        /// hàm này kiểm tra xem vật tư có tồn tại trong bản chưa
        /// 
        /// </summary>
        /// <param name="idkho"></param>
        /// <param name="mavattu"></param>
        /// <returns></returns>
        public bool checkKho_VatTu(int idkho,string mavattu)
        { 
             DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var entryPoint = (from d in help.ent.Ton_kho
                    
                         where d.ID_kho == idkho && d.Ma_vat_tu ==mavattu select d).ToList();
                if(entryPoint.Count ==0)
                    return false;
                return true;
            }
        }

        /// <summary>
        /// ham nay lay danh sach cac vat tu trong kho co ma kho va ma vat tu can tim de + them vat tu vao kho
        /// </summary>
        /// <param name="_ID_kho"></param>
        /// <param name="mavattu"></param>
        /// <returns></returns>
        public static double? getAllVT(int _ID_kho, string mavattu)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var entryPoint = (from d in help.ent.Ton_kho
                         join e in help.ent.DM_Vat_Tu on d.Ma_vat_tu equals e.Ma_vat_tu
                         where d.ID_kho == _ID_kho && d.So_luong > 0 && d.Ma_vat_tu == mavattu
                         select new
                         {
                             d.ID_ton_kho,
                             d.ID_kho,
                             d.Ma_vat_tu,
                             e.Ten_vat_tu,
                             d.So_luong,
                         }).ToList();
                dbcxtransaction.Commit();

             foreach (var record in entryPoint)
                    {
                        double? soluong = record.So_luong;
                        return soluong;
                    }
            };
            return 0;
        }
        /// <summary>
        /// hàm tìm kiếm vật tư theo kho và chất lượng
        /// </summary>
        /// <param name="_ID_kho"></param>
        /// <returns></returns>
        public static DataTable getAll(string TenKho, string TenChatLuong,string tenvt, string mavt)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Ton_kho
                          join e in help.ent.DM_Vat_Tu on d.Ma_vat_tu equals e.Ma_vat_tu
                          join f in help.ent.DM_Kho on d.ID_kho equals f.ID_kho
                          join gl in help.ent.Chat_luong on d.Id_chat_luong equals gl.Id_chat_luong


                          where gl.Loai_chat_luong.Contains(TenChatLuong) && f.Ten_kho.Contains(TenKho)&& e.Ten_vat_tu .Contains(tenvt)
                          && e.Ma_vat_tu.Contains(mavt) 
                          group d by new { d.Ma_vat_tu, e.Ten_vat_tu } into gs
                          let TotalPoints = gs.Sum(m => m.So_luong)
                          orderby TotalPoints descending

                          select new
                          {

                              Ma_vat_tu = gs.Key.Ma_vat_tu,
                              ten_vat_tu = gs.Key.Ten_vat_tu,
                              so_luong = TotalPoints
                          }).ToList();
                dbcxtransaction.Commit();
                return Utilities.clsThamSoUtilities.ToDataTable(dm);
            }
        }
        public static object getAll(int _ID_kho)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = from d in help.ent.Ton_kho
                         join e in help.ent.DM_Vat_Tu on d.Ma_vat_tu equals e.Ma_vat_tu
                         where d.ID_kho ==_ID_kho&& d.So_luong>0
                         select new
                         {
                             d.ID_ton_kho,
                             d.ID_kho,
                             d.Ma_vat_tu,
                             e.Ten_vat_tu,
                             d.So_luong,
                         };
                dbcxtransaction.Commit();
                return (object)dm.ToList();
            }
        }

        //public bool CheckTonTaiSoDK(int idkho, string maVT)
        //{
        ////    DatabaseHelper help = new DatabaseHelper();
        ////    help.ConnectDatabase();
        ////    var temp = help.ent.Ton_kho.Where(
        ////i => i.Ma_vat_tu == maVT

        ////).ToList();
        ////    string name = "";
        ////    temp.ToList().ForEach((n) =>
        ////    {
        ////        name = n.Ten_vat_tu;

        ////    });
        ////    return name;


        //}
        public int Insert()
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            // insert
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                try
                {
                    var t = new Ton_kho //Make sure you have a table called test in DB
                    {
                        ID_kho = this.ID_kho,
                        Ma_vat_tu = this.Ma_vat_tu,                   // ID = Guid.NewGuid(),
                        So_luong = this.So_luong,

                    };

                    help.ent.Ton_kho.Add(t);
                    help.ent.SaveChanges();
                    dbcxtransaction.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    dbcxtransaction.Rollback();
                    return 0;

                }
            }

            //DatabaseHelper help = new DatabaseHelper();
            //help.ConnectDatabase();
            //// insert
            //try
            //{
            //    var t = new DM_Kho //Make sure you have a table called test in DB
            //    {
            //        ID_kho = this.ID_kho,
            //        Ten_kho = this.Ten_kho,                   // ID = Guid.NewGuid(),
            //    };

            //    help.ent.DM_Kho.Add(t);
            //    help.ent.SaveChanges();
            //    return 1;
            //}
            //catch (Exception ex)
            //{
            //    return 0;

            //}


        }

        public int Update(Ton_kho kho)
        {


            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            int temp = 0;
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                using (var context = help.ent)
                {
                    context.Ton_kho.Attach(kho);
                    context.Entry(kho).State = EntityState.Modified;
                    temp = help.ent.SaveChanges();
                    dbcxtransaction.Commit();

                }


            }
            return temp;

        }

        public int Delete(Ton_kho dm)
        {
            DatabaseHelper help = new DatabaseHelper(); help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                help.ent.Ton_kho.Attach(dm);
                help.ent.Ton_kho.Remove(dm);
                int temp = help.ent.SaveChanges();
                dbcxtransaction.Commit();
                return temp;
            }
        }
    }
}
