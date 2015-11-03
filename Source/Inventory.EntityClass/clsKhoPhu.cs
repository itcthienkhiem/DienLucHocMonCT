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
   public class clsKhoPhu
    {
       public int ID_kho_phu;
       public string So_chung_tu;
       public string Ly_do;
       public DateTime Ngay_nhap;
       public string Ten_phieu;
       public int ID_kho_chinh;
       public int Insert(DatabaseHelper help)
       {
           try
           {
               var t = new Kho_phu //Make sure you have a table called test in DB
               {
                   So_chung_tu = this.So_chung_tu,
                   Ly_do = this.Ly_do,                   // ID = Guid.NewGuid(),
                   Ngay_nhap = this.Ngay_nhap,
                   Ten_phieu = this.Ten_phieu,
                   ID_kho_chinh = this.ID_kho_chinh,
               };

               help.ent.Kho_phu.Add(t);
               help.ent.SaveChanges();
               ID_kho_phu = t.ID_kho_phu;
               return 1;
           }
           catch (Exception ex)
           {
               return 0;
           }
       }
       public  DataTable GetAllData()
       {
           DatabaseHelper help = new DatabaseHelper();
           //help.ent.Configuration.LazyLoadingEnabled = false;
           help.ConnectDatabase();
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {
               var dm = (from d in help.ent.Kho_phu
                         select new
                         {
                             d.ID_kho_phu,
                             d.So_chung_tu,
                             d.Ly_do,
                             d.Ngay_nhap,
                             d.ID_kho_chinh,
                         }).ToList();
               dbcxtransaction.Commit();

               return Utilities.clsThamSoUtilities.ToDataTable(dm);
           }
       }
       public bool CheckTonTaiSoDK()
       {
           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           bool has = help.ent.Kho_phu.Any(cus => cus.ID_kho_chinh == ID_kho_chinh && cus.ID_kho_phu == cus.ID_kho_phu);
           return has;

       }
       public int Update(Kho_phu kho)
       {


           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           int temp = 0;
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {
               using (var context = help.ent)
               {
                   context.Kho_phu.Attach(kho);
                   context.Entry(kho).State = EntityState.Modified;
                   temp = help.ent.SaveChanges();
                   dbcxtransaction.Commit();

               }


           }
           return temp;

       }
       public int Delete(Kho_phu dm)
       {
           DatabaseHelper help = new DatabaseHelper(); help.ConnectDatabase();
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {


               help.ent.Kho_phu.Attach(dm);
               help.ent.Kho_phu.Remove(dm);
               int temp = help.ent.SaveChanges();
               dbcxtransaction.Commit();
               return temp;
           }

       }

    }
}
