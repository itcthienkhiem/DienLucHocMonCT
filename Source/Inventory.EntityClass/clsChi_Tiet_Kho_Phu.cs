using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
   public class clsChi_Tiet_Kho_Phu
    {
       public int ID_chi_tiet_kho_phu;
       public int ID_kho_phu;
       public string Ma_vat_tu;
       public decimal So_luong;
       public decimal Don_gia;
       public decimal Thanh_tien;
       public int ID_don_vi_tinh;
       public int ID_chat_luong;

       public int Insert(DatabaseHelper help)
       {
           try
           {
               var t = new Chi_Tiet_Kho_Phu //Make sure you have a table called test in DB
               {
                   ID_kho_phu = this.ID_kho_phu,
                   Ma_vat_tu = this.Ma_vat_tu,                   // ID = Guid.NewGuid(),
                   So_luong = this.So_luong,
                   ID_chat_luong = this.ID_chat_luong,
                   Don_gia = this.Don_gia,
                   Thanh_tien = this.Thanh_tien,
                   ID_don_vi_tinh = this.ID_don_vi_tinh,
               };

               help.ent.Chi_Tiet_Kho_Phu.Add(t);
               help.ent.SaveChanges();
               return 1;
           }
           catch (Exception ex)
           {
               return 0;
           }
       }
       public DataTable GetAllData()
       {
           DatabaseHelper help = new DatabaseHelper();
           //help.ent.Configuration.LazyLoadingEnabled = false;
           help.ConnectDatabase();
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {
               var dm = (from d in help.ent.Chi_Tiet_Kho_Phu
                         select new
                         {
                             d.ID_chi_tiet_kho_phu,
                             d.ID_kho_phu,
                             d.Ma_vat_tu,
                             d.So_luong,
                             d.ID_chat_luong,
                             d.Thanh_tien,
                             d.Don_gia,
                             d.ID_don_vi_tinh,
                         }).ToList();
               dbcxtransaction.Commit();

               return Utilities.clsThamSoUtilities.ToDataTable(dm);
           }
       }
       public bool CheckTonTaiSoDK()
       {
           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           bool has = help.ent.Chi_Tiet_Kho_Phu.Any(cus => cus.ID_kho_phu == ID_kho_phu && cus.ID_chi_tiet_kho_phu == ID_chi_tiet_kho_phu && cus.Ma_vat_tu == Ma_vat_tu && cus.ID_chat_luong == ID_chat_luong);
           return has;

       }
       public int Update(Chi_Tiet_Kho_Phu kho)
       {


           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           int temp = 0;
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {
               using (var context = help.ent)
               {
                   context.Chi_Tiet_Kho_Phu.Attach(kho);
                   context.Entry(kho).State = EntityState.Modified;
                   temp = help.ent.SaveChanges();
                   dbcxtransaction.Commit();

               }


           }
           return temp;

       }
       public int Delete(Chi_Tiet_Kho_Phu dm)
       {
           DatabaseHelper help = new DatabaseHelper(); help.ConnectDatabase();
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {


               help.ent.Chi_Tiet_Kho_Phu.Attach(dm);
               help.ent.Chi_Tiet_Kho_Phu.Remove(dm);
               int temp = help.ent.SaveChanges();
               dbcxtransaction.Commit();
               return temp;
           }

       }

       public int Delete(DatabaseHelper help,int id)
       {
          
           {
               var recordsToDelete = (from c in help.ent.Chi_Tiet_Kho_Phu where c.ID_kho_phu == id select c).ToList<Chi_Tiet_Kho_Phu>();
               if (recordsToDelete.Count > 0)
               {
                   foreach (var record in recordsToDelete)
                   {
                       help.ent.Chi_Tiet_Kho_Phu.Attach(record);
                       help.ent.Chi_Tiet_Kho_Phu.Remove(record);
                   }
               }
               help.ent.SaveChanges();
         
           }

           return 1;

       }
    }
}
