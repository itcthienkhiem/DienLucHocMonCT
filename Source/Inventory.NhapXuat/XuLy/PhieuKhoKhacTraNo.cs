using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.NhapXuat.XuLy
{
  public   class PhieuKhoKhacTraNo:PhieuBase 
    {
      public override int Insert(int id)
      {
          PhieuNhap pn = new PhieuNhap();
          return pn.Insert(id);
        
      }
      public override int BoDuyet(int id)
      {
          PhieuNhap pn = new PhieuNhap();
          return pn.BoDuyet(id);
       
      }
    }
}
