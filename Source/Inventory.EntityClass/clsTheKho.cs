using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
    public class clsTheKho
    {
        public string Ma_vat_tu;
        public string Don_vi;
        public string Dia_diem;
        public int ID_chat_luong;


        public static DataTable GetAll(string mavattu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.The_kho
                          where d.Ma_vat_tu == mavattu
                          select d).ToList();
                dbcxtransaction.Commit();
                DataTable ds = Utilities.clsThamSoUtilities.ToDataTable(dm);
                return ds;
            }

        }
        public int Insert(DatabaseHelper help)
        {

            // insert

            {
                try
                {
                    var t = new The_kho //Make sure you have a table called test in DB
                    {

                        Ma_vat_tu = this.Ma_vat_tu,                   // ID = Guid.NewGuid(),
                        ID_Chat_luong = this.ID_chat_luong,
                        Don_vi = this.Don_vi,
                        Dia_diem = this.Dia_diem,

                    };

                    help.ent.The_kho.Add(t);
                    help.ent.SaveChanges();
                    return 1;
                }
                catch (Exception ex)
                {

                    return 0;

                }

            }



        }

        public int Update(DatabaseHelper help)
        {



            int temp = 0;
            var t = new The_kho
             {
                 Ma_vat_tu = this.Ma_vat_tu,                   // ID = Guid.NewGuid(),
                 ID_Chat_luong = this.ID_chat_luong,
                 Don_vi = this.Don_vi,
                 Dia_diem = this.Dia_diem,
             };
            try
            {
                using (var context = help.ent)
                {
                    context.The_kho.Attach(t);
                    context.Entry(t).State = EntityState.Modified;
                    temp = help.ent.SaveChanges();


                }

             
            }
            catch (Exception ex)
            {
               
            }

            return temp;
        }
        public int Search(int ID_chat_luong, string mavattu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            var dm = (from d in help.ent.The_kho
                      where d.ID_Chat_luong == ID_chat_luong && d.Ma_vat_tu == mavattu
                      select new {
                        d.ID_Chat_luong,
                      }).ToList();
            if (dm.Count == 0)
                return -1;
            return (int)dm[0].ID_Chat_luong;
           
        }
        public int Delete(DatabaseHelper help)
        {
            var t = new The_kho //Make sure you have a table called test in DB
            {

                Ma_vat_tu = this.Ma_vat_tu,                   // ID = Guid.NewGuid(),
                ID_Chat_luong = this.ID_chat_luong,
                Don_vi = this.Don_vi,
                Dia_diem = this.Dia_diem,

            };
            help.ent.The_kho.Attach(t);
            help.ent.The_kho.Remove(t);
            return help.ent.SaveChanges();

        }

    }
}
