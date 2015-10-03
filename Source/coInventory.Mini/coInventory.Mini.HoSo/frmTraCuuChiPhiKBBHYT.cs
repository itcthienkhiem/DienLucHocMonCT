using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using WebService.Model;
using coInventory.Mini.EntityClass;
//using WebService.Model.Utility;

namespace coInventory.Mini.HoSo
{
    public partial class frmTraCuuChiPhiKBBHYT : Form
    {
        SystemConfig system = SystemConfig.Instance;
        //private KhoThe thongTinThe = null;

        public frmTraCuuChiPhiKBBHYT()
        {
            InitializeComponent();
            resetData();
        }

        private void Load_TheBHYT()
        {
            lblThongBao.Text = "";
            if (txtSoTheBHYT.Text.Replace("-", "").Length >= 15)
            {
                SystemConfig system = SystemConfig.Instance;
                string token = system.GetToken();
                if (string.IsNullOrEmpty(token))
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!string.IsNullOrEmpty(token))
                {
                    string URL = string.Format("WSGetTheBHYT/{0}", txtSoTheBHYT.Text.Replace("-", ""));
                    string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL1, "GET", string.Empty, token);
                    //string str = XMLUtils.DeSerializeToObject<string>(response);
                    if (!string.IsNullOrEmpty(response))
                    {
                        //thongTinThe = XMLUtils.DeSerializeToObject<KhoThe>(response);

                        //lblThoiGian.Text = " Từ ngày " + string.Format("{0:dd/MM/yyyy}", thongTinThe.GiaTriTu) + " đến ngày " + string.Format("{0:dd/MM/yyyy}", thongTinThe.GiaTriDen);
                        //lblHoTen.Text = thongTinThe.HoTen;
                        //lblNgaySinh.Text = string.Format("{0:dd/MM/yyyy}", thongTinThe.NgaySinh);
                        //lblGioiTinh.Text = thongTinThe.GioiTinh == 1 ? "Nam" : "Nữ";
                        //lblMaKCB.Text = thongTinThe.MaThe.Substring(3, 2) + "-" + thongTinThe.MaCSKCBBD;
                        //clsDM_CSKCB obj = new clsDM_CSKCB();
                        //obj.GetByKey(lblMaKCB.Text);
                        //lblNoiDKKCB.Text = obj.TenCSKCB;
                    }
                    else
                    {
                        lblThongBao.Text = "Không tìm thấy số thẻ này.";
                        resetData();
                    }


                }
                else
                {
                    txtSoTheBHYT.Clear();
                    resetData();
                }
            }
            else
            {
                resetData();
            }
        }

        private void Load_ChiPhi()
        {
            SystemConfig system = SystemConfig.Instance;
            string token = system.GetToken();
            if (string.IsNullOrEmpty(token))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string URL = "WSGetChiPhiKCBBHYT/" + txtSoTheBHYT.Text.Replace("-", "");
            string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL, "GET", string.Empty, token);
            if (!string.IsNullOrEmpty(response) && response.IndexOf("Error:") == -1)
            {

                try
                {
                    ////List<History> lstDMCHIPHI = XMLUtils.DeSerializeToList<History>(response);
                    //clsDM_CSKCB kcb = new clsDM_CSKCB();


                    //for (int i = 0; i < lstDMCHIPHI.Count; i++)
                    //{
                    //    DataRow toInsert = TbTongChiPhiKCBBHYT.NewRow();
                    //    toInsert["SoTheBHYT"] = lstDMCHIPHI[i].SoTheBHYT;
                    //    toInsert["HoTen"] = lstDMCHIPHI[i].HoTen;
                    //    toInsert["GioiTinh"] = lstDMCHIPHI[i].GioiTinh;
                    //    toInsert["NgaySinh"] = !string.IsNullOrEmpty(lstDMCHIPHI[i].NgaySinh.ToString()) ? (object)lstDMCHIPHI[i].NgaySinh : (object)DBNull.Value;
                    //    string maCSKCB = lstDMCHIPHI[i].MaCSKCB;
                    //    kcb.GetByKey(maCSKCB);
                    //    toInsert["TenCSKCB"] = kcb.TenCSKCB;
                    //    toInsert["TongChiPhi"] = lstDMCHIPHI[i].TongChiPhi;
                    //    toInsert["BHYTThanhToan"] = lstDMCHIPHI[i].BHYTThanhToan;
                    //    toInsert["NguoiBenhTra"] = !string.IsNullOrEmpty(lstDMCHIPHI[i].NguoiBenhTra.ToString()) ? (object)lstDMCHIPHI[i].NguoiBenhTra : (object)DBNull.Value;
                    //    toInsert["NgayDenKham"] = !string.IsNullOrEmpty(lstDMCHIPHI[i].NgayDenKham.ToString()) ? lstDMCHIPHI[i].NgayDenKham : (object)DBNull.Value;
                    //    // toInsert["NgayQuyetToan"] = !string.IsNullOrEmpty(lstDMCHIPHI[i].NgayQuyetToan.ToString()) ? lstDMCHIPHI[i].NgayQuyetToan : (object)DBNull.Value;
                    //    toInsert["NgayThanhToan"] = !string.IsNullOrEmpty(lstDMCHIPHI[i].NgayQuyetToan.ToString()) ? lstDMCHIPHI[i].NgayQuyetToan : (object)DBNull.Value;
                    //    TbTongChiPhiKCBBHYT.Rows.Add(toInsert);

                    //    //TbTongChiPhiKCBBHYT.Rows[i]["NgayThanhToan"] = lstDMCHIPHI[i].NgayQuyetToan;
                    //    //TbTongChiPhiKCBBHYT.Rows[i]["SoTheBHYT"] = lstDMCHIPHI[i].SoTheBHYT;
                    //    //TbTongChiPhiKCBBHYT.Rows[i]["HoTen"] = lstDMCHIPHI[i].HoTen;
                    //    //TbTongChiPhiKCBBHYT.Rows[i]["GioiTinh"] = lstDMCHIPHI[i].GioiTinh;
                    //    //TbTongChiPhiKCBBHYT.Rows[i]["NgaySinh"] = lstDMCHIPHI[i].NgaySinh;
                    //    //TbTongChiPhiKCBBHYT.Rows[i]["TenCSKCB"] = lstDMCHIPHI[i].MaCSKCB;
                    //    //TbTongChiPhiKCBBHYT.Rows[i]["TongChiPhi"] = lstDMCHIPHI[i].TongChiPhi;
                    //    //TbTongChiPhiKCBBHYT.Rows[i]["BHYTThanhToan"] = lstDMCHIPHI[i].BHYTThanhToan;
                    //    //TbTongChiPhiKCBBHYT.Rows[i]["NguoiBenhTra"] = lstDMCHIPHI[i].NguoiBenhTra;
                    //    //TbTongChiPhiKCBBHYT.Rows[i]["NgayDenKham"] = lstDMCHIPHI[i].NgayDenKham;
                   // }
                   // grdDM_KCB.DataSource = TbTongChiPhiKCBBHYT;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }   
        private void txtSoTheBHYT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = false;
                e.SuppressKeyPress = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }          
        }

        private void txtSoTheBHYT_Validated(object sender, EventArgs e)
        {
            Load_TheBHYT();
            Load_ChiPhi();       
        }

        private void resetData()
        {
            txtSoTheBHYT.Text = "";
            lblGioiTinh.Text = "";
            lblHoTen.Text = "";
            lblMaKCB.Text = "";
            lblNoiDKKCB.Text = "";
            lblNgaySinh.Text = "";
            lblThoiGian.Text = "";
            lblThongBao.Text = "";
            TbTongChiPhiKCBBHYT.Clear();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Load_TheBHYT();
            Load_ChiPhi();      
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetData();
        }
    }
}
