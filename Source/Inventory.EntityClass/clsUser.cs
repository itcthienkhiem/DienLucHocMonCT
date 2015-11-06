using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Inventory.Models;

namespace Inventory.EntityClass
{
    public class clsUser
    {
        public int ID_Users;
        public string User_name;
        public string Password;


        public bool checkPasswd(string userName, string Passwd)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Users
                          where d.User_name.Equals(userName) && d.Password.Equals(Passwd)
                          select d).FirstOrDefault();
                dbcxtransaction.Commit();
                if (dm == null)
                    return false;
                return true;
            }
        }
        public DataTable GetAllData()
        {
            DatabaseHelper help = new DatabaseHelper();
            //help.ent.Configuration.LazyLoadingEnabled = false;
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Users
                          select new
                          {
                              d.ID_users,
                              d.User_name,
                              d.Password,
                          }).ToList();
                dbcxtransaction.Commit();

                return Utilities.clsThamSoUtilities.ToDataTable(dm);
            }
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
                    var t = new User //Make sure you have a table called test in DB
                    {
                        User_name = this.User_name,
                        Password = this.Password,                   // ID = Guid.NewGuid(),
                    };

                    help.ent.Users.Add(t);
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
    }
}

