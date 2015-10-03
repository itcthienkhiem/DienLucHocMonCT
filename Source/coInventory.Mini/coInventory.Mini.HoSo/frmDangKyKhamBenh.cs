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
using System.Globalization;

namespace coInventory.Mini.HoSo
{
   
    public partial class frmDangKyKhamBenh : Form
    {
        enum TrangThai
        {
            ThemMoi,
            Xoa,
            Sua,
            Khac
        };
        public int m_LoaiBangKe = 1;

        TrangThai _TrangThai;
        private DataTable dtCSKCB = null;
        SystemConfig sys = SystemConfig.Instance;
        public frmDangKyKhamBenh()
        {
            InitializeComponent();
            _TrangThai = TrangThai.Khac;

        }

        private void frmDangKyKhamBenh_Load(object sender, EventArgs e)
        {
            //btnCheckThe.Enabled = true;
            lblThongBao.Text = "";
            SetControlStatusReadOnly(true);
            LoadDataCombobox();

        }
        private void LoadDataCombobox()
        {


            //Load data cbo mã nơi sinh sống - 3 nơi: K1, K2, K3
            cboMaNoiSinhSong.DisplayMember = "Name";
            cboMaNoiSinhSong.ValueMember = "Value";
            cboMaNoiSinhSong.DataSource = Utilities.Utils.GetKhuVucSong();
            //Load gioi tinh
            cboGioiTinh.DataSource = Utilities.Utils.GetGioiTinh();
            cboGioiTinh.DisplayMember = "Name";
            cboGioiTinh.ValueMember = "Value";
            //Load gioi tinh
            cboTuyenKham.DataSource = Utilities.Utils.GetTuyenKham();
            cboTuyenKham.DisplayMember = "Name";
            cboTuyenKham.ValueMember = "Value";
            clsDM_CSKCB cskcb = new clsDM_CSKCB();
            dtCSKCB = cskcb.GetAll();

            //
            txtNoiChuyenDen.Values = dtCSKCB;
            List<CDisplayColumns> lstColCSKCB = new List<CDisplayColumns>();
            lstColCSKCB.Add(new CDisplayColumns("MaCSKCB", "Mã CSKCB", true, true));
            lstColCSKCB.Add(new CDisplayColumns("TenCSKCB", "Tên CSKCB", true, true));

            txtNoiChuyenDen.DisplayColumns = lstColCSKCB;
        }
        private void SetControlStatusReadOnly(bool statusControl)
        {
            txtSoDKKBBHYT.Enabled = statusControl;
            txtNoiChuyenDen.ReadOnly = statusControl;
            //txtSoNgay.ReadOnly = statusControl;
            txtDiaChi.ReadOnly = statusControl;
            cboMaNoiSinhSong.Enabled = !statusControl;
            txtHoTen.ReadOnly   = statusControl;
            txtTuNgay.ReadOnly = statusControl;
            //txtTuNgay.BatBuocNhap = !statusControl;
            txtDenNgay.ReadOnly = statusControl;
            txtNgaySinh.ReadOnly = statusControl;
            // txtNamSinh.ReadOnly = statusControl;
            cboGioiTinh.Enabled = !statusControl; ;
            cboTuyenKham.Enabled = !statusControl;
            //   txtMaICD.Enabled = !statusControl;
            txtMaCSKCBBD.Enabled = !statusControl;
            //   txtChanDoan.ReadOnly = statusControl;
            chkChungTuKhongCCT.Enabled = !statusControl;
            txtNgayVao.ReadOnly = statusControl;
            btnKiemTraSDK.Enabled = statusControl;

            //btnXoa.Enabled = false;
            //btnSua.Enabled = false;


        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _TrangThai = TrangThai.ThemMoi;
            //      m_BangKe_Id = 0;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            btnLuu.Enabled = true;
            btnHuyBo.Enabled = true;

            btnCheckThe.Enabled = true;
            txtSoDKKBBHYT.Enabled = false;

            SetControlStatusReadOnly(false);


            ResetControl();
            txtSoTheBHYT.Focus();
        }

        private void ResetControl()
        {
            txtSoDKKBBHYT.Text = string.Empty;
            txtSoTheBHYT.Clear();

            txtNoiChuyenDen.Text = string.Empty;

            txtDiaChi.Text = string.Empty;
            cboMaNoiSinhSong.SelectedIndex = 0;
            txtHoTen.Text = string.Empty;


            txtTuNgay.Text = string.Empty;

            txtDenNgay.Text = string.Empty;


            txtNgaySinh.Text = string.Empty;

            cboGioiTinh.SelectedIndex = 0;
            cboTuyenKham.SelectedValue = "1";

            txtMaCSKCBBD.Text = string.Empty;
            txtMaCSKCBBD.ClearSelection();
            txtMaCSKCBBD.Values = null;

            txtTenCSKCBBD.Clear();

            chkChungTuKhongCCT.Checked = false;

            txtNgayVao.Text = string.Empty;



            DateTime now = DateTime.Now;

            txtNgayVao.Text = string.Format("{0:dd/MM/yyyy}", now);



        }

        private void btnCheckThe_Click(object sender, EventArgs e)
        {
            //frmTraCuuTheBHYT frm = new frmTraCuuTheBHYT();
            //frm.SoTheBHYT = txtSoTheBHYT.Text;
            //frm.IsOnPush = true;
            ////frm.passControl = new frmTraCuuTheBHYT.PassControl(PassData);
            //frm.ShowDialog();
            //if (frm.thongTinThe != null)
            //{
            //    PassData(frm.thongTinThe);
            //}
        }
        private void txtMaCSKCBBD_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                clsDM_CSKCB obj = new clsDM_CSKCB();
                obj.GetByKey(txtMaCSKCBBD.Text);
                txtTenCSKCBBD.Text = obj.TenCSKCB;
                CheckDungTuyen();
            }
            catch { }
        }

        private void CheckDungTuyen()
        {
            if (sys.MaCSKCB.Trim() == txtMaCSKCBBD.Text)
            {
                cboTuyenKham.SelectedValue = "1";
                txtNoiChuyenDen.Focus();
            }
            else
            {
                cboTuyenKham.SelectedValue = "0";
                txtNgayVao.Focus();
            }
        }

        private void PassData(object sender)
        {
            //KhoThe the = (KhoThe)sender;
            //txtSoTheBHYT.Text = the.MaThe;
            //txtHoTen.Text = the.HoTen;
            //txtTuNgay.Text = string.Format("{0:dd/MM/yyyy}", the.GiaTriTu);
            //txtDenNgay.Text = string.Format("{0:dd/MM/yyyy}", the.GiaTriDen);
            //txtNgaySinh.Text = string.Format("{0:dd/MM/yyyy}", the.NgaySinh);
            //cboGioiTinh.SelectedValue = the.GioiTinh.ToString();
            //string macskcb = the.MaThe.Substring(3, 2) + "-" + the.MaCSKCBBD;
            //clsDM_CSKCB obj = new clsDM_CSKCB();
            //obj.GetByKey(macskcb);

            //txtDiaChi.Text = the.DiaChi;
            //txtNgayVao_Validated(null, null);
            //txtMaCSKCBBD_Validating(null, null);

            //txtMaCSKCBBD.Text = macskcb;
            //txtTenCSKCBBD.Text = obj.TenCSKCB;
            //Load_ChiPhi();

        }       
                
        private void LoadMaCSKCBTheoMaTinh()
        {

            string maTinh = txtSoTheBHYT.Text.Replace("-", "").Substring(3, 2);
            if (maTinh != "")
            {

                string expression = "[MaTinh] ='" + maTinh + "'";
                string sortOrder = "[MaCSKCB] ASC";
                DataView dv = new DataView(dtCSKCB, expression, sortOrder, DataViewRowState.CurrentRows);
                txtMaCSKCBBD.Values = dv.ToTable("CSKCB");
                List<CDisplayColumns> lstColCSKCB = new List<CDisplayColumns>();
                lstColCSKCB.Add(new CDisplayColumns("MaCSKCB", "Mã CSKCB", true, true));
                lstColCSKCB.Add(new CDisplayColumns("TenCSKCB", "Tên CSKCB", true, true));
                txtMaCSKCBBD.DisplayColumns = lstColCSKCB;
            }

        }
        private bool Save()
        {





            //if (txtSoTheBHYT.Text == "")
            //{
            //    MessageBox.Show("Bạn chưa nhập số thẻ BHYT.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
            //    return false;
            //}
            //clsDangKyKhamBenh objDangKy = new clsDangKyKhamBenh();
            //objDangKy.MaCSKCB = txtMaCSKCBBD.Text;
            //objDangKy.MaCSKCBBĐ = txtMaCSKCBBD.Text;
            //objDangKy.SoTheBHYT = txtSoTheBHYT.Text;
            //objDangKy.TuNgay = txtTuNgay.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtTuNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            //objDangKy.DenNgay = txtDenNgay.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtDenNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            //objDangKy.HoTen = txtHoTen.Text;
            //objDangKy.NgaySinh = txtNgaySinh.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            //objDangKy.GioiTinh = int.Parse((cboGioiTinh.SelectedValue.ToString()));
            //objDangKy.DiaChi = txtDiaChi.Text;
            //objDangKy.MaNoiSinhSong = cboMaNoiSinhSong.Text;
            //objDangKy.LyDoVV = int.Parse(cboTuyenKham.SelectedValue.ToString());
            //objDangKy.MaNoiChuyenDen = txtNoiChuyenDen.Text;
            //objDangKy.ChungNhanKhongCTT = (chkChungTuKhongCCT.Checked);
            //objDangKy.GhiChu = "";
            //objDangKy.NgayDenKham = txtNgayVao.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtNgayVao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            //DangKyKhamBenh item = new DangKyKhamBenh();
            //item.MaCSKCB = objDangKy.MaCSKCB;
            //item.MaCSKCBBanDau = objDangKy.MaCSKCBBĐ;
            //item.SoTheBHYT = objDangKy.SoTheBHYT.Replace("-", "");
            //item.HoTen = objDangKy.HoTen;
            //item.NgaySinh = objDangKy.NgaySinh;
            //item.NamSinh = string.IsNullOrEmpty(objDangKy.NgaySinh.ToString()) ? 0 : objDangKy.NgaySinh.Value.Year;
            //item.GioiTinh = byte.Parse(objDangKy.GioiTinh.ToString());
            //item.DiaChi = objDangKy.DiaChi;
            //item.MaNoiSinhSong = objDangKy.MaNoiSinhSong;
            //item.ChungNhanKhongCTT = objDangKy.ChungNhanKhongCTT;
            //item.SuDungTu = (DateTime)objDangKy.TuNgay;
            //item.SuDungDen = (DateTime)objDangKy.DenNgay;
            //item.LyDoVV = byte.Parse(objDangKy.LyDoVV.ToString());
            //item.NgayDenKham = (DateTime)objDangKy.NgayDenKham;
            //item.MaNoiChuyenDen = objDangKy.MaNoiChuyenDen;
            //item.GhiChu = objDangKy.GhiChu;
            //item.ChungNhanKhongCTT = objDangKy.ChungNhanKhongCTT;
            //string requestData = null;// XMLUtils.SerializeDataContract(item);

            //SystemConfig system = SystemConfig.Instance;
            //string token = system.GetToken();
            //if (string.IsNullOrEmpty(token))
            //{
            //    MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            //string URL = "WSPutDangKyKCBBHYT";
            //string response = system.SendRequest(URL, "POST", requestData); //HttpRequest.WSRequest(URL, "POST", requestData, token); 
            
            //if (string.IsNullOrEmpty(response))
            //{
            //    MessageBox.Show("Kiểm tra cấu hình và kết nối mạng.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}

            //string value = XMLUtils.DeSerializeToObject<string>(response);
            //if (!string.IsNullOrEmpty(response) && response.IndexOf("Error:") == -1)
            //{
                
            //    if (int.Parse(value) != 0)
            //    {
            //        txtSoDKKBBHYT.Text = value;
            //        objDangKy.SoDKKCBBHYT = int.Parse(value);
            //        if (objDangKy.Insert() == 1)
            //        {
            //           // MessageBox.Show("Bạn đã đăng ký thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            //lblThongBao.ForeColor = Color.Red;
            //            lblThongBao.Text = "Bạn đã đăng ký thành công.";
            //            timerThongBao.Enabled = true;
            //            return true;
            //        }

            //        else
            //        {
            //            MessageBox.Show("Có lỗi xảy ra trong quá trình thêm, vui lòng kiểm tra lại dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return false;
            //        }
            //    }
            //}
            //else
            //{
            //    if (value.IndexOf("MaCSKCB") == -1)
            //    {
            //        MessageBox.Show("Đã có lỗi xảy ra trong quá trình đăng ký, vui lòng kiểm tra kết nối server.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //    else
            //    {
            //        clsDM_CSKCB kcb = new clsDM_CSKCB();
            //        string[] maCSKCB = value.Replace("Error: MaCSKCB=", "").Split(',');
            //        if (maCSKCB.Length > 0)
            //        {
            //            kcb.GetByKey(maCSKCB[0]);
            //            MessageBox.Show("Ngày khám này, bệnh nhân đã khám ở cơ sở " + kcb.TenCSKCB, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return false;
            //        }                    
            //    }

            //}
            return false;
        }
        private void Load_ChiPhi()
        {
            //SystemConfig system = SystemConfig.Instance;
            //string token = system.GetToken();
            //if (string.IsNullOrEmpty(token))
            //{
            //    MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //string URL = "WSGetChiPhiKCBBHYT/" + txtSoTheBHYT.Text.Replace("-", "");
            //string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL, "GET", string.Empty, token);
            //if (!string.IsNullOrEmpty(response) && response.IndexOf("Error:") == -1)
            //{

            //    try
            //    {
            //        List<History> lstDMCHIPHI = XMLUtils.DeSerializeToList<History>(response);
            //        clsDM_CSKCB kcb = new clsDM_CSKCB();
            //        for (int i = 0; i < lstDMCHIPHI.Count; i++)
            //        {
            //            DataRow toInsert = TbTongChiPhiKCBBHYT.NewRow();
            //            toInsert["SoTheBHYT"] = lstDMCHIPHI[i].SoTheBHYT;
            //            toInsert["HoTen"] = lstDMCHIPHI[i].HoTen;
            //            toInsert["GioiTinh"] = lstDMCHIPHI[i].GioiTinh;
            //            toInsert["NgaySinh"] = !string.IsNullOrEmpty(lstDMCHIPHI[i].NgaySinh.ToString()) ? (object)lstDMCHIPHI[i].NgaySinh: (object)DBNull.Value ;
            //            string maCSKCB = lstDMCHIPHI[i].MaCSKCB;
            //            kcb.GetByKey(maCSKCB);
            //            toInsert["TenCSKCB"] = kcb.TenCSKCB;
            //            toInsert["TongChiPhi"] = lstDMCHIPHI[i].TongChiPhi;
            //            toInsert["BHYTThanhToan"] = lstDMCHIPHI[i].BHYTThanhToan;
            //            toInsert["NguoiBenhTra"] = !string.IsNullOrEmpty(lstDMCHIPHI[i].NguoiBenhTra.ToString()) ? (object)lstDMCHIPHI[i].NguoiBenhTra : (object)DBNull.Value;
            //            toInsert["NgayDenKham"] = !string.IsNullOrEmpty(lstDMCHIPHI[i].NgayDenKham.ToString()) ? lstDMCHIPHI[i].NgayDenKham : (object)DBNull.Value;
            //            toInsert["NgayThanhToan"] = !string.IsNullOrEmpty(lstDMCHIPHI[i].NgayQuyetToan.ToString()) ? lstDMCHIPHI[i].NgayQuyetToan : (object)DBNull.Value;
            //            TbTongChiPhiKCBBHYT.Rows.Add(toInsert);

            //        }
            //        grdDM_KCB.DataSource = TbTongChiPhiKCBBHYT;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

        }   

        private void btnLuu_Click(object sender, EventArgs e)
        {

            string sothe = txtSoTheBHYT.Text.Replace("-", "");
            DateTime? TuNgay = txtTuNgay.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtTuNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            DateTime? DenNgay = txtDenNgay.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtDenNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            DateTime? NgaySinh = txtNgaySinh.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            DateTime? NgayDenKham = txtNgayVao.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtNgayVao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;

            string errorMsg = "Bắt buộc";
            errorProvider1.Clear();

            if (sothe.Trim().Length <= 0)
            {

                this.errorProvider1.SetError(txtSoTheBHYT, errorMsg);
                return;
            }
            if (TuNgay == null)
            {

                this.errorProvider1.SetError(txtTuNgay, errorMsg);
                return;
            }
            if (DenNgay == null)
            {

                this.errorProvider1.SetError(txtDenNgay, errorMsg);
                return;
            }
            if (NgayDenKham == null)
            {

                this.errorProvider1.SetError(txtNgayVao, errorMsg);
                return;
            }
            if (NgaySinh == null)
            {

                this.errorProvider1.SetError(txtNgaySinh, errorMsg);
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (_TrangThai == TrangThai.ThemMoi)
            {
                if (Save() == true)
                {
                    _TrangThai = TrangThai.Khac;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnDong.Enabled = true;
                    btnLuu.Enabled = false;
                    btnHuyBo.Enabled = false;
                    SetControlStatusReadOnly(true);
                    btnCheckThe.Enabled = false;
                }
               
            }
            else
                if (Sua() == true)
                {
                    _TrangThai = TrangThai.Khac;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnDong.Enabled = true;
                    btnLuu.Enabled = false;
                    btnHuyBo.Enabled = false;
                    SetControlStatusReadOnly(true);
                    btnCheckThe.Enabled = false;
             }
           
        }
        private void InsertDanhMucOnline()
        {
            //SystemConfig system = SystemConfig.Instance;
            //string service = system.GetLinkWS();
            //string param = string.Format("GetAccessToken/{0}/{1}", system.Username, system.Password);
            //string URL = service + "/" + param;
            //string response = HttpRequest.WSRequest(URL, "GET", string.Empty);
            //string token = XMLUtils.DeSerializeToObject<string>(response);

            //if (!string.IsNullOrEmpty(token))
            //{
            //    string URL1 = service + "/" + "WSDangKyKCBBHYT/";
            //}
        }

        private void txtMaCSKCBBD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTenCSKCBBD.Text = txtMaCSKCBBD.SelectedValues["TenCSKCB"].ToString();

            }
            catch { }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            _TrangThai = TrangThai.Khac;
            errorProvider1.Clear();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnDong.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            SetControlStatusReadOnly(true);
            btnCheckThe.Enabled = false;
            ResetControl();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        //private bool Load_ThongTinDKKCB()
        //{
        //    //SystemConfig system = SystemConfig.Instance;
        //    //string token = system.GetToken();
        //    //if (string.IsNullOrEmpty(token))
        //    //{
        //    //    MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //    return false;
        //    //}
        //    //if (!string.IsNullOrEmpty(token))
        //    //{
        //    //    string URL = "WSGetHosoDangKyKCBBHYT/" + txtSoDKKBBHYT.Text;

        //    //    string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL, "GET", string.Empty, token);
        //    //    if (string.IsNullOrEmpty(response))
        //    //    {
        //    //        MessageBox.Show("Không tìm thấy thông tin với mã đăng ký này.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //        return false;
        //    //    }
        //    //    DangKyKhamBenh lstDMCHIPHI = XMLUtils.DeSerializeToObject<DangKyKhamBenh>(response);//(response);
        //    //    if (lstDMCHIPHI == null)
        //    //    {
        //    //        MessageBox.Show("Mã đăng ký chưa tồn tại.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //        return false;
        //    //    }
        //    //    txtSoTheBHYT.Text = lstDMCHIPHI.SoTheBHYT;
        //    //    txtNgayVao.Text = lstDMCHIPHI.NgayDenKham.ToString("dd/MM/yyyy");
        //    //    txtNgaySinh.Text = DateTime.Parse(lstDMCHIPHI.NgaySinh.ToString()).ToString("dd/MM/yyyy");
        //    //    txtTuNgay.Text = lstDMCHIPHI.SuDungTu.ToString("dd/MM/yyyy");
        //    //    txtDenNgay.Text = lstDMCHIPHI.SuDungDen.ToString("dd/MM/yyyy");
        //    //    txtDiaChi.Text = lstDMCHIPHI.DiaChi;
        //    //    txtHoTen.Text = lstDMCHIPHI.HoTen;
        //    //    txtMaCSKCBBD.Text = lstDMCHIPHI.MaCSKCBBanDau;
        //    //    txtNoiChuyenDen.Text = lstDMCHIPHI.MaNoiChuyenDen;
        //    //    cboMaNoiSinhSong.Text = lstDMCHIPHI.MaNoiSinhSong;
        //    //    cboTuyenKham.SelectedValue = lstDMCHIPHI.LyDoVV.ToString();
        //    //    chkChungTuKhongCCT.Checked = (bool)lstDMCHIPHI.ChungNhanKhongCTT;
        //    //    cboGioiTinh.SelectedValue = lstDMCHIPHI.GioiTinh.ToString();
                
        //    //    clsDM_CSKCB objDMKCB = new clsDM_CSKCB();
        //    //    objDMKCB.GetByKey(txtMaCSKCBBD.Text);
        //    //    txtTenCSKCBBD.Text = objDMKCB.TenCSKCB;
        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show("Lỗi. Kiểm tra cấu hình và thử lại.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //    return false;
        //    //}
        //    //return true;
        //}

        private void btnKiemTraSDK_Click(object sender, EventArgs e)
        {
           //if( Load_ThongTinDKKCB()==true)
           //     Load_ChiPhi();
        }

        private void frmDangKyKhamBenh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = false;
                e.SuppressKeyPress = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            else if (e.KeyCode == Keys.N && e.Control)
            {
                btnThem.PerformClick();
            }
            else if (e.KeyCode == Keys.S && e.Control)
            {
                btnLuu.PerformClick();
            }
            else if (e.KeyCode == Keys.E && e.Control)
            {
                btnSua.PerformClick();
            }
            else if (e.KeyCode == Keys.D && e.Control)
            {
                btnXoa.PerformClick();
            }
            else if (e.KeyCode == Keys.W && e.Control)
            {

            }
            else if (e.KeyCode == Keys.P && e.Control)
            {

            }
            else if (e.KeyCode == Keys.F3)
            {
                bool focus = txtSoDKKBBHYT.Focused;
                if (focus == true)
                {
                    btnKiemTraSDK.PerformClick();
                    return;
                }
                focus = txtSoTheBHYT.Focus();
                if (focus == true)
                {
                    btnCheckThe.PerformClick();
                }
            }

        }

        private void frmDangKyKhamBenh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_TrangThai != TrangThai.Khac)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu thay đổi ?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    btnLuu.PerformClick();
                }
                else if (result == DialogResult.No)
                {
                    btnHuyBo.PerformClick();

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if  (string.IsNullOrEmpty(txtSoDKKBBHYT.Text))
            {
                MessageBox.Show("Bạn chưa nhập số ĐKKCB BHYT.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsBangKe objBangKe = new clsBangKe();
            bool checkedBangKe = objBangKe.CheckHoSo(txtSoDKKBBHYT.Text);
            if (checkedBangKe == true)
            {
                MessageBox.Show("Số đăng ký này đã được sử dụng, không thể sửa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _TrangThai = TrangThai.Sua;// "CapNhat";
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            btnLuu.Enabled = true;
            btnHuyBo.Enabled = true;
            btnCheckThe.Enabled = true;
            SetControlStatusReadOnly(false);
            txtTuNgay.Focus();
            btnKiemTraSDK.Enabled = true;

        }

        private bool Sua()
        {
            //clsBangKe objBangKe = new clsBangKe();
            //bool checkedBangKe = objBangKe.CheckHoSo(txtSoDKKBBHYT.Text);
            //if (checkedBangKe == true)
            //{
            //    MessageBox.Show("Số hồ sơ đã được sử dụng, không được phép sửa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            //clsDangKyKhamBenh objDangKy = new clsDangKyKhamBenh();
            //objDangKy.SoDKKCBBHYT = Utilities.Utils.convertInt(txtSoDKKBBHYT.Text);
            //if (string.IsNullOrEmpty( objDangKy.SoDKKCBBHYT .ToString()))
            //{
            //    MessageBox.Show("Số ĐKKCB BHYT phải là số.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            //if (string.IsNullOrEmpty(txtSoTheBHYT.Text))
            //{
            //    MessageBox.Show("Bạn chưa kiểm tra thẻ BHYT hoặc thẻ BHYT không tồn tại, vui lòng kiểm tra số BHYT trước khi sửa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            ////   objDangKy.SoDKKCBBHYT = int.Parse(txtSoDKKBBHYT.Text);



            //objDangKy.MaCSKCB = sys.MaCSKCB;
            //objDangKy.MaCSKCBBĐ = txtMaCSKCBBD.Text;
            //objDangKy.SoTheBHYT = txtSoTheBHYT.Text;
            //objDangKy.TuNgay = txtTuNgay.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtTuNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            //objDangKy.DenNgay = txtDenNgay.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtDenNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            //objDangKy.HoTen = txtHoTen.Text;
            //objDangKy.NgaySinh = txtNgaySinh.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            //objDangKy.GioiTinh = int.Parse((cboGioiTinh.SelectedValue.ToString()));
            //objDangKy.DiaChi = txtDiaChi.Text;
            //objDangKy.MaNoiSinhSong = cboMaNoiSinhSong.Text;
            //objDangKy.LyDoVV = int.Parse(cboTuyenKham.SelectedValue.ToString());
            //objDangKy.MaNoiChuyenDen = txtNoiChuyenDen.Text;
            //objDangKy.ChungNhanKhongCTT = (chkChungTuKhongCCT.Checked);
            //objDangKy.GhiChu = "";
            //objDangKy.NgayDenKham = txtNgayVao.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtNgayVao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            //DangKyKhamBenh item = new DangKyKhamBenh();
            //item.MaCSKCB = objDangKy.MaCSKCB;
            //item.MaCSKCBBanDau = objDangKy.MaCSKCBBĐ;
            //item.SoTheBHYT = objDangKy.SoTheBHYT.Replace("-", "");
            //item.HoTen = objDangKy.HoTen;
            //item.NgaySinh = objDangKy.NgaySinh;
            //item.NamSinh = string.IsNullOrEmpty(objDangKy.NgaySinh.ToString()) ? 0 : objDangKy.NgaySinh.Value.Year;
            //item.GioiTinh = byte.Parse(objDangKy.GioiTinh.ToString());
            //item.DiaChi = objDangKy.DiaChi;
            //item.MaNoiSinhSong = objDangKy.MaNoiSinhSong;
            //item.ChungNhanKhongCTT = objDangKy.ChungNhanKhongCTT;
            //item.SuDungTu = (DateTime)objDangKy.TuNgay;
            //item.SuDungDen = (DateTime)objDangKy.DenNgay;
            //item.LyDoVV = byte.Parse(objDangKy.LyDoVV.ToString());
            //item.NgayDenKham = (DateTime)objDangKy.NgayDenKham;
            //item.MaNoiChuyenDen = objDangKy.MaNoiChuyenDen;
            //item.GhiChu = objDangKy.GhiChu;
            //item.ChungNhanKhongCTT = objDangKy.ChungNhanKhongCTT;
            //SystemConfig system = SystemConfig.Instance;
            //string token = system.GetToken();
            //if (string.IsNullOrEmpty(token))
            //{
            //    MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            //if (!string.IsNullOrEmpty(token))
            //{
            //    string URL = "WSUpdateDangKyKCBBHYT/" + txtSoDKKBBHYT.Text;

            //    string requestData = XMLUtils.SerializeDataContract(item);
            //    string response = system.SendRequest(URL, "POST", requestData); //HttpRequest.WSRequest(URL, "POST", requestData, token);

            //    //string value = XMLUtils.DeSerializeToObject<string>(response);
            //    if (response.IndexOf("Error:") != -1 || string.IsNullOrEmpty(response))
            //    {
            //        return false;
            //    }
            //    if (objDangKy.CheckTonTaiKCB(txtSoDKKBBHYT.Text)==false)
            //    {
            //        objDangKy.Insert();
            //    }
            //    if (objDangKy.Update() == 1)
            //    {                   
            //        //MessageBox.Show("Cập nhật thành công!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        //lblThongBao.ForeColor = Color.Red;
            //        lblThongBao.Text = "Cập nhật thành công.";
            //        timerThongBao.Enabled = true;   
            //        return true;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Cập nhật không thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return false;
            //    }
            //}
            return false;
        }

        private void Xoa()
        {

            //clsBangKe objBangKe = new clsBangKe();
            //bool checkedBangKe = objBangKe.CheckHoSo(txtSoDKKBBHYT.Text);
            //if (checkedBangKe == true)
            //{
            //    MessageBox.Show("Số hồ sơ đã sử dụng, không được phép xóa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //clsDangKyKhamBenh objDangKy = new clsDangKyKhamBenh();
            //objDangKy.SoDKKCBBHYT = Utilities.Utils.convertInt(txtSoDKKBBHYT.Text);
            //if (string.IsNullOrEmpty(objDangKy.SoDKKCBBHYT.ToString()))
            //{
            //    MessageBox.Show("Số ĐK KCB BHYT phải là số.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtSoTheBHYT.Text))
            //{
            //    MessageBox.Show("Bạn chưa kiểm tra thẻ BHYT hoặc thẻ BHYT không tồn tại, vui lòng kiểm tra số BHYT trước khi xóa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //objDangKy.MaCSKCB = txtMaCSKCBBD.Text;
            //objDangKy.MaCSKCBBĐ = txtMaCSKCBBD.Text;
            //objDangKy.SoTheBHYT = txtSoTheBHYT.Text;
            //objDangKy.TuNgay = txtTuNgay.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtTuNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            //objDangKy.DenNgay = txtDenNgay.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtDenNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            //objDangKy.HoTen = txtHoTen.Text;
            //objDangKy.NgaySinh = txtNgaySinh.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            //objDangKy.GioiTinh = int.Parse((cboGioiTinh.SelectedValue.ToString()));
            //objDangKy.DiaChi = txtDiaChi.Text;
            //objDangKy.MaNoiSinhSong = cboMaNoiSinhSong.Text;
            //objDangKy.LyDoVV = int.Parse(cboTuyenKham.SelectedValue.ToString());
            //objDangKy.MaNoiChuyenDen = txtNoiChuyenDen.Text;
            //objDangKy.ChungNhanKhongCTT = (chkChungTuKhongCCT.Checked);
            //objDangKy.GhiChu = "";
            //objDangKy.NgayDenKham = txtNgayVao.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtNgayVao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            //DangKyKhamBenh item = new DangKyKhamBenh();
            //item.MaCSKCB = objDangKy.MaCSKCB;
            //item.MaCSKCBBanDau = objDangKy.MaCSKCBBĐ;
            //item.SoTheBHYT = objDangKy.SoTheBHYT.Replace("-", "");
            //item.HoTen = objDangKy.HoTen;
            //item.NgaySinh = objDangKy.NgaySinh;
            //item.NamSinh = string.IsNullOrEmpty(objDangKy.NgaySinh.ToString()) ? 0 : objDangKy.NgaySinh.Value.Year;
            //item.GioiTinh = byte.Parse(objDangKy.GioiTinh.ToString());
            //item.DiaChi = objDangKy.DiaChi;
            //item.MaNoiSinhSong = objDangKy.MaNoiSinhSong;
            //item.ChungNhanKhongCTT = objDangKy.ChungNhanKhongCTT;
            //item.SuDungTu = (DateTime)objDangKy.TuNgay;
            //item.SuDungDen = (DateTime)objDangKy.DenNgay;
            //item.LyDoVV = byte.Parse(objDangKy.LyDoVV.ToString());
            //item.NgayDenKham = (DateTime)objDangKy.NgayDenKham;
            //item.MaNoiChuyenDen = objDangKy.MaNoiChuyenDen;
            //item.GhiChu = objDangKy.GhiChu;
            //item.ChungNhanKhongCTT = objDangKy.ChungNhanKhongCTT;
            //SystemConfig system = SystemConfig.Instance;
            //string token = system.GetToken();
            //if (string.IsNullOrEmpty(token))
            //{
            //    MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (!string.IsNullOrEmpty(token))
            //{
            //    DialogResult dialogResult = MessageBox.Show("Bạn có thật sự muốn xóa thông tin đăng ký này không?", this.Text, MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        //do something
            //        string URL = "WSDeleteHosoDangKyKCBBHYT/" + txtSoDKKBBHYT.Text;
            //        //string requestData = XMLUtils.SerializeDataContract(item);
            //        string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL, "GET", string.Empty);
            //        if (string.IsNullOrEmpty(response))
            //        {
            //            //string value = XMLUtils.DeSerializeToObject<string>(response);
            //            //if (response.IndexOf("Error:") != -1 || string.IsNullOrEmpty(response))
            //            //{
            //            //    MessageBox.Show("Lỗi trong quá trình kết nối đến server");
            //            //    return;
            //            //}
            //            MessageBox.Show("Không xóa được hồ sơ đăng ký " + txtSoDKKBBHYT.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }
            //        //khong co loi
            //        if (objDangKy.XoaHoSo(objDangKy.SoDKKCBBHYT.ToString()) == true){
            //           // MessageBox.Show("Xóa thành công!" + txtSoDKKBBHYT.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            //lblThongBao.ForeColor = Color.Red;
            //            lblThongBao.Text = "Xóa thành công.";
            //            timerThongBao.Enabled = true;
            //        }
            //        else
            //            MessageBox.Show("Xóa không thành công." + txtSoDKKBBHYT.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        SetControlStatusReadOnly(true);
            //        ResetControl();
            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {
            //        //do something else
            //    }
            //}
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty( txtSoDKKBBHYT.Text))
            {
                MessageBox.Show("Bạn chưa nhập số ĐKKCB BHYT.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsBangKe objBangKe = new clsBangKe();
            bool checkedBangKe = objBangKe.CheckHoSo(txtSoDKKBBHYT.Text);
            if (checkedBangKe == true)
            {
                MessageBox.Show("Số đăng ký này đã được sử dụng, không thể xóa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Xoa();
        }

        private void txtSoDKKBBHYT_Validated(object sender, EventArgs e)
        {

        }

        private void txtSoDKKBBHYT_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSoDKKBBHYT_KeyPress(object sender, KeyPressEventArgs e)
        {




        }

        private void txtSoDKKBBHYT_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSoDKKBBHYT.Text == "")
            {
                ResetControl();
            }
        }

        private void txtDenNgay_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtNgayVao.GetDate != null && (txtNgayVao.GetDate.Value < txtTuNgay.GetDate.Value || txtNgayVao.GetDate.Value > txtDenNgay.GetDate.Value))
                {
                    MessageBox.Show("Ngày khám bệnh không được nằm ngoài thời hạn sử dụng thẻ BHYT.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNgayVao.Focus();
                    //SendKeys.Send("{DEL}");
                    return;
                }

            }
            catch
            {
            }
        }

        private void txtNgayVao_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtNgayVao.GetDate != null && (txtNgayVao.GetDate.Value < txtTuNgay.GetDate.Value || txtNgayVao.GetDate.Value > txtDenNgay.GetDate.Value))
                {
                   // MessageBox.Show("Ngày vào không được nằm ngoài thời hạn sử dụng thẻ BHYT", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //lblThongBao.ForeColor = Color.Red;
                    lblThongBao.Text = "Ngày vào không được nằm ngoài thời hạn sử dụng thẻ BHYT.";
                    timerThongBao.Enabled = true;
                    txtNgayVao.Focus();
                    return;
                }

            }
            catch
            {
            }
        }

        private void btnHoSo_Click(object sender, EventArgs e)
        {
            frmHoSo frm = new frmHoSo();

            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == frm.Name)
                {
                    f.Activate();
                    frm = (frmHoSo)f;
                    frm.LoadHoSo(txtSoDKKBBHYT.Text);
                    return;
                }

            }

            frm.MdiParent = this.ParentForm;
            frm.WindowState = FormWindowState.Maximized;
            frm.m_LoaiBangKe = m_LoaiBangKe;
            frm.Show();           
            frm.LoadHoSo(txtSoDKKBBHYT.Text);
        }

        private void txtNgayVao_Enter(object sender, EventArgs e)
        {
            //txtNgayVao_Validated(null, null);
        }

        private void timerThongBao_Tick(object sender, EventArgs e)
        {
            lblThongBao.ForeColor = Color.Blue;
            lblThongBao.Text = "";
            timerThongBao.Enabled = false;
        }

        private void txtSoTheBHYT_Validated(object sender, EventArgs e)
        {
            LoadMaCSKCBTheoMaTinh();
        }

    }
}

