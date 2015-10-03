using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
using System.Configuration;
////using WebService.Model;;
//using WebService.Model;.Utility;

namespace coInventory.Mini.DanhMuc
{
    public partial class frmDanhMucLuongCoSo : Form
    {
        public frmDanhMucLuongCoSo()
        {
            InitializeComponent();
        }

        private void frmDanhMucLuongCoSo_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }
        private void LoadGridView()
        {
            clsDM_LuongCoSo obj = new clsDM_LuongCoSo();
            TableDanhMucLuongCoSo = obj.GetAll();
            grdDM_LuongCoSo.DataSource = TableDanhMucLuongCoSo;
        }

        private void GetDanhMucOnline()
        {
            if (MessageBox.Show("Bạn muốn lấy dữ liệu danh mục từ server?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ////Xử lý lấy danh mục từ server thông qua webservice
                ////Giả sử webservice trả về table.

                //DataTable dt = new DataTable();
                ////Sau đó insert vào database và làm mới dữ liệu trong lưới                
                //InsertDanhMucOnline(dt);

                InsertDanhMucOnline();
                LoadGridView();
            }
        }

        private void InsertDanhMucOnline()
        {
            //SystemConfig system = SystemConfig.Instance;
            //string token = system.GetToken();
            //if (string.IsNullOrEmpty(token))
            //{
            //    MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (!string.IsNullOrEmpty(token))
            //{
            //    string URL = "WSGetDMLuongCoSo";
            //    string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL1, "GET", string.Empty, token);
            //    if (string.IsNullOrEmpty(response))
            //    {
            //        MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    //string str = XMLUtils.DeSerializeToObject<string>(response);
            //    List<DM_LuongCoSo> lstDM = XMLUtils.DeSerializeToList<DM_LuongCoSo>(response);
            //    if (lstDM == null)
            //    {
            //        MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }

            //    int tongRecord = lstDM.Count;
            //    if (tongRecord == 0)
            //    {
            //        MessageBox.Show("Không có dữ liệu để tải về.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    if (MessageBox.Show("Có " + tongRecord + " danh mục lưởng cơ sở. Bạn có muốn tải về?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            //    {
            //        return;
            //    }

            //    SQLiteDAL DAL = new SQLiteDAL();
            //    DAL.BeginTransaction();
            //    foreach (DM_LuongCoSo t in lstDM)
            //    {
            //        clsDM_LuongCoSo obj = new clsDM_LuongCoSo();
            //        obj.TuNgay = t.TuNgay;
            //        obj.LuongCoSo = t.LuongCoSo;

            //        int result = 0;
            //        DataRow[] drs = TableDanhMucLuongCoSo.Select("TuNgay = #" + obj.TuNgay + "#");
            //        if (drs.Length > 0)
            //        {
            //            obj.LuongCoSo_Id = int.Parse(drs[0]["LuongCoSo_Id"].ToString());
            //            result = obj.Update(DAL);
            //        }
            //        else
            //        {
            //            result = obj.Insert(DAL);
            //        }

            //        if (result == 0)
            //        {
            //            DAL.RollbackTransaction();
            //            MessageBox.Show("Lỗi cập nhật dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //    }
            //    //Close & Commit Trans
            //    DAL.CommitTransaction();
            //    MessageBox.Show("Cập nhật dữ liệu thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    // "Access token is empty.";
            //}


        }

        private bool CheckTonTai(int intLuongCoSo)
        {
            bool kq = false;
            clsDM_LuongCoSo obj = new clsDM_LuongCoSo();
            kq = obj.CheckTonTai(intLuongCoSo);
            return kq;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetDM_Click(object sender, EventArgs e)
        {
            GetDanhMucOnline();
        }

        private void grdDM_LuongCoSo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(grdDM_LuongCoSo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 2, e.RowBounds.Location.Y + 5);
            }
        }
    }
}
