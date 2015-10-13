using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
   public class clsLoaiPhieuNhan
    {
       public int ID_Loai_phieu_nhan;
       public string Ma_loai_phieu_nhan;
       public string Ten_loai_phieu;
       public static object getAll()
       {

           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {
               var dm = from d in help.ent.Loai_Phieu_Nhap
                        select new
                        {
                            d.ID_Loai_Phieu_Nhap,
                            d.Ma_loai_phieu_nhap,
                        };
               dbcxtransaction.Commit();
               return (object)dm.ToList();
           }



       }

    }
}
