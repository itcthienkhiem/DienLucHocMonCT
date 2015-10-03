using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using coInventory.Mini.EntityClass;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

namespace coInventory.Mini.HoSo
{
    public partial class frmGiayChuyenTuyen : Form
    {
        private PrintDocument printDoc = new PrintDocument();
        SystemConfig conf = SystemConfig.Instance;

        clsDM_CSKCB m_CSKCB = new clsDM_CSKCB();

        private string TrangThai = "";

        private string m_SoLuuTru = "";

        private string Code = "GiayChuyenTuyen";
        public frmGiayChuyenTuyen()
        {
            InitializeComponent();
        }

        private void frmGiayChuyenTuyen_KeyDown(object sender, KeyEventArgs e)
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
                btnView.PerformClick();
            }
            else if (e.KeyCode == Keys.P && e.Control)
            {
                btnPrint.PerformClick();
            }
            else if (e.KeyCode == Keys.F3)
            {
                if (txtSoLuuTru.Focused)
                {
                    btnSearch.PerformClick();
                }
            }
        }

        private void frmGiayChuyenTuyen_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
            LoadMayIn();
            m_CSKCB.GetByKey(conf.MaCSKCB);
            lblCSKCB.Text = m_CSKCB.TenCSKCB;
            LoadDataCombobox();
            SetControlStatusReadOnly(true);
        }


        private void LoadDataCombobox()
        {

            //Load gioi tinh
            cboGioiTinh.DataSource = Utilities.Utils.GetGioiTinh();
            cboGioiTinh.DisplayMember = "Name";
            cboGioiTinh.ValueMember = "Value";

            //Load data cơ sở khám chữa bệnh

            clsDM_CSKCB cskcb = new clsDM_CSKCB();
            DataTable dtCSKCB = cskcb.GetAllActive();
            txtNoiChuyenDen.Values = dtCSKCB;
            List<CDisplayColumns> lstColCSKCB = new List<CDisplayColumns>();
            lstColCSKCB.Add(new CDisplayColumns("MaCSKCB", "Mã CSKCB", true, true));
            lstColCSKCB.Add(new CDisplayColumns("TenCSKCB", "Tên CSKCB", true, true));

            txtNoiChuyenDen.DisplayColumns = lstColCSKCB;
            txtNoiChuyenDen.DisplayMember = "TenCSKCB";
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

        private void ResetControl()
        {
            txtNoiChuyenDen.Text = string.Empty;
            txtSoLuuTru.Text = string.Empty;
            txtMaYTe.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            cboGioiTinh.SelectedIndex = 0;
            txtTuoi.Text = string.Empty;
            txtDanToc.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtQuocTich.Text = string.Empty;
            txtNgheNghiep.Text = string.Empty;
            txtNoiLamViec.Text = string.Empty;
            txtGiaTriTu.Text = string.Empty;
            txtGiaTriDen.Text = string.Empty;
            txtSoTheBHYT.Text = string.Empty;
            txtTuNgay.Text = string.Empty;
            txtDenNgay.Text = string.Empty;
            txtDauHieuLamSang.Text = string.Empty;
            txtKetQuaXetNghiem.Text = string.Empty;
            txtChanDoan.Text = string.Empty;
            txtPhuongPhap.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;
            rdoDuDieuKien.Checked = true;
            rdoKhongDuDieuKien.Checked = false;
            txtGio.Text = string.Empty;
            txtPhut.Text = string.Empty;
            txtNgayChuyenTuyen.Text = string.Empty;
            txtPhuongTienVanChuyen.Text = string.Empty;
            txtNguoiHoTong.Text = string.Empty;
            txtHuongDieuTri.Text = string.Empty;
            txtSoLuuTru.Focus();
            m_SoLuuTru = "";
        }
        private void SetControlStatusReadOnly(bool statusControl)
        {
            cboGioiTinh.Enabled = !statusControl;

            txtNoiChuyenDen.Enabled = !statusControl;
            //txtSoLuuTru.ReadOnly = statusControl;
            txtMaYTe.ReadOnly = statusControl;
            txtHoTen.ReadOnly = statusControl;
            txtTuoi.Enabled = !statusControl;
            txtDanToc.ReadOnly = statusControl;
            txtDiaChi.ReadOnly = statusControl;
            txtQuocTich.ReadOnly = statusControl;
            txtNgheNghiep.ReadOnly = statusControl;
            txtNoiLamViec.ReadOnly = statusControl;
            txtGiaTriTu.Enabled = !statusControl;
            txtGiaTriDen.Enabled = !statusControl;
            txtSoTheBHYT.Enabled = !statusControl;
            txtTuNgay.Enabled = !statusControl;
            txtDenNgay.Enabled = !statusControl;
            txtDauHieuLamSang.ReadOnly = statusControl;
            txtKetQuaXetNghiem.ReadOnly = statusControl;
            txtChanDoan.ReadOnly = statusControl;
            txtPhuongPhap.ReadOnly = statusControl;
            txtHuongDieuTri.ReadOnly = statusControl;
            txtTinhTrang.ReadOnly = statusControl;
            rdoDuDieuKien.Enabled = !statusControl;
            rdoKhongDuDieuKien.Enabled = !statusControl;
            txtGio.Enabled = !statusControl;
            txtPhut.Enabled = !statusControl;
            txtNgayChuyenTuyen.Enabled = !statusControl;
            txtPhuongTienVanChuyen.ReadOnly = statusControl;
            txtNguoiHoTong.ReadOnly = statusControl;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TrangThai = "ThemMoi";

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;

            btnLuu.Enabled = true;
            btnHuyBo.Enabled = true;



            SetControlStatusReadOnly(false);


            ResetControl();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            TrangThai = "";
            lblThongBao.Text = "";
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnDong.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            SetControlStatusReadOnly(true);
            ResetControl();
            txtSoLuuTru.Enabled = true;
        }

        private string ValidateControl()
        {

            string str = "";
            if (txtNoiChuyenDen.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập nơi chuyển đến ." + Environment.NewLine;
            }
            if (txtSoLuuTru.Text.Replace("-", "").Trim().Length == 0)
            {
                str += "- Vui lòng nhập số lưu trữ." + Environment.NewLine;
            }
            //if (txtMaYTe.Text.Replace("/", "").Trim().Length == 0)
            //{
            //    str += "- Vui lòng nhập mã y tế." + Environment.NewLine;
            //}
            if (txtHoTen.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập họ tên bệnh nhân." + Environment.NewLine;
            }
            if (cboGioiTinh.Text.Trim().Length == 0)
            {
                str += "- Vui lòng chọn giới tính" + Environment.NewLine;
            }
            if (txtTuoi.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập tuổi." + Environment.NewLine;
            }
            if (txtDanToc.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập dân tộc." + Environment.NewLine;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập địa chỉ." + Environment.NewLine;
            }

            if (txtTuNgay.Text.Replace("/", "").Trim().Length == 0)
            {
                str += "- Vui lòng nhập từ ngày." + Environment.NewLine;
            }
            if (txtDenNgay.Text.Replace("/", "").Trim().Length == 0)
            {
                str += "- Vui lòng nhập đến ngày." + Environment.NewLine;
            }


            return str;

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
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;

            SetControlStatusReadOnly(true);
        }

        private void SaveData()
        {
            try
            {
                if (TrangThai == "ThemMoi")
                {

                    InsertData();


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

        private void btnSua_Click(object sender, EventArgs e)
        {
            TrangThai = "CapNhat";
            if (m_SoLuuTru.Trim() == "")
            {
                TrangThai = "";
                MessageBox.Show("Bạn vui lòng chọn số lưu trữ.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblThongBao.Text = "Bạn vui lòng chọn bảng kê để chỉnh sửa!";
                //timerThongBao.Enabled = true;
                return;
            }
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;

            btnLuu.Enabled = true;
            btnHuyBo.Enabled = true;


            SetControlStatusReadOnly(false);
            txtSoLuuTru.Focus();
            txtSoLuuTru.Enabled = false;
        }

        private void InsertData()
        {
            clsBenhAn objBenhAn = new clsBenhAn();
            try
            {
                m_SoLuuTru = txtSoLuuTru.Text;
                objBenhAn.SoLuuTru = txtSoLuuTru.Text;
                objBenhAn.MaYTe = txtMaYTe.Text;
                objBenhAn.HoTen = txtHoTen.Text;
                objBenhAn.GioiTinh = int.Parse(cboGioiTinh.SelectedValue.ToString());
                objBenhAn.NoiChuyenDen = txtNoiChuyenDen.Text;
                objBenhAn.Tuoi = txtTuoi.IntValue;
                objBenhAn.DanToc = txtDanToc.Text;
                objBenhAn.DiaChi = txtDiaChi.Text;
                objBenhAn.QuocTich = txtQuocTich.Text;
                objBenhAn.NgheNghiep = txtNgheNghiep.Text;
                objBenhAn.NoiLamViec = txtNoiLamViec.Text;
                objBenhAn.GiaTriTu = txtGiaTriTu.GetDate;
                objBenhAn.GiaTriDen = txtGiaTriDen.GetDate;
                objBenhAn.SoTheBHYT = txtSoTheBHYT.Text;
                objBenhAn.TenCSKCB = lblCSKCB.Text;
                objBenhAn.MaCSKCB = conf.MaCSKCB;
                objBenhAn.NgayVao = txtTuNgay.GetDate;
                objBenhAn.NgayRa = txtDenNgay.GetDate;
                objBenhAn.DauHieu = txtDauHieuLamSang.Text;
                objBenhAn.KetQua = txtKetQuaXetNghiem.Text;
                objBenhAn.ChanDoan = txtChanDoan.Text;
                objBenhAn.PhuongPhap = txtPhuongPhap.Text;
                objBenhAn.TinhTrang = txtTinhTrang.Text;
                objBenhAn.LyDo = rdoDuDieuKien.Checked ? 1 : 0;

                DateTime? datetime = new DateTime?();
                if (txtNgayChuyenTuyen.GetDate != null)
                    datetime = txtNgayChuyenTuyen.GetDate.Value.AddHours(txtGio.IntValue).AddMinutes(txtPhut.IntValue);
                objBenhAn.ChuyenTuyenHoi = datetime;
                objBenhAn.HuongDieuTri = txtHuongDieuTri.Text;
                objBenhAn.PhuongTienVanChuyen = txtPhuongTienVanChuyen.Text;
                objBenhAn.NguoiHoTong = txtNguoiHoTong.Text;
                objBenhAn.Loai = "GiayChuyenTuyen";
                //objBenhAn.ChanDoanGPBL=;
                //objBenhAn.LoiDanThayThuoc=;
                objBenhAn.LyDoStr = rdoDuDieuKien.Checked ? rdoDuDieuKien.Text : rdoKhongDuDieuKien.Text;


                int kq = objBenhAn.Insert();
                if (kq > 0)
                {
                    //MessageBox.Show("Thêm mới bảng kê thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblThongBao.Text = "Thêm giấy chuyển tuyến thành công.";
                    timerThongBao.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm giấy chuyển tuyến không thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm giấy chuyển tuyến không thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //lblThongBao.Text = "Thêm mới bảng kê không thành công";
                //timerThongBao.Enabled = true;
            }
        }

        private void UpdateData()
        {
            if (m_SoLuuTru.Trim() == "")
                return;
            clsBenhAn objBenhAn = new clsBenhAn();
            try
            {
                m_SoLuuTru = txtSoLuuTru.Text;
                objBenhAn.GetBySoLuuTru(m_SoLuuTru, Code);
                objBenhAn.SoLuuTru = txtSoLuuTru.Text;
                objBenhAn.MaYTe = txtMaYTe.Text;
                objBenhAn.HoTen = txtHoTen.Text;
                objBenhAn.GioiTinh = int.Parse(cboGioiTinh.SelectedValue.ToString());
                objBenhAn.NoiChuyenDen = txtNoiChuyenDen.Text;
                objBenhAn.Tuoi = txtTuoi.IntValue;
                objBenhAn.DanToc = txtDanToc.Text;
                objBenhAn.DiaChi = txtDiaChi.Text;
                objBenhAn.QuocTich = txtQuocTich.Text;
                objBenhAn.NgheNghiep = txtNgheNghiep.Text;
                objBenhAn.NoiLamViec = txtNoiLamViec.Text;
                objBenhAn.GiaTriTu = txtGiaTriTu.GetDate;
                objBenhAn.GiaTriDen = txtGiaTriDen.GetDate;
                objBenhAn.SoTheBHYT = txtSoTheBHYT.Text;
                objBenhAn.TenCSKCB = lblCSKCB.Text;
                objBenhAn.MaCSKCB = conf.MaCSKCB;
                objBenhAn.NgayVao = txtTuNgay.GetDate;
                objBenhAn.NgayRa = txtDenNgay.GetDate;
                objBenhAn.DauHieu = txtDauHieuLamSang.Text;
                objBenhAn.KetQua = txtKetQuaXetNghiem.Text;
                objBenhAn.ChanDoan = txtChanDoan.Text;
                objBenhAn.PhuongPhap = txtPhuongPhap.Text;
                objBenhAn.TinhTrang = txtTinhTrang.Text;
                objBenhAn.LyDo = rdoDuDieuKien.Checked ? 1 : 0;

                DateTime? datetime = new DateTime?();
                if (txtNgayChuyenTuyen.GetDate != null)
                    datetime = txtNgayChuyenTuyen.GetDate.Value.AddHours(txtGio.IntValue).AddMinutes(txtPhut.IntValue);
                objBenhAn.ChuyenTuyenHoi = datetime;
                objBenhAn.HuongDieuTri = txtHuongDieuTri.Text;
                objBenhAn.PhuongTienVanChuyen = txtPhuongTienVanChuyen.Text;
                objBenhAn.NguoiHoTong = txtNguoiHoTong.Text;
                objBenhAn.Loai = "GiayChuyenTuyen";
                //objBenhAn.ChanDoanGPBL=;
                //objBenhAn.LoiDanThayThuoc=;
                objBenhAn.LyDoStr = rdoDuDieuKien.Checked ? rdoDuDieuKien.Text : rdoKhongDuDieuKien.Text;

                int kq = objBenhAn.Update();
                if (kq > 0)
                {

                    //MessageBox.Show("Thêm mới bảng kê thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblThongBao.Text = "Cập nhật giấy chuyển tuyến thành công.";
                    timerThongBao.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Cập nhật giấy chuyển tuyến không thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật giấy chuyển tuyến không thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //lblThongBao.Text = "Thêm mới bảng kê không thành công";
                //timerThongBao.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TrangThai = "";


            frmTimBenhAn frm = new frmTimBenhAn();
            frm.m_Loai = "GiayChuyenTuyen";
            frm.ShowDialog();


            m_SoLuuTru = frm.m_SoLuuTru;

            if (m_SoLuuTru.Trim() == "")
                return;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnDong.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;

            ResetControl();

            SetControlStatusReadOnly(true);
            m_SoLuuTru = frm.m_SoLuuTru;
            LoadData(2);
        }

        private void LoadData(int intLoai)
        {
            clsBenhAn objBenhAn = new clsBenhAn();
            if (TrangThai == "" && intLoai == 1)
                objBenhAn.GetBySoLuuTru(txtSoLuuTru.Text,Code);
            else
                objBenhAn.GetBySoLuuTru(m_SoLuuTru,Code);

            if (objBenhAn.BenhAn_Id > 0)
            {
                m_SoLuuTru = objBenhAn.SoLuuTru;

                txtSoLuuTru.Text = objBenhAn.SoLuuTru;
                txtMaYTe.Text = objBenhAn.MaYTe;
                txtHoTen.Text = objBenhAn.HoTen;
                cboGioiTinh.SelectedValue = objBenhAn.GioiTinh.ToString();
                txtNoiChuyenDen.Text = objBenhAn.NoiChuyenDen;
                txtTuoi.Text = objBenhAn.Tuoi.ToString();
                txtDanToc.Text = objBenhAn.DanToc;
                txtDiaChi.Text = objBenhAn.DiaChi;
                txtQuocTich.Text = objBenhAn.QuocTich;
                txtNgheNghiep.Text = objBenhAn.NgheNghiep;
                txtNoiLamViec.Text = objBenhAn.NoiLamViec;
                txtGiaTriTu.Text = string.Format("{0:dd/MM/yyyy}", objBenhAn.GiaTriTu);
                txtGiaTriDen.Text = string.Format("{0:dd/MM/yyyy}", objBenhAn.GiaTriDen); ;
                txtSoTheBHYT.Text = objBenhAn.SoTheBHYT;
                lblCSKCB.Text = objBenhAn.TenCSKCB;

                txtTuNgay.Text = string.Format("{0:dd/MM/yyyy}", objBenhAn.NgayVao);
                txtDenNgay.Text = string.Format("{0:dd/MM/yyyy}", objBenhAn.NgayRa); ;
                txtDauHieuLamSang.Text = objBenhAn.DauHieu;
                txtKetQuaXetNghiem.Text = objBenhAn.KetQua;
                txtChanDoan.Text = objBenhAn.ChanDoan;
                txtPhuongPhap.Text = objBenhAn.PhuongPhap;
                txtTinhTrang.Text = objBenhAn.TinhTrang;
                if (objBenhAn.LyDo == 1)
                {
                    rdoDuDieuKien.Checked = true;
                }
                else
                {
                    rdoKhongDuDieuKien.Checked = true;
                }

                if (objBenhAn.ChuyenTuyenHoi != null)
                {
                    txtGio.Text = objBenhAn.ChuyenTuyenHoi.Value.Hour.ToString();
                    txtPhut.Text = objBenhAn.ChuyenTuyenHoi.Value.Minute.ToString();
                    txtNgayChuyenTuyen.Text = string.Format("{0:dd/MM/yyyy}", objBenhAn.ChuyenTuyenHoi); ;
                }
                txtHuongDieuTri.Text = objBenhAn.HuongDieuTri;
                txtPhuongTienVanChuyen.Text = objBenhAn.PhuongTienVanChuyen;
                txtNguoiHoTong.Text = objBenhAn.NguoiHoTong;
                //txtSoLuuTru.Focus();
            }
            else
                ResetControl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (m_SoLuuTru.Trim() != "")
            {
                if (MessageBox.Show("Bạn có muốn xóa giấy chuyển tuyến này ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    clsBenhAn objBenhAn = new clsBenhAn();
                    objBenhAn.GetBySoLuuTru(m_SoLuuTru,Code);
                    if (objBenhAn.BenhAn_Id > 0)
                    {
                        int kq = objBenhAn.Delete(objBenhAn.BenhAn_Id);
                        if (kq > 0)
                        {
                            //MessageBox.Show("Thêm mới bảng kê thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblThongBao.Text = "Xóa giấy chuyển tuyến thành công.";
                            timerThongBao.Enabled = true;
                            ResetControl();
                            SetControlStatusReadOnly(true);
                        }
                        else
                        {
                            MessageBox.Show("Xóa giấy chuyển tuyến không thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Chọn giấy chuyển tuyến.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timerThongBao_Tick(object sender, EventArgs e)
        {

            lblThongBao.ForeColor = Color.Blue;
            lblThongBao.Text = "";
            timerThongBao.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetControl();
            SetControlStatusReadOnly(true);
        }

        private void txtGio_Validated(object sender, EventArgs e)
        {
            if (txtGio.Text.Trim() != "" && (txtGio.IntValue < 0 || txtGio.IntValue > 23))
            {
                lblThongBao.Text = "Giờ phải nằm trong khoảng 0 đến 23 giờ";
                timerThongBao.Enabled = true;
                txtGio.Text = "";
                txtGio.Focus();
            }
        }

        private void txtPhut_Validated(object sender, EventArgs e)
        {
            if (txtPhut.Text.Trim() != "" && (txtPhut.IntValue < 0 || txtPhut.IntValue > 59))
            {
                lblThongBao.Text = "Phút phải nằm trong khoảng từ 0 đến 59";
                timerThongBao.Enabled = true;
                txtPhut.Focus();
                txtPhut.Text = "";
            }
        }

        private void txtSoLuuTru_Validated(object sender, EventArgs e)
        {
            if (TrangThai == "")
            {
                LoadData(1);
            }
            else if (TrangThai == "ThemMoi")
            {
                clsBenhAn obj = new clsBenhAn();
                if (obj.CheckTonTaiSoLuuTru(txtSoLuuTru.Text,Code))
                {
                    MessageBox.Show("Mã số lưu trữ này đã tồn tại.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //lblThongBao.Text = "Mã khám chữa bệnh này đã tồn tại!";
                    //timerThongBao.Enabled = true;

                    txtSoLuuTru.Text = "";
                    txtSoLuuTru.Focus();

                }
            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (m_SoLuuTru.Trim() == "")
            {
                MessageBox.Show("Bạn vui lòng chọn giấy chuyển tuyến.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblThongBao.Text = "Bạn vui lòng chọn bảng kê để xem!";
                //timerThongBao.Enabled = true;
                return;
            }

            frmReport frm = new frmReport("GiayChuyenTuyen");
            frm.m_SoLuuTru = m_SoLuuTru;
            frm.m_LoaiGiay = Code;
            frm.Show();
        }

        private void cboGioiTinh_Enter(object sender, EventArgs e)
        {
            if (cboGioiTinh.DroppedDown == false)
            {
                cboGioiTinh.DroppedDown = true;
            }
        }

        private void txtSoTheBHYT_Enter(object sender, EventArgs e)
        {
            txtSoTheBHYT.Select(0, txtSoTheBHYT.TextLength);
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

        private void txtNguoiHoTong_Validated(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtNguoiHoTong.Text = textInfo.ToTitleCase(txtNguoiHoTong.Text.ToLower());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (m_SoLuuTru.Trim() == "")
            {
                MessageBox.Show("Bạn vui lòng chọn giấy chuyển tuyến để in.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblThongBao.Text = "Bạn vui lòng chọn bảng kê để in!";
                //timerThongBao.Enabled = true;
                return;
            }

            try
            {
                clsBaoCao bc = new clsBaoCao();
                clsDM_CSKCB objCSKCB = new clsDM_CSKCB();
                SystemConfig sys = SystemConfig.Instance;

                objCSKCB.GetByKey(sys.MaCSKCB);

                DataTable dt = new DataTable("BaoCao");
                dt = bc.GetBySoLuuTru(m_SoLuuTru,Code);

                string path = string.Format("{0}/Reports/{1}.rpt", Directory.GetCurrentDirectory(), "GiayChuyenTuyen");

                ReportDocument rpDocument = new ReportDocument();
                rpDocument.Load(path);
                rpDocument.SetDataSource(dt);


                ParameterDiscreteValue val = new ParameterDiscreteValue();
                val.Value = objCSKCB.TenCSKCB;

                ParameterDiscreteValue TenSYT = new ParameterDiscreteValue();
                TenSYT.Value = conf.TenSYT;

                ParameterValues paramVals = new ParameterValues();
                ParameterValues paramSYT = new ParameterValues();

                paramVals.Add(val);

                paramSYT.Add(TenSYT);

                rpDocument.ParameterFields["TenBenhVien"].CurrentValues = paramVals;

                rpDocument.ParameterFields["TenSYT"].CurrentValues = paramSYT;

                rpDocument.DataDefinition.ParameterFields["TenBenhVien"].ApplyCurrentValues(paramVals);
                rpDocument.DataDefinition.ParameterFields["TenSYT"].ApplyCurrentValues(paramSYT);

                int nCopy = (int)nupPage.Value;
                string PrinterName = cboMayIn.Text;
                rpDocument.PrintOptions.PrinterName = PrinterName;
                rpDocument.PrintToPrinter(nCopy, false, 0, 0);
            }
            catch
            {
                lblThongBao.Text = "Vui lòng kiểm tra lại máy in.";
                timerThongBao.Enabled = true;
            }

        }
    }
}
