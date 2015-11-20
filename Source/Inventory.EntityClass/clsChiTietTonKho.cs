      using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
  public  class clsChiTietTonKho
    {
      public int ID_Chi_tiet_ton_kho;
      public int ID_Ton_kho;
      public string Ma_phieu;
      public int So_luong;
      public DateTime Ngay_thay_doi;
      public bool Tang_giam;

        //public static object getAll()
        //{

        //    DatabaseHelper help = new DatabaseHelper();
        //    help.ConnectDatabase();
        //    using (var dbcxtransaction = help.ent.Database.BeginTransaction())
        //    {
        //        var dm = from d in help.ent.Chi_Tiet_Ton_Kho
        //                 select new
        //                 {
        //                     d.ID_Chi_tiet_ton_kho,
        //                     d.ID_Ton_kho,
        //                     d.Ma_phieu,
        //                     d.So_luong,
        //                     d.Tang_Giam
        //                 };
        //        dbcxtransaction.Commit();
        //        return (object)dm.ToList();
        //    }



        //}

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
                    //var t = new Chi_Tiet_Ton_Kho //Make sure you have a table called test in DB
                    //{
                    //    ID_Ton_kho = this.ID_Ton_kho,
                    //    Ma_phieu = this.Ma_phieu,                   // ID = Guid.NewGuid(),
                    //    So_luong = this.So_luong,
                    //    Ngay_thay_doi = this.Ngay_thay_doi,
                    //    Tang_Giam = this.Tang_giam,
                        


                    //};

                    //help.ent.Chi_Tiet_Ton_Kho.Add(t);
                    //help.ent.SaveChanges();
                    //dbcxtransaction.Commit();
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

        //public int Update(Chi_Tiet_Ton_Kho kho)
        //{


        //    DatabaseHelper help = new DatabaseHelper();
        //    help.ConnectDatabase();
        //    int temp = 0;
        //    using (var dbcxtransaction = help.ent.Database.BeginTransaction())
        //    {
        //        using (var context = help.ent)
        //        {
        //            context.Chi_Tiet_Ton_Kho.Attach(kho);
        //            context.Entry(kho).State = EntityState.Modified;
        //            temp = help.ent.SaveChanges();
        //            dbcxtransaction.Commit();

        //        }


        //    }
        //    return temp;

        //}

        //public int Delete(Chi_Tiet_Ton_Kho dm)
        //{
        //    DatabaseHelper help = new DatabaseHelper(); help.ConnectDatabase();
        //    using (var dbcxtransaction = help.ent.Database.BeginTransaction())
        //    {


        //        help.ent.Chi_Tiet_Ton_Kho.Attach(dm);
        //        help.ent.Chi_Tiet_Ton_Kho.Remove(dm);
        //        int temp = help.ent.SaveChanges();
        //        dbcxtransaction.Commit();
        //        return temp;
        //    }

        //}

    }
}
