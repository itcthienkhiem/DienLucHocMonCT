using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
  public  class clsBu_Tru_No_Phieu: ObjecEntity
    {
      public override System.Data.DataTable GetAllData()
      {
          DatabaseHelper help = new DatabaseHelper();
          //help.ent.Configuration.LazyLoadingEnabled = false;
          help.ConnectDatabase();
          using (var dbcxtransaction = help.ent.Database.BeginTransaction())
          {
              var dm = (from d in help.ent.Phieu_Nhap_Kho
                        where d.isNhapNgoai ==true
                        select new
                        {
                            d.ID_phieu_nhap,
                            d.Ma_phieu_nhap
                        }).ToList();
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
              var dm = (from d in help.ent.Phieu_Nhap_Kho
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
  
    }
}
