using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SQLite;

namespace coInventory.Mini.EntityClass
{
    public class SQLiteDAL
    {
        public string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public SQLiteConnection m_conn = null;
        public SQLiteTransaction m_trans = null;

        public void BeginTransaction()
        {
            m_conn = new SQLiteConnection(connectionString);
            m_conn.Open();
            m_trans = m_conn.BeginTransaction();
        }
        public void CommitTransaction()
        {
            m_trans.Commit();
            m_conn.Close();
        }

        public void RollbackTransaction()
        {
            m_trans.Rollback();
            m_conn.Close();
        }

       
    }
}
