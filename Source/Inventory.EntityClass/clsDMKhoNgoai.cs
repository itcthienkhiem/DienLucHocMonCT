using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
   public  class clsDMKhoNgoai: ObjecEntity
    {
           public int ID_kho;
        public string Ten_kho;
      
     

        public override System.Windows.Forms.AutoCompleteStringCollection getListToCombobox(string TenCot)
        {
            System.Windows.Forms.AutoCompleteStringCollection dataCollection = new System.Windows.Forms.AutoCompleteStringCollection();

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Dm_Kho_Muon_Ngoai
                          select d).ToList();
                dbcxtransaction.Commit();
                DataTable ds = Utilities.clsThamSoUtilities.ToDataTable(dm);
                foreach (DataRow row in ds.Rows)
                {
                    dataCollection.Add(row[TenCot].ToString());
                }
            }
            return dataCollection;
        }
        public string get_TenKho(int idkho)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Dm_Kho_Muon_Ngoai
                          where d.ID == idkho
                          select new
                          {
                              d.ID,
                              d.Ten_kho_muon
                          }).First();
                dbcxtransaction.Commit();
                return dm.Ten_kho_muon;
            }
        }

        public DataTable getAll_TenKho()
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Dm_Kho_Muon_Ngoai
                          select new
                          {
                              d.ID,
                              d.Ten_kho_muon
                          }).ToList();
                dbcxtransaction.Commit();
                DataTable ds = Utilities.clsThamSoUtilities.ToDataTable(dm);
                return ds;
            }

        }

        public override DataTable GetAllData()
        {
            DatabaseHelper help = new DatabaseHelper();
            //help.ent.Configuration.LazyLoadingEnabled = false;
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Dm_Kho_Muon_Ngoai
                          select new
                          {
                              d.ID,
                              d.Ten_kho_muon
                          }).ToList();
                dbcxtransaction.Commit();

                return Utilities.clsThamSoUtilities.ToDataTable(dm);
            }
        }

      

        public bool CheckTonTaiSoDK()
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            bool has = help.ent.Dm_Kho_Muon_Ngoai.Any(cus => cus.Ten_kho_muon == Ten_kho);
            return has;

        }
        public int Insert()
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            // insert
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                try
                {
                    var t = new Dm_Kho_Muon_Ngoai //Make sure you have a table called test in DB
                    {
                       // ID = this.ID_kho,
                        Ten_kho_muon = this.Ten_kho,                   // ID = Guid.NewGuid(),
                    };

                    help.ent.Dm_Kho_Muon_Ngoai.Add(t);
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

            //DatabaseHelper help = new DatabaseHelper();
            //help.ConnectDatabase();
            //// insert
            //try
            //{
            //    var t = new DM_Kho //Make sure you have a table called test in DB
            //    {
            //        ID_kho = this.ID_kho,
            //        Ten_kho = this.Ten_kho,                   // ID = Guid.NewGuid(),
            //    };

            //    help.ent.DM_Kho.Add(t);
            //    help.ent.SaveChanges();
            //    return 1;
            //}
            //catch (Exception ex)
            //{
            //    return 0;

            //}


        }

        public int Update(Dm_Kho_Muon_Ngoai kho)
        {


            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            int temp = 0;
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                using (var context = help.ent)
                {
                    context.Dm_Kho_Muon_Ngoai.Attach(kho);
                    context.Entry(kho).State = EntityState.Modified;
                    temp = help.ent.SaveChanges();
                    dbcxtransaction.Commit();

                }


            }
            return temp;

        }

        public int Delete(Dm_Kho_Muon_Ngoai dm)
        {
            DatabaseHelper help = new DatabaseHelper(); help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {


                help.ent.Dm_Kho_Muon_Ngoai.Attach(dm);
                help.ent.Dm_Kho_Muon_Ngoai.Remove(dm);
                int temp = help.ent.SaveChanges();
                dbcxtransaction.Commit();
                return temp;
            }

        }
    }
}
