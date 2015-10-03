using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
using coInventory.Mini.Utilities;
//using WebService.Model;.Utility;
////using WebService.Model;;
using System.Threading;
using System.Configuration;

namespace coInventory.Mini.DanhMuc
{
    public partial class frmDanhMucThuoc : Form
    {
        public frmDanhMucThuoc()
        {
            InitializeComponent();
        }

        private void frmDanhMucThuoc_Load(object sender, EventArgs e)
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
     
            int index=0;
            if (gridMaster.RowCount > 0)
            {
                index = gridMaster.CurrentCell.RowIndex;
            }
            clsDM_Thuoc obj = new clsDM_Thuoc();
            dTableDanhMucThuoc = obj.GetAll();
            gridMaster.DataSource = dTableDanhMucThuoc;
            
            if (gridMaster.RowCount > 0)
            {
                gridMaster.Rows[index].Selected = true;
                gridMaster.FirstDisplayedScrollingRowIndex = index;
            }

        }

       

        private void GetDanhMucOnline()
        {
            if (MessageBox.Show("Bạn muốn lấy dữ liệu danh mục năm " + cboNam.Text + " từ server?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InsertDanhMucOnline();
                LoadGridView();
            }
        }

        private void InsertDanhMucOnline()
        {
          
            //btnLamMoi.Enabled = false;
            //btnThem.Enabled = false;
            //btnXoa.Enabled = false;
            //btnLamMoi.Enabled = false;
            //btnGetDM.Enabled = false;
            //btnSua.Enabled = false;
            //SystemConfig system = SystemConfig.Instance;
            //string token = system.GetToken();
            //if (string.IsNullOrEmpty(token))
            //{
            //    MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (!string.IsNullOrEmpty(token))
            //{
            //    string URL = string.Format("WSGetDMThuocCSKCB/{0}/{1}", system.MaCSKCB, cboNam.Text);

            //    string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL1, "GET", string.Empty, token);
            //    if (string.IsNullOrEmpty(response))
            //    {
            //        MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    //string str = XMLUtils.DeSerializeToObject<string>(response);
            //    List<DM_ThuocCSKCB> lstDMThuoc = XMLUtils.DeSerializeToList<DM_ThuocCSKCB>(response);
            //    if (lstDMThuoc == null)
            //    {
            //        MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    int tongRecord = lstDMThuoc.Count;
            //    if (tongRecord == 0)
            //    {
            //        MessageBox.Show("Không có dữ liệu để tải về.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    if (MessageBox.Show("Có " + tongRecord + " danh mục thuốc. Bạn có muốn tải về?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            //    {
            //        return;
            //    }
          
            //    SQLiteDAL DAL = new SQLiteDAL();
            //    DAL.BeginTransaction();
            //    foreach (DM_ThuocCSKCB t in lstDMThuoc)
            //    {
            //        clsDM_Thuoc obj = new clsDM_Thuoc();

            //        //obj.Thuoc_Id = t.Thuoc_Id;
            //        obj.MaThuoc = t.MaThuoc;
            //        obj.TenThuoc = t.TenThuoc;
            //        obj.TenHoatChat = t.TenHoatChat;
            //        obj.DonViTinh = t.DonViTinh;
            //        obj.QuyCach = t.QuyCach;
            //        obj.NhaSanXuat = t.NhaSanXuat;                   
            //        //obj.NuocSanXuat = t.NuocSanXuat;
            //        obj.SoDangKy = t.SoDK;
            //        //obj.HanSuDung = t.HanDung;
            //        obj.NongDo = t.NongDo;
            //        obj.DangBaoChe = t.DangBaoChe;
            //        obj.TieuChuan = t.TieuChuan;
            //        obj.NhomThuoc = t.NhomThuoc;
            //        //obj.DonGiaMua = t.DonGiaMua;
            //        obj.DonGiaThau = t.GiaThau;
            //        obj.DonGiaCSKCB = t.DonGiaCSKCB;
            //        //obj.SoLuong = t.SoLuong;
            //        obj.MaNhom1 = t.MaNhom1;
            //        obj.MaNhom2 = t.MaNhom2;
            //        obj.TrongDanhMucBHYT = t.TrongDanhMucBHYT;
            //        obj.TrongThau = t.TrongThau;
            //        obj.Active = t.Active;
            //        obj.ThuocDieuTriK = t.ThuocDieuTriK;
            //        obj.TyLeThanhToan = t.TiLeThanhToan;
            //        obj.MaNhaThau = t.MaNhaThau;
            //        obj.Nam = t.Nam;
            //        obj.STTBYT = t.STTBYT;
            //        obj.MaThuocBYT = t.MaThuocBYT;
            //        obj.MaThuocBYT2 = t.MaThuocBYT2;
            //        //obj.TenThuocBYT = t.TenThuocBYT;
            //        obj.GhiChu = t.GhiChu;

            //        obj.TrongDanhMucBHYT = (bool)t.TrongDanhMucBHYT;
            //        int result = 0;
            //        if (dTableDanhMucThuoc.Select("MaThuoc = '" + obj.MaThuoc + "'").Length > 0)
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

            //    //btnLamMoi.Enabled = true;
            //    //btnThem.Enabled = true;
            //    //btnXoa.Enabled = true;
            //    //btnLamMoi.Enabled = true;
            //    //btnGetDM.Enabled = true;
            //    //btnSua.Enabled = true;
            //  }
            //else
            //{
            //    // "Access token is empty.";
            //}

        }

        private bool CheckTonTai(string strMa)
        {
            bool kq = false;
            clsDM_Thuoc obj = new clsDM_Thuoc();
            kq = obj.CheckTonTai(strMa);
            return kq;
        }

        private int Insert()
        {
            int kq = 0;
            frmDanhMucThuocChiTiet frmChiTiet = new frmDanhMucThuocChiTiet();
            frmChiTiet.ShowDialog();
            LoadGridView();
            return kq;

        }

        private int UpdateThuoc()
        {
            int kq = 0;
            if (gridMaster.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.gridMaster.SelectedRows[0];
                string MaThuoc = row.Cells["MaThuoc"].Value.ToString();

                frmDanhMucThuocChiTiet frmChiTiet = new frmDanhMucThuocChiTiet();
                frmChiTiet.MaDM = MaThuoc;
                frmChiTiet.ShowDialog();
                LoadGridView();
            }
            return kq;

        }

        private int Delete()
        {
            int kq = 0;
            clsDM_Thuoc obj = new clsDM_Thuoc();
            if (MessageBox.Show("Bạn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridMaster.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = this.gridMaster.SelectedRows[0];
                    string MaThuoc = row.Cells["MaThuoc"].Value.ToString();
                    kq = obj.Delete(MaThuoc);
                    if (kq > 0)
                    {
                        LoadGridView();
                    }
                }

            }
            return kq;
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Insert();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UpdateThuoc();

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadGridView();
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
            bs.DataSource = dTableDanhMucThuoc;
            string search = "";
            if (cboCotDuLieu.SelectedIndex == 0)
            {
                search = "MaThuoc like '%" + txtGiaTri.Text + "%'";
            }
            else if (cboCotDuLieu.SelectedIndex == 1)
            {
                search = "TenThuoc like '%" + txtGiaTri.Text + "%'";
            }
            else if (cboCotDuLieu.SelectedIndex == 2)
            {
                search = "TenHoatChat like '%" + txtGiaTri.Text + "%'";
            }
            bs.Filter = search;
            gridMaster.DataSource = bs;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
