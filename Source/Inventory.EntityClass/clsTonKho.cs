﻿using Inventory.Models;
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
        public int So_luong;

        SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);
        public string getSL_from_MaVatTu(string Ma_vat_tu, string ID_Kho)
        {
            m_dbConnection.Open();
            System.Data.DataTable dt = new DataTable();

            //Chuẩn bị
            string sql = "";
            sql += "SELECT So_luong FROM Ton_kho ";
            sql += "WHERE Ma_vat_tu=@Ma_vat_tu ";
            sql += "AND ID_Kho=@ID_Kho ";

            SqlCommand command = new SqlCommand(sql, m_dbConnection);

            command.Parameters.Add("@Ma_vat_tu", SqlDbType.VarChar, 50).Value = Ma_vat_tu;
            command.Parameters.Add("@ID_Kho", SqlDbType.Int).Value = Int32.Parse(ID_Kho);

            command.CommandType = CommandType.Text;

            //Run
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);

            //Đóng
            m_dbConnection.Close();

            return dt.Rows[0]["So_luong"].ToString();
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
        public static int? getAllVT(int _ID_kho, string mavattu)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var entryPoint = (from d in help.ent.Ton_kho
                         join e in help.ent.DM_Vat_Tu on d.Ma_vat_tu equals e.Ma_vat_tu
                         where d.ID_kho == _ID_kho && d.So_luong > 0 && d.Ma_vat_tu ==mavattu
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
                        int? soluong = record.So_luong;
                        return soluong;
                    }
            };
            return 0;

            

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