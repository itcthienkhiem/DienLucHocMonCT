using System;
using System.Collections.Generic;
using System.Text;

namespace coInventory.Mini.EntityClass
{
   public  class clsThamSoHeThong: clsDM_XuLy
    {
       public override System.Data.DataTable GetAll()
       {
           this.sql = "select * from thamsonguoidung where mathamso = 'FILEPATH'";
           return base.GetAll();
       }
    }
}
