using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventory.Utilities;
namespace Inventory.Models
{
    public  class DatabaseHelper
    {
        //public static DateTime GetDatabaseDate()
        //{
        //    //Entities db = new Entities();
        //    //return db.Database.SqlQuery<DateTime>("SELECT GetDate()").First();
        //}

        public static List<T> ExcuteSql<T>(string sql, Dictionary<string, object> filters)
        {
            QLKhoDienLucEntities db = new QLKhoDienLucEntities();
            List<T> list = new List<T>();
           // Entities db = new Entities();
            sql += " where ";

            foreach (var item in filters)
            {
                sql += item.Key + " = ";

                if (item.Value.GetType() == typeof(string))
                {
                    sql += "'" + item.Value + "'";
                }
                else if (item.Value.GetType() == typeof(DateTime))
                {
                    sql += "#" + item.Value + "#";
                }
                else
                {
                    sql += item.Value;
                }

                sql += " && ";
            }

            sql = sql.Substring(0, sql.Length - 4);
            list =db.Database.SqlQuery<T>(sql).ToList();

            return list;
        }

        //private static string DeCryptPass()
        //{
        //    var ecr = Properties.Settings.Default.SSAP;
        //    var key = "3/3JysB9VLsqWAE35jXoy7Hf6GtSRlFJO9tcP9pm1SPKXU0zfZKIXHLSa+8wkgBQe8bDfeBI2GoS6obZlcKrZw==";

        //    return SecurityHelper.DeCryptMD5(ecr, key);
        //}

        //public static string EnCryptPass(string pass)
        //{
        //    var key = "3/3JysB9VLsqWAE35jXoy7Hf6GtSRlFJO9tcP9pm1SPKXU0zfZKIXHLSa+8wkgBQe8bDfeBI2GoS6obZlcKrZw==";

        //    return SecurityHelper.EnCryptMD5(pass, key);
        //}

        //public static string GetConnectionString()
        //{
        //    string Pass = DeCryptPass();
        //    var Datasource = Properties.Settings.Default.DS;
        //    var Database = Properties.Settings.Default.DB;
        //    var UserId = Properties.Settings.Default.UID;

        //    return "Data Source=" + Datasource + ";Initial Catalog=" + Database + ";Persist Security Info=True;User ID=" + UserId + ";Password=" + Pass + ";MultipleActiveResultSets=True;";
        //}

        public static List<string> GetDatabaseList(string Datasource, string UserId, string Pass)
        {
            string connectionString = "Data Source=" + Datasource + ";Initial Catalog=master;Persist Security Info=True;User ID=" + UserId + ";Password=" + Pass + ";MultipleActiveResultSets=True;";

            QLKhoDienLucEntities db = new QLKhoDienLucEntities();
            db.Database.Connection.ConnectionString = connectionString;

            try
            {
                var databases = db.Database.SqlQuery<string>("SELECT [name] FROM sys.databases where [name] = 'QuanLyKhoDongLuc'").ToList();

                return databases;
            }
            catch
            {
                return new List<string>();
            }
        }

        public static string GetConnectionString(string Datasource, string UserId, string Pass, string Database)
        {
            return "Data Source=" + Datasource + ";initial catalog=" + Database + ";persist security info=True;user id=" + UserId + ";password=" + Pass + ";MultipleActiveResultSets=True;";
        }
        public  QLKhoDienLucEntities db = new QLKhoDienLucEntities();

        public  int  ConnectDatabase()
        {
           
            db.Database.Connection.ConnectionString = clsThamSoUtilities.connectionString;

            try
            {
                db.Database.Connection.Open();
                //db.Database.Connection.Close();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
