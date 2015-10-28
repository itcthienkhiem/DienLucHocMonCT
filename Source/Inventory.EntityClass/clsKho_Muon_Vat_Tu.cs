using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
  public  class clsKho_Muon_Vat_Tu
    {
      public static DataTable GetAll(string name)
      {
          DatabaseHelper help = new DatabaseHelper();
          help.ConnectDatabase();
          using (var dbcxtransaction = help.ent.Database.BeginTransaction())
          {
              var dm = (from d in help.ent.Kho_muon_vat_tu
                        join k in help.ent.DM_Kho on d.ID_Kho equals k.ID_kho
                        where k.Ten_kho .Contains(name)
           
                     
                        select d
                        ).ToList();
              dbcxtransaction.Commit();
              DataTable ds = Utilities.clsThamSoUtilities.ToDataTable(dm);
              return ds;
          }
      }
    }
}
