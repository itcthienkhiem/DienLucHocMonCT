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
  public  class clsGiaoDienDichVu : clsAbLoạiGiaoDien
    {
      public override string ShowMessage()
      {
          return "Bạn có muốn xóa dịch vụ này không?";
      }
        public override string getMa(DataGridView grid)
        {
            DataGridViewRow row = grid.SelectedRows[0];
            string MaCSKCB = row.Cells["MADICHVU"].Value.ToString();
            return MaCSKCB;
        }
        public override void SetObject(clsDanhMucAbtract.clsAbGiaoDien ehost)
        {

            base.SetObject(ehost);
        }
        public override List<object> LayDanhSachFromWS(string response)
        {
            List<DM_DichVuCSKCB> DanhSachWS = XMLUtils.DeSerializeToList<DM_DichVuCSKCB>(response);
            List<object> obj = new List<object>(DanhSachWS.ToArray());
            return obj;
        }
        public override string GetTenThamSoWS()
        {
            return "WSGetDMDichVuCSKCB/31-021";
        }
        public override int XuLyTuWSSangCSDL(object obj, DataTable tb, SQLiteDAL DAL)
        {
            int result = 0;
            DM_DichVuCSKCB dm = (DM_DichVuCSKCB)obj;

            clsDM_DichVu kcb = new clsDM_DichVu(dm);
           // clsDM_CSKCB kcb = new clsDM_CSKCB(dm);
           // kcb.Delete();
            string str = String.Format("MADICHVU = '" + kcb.MaDichVu + "'");
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
        public override void SetTableName(ref DataGridView tb)
        {


            tb.Columns[0].HeaderText = "Dịch vụ ID";

            tb.Columns[1].HeaderText = "Mã Dịch vụ";
            tb.Columns[2].HeaderText = "Tên Dịch vụ ";
            tb.Columns[3].HeaderText = "Mã Loại Dịch Vụ";
            tb.Columns[4].HeaderText = "Đơn Vị Tính";
            tb.Columns[5].HeaderText = "Đơn Giá BHYT";
            tb.Columns[6].HeaderText = "Đơn Giá CSKCB";
            tb.Columns[7].HeaderText = "Mã Nhóm 1";
            tb.Columns[8].HeaderText = "Mã Nhóm 2";
            tb.Columns[9].HeaderText = "Trong Danh Mục BHYT";
            tb.Columns[10].HeaderText = "Dịch vụ KTC";
            tb.Columns[11].HeaderText = "Trạng Thái";
            tb.Columns[12].HeaderText = "Thông Tư";
            tb.Columns[13].HeaderText = "Số Thứ Tự BHYT";
            tb.Columns[14].HeaderText = "Mã Khác";
            tb.Columns[15].HeaderText = "Mã Loại Chi Phí";
            tb.Columns[16].HeaderText = "Mã Loại DVBYT";
            tb.Columns[17].HeaderText = "Ghi Chú";

        }
      
    }
}
