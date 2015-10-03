using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
using System.Data;
namespace  coInventory.Mini.DanhMuc.XuLy

{
    /// <summary>
    /// lớp xữ lý chung cho tất cả các lưới
    /// </summary>
  public abstract  class clsAbLoạiGiaoDien
    {
      public virtual string getMa(DataGridView grid) { return ""; }
      public virtual void SetObject(clsDanhMucAbtract.clsAbGiaoDien ehost)
      { }
      /// <summary>
      /// loại thông báo
      /// </summary>
      /// <returns></returns>
      public virtual string ShowMessage()
      {
          return "";
      }
      public virtual void SetTableName( ref DataGridView tb)
      { 
      
      }
      public virtual void VisibleColumn(DataGridView grid)
      { 
      
      }
      public virtual string ShowMessageGetDuLieu(int tongRecord)
      {
          return "Có "+tongRecord +" record bạn có muốn tải về.";
      }
      public virtual int XuLyTuWSSangCSDL(object obj, DataTable tb, SQLiteDAL DAL) {

          return 0;
      }
      public virtual string GetTenThamSoWS()
      {
          return "";
      }
      public virtual List<object> LayDanhSachFromWS(string response)
      {
          return null;
      }
    }
}
