using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
    public class clsTheKho
    {
        public string Ma_vat_tu;


        public static DataTable GetAll(string mavattu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.The_kho
                          where d.Ma_vat_tu == mavattu
                          select d).ToList();
                dbcxtransaction.Commit();
                DataTable ds = Utilities.clsThamSoUtilities.ToDataTable(dm);
                return ds;
            }

        }


    }
}
