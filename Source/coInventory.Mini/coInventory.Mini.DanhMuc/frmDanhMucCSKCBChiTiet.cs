using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using eHospital.Mini.EntityClass;
using eHospital.Mini.Utilities;
using eHospital.Mini.DanhMuc.XuLy;
using clsDanhMucAbtract;

namespace eHospital.Mini.DanhMuc
{
    public partial class frmDanhMucCSKCBChiTiet : clsAbGiaoDien
    {
        public clsDM_CSKCB objDM_CSKCB = new clsDM_CSKCB();
        //clsSuKienCSKCB objkcb = null;
        public frmDanhMucCSKCBChiTiet()
        {
            InitializeComponent();
            //objkcb = kcb;
        }
        public void Reset()
        {
            cbbMaCSKCB.Text = "";
            txtMaTinh.Text = "";
            txtTenCSKCB.Text = "";
            cbCSKCBBD.Text = "";
            txtXepHang.Text = "";
            cbActive.Text = "";
            txtDiaChi.Text = "";
            txtTuyen.Text = "";
            txtQuy1Quy.Text = "";
            cbCSDL.Text = "";
         
            txtMaCapTren.Text = "";
        }
        private void frmDanhMucCSKCBChiTiet_Load(object sender, EventArgs e)
        {
            objDM_CSKCB = (clsDM_CSKCB)base.obj;
            if (objDM_CSKCB != null && objDM_CSKCB.CSKCB_Id > 0)
            {
                cbbMaCSKCB.Text = objDM_CSKCB.MaCSKCB;
                txtMaTinh.Text = objDM_CSKCB.MaTinh;
                txtTenCSKCB.Text = objDM_CSKCB.TenCSKCB;
                cbCSKCBBD.Checked = objDM_CSKCB.CSKCBBanDau;
                txtXepHang.Text = objDM_CSKCB.XepHang.ToString();
                cbActive.Checked = objDM_CSKCB.Active;
                txtDiaChi.Text = objDM_CSKCB.DiaChi;
                txtTuyen.Text = objDM_CSKCB.Tuyen.ToString();
                txtQuy1Quy.Text = objDM_CSKCB.Quy1Quy.ToString();
                cbCSDL.Checked = objDM_CSKCB.CoDuLieu;
              
                txtMaCapTren.Text = objDM_CSKCB.MaCapTren;
                //dtpHanSuDung.Value = objDM_Thuoc.mHanSuDung;

            }
            else Reset();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        //public delegate void CapNhatDuLieu(clsDM_CSKCB sender);

        //// Create instance (null)
        //public CapNhatDuLieu capNhat;

        private  void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (objDM_CSKCB == null)
                objDM_CSKCB = new clsDM_CSKCB();
            objDM_CSKCB.MaCSKCB = cbbMaCSKCB.Text;
            objDM_CSKCB.MaTinh = txtMaTinh.Text;
            objDM_CSKCB.TenCSKCB = txtTenCSKCB.Text;
            objDM_CSKCB.CSKCBBanDau = cbCSKCBBD.Checked;
            objDM_CSKCB.XepHang =int.Parse( txtXepHang.Text );
            objDM_CSKCB.Active =cbActive .Checked;
            objDM_CSKCB.DiaChi = txtDiaChi.Text;
            objDM_CSKCB.Tuyen = int.Parse(txtTuyen.Text);
            objDM_CSKCB.Quy1Quy = decimal.Parse(txtQuy1Quy.Text) ;
            objDM_CSKCB.CoDuLieu = cbCSDL.Checked;
           
            objDM_CSKCB.MaCapTren = txtMaCapTren.Text;

            capNhat(objDM_CSKCB,objDM_CSKCB.CSKCB_Id);
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
