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

namespace coInventory.Mini.DanhMuc
{
    public partial class frmDanhMucCSKCB : Form
    {
        public frmDanhMucCSKCB()
        {
            InitializeComponent();
        }
        private void frmDanhMucCSKCB_Load(object sender, EventArgs e)
        {
            LoadGridView();
            cboCotDuLieu.SelectedIndex = 0;
        }

        private void LoadGridView()
        {
            clsDM_CSKCB obj = new clsDM_CSKCB();
            CSKCBBD = obj.GetAll();
            grdMaster.DataSource = CSKCBBD;
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

        private void GetDanhMucOnline()
        {
            if (MessageBox.Show("Bạn muốn lấy dữ liệu danh mục từ server?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
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
            //    MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (!string.IsNullOrEmpty(token))
            //{
            //    string URL = "WSGetDMCSKCB";
            //    string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL1, "GET", string.Empty, token);
            //    if (string.IsNullOrEmpty(response))
            //    {
            //        MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    //string str = XMLUtils.DeSerializeToObject<string>(response);
            //    List<DM_CSKCB> lstDM_CSKCB = XMLUtils.DeSerializeToList<DM_CSKCB>(response);
            //    if (lstDM_CSKCB == null)
            //    {
            //        MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    int tongRecord = lstDM_CSKCB.Count;
            //    if (tongRecord == 0)
            //    {
            //        MessageBox.Show("Không có dữ liệu để tải về.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    if (MessageBox.Show("Có " + tongRecord + " danh mục CSKCB. Bạn có muốn tải về?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            //    {
            //        return;
            //    }

            //    SQLiteDAL DAL = new SQLiteDAL();
            //    DAL.BeginTransaction();
            //    foreach (DM_CSKCB t in lstDM_CSKCB)
            //    {
            //        clsDM_CSKCB obj = new clsDM_CSKCB();
            //        obj.MaCSKCB = t.MaCSKCB;
            //        obj.TenCSKCB = t.TenCSKCB;
            //        obj.MaTinh = t.MaTinh;
            //        obj.XepHang = t.XepHang==null?0: t.XepHang.Value;
            //        obj.CSKCBBanDau = t.CSKCBBanDau ?? true;
            //        obj.Active = t.Active ?? true;
            //        obj.DiaChi = t.DiaChi;
            //        obj.Tuyen = t.Tuyen ?? 0;
            //        obj.Quy1Quy = t.Quy1Quy ?? 0;
            //        obj.CoDuLieu = t.CoDuLieu ?? true;
            //        obj.MaCapTren = t.MaCapTren;

            //        int result = 0;
            //        if (CSKCBBD.Select("MaCSKCB = '" + obj.MaCSKCB + "'").Length > 0)
            //        {
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

        private bool CheckTonTai(string strMa)
        {
            bool kq = false;
            clsDM_ICD obj = new clsDM_ICD();
            kq = obj.CheckTonTai(strMa);
            return kq;
        }

        private void grdMaster_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(grdMaster.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 2, e.RowBounds.Location.Y + 5);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        
        private void txtGiaTri_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = CSKCBBD;
            string search = "";
            if (cboCotDuLieu.SelectedIndex == 0)
            {
                search = "MaCSKCB like '%" + txtGiaTri.Text + "%'";
            }
            else if (cboCotDuLieu.SelectedIndex == 1)
            {
                search = "TenCSKCB like '%" + txtGiaTri.Text + "%'";
            }
            
          
            bs.Filter = search;
            grdMaster.DataSource = bs;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
