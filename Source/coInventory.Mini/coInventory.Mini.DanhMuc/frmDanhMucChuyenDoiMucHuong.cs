using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
////using WebService.Model;;
//using WebService.Model;.Utility;
using System.Configuration;

namespace coInventory.Mini.DanhMuc
{
    public partial class frmDanhMucChuyenDoiMucHuong : Form
    {
        public frmDanhMucChuyenDoiMucHuong()
        {
            InitializeComponent();
        }

        private void frmDanhMucChuyenDoiMucHuong_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }
        private void LoadGridView()
        {
            clsDM_ChuyenDoiMucHuong obj = new clsDM_ChuyenDoiMucHuong();
            TableChuyenDoiMucHuong = obj.GetAll();
            grdDM_ChuyenDoiMucHuong.DataSource = TableChuyenDoiMucHuong;
        }

        private void GetDanhMucOnline()
        {
            if (MessageBox.Show("Bạn muốn lấy dữ liệu danh mục từ server?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                                
                InsertDanhMucOnline();
                LoadGridView();
            }
        }

        private void InsertDanhMucOnline(){
        //{
        //    SystemConfig system = SystemConfig.Instance;

        //    string service = system.GetLinkWS();
        //    string token = system.GetToken();
        //    if (string.IsNullOrEmpty(token))
        //    {
        //        MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        string URL = "WSGetDMChuyenDoi";
        //        string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL1, "GET", string.Empty, token);
        //        if (string.IsNullOrEmpty(response))
        //        {
        //            MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }
        //        //string str = XMLUtils.DeSerializeToObject<string>(response);
        //        List<DM_ChuyenDoi> lstDM = XMLUtils.DeSerializeToList<DM_ChuyenDoi>(response);
        //        if (lstDM == null)
        //        {
        //            MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }
        //        int tongRecord = lstDM.Count;
        //        if (tongRecord == 0)
        //        {
        //            MessageBox.Show("Không có dữ liệu để tải về.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }
        //        if (MessageBox.Show("Có " + tongRecord + " danh mục . Bạn có muốn tải về?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
        //        {
        //            return;
        //        }

        //        SQLiteDAL DAL = new SQLiteDAL();
        //        DAL.BeginTransaction();
        //        foreach (DM_ChuyenDoi t in lstDM)
        //        {
        //            clsDM_ChuyenDoiMucHuong obj = new clsDM_ChuyenDoiMucHuong();
        //            obj.DoiTuong = t.MaDoiTuong;
        //            obj.MucHuongCu = t.MucHuongCu;
        //            obj.MucHuongMoi = t.MucHuongMoi;

        //            int result = 0;
        //            if (TableChuyenDoiMucHuong.Select("DoiTuong = '" + obj.DoiTuong+"'").Length > 0)
        //            {
        //                result = obj.Update(DAL);
        //            }
        //            else
        //            {
        //                result = obj.Insert(DAL);
        //            }

        //            if (result == 0)
        //            {
        //                DAL.RollbackTransaction();
        //                MessageBox.Show("Lỗi cập nhật dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }

        //        }
        //        //Close & Commit Trans
        //        DAL.CommitTransaction();
        //        MessageBox.Show("Cập nhật dữ liệu thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        //btnLamMoi.Enabled = true;
        //        //btnThem.Enabled = true;
        //        //btnXoa.Enabled = true;
        //        //btnLamMoi.Enabled = true;
        //        //btnGetDM.Enabled = true;
        //        //btnSua.Enabled = true;
        //    }
        //    else
        //    {
        //        // "Access token is empty.";
        //    }
        }


        private bool CheckTonTai(string strDoiTuong)
        {
            bool kq = false;
            clsDM_ChuyenDoiMucHuong obj = new clsDM_ChuyenDoiMucHuong();
            kq = obj.CheckTonTai(strDoiTuong);
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

        private void grdDM_ChuyenDoiMucHuong_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(grdDM_ChuyenDoiMucHuong.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 2, e.RowBounds.Location.Y + 5);
            }
        }
    }
}
