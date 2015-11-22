using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.NhapXuat.XuLy
{
  public   class DiMuonNo : PhieuBase
    {
        public override int Insert(int id)
        {
            KhoNgoai pn = new KhoNgoai();
            return pn.Insert(id);
        }
        public override int BoDuyet(int id)
        {
            KhoNgoai pn = new KhoNgoai();
            return pn.BoDuyet(id);

        }
    }
}
