using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Inventory.EntityClass;

namespace Inventory.BusinessClass
{
   public class clsBusKhoPhu
    {
       public int Insert(clsKhoPhu kp , clsChi_Tiet_Kho_Phu ctkp)
       { 
         DatabaseHelper help = new DatabaseHelper();
             help.ConnectDatabase();
             // xem số lượng vật tư trong kho có còn hay hok ?
             //nếu còn thì thực hiện trả nợ 

             using (var dbcxtransaction = help.ent.Database.BeginTransaction())
             {
                 if (kp.Insert(help) == 1 && ctkp.Insert(help) == 1)
                 {
                     dbcxtransaction.Commit();
                     return 1;
                 }
                 else
                 {
                     dbcxtransaction.Rollback();
                 }
             }
             return 0;
       }
    }
}
