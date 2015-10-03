using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace Inventory.EntityClass
{
    public class SQLDAL
    {
        public string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public SqlConnection m_conn = null;
        public SqlTransaction m_trans = null;

        public void BeginTransaction()
        {
            m_conn = new SqlConnection(connectionString);
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
