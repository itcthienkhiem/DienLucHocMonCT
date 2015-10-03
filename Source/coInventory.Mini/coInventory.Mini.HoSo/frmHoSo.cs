using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
using System.Globalization;
using System.Drawing.Printing;
using CrystalDecisions.Shared;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
//using WebService.Model;
//using WebService.Model.Utility;

namespace coInventory.Mini.HoSo
{
    public partial class frmHoSo : Form
    {
        #region Khai báo biến
        public int m_LoaiBangKe = 1;


        private bool isCapNhat = false;

        private string TrangThai = "";
        private int m_BangKe_Id = 0;
        private string m_MaChiPhi = string.Empty;
        private string m_LoaiChiPhi = string.Empty;

        private DataTable dtCSKCB = null;

        SystemConfig conf = SystemConfig.Instance;

        clsDM_CSKCB m_CSKCB = new clsDM_CSKCB();

        //Load data 1 lan 
        decimal luong = 0;
        List<clsDM_ChuyenDoiMucHuong> cds = new List<clsDM_ChuyenDoiMucHuong>();
        List<clsDM_MucHuong> mhs = new List<clsDM_MucHuong>();

        private PrintDocument printDoc = new PrintDocument();

        #endregion

        #region Các sự kiện
        public frmHoSo()
        {
            InitializeComponent();
        }

        private void frmHoSo_Load(object sender, EventArgs e)
        {
            if (m_LoaiBangKe == 1)
            {
                this.Text = "Bảng kê chi phí KCB ngoại trú (01/BV)";
            }
            else if (m_LoaiBangKe == 2)
            {
                this.Text = "Bảng kê chi phí KCB Nội trú (02/BV)";
            }
            else if (m_LoaiBangKe == 3)
            {
                this.Text = "Bảng kê chi phí KCB ngoại trú (03/TYT)";
            }
            else
            {
                this.Close();
            }

            try
            {
                SetControlStatusReadOnly(true);
                LoadDataCombobox();
                LoadLuongCoSoVaMucHuong();
                ResetControl();
                LoadMayIn();
                m_CSKCB.GetByKey(conf.MaCSKCB);
                lblThongBao.Text = "";
            }
            catch { }
        }

        public void LoadHoSo(string strSoDK)
        {
            btnThem.PerformClick();
            txtSoDK.Text = strSoDK;
            txtSoDK_Validated(null, null);
            
        }

        private void LoadMayIn()
        {

            int i;
            string pkInstalledPrinters;

            cboMayIn.Items.Clear();
            for (i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cboMayIn.Items.Add(pkInstalledPrinters);
                if (printDoc.PrinterSettings.IsDefaultPrinter)
                {
                    cboMayIn.Text = printDoc.PrinterSettings.PrinterName;
                }
            }
        }

        private void LoadLuongCoSoVaMucHuong()
        {
            luong = clsDM_LuongCoSo.GetLuongCoSo();
            cds = clsDM_ChuyenDoiMucHuong.GetListChuyenDoi();
            mhs = clsDM_MucHuong.GetListMucHuong();


        }

        private void LoadDataCombobox()
        {
            //Chú ý khi đổ dữ liệu lần đầu, không cho valuechanged sự kiện cbo

            //Load data cbo trạng thái - 2 trạng thái: "tạo mới" và "đã gửi BHXH". Mặc định là tạo mới, khi cột DaGuiBHXH trong bảng BangKe là 1 thì sẽ là "đã gửi BHXH"


            cboTinhTrang.DataSource = Utilities.Utils.GetTrangThai();
            cboTinhTrang.DisplayMember = "Name";
            cboTinhTrang.ValueMember = "Value";


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

            //Load data cơ sở khám chữa bệnh

            clsDM_CSKCB cskcb = new clsDM_CSKCB();
            dtCSKCB = cskcb.GetAllActive();
            txtNoiChuyenDen.Values = dtCSKCB;
            List<CDisplayColumns> lstColCSKCB = new List<CDisplayColumns>();
            lstColCSKCB.Add(new CDisplayColumns("MaCSKCB", "Mã CSKCB", true, true));
            lstColCSKCB.Add(new CDisplayColumns("TenCSKCB", "Tên CSKCB", true, true));

            txtNoiChuyenDen.DisplayColumns = lstColCSKCB;

            //Load data cbo mức hưởng
            clsDM_MucHuong mucHuong = new clsDM_MucHuong();
            cboMucHuong.DataSource = mucHuong.GetAllActive();
            cboMucHuong.DisplayMember = "MucHuong";
            cboMucHuong.ValueMember = "MucHuong";
            cboMucHuong.SelectedValue = 0;

            //Load data cbo ICD

            clsDM_ICD icd = new clsDM_ICD();

            DataTable dt = new DataTable();
            dt = icd.GetAllActive();

            txtMaICD.Values = dt;
            List<CDisplayColumns> lstCol = new List<CDisplayColumns>();
            lstCol.Add(new CDisplayColumns("MaICD", "Mã ICD", true, true));
            lstCol.Add(new CDisplayColumns("TenICD", "Tên ICD", true, true));

            txtMaICD.DisplayColumns = lstCol;

            txtBenhKhac.DisplayColumns = lstCol;
            txtBenhKhac.Values = dt;

            //Load data cbo Thuốc


            clsDM_Thuoc thuoc = new clsDM_Thuoc();
            txtThuoc.DropDownSize = new Size(600, 155);
            txtThuoc.Values = thuoc.GetAllALL();


            List<CDisplayColumns> lstColT = new List<CDisplayColumns>();
            lstColT.Add(new CDisplayColumns("Nhom", "Nhóm", false, true));
            lstColT.Add(new CDisplayColumns("MaChiPhi", "Mã chi phí", true, true));
            lstColT.Add(new CDisplayColumns("TenChiPhi", "Tên chi phí", true, true));
            lstColT.Add(new CDisplayColumns("DonGiaBHYT", "Đơn giá", false, true));
            txtThuoc.DisplayColumns = lstColT;
            txtThuoc.DisplayMember = "TenChiPhi";


            //Danh mục phòng ban
            clsDM_PhongBan phongban = new clsDM_PhongBan();
            txtKhoa.DropDownSize = new Size(300, 110);
            txtKhoa.Values = phongban.GetAllActive();
            List<CDisplayColumns> lstColPB = new List<CDisplayColumns>();
            lstColPB.Add(new CDisplayColumns("MaPhongBan", "Mã Khoa", true, true));
            lstColPB.Add(new CDisplayColumns("TenPhongBan", "Tên khoa", true, true));
            txtKhoa.DisplayColumns = lstColPB;
            txtKhoa.DisplayMember = "TenPhongBan";
        }

        private void txtSoTheBHYT_Validated(object sender, EventArgs e)
        {
            //Khi nhập xong số thẻ BHYT tự động chọn mức hưởng dựa vào ký tự số 3.
            //Vì trước đây có 7 mức hưởng, sau này chuyển thành 5 mức hưởng. Các thẻ cũ thì vẫn chưa đổi số thẻ nhưng vẫn hưởng theo mức hưởng mới.
            //Phải check trong bảng DM_ChuyenDoi trước theo cặp key DoiTuong (2 ký tự đầu) và mức hưởng cũ (ký tự số 3) --> chọn mức hưởng (theo mức hưởng mới).
            //Nếu không có trong bảng DM_ChuyenDoi thì nhảy theo bảng DM_MucHuong và check thêm 2 ký đầu và ký tự số 3 có đúng không trong bảng DM_MucHuongChuyenDoi
            int MucHuong = clsDM_ChuyenDoiMucHuong.GetMucHuongMoi(txtSoTheBHYT.Text);
            cboMucHuong.SelectedValue = MucHuong;

            txtNgayVao_Validated(null, null);

            if (txtSoTheBHYT.Text.Replace("-", "").Length >= 15)
            {
                if (TrangThai == "")
                {
                    LoadData(2);
                }
                else if (TrangThai == "ThemMoi" && (txtSoDK.Text.Trim().Length == 0 && txtMaBenhNhan.Text.Trim().Length == 0
                    && txtMaKhamChuBenh.Text.Trim().Length == 0))
                {
                    clsBangKe obj = new clsBangKe();

                    IsRunCheck = true;
                    if (txtSoTheBHYT.Text.Replace("-", "").Trim().Length > 0)
                    {
                        obj.GetByKey(txtSoTheBHYT.Text.Replace("-", "").Trim());
                        if (obj.MaKhamChuaBenh == null || obj.MaKhamChuaBenh.Trim() == "")
                        {
                            //Do nothing
                        }
                        else
                        {
                            txtTuNgay.Text = string.Format("{0:dd/MM/yyyy}", obj.TuNgayBH);
                            txtDenNgay.Text = string.Format("{0:dd/MM/yyyy}", obj.DenNgayBH);
                            txtDiaChi.Text = obj.DiaChi;
                            cboGioiTinh.SelectedValue = obj.GioiTinh.ToString();
                            cboMaNoiSinhSong.SelectedValue = obj.MaNoiSinhSong;
                            txtMaCSKCBBD.Text = obj.MaCSKCBBanDau;
                            txtTenCSKCBBD.Text = obj.TenCSKCBBanDau;
                            txtNgaySinh.Text = string.Format("{0:dd/MM/yyyy}", obj.NgaySinh);
                            txtMaBenhNhan.Text = obj.MaNguoiBenh;
                            cboTuyenKham.SelectedValue = obj.TuyenKhamBenh.ToString();
                            cboMaNoiSinhSong.SelectedValue = obj.MaNoiSinhSong;
                            txtNamSinh.Text = obj.NamSinh.ToString();
                            txtHoTen.Text = obj.HoTen.ToString();
                        }



                        IsRunCheck = false;
                    }
                }

                LoadMaCSKCBTheoMaTinh();

            }
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
                // TinhTongGridView();
            }

        }

        private void datNgaySinh_Validated(object sender, EventArgs e)
        {
            //Khi nhập xong ngày sinh, thì tự động load năm sinh vào ô txtNamSinh
        }

        private void cboMaCSKCBBD_SelectedValueChanged(object sender, EventArgs e)
        {
            //Khi chọn xong Mã CSKCB ban đầu, thì tự động load tên CSKCB ban đầu vào ô txtTenCSKCBBD
        }

        private void rdoCapCuu_CheckedChanged(object sender, EventArgs e)
        {
            //Nếu đang chọn cấp cứu thì là đúng tuyến --> txtPhanTramHuong là hưởng đúng phần trăm hưởng của mức hưởng
        }

        private void rdoDungTuyen_CheckedChanged(object sender, EventArgs e)
        {
            //Nếu đang chọn đúng tuyến --> txtPhanTramHuong là hưởng đúng phần trăm hưởng của mức hưởng
        }

        private void rdoTraiTuyen_CheckedChanged(object sender, EventArgs e)
        {
            //Nếu đang chọn tuyến tuyến --> txtPhanTramHuong là hưởng trái tuyến phần trăm hưởng của mức hưởng.

        }

        private void cboMucHuong_SelectedValueChanged(object sender, EventArgs e)
        {
            //Tùy theo mức hưởng --> txtPhanTramHuong
            try
            {
                txtPhanTramHuong.Value = (decimal)(((DataRowView)cboMucHuong.SelectedItem)["PhanTram"]);
            }
            catch { txtPhanTramHuong.Value = 0; }
        }

        private void datNgayVao_Validated(object sender, EventArgs e)
        {
            //Nếu ngày ra not null thì check ngày vào <= ngày ra. Và Tự động tính ra số ngày điều trị = Ngày ra - ngày vào.
        }

        private void datNgayRa_Validated(object sender, EventArgs e)
        {
            //Nếu ngày vào not null thì check ngày ra >= ngày vào. Và Tự động tính ra số ngày điều trị = Ngày ra - ngày vào.
            //Set ngày thanh toán = ngày ra.
        }

        private void cboICD_SelectedValueChanged(object sender, EventArgs e)
        {
            //Khi chọn ICD, tự động load txtChanDoan = tên ICD.
        }

        private void cboThuoc_SelectedValueChanged(object sender, EventArgs e)
        {
            //Khi chọn thuốc, tự động load txtSoLuongThuoc  = 1,
            //txtBHYTThanhToanThuoc = DonGiaBHYT * Phần trăm hưởng. txtNguonKhacThuoc = 0, txtNguoiBenhTraThuoc = DonGiaBHYT - txtNguonKhacThuoc - txtBHYTThanhToanThuoc
            //Đồng thời con  trỏ nhảy qua ô số lượng, để người dùng chỉnh sửa.
        }

        private void txtSoLuongThuoc_Validated(object sender, EventArgs e)
        {
            //Khi người dùng enter, kiểm tra có chọn thuốc chưa. Nếu có tính lại các ô txtBHYTThanhToanThuoc, txtNguoiBenhTraThuoc. Sau đó gọi sự kiện addThuoc xuống lưới             

            //ThemVaCapNhatChiPhi();
            //txtThuoc.Focus();
            if (!isCapNhat)
            {
                btnAddThuoc_Click(null, null);
            }
        }

        private void btnAddThuoc_Click(object sender, EventArgs e)
        {
            //Kiểm tra thuốc này (theo mã) đã có trong lưới chi phí thuốc chưa, có rồi thì update dữ liệu trên lưới, chưa thì insert xuống
            decimal ThanhTien = (txtSoLuongThuoc.Value * txtDonGiaBHYT.Value);
            decimal NguoiBenhTra = ThanhTien - (ThanhTien * (txtPhanTramHuong.Value / 100));
            if (txtNguonKhacThuoc.Value > NguoiBenhTra && txtNguonKhacThuoc.Value > 0)
            {
                MessageBox.Show("Nguồn khác vượt số tiền người bệnh trả.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNguonKhacThuoc.Focus();
                txtNguonKhacThuoc.Value = 0;
                txtNguonKhacThuoc.Select(0, txtNguonKhacThuoc.Text.Length);
                return;
            }
            else
            {
                if (!btnClearChiPhi.Focused)
                {
                    ThemVaCapNhatChiPhi();
                    grdChiPhiThuoc.ClearSelection();
                }
            }

        }

        private void cboVTYT_SelectedValueChanged(object sender, EventArgs e)
        {
            //Khi chọn VTYT, tự động load txtSoLuongVTYT  = 1,
            //txtBHYTThanhToanVTYT = DonGiaBHYT * Phần trăm hưởng. txtNguonKhacThuoc = 0, txtNguoiBenhTraVTYT = DonGiaBHYT - txtNguonKhacThuoc - txtBHYTThanhToanThuoc
            //Đồng thời con  trỏ nhảy qua ô số lượng, để người dùng chỉnh sửa.
        }

        private void txtSoLuongVTYT_Validated(object sender, EventArgs e)
        {
            //Khi người dùng enter, kiểm tra có chọn thuốc chưa. Nếu có tính lại các ô txtBHYTThanhToanVTYT, txtNguoiBenhTraVTYT. Sau đó gọi sự kiện addVTYT xuống lưới 
        }

        private void btnAddVTYT_Click(object sender, EventArgs e)
        {

            //Kiểm tra VTYT này (theo mã) đã có trong lưới chi phí VTYT chưa, có rồi thì update dữ liệu trên lưới, chưa thì insert xuống
        }

        private void cboDichVu_SelectedValueChanged(object sender, EventArgs e)
        {
            //Khi chọn dịch vụ, tự động load txtSoLuongDichVu  = 1,
            //txtBHYTThanhToanDichVu = DonGiaBHYT * Phần trăm hưởng. txtNguonKhacDichVu = 0, txtNguoiBenhTraDichVu = DonGiaBHYT - txtNguonKhacDichVu - txtBHYTThanhToanDichVu
            //Đồng thời con  trỏ nhảy qua ô số lượng, để người dùng chỉnh sửa.
        }

        private void txtSoLuongDichVu_Validated(object sender, EventArgs e)
        {
            //Khi người dùng enter, kiểm tra có chọn dịch vụ chưa. Nếu có tính lại các ô txtBHYTThanhToanDichVu, txtNguoiBenhTraDichVu. Sau đó gọi sự kiện addDichVu xuống lưới 
        }

        private void btnAddDichVu_Click(object sender, EventArgs e)
        {
            //Kiểm tra Dịch vụ này (theo mã) đã có trong lưới chi phí dịch vụ chưa, có rồi thì update dữ liệu trên lưới, chưa thì insert xuống
        }

        private void cboMau_SelectedValueChanged(object sender, EventArgs e)
        {
            //Khi chọn máu, tự động load txtSoLuongMau  = 1,
            //txtBHYTThanhToanMau = DonGiaBHYT * Phần trăm hưởng. txtNguonKhacMau = 0, txtNguoiBenhTraMau = DonGiaBHYT - txtNguonKhacMau - txtBHYTThanhToanMau
            //Đồng thời con  trỏ nhảy qua ô số lượng, để người dùng chỉnh sửa.
        }

        private void txtSoLuongMau_Validated(object sender, EventArgs e)
        {
            //Khi người dùng enter, kiểm tra có chọn máu chưa. Nếu có tính lại các ô txtBHYTThanhToanMau, txtNguoiBenhTraMau. Sau đó gọi sự kiện addMau xuống lưới 
        }

        private void btnAddMau_Click(object sender, EventArgs e)
        {
            //Kiểm tra máu này (theo mã) đã có trong lưới chi phí máu chưa, có rồi thì update dữ liệu trên lưới, chưa thì insert xuống
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Kiem tra
            string msg = ValidateControl();
            if (msg.Trim().Length > 0)
            {
                MessageBox.Show(msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //gọi hàm savedata
            SaveData();

            TrangThai = "";
            //m_BangKe_Id = 0;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnDong.Enabled = true;
            btnGuiBHXH.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;

            txtSoDK.Enabled = true;

            SetControlStatusReadOnly(true);
        }

        private void frmHoSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = false;
                e.SuppressKeyPress = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClearChiPhi.Focus();
                btnClearChiPhi.PerformClick();
                txtThuoc.Focus();
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
                btnView.PerformClick();
            }
            else if (e.KeyCode == Keys.P && e.Control)
            {
                btnPrint.PerformClick();
            }
            else if (e.KeyCode == Keys.F3)
            {
                if (txtSoHoSo.Focused)
                {
                    btnSearch.PerformClick();
                }
                else if (txtSoTheBHYT.Focused)
                {
                    btnCheckThe.PerformClick();
                }
            }
        }

        private void txtSoLuongThuoc_Enter(object sender, EventArgs e)
        {
            txtSoLuongThuoc.Select(0, txtSoLuongThuoc.Text.Length);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TrangThai = "";


            frmTimHoSo frm = new frmTimHoSo();
            frm.mLoaiBangKe = m_LoaiBangKe;
            frm.ShowDialog();

            m_BangKe_Id = frm.mBangKe_Id;

            if (m_BangKe_Id == 0)
                return;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnDong.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            btnCheckThe.Enabled = false;

            ResetControl();
            SetControlStatusReadOnly(true);
            LoadData(0);

            txtSoDK.Enabled = true;


            TinhTongGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TrangThai = "CapNhat";
            txtMaKhamChuBenh.Enabled = false;
            if (m_BangKe_Id == 0)
            {
                TrangThai = "";
                MessageBox.Show("Bạn vui lòng chọn bảng kê để chỉnh sửa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblThongBao.Text = "Bạn vui lòng chọn bảng kê để chỉnh sửa!";
                //timerThongBao.Enabled = true;
                return;
            }

            clsBangKe obj = new clsBangKe();
            obj.GetByKey(m_BangKe_Id);

            if (obj.DaGuiBHYT.Value)
            {
                MessageBox.Show("Bảng kê này đã gửi BHXH.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblThongBao.Text = "Bảng kê này đã gửi BHXH!";
                //timerThongBao.Enabled = true;
                return;
            }

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;

            btnGuiBHXH.Enabled = false;

            btnLuu.Enabled = true;
            btnHuyBo.Enabled = true;

            btnCheckThe.Enabled = true;

            SetControlStatusReadOnly(false);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TrangThai = "ThemMoi";
            m_BangKe_Id = 0;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;

            btnLuu.Enabled = true;
            btnHuyBo.Enabled = true;

            btnCheckThe.Enabled = true;

            btnGuiBHXH.Enabled = false;

            SetControlStatusReadOnly(false);

            txtMaKhamChuBenh.ReadOnly = false;
            txtSoDK.Enabled = true;

            btnClearSoDK.Enabled = true;

            grdChiPhiThuoc.ClearSelection();
            m_BangKe_Id = 0;


            ResetControl();
        }

        private void txtNamSinh_Validating(object sender, CancelEventArgs e)
        {
            //if (txtNamSinh.TextLength <= 0)
            //{
            //    txtNamSinh.Focus();
            //}
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            TrangThai = "";
            lblThongBao.Text = "";
            m_BangKe_Id = 0;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnDong.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;

            btnGuiBHXH.Enabled = true;

            SetControlStatusReadOnly(true);

            txtMaKhamChuBenh.Enabled = true;

            //txtSoDK.Enabled = false;
            //btnClearSoDK.Enabled = false;

            btnCheckThe.Enabled = false;

            ResetControl();
        }

        private void txtThuoc_Validating(object sender, CancelEventArgs e)
        {
            //Khi chọn dịch vụ, tự động load txtSoLuongDichVu  = 1,
            //txtBHYTThanhToanDichVu = DonGiaBHYT * Phần trăm hưởng. txtNguonKhacDichVu = 0, txtNguoiBenhTraDichVu = DonGiaBHYT - txtNguonKhacDichVu - txtBHYTThanhToanDichVu
            //Đồng thời con  trỏ nhảy qua ô số lượng, để người dùng chỉnh sửa.

            try
            {
                decimal DonGiaBHYT = Math.Round((decimal)txtThuoc.SelectedValues["DonGiaBHYT"] * txtSoLuongThuoc.Value);
                txtBHYTTT.Value = Math.Round(DonGiaBHYT * (txtPhanTramHuong.Value / 100));
                txtDonGiaBHYT.Value = Math.Round((decimal)txtThuoc.SelectedValues["DonGiaBHYT"]);
                //txtNguoiBenhTraThuoc.Value = txtBHYTTT.Value - txtNguonKhacThuoc.Value - txtBHYTTT.Value;

            }
            catch { }
        }

        private void txtThuoc_TextChanged(object sender, EventArgs e)
        {
            if (txtThuoc.Text.Trim().Length == 0)
            {
                m_LoaiChiPhi = "";
                m_MaChiPhi = "";
                txtNguonKhacThuoc.Value = 0;
                txtBHYTTT.Value = 0;
                txtDonGiaBHYT.Value = 0;
                txtSoLuongThuoc.Value = 1;
                
                btnClearChiPhi.Visible = false;
            }
            else
            {
                try
                {
                    if (TrangThai != "")
                    {
                        btnClearChiPhi.Visible = true;
                    }

                    decimal DonGiaBHYT = Math.Round((decimal)txtThuoc.SelectedValues["DonGiaBHYT"] * txtSoLuongThuoc.Value);
                    txtBHYTTT.Value = Math.Round(DonGiaBHYT * (txtPhanTramHuong.Value / 100));
                    txtDonGiaBHYT.Value = Math.Round((decimal)txtThuoc.SelectedValues["DonGiaBHYT"]);
                    //txtNguoiBenhTraThuoc.Value = txtBHYTTT.Value - txtNguonKhacThuoc.Value - txtBHYTTT.Value;
                    //txtSoLuongThuoc.Focus();
                }
                catch { }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(txtTuNgay.GetDate.ToString());
            Close();
            GC.Collect();
        }

        private void txtMaCSKCBBD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsDM_CSKCB obj = new clsDM_CSKCB();
                obj.GetByKey(txtMaCSKCBBD.Text);
                txtTenCSKCBBD.Text = obj.TenCSKCB;//txtMaCSKCBBD.SelectedValues["TenCSKCB"].ToString();

            }
            catch { }
        }

        private void txtMaICD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMaICD.SelectedValues["MaICD"].ToString() != "")
                {
                    txtChanDoan.Text = txtMaICD.SelectedValues["TenICD"].ToString();
                }
                txtChanDoan.Select(txtChanDoan.Text.Length, 0);

            }
            catch { }
        }

        private void CheckDungTuyen()
        {
            if (m_CSKCB.MaCSKCB.Trim() == txtMaCSKCBBD.Text)
            {
                cboTuyenKham.SelectedValue = "1";
                txtNoiChuyenDen.Focus();
            }
            else
            {
                cboTuyenKham.SelectedValue = "0";
                txtKhoa.Focus();

            }
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



        private void txtNgaySinh_Validated(object sender, EventArgs e)
        {
            if (txtNgaySinh.Text.Replace("/", "").Trim().Length > 0 && txtNgaySinh.GetDate == null)
            {
                txtNgaySinh.Focus();
                txtNamSinh.Clear();
                return;
            }

            if (txtNgaySinh.GetDate != null && txtTuNgay.GetDate != null && txtNgaySinh.GetDate > txtTuNgay.GetDate)
            {
                lblThongBao.Text = "Ngày sinh phải nhỏ hơn ngày bắt đầu của thẻ.";
                timerThongBao.Enabled = true;
            }

            if (txtNgaySinh.GetDate != null)
            {
                txtNamSinh.Text = txtNgaySinh.GetDate.Value.Year.ToString();
                txtNamSinh.Enabled = false;
                cboGioiTinh.Focus();

            }
            else
            {
                txtNamSinh.Enabled = true;
                txtNamSinh.Focus();
            }
        }

        private void grdChiPhiThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdChiPhiThuoc.SelectedRows.Count > 0)
            {
                m_MaChiPhi = grdChiPhiThuoc.CurrentRow.Cells["MaChiPhi"].Value.ToString();
                m_LoaiChiPhi = grdChiPhiThuoc.CurrentRow.Cells["MaLoaiChiPhi"].Value.ToString();

                txtThuoc.Text = grdChiPhiThuoc.CurrentRow.Cells["TenChiPhi"].Value.ToString();
                txtSoLuongThuoc.Value = (decimal)grdChiPhiThuoc.CurrentRow.Cells["SoLuong"].Value;
                txtBHYTTT.Value = (decimal)grdChiPhiThuoc.CurrentRow.Cells["BHYTThanhToan"].Value;
                txtNguonKhacThuoc.Value = (decimal)grdChiPhiThuoc.CurrentRow.Cells["NguonKhac"].Value;
                txtDonGiaBHYT.Value = (decimal)grdChiPhiThuoc.CurrentRow.Cells["DonGiaBHYT"].Value;

                isCapNhat = true;
            }
            else
            {
                m_MaChiPhi = string.Empty;
                m_LoaiChiPhi = string.Empty;
                isCapNhat = false;
            }
        }

        #endregion

        #region Hàm gọi
        private void FillBangKe(ref List<clsBangKeChiTiet> chitiets, int intBangKe_Id)
        {


            foreach (DataRow dr in TableChiPhiThuoc.Rows)
            {
                clsBangKeChiTiet obj = new clsBangKeChiTiet();
                obj.BangKe_Id = intBangKe_Id;
                obj.MaChiPhi = dr["MaChiPhi"].ToString();
                obj.MaPhu = dr["MaPhu"].ToString();
                obj.TenChiPhi = dr["TenChiPhi"].ToString();
                obj.DonViTinh = dr["DonViTinh"].ToString();
                obj.SoLuong = (decimal)dr["SoLuong"];
                obj.PhanTramDuocHuong = (decimal)dr["PhanTramDuocHuong"];
                obj.DonGiaBHYT = (decimal)dr["DonGiaBHYT"];
                obj.ThanhTienBHYT = (decimal)dr["ThanhTienBHYT"];
                obj.BHYTThanhToan = (decimal)dr["BHYTThanhToan"];
                obj.NguonKhac = (decimal)dr["NguonKhac"];
                obj.NguoiBenhTra = (decimal)dr["NguoiBenhTra"];
                obj.ChiPhiNgoaiDinhSuat = (decimal)dr["ChiPhiNgoaiDinhSuat"];
                obj.MaNhom1 = dr["MaNhom1"].ToString();
                obj.MaNhom2 = dr["MaNhom2"].ToString();
                obj.MaLoaiChiPhi = dr["MaLoaiChiPhi"].ToString();
                obj.VTYTDichVuKTC = string.IsNullOrEmpty(dr["VTYTDichVuKTC"].ToString()) ? false : (bool)dr["VTYTDichVuKTC"];
                obj.DichVuKTC = string.IsNullOrEmpty(dr["DichVuKTC"].ToString()) ? false : (bool)dr["DichVuKTC"];
                obj.GhiChu = dr["GhiChu"].ToString();
                obj.TyLeThanhToan = string.IsNullOrEmpty(dr["TyLeThanhToan"].ToString()) ? 100 : (decimal)dr["TyLeThanhToan"];
                chitiets.Add(obj);
            }

            //}
        }

        private void FillBangKe(ref clsBangKe bangKe)
        {
            if (m_BangKe_Id != 0)
            {
                bangKe.BangKe_Id = m_BangKe_Id;
            }
            bangKe.LoaiBangKe = m_LoaiBangKe;

            //Số hồ sơ được dùng để lưu Số đăng ký khám bệnh
            bangKe.SoHoSo = txtSoDK.Text;
            bangKe.Khoa = txtKhoa.Text;
            bangKe.PhanTramDuocHuong = txtPhanTramHuong.Value;
            bangKe.MaKhamChuaBenh = txtMaKhamChuBenh.Text;
            bangKe.MaNguoiBenh = txtMaBenhNhan.Text;
            bangKe.HoTen = txtHoTen.Text;
            bangKe.GioiTinh = int.Parse(cboGioiTinh.SelectedValue.ToString());
            bangKe.NgaySinh = txtNgaySinh.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            bangKe.NamSinh = txtNamSinh.Text.Trim().Length == 0 ? null : (int?)int.Parse(txtNamSinh.Text);
            bangKe.DiaChi = txtDiaChi.Text;
            bangKe.MaNoiSinhSong = cboMaNoiSinhSong.SelectedValue.ToString();
            bangKe.SoTheBHYT = txtSoTheBHYT.Text.Replace("-", "");
            bangKe.TuNgayBH = txtTuNgay.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtTuNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            bangKe.DenNgayBH = txtDenNgay.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtDenNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            bangKe.CoBHYT = bangKe.CoBHYT.Value;
            bangKe.TreEmKhongTheBHYT = bangKe.TreEmKhongTheBHYT.Value;
            // bangKe.MucHuong = Convert.ToInt32( ((DataRowView)cboMucHuong.SelectedValue).Row["MucHuong"].ToString()) ;
            // bangKe.PhanTramDuocHuong = (decimal?)((DataRowView)cboMucHuong.SelectedValue).Row["PhanTram"]; ;
            bangKe.MaCSKCBBanDau = txtMaCSKCBBD.Text;
            bangKe.TenCSKCBBanDau = txtTenCSKCBBD.Text;
            bangKe.MaCSKCB = conf.MaCSKCB;
            bangKe.MaChiNhanh = conf.MaChiNhanh;
            bangKe.MaNoiChuyenDen = txtNoiChuyenDen.Text;
            bangKe.TenNoiChuyenDen = txtNoiChuyenDen.Text;
            bangKe.NgayDenKham = txtNgayVao.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtNgayVao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            bangKe.NgayKetThuc = txtNgayRa.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtNgayRa.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            bangKe.SoNgayDieuTri = txtSoNgay.IntValue;
            bangKe.NgayQuyetToan = txtNgayQuyetToan.Text.Replace("/", "").Trim().Length > 0 ? (DateTime?)DateTime.ParseExact(txtNgayQuyetToan.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null;
            bangKe.TuyenKhamBenh = int.Parse(cboTuyenKham.SelectedValue.ToString());
            bangKe.ChanDoan = txtChanDoan.Text;
            bangKe.BenhKhac = txtBenhKhac.Text;
            bangKe.MaICD = txtMaICD.Text;
            bangKe.TongChiPhi = (decimal?)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "True");
            bangKe.BHYTThanhToan = (decimal?)TableChiPhiThuoc.Compute("Sum(BHYTThanhToan)", "True");
            bangKe.NguoiBenhTra = (decimal?)TableChiPhiThuoc.Compute("Sum(NguoiBenhTra)", "True");
            bangKe.NguonKhac = (decimal?)TableChiPhiThuoc.Compute("Sum(NguonKhac)", "True");

            //bangKe.SoTienThanhToanToiDa 

            //bangKe.TienKham = (decimal)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "MaNhom2='10'");

            //bangKe.TienGiuong =(decimal)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "MaNhom2='12'");

            //bangKe.TienXN = (decimal)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "MaNhom2='01'");

            //bangKe.TienCDHA = (decimal)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "MaNhom1='04'");

            //bangKe.TienTDCN = (decimal)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "MaNhom1='05'");

            //bangKe.TienPTTT = (decimal)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "MaNhom2='05'"); 

            //bangKe.TienDichVuKTC= (decimal)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "MaNhom1='07'");

            //bangKe.TienMau = (decimal)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "MaNhom2='04'");

            //bangKe.TienThuoc = (decimal)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "MaNhom2='03'");

            //bangKe.TienVTYT = (decimal)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "MaNhom2='06'");

            ////bangKe.TienVTYTTH 

            //bangKe.TienVTYTTT = (decimal)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "MaNhom2='09'"); 

            //bangKe.TienVanChuyen = (decimal)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "MaNhom2='11'");

            ////bangKe.DVKTC_TinhToan 

            //bangKe.DVKTC_ThanhToan =(decimal)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "MaNhom2='07'"); 

            bangKe.ChiPhiNgoaiDinhSuat = (decimal)TableChiPhiThuoc.Compute("Sum(ChiPhiNgoaiDinhSuat)", "True");

            //bangKe.DaGuiBHYT = false;

            //bangKe.NgayGuiBHYT 
            //bangKe.NguoiGuiBHYT 
            //bangKe.NgayTao 
            //bangKe.NguoiTao 
            //bangKe.NgayCapNhat 
            //bangKe.NguoiCapNhat 
            bangKe.ChungNhanKhongCCT = chkChungTuKhongCCT.Checked;

        }

        private void SaveData()
        {
            //Validate trước khi lưu

            //Kiểm tra trạng thái là thêm mới hay sửa gọi hàm tương ứng
            try
            {
                if (TrangThai == "ThemMoi")
                {

                    InsertData();

                    //ResetControl();

                    if (m_BangKe_Id > 0)
                    {
                        // LoadData(0);
                        txtSoHoSo.Text = m_BangKe_Id.ToString();
                        txtThuoc.Text = "";

                    }

                }
                else if (TrangThai == "CapNhat")
                {
                    UpdateData();

                }
                TrangThai = "";
                SetControlStatusReadOnly(true);

            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình lưu.Vui lòng kiểm tra lại thông tin.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblThongBao.Text = "Có lỗi trong quá trình lưu.Vui lòng kiểm tra lại thông tin!";
                //timerThongBao.Enabled = true;
            }

        }

        private void InsertData()
        {
            SQLiteDAL DAL = new SQLiteDAL();
            DAL.BeginTransaction();
            clsBangKe objBangKe = new clsBangKe();
            List<clsBangKeChiTiet> chitiets = new List<clsBangKeChiTiet>();
            try
            {
                FillBangKe(ref objBangKe);
                int intBangKe_Id = objBangKe.Insert(DAL);

                m_BangKe_Id = intBangKe_Id;

                int kq = 0;
                if (intBangKe_Id > 0)
                {

                    FillBangKe(ref chitiets, intBangKe_Id);
                    foreach (clsBangKeChiTiet ct in chitiets)
                    {
                        kq = ct.Insert(DAL);
                        if (kq <= 0)
                        {
                            DAL.RollbackTransaction();
                            return;
                        }
                    }
                }
                else
                {
                    DAL.RollbackTransaction();
                    return;
                }

                DAL.CommitTransaction();
                //MessageBox.Show("Thêm mới bảng kê thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblThongBao.Text = "Thêm mới bảng kê thành công.";
                timerThongBao.Enabled = true;
            }
            catch (Exception ex)
            {
                DAL.RollbackTransaction();
                MessageBox.Show("Thêm mới bảng kê không thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //lblThongBao.Text = "Thêm mới bảng kê không thành công";
                //timerThongBao.Enabled = true;
            }
        }

        private void UpdateData()
        {
            SQLiteDAL DAL = new SQLiteDAL();
            DAL.BeginTransaction();
            clsBangKe objBangKe = new clsBangKe();
            List<clsBangKeChiTiet> chitiets = new List<clsBangKeChiTiet>();

            try
            {
                objBangKe.GetByKey(m_BangKe_Id);

                FillBangKe(ref objBangKe);
                int kq = objBangKe.Update(DAL);

                if (kq > 0)
                {
                    kq = objBangKe.DeleteBangKeChiTiet(m_BangKe_Id, DAL);
                    if (kq > 0)
                    {
                        FillBangKe(ref chitiets, m_BangKe_Id);
                        foreach (clsBangKeChiTiet ct in chitiets)
                        {
                            kq = ct.Insert(DAL);
                            if (kq <= 0)
                            {
                                DAL.RollbackTransaction();
                                return;
                            }
                        }
                    }
                    else
                    {
                        DAL.RollbackTransaction();
                        return;
                    }

                }
                else
                {
                    DAL.RollbackTransaction();
                    return;
                }

                DAL.CommitTransaction();
                //MessageBox.Show("Cập nhật bảng kê thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblThongBao.Text = "Cập nhật bảng kê thành công.";
                timerThongBao.Enabled = true;
            }
            catch (Exception ex)
            {
                DAL.RollbackTransaction();
                m_BangKe_Id = 0;
                txtSoHoSo.Text = "";
                MessageBox.Show("Cập nhật bảng kê không thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //lblThongBao.Text = "Cập nhật bảng kê không thành công";
                //timerThongBao.Enabled = true;
            }
        }

        bool IsRunCheck = false;
        private void LoadData(int status)
        {

            if (IsRunCheck == true)
            {
                return;
            }
            //Nếu trang thái là 3 và có số đăng ký ở trang thái thêm mới thì GetSoDangKy từ DangKyKhamBenh
            if (status == 3 && txtSoDK.Text.Trim().Length > 0 && TrangThai == "ThemMoi")
            {

                clsDangKyKhamBenh obj = new clsDangKyKhamBenh();
                obj.GetByKey(txtSoDK.Text.Trim());

                if (obj.KhamBenh_Id <= 0)
                {
                    txtSoDK.Text = string.Empty;
                    ResetControl();
                    return;
                }
                IsRunCheck = true;
                txtSoTheBHYT.Text = obj.SoTheBHYT.ToString();
                txtHoTen.Text = obj.HoTen;
                txtDiaChi.Text = obj.DiaChi;
                txtTuNgay.Text = string.Format("{0:dd/MM/yyyy}", obj.TuNgay);
                txtDenNgay.Text = string.Format("{0:dd/MM/yyyy}", obj.DenNgay);
                txtNgaySinh.Text = string.Format("{0:dd/MM/yyyy}", obj.NgaySinh);
                txtNgayVao.Text = string.Format("{0:dd/MM/yyyy}", obj.NgayDenKham);
                txtNamSinh.Text = obj.NgaySinh.Value.Year.ToString();

                clsDM_CSKCB objCSKCB = new clsDM_CSKCB();
                objCSKCB.GetByKey(obj.MaCSKCBBĐ);
                txtMaCSKCBBD.Text = obj.MaCSKCBBĐ;
                txtTenCSKCBBD.Text = objCSKCB.TenCSKCB;
                txtNoiChuyenDen.Text = obj.MaNoiChuyenDen;
                cboTuyenKham.SelectedValue = obj.LyDoVV.ToString();
                cboGioiTinh.SelectedValue = obj.GioiTinh.ToString();
                cboMaNoiSinhSong.SelectedValue = obj.MaNoiSinhSong.ToString();



                LoadMaCSKCBTheoMaTinh();
                //CheckDungTuyen();
                txtMaBenhNhan.Focus();
            }

            /*
             * Load thông tin từ Bảng Kê
             * Trang thái 0 : Get từ Form Search 
             * Trang Thai 1: Get thông tin bằng Mã khám chữa bệnh
             * Trạng thái 2: Get thông tin bằng thẻ BHYT
             * Trang thái 3: Get bằng số đăng ký.
             */
            if (status == 0 || status == 1 || status == 2 || (TrangThai == "" && status == 3))
            {
                clsBangKe obj = new clsBangKe();
                if (TrangThai.Trim() == "" && status == 1)
                {
                    if (txtMaKhamChuBenh.Text.Trim().Length > 0)
                    {
                        obj.GetByMaKhamChuaBenh(txtMaKhamChuBenh.Text);
                        if (obj.MaKhamChuaBenh == null || obj.MaKhamChuaBenh.Trim() == "")
                        {
                            MessageBox.Show("Không tìm thấy Mã khám chữa bệnh " + txtMaKhamChuBenh.Text + " này.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ResetControl();
                            txtMaKhamChuBenh.Focus();
                            return;
                        }
                        m_BangKe_Id = obj.BangKe_Id;
                    }
                    else
                    {
                        ResetControl();
                        txtMaKhamChuBenh.Focus();
                        return;
                    }
                    IsRunCheck = true;
                }
                else if (TrangThai.Trim() == "" && status == 2)
                {

                    if (txtSoTheBHYT.Text.Replace("-", "").Trim().Length > 0)
                    {
                        obj.GetByKey(txtSoTheBHYT.Text.Replace("-", "").Trim());
                        if (obj.MaKhamChuaBenh == null || obj.MaKhamChuaBenh.Trim() == "")
                        {
                            MessageBox.Show("Không tìm thấy số thẻ " + txtSoTheBHYT.Text + " này.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ResetControl();
                            txtSoTheBHYT.Focus();
                            return;
                        }

                    }
                    else
                    {
                        ResetControl();
                        txtSoTheBHYT.Focus();
                        return;
                    }
                    IsRunCheck = true;
                }
                else if (TrangThai.Trim() == "" && status == 3)
                {
                    obj.GetBySoDK(txtSoDK.Text);
                    if (obj.MaKhamChuaBenh == null || obj.MaKhamChuaBenh.Trim() == "")
                    {
                        MessageBox.Show("Không tìm thấy số đăng ký " + txtSoDK.Text + " này.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ResetControl();
                        txtSoDK.Focus();
                        return;
                    }

                }
                else if (status == 0)
                {
                    IsRunCheck = true;
                    obj.GetByKey(m_BangKe_Id);
                }
                m_BangKe_Id = obj.BangKe_Id;


                //txtSoHoSo.Text = obj.SoHoSo;

                txtSoHoSo.Text = obj.BangKe_Id.ToString();
                txtMaKhamChuBenh.Text = obj.MaKhamChuaBenh;

                //if (status != 2)
                //{
                txtSoTheBHYT.Text = obj.SoTheBHYT;
                //}



                txtTuNgay.Text = string.Format("{0:dd/MM/yyyy}", obj.TuNgayBH);
                txtDenNgay.Text = string.Format("{0:dd/MM/yyyy}", obj.DenNgayBH);
                txtDiaChi.Text = obj.DiaChi;
                txtKhoa.Text = obj.Khoa;
                txtHoTen.Text = obj.HoTen;
                txtMaBenhNhan.Text = obj.MaNguoiBenh;
                cboTuyenKham.SelectedValue = obj.TuyenKhamBenh.ToString();

                txtNamSinh.Text = obj.NamSinh.ToString();

                cboTinhTrang.SelectedIndex = obj.DaGuiBHYT.Value ? 1 : 0;

                txtSoNgay.Text = obj.SoNgayDieuTri.Value.ToString();
                txtNgayVao.Text = string.Format("{0:dd/MM/yyyy}", obj.NgayDenKham);
                txtNgayRa.Text = string.Format("{0:dd/MM/yyyy}", obj.NgayKetThuc);
                txtNgayQuyetToan.Text = string.Format("{0:dd/MM/yyyy}", obj.NgayQuyetToan);
                txtMaICD.Text = obj.MaICD;
                txtChanDoan.Text = obj.ChanDoan;
                cboGioiTinh.SelectedValue = obj.GioiTinh.ToString();
                cboMaNoiSinhSong.SelectedValue = obj.MaNoiSinhSong;
                txtMaCSKCBBD.Text = obj.MaCSKCBBanDau;
                txtTenCSKCBBD.Text = obj.TenCSKCBBanDau;
                txtNoiChuyenDen.Text = obj.MaNoiChuyenDen;
                txtNgaySinh.Text = string.Format("{0:dd/MM/yyyy}", obj.NgaySinh);
                txtBenhKhac.Text = obj.BenhKhac;


                chkChungTuKhongCCT.Checked = obj.ChungNhanKhongCCT.Value;

                txtSoDK.Text = obj.SoHoSo;

                LoadMaCSKCBTheoMaTinh();

                // txtMaCSKCBBD.UpdateData();
                txtThuoc.Clear();


                clsBangKeChiTiet chitiet = new clsBangKeChiTiet();
                TableChiPhiThuoc = chitiet.GetAll(m_BangKe_Id);
                grdChiPhiThuoc.DataSource = TableChiPhiThuoc;

                txtTongChiPhi.Text = string.Format("{0:#,##0}", TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "True"));
                txtBHYTThanhToan.Text = string.Format("{0:#,##0}", TableChiPhiThuoc.Compute("Sum(BHYTThanhToan)", "True"));
                txtNguoiBenhTra.Text = string.Format("{0:#,##0}", TableChiPhiThuoc.Compute("Sum(NguoiBenhTra)", "True"));
                txtNguonKhac.Text = string.Format("{0:#,##0}", TableChiPhiThuoc.Compute("Sum(NguonKhac)", "True"));
                txtNgoaiDinhSuat.Text = string.Format("{0:#,##0}", TableChiPhiThuoc.Compute("Sum(ChiPhiNgoaiDinhSuat)", "True"));
                txtThuoc.Focus();
                txtThuoc.Text = "";
                txtSoLuongThuoc.Value = 1;
                txtPhanTramHuong.Value = obj.PhanTramDuocHuong ?? 0;
            }

            //txtMaICD.UpdateData();




            this.grdChiPhiThuoc.Sort(this.grdChiPhiThuoc.Columns["GroupName"], ListSortDirection.Ascending);
            IsRunCheck = false;

        }

        private void ThemVaCapNhatChiPhi()
        {
            if (txtSoTheBHYT.Text.Replace("-", "").Length < 15)
            {
                MessageBox.Show("Vui lòng nhập số thẻ BHYT trước khi thêm chi phí.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblThongBao.Text = "Vui lòng nhập số thẻ BHYT trước khi thêm chi phí!";
                //timerThongBao.Enabled = true;

                txtThuoc.Focus();
                return;
            }
            string MaChiPhi = txtThuoc.SelectedValues["MaChiPhi"].ToString();
            string LoaiChiPhi = txtThuoc.SelectedValues["LoaiChiPhi"].ToString();

            bool isUpdateChiTiet = false;

            isCapNhat = false;

            if (m_MaChiPhi.Trim().Length > 0 && m_LoaiChiPhi.Trim().Length > 0)
            {
                MaChiPhi = m_MaChiPhi;
                LoaiChiPhi = m_LoaiChiPhi;
                isUpdateChiTiet = true;
                isCapNhat = true;
            }

            DataRow[] existsRows = TableChiPhiThuoc.Select("MaChiPhi ='" + MaChiPhi + "'");

            if (LoaiChiPhi == "T")
            {
                clsDM_Thuoc t = new clsDM_Thuoc();
                t.GetByKey(MaChiPhi);

                if (existsRows.Length > 0)
                {
                    if (!isUpdateChiTiet && MessageBox.Show("Mã " + MaChiPhi + " chi phí này tồn tại? Bạn có muốn cập nhật số lượng?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        existsRows[0]["SoLuong"] = (decimal)existsRows[0]["SoLuong"] + txtSoLuongThuoc.Value;

                    }
                    else
                    {
                        existsRows[0]["SoLuong"] = txtSoLuongThuoc.Value;
                    }


                    existsRows[0]["PhanTramDuocHuong"] = txtPhanTramHuong.Text;

                    decimal ThanhTienBHYT = Math.Round((decimal)existsRows[0]["SoLuong"] * t.DonGiaThau.Value);
                    decimal BHYTThanhToan = Math.Round(((decimal)existsRows[0]["SoLuong"] * t.DonGiaThau.Value) * (txtPhanTramHuong.Value / 100) * (t.TyLeThanhToan.Value / 100));
                    decimal NguoiBenhTra = ThanhTienBHYT - txtNguonKhacThuoc.Value - BHYTThanhToan;

                    existsRows[0]["ThanhTienBHYT"] = ThanhTienBHYT;
                    existsRows[0]["BHYTThanhToan"] = BHYTThanhToan;
                    existsRows[0]["NguoiBenhTra"] = NguoiBenhTra; ;
                    existsRows[0]["NguonKhac"] = txtNguonKhacThuoc.Value;
                    existsRows[0]["ChiPhiNgoaiDinhSuat"] = 0;
                    existsRows[0]["TyLeThanhToan"] = t.TyLeThanhToan.Value;
                    TableChiPhiThuoc.AcceptChanges();
                }
                else
                {

                    DataRow dr = TableChiPhiThuoc.NewRow();
                    dr["MaChiPhi"] = t.MaThuoc;
                    //dr["MaPhu"] = t.MaPhu ;
                    dr["TenChiPhi"] = t.TenThuoc;
                    dr["DonViTinh"] = t.DonViTinh;
                    dr["SoLuong"] = txtSoLuongThuoc.Value;
                    dr["DonGiaBHYT"] = t.DonGiaThau;
                    dr["PhanTramDuocHuong"] = txtPhanTramHuong.Text;

                    decimal ThanhTienBHYT = Math.Round(txtSoLuongThuoc.Value * t.DonGiaThau.Value);
                    decimal BHYTThanhToan = Math.Round((txtSoLuongThuoc.Value * t.DonGiaThau.Value) * (txtPhanTramHuong.Value / 100) * (t.TyLeThanhToan.Value / 100));
                    decimal NguoiBenhTra = ThanhTienBHYT - txtNguonKhacThuoc.Value - BHYTThanhToan;

                    dr["ThanhTienBHYT"] = ThanhTienBHYT;
                    dr["BHYTThanhToan"] = BHYTThanhToan;
                    dr["NguoiBenhTra"] = NguoiBenhTra;
                    dr["NguonKhac"] = txtNguonKhacThuoc.Value;
                    dr["ChiPhiNgoaiDinhSuat"] = 0;
                    dr["MaNhom1"] = t.MaNhom1;
                    dr["MaNhom2"] = t.MaNhom2;
                    dr["MaLoaiChiPhi"] = LoaiChiPhi;
                    //dr["VTYTDichVuKTC"] = t.VTYTDichVuKTC ;
                    //dr["DichVuKTC"] = t.DichVuKTC ;
                    dr["GhiChu"] = t.GhiChu;

                    dr["TyLeThanhToan"] = t.TyLeThanhToan.Value;

                    dr["GroupName"] = "Thuốc";

                    TableChiPhiThuoc.Rows.Add(dr);
                }
            }

            else if (LoaiChiPhi == "D")
            {
                clsDM_DichVu dv = new clsDM_DichVu();
                dv.GetByKey(MaChiPhi);

                if (existsRows.Length > 0)
                {
                    if (!isUpdateChiTiet && MessageBox.Show("Mã " + MaChiPhi + " chi phí này tồn tại? Bạn có muốn cập nhật số lượng?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        existsRows[0]["SoLuong"] = (decimal)existsRows[0]["SoLuong"] + txtSoLuongThuoc.Value;
                    }
                    else
                    {
                        existsRows[0]["SoLuong"] = txtSoLuongThuoc.Value;
                    }
                    existsRows[0]["PhanTramDuocHuong"] = txtPhanTramHuong.Text;


                    decimal ThanhTienBHYT = Math.Round((decimal)existsRows[0]["SoLuong"] * dv.DonGiaBHYT.Value);
                    decimal BHYTThanhToan = Math.Round(((decimal)existsRows[0]["SoLuong"] * dv.DonGiaBHYT.Value) * (txtPhanTramHuong.Value / 100));
                    decimal NguoiBenhTra = ThanhTienBHYT - txtNguonKhacThuoc.Value - BHYTThanhToan;

                    existsRows[0]["ThanhTienBHYT"] = ThanhTienBHYT;
                    existsRows[0]["BHYTThanhToan"] = BHYTThanhToan;
                    existsRows[0]["NguoiBenhTra"] = NguoiBenhTra; ;
                    existsRows[0]["NguonKhac"] = txtNguonKhacThuoc.Value;
                    existsRows[0]["ChiPhiNgoaiDinhSuat"] = 0;
                    TableChiPhiThuoc.AcceptChanges();
                }
                else
                {

                    DataRow dr = TableChiPhiThuoc.NewRow();
                    dr["MaChiPhi"] = dv.MaDichVu;
                    dr["MaPhu"] = dv.MaKhac;
                    dr["TenChiPhi"] = dv.TenDichVu;
                    dr["DonViTinh"] = dv.DonViTinh;
                    dr["SoLuong"] = txtSoLuongThuoc.Value;
                    dr["DonGiaBHYT"] = dv.DonGiaBHYT;
                    dr["PhanTramDuocHuong"] = txtPhanTramHuong.Text;

                    decimal ThanhTienBHYT = Math.Round(txtSoLuongThuoc.Value * dv.DonGiaBHYT.Value);
                    decimal BHYTThanhToan = Math.Round((txtSoLuongThuoc.Value * dv.DonGiaBHYT.Value) * (txtPhanTramHuong.Value / 100));
                    decimal NguoiBenhTra = ThanhTienBHYT - txtNguonKhacThuoc.Value - BHYTThanhToan;

                    dr["ThanhTienBHYT"] = ThanhTienBHYT;
                    dr["BHYTThanhToan"] = BHYTThanhToan;
                    dr["NguoiBenhTra"] = NguoiBenhTra;
                    dr["NguonKhac"] = txtNguonKhacThuoc.Value;
                    dr["ChiPhiNgoaiDinhSuat"] = 0;
                    dr["MaNhom1"] = dv.MaNhom1;
                    dr["MaNhom2"] = dv.MaNhom2;
                    dr["MaLoaiChiPhi"] = LoaiChiPhi;
                    //dr["VTYTDichVuKTC"] = t.VTYTDichVuKTC ;
                    dr["DichVuKTC"] = dv.DichVuKTC.Value;
                    dr["GhiChu"] = dv.GhiChu;

                    dr["GroupName"] = "Dịch vụ";

                    TableChiPhiThuoc.Rows.Add(dr);
                }
            }
            else if (LoaiChiPhi == "V")
            {
                clsDM_VTYT vtyt = new clsDM_VTYT();
                vtyt.GetByKey(MaChiPhi);

                if (existsRows.Length > 0)
                {
                    if (!isUpdateChiTiet && MessageBox.Show("Mã " + MaChiPhi + " chi phí này tồn tại? Bạn có muốn cập nhật số lượng?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        existsRows[0]["SoLuong"] = (decimal)existsRows[0]["SoLuong"] + txtSoLuongThuoc.Value;

                    }
                    else
                    {
                        existsRows[0]["SoLuong"] = txtSoLuongThuoc.Value;
                    }
                    existsRows[0]["PhanTramDuocHuong"] = txtPhanTramHuong.Text;
                    decimal ThanhTienBHYT = Math.Round((decimal)existsRows[0]["SoLuong"] * vtyt.DonGiaThau.Value);
                    decimal BHYTThanhToan = Math.Round(((decimal)existsRows[0]["SoLuong"] * vtyt.DonGiaThau.Value) * (txtPhanTramHuong.Value / 100));
                    decimal NguoiBenhTra = ThanhTienBHYT - txtNguonKhacThuoc.Value - BHYTThanhToan;

                    existsRows[0]["ThanhTienBHYT"] = ThanhTienBHYT;
                    existsRows[0]["BHYTThanhToan"] = BHYTThanhToan;
                    existsRows[0]["NguoiBenhTra"] = NguoiBenhTra; ;
                    existsRows[0]["NguonKhac"] = txtNguonKhacThuoc.Value;
                    existsRows[0]["ChiPhiNgoaiDinhSuat"] = 0;
                    TableChiPhiThuoc.AcceptChanges();
                }
                else
                {

                    DataRow dr = TableChiPhiThuoc.NewRow();
                    dr["MaChiPhi"] = vtyt.MaVTYT;
                    // dr["MaPhu"] = vtyt.;
                    dr["TenChiPhi"] = vtyt.TenVTYT;
                    dr["DonViTinh"] = vtyt.DonViTinh;
                    dr["SoLuong"] = txtSoLuongThuoc.Value;
                    dr["DonGiaBHYT"] = vtyt.DonGiaThau;
                    dr["PhanTramDuocHuong"] = txtPhanTramHuong.Text;

                    decimal ThanhTienBHYT = Math.Round(txtSoLuongThuoc.Value * vtyt.DonGiaThau.Value);
                    decimal BHYTThanhToan = Math.Round((txtSoLuongThuoc.Value * vtyt.DonGiaThau.Value) * (txtPhanTramHuong.Value / 100));
                    decimal NguoiBenhTra = ThanhTienBHYT - txtNguonKhacThuoc.Value - BHYTThanhToan;
                    dr["ThanhTienBHYT"] = ThanhTienBHYT;
                    dr["BHYTThanhToan"] = BHYTThanhToan;
                    dr["NguoiBenhTra"] = NguoiBenhTra;
                    dr["NguonKhac"] = txtNguonKhacThuoc.Value;

                    dr["ChiPhiNgoaiDinhSuat"] = 0;
                    dr["MaNhom1"] = vtyt.MaNhom1;
                    dr["MaNhom2"] = vtyt.MaNhom2;
                    dr["MaLoaiChiPhi"] = LoaiChiPhi;
                    dr["VTYTDichVuKTC"] = vtyt.VTYTDichVuKTC.Value;
                    //dr["DichVuKTC"] = t.DichVuKTC ;
                    dr["GhiChu"] = vtyt.GhiChu;
                    dr["GroupName"] = "Vật tư y tế";
                    TableChiPhiThuoc.Rows.Add(dr);
                }
            }
            else if (LoaiChiPhi == "M")
            {
                clsDM_Mau m = new clsDM_Mau();
                m.GetByKey(MaChiPhi);

                if (existsRows.Length > 0)
                {
                    if (MessageBox.Show("Mã " + MaChiPhi + " chi phí này tồn tại? Bạn có muốn cập nhật số lượng?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        existsRows[0]["SoLuong"] = (decimal)existsRows[0]["SoLuong"] + txtSoLuongThuoc.Value;

                    }
                    else
                    {
                        existsRows[0]["SoLuong"] = txtSoLuongThuoc.Value;
                    }
                    existsRows[0]["PhanTramDuocHuong"] = txtPhanTramHuong.Text;

                    decimal ThanhTienBHYT = Math.Round((decimal)existsRows[0]["SoLuong"] * m.DonGiaBHYT.Value);
                    decimal BHYTThanhToan = Math.Round(((decimal)existsRows[0]["SoLuong"] * m.DonGiaBHYT.Value) * (txtPhanTramHuong.Value / 100));
                    decimal NguoiBenhTra = ThanhTienBHYT - txtNguonKhacThuoc.Value - BHYTThanhToan;

                    existsRows[0]["ThanhTienBHYT"] = ThanhTienBHYT;
                    existsRows[0]["BHYTThanhToan"] = BHYTThanhToan;
                    existsRows[0]["NguoiBenhTra"] = NguoiBenhTra; ;
                    existsRows[0]["NguonKhac"] = txtNguonKhacThuoc.Value;

                    existsRows[0]["ChiPhiNgoaiDinhSuat"] = 0;
                    TableChiPhiThuoc.AcceptChanges();
                }
                else
                {

                    DataRow dr = TableChiPhiThuoc.NewRow();
                    dr["MaChiPhi"] = m.MaMauVaChePhamMau;
                    // dr["MaPhu"] = vtyt.;
                    dr["TenChiPhi"] = m.TenMauVaChePhamMau;
                    dr["DonViTinh"] = m.DonViTinh;
                    dr["SoLuong"] = txtSoLuongThuoc.Value;
                    dr["DonGiaBHYT"] = m.DonGiaBHYT;
                    dr["PhanTramDuocHuong"] = txtPhanTramHuong.Text;

                    decimal ThanhTienBHYT = Math.Round(txtSoLuongThuoc.Value * m.DonGiaBHYT.Value);
                    decimal BHYTThanhToan = Math.Round((txtSoLuongThuoc.Value * m.DonGiaBHYT.Value) * (txtPhanTramHuong.Value / 100));
                    decimal NguoiBenhTra = ThanhTienBHYT - txtNguonKhacThuoc.Value - BHYTThanhToan;
                    dr["ThanhTienBHYT"] = ThanhTienBHYT;
                    dr["BHYTThanhToan"] = BHYTThanhToan;
                    dr["NguoiBenhTra"] = NguoiBenhTra;
                    dr["NguonKhac"] = txtNguonKhacThuoc.Value;

                    dr["ChiPhiNgoaiDinhSuat"] = 0;
                    dr["MaNhom1"] = m.MaNhom1;
                    dr["MaNhom2"] = m.MaNhom2;
                    dr["MaLoaiChiPhi"] = LoaiChiPhi;
                    //dr["VTYTDichVuKTC"] = vtyt.VTYTDichVuKTC;
                    //dr["DichVuKTC"] = t.DichVuKTC ;
                    dr["GhiChu"] = m.GhiChu;
                    dr["GroupName"] = "Máu và chế phẩm";
                    TableChiPhiThuoc.Rows.Add(dr);
                }
            }
            m_MaChiPhi = "";
            m_LoaiChiPhi = "";
            txtThuoc.ClearSelection();
            TinhTongGridView();
            txtThuoc.Focus();

        }

        private void TinhTongGridView()
        {


            //Tinh lai muc huong
            //10 :Tuyên Xa, 20: Tuyến Huyện, 30: Tuyến Tỉnh, 40: Tuyến TW
            //10: Ngoai tru, 20: NoiTru

            //Check MaCSKB hê thống là tuyen gì?
            decimal? tongchiphi = 0;
            try
            {
                tongchiphi = (decimal?)TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "True");
            }
            catch { }

            bool dungTuyen = false;
            if (cboTuyenKham.SelectedValue.ToString() == "1" || cboTuyenKham.SelectedValue.ToString() == "2")
                dungTuyen = true;

            string maNoiSinhSong = cboMaNoiSinhSong.SelectedValue.ToString();
            DateTime? ngayThanhToan = txtNgayQuyetToan.GetDate.Value;
            decimal phanTram = CalculateBHYT.GetPhanTramDuocHuong(txtSoTheBHYT.Text, dungTuyen, (byte)m_CSKCB.Tuyen, tongchiphi.Value, maNoiSinhSong, (m_LoaiBangKe == 2 ? (byte)EnumHinhThucKham.NoiTru : (byte)EnumHinhThucKham.NgoaiTru), ngayThanhToan.Value, luong, cds, mhs, chkChungTuKhongCCT.Checked);
            txtPhanTramHuong.Value = phanTram;
            //Tinh lai chi phi
            TableChiPhiThuoc.AcceptChanges();

            foreach (DataRow row in TableChiPhiThuoc.Rows)
            {
                row.BeginEdit();
                row["PhanTramDuocHuong"] = phanTram;
                decimal ThanhTienBHYT = Math.Round((decimal)row["SoLuong"] * (decimal)row["DonGiaBHYT"]);
                decimal BHYTThanhToan = Math.Round(((decimal)row["SoLuong"] * (decimal)row["DonGiaBHYT"]) * (phanTram / 100));
                decimal NguonKhac = Math.Round((decimal)row["NguonKhac"]);
                decimal NguoiBenhTra = ThanhTienBHYT - NguonKhac - BHYTThanhToan;
                row["ThanhTienBHYT"] = ThanhTienBHYT;
                row["BHYTThanhToan"] = BHYTThanhToan;
                row["NguoiBenhTra"] = NguoiBenhTra;
                row["NguonKhac"] = NguonKhac;
                row.EndEdit();
            }


            //MessageBox.Show(phanTram.ToString());

            //Tính tổng các cột
            //grdChiPhiThuoc.Update();
            txtTongChiPhi.Text = string.Format("{0:#,##0}", TableChiPhiThuoc.Compute("Sum(ThanhTienBHYT)", "True"));
            txtBHYTThanhToan.Text = string.Format("{0:#,##0}", TableChiPhiThuoc.Compute("Sum(BHYTThanhToan)", "True"));
            txtNguoiBenhTra.Text = string.Format("{0:#,##0}", TableChiPhiThuoc.Compute("Sum(NguoiBenhTra)", "True"));
            txtNguonKhac.Text = string.Format("{0:#,##0}", TableChiPhiThuoc.Compute("Sum(NguonKhac)", "True"));
            txtNgoaiDinhSuat.Text = string.Format("{0:#,##0}", TableChiPhiThuoc.Compute("Sum(ChiPhiNgoaiDinhSuat)", "True"));

            //Reset field

            txtThuoc.Text = "";
            txtSoLuongThuoc.Value = 1;
            txtBHYTTT.Value = 0;
            txtNguonKhacThuoc.Value = 0;
            txtDonGiaBHYT.Value = 0;
            //txtNguoiBenhTraThuoc.Value = 0;
            m_MaChiPhi = string.Empty;
            m_LoaiChiPhi = string.Empty;

            this.grdChiPhiThuoc.Sort(this.grdChiPhiThuoc.Columns["GroupName"], ListSortDirection.Ascending);
        }

        private string ValidateControl()
        {
            txtNgayVao_Validated(null, null);
            txtNgayRa_Leave(null, null);

            string str = "";
            if (txtMaKhamChuBenh.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập số chữa bệnh ." + Environment.NewLine;
            }
            if (txtSoTheBHYT.Text.Replace("-", "").Trim().Length == 0)
            {
                str += "- Vui lòng nhập số thẻ BHYT." + Environment.NewLine;
            }
            if (txtTuNgay.Text.Replace("/", "").Trim().Length == 0)
            {
                str += "- Vui lòng nhập từ ngày BHYT." + Environment.NewLine;
            }
            if (txtDenNgay.Text.Replace("/", "").Trim().Length == 0)
            {
                str += "- Vui lòng nhập đến ngày BHYT." + Environment.NewLine;
            }
            if (txtHoTen.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập họ tên bệnh nhân." + Environment.NewLine;
            }
            if (txtNamSinh.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập năm sinh bệnh nhân." + Environment.NewLine;
            }

            if (txtDiaChi.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập địa chỉ." + Environment.NewLine;
            }
            if (txtMaCSKCBBD.Text.Trim().Length == 0 && txtTenCSKCBBD.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập mã CSKCB" + Environment.NewLine;
            }
            if (txtTenCSKCBBD.Text.Trim().Length == 0 && txtTenCSKCBBD.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập tên CSKCB" + Environment.NewLine;
            }
            if (txtNgayVao.Text.Replace("/", "").Trim().Length == 0)
            {
                str += "- Vui lòng nhập ngày vào." + Environment.NewLine;
            }
            if (txtNgayRa.Text.Replace("/", "").Trim().Length == 0)
            {
                str += "- Vui lòng nhập ngày ra." + Environment.NewLine;
            }
            if (txtMaICD.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập mã ICD." + Environment.NewLine;
            }
            if (txtChanDoan.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập chẩn đoán." + Environment.NewLine;
            }

            if (txtNgayQuyetToan.Text.Replace("/", "").Trim().Length == 0)
            {
                str += "- Vui lòng nhập ngày thanh toán." + Environment.NewLine;
            }
            if (TableChiPhiThuoc.Rows.Count <= 0)
            {
                str += "- Không có chi phí." + Environment.NewLine;
            }

            return str;

        }


        private void ResetControl()
        {
            txtSoDK.Text = string.Empty;
            txtBenhKhac.Text = "";

            txtPhanTramHuong.Value = 0;
            cboMucHuong.SelectedValue = 0;

            txtSoTheBHYT.Clear();
            txtSoHoSo.Clear();
            txtMaBenhNhan.Clear();
            txtMaKhamChuBenh.Clear();
            txtNoiChuyenDen.Text = string.Empty;
            txtSoNgay.Text = "1";
            txtDiaChi.Text = string.Empty;
            cboMaNoiSinhSong.SelectedIndex = 0;
            txtHoTen.Text = string.Empty;


            txtTuNgay.Text = string.Empty;

            txtDenNgay.Text = string.Empty;

            txtMaBenhNhan.Text = string.Empty;
            txtNgaySinh.Text = string.Empty;
            txtNamSinh.Text = string.Empty;
            cboGioiTinh.SelectedIndex = 0;
            cboTinhTrang.SelectedIndex = 0;
            cboTuyenKham.SelectedValue = "1";
            txtMaICD.Text = string.Empty;
            //txtMaICD.ClearSelection();

            txtMaCSKCBBD.Text = string.Empty;
            //txtMaCSKCBBD.ClearSelection();
            txtMaCSKCBBD.Values = null;

            txtTenCSKCBBD.Clear();
            txtChanDoan.Text = string.Empty;
            chkChungTuKhongCCT.Checked = false;
            txtNgayRa.Text = string.Empty;
            txtNgayVao.Text = string.Empty;

            txtNgayQuyetToan.Text = string.Empty;

            txtKhoa.Text = string.Empty;
            txtThuoc.Text = string.Empty;
            txtThuoc.ClearSelection();

            txtSoLuongThuoc.Value = 1;
            txtNguonKhacThuoc.Value = 0;

            DateTime now = DateTime.Now;
            txtNgayRa.Text = string.Format("{0:dd/MM/yyyy}", now);
            txtNgayVao.Text = string.Format("{0:dd/MM/yyyy}", now);
            txtNgayQuyetToan.Text = string.Format("{0:dd/MM/yyyy}", now);
            txtBHYTTT.Controls[0].Enabled = false;

            TableChiPhiThuoc.Clear();

            txtTongChiPhi.Text = "0";
            txtNgoaiDinhSuat.Text = "0";
            txtBHYTThanhToan.Text = "0";
            txtNguonKhac.Text = "0";
            txtNguoiBenhTra.Text = "0";

            txtSoDK.Focus();
        }


        private void SetControlStatusReadOnly(bool statusControl)
        {
            txtNoiChuyenDen.ReadOnly = statusControl;
            //txtSoNgay.ReadOnly = statusControl;
            txtDiaChi.ReadOnly = statusControl;
            cboMaNoiSinhSong.Enabled = !statusControl;
            txtHoTen.ReadOnly = statusControl;



            txtTuNgay.ReadOnly = statusControl;
            //txtTuNgay.BatBuocNhap = !statusControl;

            txtDenNgay.ReadOnly = statusControl;
            //txtDenNgay.BatBuocNhap = !statusControl;

            txtMaBenhNhan.ReadOnly = statusControl;
            txtNgaySinh.ReadOnly = statusControl;
            txtNamSinh.ReadOnly = statusControl;
            cboGioiTinh.Enabled = !statusControl; ;
            cboTuyenKham.Enabled = !statusControl;
            txtMaICD.Enabled = !statusControl;

            txtBenhKhac.Enabled = !statusControl;

            txtMaCSKCBBD.Enabled = !statusControl;
            txtChanDoan.ReadOnly = statusControl;
            chkChungTuKhongCCT.Enabled = !statusControl;
            txtNgayRa.ReadOnly = statusControl;
            //txtNgayRa.BatBuocNhap = !statusControl;

            txtNgayVao.ReadOnly = statusControl;
            //txtNgayVao.BatBuocNhap = statusControl;

            txtNgayQuyetToan.ReadOnly = statusControl;
            //txtNgayQuyetToan.BatBuocNhap = !statusControl;

            txtKhoa.ReadOnly = statusControl;
            txtThuoc.ReadOnly = statusControl;
            txtSoLuongThuoc.ReadOnly = statusControl;
            txtNguonKhacThuoc.ReadOnly = statusControl;
            btnAddThuoc.Enabled = !statusControl;
            grdChiPhiThuoc.AllowUserToDeleteRows = !statusControl;
        }

        #endregion

        private void grdChiPhiThuoc_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            TinhTongGridView();
        }

        private void txtNgayRa_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtNgayRa.GetDate != null && txtTuNgay.GetDate != null && txtDenNgay.GetDate != null && (txtNgayRa.GetDate.Value < txtTuNgay.GetDate.Value || txtNgayRa.GetDate.Value > txtDenNgay.GetDate.Value))
                {
                    //MessageBox.Show("Ngày vào không được nằm ngoài thời hạn sử dụng thẻ BHYT", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblThongBao.Text = "Ngày vào không được nằm ngoài thời hạn sử dụng thẻ BHYT.";
                    timerThongBao.Enabled = true;

                    txtNgayRa.Focus();
                    // SendKeys.Send("{DEL}");
                    return;
                }

                if (txtNgayVao.GetDate != null && txtNgayRa.GetDate != null && txtNgayRa.GetDate.Value < txtNgayVao.GetDate.Value)
                {
                    lblThongBao.Text = "Ngày ra phải lớn hơn ngày vào.";
                    timerThongBao.Enabled = true;
                    txtNgayRa.Text = "";
                    txtNgayRa.Focus();
                    return;
                }
                else
                {
                    lblThongBao.Text = "";
                }

                txtNgayQuyetToan.Text = string.Format("{0:dd/MM/yyyy}", txtNgayRa.GetDate);
                TinhSoNgayVaoVien();
            }
            catch (Exception ex) { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            clsBangKe obj = new clsBangKe();
            obj.GetByKey(m_BangKe_Id);

            if (m_BangKe_Id == 0)
            {
                MessageBox.Show("Bạn vui lòng chọn bảng kê để xóa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblThongBao.Text = "Bạn vui lòng chọn bảng kê để xóa!";
                //timerThongBao.Enabled = true;
                return;
            }

            if (obj.DaGuiBHYT.Value)
            {
                MessageBox.Show("Bảng kê này đã gửi BHXH.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblThongBao.Text = "Bảng kê này đã gửi BHXH!.";
                //timerThongBao.Enabled = true;
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa bảng kê này?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int kq = obj.Delete(m_BangKe_Id);
                if (kq > 0)
                {
                    //MessageBox.Show("Xóa bảng kê thành công?", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblThongBao.Text = "Xóa bảng kê thành công.";
                    timerThongBao.Enabled = true;

                    SetControlStatusReadOnly(true);
                    ResetControl();
                }
            }
        }

        private void txtHoTen_Validated(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtHoTen.Text = textInfo.ToTitleCase(txtHoTen.Text.ToLower());
        }

        private void txtDiaChi_Validated(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtDiaChi.Text = textInfo.ToTitleCase(txtDiaChi.Text.ToLower());
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (m_BangKe_Id == 0)
            {
                MessageBox.Show("Bạn vui lòng chọn bảng kê để xem.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblThongBao.Text = "Bạn vui lòng chọn bảng kê để xem!";
                //timerThongBao.Enabled = true;
                return;
            }

            frmReport frm = new frmReport("BCVP");
            frm.m_BangKe_Id = m_BangKe_Id;
            frm.m_LoaiBangKe = m_LoaiBangKe;
            frm.Show();
        }

        private void txtKhoa_Validated(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtKhoa.Text = textInfo.ToTitleCase(txtKhoa.Text.ToLower());
        }



        private void TinhSoNgayVaoVien()
        {
            try
            {
                TimeSpan ts = txtNgayRa.GetDate.Value - txtNgayVao.GetDate.Value;

                txtSoNgay.Text = (ts.TotalDays + 1).ToString();
            }
            catch { }
        }

        private void txtNgayVao_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtNgayVao.GetDate != null && (txtNgayVao.GetDate.Value < txtTuNgay.GetDate.Value || txtNgayVao.GetDate.Value > txtDenNgay.GetDate.Value))
                {
                    //MessageBox.Show("Ngày vào không được nằm ngoài thời hạn sử dụng thẻ BHYT", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblThongBao.Text = "Ngày vào không được nằm ngoài thời hạn sử dụng thẻ BHYT.";
                    timerThongBao.Enabled = true;
                    txtNgayVao.Focus();
                    //SendKeys.Send("{DEL}");
                    return;
                }
                TinhSoNgayVaoVien();
            }
            catch
            {
            }
        }

        private void cboTuyenKham_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTuyenKham.SelectedValue.ToString() == "1")
                {
                    txtNoiChuyenDen.Enabled = true;
                    txtNoiChuyenDen.Focus();
                }
                else
                {

                    txtNoiChuyenDen.Enabled = false;
                    txtKhoa.Focus();
                }

                TinhTongGridView();

            }
            catch
            {
            }
        }

        private void chkChungTuKhongCCT_Enter(object sender, EventArgs e)
        {
            chkChungTuKhongCCT.BackColor = SystemColors.Info;
        }

        private void chkChungTuKhongCCT_Leave(object sender, EventArgs e)
        {
            chkChungTuKhongCCT.BackColor = SystemColors.Control;
        }

        private void cboMaNoiSinhSong_Enter(object sender, EventArgs e)
        {
            if (cboMaNoiSinhSong.DroppedDown == false)
            {
                cboMaNoiSinhSong.DroppedDown = true;
            }

        }

        private void cboGioiTinh_Enter(object sender, EventArgs e)
        {
            if (cboGioiTinh.DroppedDown == false)
            {
                cboGioiTinh.DroppedDown = true;
            }
        }




        private void txtMaKhamChuBenh_Validated(object sender, EventArgs e)
        {

            if (TrangThai == "ThemMoi")
            {
                clsBangKe obj = new clsBangKe();
                if (obj.CheckTonTaiMaKhamChuaBenh(txtMaKhamChuBenh.Text))
                {
                    MessageBox.Show("Mã khám chữa bệnh này đã tồn tại.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //lblThongBao.Text = "Mã khám chữa bệnh này đã tồn tại!";
                    //timerThongBao.Enabled = true;

                    txtMaKhamChuBenh.Text = "";
                    txtMaKhamChuBenh.Focus();

                }
                else if (txtSoDK.Text.Trim().Length > 0 && txtSoTheBHYT.Text.Trim().Length > 0 && txtHoTen.Text.Trim().Length > 0)
                {
                    //CheckDungTuyen();
                }
            }
            else
            {
                LoadData(1);
            }
        }

        private void btnCheckThe_Click(object sender, EventArgs e)
        { //{
        //    frmTraCuuTheBHYT frm = new frmTraCuuTheBHYT();
        //    frm.SoTheBHYT = txtSoTheBHYT.Text;
        //    frm.IsOnPush = true;
        //    //frm.passControl = new frmTraCuuTheBHYT.PassControl(PassData);
        //    frm.ShowDialog();
        //    if (frm.thongTinThe != null)
        //    {
        //        PassData(frm.thongTinThe);
        //    }
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
            //txtNgaySinh_Validated(null, null);
            //txtSoTheBHYT_Validated(null, null);
            //txtMaCSKCBBD_Validating(null, null);

            //txtMaCSKCBBD.Text = macskcb;

            //txtTenCSKCBBD.Text = obj.TenCSKCB;
            //txtMaBenhNhan.Focus();

        }

        private void cboMaNoiSinhSong_Click(object sender, EventArgs e)
        {
            if (cboMaNoiSinhSong.DroppedDown == false)
            {
                cboMaNoiSinhSong.DroppedDown = true;
            }
        }

        private void cboGioiTinh_Click(object sender, EventArgs e)
        {
            //if (cboGioiTinh.DroppedDown == false)
            {
                cboGioiTinh.DroppedDown = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            //if (m_BangKe_Id == 0)
            //{
            //    MessageBox.Show("Bạn vui lòng chọn bảng kê để in.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //lblThongBao.Text = "Bạn vui lòng chọn bảng kê để in!";
            //    //timerThongBao.Enabled = true;
            //    return;
            //}

            //if (m_BangKe_Id > 0)
            //{
            //    try
            //    {
            //        clsBaoCao bc = new clsBaoCao();
            //        clsDM_CSKCB objCSKCB = new clsDM_CSKCB();
            //        SystemConfig sys = SystemConfig.Instance;

            //        objCSKCB.GetByKey(sys.MaCSKCB);

            //        DataTable dt = new DataTable("BaoCao");
            //        dt = bc.GetBangKeNhom1(m_BangKe_Id);

            //        dt.Columns.Add("BarCode", typeof(byte[]));

            //        BarcodeLib.Barcode b = new BarcodeLib.Barcode();

            //        if (dt.Rows.Count > 0)
            //        {
            //            if (!string.IsNullOrEmpty(dt.Rows[0]["MaNguoiBenh"].ToString()))
            //            {
            //                Image bar = b.Encode(BarcodeLib.TYPE.CODE128, dt.Rows[0]["MaNguoiBenh"].ToString(), Color.Black, Color.White, 300, 150);
            //                byte[] imageData = converterByte(bar);
            //                dt.Rows[0]["BarCode"] = imageData;
            //            }
            //        }

            //        string path = string.Format("{0}/Reports/BCVP_{1}.rpt", Directory.GetCurrentDirectory(), m_LoaiBangKe);
            //        ReportDocument rpDocument = new ReportDocument();
            //        rpDocument.Load(path);
            //        rpDocument.SetDataSource(dt);


            //        ParameterDiscreteValue val = new ParameterDiscreteValue();
            //        val.Value = objCSKCB.TenCSKCB;

            //        ParameterDiscreteValue TenSYT = new ParameterDiscreteValue();
            //        TenSYT.Value = conf.TenSYT;

            //        ParameterValues paramVals = new ParameterValues();
            //        ParameterValues paramSYT = new ParameterValues();

            //        paramVals.Add(val);

            //        paramSYT.Add(TenSYT);

            //        rpDocument.ParameterFields["TenBenhVien"].CurrentValues = paramVals;

            //        rpDocument.ParameterFields["TenSYT"].CurrentValues = paramSYT;

            //        rpDocument.DataDefinition.ParameterFields["TenBenhVien"].ApplyCurrentValues(paramVals);
            //        rpDocument.DataDefinition.ParameterFields["TenSYT"].ApplyCurrentValues(paramSYT);

            //        int nCopy = (int)nupPage.Value;
            //        string PrinterName = cboMayIn.Text;
            //        rpDocument.PrintOptions.PrinterName = PrinterName;
            //        rpDocument.PrintToPrinter(nCopy, false, 0, 0);
            //    }
            //    catch
            //    {
            //        lblThongBao.Text = "Vui lòng kiểm tra lại máy in.";
            //        timerThongBao.Enabled = true;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn bảng kê để In.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //lblThongBao.Text="Vui lòng chọn bảng kê để In.";
            //    //timerThongBao.Enabled = true;
            //}

        }

        private void cboMaNoiSinhSong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                TinhTongGridView();
            }
            catch { }
        }

        private void frmHoSo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TrangThai != "")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu thay đổi.", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
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
                    return;
                }

            }

        }
        //Gui BHXH
        private void btnGuiBHXH_Click(object sender, EventArgs e)
        {
            //WSUpdateBangKe
            //WSPutBangKe

            if (m_BangKe_Id == 0)
            {
                MessageBox.Show("Bạn vui lòng chọn bảng kê để gửi BHXH.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblThongBao.ForeColor = Color.Red;
                //lblThongBao.Text = "Bạn vui lòng chọn bảng kê để gửi BHXH!";
                //timerThongBao.Enabled = true;
                return;
            }

            if (MessageBox.Show("Bạn có muốn gửi BHXH?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                clsBangKe bangKe = new clsBangKe();
                bangKe.GetByKey(m_BangKe_Id);

                string TrangThai = "";

                if (bangKe.DaGuiBHYT.Value == false)
                {
                    TrangThai = "WSPutBangKe";
                }
                else
                {
                    TrangThai = "WSUpdateBangKe";
                }
                Send(bangKe, TrangThai);
            }
        }


        public void Send(clsBangKe BangKe, string TrangThai)
        {
            ////URL
            //string publicURL = conf.GetLinkWS();
            //string URL = publicURL + string.Format("{0}/{1}", TrangThai, conf.MaCSKCB);
            //string param = string.Format("GetAccessToken/{0}/{1}", conf.Username, conf.Password);
            //string tokenURL = publicURL + param;
            //string token = Token.GetToken(tokenURL);

            //if (token == "")
            //{
            //    MessageBox.Show("Không thể kết nối tới máy chủ!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //lblThongBao.Text = "Không thể kết nối tới máy chủ!";
            //    //timerThongBao.Enabled = true;
            //    return;
            //}
            //SystemConfig system = SystemConfig.Instance;
            //string token = system.GetToken();
            //string URL = string.Format("{0}/{1}", TrangThai, conf.MaCSKCB);
            //if (string.IsNullOrEmpty(token))
            //{
            //    MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //clsBangKeChiTiet objBangKeChiTiet = new clsBangKeChiTiet();
            //clsBangKeChanDoan objBangKeChanDoan = new clsBangKeChanDoan();
            //List<clsBangKeChiTiet> danhSachChiTietBK = new List<clsBangKeChiTiet>();
            //List<clsBangKeChanDoan> danhSachChanDoan = new List<clsBangKeChanDoan>();

            //if (!string.IsNullOrEmpty(token))
            //{
            //    ////Lay thông tin bang ke
            //    BangKe.GetByKey(m_BangKe_Id);
            //    //Lay chi tiet bảng ke
            //    danhSachChiTietBK = LayBangKeChiTiet(objBangKeChiTiet.GetByID(m_BangKe_Id));
            //    //Lay chi tiet chan doan
            //    danhSachChanDoan = LayBangKeChuanDoan(objBangKeChanDoan.GetAll(m_BangKe_Id));

            //    BangKe01 objBangKe = new BangKe01();
            //    objBangKe.BenhKhac = BangKe.BenhKhac;
            //    objBangKe.BHYTThanhToan = BangKe.BHYTThanhToan;
            //    objBangKe.CapCuu = BangKe.TuyenKhamBenh == 2 ? true : false;
            //    objBangKe.ChanDoan = BangKe.ChanDoan;
            //    objBangKe.ChinhSuaChiPhi = null;
            //    objBangKe.ChiPhiNgoaiDinhSuat = BangKe.ChiPhiNgoaiDinhSuat;
            //    objBangKe.ChungNhanKhongCTT = BangKe.ChungNhanKhongCCT;
            //    objBangKe.CoBHYT = BangKe.CoBHYT;
            //    objBangKe.DanhDauThongKe = false;
            //    objBangKe.DiaChi = BangKe.DiaChi;
            //    objBangKe.DiaChiVNFont = null;
            //    objBangKe.DieuTriNgoaiTru = null;
            //    objBangKe.DuaVaoQuyetToan = null;
            //    objBangKe.DungTuyen = BangKe.TuyenKhamBenh == 1 ? true : false;
            //    objBangKe.DVKTC_ThanhToan = BangKe.DVKTC_ThanhToan;
            //    objBangKe.DVKTC_TinhToan = BangKe.DVKTC_TinhToan;
            //    objBangKe.GhiChu = null;
            //    objBangKe.GhiChuChuyenSau = null;
            //    objBangKe.GiamDinhChuyenSau = null;
            //    objBangKe.GioiTinh = byte.Parse(BangKe.GioiTinh.ToString());
            //    objBangKe.HinhThucKham = BangKe.LoaiBangKe == 2 ? (byte)2 : (byte)1;//Bang ke 02 Noi tru, Bang ke 01 va Bang ke 03 ngoai tru 
            //    objBangKe.HoTen = BangKe.HoTen;
            //    objBangKe.HoTenVNFont = null;
            //    objBangKe.HSLienQuanChinhSuaCP = null;
            //    objBangKe.ICD10CV = BangKe.MaICD;
            //    objBangKe.BenhKhac = BangKe.BenhKhac;
            //    objBangKe.ImportBatch = null;
            //    objBangKe.KetQuaGiamDinh = null;
            //    objBangKe.Khoa = BangKe.Khoa;
            //    objBangKe.KhoaVNFont = null;
            //    objBangKe.LyDoTraHoSo = null;
            //    objBangKe.LyDoTuChoi = null;
            //    objBangKe.MaChiNhanh = BangKe.MaChiNhanh;
            //    objBangKe.MaCSKCB = BangKe.MaCSKCB;
            //    objBangKe.MaCSKCBBanDau = BangKe.MaCSKCBBanDau;
            //    objBangKe.MaDuongDan = null;
            //    objBangKe.MaLoi = null;
            //    objBangKe.MaNguoiBenh = BangKe.MaNguoiBenh;
            //    objBangKe.MaNoiChuyenDen = BangKe.MaNoiChuyenDen;
            //    objBangKe.TenNoiChuyenDen = BangKe.MaNoiChuyenDen;//;BangKe.TenNoiChuyenDen;

            //    objBangKe.MaNoiSinhSong = BangKe.MaNoiSinhSong;
            //    objBangKe.MoTaLoi = null;
            //    objBangKe.NamQuyetToan = null;
            //    objBangKe.NamSinh = BangKe.NamSinh;
            //    objBangKe.NgayCapNhat = BangKe.NgayCapNhat == DateTime.MinValue ? null : BangKe.NgayCapNhat;
            //    //     DateTime.TryParse("26/3/2015 12:00:00 AM", out dateTime);
            //    objBangKe.NgayDenKham = BangKe.NgayDenKham == DateTime.MinValue ? null : BangKe.NgayDenKham;

            //    objBangKe.NgayGiamDinh = null;
            //    objBangKe.NgayGui = null;
            //    //            DateTime.TryParse("26/3/2015 12:00:00 AM", out dateTime);
            //    objBangKe.NgayKetThuc = BangKe.NgayKetThuc == DateTime.MinValue ? null : BangKe.NgayKetThuc;
            //    objBangKe.NgayPheDuyet = null;
            //    objBangKe.NgayQuyetToan = BangKe.NgayQuyetToan == DateTime.MinValue ? null : BangKe.NgayQuyetToan;
            //    objBangKe.NgaySinh = BangKe.NgaySinh;
            //    objBangKe.NgayTao = BangKe.NgayTao == DateTime.MinValue ? null : BangKe.NgayTao;
            //    //DateTime.TryParse("26/3/2015 12:00:00 AM", out dateTime);
            //    objBangKe.NgayThanhToan = BangKe.NgayQuyetToan;//.NgayKetThuc;//quan trong
            //    objBangKe.NguoiBenhCungTra = null;
            //    objBangKe.NguoiBenhTra = BangKe.NguoiBenhTra;
            //    objBangKe.NguoiCapNhat = BangKe.NguoiCapNhat;
            //    objBangKe.NguoiGiamDinh = null;
            //    objBangKe.NguoiGiamDinhChuyenSau = null;
            //    objBangKe.NguoiGui = BangKe.NguoiGuiBHYT;
            //    objBangKe.NguoiNhoGiamDinhChuyenSau = null;
            //    objBangKe.NguoiPheDuyet = null;
            //    objBangKe.NguoiTao = BangKe.NguoiTao;
            //    objBangKe.NguonDuLieu = null;
            //    objBangKe.NguonKhac = BangKe.NguonKhac;
            //    objBangKe.NhomDoiTuong = null;
            //    objBangKe.NoiThanhToan = null;
            //    objBangKe.PhanTramDuocHuong = BangKe.PhanTramDuocHuong;
            //    objBangKe.QuyQuyetToan = null;
            //    objBangKe.SoHoSo = BangKe.SoHoSo;
            //    objBangKe.SoKhamBenh = BangKe.MaKhamChuaBenh;// "15032600001";
            //    objBangKe.SoNgayDieuTri = BangKe.SoNgayDieuTri;
            //    objBangKe.SoTheBHYT = BangKe.SoTheBHYT;// "GD7790800816264";
            //    objBangKe.SoTienThanhToanToiDa = BangKe.SoTienThanhToanToiDa;
            //    objBangKe.SoTienTuChoiThanhToan = null;
            //    objBangKe.STTCV = null;
            //    // DateTime.TryParse("31/12/2015 12:00:00 AM", out dateTime);
            //    objBangKe.SuDungDen = BangKe.DenNgayBH;//dateTime;
            //    //DateTime.TryParse("31/12/2015 12:00:00 AM", out dateTime);
            //    objBangKe.SuDungTu = BangKe.TuNgayBH;//dateTime;
            //    objBangKe.TenCSKCBBanDau = BangKe.TenCSKCBBanDau;
                
            //    objBangKe.ThangQuyetToan = null;
            //    objBangKe.TienCDHA = null;
            //    objBangKe.TienCDHA_XT = null;
            //    objBangKe.TienCDHA_XT2021 = null;
            //    objBangKe.TienDaTuyen = null;
            //    objBangKe.TienDVKTC = BangKe.TienDichVuKTC;//null;
            //    objBangKe.TienDVKTC_XT = null;
            //    objBangKe.TienDVKTC_XT2021 = null;
            //    objBangKe.TienKham = BangKe.TienKham;
            //    objBangKe.TienKham_XT = null;
            //    objBangKe.TienKham_XT2021 = null;
            //    objBangKe.TienKTG = null;
            //    objBangKe.TienKTG_XT = null;
            //    objBangKe.TienKTG_XT2021 = null;
            //    objBangKe.TienMau = BangKe.TienMau;
            //    objBangKe.TienMau_XT = null;
            //    objBangKe.TienMau_XT2021 = null;
            //    objBangKe.TienPTTT = BangKe.TienPTTT;
            //    objBangKe.TienPTTT_XT = null;
            //    objBangKe.TienPTTT_XT2021 = null;
            //    objBangKe.TienThongBao = null;
            //    objBangKe.TienVC = BangKe.TienVanChuyen;
            //    objBangKe.TienVC_XT = null;
            //    objBangKe.TienVC_XT2021 = null;
            //    objBangKe.TienVTYTTH = BangKe.TienVTYTTH;
            //    objBangKe.TienVTYTTH_XT = null;
            //    objBangKe.TienVTYTTH_XT2021 = null;
            //    objBangKe.TienVTYTTT = BangKe.TienVTYTTT;
            //    objBangKe.TienVTYTTT_XT = null;
            //    objBangKe.TienVTYTTT_XT2021 = null;
            //    objBangKe.TienVuotTran = null;
            //    objBangKe.TienXN = BangKe.TienXN;
            //    objBangKe.TienXN_XT = null;
            //    objBangKe.TienXN_XT2021 = null;
            //    objBangKe.TinhTrang = null;
            //    objBangKe.TinhTrangGiamDinh = null;
            //    objBangKe.TongChiPhi = BangKe.TongChiPhi;
            //    objBangKe.TongChiPhiThuoc = BangKe.TienThuoc;
            //    objBangKe.TongChiPhiThuoc_XT = null;
            //    objBangKe.TongChiPhiThuoc_XT2021 = null;
            //    objBangKe.TreEmKhongTheBHYT = BangKe.TreEmKhongTheBHYT;
            //    objBangKe.XuatToanTheo2021 = null;


            //    objBangKe.BangKe01ChiTiet = new List<BangKe01ChiTiet>();
            //    foreach (clsBangKeChiTiet bangkeCT in danhSachChiTietBK)
            //    {
            //        BangKe01ChiTiet obj = new BangKe01ChiTiet();

            //        switch (bangkeCT.MaLoaiChiPhi)
            //        {
            //            case "D":
            //                obj.MaDanhMuc = 3;
            //                break;
            //            case "T":
            //                obj.MaDanhMuc = 1;
            //                break;
            //            case "V":
            //                obj.MaDanhMuc = 2;
            //                break;
            //            case "M":
            //                obj.MaDanhMuc = 4;
            //                break;

            //        }

            //        obj.BHYTThanhToan = bangkeCT.BHYTThanhToan;
            //        obj.ChiPhiNgoaiDinhSuat = bangkeCT.ChiPhiNgoaiDinhSuat;

            //        obj.LaDVKTC = bangkeCT.DichVuKTC;
            //        obj.LaVTDVKTC = bangkeCT.VTYTDichVuKTC;

            //        obj.DonGiaBHYT = bangkeCT.DonGiaBHYT;

            //        obj.MaChiPhi = bangkeCT.MaChiPhi;
            //        obj.MaChiPhi_HIS = bangkeCT.MaChiPhi;

            //        obj.DonViTinh = bangkeCT.DonViTinh;
            //        obj.DonViTinh_HIS = bangkeCT.DonViTinh;

            //        obj.TenChiPhi = bangkeCT.TenChiPhi;
            //        obj.TenChiPhi_HIS = bangkeCT.TenChiPhi;

            //        obj.MaLoaiChiPhi = bangkeCT.MaNhom1;
            //        obj.MaLoaiChiPhi2 = bangkeCT.MaNhom2;

            //        obj.NguoiBenhTra = bangkeCT.NguoiBenhTra;
            //        obj.NguonKhac = bangkeCT.NguonKhac;
            //        obj.PhanTramDuocHuong = bangkeCT.PhanTramDuocHuong;
            //        obj.SoLuong = bangkeCT.SoLuong;

            //        obj.ThanhTien = bangkeCT.ThanhTienBHYT;

            //        obj.TiLeThanhToan = bangkeCT.TyLeThanhToan;

            //        objBangKe.BangKe01ChiTiet.Add(obj);
            //    }
            //    objBangKe.BangKe01ChanDoan = new List<BangKe01ChanDoan>();
            //    //foreach (clsBangKeChanDoan bkcd in danhSachChanDoan)
            //    //{
            //    BangKe01ChanDoan objChanDoan = new BangKe01ChanDoan();
            //    objChanDoan.MaICD10 = BangKe.MaICD;
            //    objChanDoan.STT = 1;
            //    objBangKe.BangKe01ChanDoan.Add(objChanDoan);
            //    //}


            //    string requestData = XMLUtils.SerializeDataContract(objBangKe);


            //    string response = system.SendRequest(URL, "POST", requestData); //HttpRequest.WSRequest(URL, "POST", requestData, token);
            //    if (string.IsNullOrEmpty(response))
            //    {
            //        MessageBox.Show("Vui lòng kiểm tra lại dữ liệu gửi.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        //lblThongBao.Text = "Vui lòng kiểm tra lại dữ liệu gửi!.";
            //        //timerThongBao.Enabled = true;
            //        return;
            //    }
            //    if (!string.IsNullOrEmpty(response) && response.IndexOf("Error:") == -1)
            //    {
            //        string value = XMLUtils.DeSerializeToObject<string>(response);
            //        if (int.Parse(value) != 0)
            //        {
            //            BangKe.DaGuiBHYT = true;
            //            BangKe.BangKe_Id_BHXH = int.Parse(value);
            //            int kq = BangKe.Update();

            //            if (TrangThai == "WSPutBangKe")
            //            // MessageBox.Show("Đã gửi BHXH!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            {
            //                lblThongBao.Text = "Đã gửi BHXH.";
            //                timerThongBao.Enabled = true;
            //            }
            //            else
            //            //MessageBox.Show("Đã cập nhật bảng kê ở BHXH!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            {
            //                lblThongBao.Text = "Đã cập nhật bảng kê ở BHXH.";
            //                timerThongBao.Enabled = true;
            //            }
            //            LoadData(0);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Không gửi được bảng kê.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            //lblThongBao.ForeColor = Color.Red;
            //            //lblThongBao.Text = "Không gửi được bảng kê!";
            //            //timerThongBao.Enabled = true;
            //        }
            //    }
            //    else
            //    {


            //        string str = system.GetToken();

            //        if (string.IsNullOrEmpty(str))
            //        {
            //            MessageBox.Show("Lỗi không thể kết nối tới BHXH.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            //lblThongBao.ForeColor = Color.Red;
            //            //lblThongBao.Text = "Lỗi không thể kết nối tới BHXH!.";
            //            //timerThongBao.Enabled = true;
            //            return;
            //        }
            //        else
            //        {

            //        }
            //        //quay lai truoc 
            //    }
            //}

        }



        private List<clsBangKeChiTiet> LayBangKeChiTiet(DataTable tbBangKeChiTiet)
        {
            List<clsBangKeChiTiet> lsBangKeChiTiet = new List<clsBangKeChiTiet>();
            DataTable tb = tbBangKeChiTiet;
            if (tb == null)
                return null;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                clsBangKeChiTiet objBangKeChiTiet = new clsBangKeChiTiet();

                objBangKeChiTiet.BangKeChiTiet_Id = int.Parse(tb.Rows[i]["BangKeChiTiet_Id"].ToString());
                objBangKeChiTiet.BangKe_Id = int.Parse(tb.Rows[i]["BangKe_Id"].ToString());
                objBangKeChiTiet.MaChiPhi = tb.Rows[i]["MaChiPhi"].ToString();
                objBangKeChiTiet.MaPhu = tb.Rows[i]["MaPhu"].ToString();
                objBangKeChiTiet.TenChiPhi = (tb.Rows[i]["TenChiPhi"].ToString());
                objBangKeChiTiet.DonViTinh = (tb.Rows[i]["DonViTinh"].ToString());

                try
                {
                    objBangKeChiTiet.SoLuong = decimal.Parse(tb.Rows[i]["SoLuong"].ToString());
                    objBangKeChiTiet.PhanTramDuocHuong = decimal.Parse(tb.Rows[i]["PhanTramDuocHuong"].ToString());
                    objBangKeChiTiet.DonGiaBHYT = decimal.Parse(tb.Rows[i]["DonGiaBHYT"].ToString());
                    objBangKeChiTiet.ThanhTienBHYT = decimal.Parse(tb.Rows[i]["ThanhTienBHYT"].ToString());
                    objBangKeChiTiet.BHYTThanhToan = decimal.Parse(tb.Rows[i]["BHYTThanhToan"].ToString());
                    objBangKeChiTiet.NguonKhac = decimal.Parse(tb.Rows[i]["NguonKhac"].ToString());

                    objBangKeChiTiet.NguoiBenhTra = decimal.Parse(tb.Rows[i]["NguoiBenhTra"].ToString());
                    objBangKeChiTiet.ChiPhiNgoaiDinhSuat = decimal.Parse(tb.Rows[i]["ChiPhiNgoaiDinhSuat"].ToString());
                }
                catch (Exception ex) { }
                objBangKeChiTiet.MaNhom1 = tb.Rows[i]["MaNhom1"].ToString();

                objBangKeChiTiet.MaNhom2 = tb.Rows[i]["MaNhom2"].ToString();
                objBangKeChiTiet.MaLoaiChiPhi = tb.Rows[i]["MaLoaiChiPhi"].ToString();

                objBangKeChiTiet.VTYTDichVuKTC = bool.Parse(tb.Rows[i]["VTYTDichVuKTC"].ToString());
                objBangKeChiTiet.DichVuKTC = bool.Parse(tb.Rows[i]["DichVuKTC"].ToString());
                objBangKeChiTiet.GhiChu = tb.Rows[i]["GhiChu"].ToString();
                lsBangKeChiTiet.Add(objBangKeChiTiet);

            }


            return lsBangKeChiTiet;

        }
        private List<clsBangKeChanDoan> LayBangKeChuanDoan(DataTable tbBangKeChuanDoan)
        {
            List<clsBangKeChanDoan> lsBangKeChiTiet = new List<clsBangKeChanDoan>();
            DataTable tb = tbBangKeChuanDoan;
            if (tb == null)
                return null;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                clsBangKeChanDoan objBangKeChiTiet = new clsBangKeChanDoan();
                objBangKeChiTiet.ChuanDoan_Id = int.Parse(tb.Rows[i]["ChanDoan_Id"].ToString());
                objBangKeChiTiet.BangKe_Id = int.Parse(tb.Rows[i]["BangKe_Id"].ToString());
                objBangKeChiTiet.MaICD = tb.Rows[i]["MaICD"].ToString();
                try
                {
                    objBangKeChiTiet.STT = int.Parse(tb.Rows[i]["STT"].ToString());
                }
                catch (Exception ex) { }
                lsBangKeChiTiet.Add(objBangKeChiTiet);

            }


            return lsBangKeChiTiet;

        }

        private void txtKhoa_Validating(object sender, CancelEventArgs e)
        {
            try
            {

                if (txtKhoa.SelectedValues["TenPhongBan"].ToString().Trim() != "" && TrangThai != "")
                    txtKhoa.Text = txtKhoa.SelectedValues["TenPhongBan"].ToString();
            }
            catch
            {
            }
        }

        private void txtKhoa_Enter(object sender, EventArgs e)
        {
            txtKhoa.SelectAll();
            txtKhoa.UpdateData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            btnHuyBo_Click(null, null);
        }

        private void txtSoDK_Validated(object sender, EventArgs e)
        {
            //Load theo So ĐK BHXH
            if (txtSoDK.Text.Trim().Length == 0)
            {
                return;
            }

            if (TrangThai == "ThemMoi")
            {

                clsBangKe obj = new clsBangKe();
                if (obj.CheckTonTaiSoDK(txtSoDK.Text))
                {
                    ResetControl();
                    MessageBox.Show("Số đăng ký này đã được sử dụng.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                    //lblThongBao.ForeColor = Color.Red;
                    //lblThongBao.Text="Số đăng ký này đã được sử dụng";
                    //timerThongBao.Enabled=true;
                }
                if (!Load_ThongTinDKKCB())
                {
                    LoadData(3);
                }
                TinhTongGridView();
            }
            else
            {
                LoadData(3);
            }

        }

        private void btnClearSoDK_Click(object sender, EventArgs e)
        {
            ResetControl();
            btnThem_Click(null, null);

        }

        private void txtMaICD_Validated(object sender, EventArgs e)
        {
            try
            {
                //txtMaICD.UpdateData();
                clsDM_ICD obj = new clsDM_ICD();
                obj.GetByKey(txtMaICD.Text);
                if (obj.MaICD == null)
                {
                    txtMaICD.Text = "";//txtMaICD.SelectedValues["TenICD"].ToString();
                    txtChanDoan.Text = "";
                }
                else
                {
                    txtChanDoan.Text = obj.TenICD;
                }
                txtChanDoan.Select(txtChanDoan.Text.Length, 0);
            }
            catch { }
        }

        private void timerThongBao_Tick(object sender, EventArgs e)
        {
            lblThongBao.ForeColor = Color.Blue;
            lblThongBao.Text = "";
            timerThongBao.Enabled = false;
        }

        private bool Load_ThongTinDKKCB()
        {
            SystemConfig system = SystemConfig.Instance;
            string token = system.GetToken();
            if (string.IsNullOrEmpty(token))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (!string.IsNullOrEmpty(token))
            {
                //string URL = "WSGetHosoDangKyKCBBHYT/" + txtSoDK.Text;

                //string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL, "GET", string.Empty, token);
                //if (response.IndexOf("Error") != -1)
                //{
                //    lblThongBao.Text = "Mất kết nối đến server, vui lòng thử lại sau.";
                //    timerThongBao.Enabled = true;
                //    return false;
                //}
                //if (string.IsNullOrEmpty(response))
                //{
                //    lblThongBao.Text = "Không tìm thấy thông tin với mã đăng ký này!";
                //    timerThongBao.Enabled = true;
                //    return false;
                //}
                //DangKyKhamBenh lstDMCHIPHI = XMLUtils.DeSerializeToObject<DangKyKhamBenh>(response);//(response);
                //if (lstDMCHIPHI == null)
                //{
                //    lblThongBao.Text = "Mã đăng ký chưa tồn tại !";
                //    timerThongBao.Enabled = true;
                //    return false;
                //}
                //IsRunCheck = true;
                //txtSoTheBHYT.Text = lstDMCHIPHI.SoTheBHYT.ToString();
                //txtHoTen.Text = lstDMCHIPHI.HoTen;
                //txtDiaChi.Text = lstDMCHIPHI.DiaChi;
                //txtTuNgay.Text = string.Format("{0:dd/MM/yyyy}", lstDMCHIPHI.SuDungTu);
                //txtDenNgay.Text = string.Format("{0:dd/MM/yyyy}", lstDMCHIPHI.SuDungDen);
                //txtNgaySinh.Text = string.Format("{0:dd/MM/yyyy}", lstDMCHIPHI.NgaySinh);

                //txtNgayVao.Text = string.Format("{0:dd/MM/yyyy}", lstDMCHIPHI.NgayDenKham);

                //txtNamSinh.Text = lstDMCHIPHI.NgaySinh.Value.Year.ToString();

                //clsDM_CSKCB objCSKCB = new clsDM_CSKCB();
                //objCSKCB.GetByKey(lstDMCHIPHI.MaCSKCBBanDau);
                //txtMaCSKCBBD.Text = lstDMCHIPHI.MaCSKCBBanDau;
                //txtTenCSKCBBD.Text = objCSKCB.TenCSKCB;

                //cboTuyenKham.SelectedValue = lstDMCHIPHI.LyDoVV.ToString();
                //cboGioiTinh.SelectedValue = lstDMCHIPHI.GioiTinh.ToString();
                //cboMaNoiSinhSong.SelectedValue = lstDMCHIPHI.MaNoiSinhSong.ToString();

                //txtNoiChuyenDen.Text = lstDMCHIPHI.MaNoiChuyenDen.ToString();

                //LoadMaCSKCBTheoMaTinh();
                ////CheckDungTuyen();
                //txtMaBenhNhan.Focus();

                //IsRunCheck = false;

                return true;
            }
            else
            {
                lblThongBao.Text = "Lỗi! Kiểm tra cấu hình và thử lại!";
                timerThongBao.Enabled = true;
                return false;
            }
        }

        private void txtThuoc_Enter(object sender, EventArgs e)
        {
            // txtThuoc.BackColor = SystemColors.GradientActiveCaption;
        }

        private void txtThuoc_Leave(object sender, EventArgs e)
        {
            // txtThuoc.BackColor = SystemColors.Window;
        }

        private void txtNguonKhacThuoc_Enter(object sender, EventArgs e)
        {
            txtNguonKhacThuoc.Select(0, txtNguonKhacThuoc.Text.Length);
        }

        private void txtNguonKhacThuoc_Validated(object sender, EventArgs e)
        {
            btnAddThuoc_Click(null, null);
        }

        private void txtBenhKhac_Validated(object sender, EventArgs e)
        {
            if (txtBenhKhac.TextLength > 0)
            {
                if (txtBenhKhac.Text.LastIndexOf(';') == txtBenhKhac.TextLength - 1)
                {
                    txtBenhKhac.Text = txtBenhKhac.Text.Substring(0, txtBenhKhac.Text.Length - 1);
                }
            }
        }

        private void grdChiPhiThuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(grdChiPhiThuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 7);
            }
        }

        private void frmHoSo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }

        private void btnClearChiPhi_Click(object sender, EventArgs e)
        {
            m_MaChiPhi = "";
            m_LoaiChiPhi = "";
            txtThuoc.Text = "";
            btnClearChiPhi.Visible = false;
        }

        public static byte[] converterByte(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
    }

}
