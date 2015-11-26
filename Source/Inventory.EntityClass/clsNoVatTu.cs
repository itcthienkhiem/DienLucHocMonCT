using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
  public   class clsNoVatTu
    {
      public bool CheckTonTaiSoDK(string maphieu ,string mavattu, int cl)
      {
          DatabaseHelper help = new DatabaseHelper();
          help.ConnectDatabase();
          bool has = help.ent.No_vat_tu.Any(cus => cus.Ma_phieu_xuat_tam == maphieu &&cus.Ma_vat_tu == mavattu && cus.Id_chat_luong == cl);
          return has;

      }
    }
}
