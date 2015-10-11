using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.Models
{
  public  class frm_DM_Kho
    {
      public static object getAll()
      {


          var dm = from d in Entities.ent.DM_Kho
                   select new
                   {
                       d.ID_kho,
                       d.Ten_kho
                   };
          return dm.ToList();
      }
    }
}
