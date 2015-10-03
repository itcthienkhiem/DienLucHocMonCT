using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
using coInventory.Mini.Utilities;
using System.Globalization;

namespace coInventory.Mini.DanhMuc
{
    public partial class frmDanhMucVTYTChiTiet : Form
    {
        public string MaDM = "";
        public frmDanhMucVTYTChiTiet()
        {
            InitializeComponent();
        }

        private void frmDanhMucVTYTChiTiet_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            lblCapNhat.Text = "Thêm";
            if (MaDM != "")
            {
                txtMaVTYT.Enabled = false;
                lblCapNhat.Text = "Cập nhật";

                clsDM_VTYT obj = new clsDM_VTYT();
                obj.GetByKey(MaDM);
                txtMaVTYT.Text = obj.MaVTYT;
                txtTenVTYT.Text = obj.TenVTYT;
                txtDVT.Text = obj.DonViTinh;
                txtTenHoatChat.Text = obj.TenHoatChat;
                txtQuyCach.Text = obj.QuyCach;
                txtNhaSanXuat.Text = obj.NhaSanXuat;
                txtNuocSanXuat.Text = obj.NuocSanXuat;
                txtSoDK.Text = obj.SoDangKy;

                decDonGiaMua.Value = obj.DonGiaMua??0;
                decDonGiaCSKCB.Value = obj.DonGiaCSKCB??0;
                decDonGiaBHYT.Value = obj.DonGiaThau??0;
                chkVTYT_TT.Checked = obj.VTYTThayThe??false;
                chkKTC.Checked = obj.VTYTDichVuKTC??false;
                chkConDung.Checked = obj.Active??false;
                chkBHYT.Checked = obj.TrongDanhMucBHYT??false;
                txtNhom1.Text = obj.MaNhom1;
                txtNhom2.Text = obj.MaNhom2;

                txtHanSuDung.Text = (obj.HanSuDung != null) ? string.Format("{0:dd/MM/yyyy}", obj.HanSuDung) : "";


                chkKTC.Checked = obj.VTYTDichVuKTC??false;
                txtMaVTYTBYT.Text = obj.MaVTYTBYT;

                txtGhiChu.Text = obj.GhiChu;
                intSTTBYT.Text = obj.STTBYT;
                txtMaVTYTBYT.Text = obj.MaVTYTBYT;
                txtTenVTYTBYT.Text = obj.TenVTYTBYT;
            }
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
            if (CheckTonTai(txtMaVTYT.Text))
            {
                MessageBox.Show("Mã VTYT này đã được sử dụng. Xin nhập mã VTYT khác", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaVTYT.Focus();
                return 0;
            }

            int kq = 0;
            clsDM_VTYT obj = new clsDM_VTYT();
            obj.MaVTYT = txtMaVTYT.Text;
            obj.TenVTYT = txtTenVTYT.Text;
            obj.DonViTinh = txtDVT.Text;
            obj.TenHoatChat = txtTenHoatChat.Text;
            obj.QuyCach = txtQuyCach.Text;
            obj.NhaSanXuat = txtNhaSanXuat.Text;
            obj.NuocSanXuat = txtNuocSanXuat.Text;
            obj.SoDangKy = txtSoDK.Text;

            obj.DonGiaMua = decDonGiaMua.Value;
            obj.DonGiaCSKCB = decDonGiaCSKCB.Value;
            obj.DonGiaThau = decDonGiaBHYT.Value;
            obj.VTYTThayThe = chkVTYT_TT.Checked;
            obj.VTYTDichVuKTC = chkKTC.Checked;
            obj.Active = chkConDung.Checked;
            obj.TrongDanhMucBHYT = chkBHYT.Checked;
            obj.MaNhom1 = txtNhom1.Text;
            obj.MaNhom2 = txtNhom2.Text;

            if (txtHanSuDung.Text.Length > 0)
            {
                DateTime dt = DateTime.ParseExact(txtHanSuDung.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj.HanSuDung = dt;
            }
            else
            {
                obj.HanSuDung = null;
            }

            obj.VTYTDichVuKTC = chkKTC.Checked;
            obj.Active = chkConDung.Checked;
            obj.MaVTYTBYT = txtMaVTYTBYT.Text;

            obj.GhiChu = txtGhiChu.Text;
            obj.STTBYT = intSTTBYT.Text;
            obj.MaVTYTBYT = txtMaVTYTBYT.Text;
            obj.TenVTYTBYT = txtTenVTYTBYT.Text;
            kq = obj.Insert();
            return kq;

        }

        private int Update(string strMa)
        {
            int kq = 0;
            clsDM_VTYT obj = new clsDM_VTYT();
            obj.MaVTYT = strMa;
            obj.TenVTYT = txtTenVTYT.Text;
            obj.DonViTinh = txtDVT.Text;
            obj.TenHoatChat = txtTenHoatChat.Text;
            obj.QuyCach = txtQuyCach.Text;
            obj.NhaSanXuat = txtNhaSanXuat.Text;
            obj.NuocSanXuat = txtNuocSanXuat.Text;
            obj.SoDangKy = txtSoDK.Text;

            obj.DonGiaMua = decDonGiaMua.Value;
            obj.DonGiaCSKCB = decDonGiaCSKCB.Value;
            obj.DonGiaThau = decDonGiaBHYT.Value;
            obj.VTYTThayThe = chkVTYT_TT.Checked;
            obj.VTYTDichVuKTC = chkKTC.Checked;
            obj.Active = chkConDung.Checked;
            obj.TrongDanhMucBHYT = chkBHYT.Checked;
            obj.MaNhom1 = txtNhom1.Text;
            obj.MaNhom2 = txtNhom2.Text;

            if (txtHanSuDung.Text.Length > 0)
            {
                DateTime dt = DateTime.ParseExact(txtHanSuDung.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj.HanSuDung = dt;
            }
            else
            {
                obj.HanSuDung = null;
            }

            obj.VTYTDichVuKTC = chkKTC.Checked;
            obj.Active = chkConDung.Checked;
            obj.MaVTYTBYT = txtMaVTYTBYT.Text;

            obj.GhiChu = txtGhiChu.Text;
            obj.STTBYT = intSTTBYT.Text;
            obj.MaVTYTBYT = txtMaVTYTBYT.Text;
            obj.TenVTYTBYT = txtTenVTYTBYT.Text;
            kq = obj.Update();
            return kq;

        }

        private int Delete(string strMaDM)
        {
            int kq = 0;
            clsDM_VTYT obj = new clsDM_VTYT();
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
                MessageBox.Show("Cập nhật dữ liệu thành công!.");
            }

        }

        private void txtMaVTYT_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "Bắt buộc";
            if (txtMaVTYT.Text.Length <= 0)
            {
                e.Cancel = true;
                txtMaVTYT.Select(0, txtMaVTYT.Text.Length);

 
                this.errorProvider.SetError(txtMaVTYT, errorMsg);
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtTenVTYT_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "Bắt buộc";
            if (txtTenVTYT.Text.Length <= 0)
            {
                e.Cancel = true;
                txtTenVTYT.Select(0, txtTenVTYT.Text.Length);

                this.errorProvider.SetError(txtTenVTYT, errorMsg);
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtHanSuDung_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "Không hợp lệ";
            try
            {
                if (txtHanSuDung.Text.Length > 0)
                {
                    DateTime dt = DateTime.ParseExact(txtHanSuDung.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                   
                }
                errorProvider.Clear();
            }
            catch
            {
                e.Cancel = true;
                this.errorProvider.SetError(txtHanSuDung, errorMsg);

            }
        }

        private void frmDanhMucVTYTChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = false;
                e.SuppressKeyPress = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void decDonGiaMua_Enter(object sender, EventArgs e)
        {
            decDonGiaMua.Select(0, decDonGiaMua.Text.Length);
        }

        private void decDonGiaCSKCB_Enter(object sender, EventArgs e)
        {
            decDonGiaCSKCB.Select(0, decDonGiaCSKCB.Text.Length);
        }

        private void decDonGiaBHYT_Enter(object sender, EventArgs e)
        {
            decDonGiaBHYT.Select(0, decDonGiaBHYT.Text.Length);
        }


        private void intSTTBYT_Enter(object sender, EventArgs e)
        {
            intSTTBYT.Select(0, intSTTBYT.Text.Length);
        }

    }
}
