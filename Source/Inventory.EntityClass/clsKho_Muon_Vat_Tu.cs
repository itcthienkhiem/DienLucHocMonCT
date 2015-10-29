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
                        join c in help.ent.Chat_luong on d.Id_chat_luong equals c.Id_chat_luong
                        join v in help.ent.DM_Vat_Tu on d.Ma_vat_tu equals v.Ma_vat_tu 

                        where k.Ten_kho .Contains(name) &&d.Da_tra == false
                         


                        select new {
                        ID_kho_muon_vat_tu = d.ID_kho_muon_vat_tu,
                        ID_kho = d.ID_Kho,
                        ID_Kho_Muon  = d.ID_Kho_muon,
                        Ma_vat_tu = d.Ma_vat_tu,
                        Ten_vat_tu = v.Ten_vat_tu,
                        So_luong = d.So_luong,
                        Ma_phieu_xuat_tam = d.Ma_phieu_xuat_tam,
                        ID_chat_luong = d.Id_chat_luong,
                        Ten_chat_luong = c.Loai_chat_luong,
                       // Ten_kho  = k.Ten_kho,

                            
                        }
                        ).ToList();
              dbcxtransaction.Commit();
              DataTable ds = Utilities.clsThamSoUtilities.ToDataTable(dm);
              return ds;
          }
      }
    }
}
