using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
using coInventory.Mini.Utilities;
using System.Threading;
////using WebService.Model;;
using System.Configuration;
////using WebService.Model;.Utility;

namespace coInventory.Mini.DanhMuc
{
    public partial class frmDanhMucVTYT : Form
    {
        List<Thread> lstThread = new List<Thread>();
        public frmDanhMucVTYT()
        {
            InitializeComponent();
        }
        private void frmDanhMucVTYT_Load(object sender, EventArgs e)
        {
            LoadGridView();
            LoadComboData();
        }

        private void LoadComboData()
        {
            cboNam.DataSource = Utils.GetListYear();
            cboCotDuLieu.SelectedIndex = 0;
        }

        private void LoadGridView()
        {
            int index = 0;
            if (gridMaster.RowCount > 0)
            {
                index = gridMaster.CurrentCell.RowIndex;
            }
            clsDM_VTYT obj = new clsDM_VTYT();
            dTableDanhMucVTYT = obj.GetAll();
            gridMaster.DataSource = dTableDanhMucVTYT;

            if (gridMaster.RowCount > 0)
            {
                gridMaster.Rows[index].Selected = true;
                gridMaster.FirstDisplayedScrollingRowIndex = index;
            }
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
            //try
            //{
            //    SystemConfig system = SystemConfig.Instance;
            //    string token = system.GetToken();
            //    if (string.IsNullOrEmpty(token))
            //    {
            //        MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }

            //    if (!string.IsNullOrEmpty(token))
            //    {
            //        string URL = string.Format("WSGetDMVatTuYTeThauCSKCB/{0}/{1}", system.MaCSKCB, cboNam.Text);
            //        string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL1, "GET", string.Empty, token);
            //        if (string.IsNullOrEmpty(response))
            //        {
            //            MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }
            //        //string str = XMLUtils.DeSerializeToObject<string>(response);
            //        List<DM_VatTuYTeCSKCB> lstDMVTYT = XMLUtils.DeSerializeToList<DM_VatTuYTeCSKCB>(response);
            //        if (lstDMVTYT == null)
            //        {
            //            MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }
            //        int tongRecord = lstDMVTYT.Count;
            //        if (tongRecord == 0)
            //        {
            //            MessageBox.Show("Không có dữ liệu để tải về.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }
            //        if (MessageBox.Show("Có " + tongRecord + " danh mục VTYT. Bạn có muốn tải về?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            //        {
            //            return;
            //        }

            //        SQLiteDAL DAL = new SQLiteDAL();
            //        DAL.BeginTransaction();

            //        foreach (DM_VatTuYTeCSKCB t in lstDMVTYT)
            //        {
            //            clsDM_VTYT obj = new clsDM_VTYT();

            //            //obj.VTYT_Id = t.VTYT_Id;
            //            obj.MaVTYT = t.MaVatTuYTe;
            //            obj.TenVTYT = t.TenVatTuYTe;
            //            //obj.TenHoatChat = t.TenHoatChat;
            //            obj.DonViTinh = t.DonViTinh;
            //            obj.QuyCach = t.QuyCach;
            //            obj.NhaSanXuat = t.NhaSanXuat;
            //            obj.NuocSanXuat = t.NuocSanXuat;
            //            //obj.SoDangKy = t.SoDangKy;
            //            //obj.HanSuDung = t.HanSuDung;
            //            obj.SoLuong = t.SoLuong;
            //            obj.DonGiaMua = t.GiaMua;
            //            obj.DonGiaThau = t.GiaThau;
            //            obj.DonGiaCSKCB = t.DonGiaCSKCB;
            //            obj.MaNhom1 = t.MaNhom1;
            //            obj.MaNhom2 = t.MaNhom2;
            //            obj.TrongDanhMucBHYT = t.TrongDanhMucBHYT;
            //            obj.VTYTThayThe = t.VatTuYTeThayThe;
            //            obj.VTYTDichVuKTC = t.DichVuKTC;
            //            obj.TrongThau = t.TrongThau;
            //            obj.Active = t.Active;
            //            obj.Nam = t.Nam;
            //            //obj.STTBYT = t.STTBYT;
            //            obj.MaVTYTBYT = t.MaVatTuYTeBYT;
            //            //obj.TenVTYTBYT = t.TenVTYTBYT;
            //            obj.GhiChu = t.GhiChu;
            //            int result = 0;
            //            if (dTableDanhMucVTYT.Select("MaVTYT = '" + obj.MaVTYT + "'").Length > 0)
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
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("Lỗi : "+Environment.NewLine+ ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private bool CheckTonTai(string strMa)
        {
            bool kq = false;
            clsDM_VTYT obj = new clsDM_VTYT();
            kq = obj.CheckTonTai(strMa);
            return kq;
        }

        private int Insert()
        {
            int kq = 0;
            frmDanhMucVTYTChiTiet frmChiTiet = new frmDanhMucVTYTChiTiet();
            frmChiTiet.ShowDialog();
            LoadGridView();
            return kq;

        }

        private int UpdateVTYT()
        {
            int kq = 0;
            if (gridMaster.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.gridMaster.SelectedRows[0];
                string MaVTYT = row.Cells["MaVTYT"].Value.ToString();

                frmDanhMucVTYTChiTiet frmChiTiet = new frmDanhMucVTYTChiTiet();
                frmChiTiet.MaDM = MaVTYT;
                frmChiTiet.ShowDialog();
                LoadGridView();
            }
            return kq;

        }

        private int Delete()
        {
            int kq = 0;
            clsDM_VTYT obj = new clsDM_VTYT();
            if (MessageBox.Show("Bạn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridMaster.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = this.gridMaster.SelectedRows[0];
                    string MaVTYT = row.Cells["MaVTYT"].Value.ToString();
                    kq = obj.Delete(MaVTYT);
                    if (kq > 0)
                    {
                        LoadGridView();
                    }
                }

            }

            return kq;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Insert();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UpdateVTYT();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridMaster_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(gridMaster.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 2, e.RowBounds.Location.Y + 5);
            }
        }

        private void btnGetDM_Click(object sender, EventArgs e)
        {
            GetDanhMucOnline();
        }

        private void txtGiaTri_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dTableDanhMucVTYT;
            string search ="";
            if (cboCotDuLieu.SelectedIndex == 0)
            {
                search = "MaVTYT like '%" + txtGiaTri.Text + "%'";
            }
            else if (cboCotDuLieu.SelectedIndex == 1)
            {
                search = "TenVTYT like '%" + txtGiaTri.Text + "%'";
            }
            else if (cboCotDuLieu.SelectedIndex == 2)
            {
                search = "TenHoatChat like '%" + txtGiaTri.Text + "%'";
            }
            bs.Filter = search;
            gridMaster.DataSource = bs;
        }



    }
}
