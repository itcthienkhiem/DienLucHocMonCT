using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inventory.EntityClass
{
   public class ObjecEntity
    {
       //tổng quát hóa
       public virtual AutoCompleteStringCollection getListToComboboxNotHaveKhoNgoai(string TenCot) { return null; }
       public virtual AutoCompleteStringCollection getListToComboboxHaveKhoNgoai(string TenCot) { return null; }
       public virtual AutoCompleteStringCollection getListToCombobox(string TenCot) { return null; }
       public virtual DataTable GetAllData() { return null; }
       public virtual DataTable GetAllHasNotData() { return null; }
       public virtual DataTable GetAllDataHasKhoNgoai() { return null; }
       public virtual DataTable GetAllDataHasNotKhoNgoai() { return null; }  
       public virtual bool KiemTraTrungMa() { return false; }
       public virtual bool KiemTraTrungTen(string ten) { return false; }
    }
}
