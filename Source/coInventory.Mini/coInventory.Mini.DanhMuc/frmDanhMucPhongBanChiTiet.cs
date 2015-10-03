using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
namespace coInventory.Mini.DanhMuc
{
    public partial class frmDanhMucPhongBanChiTiet : Form
    {
        public string MaPhongBan;
        public frmDanhMucPhongBanChiTiet()
        {
            InitializeComponent();
        }
        private void FillData()
        {
            lblCapNhat.Text = "Thêm";
            if (MaPhongBan !=null&& MaPhongBan != "")
            {
                txtMaPhongBan.Enabled = false;
                lblCapNhat.Text = "Cập nhật";


                clsDM_PhongBan obj = new clsDM_PhongBan();
                obj.GetByKey(MaPhongBan);
                txtMaPhongBan.Text = obj.MaPhongBan;
                txtTenPhongBan.Text = obj.TenPhongBan;
                txtLoaiPhongBan.Text = obj.LoaiPhongBan;

                 cbActive.Checked=(bool)obj.Active ;
            }
        }
        private int Insert()
        {
            
            int kq = 0;
            clsDM_PhongBan obj = new clsDM_PhongBan();
            if (obj.CheckTonTai(txtMaPhongBan.Text)==true)
            {
                MessageBox.Show("Mã Phòng Ban Đã Tồn Tại!");
                txtMaPhongBan.Focus();
                return 0;
            }
            obj.MaPhongBan = txtMaPhongBan.Text;
            obj.TenPhongBan = txtTenPhongBan.Text;
            obj.LoaiPhongBan = txtLoaiPhongBan.Text;
            

            obj.Active = cbActive.Checked;
            

            kq = obj.Insert();
            return kq;

        }

        private void frmDanhMucPhongBanChiTiet_Load(object sender, EventArgs e)
        {
            FillData();
        }
        private int Update(string strMa)
        {
            int kq = 0;
            clsDM_PhongBan obj = new clsDM_PhongBan();
            obj.MaPhongBan = strMa;
            obj.GetByKey(strMa);
            obj.TenPhongBan = txtTenPhongBan.Text;
            obj.LoaiPhongBan = txtLoaiPhongBan.Text;
           

            obj.Active = cbActive.Checked;
            kq = obj.Update();
            return kq;

        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int kq = 0;
            if (MaPhongBan!=null&& MaPhongBan != "")
            {
                kq = Update(MaPhongBan);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaPhongBan_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "Bắt buộc";
            if (txtMaPhongBan.Text.Length <= 0)
            {
                e.Cancel = true;
                txtMaPhongBan.Select(0, txtMaPhongBan.Text.Length);

                this.errorProvider.SetError(txtMaPhongBan, errorMsg);
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtTenPhongBan_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "Bắt buộc";
            if (txtTenPhongBan.Text.Length <= 0)
            {
                e.Cancel = true;
                txtTenPhongBan.Select(0, txtTenPhongBan.Text.Length);

                this.errorProvider.SetError(txtTenPhongBan, errorMsg);
            }
            else
            {
                errorProvider.Clear();
            }
        }
    }
}
