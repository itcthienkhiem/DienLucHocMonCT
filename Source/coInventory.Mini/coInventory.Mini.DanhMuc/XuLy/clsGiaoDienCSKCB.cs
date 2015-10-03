using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using eHospital.Mini.EntityClass;
using WebService.Model;
using WebService.Model.Utility;
namespace  eHospital.Mini.DanhMuc.XuLy

{
    /// <summary>
    /// lớp xữ lý riêng cho từng loại lưới CSKCB
    /// </summary>
   public class clsGiaoDienCSKCB : clsAbLoạiGiaoDien 
    {
       
       public override string ShowMessage()
       {
           return "Bạn có muốn xóa CSKCB này không? ";
         
       }
       public override string getMa(DataGridView grid)
       {
           DataGridViewRow row = grid.SelectedRows[0];
           string MaCSKCB = row.Cells["Mã KCB ID"].Value.ToString();
           return MaCSKCB;
        
       }
       public override string GetTenThamSoWS()
       {

           return "WSGetDMCSKCB";
       }
       public override List<object> LayDanhSachFromWS(string response)
       {
           List<DM_CSKCB> DanhSachWS = XMLUtils.DeSerializeToList<DM_CSKCB>(response);
           List<object > obj =new List<object>( DanhSachWS.ToArray());
           return obj;
       }    
       public override int XuLyTuWSSangCSDL( object obj,DataTable tb,SQLiteDAL DAL)
       {
       //    tb.Rows.Clear();
           int result = 0;
           DM_CSKCB dm = (DM_CSKCB)obj;

           clsDM_CSKCB kcb = new clsDM_CSKCB(dm);
           //kcb.Delete();

           string str = String.Format("MACSKCB = '" + kcb.MaCSKCB + "'");
           if (tb != null && tb.Select(str).Length > 0)
           {
               result = kcb.Update(DAL);
           }
           else
           {
               result = kcb.Insert(DAL);
           }
           return result;
          
       }
       public override void SetObject(clsDanhMucAbtract.clsAbGiaoDien ehost)
       {
         
           base.SetObject(ehost);
       }
       public override void VisibleColumn(DataGridView grid)
       {
           grid.Columns[10].Visible = false;
           grid.Columns[11].Visible = false ;

           grid.Columns[12].Visible = false;
           grid.Columns[13].Visible = false;
           grid.Columns[14].Visible = false;
           grid.Columns[15].Visible = false;

       }
       public override void SetTableName(ref DataGridView tb)
       {
           tb.Columns[0].HeaderText = "Cơ sở KCB ID";

           tb.Columns[1].HeaderText = "Mã KCB ID";
           tb.Columns[2].HeaderText = "Mã Tỉnh ";
           tb.Columns[3].HeaderText = "Tên Cơ sở KCB";
           tb.Columns[4].HeaderText = "Cơ sở KCB Ban Đầu";
           tb.Columns[5].HeaderText = "Xếp Hạng";
           tb.Columns[6].HeaderText = "Trạng Thái";
           tb.Columns[7].HeaderText = "Địa Chỉ";
           tb.Columns[8].HeaderText = "Tuyến";
           tb.Columns[9].HeaderText = "Quy1Quy";
           tb.Columns[10].HeaderText = "Cơ Sở Dữ Liệu";
           tb.Columns[11].HeaderText = "Người Tạo";
           tb.Columns[12].HeaderText = "Ngày Tạo";
           tb.Columns[13].HeaderText = "Người Cập Nhật";
           tb.Columns[14].HeaderText = "Ngày Cập Nhật";
           tb.Columns[15].HeaderText = "Mã Cấp Trên";

        
       }
     
    }
}
