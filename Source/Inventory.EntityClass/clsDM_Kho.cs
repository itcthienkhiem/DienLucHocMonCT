using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Inventory.Utilities;
using Inventory.Models;
using System.Linq;
using System.Data.Entity;
namespace Inventory.EntityClass
{
   public class clsDM_Kho
    {
        public int? ID_kho;
        public string Ten_kho;
       public clsDM_Kho()
       { 
       
       }

       SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);

       public static object getAll()
       {
          
           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           using (var dbcxtransaction =help.ent.Database.BeginTransaction())
           {
               var dm = from d in help.ent.DM_Kho
                        select new
                        {
                            d.ID_kho,
                            d.Ten_kho
                        };
               dbcxtransaction.Commit();
               return (object)dm.ToList();
           }
              
          

       }

       public bool CheckTonTaiSoDK()
       {
           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           bool has = help.ent.DM_Kho.Any(cus => cus.Ten_kho == Ten_kho);
           return has;

       }
       public int Insert()
       {

           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           // insert
           try
           {
               var t = new DM_Kho //Make sure you have a table called test in DB
               {
                   ID_kho = this.ID_kho,
                   Ten_kho = this.Ten_kho,                   // ID = Guid.NewGuid(),
               };

               help.ent.DM_Kho.Add(t);
               help.ent.SaveChanges();
               return 1;
           }
           catch (Exception ex)
           {
               return 0;

           }
           

       }

       public int Update(DM_Kho kho)
       {
         

           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           int temp = 0;
           using (var dbcxtransaction = help.ent.Database.BeginTransaction())
           {
               using (var context = help.ent)
               {
                   context.DM_Kho.Attach(kho);
                   context.Entry(kho).State = EntityState.Modified;
                   temp = help.ent.SaveChanges();
                   dbcxtransaction.Commit();
                  
               }

              
           }
           return temp;
       
       }

       public int Delete(DM_Kho dm)
       {
           DatabaseHelper help = new DatabaseHelper();
           help.ConnectDatabase();
           help.ent.DM_Kho.Attach(dm);
           help.ent.DM_Kho.Remove(dm);
          return help.ent.SaveChanges();

       }


     
    }
}
