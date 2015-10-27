using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
    public class clsVatTuGoiDauKy
    {
        public int ID_VT_Goi_Dau;
        public string Ma_vat_tu;
        public double So_Luong;
        public int ID_ky;
        public int ID_chat_luong;
        public int ID_kho; 

        public int Insert()
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            // insert
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                try
                {
                    var t = new Vat_Tu_Goi_Dau_Ky //Make sure you have a table called test in DB
                    {
                        ID_VT_Goi_Dau = this.ID_VT_Goi_Dau,
                        Ma_vat_tu = this.Ma_vat_tu,                   // ID = Guid.NewGuid(),
                        So_Luong = this.So_Luong,
                        ID_ky = this.ID_ky,
                        ID_chat_luong = this.ID_chat_luong,
                        ID_kho = this.ID_kho,
                    };

                    help.ent.Vat_Tu_Goi_Dau_Ky.Add(t);
                    help.ent.SaveChanges();
                    dbcxtransaction.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    dbcxtransaction.Rollback();
                    return 0;

                }
            }
        }
        
        public bool CheckTonTaiSoDK()
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            bool has = help.ent.Vat_Tu_Goi_Dau_Ky.Any(cus => cus.Ma_vat_tu == Ma_vat_tu && cus.ID_chat_luong ==ID_chat_luong && cus.ID_kho == ID_kho);
            return has;

        }
    }
}
    
