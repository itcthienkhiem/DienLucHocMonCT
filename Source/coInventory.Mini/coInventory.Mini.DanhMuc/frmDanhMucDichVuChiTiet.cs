using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;

namespace coInventory.Mini.DanhMuc
{
    public partial class frmDanhMucDichVuChiTiet : Form
    {

        public string MaDM = "";
        public frmDanhMucDichVuChiTiet()
        {
            InitializeComponent();
        }


        private void frmDanhMucDichVuChiTiet_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            lblCapNhat.Text = "Thêm";
            if (MaDM != "")
            {
                txtMaDichVu.Enabled = false;
                lblCapNhat.Text = "Cập nhật";


                clsDM_DichVu obj = new clsDM_DichVu();
                obj.GetByKey(MaDM);
                txtMaDichVu.Text = obj.MaDichVu;
                txtTenDichVu.Text = obj.TenDichVu;
                txtDVT.Text = obj.DonViTinh;
                decDonGiaCSKCB.Value = obj.DonGiaCSKCB ?? 0;
                decDonGiaBHYT.Value = obj.DonGiaBHYT ?? 0;
                txtMaLoaiDichVu.Text = obj.MaLoaiDichVu.ToString();
                txtMaNhom1.Text = obj.MaNhom1;


                txtMaNhom2.Text = obj.MaNhom2.ToString();
                cbTrongDanhBaBHYT.Checked = obj.TrongDanhMucBHYT ?? false;
                cbActive.Checked = obj.Active ?? false;
                cbDichVuKTC.Checked = obj.DichVuKTC ?? false;
                txtThongTu.Text = obj.ThongTu;

                txtSoBHYT.Text = obj.STTBYT;
                txtMaKhac.Text = obj.MaKhac;
                txtMaLoaiChiPhi.Text = obj.MaLoaiChiPhi;
                txtMaDichVuBHYT.Text = obj.MaDichVuBYT;
                txtGhiChu.Text = obj.GhiChu;
            }
        }

        private bool CheckTonTai(string strMa)
        {
            bool kq = false;
            clsDM_DichVu obj = new clsDM_DichVu();
            kq = obj.CheckTonTai(strMa);
            return kq;
        }

        private int Insert()
        {
            if (CheckTonTai(txtMaDichVu.Text))
            {
                MessageBox.Show("Mã dịch vụ đã tồn tại.");
                txtMaDichVu.Focus();
                return 0;
            }

            int kq = 0;
            clsDM_DichVu obj = new clsDM_DichVu();            
            obj.MaDichVu = txtMaDichVu.Text;
            obj.TenDichVu = txtTenDichVu.Text;
            obj.DonViTinh = txtDVT.Text;
            obj.DonGiaCSKCB = decDonGiaCSKCB.Value;
            obj.DonGiaBHYT = decDonGiaBHYT.Value;
            obj.GhiChu = txtGhiChu.Text;
            obj.MaLoaiDichVu = txtMaLoaiDichVu.Text;
            obj.MaNhom1 = txtMaNhom1.Text;
            obj.MaNhom2 = txtMaNhom2.Text;            
            
            obj.Active = cbActive.Checked;
            obj.TrongDanhMucBHYT = cbTrongDanhBaBHYT.Checked;
            obj.DichVuKTC = cbDichVuKTC.Checked;

            obj.ThongTu = txtThongTu.Text;
            obj.STTBYT = txtSoBHYT.Text;
            obj.MaDichVuBYT = txtMaDichVuBHYT.Text;
            obj.MaKhac = txtMaKhac.Text;
            obj.MaLoaiChiPhi = txtMaLoaiChiPhi.Text;

            kq = obj.Insert();
            return kq;

        }

        private int Update(string strMa)
        {
            int kq = 0;
            clsDM_DichVu obj = new clsDM_DichVu();
            obj.MaDichVu = strMa;
            obj.GetByKey(strMa);
            obj.TenDichVu = txtTenDichVu.Text;
            obj.DonViTinh = txtDVT.Text;
            obj.DonGiaCSKCB = decDonGiaCSKCB.Value;
            obj.DonGiaBHYT = decDonGiaBHYT.Value;
            obj.GhiChu = txtGhiChu.Text;
            obj.MaLoaiDichVu = txtMaLoaiDichVu.Text;
            obj.MaNhom1 = txtMaNhom1.Text;
            obj.MaNhom2 = txtMaNhom2.Text;

            obj.Active = cbActive.Checked;
            obj.TrongDanhMucBHYT = cbTrongDanhBaBHYT.Checked;
            obj.DichVuKTC = cbDichVuKTC.Checked;

            obj.ThongTu = txtThongTu.Text;
            obj.STTBYT = txtSoBHYT.Text;
            obj.MaDichVuBYT = txtMaDichVuBHYT.Text;
            obj.MaKhac = txtMaKhac.Text;
            obj.MaLoaiChiPhi = txtMaLoaiChiPhi.Text;

            kq = obj.Update();
            return kq;

        }

        private int Delete(string strMaDM)
        {
            int kq = 0;
            clsDM_DichVu obj = new clsDM_DichVu();
            if (MessageBox.Show("Bạn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                kq = obj.Delete(strMaDM);
            }
            return kq;

        }
        
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int kq = 0;
            if (MaDM != "")
            {
                kq = Update(MaDM);
            }
            else
            {
                kq = Insert();
            }

            if (kq == 1)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công.");
            }
        }

        private void txtMaDichVu_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "Bắt buộc";
            if (txtMaDichVu.Text.Length <= 0)
            {
                e.Cancel = true;
                txtMaDichVu.Select(0, txtMaDichVu.Text.Length);

                this.errorProvider.SetError(txtMaDichVu, errorMsg);
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtTenDichVu_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "Bắt buộc";
            if (txtTenDichVu.Text.Length <= 0)
            {
                e.Cancel = true;
                txtTenDichVu.Select(0, txtTenDichVu.Text.Length);

                this.errorProvider.SetError(txtTenDichVu, errorMsg);
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void decDonGiaCSKCB_Enter(object sender, EventArgs e)
        {
            decDonGiaCSKCB.Select(0, decDonGiaCSKCB.Text.Length);
        }

        private void decDonGiaBHYT_Enter(object sender, EventArgs e)
        {
            decDonGiaBHYT.Select(0, decDonGiaBHYT.Text.Length);
        }

        private void frmDanhMucDichVuChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = false;
                e.SuppressKeyPress = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

    }
}
