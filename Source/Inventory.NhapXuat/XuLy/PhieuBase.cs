using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventory.Models;
using System.Data.Entity;
namespace Inventory.NhapXuat.XuLy
{
   public class PhieuBase
    {
        public virtual int Insert (int id )
        {
          

            return 1;
        }
        public virtual int Insert(int id, DatabaseHelper help) { return 0; }

        public virtual int Update(int id)
        {
            return 0;        
        }
        public virtual int Delete(int id)
       {
           return 0;
       }
        public virtual int BoDuyet(int id, DatabaseHelper help) { return 0; }
        public virtual int BoDuyet(int id)
        {
            return 0;
        }
    }
}
