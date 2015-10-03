using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WebService.Model;
using System.Data;
using eHospital.Mini.EntityClass;
using WebService.Model.Utility;

namespace eHospital.Mini.DanhMuc.XuLy
{
    public class clsGiaoDienMau : clsAbLoạiGiaoDien
    {
        public override string ShowMessage()
        {
            return "Bạn muốn xóa danh mục máu này không?";
        }
        public override string getMa(DataGridView grid)
        {
            DataGridViewRow row = grid.SelectedRows[0];
            string MaMAU = row.Cells["MaMauVaChePhamMau"].Value.ToString();
            return MaMAU;
            //return base.getMaThuoc(grid);
        }
        public override List<object> LayDanhSachFromWS(string response)
        {
            List<DM_MauVaChePhamCSKCB> DanhSachWS = XMLUtils.DeSerializeToList<DM_MauVaChePhamCSKCB>(response);
            List<object> obj = new List<object>(DanhSachWS.ToArray());
            return obj;
        }
        public override string GetTenThamSoWS()
        {
            return "WSGetDMMauVaChePhamCSKCB/31-021";
        }
        public override int XuLyTuWSSangCSDL(object obj, DataTable tb, SQLiteDAL DAL)
        {
            int result = 0;
            DM_MauVaChePhamCSKCB dm = (DM_MauVaChePhamCSKCB)obj;

            clsDM_Mau kcb = null;// new clsDM_Mau(dm);
            //kcb.Delete();
            string str = String.Format("MaMauVaChePhamMau = '" + kcb.MaMauVaChePhamMau + "'");
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
        public override void SetTableName(ref DataGridView tb)
        {
            tb.Columns[0].HeaderText = "Máu ID";

            tb.Columns[1].HeaderText = "Mã Máu";
            tb.Columns[2].HeaderText = "Tên Máu ";
            tb.Columns[3].HeaderText = "Mã Loại Máu";
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
            tb.Columns[14].HeaderText = "Mã Máu BYT";
        }
    }
}
