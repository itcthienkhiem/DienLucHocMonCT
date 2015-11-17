using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
using Inventory.NhapXuat;
using Inventory.Utilities;
using Inventory.Report;

namespace Inventory.XuatTamVatTu
{
    /// <summary>
    /// In Processing
    /// [.] Xử lý logic trên frm --> dc khoảng 60%
    /// [x] Cập nhật dữ liệu tồn sau khi xuất bình thường --> Đang làm...
    /// [.] Xử lý vấn đề nhiều loại VT trên cùng 1 grid --> in processing... --> 80%, check sau
    /// [.] Sửa lại phần cập nhật vào DB --> căn bản xong
    /// [x] Xử lý phần mượn vt giữa các kho
    /// [ ] Xử lý tính toán SL thực xuất --> Tạm xong 50%
    /// [ ] Xử lý trường hợp giữ lại VT
    /// [ ] Xử lý đóng phiếu xuất.
    /// [ ] Xử lý thêm vào thẻ kho
    /// [ ] Phần hoàn nhập - giữa lại: Nếu đã giữ lại, thì khi trả nợ xong mới dc set duyệt hoàn nhập, hoặc hoàn nhập hết cái đang giữ.
    /// [ ] Nếu NV còn nợ VT thì hiện 2 nút
    ///     [ ] Trả nợ: Init vào grid những vt của NV đó còn đang giữ.
    ///     [ ] Hoàn nhập lại --> chuyển qua frm xuất, thực hiện hoàn nhập.
    /// [ ] Có 3 stt cần giải
    ///     [ ] 1 là báo giữ VT --> chỉ cho edit 1 phần giữ lại rồi add vào
    ///     [ ] 2 là phần hoàn nhập --> tương tự chỉ cho edit phần HN, nếu SL giữ lại  != 0, SL hoàn NV ko thể lớn hơn SL giữ lại, càng ko thể lớn hơn SLTX, sau khi Hn thì xóa nợ.
    ///     [ ] 3 là phần xuất cho NV còn giữ VT, phải HN, hoặc dùng tiếp tất cả.
    /// [ ] Nếu nợ VT
    ///     [ ] Phải dùng tiếp hoặc hoàn nhập
    ///     [ ] Cấm xóa dòng có nợ
    ///     [ ] Không lưu nếu các dòng có nợ chưa duyệt xuất.
    /// 
    /// Setup
    /// [ ] Xuất cho nhân viên --> truyền vào ID Nhân Viên
    ///     --> Nhân viên đó có thể còn giữ vật tư
    /// [ ] Xác nhận lượng vật tư đã xuất
    ///     --> Cập nhật lại sl vt tồn trong kho
    /// [ ] Xác nhận hoàn nhập hoặc báo giữ lại VT
    ///     --> NV giữ vật tư thì add vào nợ vật tư
    ///     --> NV hoàn nhập thì cập nhật lại vào kho đã xuất
    /// 
    /// [ ] Xem/sửa phiếu xuất --> truyền vào mã phiếu xuất
    /// [ ] Thêm phiếu xuất mới
    /// 
    /// [ ] Xuất kho, nhưng kho được chọn bị thiếu vật tư, phải mượn từ kho khác --> Tạm chưa xử lý
    /// 
    /// Xử lý ngoại lệ:
    /// [ ] Xuất cho nhân viên chưa có trong DM NV --> Yêu cầu thêm, hoặc ask: tự động thêm (Ko khả thi)
    /// [ ] Trường hợp nhân viên giữ lại --> ngày hôm sau dùng tiếp, nhưng ít hơn SL giữ lại.
    /// 
    /// Show:
    /// [ ] SL vật tư còn lại trong kho đã chọn
    /// [ ] ChkBox Mượn vật tư sẽ bị disable nếu trong list có vật tư từ kho khác
    /// 
    /// Khởi tạo: 
    /// [ ] SET enable/disable cho các component
    /// [ ] init cho Panel trên và dưới
    /// [ ] init cho các comboBox
    /// [ ] Ràng buột dữ liệu
    /// 
    /// 
    /// Problem:
    /// [ ] Cache dữ liệu, phòng cúp điện?
    /// [ ] SL Giữ lại + SL Hoàn Nhập phải bằng SL Đề Nghị --> Trường hợp ko bằng --> chưa xử lý dc
    /// [ ] Trường hợp mượn vật tư từ "kho khác tên x", khi trả lại, ko trả về "kho khác tên x" đó, mà trả lại kho xuất cho phiếu đó.
    ///     --> Vấn đề trả nợ giữa các kho sẽ xử lý ở 1 frm khác.
    /// [ ] Kho mượn vt ko được trùng với kho xuất -> refesh --> remove bớt 1 item khi kho xuất thay đổi.
    /// [ ] Kho xuất, khi đã chọn vật tư từ kho và add vào grid, thì ko dc thay đổi nữa kho xuất nữa --> set readonly
    /// [ ] Tạo hàm check, nếu chọn vt mà sl trong kho bằng 0 thì hiện đỏ ở phần sl vật tư
    /// [ ] Chọn Mã vật tư | Tên VT set luôn dvt, sl còn lại trong kho
    /// [ ] Xử trường hợp Nhập Tên NV ko có trong DM Nhan Vien
    /// [ ] Vấn đề SL ảo của 1 loại VT đã add vào grid, vt còn 10, add vật tư A --> 10, lại add vt A 5.
    ///     --> Phải check đã add chưa, để set còn lại.
    /// [ ] SL thực xuất có thể ko bằng SL đề nghị, vì tất cả các kho đều hết VT chẳng hạn.
    /// [ ] Phần sửa trên grid, khi đã xác nhận xuất thì ko thể sửa info như mã vt, hãy phần xuất
    /// 
    /// btnThem:
    /// [ ] Nhập mã phiếu trước khi chọn thêm, mã phiếu hợp lệ mới dc thêm.
    /// [ ] Mã phiếu có thể auto tạo từ crc của curDateTime
    /// 
    /// Xử lý với nhân viên giữ vật tư:
    /// [ ] Nếu còn giữ VT, bắt phải dùng tiếp vật tư đó --> xử lý ở nút ADD
    /// [ ] Hoặc phải hoàn nhập, bật về frm của phiếu xuất cũ --> thêm vào hoàn nhập --> xóa nợ.
    /// [?] Vấn đề --> duyệt hoàn nhập giữ lại @.@
    /// 
    /// ToolTip1.Show("Nhân viên này còn đang giữ vật tư", this.cbTenNhanVien, 15, 15, 1500);
    /// </summary>
    public partial class frmChiTietPhieuXuatTam : DevExpress.XtraEditors.XtraForm
    {
        //------------ New --------------
        FormActionDelegate2 frmAction;
        clsPanelButton2 PanelButton;

        System.Windows.Forms.ToolTip ToolTip1;

        clsChiTietPhieuXuatTam PhieuXuat;

        //private enum enumFlagSL : byte { None = 0, HasVal, Alert };

        //enumFlagSL flagSL;

        private System.Windows.Forms.ErrorProvider errorProvider1;

        AutoConfigFormControls autoConfigFormControls;

        //int ID_nhan_vien;

        public frmChiTietPhieuXuatTam()
        {
            InitializeComponent();
            frm_init();


        }

        private void frm_init()
        {
            button1.Visible = false;
            ToolTip1 = new System.Windows.Forms.ToolTip();
            errorProvider1 = new ErrorProvider();
            autoConfigFormControls = new AutoConfigFormControls(ref errorProvider1);

            //flagSL = enumFlagSL.None;

            initPanelButton();
            initTextBox();

            init_cb();

            PhieuXuat = new clsChiTietPhieuXuatTam();

            DisableControl_ForNew();
        }

        public frmChiTietPhieuXuatTam(int ID_nhan_vien)
        {
            InitializeComponent();
            frm_init();

            cbMaPhieuXuatTam.Text = TaoMaPhieu();
            btnThem_Click(btnThem, EventArgs.Empty);

            cbMaNhanVien.SelectedValue = ID_nhan_vien;
            cbMaNhanVien_SelectionChangeCommitted(cbMaNhanVien, EventArgs.Empty);
            cbTenNhanVien_SelectionChangeCommitted(cbTenNhanVien, EventArgs.Empty);
        }

        //Xử lý báo giữ lại VT
        public frmChiTietPhieuXuatTam(string MaPhieXuatTam, enumButton2 stt)
        {
            InitializeComponent();
            frm_init();

            clsPhieuXuatTamVatTu pxt = new clsPhieuXuatTamVatTu();
            if (pxt.CheckTonTaiSoDK(MaPhieXuatTam) == false)
            {
                MessageBox.Show("Mã phiếu xuất bạn chọn ko tồn tại!");
                this.Close();
            }
                

            cbMaPhieuXuatTam.Text = MaPhieXuatTam;
            btnSua_Click(btnSua, EventArgs.Empty);

            //tùy theo stt, setup frm
            if (stt == enumButton2.BaoGiuLai)
            {
                PanelButton.setClickStatus(stt);
                EnableControl_For_BaoGiuLai();
            }
            else if (stt == enumButton2.BaoHoanNhap)
            {
                PanelButton.setClickStatus(stt);
                EnableControl_For_BaoHoanNhap();
            }
            else
            {
                MessageBox.Show("Xảy ra lỗi khởi tạo phiếu!");
                this.Close();
            }
        }

        private string TaoMaPhieu()
        {
            DateTime today = DateTime.Today;
            clsPhieuXuatTamVatTu px = new clsPhieuXuatTamVatTu();

            int stt = px.GetMaxID() + 1;

            string s = stt.ToString();

            for (int i = s.Length; s.Length < 4; i++)
            {
                s = "0" + s;
            }

            string result = today.Year.ToString().Substring(2, 2) + today.Month.ToString() + today.Day.ToString() + s;

            // ID_phieu_xuat_tam

            return result;
        }

        private void btnCheckMaPhieuXuat_Click(object sender, EventArgs e)
        {
            cbMaPhieuXuatTam.Text = TaoMaPhieu();

        }

        /// <summary>
        /// Testing
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            //clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
            //chitiet.Update_row("xuat001", dataTableChiTietPhieuXuatTam, 0);

            //clsChiTietPhieuXuatTam ChiTietPhieuXuat = new clsChiTietPhieuXuatTam();

            //ChiTietPhieuXuat.CapNhapChiTietPhieuXuat(dataTableChiTietPhieuXuatTam, cbMaPhieuXuatTam.Text);

            //cbMaPhieuXuatTam.Items.Clear();
            //init_cbMaPhieuXuatTam();

            //cbMuonVTTaiKho.Items.RemoveAt(0);
            //GetItemText(cbMaVatTu.SelectedItem)
            //ToolTip1.Show(cbMaVatTu.GetItemText(cbMaVatTu.SelectedItem), this.cbMaVatTu, 0, 0, 2000);

            //clsPhieuXuatTamVatTu px = new clsPhieuXuatTamVatTu();

            //ToolTip1.Show(TaoMaPhieu(), this.cbMaVatTu, 0, 0, 2000);

            //clsChiTietPhieuXuatTam px = new clsChiTietPhieuXuatTam();

            //ToolTip1.Show(px.getBool_DaDuyetXuat("1510280009", "002", 1, 1).ToString(), this.cbMaVatTu, 0, 0, 2000);

            Int32 selectedRowCount = gridChiTietPhieuXuatTam.CurrentRow.Index;
            DataGridViewRow selectedRow = gridChiTietPhieuXuatTam.Rows[selectedRowCount];

            ToolTip1.Show(selectedRow.Cells["_ID_chi_tiet_phieu_xuat_tam"].Value.ToString(), this.cbMaVatTu, 0, 0, 2000);
        }

        public void frmChiTietPhieuXuatTam_Load(object sender, EventArgs e)
        {
            //ToolTip1.SetToolTip(this.btnCheckNVGiuVT, "Hello");
        }

        

        /// <summary>
        /// Demo tính năng thêm, tắt tạm tính năng sửa.
        /// </summary>
        private void initPanelButton()
        {
            //Init cls Panel Button
            PanelButton = new clsPanelButton2();

            frmAction = new FormActionDelegate2(FormAction);
            PanelButton.setDelegateFormAction(frmAction);

            PanelButton.AddButton(enumButton2.Them, ref btnThem);
            PanelButton.AddButton(enumButton2.Xoa, ref btnXoa);
            PanelButton.AddButton(enumButton2.Sua, ref btnSua);
            PanelButton.AddButton(enumButton2.LamMoi, ref btnLamMoi);
            PanelButton.AddButton(enumButton2.Luu, ref btnLuu);

            PanelButton.AddButton(enumButton2.Huy, ref btnHuy);
            PanelButton.AddButton(enumButton2.Dong, ref btnDong);

            PanelButton.AddButton(enumButton2.ThemLuoi, ref btnAddToGrid);
            PanelButton.AddButton(enumButton2.XoaLuoi, ref btnDelRowInGrid);
            PanelButton.AddButton(enumButton2.SuaLuoi, ref btnEditRowInGrid);
            PanelButton.AddButton(enumButton2.LuuThayDoiVaoLuoi, ref btnSaveGrid);
            PanelButton.AddButton(enumButton2.HuySuaLuoi, ref btnCancel);

            PanelButton.setButtonStatus(enumButton2.ThemLuoi, true);
            PanelButton.setButtonStatus(enumButton2.XoaLuoi, true);
            PanelButton.setButtonStatus(enumButton2.SuaLuoi, true);
            PanelButton.setButtonStatus(enumButton2.LuuThayDoiVaoLuoi, true);
            PanelButton.setButtonStatus(enumButton2.HuySuaLuoi, true);

            PanelButton.setButtonClickEvent(enumButton2.Dong);
            PanelButton.setButtonClickEvent(enumButton2.Huy);
            PanelButton.setButtonClickEvent(enumButton2.HuySuaLuoi);

            PanelButton.setButtonStatus(enumButton2.Xoa, false);
            PanelButton.setButtonStatus(enumButton2.Sua, true);
            PanelButton.setButtonStatus(enumButton2.LamMoi, false);

            btnXoa.Enabled = false;
            //btnSua.Enabled = false;
            btnLamMoi.Enabled = false;

            PanelButton.ResetButton();
        }

        public void FormAction(enumFormAction2 frmAct)
        {
            switch (frmAct)
            {
                case enumFormAction2.None:
                    break;
                case enumFormAction2.LoadData:
                    break;
                case enumFormAction2.CloseForm:
                    CloseForm();
                    break;
                case enumFormAction2.setFormData:
                    break;
                case enumFormAction2.ResetInputForm:
                    ResetInputForm();
                    //ToolTip1.Show("ResetInputForm();", this.cbMaPhieuXuatTam, 20, 20, 2000);
                    break;
                case enumFormAction2.disableInputForm:
                    DisableControl_ForNew();
                    //ToolTip1.Show("DisableControl_ForNew();", this.cbMaPhieuXuatTam, 20, 20, 2000);
                    break;
                case enumFormAction2.btnCancel:
                    ResetGridInputForm();
                    break;
                case enumFormAction2.Dong:
                    break;
                case enumFormAction2.ResetGridInputForm:
                    ResetGridInputForm();
                    break;
                default:
                    break;
            }
        }

        
        private void chkInitCB()
        {
            if (Double.Parse(txtSLDangGiu.Text) > 0)
            {
                init_cbMaVatTu();
                init_cbTenVatTu();
            }
        }
        

        /// <summary>
        /// btnThem:
        /// [ ] Check xem mã phiếu xuất hợp lệ chưa, có trùng ko? Nếu trùng thì bắt nhập cái khác.
        /// [ ] Nếu ổn, enable control cho nhập, cho phép lưu, hủy.
        /// </summary>
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbMaPhieuXuatTam.Text.Trim().Equals(string.Empty))
            {
                cbMaPhieuXuatTam.Text = TaoMaPhieu();
            }

            //Nếu cbMaPhieuXuatTam đã có thì báo lỗi --> đề nghị nhập lại --> ko cho thêm
            if (cbMaPhieuXuatTam.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Bạn chưa nhập mã phiếu xuất tạm");
                return;
            }

            if(PhieuXuat.isHasDuplicateRow(cbMaPhieuXuatTam.Text.Trim().ToString()))
            {
                MessageBox.Show("Mã phiếu xuất này đã tồn tại, không thể thêm mới được.");
                return;
            }

            if (PanelButton.isClickNone())
            {
                PanelButton.setClickThem();

                PanelButton.Enable_btn_Luu_Huy();

                EnableControl_ForNew();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //btnCheckMaPhieuXuat.Enabled = true;

            //Ko cần thiết
            if (cbMaPhieuXuatTam.Text.Trim() == "")
            {
                MessageBox.Show("Mã phiếu bắt buộc nhập!");
                return;
            }

            if (dataTableChiTietPhieuXuatTam.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu trong danh sách vật tư không rỗng");
                return;
            }

            switch (PanelButton.getClickStatus())
            {
                case enumButton2.Them:
                    try
                    {
                        //01: Thêm phiếu vào DS
                        clsPhieuXuatTamVatTu phieuxuat = new clsPhieuXuatTamVatTu();

                        phieuxuat.Ma_phieu_xuat_tam = cbMaPhieuXuatTam.Text.Trim();
                        phieuxuat.ID_Nhan_vien = Int32.Parse(cbMaNhanVien.SelectedValue.ToString());
                        phieuxuat.Ngay_xuat = dtNgayXuat.Value;

                        phieuxuat.ID_kho = Int32.Parse(cbKhoXuat.SelectedValue.ToString());

                        phieuxuat.Ly_do = txtLyDo.Text.Trim();
                        phieuxuat.Cong_trinh = txtCongTrinh.Text.Trim();
                        phieuxuat.Dia_chi = txtDiaChi.Text.Trim();
                        phieuxuat.Da_duyet = bDaDuyetPhieuXuat();

                        try
                        {
                            clsChiTietPhieuXuatTam ChiTietPhieuXuat = new clsChiTietPhieuXuatTam();
                            if (ChiTietPhieuXuat.CapNhapChiTietPhieuXuat(dataTableChiTietPhieuXuatTam, phieuxuat.Ma_phieu_xuat_tam, phieuxuat) == 1)
                            {
                                MessageBox.Show("Bạn đã thêm thành công!");

                                PanelButton.setClickSua();
                                ResetGridInputForm();
                                dataTableChiTietPhieuXuatTam.Clear();
                                SetDataToGrid();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                        catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    break;

                case enumButton2.Sua:
                    {
                        try
                        {
                            //01: Thêm phiếu vào DS
                            clsPhieuXuatTamVatTu phieuxuat = new clsPhieuXuatTamVatTu();

                            phieuxuat.Ma_phieu_xuat_tam = cbMaPhieuXuatTam.Text.Trim();
                            phieuxuat.ID_Nhan_vien = Int32.Parse(cbMaNhanVien.SelectedValue.ToString());
                            phieuxuat.Ngay_xuat = dtNgayXuat.Value;

                            phieuxuat.ID_kho = Int32.Parse(cbKhoXuat.SelectedValue.ToString());

                            phieuxuat.Ly_do = txtLyDo.Text.Trim();
                            phieuxuat.Cong_trinh = txtCongTrinh.Text.Trim();
                            phieuxuat.Dia_chi = txtDiaChi.Text.Trim();
                            phieuxuat.Da_duyet = bDaDuyetPhieuXuat();

                            try
                            {
                                clsChiTietPhieuXuatTam ChiTietPhieuXuat = new clsChiTietPhieuXuatTam();
                                if (ChiTietPhieuXuat.CapNhapChiTietPhieuXuat(dataTableChiTietPhieuXuatTam, phieuxuat.Ma_phieu_xuat_tam, phieuxuat) == 1)
                                {
                                    MessageBox.Show("Bạn đã cập nhật thành công!");
                                    ResetGridInputForm();
                                    dataTableChiTietPhieuXuatTam.Clear();
                                    SetDataToGrid();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                            catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    break;
                case enumButton2.BaoGiuLai:
                    {
                        try
                        {
                            //01: Thêm phiếu vào DS
                            clsPhieuXuatTamVatTu phieuxuat = new clsPhieuXuatTamVatTu();

                            phieuxuat.Ma_phieu_xuat_tam = cbMaPhieuXuatTam.Text.Trim();
                            phieuxuat.ID_Nhan_vien = Int32.Parse(cbMaNhanVien.SelectedValue.ToString());
                            phieuxuat.Ngay_xuat = dtNgayXuat.Value;

                            phieuxuat.ID_kho = Int32.Parse(cbKhoXuat.SelectedValue.ToString());

                            phieuxuat.Ly_do = txtLyDo.Text.Trim();
                            phieuxuat.Cong_trinh = txtCongTrinh.Text.Trim();
                            phieuxuat.Dia_chi = txtDiaChi.Text.Trim();
                            phieuxuat.Da_duyet = bDaDuyetPhieuXuat();

                            try
                            {
                                clsChiTietPhieuXuatTam ChiTietPhieuXuat = new clsChiTietPhieuXuatTam();
                                if (ChiTietPhieuXuat.CapNhapChiTietPhieuXuat(dataTableChiTietPhieuXuatTam, phieuxuat.Ma_phieu_xuat_tam, phieuxuat) == 1)
                                {
                                    MessageBox.Show("Bạn đã cập nhật thành công!");
                                    ResetGridInputForm();
                                    dataTableChiTietPhieuXuatTam.Clear();
                                    SetDataToGrid();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    break;
                case enumButton2.BaoHoanNhap:
                    {
                        try
                        {
                            //01: Thêm phiếu vào DS
                            clsPhieuXuatTamVatTu phieuxuat = new clsPhieuXuatTamVatTu();

                            phieuxuat.Ma_phieu_xuat_tam = cbMaPhieuXuatTam.Text.Trim();
                            phieuxuat.ID_Nhan_vien = Int32.Parse(cbMaNhanVien.SelectedValue.ToString());
                            phieuxuat.Ngay_xuat = dtNgayXuat.Value;

                            phieuxuat.ID_kho = Int32.Parse(cbKhoXuat.SelectedValue.ToString());

                            phieuxuat.Ly_do = txtLyDo.Text.Trim();
                            phieuxuat.Cong_trinh = txtCongTrinh.Text.Trim();
                            phieuxuat.Dia_chi = txtDiaChi.Text.Trim();
                            phieuxuat.Da_duyet = bDaDuyetPhieuXuat();

                            try
                            {
                                clsChiTietPhieuXuatTam ChiTietPhieuXuat = new clsChiTietPhieuXuatTam();
                                if (ChiTietPhieuXuat.CapNhapChiTietPhieuXuat(dataTableChiTietPhieuXuatTam, phieuxuat.Ma_phieu_xuat_tam, phieuxuat) == 1)
                                {
                                    MessageBox.Show("Bạn đã cập nhật thành công!");
                                    ResetGridInputForm();
                                    dataTableChiTietPhieuXuatTam.Clear();
                                    SetDataToGrid();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    break;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Nếu cbMaPhieuXuatTam đã có thì báo lỗi --> đề nghị nhập lại --> ko cho thêm
            if (cbMaPhieuXuatTam.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Bạn chưa nhập mã phiếu xuất tạm");
                return;
            }

            if (!PhieuXuat.isHasDuplicateRow(cbMaPhieuXuatTam.Text.Trim().ToString()))
            {
                MessageBox.Show("Mã phiếu xuất này không tồn tại.");
                return;
            }

            if (PanelButton.isClickNone())
            {
                PanelButton.setClickSua();

                PanelButton.Enable_btn_Luu_Huy();

                EnableControl_ForNew();

                SetDataToForm();

                SetDataToGrid();
            }
        }

        private bool checkSoLuongXuat()
        {
            if (getDouble(txtSLDN) == 0)
            {
                ToolTip1.Show("Số lượng đề nghị không thể bằng 0!", this.txtSLDN, 20, 20, 1500);
                return false;
            }

            if (getDouble(txtSLDN) < getDouble(txtSLTX))
            {
                ToolTip1.Show("SL thực xuất không thể lớn hơn SL đề nghị!", this.txtSLTX, 20, 20, 1500);
                return false;
            }

            if (getDouble(txtSLDN) < 0)
            {
                ToolTip1.Show("Số lượng đề nghị không thể là số âm!", this.txtSLDN, 20, 20, 1500);
                return false;
            }

            if (getDouble(txtSLTX) < 0)
            {
                ToolTip1.Show("Số lượng thực xuất không thể là số âm!", this.txtSLTX, 20, 20, 1500);
                return false;
            }

            if (getDouble(txtSLTX) > getDouble(txtSL))
            {
                ToolTip1.Show("Bạn không thể xuất nhiều hơn số lượng vật tư có trong kho!", this.txtSLTX, 20, 20, 1500);
                return false;
            }

            return true;
        }

        private bool checkSoLuongHNGL()
        {
            //bool flag = true;

            if (getDouble(txtSLHN) < 0)
            {
                ToolTip1.Show("Số lượng hoàn nhập không thể là số âm!", this.txtSLHN, 20, 20, 1500);
                return false;
            }

            if (getDouble(txtSLGL) < 0)
            {
                ToolTip1.Show("Số lượng giữ lại không thể là số âm!", this.txtSLGL, 20, 20, 1500);
                return false;
            }

            return true;
        }

        private bool check_cbVT()
        {
            //bool flag = true;

            if (cbMaVatTu.Text == "" || cbTenVatTu.Text == "" || cbMaVatTu.SelectedIndex == -1 || cbTenVatTu.SelectedIndex == -1)
            {
                ToolTip1.Show("Bạn chưa chọn Vật Tư!", this.cbMaVatTu, 15, 15, 1500);
                return false;
            }

            if (cbChatLuong.Text == "" || cbChatLuong.SelectedIndex == -1)
            {
                ToolTip1.Show("Bạn chưa chọn Loại Chất Lượng!", this.cbChatLuong, 15, 15, 1500);
                return false;
            }

            return true;
        }

        private bool check_cbKho()
        {
            //bool flag = true;
            int ID_Kho = getIDKho();

            if (ID_Kho == -1)
            {
                ToolTip1.Show("Bạn chưa chọn kho xuất!", this.cbKhoXuat, 15, 15, 1500);
                return false;
            }

            if (ID_Kho == -2)
            {
                ToolTip1.Show("Bạn chưa chọn kho mượn!", this.cbMuonVTTaiKho, 15, 15, 1500);
                return false;
            }

            if (ID_Kho == -3)
            {
                ToolTip1.Show("Kho mượn và kho xuất không thể trùng nhau!", this.cbMuonVTTaiKho, 15, 15, 1500);
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Move to top later
            if (!((PanelButton.getClickStatus() == enumButton2.Them) || (PanelButton.getClickStatus() == enumButton2.Sua) || (PanelButton.getClickStatus() == enumButton2.BaoGiuLai) || (PanelButton.getClickStatus() == enumButton2.BaoHoanNhap)))
            {
                return;
            }

            if (chkboxXacNhanXuat.Checked == false)
            {
                if (check_cbKho() == false || check_cbVT() == false || checkSoLuongXuat() == false)
                {
                    return;
                }
            }
            else
            {
                if (checkSoLuongHNGL() == false)
                {
                    return;
                }
            }

            //Kiem tra row trùng lập, chưa giải quyết phần thiếu vật tư, xin thêm
            //---------- TEST
            //DataRow dr = dataTableChiTietPhieuXuatTam.NewRow();

            //dr["Ma_vat_tu"] = "17190010";
            //dr["Ten_vat_tu"] = "Thuốc hàn (Cadweld)";
            //dr["ID_kho"] = "0";
            //dr["Ten_kho"] = "Kho 1";
            //dr["So_luong"] = "20";
            //dr["So_luong_de_nghi"] = "10";
            //dr["So_luong_thuc_xuat"] = "10";
            //dr["Da_duyet_xuat_vat_tu"] = "true";
            //dr["So_luong_hoan_nhap"] = "0";
            //dr["So_luong_giu_lai"] = "0";
            //dr["Da_duyet_hoan_nhap_giu_lai"] = "false";
            //dr["So_luong_su_dung"] = "0";

            //dataTableChiTietPhieuXuatTam.Rows.Add(dr);
            //-------

            int ID_Kho = getIDKho();

            //Tạm thời vật tư a trong kho x ko dc add quá 2 lần. --> chưa giải quyết phần thiếu vật tư, xin thêm
            //data.Select(string.Format("Ma_vat_tu='{0}'", selectedRow.Cells["_Ma_vat_tu"].Value.ToString()));
            //DataRow[] chkMaVatTu = dataTableChiTietPhieuXuatTam.Select("Ma_vat_tu = \'" + cbMaVatTu.Text.Trim() + "\' AND ID_kho = \'" + ID_Kho + "\'");
            //DataRow[] chkMaVatTu = gridChiTietPhieuXuatTam.Select Select(string.Format("ID_kho = '{0}' AND Ma_vat_tu='{1}' AND Id_chat_luong = '{2}' AND Da_duyet_xuat_vat_tu='FALSE'", ID_Kho, cbMaVatTu.Text.Trim(), cbChatLuong.SelectedValue.ToString()));

            DataRow[] chkMaVatTu = dataTableChiTietPhieuXuatTam.Select(string.Format("ID_kho = '{0}' AND Ma_vat_tu='{1}' AND Id_chat_luong = '{2}' AND Da_duyet_xuat_vat_tu='FALSE'", ID_Kho, cbMaVatTu.Text.Trim(), cbChatLuong.SelectedValue.ToString()));
            

            if (chkMaVatTu.Length != 0)
            {
                //int index = dataTableChiTietPhieuXuatTam.Rows.IndexOf(chkMaVatTu[0]);
                //MessageBox.Show("Vật tư bạn chọn đã tồn tại! Bạn có thể sửa lại!"); //Ten_vat_tu
                DialogResult dialogResult = MessageBox.Show(string.Format("Vật tư mã = '{0}' đã tồn tại!\nBạn có muốn sửa lại không?", cbMaVatTu.Text), "Cảnh báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < gridChiTietPhieuXuatTam.Rows.Count; i++)
                    {
                        DataGridViewRow tmp_row = gridChiTietPhieuXuatTam.Rows[i];
                        if (Int32.Parse(tmp_row.Cells["_ID_kho"].Value.ToString()) == ID_Kho && tmp_row.Cells["_Ma_vat_tu"].Value.ToString() == cbMaVatTu.Text.Trim() && Int32.Parse(tmp_row.Cells["_Id_chat_luong"].Value.ToString()) == Int32.Parse(cbChatLuong.SelectedValue.ToString()) && bool.Parse(tmp_row.Cells["_Da_duyet_xuat_vat_tu"].Value.ToString()) == false)
                        {
                            //gridChiTietPhieuXuatTam.Rows[i].Selected = true;

                            //col = 1, row = i
                            gridChiTietPhieuXuatTam.CurrentCell = gridChiTietPhieuXuatTam[1,i];
                            ResetGridInputForm();
                            btnEdit_Click(btnEditRowInGrid, EventArgs.Empty);
                            break;
                        }
                        else
                        {
                            //gridChiTietPhieuXuatTam.Rows[i].Selected = false;
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                    ResetGridInputForm();
                }

                return;
            }

            DataRow dr = dataTableChiTietPhieuXuatTam.NewRow();
            dr["ID_chi_tiet_phieu_xuat_tam"] = curGridRow_ID;
            dr["Ma_vat_tu"] = cbMaVatTu.Text;
            dr["Ten_vat_tu"] = cbTenVatTu.Text;
            dr["ID_kho"] = ID_Kho;
            dr["Ten_kho"] = getTenKho();
            dr["Ten_don_vi_tinh"] = txtDVT.Text;
            dr["Id_chat_luong"] = Int32.Parse(cbChatLuong.SelectedValue.ToString());
            dr["Loai_chat_luong"] = cbChatLuong.Text;

            //Chưa setup func, và có lẽ ko cần thiết
            //dr["So_luong"] = "0";

            dr["So_luong_dang_giu"] = txtSLDangGiu.Text;
            dr["ID_No_vat_tu"] = curGridRow_ID_No_vat_tu;

            dr["So_luong_de_nghi"] = txtSLDN.Text;
            dr["So_luong_thuc_xuat"] = txtSLTX.Text;
            dr["Da_duyet_xuat_vat_tu"] = chkboxXacNhanXuat.Checked;

            //Chưa cho sửa
            dr["So_luong_hoan_nhap"] = txtSLHN.Text;
            dr["So_luong_giu_lai"] = txtSLGL.Text;
            dr["Da_duyet_hoan_nhap"] = chkboxXacNhanHoanNhap.Checked;
            dr["Da_duyet_giu_lai"] = chkboxXacNhanGiuLai.Checked;

            //not use
            //dr["So_luong_su_dung"] = "0";

            dataTableChiTietPhieuXuatTam.Rows.Add(dr);

            //if (Double.Parse(txtSLDangGiu.Text) > 0)
            //{
            //    init_cbMaVatTu();
            //    init_cbTenVatTu();
            //}

            ResetGridInputForm();

            //Khi đã add data của kho xuất rồi, thì đó là kho xuất chính, ko thể thay đổi nữa.
            //cbKhoXuat.Enabled = false;
            setup_cbKhoXuat();

            // gridMaster.SelectedRows.
        }

        Int32 curGridRow_Editing = -1;
        Int32 curGridRow_ID = -1;
        Int32 curGridRow_ID_No_vat_tu = -1;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataTableChiTietPhieuXuatTam.Rows.Count == 0)
            {
                ToolTip1.Show("Bạn cần thêm VT vào lưới trước khi chỉnh sửa!", this.btnAddToGrid, 15, 15, 2000);
                return;
            }

            //PanelButton.getClickStatus() == enumButton2.BaoGiuLai
            if (!((PanelButton.getClickStatus() == enumButton2.Them) || (PanelButton.getClickStatus() == enumButton2.Sua) || (PanelButton.getClickStatus() == enumButton2.BaoGiuLai) || (PanelButton.getClickStatus() == enumButton2.BaoHoanNhap) ))
                return;

            if (PanelButton.getClickStatus() == enumButton2.BaoGiuLai)
            {
                txtSLGL.Enabled = true;
                chkboxXacNhanGiuLai.Enabled = true;
            }

            if (PanelButton.getClickStatus() == enumButton2.BaoHoanNhap)
            {
                txtSLHN.Enabled = true;
                chkboxXacNhanHoanNhap.Enabled = true;
            }

            try
            {
                if (gridChiTietPhieuXuatTam.Rows.Count > 0)
                {
                    Int32 selectedRowCount = gridChiTietPhieuXuatTam.CurrentRow.Index;
                    DataGridViewRow selectedRow = gridChiTietPhieuXuatTam.Rows[selectedRowCount];

                    bool bXacNhanXuat = bool.Parse(selectedRow.Cells["_Da_duyet_xuat_vat_tu"].Value.ToString());
                    bool bXacNhanHoanNhap = bool.Parse(selectedRow.Cells["_Da_duyet_hoan_nhap"].Value.ToString());
                    bool bXacNhanGiuLai = bool.Parse(selectedRow.Cells["_Da_duyet_giu_lai"].Value.ToString());

                    //if (bXacNhanXuat && bXacNhanHoanNhap)
                    //{
                    //    MessageBox.Show("Bạn không thể sửa vật tư đã duyệt!");
                    //    return;
                    //}

                    if (bXacNhanXuat == true && PanelButton.getClickStatus() != enumButton2.BaoHoanNhap && PanelButton.getClickStatus() != enumButton2.BaoGiuLai)
                    {
                        MessageBox.Show("Bạn không thể sửa vật tư đã duyệt!");
                        return;
                    }

                    if (!(PanelButton.getClickStatus() == enumButton2.BaoGiuLai) || (PanelButton.getClickStatus() == enumButton2.BaoHoanNhap))
                    {
                        PanelButton.setGridClickEdit();
                    }

                    PanelButton.setGridClickEdit();

                    PanelButton.Enable_btn_Luu_Huy_Luoi();

                    curGridRow_Editing = selectedRowCount;
                    curGridRow_ID = Int32.Parse(selectedRow.Cells["_ID_chi_tiet_phieu_xuat_tam"].Value.ToString());
                    curGridRow_ID_No_vat_tu = Int32.Parse(selectedRow.Cells["_ID_No_vat_tu"].Value.ToString());

                    int ID_Kho = Int32.Parse(selectedRow.Cells["_ID_kho"].Value.ToString());

                    if (Int32.Parse(cbKhoXuat.SelectedValue.ToString()) != ID_Kho)
                    {
                        chkboxEnableMuonVT.Checked = true;
                        cbMuonVTTaiKho.SelectedValue = ID_Kho;
                        cbMuonVTTaiKho_SelectionChangeCommitted(cbMuonVTTaiKho, EventArgs.Empty);
                    }

                    Double sldg = Double.Parse(selectedRow.Cells["_So_luong_dang_giu"].Value.ToString());

                    if (sldg > 0)
                    {
                        init_cbMaVatTu_ALL();
                        init_cbTenVatTu_ALL();

                        DataTable data = (DataTable)cbMaVatTu.DataSource;
                        DataRow[] rows = data.Select(string.Format("Ma_vat_tu='{0}'", selectedRow.Cells["_Ma_vat_tu"].Value.ToString()));
                        cbMaVatTu.SelectedValue = Int32.Parse(rows[0]["ID_Vat_tu"].ToString()); //data.Select() //FindIndex(p => p.DisplayValue == "SomeValue");

                        this.cbMaVatTu_SelectionChangeCommitted((object)cbMaVatTu, EventArgs.Empty);
                    }
                    else
                    {
                        DataTable data = (DataTable)cbMaVatTu.DataSource;
                        DataRow[] rows = data.Select(string.Format("Ma_vat_tu='{0}'", selectedRow.Cells["_Ma_vat_tu"].Value.ToString()));
                        cbMaVatTu.SelectedValue = Int32.Parse(rows[0]["ID_Vat_tu"].ToString()); //data.Select() //FindIndex(p => p.DisplayValue == "SomeValue");

                        this.cbMaVatTu_SelectionChangeCommitted((object)cbMaVatTu, EventArgs.Empty);
                    }

                    


                    cbChatLuong.SelectedValue = Int32.Parse(selectedRow.Cells["_Id_chat_luong"].Value.ToString());
                    cbChatLuong_SelectionChangeCommitted(cbChatLuong, EventArgs.Empty);

                    txtSLDangGiu.Text = selectedRow.Cells["_So_luong_dang_giu"].Value.ToString();

                    txtSLDN.Text = selectedRow.Cells["_So_luong_de_nghi"].Value.ToString();
                    txtSLTX.Text = selectedRow.Cells["_So_luong_thuc_xuat"].Value.ToString();

                    

                    //txtSL.Text = selectedRow.Cells["_So_luong_de_nghi"].Value.ToString();

                    chkboxXacNhanXuat.Checked = bool.Parse(selectedRow.Cells["_Da_duyet_xuat_vat_tu"].Value.ToString());
                    //txtSL.Text = "-";

                    txtSLHN.Text = selectedRow.Cells["_So_luong_hoan_nhap"].Value.ToString();
                    txtSLGL.Text = selectedRow.Cells["_So_luong_giu_lai"].Value.ToString();
                    chkboxXacNhanGiuLai.Checked = bool.Parse(selectedRow.Cells["_Da_duyet_giu_lai"].Value.ToString());
                    chkboxXacNhanHoanNhap.Checked = bool.Parse(selectedRow.Cells["_Da_duyet_hoan_nhap"].Value.ToString());

                    if (PanelButton.getClickStatus() == enumButton2.BaoHoanNhap)
                    {
                        if (Double.Parse(txtSLGL.Text.ToString()) > 0)
                        {
                            txtSLHN.Text = txtSLHN.Text;
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!((PanelButton.getClickStatus() == enumButton2.Them) || (PanelButton.getClickStatus() == enumButton2.Sua)))
                    return;

                Int32 selectedRowCount = gridChiTietPhieuXuatTam.CurrentRow.Index; //CurrentCell.RowIndex;

                if (dataTableChiTietPhieuXuatTam.Rows.Count == 0 || selectedRowCount >= dataTableChiTietPhieuXuatTam.Rows.Count)
                    return;

                DataGridViewRow selectedRow = gridChiTietPhieuXuatTam.Rows[selectedRowCount];

                bool bXacNhanXuat = bool.Parse(selectedRow.Cells["_Da_duyet_xuat_vat_tu"].Value.ToString());
                //bool bXacNhanHoanNhapGiuLai = bool.Parse(selectedRow.Cells["_Da_duyet_hoan_nhap_giu_lai"].Value.ToString());
                //bool bXacNhanHoanNhap = bool.Parse(selectedRow.Cells["_Da_duyet_hoan_nhap"].Value.ToString());
                //bool bXacNhanGiuLai = bool.Parse(selectedRow.Cells["_Da_duyet_giu_lai"].Value.ToString());

                if (bXacNhanXuat)
                {
                    MessageBox.Show("Bạn không thể xóa vật tư đã duyệt!");
                    return;
                }

                string Ten_vat_tu = selectedRow.Cells["_Ten_vat_tu"].Value.ToString();


                DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xóa vật tư \'" + Ten_vat_tu + "\' này ra khỏi phiếu?", "Cảnh báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dataTableChiTietPhieuXuatTam.Rows.RemoveAt(selectedRowCount);

                    //if (dataTableChiTietPhieuXuatTam.Rows.Count == 0)
                    //    cbKhoXuat.Enabled = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            setup_cbKhoXuat();
        }

        private void btnSaveGrid_Click(object sender, EventArgs e)
        {
            try
            {
                dataTableChiTietPhieuXuatTam.Rows.RemoveAt(curGridRow_Editing);
                btnAdd_Click(this.btnAddToGrid, EventArgs.Empty);

                if (!PanelButton.isGridClickNone())
                {
                    PanelButton.ResetGridClickStatus();

                    PanelButton.ResetGridButton();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// txtSL: 
        /// [ ] Nếu ko mượn vt từ kho khác, luôn lấy SL từ kho xuất
        /// </summary>
        private void setInfoVatTu(string ID_Vat_tu)
        {
            clsDMVatTu vt = new clsDMVatTu();
            txtDVT.Text = vt.getDVT_from_IDVT(ID_Vat_tu);

            //txtSL.Text = "-";

            ////txtSL
            //string ID_Kho = "";

            //if (chkboxEnableMuonVT.Checked)
            //{
            //    ID_Kho = cbMuonVTTaiKho.SelectedValue.ToString();
            //}
            //else
            //{
            //    ID_Kho = cbKhoXuat.SelectedValue.ToString();
            //}
            
            //if (Int32.Parse(ID_Kho) >= 0)
            //{
            //    string Ma_vat_tu = vt.getMaVT_from_IDVT(ID_Vat_tu);

            //    //clsTonKho TonKho = new clsTonKho();
            //    //txtSL.Text = TonKho.getSL_from_MaVatTu(Ma_vat_tu, ID_Kho);
            //}
        }

        
        private  void setColorSL(bool flag)
        {
            if(flag || chkboxXacNhanXuat.Checked)
            {
                if (Int32.Parse(txtSL.Text.Trim().ToString()) > 0)
                {
                    this.txtSL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                    this.txtSL.ForeColor = System.Drawing.SystemColors.WindowText;
                    errorProvider1.SetError(txtSL, "");
                }
                else
                {
                    reset_txtSL();
                }
                
            }
            else
            {
                this.txtSL.ForeColor = System.Drawing.Color.Blue; 
                this.txtSL.BackColor = System.Drawing.Color.Red;
                errorProvider1.SetError(txtSL, "Vật tư này ko còn trong kho!");
            }
        }

        private void reset_txtSL()
        {
            txtSL.Text = "-";
            this.txtSL.BackColor = System.Drawing.SystemColors.Control;
            this.txtSL.ForeColor = System.Drawing.SystemColors.WindowText;
            errorProvider1.SetError(txtSL, "");
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            TextBox SoLuong = (TextBox)sender;

            Double sl;
            if (SoLuong.Text.Trim().ToString().Equals("-") || Double.TryParse(SoLuong.Text.Trim().ToString(), out sl) == false)
            {
                reset_txtSL();
                return;
            }

            //Double sl;
            if (chkboxXacNhanXuat.Checked == true && Double.TryParse(txtSL.Text.Trim().ToString(), out sl) == true)
            {
                reset_txtSL();
                return;
            }

            //Check ID Kho
            if (getIDKho() < 0)
            {
                reset_txtSL();
                return;
            }

            //Check VT
            if (cbMaVatTu.SelectedIndex == -1)
            {
                reset_txtSL();
                return;
            }

            //Check Chất Lượng
            if (cbChatLuong.SelectedIndex == -1)
            {
                reset_txtSL();
                return;
            }

            if (Double.Parse(SoLuong.Text.Trim().ToString()) > 0)
            {
                this.txtSL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                this.txtSL.ForeColor = System.Drawing.SystemColors.WindowText;
                errorProvider1.SetError(txtSL, "");
            }
            else
            {
                this.txtSL.ForeColor = System.Drawing.Color.Blue;
                this.txtSL.BackColor = System.Drawing.Color.Red;
                errorProvider1.SetError(txtSL, "Vật tư này ko còn trong kho!");
            }
        }

        private void setSLVatTu()
        {
            //txtSL.Text = "-";

            //chkboxXacNhanXuat == true
            Double sl;
            if (chkboxXacNhanXuat.Checked == true && Double.TryParse(txtSL.Text.Trim().ToString(), out sl) == true)
            {
                reset_txtSL();
                return;
            }

            //Check ID Kho
            int ID_kho = getIDKho();
            if (getIDKho() < 0)
            {
                reset_txtSL();
                return;
            }

            //Check VT
            if (cbMaVatTu.SelectedIndex == -1)
            {
                reset_txtSL();
                return;
            }

            //Check Chất Lượng
            if (cbChatLuong.SelectedIndex == -1)
            {
                reset_txtSL();
                return;
            }

            string Ma_vat_tu = cbMaVatTu.GetItemText(cbMaVatTu.SelectedItem); //cbMaVatTu.SelectedText.ToString(); //cbMaVatTu.Text.Trim().ToString();
            int Id_chat_luong = Int32.Parse(cbChatLuong.SelectedValue.ToString());

            clsTonKho TonKho = new clsTonKho();
            Double SL = TonKho.getSL(Ma_vat_tu, ID_kho, Id_chat_luong);

            txtSL.Text = SL.ToString();

        }


        private int getIDKho()
        {
            //Kiểm tra lỗi kho xuất trước
            if (cbKhoXuat.Text.Trim().Equals(string.Empty) || cbKhoXuat.SelectedIndex == -1)
            {
                //Chưa chọn kho xuất
                return -1;
            }
            else
            {
                //Kiểm tra trường hợp mượn vật tư
                if (chkboxEnableMuonVT.Checked == true)
                {
                    if (cbMuonVTTaiKho.Text.Trim().Equals(string.Empty) || cbMuonVTTaiKho.SelectedIndex == -1)
                    {
                        //Chưa chọn kho mượn
                        return -2;
                    }

                    if (Int32.Parse(cbMuonVTTaiKho.SelectedValue.ToString()) == Int32.Parse(cbKhoXuat.SelectedValue.ToString()))
                    {
                        //Kho mượn và kho xuất trùng nhau
                        return -3;
                    }

                    return Int32.Parse(cbMuonVTTaiKho.SelectedValue.ToString());
                }

                return Int32.Parse(cbKhoXuat.SelectedValue.ToString());
            }
            
        }

        /// <summary>
        /// Phụ thuộc hàm GetIDKho
        /// </summary>
        private string getTenKho()
        {
            if (getIDKho() < 0)
                return "";

            if (chkboxEnableMuonVT.Checked)
            {
                return cbMuonVTTaiKho.Text.ToString();
            }
            else
            {
                return cbKhoXuat.Text.ToString();
            }
        }


        private bool bDaDuyetPhieuXuat()
        {
            for (int i = 0; i < dataTableChiTietPhieuXuatTam.Rows.Count; i++)
            {
                DataGridViewRow selectedRow = gridChiTietPhieuXuatTam.Rows[i];

                bool bXacNhanXuat = bool.Parse(selectedRow.Cells["_Da_duyet_xuat_vat_tu"].Value.ToString());
                //bool bXacNhanHoanNhapGiuLai = bool.Parse(selectedRow.Cells["_Da_duyet_hoan_nhap_giu_lai"].Value.ToString());
                bool bXacNhanHoanNhap = bool.Parse(selectedRow.Cells["_Da_duyet_hoan_nhap"].Value.ToString());
                bool bXacNhanGiuLai = bool.Parse(selectedRow.Cells["_Da_duyet_giu_lai"].Value.ToString());


                if (bXacNhanXuat == false || bXacNhanHoanNhap == false || bXacNhanGiuLai == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void SetDataToForm()
        {
            clsPhieuXuatTamVatTu PhieuXuat = new clsPhieuXuatTamVatTu();

            DataTable dt = PhieuXuat.GetAll_byMaPhieu(cbMaPhieuXuatTam.Text.Trim());

            cbMaNhanVien.SelectedValue = Int32.Parse(dt.Rows[0]["ID_nhan_vien"].ToString());
            cbMaNhanVien_SelectionChangeCommitted(cbMaNhanVien, EventArgs.Empty);

            //dtNgayXuat.CustomFormat = "dd-MM-yyyy";
            dtNgayXuat.Value = Convert.ToDateTime(dt.Rows[0]["Ngay_xuat"].ToString());
            cbKhoXuat.SelectedValue = Int32.Parse(dt.Rows[0]["ID_kho"].ToString());
            cbKhoXuat_SelectionChangeCommitted(cbKhoXuat, EventArgs.Empty);
            txtLyDo.Text = dt.Rows[0]["Ly_do"].ToString();
            txtCongTrinh.Text = dt.Rows[0]["Cong_trinh"].ToString();
            txtDiaChi.Text = dt.Rows[0]["Dia_chi"].ToString();

        }

        private void setup_cbKhoXuat()
        {
            if (dataTableChiTietPhieuXuatTam.Rows.Count > 0)
            {
                cbKhoXuat.Enabled = false;
            }
            else
                cbKhoXuat.Enabled = true;
        }

        private void SetDataToGrid()
        {
            clsChiTietPhieuXuatTam ChitTietPhieuXuat = new clsChiTietPhieuXuatTam();
            DataTable dt = ChitTietPhieuXuat.getAll_toGrid(cbMaPhieuXuatTam.Text.Trim());

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dataTableChiTietPhieuXuatTam.NewRow();
                dr["ID_chi_tiet_phieu_xuat_tam"] = dt.Rows[i]["ID_chi_tiet_phieu_xuat_tam"];
                dr["Ma_vat_tu"] = dt.Rows[i]["Ma_vat_tu"];
                dr["Ten_vat_tu"] = dt.Rows[i]["Ten_vat_tu"];
                dr["Id_chat_luong"] = dt.Rows[i]["Id_chat_luong"];
                dr["Loai_chat_luong"] = dt.Rows[i]["Loai_chat_luong"];
                dr["ID_kho"] = dt.Rows[i]["ID_kho"];
                dr["Ten_kho"] = dt.Rows[i]["Ten_kho"];
                dr["ID_No_vat_tu"] = -1;
                dr["So_luong_dang_giu"] = dt.Rows[i]["So_luong_dang_giu"];
                dr["So_luong_de_nghi"] = dt.Rows[i]["So_luong_de_nghi"];
                dr["So_luong_thuc_xuat"] = dt.Rows[i]["So_luong_thuc_xuat"];
                dr["Da_duyet_xuat_vat_tu"] = dt.Rows[i]["Da_duyet_xuat_vat_tu"];
                dr["So_luong_hoan_nhap"] = dt.Rows[i]["So_luong_hoan_nhap"];
                dr["So_luong_giu_lai"] = dt.Rows[i]["So_luong_giu_lai"];
                dr["Da_duyet_hoan_nhap"] = dt.Rows[i]["Da_duyet_hoan_nhap"];
                dr["Da_duyet_giu_lai"] = dt.Rows[i]["Da_duyet_giu_lai"];
                dr["Ten_don_vi_tinh"] = dt.Rows[i]["Ten_don_vi_tinh"];
                dataTableChiTietPhieuXuatTam.Rows.Add(dr);
            }

            setup_cbKhoXuat();
        }

        //BEGIN-------------------------Phần Init txtBox-------
        private void initTextBox()
        {
            autoConfigFormControls.AddTextBox(ref txtSLDN);
            autoConfigFormControls.AddTextBox(ref txtSLTX);
            autoConfigFormControls.AddTextBox(ref txtSLHN);
            autoConfigFormControls.AddTextBox(ref txtSLGL);
        }
        //END-------------------------Phần Init txtBox-------


        //BEGIN-------------------------Phần Init cb-------
        private void init_cb()
        {
            init_cbMaPhieuXuatTam();

            init_cbMaNhanVien();
            init_cbTenNhanVien();

            init_cbKhoXuat();
            init_cbMuonVTTaiKho();

            init_cbMaVatTu();
            init_cbTenVatTu();

            init_cbChatLuong();
        }

        private void init_cbMaNhanVien()
        {
            cbMaNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMaNhanVien.AutoCompleteSource = AutoCompleteSource.CustomSource;

            clsDM_NhanVien nv = new clsDM_NhanVien();
            AutoCompleteStringCollection combData1 = nv.getListMaNhanVien();

            cbMaNhanVien.AutoCompleteCustomSource = combData1;

            cbMaNhanVien.DataSource = nv.getAll_Ma_Ten_NV();
            cbMaNhanVien.ValueMember = "ID_nhan_vien";
            cbMaNhanVien.DisplayMember = "Ma_nhan_vien";

            cbMaNhanVien.SelectedIndex = -1;
        }

        private void init_cbTenNhanVien()
        {
            cbTenNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTenNhanVien.AutoCompleteSource = AutoCompleteSource.CustomSource;

            clsDM_NhanVien nv = new clsDM_NhanVien();
            AutoCompleteStringCollection combData1 = nv.getListTenNhanVien();

            cbTenNhanVien.AutoCompleteCustomSource = combData1;

            cbTenNhanVien.DataSource = nv.getAll_Ma_Ten_NV();
            cbTenNhanVien.ValueMember = "ID_nhan_vien";
            cbTenNhanVien.DisplayMember = "Ten_nhan_vien";

            cbTenNhanVien.SelectedIndex = -1;
        }

        //Kho xuất, khi đã chọn vật tư từ kho, thì ko dc thay đổi nữa.
        private void init_cbKhoXuat()
        {
            clsDM_Kho DMKho = new clsDM_Kho();

            cbKhoXuat.DataSource = DMKho.getAll_TenKho();
            cbKhoXuat.ValueMember = "ID_kho";
            cbKhoXuat.DisplayMember = "Ten_kho";

            cbKhoXuat.SelectedIndex = -1;
        }

        /// <summary>
        /// Chia làm 2 hướng, init DS VT kho xuất chính, init theo DS VT theo kho mượn.
        /// </summary>
        private void init_cbMaVatTu()
        {
            int ID_Kho = getIDKho();
            if (ID_Kho < 0)
            {
                cbMaVatTu.DataSource = null;
                cbMaVatTu.AutoCompleteCustomSource = null;
                return;
            }

            cbMaVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMaVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;

            clsTonKho vt = new clsTonKho();
            AutoCompleteStringCollection combData1 = vt.getListMaVatTu(ID_Kho);

            cbMaVatTu.AutoCompleteCustomSource = combData1;

            cbMaVatTu.DataSource = vt.getAll_Ma_Ten_VatTu(ID_Kho);
            cbMaVatTu.ValueMember = "ID_Vat_tu";
            cbMaVatTu.DisplayMember = "Ma_vat_tu";

            cbMaVatTu.SelectedIndex = -1;
        }

        private void init_cbMaVatTu_ALL()
        {
            cbMaVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMaVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;

            clsDMVatTu vt = new clsDMVatTu();
            AutoCompleteStringCollection combData1 = vt.getListMaVatTu();

            cbMaVatTu.AutoCompleteCustomSource = combData1;

            cbMaVatTu.DataSource = vt.getAll_Ma_Ten_VatTu();
            cbMaVatTu.ValueMember = "ID_Vat_tu";
            cbMaVatTu.DisplayMember = "Ma_vat_tu";

            cbMaVatTu.SelectedIndex = -1;
        }

        /// <summary>
        /// Chia làm 2 hướng, init DS VT kho xuất chính, init theo DS VT theo kho mượn.
        /// </summary>
        //private int getID_cbMaVatTu()
        //{
        //    int ID_Kho = getIDKho();
        //    if (ID_Kho < 0)
        //    {
        //        cbMaVatTu.DataSource = null;
        //        cbMaVatTu.AutoCompleteCustomSource = null;
        //        return -1;
        //    }

        //    cbMaVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    cbMaVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;

        //    clsTonKho vt = new clsTonKho();
        //    AutoCompleteStringCollection combData1 = 

        //    cbMaVatTu.AutoCompleteCustomSource = combData1;

        //    cbMaVatTu.DataSource = vt.getAll_Ma_Ten_VatTu(ID_Kho);
        //    cbMaVatTu.ValueMember = "ID_Vat_tu";
        //    cbMaVatTu.DisplayMember = "Ma_vat_tu";

        //    cbMaVatTu.SelectedIndex = -1;
        //}

        private void init_cbTenVatTu()
        {
            int ID_Kho = getIDKho();
            if (ID_Kho < 0)
            {
                cbTenVatTu.DataSource = null;
                cbTenVatTu.AutoCompleteCustomSource = null;
                return;
            }

            cbTenVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTenVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;

            clsTonKho vt = new clsTonKho();

            AutoCompleteStringCollection combData1 = vt.getListTenVatTu(ID_Kho);

            cbTenVatTu.AutoCompleteCustomSource = combData1;

            cbTenVatTu.DataSource = vt.getAll_Ma_Ten_VatTu(ID_Kho);
            cbTenVatTu.ValueMember = "ID_Vat_tu";
            cbTenVatTu.DisplayMember = "Ten_vat_tu";

            cbTenVatTu.SelectedIndex = -1;
        }

        private void init_cbTenVatTu_ALL()
        {
            cbTenVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTenVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;

            clsDMVatTu vt = new clsDMVatTu();

            AutoCompleteStringCollection combData1 = vt.getListTenVatTu();

            cbTenVatTu.AutoCompleteCustomSource = combData1;

            cbTenVatTu.DataSource = vt.getAll_Ma_Ten_VatTu();
            cbTenVatTu.ValueMember = "ID_Vat_tu";
            cbTenVatTu.DisplayMember = "Ten_vat_tu";

            cbTenVatTu.SelectedIndex = -1;
        }

        private void init_cbChatLuong()
        {
            cbChatLuong.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbChatLuong.AutoCompleteSource = AutoCompleteSource.CustomSource;

            clsDMChatLuong ChatLuong = new clsDMChatLuong();
            AutoCompleteStringCollection combData1 = ChatLuong.getListLoaiChatLuong();

            cbChatLuong.AutoCompleteCustomSource = combData1;

            cbChatLuong.DataSource = ChatLuong.GetAllData();
            cbChatLuong.ValueMember = "Id_chat_luong";
            cbChatLuong.DisplayMember = "Loai_chat_luong";

            cbChatLuong.SelectedIndex = -1;
        }

        /// <summary>
        /// Kho mượn vt ko được trùng với kho xuất
        /// </summary>
        private void init_cbMuonVTTaiKho()
        {
            clsDM_Kho DMKho = new clsDM_Kho();

            cbMuonVTTaiKho.DataSource = DMKho.getAll_TenKho();
            cbMuonVTTaiKho.ValueMember = "ID_kho";
            cbMuonVTTaiKho.DisplayMember = "Ten_kho";

            cbMuonVTTaiKho.SelectedIndex = -1;
        }

        private void init_cbMaPhieuXuatTam()
        {
            cbMaPhieuXuatTam.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMaPhieuXuatTam.AutoCompleteSource = AutoCompleteSource.CustomSource;

            clsChiTietPhieuXuatTam PhieuXuat = new clsChiTietPhieuXuatTam();
            AutoCompleteStringCollection combData1 = PhieuXuat.getListMaPhieuXuatTam();

            cbMaPhieuXuatTam.AutoCompleteCustomSource = combData1;

            cbMaPhieuXuatTam.DataSource = PhieuXuat.getAll_Ma_Phieu();
            cbMaPhieuXuatTam.ValueMember = "ID_phieu_xuat_tam";
            cbMaPhieuXuatTam.DisplayMember = "Ma_phieu_xuat_tam";

            cbMaPhieuXuatTam.SelectedIndex = -1;
        }

        /// <summary>
        /// Handles the SelectionChangeCommitted event of the cbTenNhanVien control.
        /// </summary>
        private void cbTenNhanVien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if ((comboBox.SelectedIndex != -1) && (cbMaNhanVien.SelectedValue != comboBox.SelectedValue))
            {
                cbMaNhanVien.SelectedValue = comboBox.SelectedValue;
            }

            if ((comboBox.SelectedIndex != -1))
            {
                int ID_NV = Int32.Parse(comboBox.SelectedValue.ToString());

                clsPhieuXuatTamVatTu ctpxt = new clsPhieuXuatTamVatTu();

                if (ctpxt.chkNV_no_VT(ID_NV) == true)
                {
                    //MessageBox.Show("NV này còn nợ VT!");
                    btnCheckNVGiuVT.Visible = true;
                    ToolTip1.Show("Nhân viên này còn đang giữ vật tư!\nClick vào button để đưa danh sách VT còn đang nợ vào lưới!", this.btnCheckNVGiuVT, 15, 15, 5000);
                }
                else
                {
                    btnCheckNVGiuVT.Visible = false;
                }

            }
        }

        private void cbMaNhanVien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if ((comboBox.SelectedIndex != -1) && (cbTenNhanVien.SelectedValue != comboBox.SelectedValue))
            {
                cbTenNhanVien.SelectedValue = comboBox.SelectedValue;
            }
        }

        //Chưa dụng đến phần SL
        private void cbMuonVTTaiKho_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if (cbKhoXuat.SelectedValue.ToString() == comboBox.SelectedValue.ToString())
            {
                ToolTip1.Show("Kho xuất và kho mượn không thể trùng nhau", this.cbMuonVTTaiKho, 15, 15, 2000);
                comboBox.SelectedIndex = -1;
                init_cbMaVatTu();
                init_cbTenVatTu();
                return;
            }

            if ((comboBox.SelectedIndex > -1) && (cbKhoXuat.SelectedValue != comboBox.SelectedValue))
            {
                //setSLVatTu(comboBox.SelectedValue.ToString());
                setSLVatTu();
                init_cbMaVatTu();
                init_cbTenVatTu();
            }

        }

        private void cbMaVatTu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if ((comboBox.SelectedIndex > -1) && (cbTenVatTu.SelectedValue != comboBox.SelectedValue))
            {
                cbTenVatTu.SelectedValue = comboBox.SelectedValue;
                setInfoVatTu(comboBox.SelectedValue.ToString());
                setSLVatTu();
            }
        }

        private void cbTenVatTu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if ((comboBox.SelectedIndex > -1) && (cbMaVatTu.SelectedValue != comboBox.SelectedValue))
            {
                cbMaVatTu.SelectedValue = comboBox.SelectedValue;
                setInfoVatTu(comboBox.SelectedValue.ToString());
            }
        }

        private void cbKhoXuat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setSLVatTu();
            init_cbMaVatTu();
            init_cbTenVatTu();
        }

        //END-------------------------Phần Init cb-------

        /// <summary>
        /// Disable các control, dùng lúc mới load form
        /// </summary>
        private void DisableControl_ForNew()
        {
            //Enable để nhập mã phiếu và check tồn tại, tránh trường hợp trùng mã phiếu
            cbMaPhieuXuatTam.Enabled = true;
            btnCheckMaPhieuXuat.Enabled = true;
            //--------

            cbTenNhanVien.Enabled = false;
            cbMaNhanVien.Enabled = false;
            dtNgayXuat.Enabled = false;
            cbKhoXuat.Enabled = false;
            txtLyDo.Enabled = false;
            txtCongTrinh.Enabled = false;
            txtDiaChi.Enabled = false;

            //Khi bật, nếu đã thêm row vật tư từ kho khác, thì ko thể tắt
            chkboxEnableMuonVT.Enabled = false;

            //Chế độ mượn vật tư từ kho khác, tắt đến khi "chkboxEnableMuonVT" được bật
            cbMuonVTTaiKho.Enabled = false;

            //Control trên grid
            cbMaVatTu.Enabled = false;
            cbTenVatTu.Enabled = false;
            cbChatLuong.Enabled = false;

            //txtDVT, TxtSL (SL VT còn trong kho) mặc định luôn là ReadOnly, nên ko cần disable
            txtDVT.Enabled = true;
            //SL vật tư còn tồn trong kho, chỉ hoạt động khi chưa duyệt xuất vật tư.
            txtSL.Enabled = true;
            //-----------

            txtSLDN.Enabled = false;

            //SL Thực Xuất ko dc lớn hơn sl vt có trong kho
            txtSLTX.Enabled = false;
            chkboxXacNhanXuat.Enabled = false;

            //SL Giữ lại phải ít hơn hoặc bằng SL Đề nghị
            txtSLGL.Enabled = false;
            txtSLHN.Enabled = false;
            chkboxXacNhanGiuLai.Enabled = false;
            chkboxXacNhanHoanNhap.Enabled = false;

            btnAddToGrid.Enabled = false;
            btnDelRowInGrid.Enabled = false;
            btnEditRowInGrid.Enabled = false;

            btnSaveGrid.Enabled = false;
            btnCancel.Enabled = false;

            //Disable cả grid
            gridChiTietPhieuXuatTam.Enabled = false;

        }

        /// <summary>
        /// Enable các control, dùng lúc thêm mới
        /// </summary>
        private void EnableControl_ForNew()
        {
            //Enable để nhập mã phiếu và check tồn tại, tránh trường hợp trùng mã phiếu
            cbMaPhieuXuatTam.Enabled = false;
            btnCheckMaPhieuXuat.Enabled = true;
            //--------

            cbTenNhanVien.Enabled = true;
            cbMaNhanVien.Enabled = true;
            dtNgayXuat.Enabled = true;
            cbKhoXuat.Enabled = true;
            txtLyDo.Enabled = true;
            txtCongTrinh.Enabled = true;
            txtDiaChi.Enabled = true;

            //Khi bật, nếu đã thêm row vật tư từ kho khác, thì ko thể tắt
            chkboxEnableMuonVT.Enabled = true;

            //Chế độ mượn vật tư từ kho khác, tắt đến khi "chkboxEnableMuonVT" được bật
            cbMuonVTTaiKho.Enabled = false;

            //Control trên grid
            cbMaVatTu.Enabled = true;
            cbTenVatTu.Enabled = true;
            cbChatLuong.Enabled = true;

            //txtDVT, TxtSL (SL VT còn trong kho) mặc định luôn là ReadOnly, nên ko cần disable
            txtDVT.Enabled = true;
            //SL vật tư còn tồn trong kho, chỉ hoạt động khi chưa duyệt xuất vật tư.
            txtSL.Enabled = true;
            //-----------

            txtSLDN.Enabled = true;

            //SL Thực Xuất ko dc lớn hơn sl vt có trong kho
            txtSLTX.Enabled = true;
            chkboxXacNhanXuat.Enabled = true;

            //Khi thêm mới, ko xác nhận hoàn nhập
            txtSLGL.Enabled = false;
            txtSLHN.Enabled = false;
            chkboxXacNhanGiuLai.Enabled = false;
            chkboxXacNhanHoanNhap.Enabled = false;

            btnAddToGrid.Enabled = true;
            btnDelRowInGrid.Enabled = true;
            btnEditRowInGrid.Enabled = true;

            //btnSave dùng lưu thay đổi vào lưới
            btnSaveGrid.Enabled = false;
            btnCancel.Enabled = true;

            //Disable cả grid
            gridChiTietPhieuXuatTam.Enabled = true;

        }


        public void ResetInputForm()
        {
            init_cbMaPhieuXuatTam();
            cbMaPhieuXuatTam.Text = "";
            cbMaPhieuXuatTam.SelectedIndex = -1;

            cbTenNhanVien.SelectedIndex = -1;
            cbMaNhanVien.SelectedIndex = -1;
            dtNgayXuat.Value = dtNgayXuat.Value.Date;
            cbKhoXuat.SelectedIndex = -1;
            txtLyDo.Text = "";
            txtCongTrinh.Text = "";
            txtDiaChi.Text = "";

            ResetGridInputForm();
            dataTableChiTietPhieuXuatTam.Clear();
        }

        private void ResetGridInputForm()
        {
            //Move to top later
            if ((PanelButton.getClickStatus() == enumButton2.Them) || (PanelButton.getClickStatus() == enumButton2.Sua))
            {
                EnableGridInputForm();
            }
            

            curGridRow_ID = -1;
            curGridRow_ID_No_vat_tu = -1;
            cbMuonVTTaiKho.SelectedIndex = -1;
            cbMaVatTu.SelectedIndex = -1;
            cbTenVatTu.SelectedIndex = -1;
            cbChatLuong.SelectedIndex = -1;
            txtDVT.Text = "";
            chkboxEnableMuonVT.Checked = false;
            txtSL.Text = "-";

            chkInitCB();
            txtSLDangGiu.Text = "0";

            txtSLDN.Text = "0";
            txtSLTX.Text = "0";
            chkboxXacNhanXuat.Checked = false;

            txtSLGL.Text = "0";
            txtSLHN.Text = "0";
            chkboxXacNhanHoanNhap.Checked = false;
            chkboxXacNhanGiuLai.Checked = false;

            if (PanelButton.getClickStatus() == enumButton2.BaoGiuLai)
            {
                txtSLGL.Enabled = false;
                chkboxXacNhanGiuLai.Enabled = false;
            }

            if (PanelButton.getClickStatus() == enumButton2.BaoHoanNhap)
            {
                txtSLHN.Enabled = false;
                chkboxXacNhanHoanNhap.Enabled = false;
            }
        }

        private void EnableGridInputForm()
        {
            chkboxEnableMuonVT.Enabled = true;

            cbMaVatTu.Enabled = true;
            cbTenVatTu.Enabled = true;
            cbChatLuong.Enabled = true;

            //txtDVT, TxtSL (SL VT còn trong kho) mặc định luôn là ReadOnly, nên ko cần disable
            txtDVT.Enabled = true;
            //SL vật tư còn tồn trong kho, chỉ hoạt động khi chưa duyệt xuất vật tư.
            txtSL.Enabled = true;
            //-----------

            txtSLDN.Enabled = true;

            //SL Thực Xuất ko dc lớn hơn sl vt có trong kho
            txtSLTX.Enabled = true;
            chkboxXacNhanXuat.Enabled = true;

            //Khi thêm mới, ko xác nhận hoàn nhập
            txtSLGL.Enabled = false;
            txtSLHN.Enabled = false;
            chkboxXacNhanHoanNhap.Enabled = false;
            chkboxXacNhanGiuLai.Enabled = false;
        } 

        private void EnableGridInputForm_BaoGiuLai()
        {
            txtSLGL.Enabled = true;
            chkboxXacNhanGiuLai.Enabled = true;
        }

        public void CloseForm()
        {
            this.Close();
        }

        private double getDouble(TextBox txtBox)
        {
            double tmp;
            if (double.TryParse(txtBox.Text.Trim().ToString(), out tmp))
            {
                return tmp;
            }
            else
                return -1;
        }

        //--------------EVENT
        private void chkboxXacNhanXuat_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;

            if (chkBox.Checked == false)
            {
                return;
            }

            //if (getDouble(txtSLDN) == 0)
            //{
            //    ToolTip1.Show("SL đề nghị không thể bằng 0", this.chkboxXacNhanXuat, 15, 15, 1500);
            //    if (chkBox.Checked == true)
            //        chkBox.Checked = false;
            //    return;
            //}

            if (check_cbKho() == false || check_cbVT() == false || checkSoLuongXuat() == false)
            {
                //ToolTip1.Show("SL đề nghị không thể bằng 0", this.chkboxXacNhanXuat, 15, 15, 1500);
                if (chkBox.Checked == true)
                    chkBox.Checked = false;
                return;
            }

            if (chkBox.Checked)
            {
                txtSLDN.Enabled = false;
                txtSLTX.Enabled = false;

                cbMaVatTu.Enabled = false;
                cbTenVatTu.Enabled = false;
                cbChatLuong.Enabled = false;

                cbMuonVTTaiKho.Enabled = false;
                chkboxEnableMuonVT.Enabled = false;

                //txtSLHN.Enabled = true;
                //txtSLGL.Enabled = true;
                //chkboxXacNhanHoanNhapGiuLai.Enabled = true;

                chkboxXacNhanXuat.Enabled = false;
            }

            setSLVatTu();
        }

        /// <summary>
        /// Cần thêm ràng buột để mượn vật tư
        /// [ ] SL còn lại nhỏ hơn mức đề nghị --> enable mượn VT, hoặc visiable
        /// [ ] 
        /// </summary>
        private void chkboxEnableMuonVT_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;

            //Xử lý chưa chọn kho xuất
            if (cbKhoXuat.SelectedIndex < 0 && chkBox.Checked == true)
            {
                ToolTip1.Show("Bạn chưa chọn kho xuất!", this.chkboxEnableMuonVT, 15, 15, 2000);
                chkBox.Checked = false;
                return;
            }

            //Main
            if (chkBox.Checked)
            {
                cbKhoXuat.Enabled = false;
                cbMuonVTTaiKho.Enabled = true;
            }
            else
            {
                //if (dataTableChiTietPhieuXuatTam != null)
                //{
                //    if (dataTableChiTietPhieuXuatTam.Rows.Count == 0)
                //    {
                //        cbKhoXuat.Enabled = true;
                //    }
                //}

                setup_cbKhoXuat();
                cbMuonVTTaiKho.SelectedIndex = -1;
                cbMuonVTTaiKho.Enabled = false;
                init_cbMaVatTu();
                init_cbTenVatTu();
            }
        }


        /// <summary>
        /// Xử lý hiện SL của "loại VT_chất lượng"
        /// </summary>
        private void cbChatLuong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if ((comboBox.SelectedIndex != -1) && (cbMaVatTu.SelectedIndex != -1) && getIDKho() >= 0)
            {
                setSLVatTu();
            }
        }

        /// <summary>
        /// Trước mắt SL TX sẽ bằng SL DN
        /// </summary>
        private void txtSLDN_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtSLDN_TextChanged(object sender, EventArgs e)
        {
            TextBox txtSoLuongDeNghi = (TextBox)sender;
            double tmp;
            if (Double.TryParse(txtSoLuongDeNghi.Text, out tmp) == true)
            {
                //Nếu ko có giữ vt đó thì lấy bằng SL thực xuất
                //Nếu có nợ, thì lấy sldn - sl giữ
                txtSLTX.Text = (tmp - Double.Parse(txtSLDangGiu.Text)).ToString();

            }
        }

        /// <summary>
        /// Enable các control, dùng lúc Báo Giữ Lại
        /// </summary>
        private void EnableControl_For_BaoGiuLai()
        {
            //Enable để nhập mã phiếu và check tồn tại, tránh trường hợp trùng mã phiếu
            cbMaPhieuXuatTam.Enabled = false;
            btnCheckMaPhieuXuat.Enabled = false;
            //--------

            cbTenNhanVien.Enabled = false;
            cbMaNhanVien.Enabled = false;
            dtNgayXuat.Enabled = false;
            cbKhoXuat.Enabled = false;
            txtLyDo.Enabled = false;
            txtCongTrinh.Enabled = false;
            txtDiaChi.Enabled = false;

            //Khi bật, nếu đã thêm row vật tư từ kho khác, thì ko thể tắt
            chkboxEnableMuonVT.Enabled = false;

            //Chế độ mượn vật tư từ kho khác, tắt đến khi "chkboxEnableMuonVT" được bật
            cbMuonVTTaiKho.Enabled = false;

            //Control trên grid
            cbMaVatTu.Enabled = false;
            cbTenVatTu.Enabled = false;
            cbChatLuong.Enabled = false;

            //txtDVT, TxtSL (SL VT còn trong kho) mặc định luôn là ReadOnly, nên ko cần disable
            txtDVT.Enabled = true;
            //SL vật tư còn tồn trong kho, chỉ hoạt động khi chưa duyệt xuất vật tư.
            txtSL.Enabled = true;
            //-----------

            txtSLDN.Enabled = false;

            //SL Thực Xuất ko dc lớn hơn sl vt có trong kho
            txtSLTX.Enabled = false;
            chkboxXacNhanXuat.Enabled = false;

            //Khi thêm mới, ko xác nhận hoàn nhập
            txtSLGL.Enabled = false;
            txtSLHN.Enabled = false;
            chkboxXacNhanGiuLai.Enabled = false;
            chkboxXacNhanHoanNhap.Enabled = false;

            btnAddToGrid.Enabled = false;
            btnDelRowInGrid.Enabled = false;
            btnEditRowInGrid.Enabled = true;

            //btnSave dùng lưu thay đổi vào lưới
            btnSaveGrid.Enabled = false;
            btnCancel.Enabled = true;

            //Disable cả grid
            gridChiTietPhieuXuatTam.Enabled = true;

        }

        private void chkboxXacNhanGiuLai_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;

            if (chkBox.Checked == false)
            {
                return;
            }

            if (chkBox.Checked == true)
            {
                txtSLGL.Enabled = false;
                chkboxXacNhanGiuLai.Enabled = false;
            }
        }

        /// <summary>
        /// Enable các control, dùng lúc Báo Giữ Lại
        /// </summary>
        private void EnableControl_For_BaoHoanNhap()
        {
            //Enable để nhập mã phiếu và check tồn tại, tránh trường hợp trùng mã phiếu
            cbMaPhieuXuatTam.Enabled = false;
            btnCheckMaPhieuXuat.Enabled = false;
            //--------

            cbTenNhanVien.Enabled = false;
            cbMaNhanVien.Enabled = false;
            dtNgayXuat.Enabled = false;
            cbKhoXuat.Enabled = false;
            txtLyDo.Enabled = false;
            txtCongTrinh.Enabled = false;
            txtDiaChi.Enabled = false;

            //Khi bật, nếu đã thêm row vật tư từ kho khác, thì ko thể tắt
            chkboxEnableMuonVT.Enabled = false;

            //Chế độ mượn vật tư từ kho khác, tắt đến khi "chkboxEnableMuonVT" được bật
            cbMuonVTTaiKho.Enabled = false;

            //Control trên grid
            cbMaVatTu.Enabled = false;
            cbTenVatTu.Enabled = false;
            cbChatLuong.Enabled = false;

            //txtDVT, TxtSL (SL VT còn trong kho) mặc định luôn là ReadOnly, nên ko cần disable
            txtDVT.Enabled = true;
            //SL vật tư còn tồn trong kho, chỉ hoạt động khi chưa duyệt xuất vật tư.
            txtSL.Enabled = true;
            //-----------

            txtSLDN.Enabled = false;

            //SL Thực Xuất ko dc lớn hơn sl vt có trong kho
            txtSLTX.Enabled = false;
            chkboxXacNhanXuat.Enabled = false;

            //Khi thêm mới, ko xác nhận hoàn nhập
            txtSLGL.Enabled = false;
            txtSLHN.Enabled = false;
            chkboxXacNhanGiuLai.Enabled = false;
            chkboxXacNhanHoanNhap.Enabled = false;

            btnAddToGrid.Enabled = false;
            btnDelRowInGrid.Enabled = false;
            btnEditRowInGrid.Enabled = true;

            //btnSave dùng lưu thay đổi vào lưới
            btnSaveGrid.Enabled = false;
            btnCancel.Enabled = true;

            //Disable cả grid
            gridChiTietPhieuXuatTam.Enabled = true;

        }

        private void chkboxXacNhanHoanNhap_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;

            if (chkBox.Checked == false)
            {
                return;
            }

            if (chkBox.Checked == true)
            {
                chkboxXacNhanGiuLai.Checked = true;

                txtSLGL.Enabled = false;
                chkboxXacNhanGiuLai.Enabled = false;

                txtSLHN.Enabled = false;
                chkboxXacNhanHoanNhap.Enabled = false;
            }
        }

        /// <summary>
        /// Btn chỉ hiện nếu nv đó còn đang giữ vt, khi click vào thì thông báo nv còn giữ lại vt.
        /// Thực hiện Add những vt còn nợ vào grid
        /// </summary>
        private void btnCheckNVGiuVT_Click(object sender, EventArgs e)
        {
            //ToolTip1.Show("Nhân viên này còn đang giữ vật tư", this.cbTenNhanVien, 0, 0, 500);

            //clsChiTietPhieuXuatTam ChitTietPhieuXuat = new clsChiTietPhieuXuatTam();
            //DataTable dt = ChitTietPhieuXuat.getAll_toGrid(cbMaPhieuXuatTam.Text.Trim());

            int Ma_NV = Int32.Parse(cbTenNhanVien.SelectedValue.ToString());

            clsPhieuXuatTamVatTu pxt = new clsPhieuXuatTamVatTu();
            DataTable dt = pxt.GetAll_NV_no_VT(Ma_NV);

            //cbKhoXuat.SelectedValue = Int32.Parse(dt.Rows[0]["ID_kho"].ToString());
            //cbKhoXuat_SelectionChangeCommitted(cbKhoXuat, EventArgs.Empty);
            //GetAll_NV_no_VT(int ID_NV)

            DataTable dt2 = pxt.Get_NV_no_VT_IDKho(Ma_NV);

            int IDKho = Int32.Parse(dt2.Rows[0]["ID_kho"].ToString());
            string TenKho = dt2.Rows[0]["Ten_kho"].ToString();

            cbKhoXuat.SelectedValue = IDKho;
            cbKhoXuat_SelectionChangeCommitted(cbKhoXuat, EventArgs.Empty);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dataTableChiTietPhieuXuatTam.NewRow();
                dr["ID_chi_tiet_phieu_xuat_tam"] = -1;

                dr["Ma_vat_tu"] = dt.Rows[i]["Ma_vat_tu"];
                dr["Ten_vat_tu"] = dt.Rows[i]["Ten_vat_tu"];

                dr["Id_chat_luong"] = dt.Rows[i]["Id_chat_luong"];
                dr["Loai_chat_luong"] = dt.Rows[i]["Loai_chat_luong"];

                dr["ID_kho"] = IDKho;//dt.Rows[i]["ID_kho"];
                dr["Ten_kho"] = TenKho; //dt.Rows[i]["Ten_kho"];

                dr["ID_No_vat_tu"] = dt.Rows[i]["ID_No_vat_tu"];
                dr["So_luong_dang_giu"] = dt.Rows[i]["So_luong_giu_lai"];

                dr["So_luong_de_nghi"] = dt.Rows[i]["So_luong_giu_lai"]; 
                dr["So_luong_thuc_xuat"] = 0;

                dr["Da_duyet_xuat_vat_tu"] = true;
                dr["So_luong_hoan_nhap"] = 0;
                dr["So_luong_giu_lai"] = 0;
                dr["Da_duyet_hoan_nhap"] = false;
                dr["Da_duyet_giu_lai"] = false;
                dr["Ten_don_vi_tinh"] = dt.Rows[i]["Ten_don_vi_tinh"];

                dataTableChiTietPhieuXuatTam.Rows.Add(dr);
            }

            setup_cbKhoXuat();

            btnCheckNVGiuVT.Visible = false;
            cbMaNhanVien.Enabled = false;
            cbTenNhanVien.Enabled = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cbMaPhieuXuatTam.Text.Equals(string.Empty))
            {
                return;
            }

            clsChiTietPhieuXuatTam chitiet_pxt = new clsChiTietPhieuXuatTam();

            if (chitiet_pxt.isHasDuplicateRow(cbMaPhieuXuatTam.Text) == false)
            {
                return;
            }

            frmReport_phieu_xuat_tam_vat_tu frm = new frmReport_phieu_xuat_tam_vat_tu(cbMaPhieuXuatTam.Text);

            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == frm.Name)
                {
                    f.Activate();
                    return;
                }
            }

            frm.MdiParent = this.ParentForm;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void cbMaVatTu_KeyDown(object sender, KeyEventArgs e)
        {
            cbMaVatTu_SelectionChangeCommitted(sender, e);
        }

        private void cbTenVatTu_KeyDown(object sender, KeyEventArgs e)
        {
            cbTenVatTu_SelectionChangeCommitted(sender, e);
        }

        private void cbTenNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            cbTenNhanVien_SelectionChangeCommitted(sender, e);
        }

        private void cbMaNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            cbMaNhanVien_SelectionChangeCommitted(sender, e);
        }
    }
}