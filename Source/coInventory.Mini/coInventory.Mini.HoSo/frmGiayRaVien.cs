using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
using System.Drawing.Printing;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

namespace coInventory.Mini.HoSo
{
    public partial class frmGiayRaVien : Form
    {
        private PrintDocument printDoc = new PrintDocument();
        SystemConfig conf = SystemConfig.Instance;

        clsDM_CSKCB m_CSKCB = new clsDM_CSKCB();

        private string TrangThai = "";

        private string m_SoLuuTru = "";

        private string Code = "GiayRaVien";

        public frmGiayRaVien()
        {
            InitializeComponent();
        }

        private void frmGiayRaVien_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
            LoadMayIn();
            m_CSKCB.GetByKey(conf.MaCSKCB);
            LoadDataCombobox();
            SetControlStatusReadOnly(true);
        }

        private void LoadDataCombobox()
        {
            cboGioiTinh.DataSource = Utilities.Utils.GetGioiTinh();
            cboGioiTinh.DisplayMember = "Name";
            cboGioiTinh.ValueMember = "Value";
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

        private void ResetControl()
        {
            txtSoLuuTru.Text = string.Empty;
            txtMaYTe.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            cboGioiTinh.SelectedIndex = 0;
            txtTuoi.Text = string.Empty;
            txtDanToc.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtQuocTich.Text = string.Empty;
            txtGiaTriTu.Text = string.Empty;
            txtGiaTriDen.Text = string.Empty;
            txtSoTheBHYT.Text = string.Empty;
            txtNgayVaoVien.Text = string.Empty;
            txtNgayRaVien.Text = string.Empty;
            txtChanDoan.Text = string.Empty;
            txtChanDoanGPBL.Text = string.Empty;
            txtPhuongPhapDieuTri.Text = string.Empty;
            txtLoiDanThayThuoc.Text = string.Empty;
            txtGioVaoVien.Text = string.Empty;
            txtGioRaVien.Text = string.Empty;
            txtPhutRaVien.Text = string.Empty;
            txtPhutVaoVien.Text = string.Empty;
             txtSoLuuTru.Focus();
            m_SoLuuTru = "";
        }
        private void SetControlStatusReadOnly(bool statusControl)
        {
            cboGioiTinh.Enabled = !statusControl;


            //txtSoLuuTru.ReadOnly = statusControl;
            txtMaYTe.ReadOnly = statusControl;
            txtHoTen.ReadOnly = statusControl;
            txtTuoi.Enabled = !statusControl;
            txtDanToc.ReadOnly = statusControl;
            txtDiaChi.ReadOnly = statusControl;
            txtQuocTich.ReadOnly = statusControl;
            txtGiaTriTu.Enabled = !statusControl;
            txtGiaTriDen.Enabled = !statusControl;
            txtSoTheBHYT.Enabled = !statusControl;
            txtChanDoan.ReadOnly = statusControl;
            txtChanDoanGPBL.ReadOnly = statusControl;
            txtPhuongPhapDieuTri.ReadOnly = statusControl;
            txtLoiDanThayThuoc.ReadOnly = statusControl;
            txtNgayVaoVien.Enabled = !statusControl;
            txtNgayRaVien.Enabled = !statusControl;
            txtGioVaoVien.Enabled = !statusControl;
            txtGioRaVien.Enabled = !statusControl;
            txtPhutRaVien.Enabled = !statusControl;
            txtPhutVaoVien.Enabled = !statusControl;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TrangThai = "";


            frmTimBenhAn frm = new frmTimBenhAn();
            frm.m_Loai = "GiayRaVien";
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
            if (IsRunCheck == true)
                return;
            clsBenhAn objBenhAn = new clsBenhAn();
            if (TrangThai == "" && intLoai == 1)
                objBenhAn.GetBySoLuuTru(txtSoLuuTru.Text,Code);
            else
                objBenhAn.GetBySoLuuTru(m_SoLuuTru,Code);
            
            if (objBenhAn.BenhAn_Id > 0)
            {
                m_SoLuuTru = objBenhAn.SoLuuTru;
                IsRunCheck = true;
                txtSoLuuTru.Text = objBenhAn.SoLuuTru;
                txtMaYTe.Text = objBenhAn.MaYTe;
                txtHoTen.Text = objBenhAn.HoTen;
                cboGioiTinh.SelectedValue = objBenhAn.GioiTinh.ToString();
                txtTuoi.Text = objBenhAn.Tuoi.ToString();
                txtDanToc.Text = objBenhAn.DanToc;
                txtDiaChi.Text = objBenhAn.DiaChi;
                txtQuocTich.Text = objBenhAn.QuocTich;
                txtGiaTriTu.Text = string.Format("{0:dd/MM/yyyy}", objBenhAn.GiaTriTu);
                txtGiaTriDen.Text = string.Format("{0:dd/MM/yyyy}", objBenhAn.GiaTriDen); ;
                txtSoTheBHYT.Text = objBenhAn.SoTheBHYT;


                txtChanDoan.Text = objBenhAn.ChanDoan;
                txtChanDoanGPBL.Text = objBenhAn.ChanDoanGPBL;
                txtLoiDanThayThuoc.Text = objBenhAn.LoiDanThayThuoc;
                txtPhuongPhapDieuTri.Text = objBenhAn.PhuongPhap;


                if (objBenhAn.NgayVao != null)
                {
                    txtGioVaoVien.Text = objBenhAn.NgayVao.Value.Hour.ToString();
                    txtPhutVaoVien.Text = objBenhAn.NgayVao.Value.Minute.ToString();
                    txtNgayVaoVien.Text = string.Format("{0:dd/MM/yyyy}", objBenhAn.NgayVao); ;
                }
                if (objBenhAn.NgayRa != null)
                {
                    txtGioRaVien.Text = objBenhAn.NgayRa.Value.Hour.ToString();
                    txtPhutRaVien.Text = objBenhAn.NgayRa.Value.Minute.ToString();
                    txtNgayRaVien.Text = string.Format("{0:dd/MM/yyyy}", objBenhAn.NgayRa); ;
                }
                //txtSoLuuTru.Focus();
                IsRunCheck = false;
            }
            else
                ResetControl();
        }

        private void frmGiayRaVien_KeyDown(object sender, KeyEventArgs e)
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

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (m_SoLuuTru.Trim() != "")
            {
                if (MessageBox.Show("Bạn có muốn xóa giấy ra viện này ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    clsBenhAn objBenhAn = new clsBenhAn();
                    objBenhAn.GetBySoLuuTru(m_SoLuuTru,Code);
                    if (objBenhAn.BenhAn_Id > 0)
                    {
                        int kq = objBenhAn.Delete(objBenhAn.BenhAn_Id);
                        if (kq > 0)
                        {
                            //MessageBox.Show("Thêm mới bảng kê thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblThongBao.Text = "Xóa giấy ra viện thành công.";
                            timerThongBao.Enabled = true;
                            ResetControl();
                            SetControlStatusReadOnly(true);
                        }
                        else
                        {
                            MessageBox.Show("Xóa giấy ra viện không thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Chọn giấy ra viện.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timerThongBao_Tick(object sender, EventArgs e)
        {
            lblThongBao.ForeColor = Color.Blue;
            lblThongBao.Text = "";
            timerThongBao.Enabled = false;
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
                MessageBox.Show("Có lỗi trong quá trình lưu.Vui lòng kiểm tra lại thông tin!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblThongBao.Text = "Có lỗi trong quá trình lưu.Vui lòng kiểm tra lại thông tin!";
                //timerThongBao.Enabled = true;
            }
        }

        private void InsertData()
        {
            clsBenhAn objBenhAn = new clsBenhAn();
            try
            {
                m_SoLuuTru = txtSoLuuTru.Text;
                objBenhAn.GetBySoLuuTru(m_SoLuuTru,Code);
                objBenhAn.SoLuuTru = txtSoLuuTru.Text;
                objBenhAn.MaYTe = txtMaYTe.Text;
                objBenhAn.HoTen = txtHoTen.Text;
                objBenhAn.GioiTinh = int.Parse(cboGioiTinh.SelectedValue.ToString());
                objBenhAn.Tuoi = txtTuoi.IntValue;
                objBenhAn.DanToc = txtDanToc.Text;
                objBenhAn.DiaChi = txtDiaChi.Text;
                objBenhAn.QuocTich = txtQuocTich.Text;
                objBenhAn.GiaTriTu = txtGiaTriTu.GetDate;
                objBenhAn.GiaTriDen = txtGiaTriDen.GetDate;
                objBenhAn.SoTheBHYT = txtSoTheBHYT.Text;
                objBenhAn.MaCSKCB = conf.MaCSKCB;
                


                DateTime? datetimeNgayVao = new DateTime?();
                DateTime? datetimeNgayRa = new DateTime?();

                if (txtNgayVaoVien.GetDate != null)
                    datetimeNgayVao = txtNgayVaoVien.GetDate.Value.AddHours(txtGioVaoVien.IntValue).AddMinutes(txtPhutVaoVien.IntValue);
                if (txtNgayRaVien.GetDate != null)
                    datetimeNgayRa = txtNgayRaVien.GetDate.Value.AddHours(txtGioRaVien.IntValue).AddMinutes(txtPhutRaVien.IntValue);

                objBenhAn.NgayVao = datetimeNgayVao;
                objBenhAn.NgayRa = datetimeNgayRa;

                objBenhAn.Loai = "GiayRaVien";
                objBenhAn.ChanDoan = txtChanDoan.Text;
                objBenhAn.ChanDoanGPBL = txtChanDoanGPBL.Text;
                objBenhAn.LoiDanThayThuoc = txtLoiDanThayThuoc.Text;
                objBenhAn.PhuongPhap = txtPhuongPhapDieuTri.Text;

                int kq = objBenhAn.Insert();
                if (kq > 0)
                {
                    //MessageBox.Show("Thêm mới bảng kê thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblThongBao.Text = "Thêm giấy ra viện thành công.";
                    timerThongBao.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm giấy ra viện không thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm giấy ra viện không thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                objBenhAn.GetBySoLuuTru(m_SoLuuTru,Code);
                objBenhAn.SoLuuTru = txtSoLuuTru.Text;
                objBenhAn.MaYTe = txtMaYTe.Text;
                objBenhAn.HoTen = txtHoTen.Text;
                objBenhAn.GioiTinh = int.Parse(cboGioiTinh.SelectedValue.ToString());
                objBenhAn.Tuoi = txtTuoi.IntValue;
                objBenhAn.DanToc = txtDanToc.Text;
                objBenhAn.DiaChi = txtDiaChi.Text;
                objBenhAn.QuocTich = txtQuocTich.Text;
                objBenhAn.GiaTriTu = txtGiaTriTu.GetDate;
                objBenhAn.GiaTriDen = txtGiaTriDen.GetDate;
                objBenhAn.SoTheBHYT = txtSoTheBHYT.Text;
                objBenhAn.MaCSKCB = conf.MaCSKCB;
                

                DateTime? datetimeNgayVao = new DateTime?();
                DateTime? datetimeNgayRa = new DateTime?();

                if (txtNgayVaoVien.GetDate != null)
                    datetimeNgayVao = txtNgayVaoVien.GetDate.Value.AddHours(txtGioVaoVien.IntValue).AddMinutes(txtPhutVaoVien.IntValue);
                if (txtNgayRaVien.GetDate != null)
                    datetimeNgayRa = txtNgayRaVien.GetDate.Value.AddHours(txtGioRaVien.IntValue).AddMinutes(txtPhutRaVien.IntValue);

                objBenhAn.NgayVao = datetimeNgayVao;
                objBenhAn.NgayRa = datetimeNgayRa;

                objBenhAn.Loai = "GiayRaVien";
                objBenhAn.ChanDoan = txtChanDoan.Text;
                objBenhAn.ChanDoanGPBL=txtChanDoanGPBL.Text;
                objBenhAn.LoiDanThayThuoc=txtLoiDanThayThuoc.Text;
                objBenhAn.PhuongPhap = txtPhuongPhapDieuTri.Text;

                int kq = objBenhAn.Update();
                if (kq > 0)
                {

                    //MessageBox.Show("Thêm mới bảng kê thành công", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblThongBao.Text = "Cập nhật giấy ra viện thành công.";
                    timerThongBao.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Cập nhật giấy ra viện không thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật giấy ra viện không thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //lblThongBao.Text = "Thêm mới bảng kê không thành công";
                //timerThongBao.Enabled = true;
            }
        }

        private string ValidateControl()
        {

            string str = "";
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

            if (txtNgayVaoVien.Text.Replace("/", "").Trim().Length == 0 || txtGioVaoVien.Text.Trim().Length==0 || txtPhutVaoVien.Text.Trim().Length==0)
            {
                str += "- Vui lòng nhập ngày giờ vào viện." + Environment.NewLine;
            }
            if (txtNgayRaVien.Text.Replace("/", "").Trim().Length == 0 || txtGioRaVien.Text.Trim().Length == 0 || txtPhutRaVien.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập ngày giờ ra viện." + Environment.NewLine;
            }

            if (txtChanDoan.Text.Trim().Length == 0)
            {
                str += "- Vui lòng nhập chẩn đoán." + Environment.NewLine;
            }


            return str;

        }

        private void txtGioVaoVien_Validated(object sender, EventArgs e)
        {
            if (txtGioVaoVien.Text.Trim() != "" && (txtGioVaoVien.IntValue < 0 || txtGioVaoVien.IntValue > 23))
            {
                lblThongBao.Text = "Giờ phải nằm trong khoảng 0 đến 23 giờ";
                timerThongBao.Enabled = true;
                txtGioVaoVien.Text = "";
                txtGioVaoVien.Focus();
                return;
            }
            if (txtPhutVaoVien.Text.Trim() != "" && (txtPhutVaoVien.IntValue < 0 || txtPhutVaoVien.IntValue > 59))
            {
                lblThongBao.Text = "Phút phải nằm trong khoảng 0 đến 59";
                timerThongBao.Enabled = true;
                txtPhutVaoVien.Text = "";
                txtPhutVaoVien.Focus();
                return;
            }

            if (txtGioRaVien.Text.Trim() != "" && (txtGioRaVien.IntValue < 0 || txtGioRaVien.IntValue > 23))
            {
                lblThongBao.Text = "Giờ phải nằm trong khoảng 0 đến 23 giờ";
                timerThongBao.Enabled = true;
                txtGioRaVien.Text = "";
                txtGioRaVien.Focus();
                return;
            }
            if (txtPhutRaVien.Text.Trim() != "" && (txtPhutRaVien.IntValue < 0 || txtPhutRaVien.IntValue > 59))
            {
                lblThongBao.Text = "Phút phải nằm trong khoảng 0 đến 59";
                timerThongBao.Enabled = true;
                txtPhutVaoVien.Text = "";
                txtPhutVaoVien.Focus();
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TrangThai = "CapNhat";
            if (m_SoLuuTru.Trim() == "")
            {
                TrangThai = "";
                MessageBox.Show("Bạn vui lòng chọn số lưu trữ!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetControl();
            SetControlStatusReadOnly(true);
        }

        bool IsRunCheck = false;
        private void txtSoLuuTru_Validated(object sender, EventArgs e)
        {
            if (TrangThai == "" )
            {
                LoadData(1);
            }
            else if (TrangThai == "ThemMoi")
            {
                clsBenhAn obj = new clsBenhAn();
                if (obj.CheckTonTaiSoLuuTru(txtSoLuuTru.Text, Code))
                {
                    MessageBox.Show("Mã số lưu trữ này đã tồn tại!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Bạn vui lòng chọn giấy ra viện.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblThongBao.Text = "Bạn vui lòng chọn bảng kê để xem!";
                //timerThongBao.Enabled = true;
                return;
            }

            frmReport frm = new frmReport("GiayRaVien");
            frm.m_SoLuuTru = m_SoLuuTru;
            frm.m_LoaiGiay = Code;
            frm.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (m_SoLuuTru.Trim() == "")
            {
                MessageBox.Show("Bạn vui lòng chọn giấy chuyển tuyến để in!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                string path = string.Format("{0}/Reports/{1}.rpt", Directory.GetCurrentDirectory(), "GiayRaVien");

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

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
