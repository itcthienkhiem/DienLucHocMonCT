using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
using System.Globalization;

namespace coInventory.Mini.DanhMuc
{
    public partial class frmDanhMucThuocChiTiet : Form
    {
        public string MaDM = "";
        public frmDanhMucThuocChiTiet()
        {
            InitializeComponent();
        }

        private void frmDanhMucThuocChiTiet_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            lblCapNhat.Text = "Thêm";
            if (MaDM != "")
            {
                txtMaThuoc.Enabled = false;
                lblCapNhat.Text = "Cập nhật";


                clsDM_Thuoc obj = new clsDM_Thuoc();
                obj.GetByKey(MaDM);
                txtMaThuoc.Text = obj.MaThuoc;
                txtTenThuoc.Text = obj.TenThuoc;
                txtDVT.Text = obj.DonViTinh;
                txtTenHoatChat.Text = obj.TenHoatChat;
                txtQuyCach.Text = obj.QuyCach;
                txtNhaSanXuat.Text = obj.NhaSanXuat;
                txtNuocSanXuat.Text = obj.NuocSanXuat;
                txtSoDK.Text = obj.SoDangKy;

                intNam.Text = obj.Nam.ToString();

                decDonGiaMua.Value = obj.DonGiaMua??0;
                decDonGiaCSKCB.Value = obj.DonGiaCSKCB??0;
                decDonGiaBHYT.Value = obj.DonGiaThau??0;

                chkConDung.Checked = obj.Active??false;
                chkBHYT.Checked = obj.TrongDanhMucBHYT??false;
                txtNhom1.Text = obj.MaNhom1;
                txtNhom2.Text = obj.MaNhom2;

                txtHanSuDung.Text = (obj.HanSuDung != null) ? string.Format("{0:dd/MM/yyyy}", obj.HanSuDung) : "";
                txtGhiChu.Text = obj.GhiChu;
                intSTTBYT.Text = obj.STTBYT;
                txtMaThuocBYT.Text = obj.MaThuocBYT;
                txtTenThuocBYT.Text = obj.TenThuocBYT;
            }
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
            if (CheckTonTai(txtMaThuoc.Text))
            {
                MessageBox.Show("Mã thuốc này đã được sử dụng. Xin nhập mã thuốc khác", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaThuoc.Focus();
                return 0;
            }

            int kq = 0;
            clsDM_Thuoc obj = new clsDM_Thuoc();
            obj.MaThuoc = txtMaThuoc.Text;
            obj.TenThuoc = txtTenThuoc.Text;
            obj.TenHoatChat = txtTenHoatChat.Text;
            obj.DonViTinh = txtDVT.Text;
            obj.TenHoatChat = txtTenHoatChat.Text;
            obj.QuyCach = txtQuyCach.Text;
            obj.NhaSanXuat = txtNhaSanXuat.Text;
            obj.NuocSanXuat = txtNuocSanXuat.Text;
            obj.SoDangKy = txtSoDK.Text;

            obj.DonGiaMua = decDonGiaMua.Value;
            obj.DonGiaCSKCB = decDonGiaCSKCB.Value;
            obj.DonGiaThau = decDonGiaBHYT.Value;
            obj.MaNhom1 = txtNhom1.Text;
            obj.MaNhom2 = txtNhom2.Text;
            obj.STTBYT = intSTTBYT.Text;
            obj.MaThuocBYT = txtMaThuocBYT.Text;
            obj.TenThuocBYT = txtTenThuocBYT.Text;
            obj.GhiChu = txtGhiChu.Text;

            if (txtHanSuDung.Text.Length > 0)
            {
                DateTime dt = DateTime.ParseExact(txtHanSuDung.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj.HanSuDung = dt;
            }
            else
            {
                obj.HanSuDung = null;
            }
            obj.DonViTinh = txtDVT.Text;
            obj.Active = chkConDung.Checked;
            obj.TrongDanhMucBHYT = chkBHYT.Checked;
            obj.SoDangKy = txtSoDK.Text;

            kq = obj.Insert();
            return kq;

        }

        private int Update(string strMa)
        {
            int kq = 0;
            clsDM_Thuoc obj = new clsDM_Thuoc();
            obj.MaThuoc = strMa;
            obj.GetByKey(strMa);
            obj.TenThuoc = txtTenThuoc.Text;
            obj.TenHoatChat = txtTenHoatChat.Text;
            obj.DonViTinh = txtDVT.Text;
            obj.TenHoatChat = txtTenHoatChat.Text;
            obj.QuyCach = txtQuyCach.Text;
            obj.NhaSanXuat = txtNhaSanXuat.Text;
            obj.NuocSanXuat = txtNuocSanXuat.Text;
            obj.SoDangKy = txtSoDK.Text;

            obj.DonGiaMua = decDonGiaMua.Value;
            obj.DonGiaCSKCB = decDonGiaCSKCB.Value;
            obj.DonGiaThau = decDonGiaBHYT.Value;
            obj.MaNhom1 = txtNhom1.Text;
            obj.MaNhom2 = txtNhom2.Text;
            obj.STTBYT = intSTTBYT.Text;
            obj.MaThuocBYT = txtMaThuocBYT.Text;
            obj.TenThuocBYT = txtTenThuocBYT.Text;
            obj.GhiChu = txtGhiChu.Text;

            if (txtHanSuDung.Text.Length > 0)
            {
                DateTime dt = DateTime.ParseExact(txtHanSuDung.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj.HanSuDung = dt;
            }
            else
            {
                obj.HanSuDung = null;
            }
            obj.DonViTinh = txtDVT.Text;
            obj.Active = chkConDung.Checked;
            obj.TrongDanhMucBHYT = chkBHYT.Checked;
            obj.SoDangKy = txtSoDK.Text;

            kq = obj.Update();
            return kq;

        }

        private int Delete(string strMaDM)
        {
            int kq = 0;
            clsDM_Thuoc obj = new clsDM_Thuoc();
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

        private void txtMaThuoc_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "Bắt buộc";
            if (txtMaThuoc.Text.Length <= 0)
            {
                e.Cancel = true;
                txtMaThuoc.Select(0, txtMaThuoc.Text.Length);

                this.errorProvider.SetError(txtMaThuoc, errorMsg);
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtTenThuoc_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "Bắt buộc";
            if (txtTenThuoc.Text.Length <= 0)
            {
                e.Cancel = true;
                txtTenThuoc.Select(0, txtTenThuoc.Text.Length);

                this.errorProvider.SetError(txtTenThuoc, errorMsg);
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

        private void frmDanhMucThuocChiTiet_KeyDown(object sender, KeyEventArgs e)
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

        private void intNam_Enter(object sender, EventArgs e)
        {
            intNam.Select(0, intNam.Text.Length);
        }




    }
}
