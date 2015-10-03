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
    public partial class frmDanhMucMauChiTiet : Form
    {

        public string MaDM = "";

        public frmDanhMucMauChiTiet()
        {
            InitializeComponent();
        }
                 
        private void frmDanhMucCSKCBChiTiet_Load(object sender, EventArgs e)
        {
            FillData();           
        }

        private void FillData()
        {
            lblCapNhat.Text = "Thêm";
            if (MaDM != "")
            {
                txtMaMau.Enabled = false;
                lblCapNhat.Text = "Cập nhật";

                clsDM_Mau obj = new clsDM_Mau();
                obj.GetByKey(MaDM);
                txtMaMau.Text = obj.MaMauVaChePhamMau;
                txtTenMau.Text = obj.TenMauVaChePhamMau;
                txtDVT.Text = obj.DonViTinh;
                decDonGiaCSKCB.Value = obj.DonGiaCSKCB ?? 0;
                decDonGiaBHYT.Value = obj.DonGiaBHYT ?? 0;
                txtMaLoai.Text = obj.MaLoaiMauVaChePhamMau.ToString();
                txtMaNhom1.Text = obj.MaNhom1;
                txtMaNhom2.Text = obj.MaNhom2;
                chkBHYT.Checked = obj.TrongDanhMucBHYT ?? false;
                chkActive.Checked = obj.Active ?? false;
                txtThongTu.Text = obj.ThongTu;

                txtSoBHYT.Text = obj.STTBYT;
                txtMaMauBYT.Text = obj.MaMauVaChePhamMauBYT;
                txtGhiChu.Text = obj.GhiChu;
            }
        }

        private bool CheckTonTai(string strMa)
        {
            bool kq = false;
            clsDM_Mau obj = new clsDM_Mau();
            kq = obj.CheckTonTai(strMa);
            return kq;
        }

        private int Insert()
        {
            if (CheckTonTai(txtMaMau.Text))
            {
                MessageBox.Show("Mã Máu Đã Tồn Tại!");
                txtMaMau.Focus();
                return 0;
            }

            int kq = 0;
            clsDM_Mau obj = new clsDM_Mau();            
            obj.MaMauVaChePhamMau = txtMaMau.Text;
            obj.TenMauVaChePhamMau = txtTenMau.Text;
            obj.DonViTinh = txtDVT.Text;
            obj.DonGiaCSKCB = decDonGiaCSKCB.Value;
            obj.DonGiaBHYT = decDonGiaBHYT.Value;            
            obj.MaLoaiMauVaChePhamMau = txtMaLoai.Text;
            obj.MaNhom1 = txtMaNhom1.Text;
            obj.MaNhom2 = txtMaNhom2.Text;
            obj.Active = chkActive.Checked;
            obj.TrongDanhMucBHYT = chkBHYT.Checked;
            obj.ThongTu = txtThongTu.Text;
            obj.STTBYT = txtSoBHYT.Text;
            obj.MaMauVaChePhamMauBYT = txtMaMauBYT.Text;
            obj.GhiChu = txtGhiChu.Text;

            kq = obj.Insert();
            return kq;

        }

        private int Update(string strMa)
        {
            int kq = 0;
            clsDM_Mau obj = new clsDM_Mau();
            obj.MaMauVaChePhamMau = strMa;
            obj.GetByKey(strMa);
            obj.TenMauVaChePhamMau = txtTenMau.Text;
            obj.DonViTinh = txtDVT.Text;
            obj.DonGiaCSKCB = decDonGiaCSKCB.Value;
            obj.DonGiaBHYT = decDonGiaBHYT.Value;
            obj.MaLoaiMauVaChePhamMau = txtMaLoai.Text;
            obj.MaNhom1 = txtMaNhom1.Text;
            obj.MaNhom2 = txtMaNhom2.Text;
            obj.Active = chkActive.Checked;
            obj.TrongDanhMucBHYT = chkBHYT.Checked;
            obj.ThongTu = txtThongTu.Text;
            obj.STTBYT = txtSoBHYT.Text;
            obj.MaMauVaChePhamMauBYT = txtMaMauBYT.Text;
            obj.GhiChu = txtGhiChu.Text;

            kq = obj.Update();
            return kq;

        }

        private int Delete(string strMaDM)
        {
            int kq = 0;
            clsDM_Mau obj = new clsDM_Mau();
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

        private void txtMaMau_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "Bắt buộc";
            if (txtMaMau.Text.Length <= 0)
            {
                e.Cancel = true;
                txtMaMau.Select(0, txtMaMau.Text.Length);

                this.errorProvider.SetError(txtMaMau, errorMsg);
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtTenMau_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "Bắt buộc";
            if (txtTenMau.Text.Length <= 0)
            {
                e.Cancel = true;
                txtTenMau.Select(0, txtTenMau.Text.Length);

                this.errorProvider.SetError(txtTenMau, errorMsg);
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

        private void frmDanhMucMauChiTiet_KeyDown(object sender, KeyEventArgs e)
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
