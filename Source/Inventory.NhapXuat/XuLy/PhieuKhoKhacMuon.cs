using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.NhapXuat.XuLy
{
  public   class PhieuKhoKhacMuon: PhieuBase

    {
      public override int Insert(int id)
      {
          DiTraNo phieumuon = new DiTraNo();
         return  phieumuon.Insert(id);
      }
      public override int BoDuyet(int id)
      {
          DiTraNo phieumuon = new DiTraNo();
          return phieumuon.BoDuyet(id);
      }
    }
}
