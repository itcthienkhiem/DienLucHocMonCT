using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
    public class clsChiTietTheKho
    {
        /// <summary>
        /// hàm này lấy danh sách các thẻ kho có id bằng id thẻ kho và có ngày nhập từ ngày đến ngày 
        /// </summary>
        /// <param name="id_thekho"></param>
        /// <returns></returns>
        public DataTable GetAll(int id_thekho)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Chi_tiet_the_kho
                          where d.ID_The_Kho == id_thekho
                          select d).ToList();
                dbcxtransaction.Commit();
                return Utilities.clsThamSoUtilities.ToDataTable(dm);
            }
        }
    }
}
