using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
  public   class clsLoaiPhieuNhap :ObjecEntity
  {
      public int ID_LPN;
      public string Ma_LPN;
      public string Ten_LPN;

      public clsLoaiPhieuNhap() { }
      public override bool KiemTraTrungMa()
      {
          DatabaseHelper help = new DatabaseHelper();
          help.ConnectDatabase();
          bool has = help.ent.Loai_Phieu_Nhap.Any(cus => cus.Ma_loai_phieu_nhap == Ma_LPN);
          return has;
      }
      public override bool KiemTraTrungTen(string ten)
      {
          DatabaseHelper help = new DatabaseHelper();
          help.ConnectDatabase();
          bool has = help.ent.Loai_Phieu_Nhap.Any(cus => cus.Ten_loai_phieu_nhap == ten);
          return has;
      }
      public int GetFirst(DatabaseHelper help)
      { 
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
          {
              var dm = (from d in help.ent.Loai_Phieu_Nhap
                        select d).First();

              return dm.ID_Loai_Phieu_Nhap;
          }

      }
      
      public override System.Data.DataTable GetAllData()
      {
          DatabaseHelper help = new DatabaseHelper();
          help.ConnectDatabase();
          using (var dbcxtransaction = help.ent.Database.BeginTransaction())
          {
              var dm = (from d in help.ent.Loai_Phieu_Nhap
                        select d).ToList();
              dbcxtransaction.Commit();

              return Utilities.clsThamSoUtilities.ToDataTable(dm);
          }
      }
      public override System.Windows.Forms.AutoCompleteStringCollection getListToCombobox(string TenCot)
      {
          System.Windows.Forms.AutoCompleteStringCollection dataCollection = new System.Windows.Forms.AutoCompleteStringCollection();


          DatabaseHelper help = new DatabaseHelper();
          help.ConnectDatabase();
          using (var dbcxtransaction = help.ent.Database.BeginTransaction())
          {
              var dm = (from d in help.ent.Loai_Phieu_Nhap
                        select d).ToList();
              dbcxtransaction.Commit();
              DataTable ds = Utilities.clsThamSoUtilities.ToDataTable(dm);
              foreach (DataRow row in ds.Rows)
              {
                  dataCollection.Add(row[TenCot].ToString());
              }
          }
          return dataCollection;
      }
      //public static object getAll()
      //{

      //    DatabaseHelper help = new DatabaseHelper();
      //    help.ConnectDatabase();
      //    using (var dbcxtransaction = help.ent.Database.BeginTransaction())
      //    {
      //        var dm = from d in help.ent.Loai_Phieu_Nhap
      //                 select new
      //                 {
      //                     d.ID_Loai_Phieu_Nhap,
      //                     d.Ma_loai_phieu_nhap,
      //                     d.Ten_loai_phieu_nhap,
      //                 };
      //        dbcxtransaction.Commit();
      //        return (object)dm.ToList();
      //    }



      //}

      //public bool CheckTonTaiSoDK()
      //{
      //    DatabaseHelper help = new DatabaseHelper();
      //    help.ConnectDatabase();
      //    bool has = help.ent.Loai_Phieu_Nhap.Any(cus => cus.Ma_loai_phieu_nhap== Ma_LPN);
      //    return has;

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
                  var t = new Loai_Phieu_Nhap //Make sure you have a table called test in DB
                  {
                      Ma_loai_phieu_nhap = this.Ma_LPN,
                      Ten_loai_phieu_nhap= this.Ten_LPN,                   // ID = Guid.NewGuid(),
                  };

                  help.ent.Loai_Phieu_Nhap.Add(t);
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
          //    var t = new Loai_Phieu_Nhap //Make sure you have a table called test in DB
          //    {
          //        ID_kho = this.ID_kho,
          //        Ten_kho = this.Ten_kho,                   // ID = Guid.NewGuid(),
          //    };

          //    help.ent.Loai_Phieu_Nhap.Add(t);
          //    help.ent.SaveChanges();
          //    return 1;
          //}
          //catch (Exception ex)
          //{
          //    return 0;

          //}


      }

      public int Update(Loai_Phieu_Nhap kho)
      {


          DatabaseHelper help = new DatabaseHelper();
          help.ConnectDatabase();
          int temp = 0;
          using (var dbcxtransaction = help.ent.Database.BeginTransaction())
          {
              using (var context = help.ent)
              {
                  context.Loai_Phieu_Nhap.Attach(kho);
                  context.Entry(kho).State = EntityState.Modified;
                  temp = help.ent.SaveChanges();
                  dbcxtransaction.Commit();

              }


          }
          return temp;

      }

      public int Delete(Loai_Phieu_Nhap dm)
      {
          DatabaseHelper help = new DatabaseHelper(); help.ConnectDatabase();
          using (var dbcxtransaction = help.ent.Database.BeginTransaction())
          {


              help.ent.Loai_Phieu_Nhap.Attach(dm);
              help.ent.Loai_Phieu_Nhap.Remove(dm);
              int temp = help.ent.SaveChanges();
              dbcxtransaction.Commit();
              return temp;
          }

      }



  }
}
