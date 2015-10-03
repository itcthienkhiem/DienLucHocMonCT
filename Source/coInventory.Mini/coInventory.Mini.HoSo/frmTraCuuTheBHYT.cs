using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
//using WebService.Model;
//using WebService.Model.Utility;

namespace coInventory.Mini.HoSo
{
    public partial class frmTraCuuTheBHYT : Form
    {
        public string SoTheBHYT = "";
        public bool IsOnPush = false;
        public frmTraCuuTheBHYT()
        {
            InitializeComponent();
           
        }
        SystemConfig system = SystemConfig.Instance;
        private void frmTraCuuTheBHYT_Load(object sender, EventArgs e)
        {
            btnChon.Visible = IsOnPush;
            lblLayThongTin.Visible= IsOnPush;
            txtSoTheBHYT.Clear();
            lblHoTen.Text = "";
            lblNgaySinh.Text = "";
            lblNoiDKKCB.Text = "";
            lblThoiGian.Text = "";
            lblMa.Text = "";
            lblDiaChi.Text = "";
            lblGioiTinh.Text = "";
            txtSoTheBHYT.Text = SoTheBHYT;
            lblThongBao.Text = "";
        }

       // public KhoThe thongTinThe = null;

        public delegate void PassControl(object sender);

        public PassControl passControl;

        private void txtSoTheBHYT_TextChanged(object sender, EventArgs e)
        {
            CheckThe();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            //if (thongTinThe != null)
            //{        
            //    Close();
            //}
            //else
            //{
            //    MessageBox.Show("Không có thông tin. Vui lòng kiểm tra lại.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckThe();
        }

        private void CheckThe()
        {
            //lblThongBao.Text = "";
            //if (txtSoTheBHYT.Text.Replace("-", "").Length >= 15)
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
            //        string URL = string.Format("WSGetTheBHYT/{0}", txtSoTheBHYT.Text.Replace("-", ""));
            //        string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL1, "GET", string.Empty, token);
            //        //string str = XMLUtils.DeSerializeToObject<string>(response);
            //        if (!string.IsNullOrEmpty(response))
            //        {
            //            thongTinThe = XMLUtils.DeSerializeToObject<KhoThe>(response);



            //            lblThoiGian.Text = " Từ ngày " + string.Format("{0:dd/MM/yyyy}", thongTinThe.GiaTriTu) + " đến ngày " + string.Format("{0:dd/MM/yyyy}", thongTinThe.GiaTriDen);
            //            lblHoTen.Text = thongTinThe.HoTen;
            //            lblNgaySinh.Text = string.Format("{0:dd/MM/yyyy}", thongTinThe.NgaySinh);
            //            lblDiaChi.Text = thongTinThe.DiaChi;
            //            lblGioiTinh.Text = thongTinThe.GioiTinh == 1 ? "Nam" : "Nữ";
            //            lblMa.Text = thongTinThe.MaThe.Substring(3, 2) + "-" + thongTinThe.MaCSKCBBD;
            //            clsDM_CSKCB obj = new clsDM_CSKCB();
            //            obj.GetByKey(lblMa.Text);
            //            lblNoiDKKCB.Text = obj.TenCSKCB;
            //        }
            //        else
            //        {
            //            lblThongBao.Text = "Không tìm thấy số thẻ này.";
            //        }


            //    }
            //    else
            //    {
            //        txtSoTheBHYT.Clear();
            //        txtSoTheBHYT.SelectionStart = 0;
            //        lblThoiGian.Text ="";
            //        lblHoTen.Text = "";
            //        lblNgaySinh.Text = "";
            //        lblDiaChi.Text = "";
            //        lblGioiTinh.Text = "";
            //        lblMa.Text = "";                 
            //        lblNoiDKKCB.Text = "";
            //    }
           // }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSoTheBHYT.Clear();
            lblThoiGian.Text = "";
            lblHoTen.Text = "";
            lblNgaySinh.Text = "";
            lblDiaChi.Text = "";
            lblGioiTinh.Text = "";
            lblMa.Text = "";
            lblNoiDKKCB.Text = "";
        }
    }
}
