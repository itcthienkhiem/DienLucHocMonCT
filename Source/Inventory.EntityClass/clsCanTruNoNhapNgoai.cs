using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Inventory.Models;
using System.Data;

namespace Inventory.EntityClass
{
   public class clsCanTruNoNhapNgoai
    {
       public string Ma_phieu_nhap;
       public string Ma_phieu_nhap_no;
       public string Ma_vat_tu;
       public int Id_chat_luong;
       public decimal So_luong_can_tru;

       public int ID;
       public static DataTable GetAll()
       {
           DatabaseHelper help = new DatabaseHelper();
           //help.ent.Configuration.LazyLoadingEnabled = false;
           help.ConnectDatabase();
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {
               var dm = (from d in help.ent.Can_tru_no_nhap_ngoai
                         select d).ToList();
               dbcxtransaction.Commit();

               return Utilities.clsThamSoUtilities.ToDataTable(dm);

           }
       }

       public int CheckTonTaiSoDK()
       {



           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();

           var dm = (from d in help.ent.Can_tru_no_nhap_ngoai
                     where d.Ma_phieu_nhap == Ma_phieu_nhap&&
                     d.Ma_phieu_nhap_no == Ma_phieu_nhap_no &&
                     d.Ma_vat_tu == Ma_vat_tu
                     select new
                     {
                         d.ID,
                     }).SingleOrDefault();

           if (dm == null)
               return -1;
                     return dm.ID;

       }
       public int Insert(DatabaseHelper help)
       {
             
          
           {
               try
               {
                   var t = new Can_tru_no_nhap_ngoai //Make sure you have a table called test in DB
                   {
                       Id_chat_luong = this.Id_chat_luong,
                       Ma_vat_tu = this.Ma_vat_tu,                   // ID = Guid.NewGuid(),
                       So_luong_can_tru = this.So_luong_can_tru,
                       Ma_phieu_nhap = this.Ma_phieu_nhap,
                       Ma_phieu_nhap_no = this.Ma_phieu_nhap_no,
                   };

                   help.ent.Can_tru_no_nhap_ngoai.Add(t);
                   help.ent.SaveChanges();
                   //dbcxtransaction.Commit();
                   return 1;
               }
               catch (Exception ex)
               {
                   //dbcxtransaction.Rollback();
                   return 0;

               }
           }
       }

       public int Update(DatabaseHelper help)
       {
           var t = new Can_tru_no_nhap_ngoai //Make sure you have a table called test in DB
           {
               ID = this.ID,
               Id_chat_luong = this.Id_chat_luong,
               Ma_vat_tu = this.Ma_vat_tu,                   // ID = Guid.NewGuid(),
               So_luong_can_tru = this.So_luong_can_tru,
               Ma_phieu_nhap = this.Ma_phieu_nhap,
               Ma_phieu_nhap_no = this.Ma_phieu_nhap_no,
           };

           int temp = 0;
         
           {
               using (var context = help.ent)
               {
                   context.Can_tru_no_nhap_ngoai.Attach(t);
                   context.Entry(t).State = EntityState.Modified;
                   temp = help.ent.SaveChanges();
        
               }


           }
           return temp;

       }

       public int Update()
       {
           var t = new Can_tru_no_nhap_ngoai //Make sure you have a table called test in DB
           {
               ID = this.ID,
               Id_chat_luong = this.Id_chat_luong,
               Ma_vat_tu = this.Ma_vat_tu,                   // ID = Guid.NewGuid(),
               So_luong_can_tru = this.So_luong_can_tru,
               Ma_phieu_nhap = this.Ma_phieu_nhap,
               Ma_phieu_nhap_no = this.Ma_phieu_nhap_no,
           };

           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           int temp = 0;
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {
               using (var context = help.ent)
               {
                   context.Can_tru_no_nhap_ngoai.Attach(t);
                   context.Entry(t).State = EntityState.Modified;
                   temp = help.ent.SaveChanges();
                   dbcxtransaction.Commit();

               }


           }
           return temp;

       }

    }
}
