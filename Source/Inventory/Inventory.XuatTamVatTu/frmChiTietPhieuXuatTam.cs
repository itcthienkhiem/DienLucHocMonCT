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
namespace Inventory.XuatTamVatTu
{
    /// <summary>
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
    /// [ ] 
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
    /// </summary>
    public partial class frmChiTietPhieuXuatTam : Form
    {
        //------------ New --------------
        FormActionDelegate2 frmAction;
        clsPanelButton2 PanelButton;

        System.Windows.Forms.ToolTip ToolTip1;

        clsChiTietPhieuXuatTam PhieuXuat;

        public frmChiTietPhieuXuatTam()
        {
            InitializeComponent();

            PhieuXuat = new clsChiTietPhieuXuatTam();

            DisableControl_ForNew();

            initPanelButton();

            init_cb();

        }

        public void frmChiTietPhieuXuatTam_Load(object sender, EventArgs e)
        {
            ToolTip1 = new System.Windows.Forms.ToolTip();
            //ToolTip1.SetToolTip(this.btnCheckNVGiuVT, "Hello");
        }

        private void init_cb()
        {
            init_cbMaPhieuXuatTam();

            init_cbMaNhanVien();
            init_cbTenNhanVien();

            init_cbKhoXuat();
            init_cbMuonVTTaiKho();

            init_cbMaVatTu();
            init_cbTenVatTu();
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

            PanelButton.setButtonClickEvent(enumButton2.Dong);
            PanelButton.setButtonClickEvent(enumButton2.Huy);

            PanelButton.setButtonStatus(enumButton2.Xoa, false);
            PanelButton.setButtonStatus(enumButton2.Sua, false);
            PanelButton.setButtonStatus(enumButton2.LamMoi, false);

            btnXoa.Enabled = false;
            btnSua.Enabled = false;
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
                    break;
                case enumFormAction2.disableInputForm:
                    DisableControl_ForNew();
                    break;
                case enumFormAction2.Huy:
                    break;
                case enumFormAction2.Dong:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Btn chỉ hiện nếu nv đó còn đang giữ vt, khi click vào thì thông báo nv còn giữ lại vt.
        /// </summary>
        private void btnCheckNVGiuVT_Click(object sender, EventArgs e)
        {
            //ToolTip1.Show("Nhân viên này còn đang giữ vật tư", this.cbTenNhanVien, 0, 0, 500);
        }

        public void ResetInputForm()
        {
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
            cbMuonVTTaiKho.SelectedIndex = -1;
            cbMaVatTu.SelectedIndex = -1;
            cbTenVatTu.SelectedIndex = -1;
            txtDVT.Text = "";
            chkboxEnableMuonVT.Checked = false;
            txtSL.Text = "";

            txtSLDN.Text = "0";
            txtSLTX.Text = "0";
            chkboxXacNhanXuat.Checked = false;

            txtSLGL.Text = "0";
            txtSLHN.Text = "0";
            chkboxXacNhanHoanNhapGiuLai.Checked = false;
        }

        public void CloseForm()
        {
            this.Close();
        }

        /// <summary>
        /// btnThem:
        /// [ ] Check xem mã phiếu xuất hợp lệ chưa, có trùng ko? Nếu trùng thì bắt nhập cái khác.
        /// [ ] Nếu ổn, enable control cho nhập, cho phép lưu, hủy.
        /// </summary>
        private void btnThem_Click(object sender, EventArgs e)
        {
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
            chkboxXacNhanHoanNhapGiuLai.Enabled = false;

            btnAddToGrid.Enabled = false;
            btnDelRowInGrid.Enabled = false;
            btnEditRowInGrid.Enabled = false;
            btnSaveGrid.Enabled = false;

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
            chkboxXacNhanHoanNhapGiuLai.Enabled = false;

            btnAddToGrid.Enabled = true;
            btnDelRowInGrid.Enabled = true;
            btnEditRowInGrid.Enabled = true;
            btnSaveGrid.Enabled = true;

            //Disable cả grid
            gridChiTietPhieuXuatTam.Enabled = true;

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

        private void init_cbMaVatTu()
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

        private void init_cbTenVatTu()
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

        //Kho xuất, khi đã chọn vật tư từ kho, thì ko dc thay đổi nữa.
        private void init_cbKhoXuat()
        {
            //cbKhoXuat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbKhoXuat.AutoCompleteSource = AutoCompleteSource.CustomSource;

            clsDM_Kho DMKho = new clsDM_Kho();
            //AutoCompleteStringCollection combData1 = DMKho.getListMaPhieuXuatTam();

            //cbKhoXuat.AutoCompleteCustomSource = combData1;

            cbKhoXuat.DataSource = DMKho.getAll_TenKho();
            cbKhoXuat.ValueMember = "ID_kho";
            cbKhoXuat.DisplayMember = "Ten_kho";

            cbKhoXuat.SelectedIndex = -1;
        }

        /// <summary>
        /// Kho mượn vt ko được trùng với kho xuất
        /// </summary>
        private void init_cbMuonVTTaiKho()
        {
            //cbMuonVTTaiKho.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbMuonVTTaiKho.AutoCompleteSource = AutoCompleteSource.CustomSource;

            clsDM_Kho DMKho = new clsDM_Kho();
            //AutoCompleteStringCollection combData1 = DMKho.getListMaPhieuXuatTam();

            //cbMuonVTTaiKho.AutoCompleteCustomSource = combData1;

            cbMuonVTTaiKho.DataSource = DMKho.getAll_TenKho();
            cbMuonVTTaiKho.ValueMember = "ID_kho";
            cbMuonVTTaiKho.DisplayMember = "Ten_kho";

            cbMuonVTTaiKho.SelectedIndex = -1;
        }

        private void cbMaVatTu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if ((comboBox.SelectedIndex > -1) && (cbTenVatTu.SelectedValue != comboBox.SelectedValue))
            {
                cbTenVatTu.SelectedValue = comboBox.SelectedValue;
                setInfoVatTu(comboBox.SelectedValue.ToString());
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

        /// <summary>
        /// txtSL: 
        /// [ ] Nếu ko mượn vt từ kho khác, luôn lấy SL từ kho xuất
        /// </summary>
        /// <param name="ID_Vat_tu">The i d_ vat_tu.</param>
        private void setInfoVatTu(string ID_Vat_tu)
        {
            clsDMVatTu vt = new clsDMVatTu();
            txtDVT.Text = vt.getDVT_from_IDVT(ID_Vat_tu);

            txtSL.Text = "";

            //txtSL
            string ID_Kho = "";

            if (chkboxEnableMuonVT.Checked)
            {
                ID_Kho = cbMuonVTTaiKho.SelectedValue.ToString();
            }
            else
            {
                ID_Kho = cbKhoXuat.SelectedValue.ToString();
            }
            
            if (Int32.Parse(ID_Kho) >= 0)
            {
                string Ma_vat_tu = vt.getMaVT_from_IDVT(ID_Vat_tu);

                //clsTonKho TonKho = new clsTonKho();
                //txtSL.Text = TonKho.getSL_from_MaVatTu(Ma_vat_tu, ID_Kho);
            }
        }

        private void setSLVatTu(string ID_Kho)
        {
            txtSL.Text = "";

            if (!cbMaVatTu.Text.Equals(string.Empty))
            {
                //string ID_Kho = "";

                if (chkboxEnableMuonVT.Checked)
                {
                    ID_Kho = cbMuonVTTaiKho.SelectedValue.ToString();
                }
                else
                {
                    ID_Kho = cbKhoXuat.SelectedValue.ToString();
                }

                if (Int32.Parse(ID_Kho) >= 0)
                {
                    string Ma_vat_tu = cbMaVatTu.Text;

                    clsTonKho TonKho = new clsTonKho();
                    txtSL.Text = TonKho.getSL_from_MaVatTu(Ma_vat_tu, ID_Kho);
                }
            }
        }

        private void cbTenNhanVien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if ((comboBox.SelectedIndex != -1) && (cbMaNhanVien.SelectedValue != comboBox.SelectedValue))
            {
                cbMaNhanVien.SelectedValue = comboBox.SelectedValue;
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

            if ((comboBox.SelectedIndex > -1) && (cbKhoXuat.SelectedValue != comboBox.SelectedValue))
            {
                //setSLVatTu(comboBox.SelectedValue.ToString());
            }
            
        }

        /// <summary>
        /// Cần thêm ràng buột để mượn vật tư
        /// [ ] SL còn lại nhỏ hơn mức đề nghị --> enable mượn VT, hoặc visiable
        /// [ ] 
        /// </summary>
        private void chkboxEnableMuonVT_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;

            if (chkBox.Checked)
            {
                cbKhoXuat.Enabled = false;
                cbMuonVTTaiKho.Enabled = true;
            }
            else
            {
                if (dataTableChiTietPhieuXuatTam != null)
                {
                    if (dataTableChiTietPhieuXuatTam.Rows.Count == 0)
                    {
                        cbKhoXuat.Enabled = true;
                    }
                }
                cbMuonVTTaiKho.Enabled = false;
            }
        }


        private int getIDKho()
        {
            if (chkboxEnableMuonVT.Checked)
            {
                if (cbMuonVTTaiKho.Text.Trim().Equals(string.Empty))
                {
                    //Chưa chọn kho mượn
                    return -2;
                }
                else if (cbMuonVTTaiKho.SelectedValue == cbKhoXuat.SelectedValue)
                {
                    //Kho mượn và kho xuất trùng nhau
                    return -3;
                }
                else
                {
                    return Int32.Parse(cbMuonVTTaiKho.SelectedValue.ToString());
                }
            }
            else
            {
                if (cbKhoXuat.Text.Trim().Equals(string.Empty))
                {
                    //Chưa chọn kho xuất
                    return -1;
                }
                else
                {
                    return Int32.Parse(cbKhoXuat.SelectedValue.ToString());
                }
            }
        }

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (staTus == enumStatus.Sua || staTus == enumStatus.Them)
            //    sttaf = staTus;

            if ((int.Parse(txtSLDN.Text.Trim())) < 0 || (int.Parse(txtSLTX.Text.Trim())) < 0)
            {
                MessageBox.Show("Số lượng vật tư không thể là số âm!");
                return;
            }


            if (cbMaVatTu.Text == "" || cbTenVatTu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn tên Vật Tư!");
                return;
            }

            int ID_Kho = getIDKho();
            if (ID_Kho == -1)
            {
                MessageBox.Show("Bạn chưa chọn kho xuất!");
                return;
            }
            if (ID_Kho == -2)
            {
                MessageBox.Show("Bạn chưa chọn kho mượn!");
                return;
            }
            if (ID_Kho == -3)
            {
                MessageBox.Show("Kho mượn và kho xuất không thể trùng nhau");
                return;
            }


            //Move to top later
            if (!((PanelButton.getClickStatus() == enumButton2.Them) || (PanelButton.getClickStatus() == enumButton2.Sua)))
                return;

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

            //Tạm thời vật tư a trong kho x ko dc add quá 2 lần. --> chưa giải quyết phần thiếu vật tư, xin thêm
            DataRow[] chkMaVatTu = dataTableChiTietPhieuXuatTam.Select("Ma_vat_tu = \'" + cbMaVatTu.Text.Trim() + "\' AND ID_kho = \'" + ID_Kho + "\'");
            if (chkMaVatTu.Length != 0)
            {
                MessageBox.Show("Vật tư bạn chọn, đã tồn tại!");
                return;
            }


            DataRow dr = dataTableChiTietPhieuXuatTam.NewRow();
            dr["Ma_vat_tu"] = cbMaVatTu.Text;
            dr["Ten_vat_tu"] = cbTenVatTu.Text;
            dr["ID_kho"] = ID_Kho;
            dr["Ten_kho"] = getTenKho();
            dr["Ten_don_vi_tinh"] = txtDVT.Text;

            //Chưa setup func, và có lẽ ko cần thiết
            //dr["So_luong"] = "0";

            dr["So_luong_de_nghi"] = txtSLDN.Text;
            dr["So_luong_thuc_xuat"] = txtSLTX.Text;
            dr["Da_duyet_xuat_vat_tu"] = chkboxXacNhanXuat.Checked;

            //Chưa cho sửa
            dr["So_luong_hoan_nhap"] = txtSLHN.Text;
            dr["So_luong_giu_lai"] = txtSLGL.Text;
            dr["Da_duyet_hoan_nhap_giu_lai"] = chkboxXacNhanHoanNhapGiuLai.Checked;

            //not use
            dr["So_luong_su_dung"] = "0";

            dataTableChiTietPhieuXuatTam.Rows.Add(dr);
            ResetGridInputForm();

            //Khi đã add data của kho xuất rồi, thì đó là kho xuất chính, ko thể thay đổi nữa.
            cbKhoXuat.Enabled = false;

            // gridMaster.SelectedRows.
        }

        private void chkboxXacNhanXuat_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //setStatus(true);
            //staTus = enumStatus.SuaLuoi;

            if (!((PanelButton.getClickStatus() == enumButton2.Them) || (PanelButton.getClickStatus() == enumButton2.Sua)))
                return;

            if (dataTableChiTietPhieuXuatTam.Rows.Count == 0)
                return;

            try
            {
                //if (staTus == enumStatus.Sua || staTus == enumStatus.Them)
                //    sttaf = staTus;

                if (gridChiTietPhieuXuatTam.Rows.Count > 0)
                {
                    PanelButton.setClickStatus(enumButton2.SuaLuoi);

                    btnAddToGrid.Enabled = false;
                    btnEditRowInGrid.Enabled = false;
                    btnDelRowInGrid.Enabled = false;

                    //CurrentCell.RowIndex;
                    Int32 selectedRowCount = gridChiTietPhieuXuatTam.CurrentRow.Index;
                    DataGridViewRow selectedRow = gridChiTietPhieuXuatTam.Rows[selectedRowCount];

                    clsDMVatTu vt = new clsDMVatTu();
                    cbMaVatTu.SelectedValue = vt.getID_Ma_Vat_Tu(selectedRow.Cells["_Ma_vat_tu"].Value.ToString());
                    this.cbMaVatTu_SelectionChangeCommitted((object)cbMaVatTu, EventArgs.Empty);
                    //cbTenVatTu.SelectedValue = cbMaVatTu.SelectedValue;
                    //setInfoVatTu(cbMaVatTu.SelectedValue.ToString());


                    txtSLDN.Text = selectedRow.Cells["_So_luong_de_nghi"].Value.ToString();
                    txtSLTX.Text = selectedRow.Cells["_So_luong_thuc_xuat"].Value.ToString();

                    chkboxXacNhanXuat.Checked = bool.Parse(selectedRow.Cells["_Da_duyet_xuat_vat_tu"].Value.ToString());



                    //MessageBox.Show("DN: " + selectedRow.Cells["_So_luong_de_nghi"].Value.ToString() + " TX: " + selectedRow.Cells["_So_luong_thuc_xuat"].Value.ToString() + " chk: " + selectedRow.Cells["_Da_duyet_xuat_vat_tu"].Value.ToString());

                    //DataRow selectedRow = dataTableChiTietPhieuXuatTam.Rows[selectedRowCount];
                    //cbMaVatTu.SelectedValue = vt.getID_Ma_Vat_Tu(selectedRow["Ma_vat_tu"].ToString());

                    //MessageBox.Show(selectedRow.Cells["_Ma_vat_tu"].Value.ToString());

                    //MessageBox.Show(gridChiTietPhieuXuatTam.Columns[0].Name);


                    //txtSLHN.Text = selectedRow.Cells["So_luong_hoan_nhap"].Value.ToString();
                    //txtSLTX.Text = selectedRow.Cells["So_luong_thuc_xuat"].Value.ToString();

                    //txtSLGL.Text = selectedRow.Cells["So_luong_giu_lai"].Value.ToString();

                    //                txtSL.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_giu_lai"].Value.ToString();
                    //txtChatLuong.Text = gridMaster.Rows[selectedRowCount].Cells["Chat_luong"].Value.ToString();
                    //txtDVT.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value.ToString();


                    //cbMaVatTu_KeyDown(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //----------------------- Old
        //public frmChiTietPhieuXuatTam()
        //{
        //    InitializeComponent();
        //}

        Dictionary<string, clsDM_NhanVien> DicNhanVien = new Dictionary<string, clsDM_NhanVien>();
        Dictionary<string, clsDMVatTu> Dic = new Dictionary<string, clsDMVatTu>();

        //    Dictionary<string, clsDMVatTu> DicTen = new Dictionary<string, clsDMVatTu>();
        //  DataTable data = new DataTable();

        /* Khiem
        public frmChiTietPhieuXuatTam()
        {
            InitializeComponent();

            
            staTus = enumStatus.None;


             this.cbMaNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbMaNhanVien.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cbKhoXuat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbKhoXuat.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.cbMaVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbMaVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cbTenVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbTenVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            clsDM_Kho dmKho = new clsDM_Kho();
          //  cbKhoNhap.DisplayMember = "Ten_kho";
          //  cbKhoNhap.ValueMember = "ID_kho";
            Dic = GetDict((DataTable)new clsDMVatTu().GetAll());
            //    DicTen = GetDictTen(new clsDMVatTu().GetAll());

           // cbKhoNhap.DataSource = dmKho.GetAll();

            AutoCompleteStringCollection combData1 = new AutoCompleteStringCollection();
            AutoCompleteStringCollection combData2 = new AutoCompleteStringCollection();
            foreach (string key in Dic.Keys)
            {
                combData1.Add(Dic[key].Ma_vat_tu);
                combData2.Add(Dic[key].Ten_vat_tu);

            }


            cbMaVatTu.AutoCompleteCustomSource = combData1;
            cbMaVatTu.DataSource = combData1;
            cbTenVatTu.AutoCompleteCustomSource = combData2;
            cbTenVatTu.DataSource = combData2;
            cbMaVatTu.SelectedIndex = -1;
            cbTenVatTu.SelectedIndex = -1;
            clsDM_NhanVien dmnv = new clsDM_NhanVien();
           DataTable temp =(DataTable)  dmnv.GetAll();
           DicNhanVien = GetDictMaNhanVien(temp);
          //     AutoCompleteStringCollection combDataMa = new AutoCompleteStringCollection();
            AutoCompleteStringCollection combDataTen = new AutoCompleteStringCollection();
            foreach (string key in DicNhanVien.Keys)
            {
             //   combDataMa.Add(DicNhanVien[key].Ma_nhan_vien);
                combDataTen.Add(DicNhanVien[key].Ten_nhan_vien);

            }


        
            cbKhoXuat.AutoCompleteCustomSource = combDataTen;
            cbKhoXuat.DataSource = temp;
            cbKhoXuat.DisplayMember = "Ten_nhan_vien";
            cbKhoXuat.ValueMember = "ID_nhan_vien";

           // cbMaNhanVien.SelectedIndex = -1;
            cbKhoXuat.SelectedIndex = -1;
            // gridMaster.DataSource = data;
            
            
    }
    //End Khiem */

        public frmChiTietPhieuXuatTam(enumButton2 stt, string MaPhieuXuatTam)
        {
            InitializeComponent();
            staTus = enumStatus.None;


            this.cbMaNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbMaNhanVien.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cbKhoXuat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbKhoXuat.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.cbMaVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbMaVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cbTenVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbTenVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            clsDM_Kho dmKho = new clsDM_Kho();
            //  cbKhoNhap.DisplayMember = "Ten_kho";
            //  cbKhoNhap.ValueMember = "ID_kho";
            Dic = GetDict((DataTable)new clsDMVatTu().GetAll());
            //    DicTen = GetDictTen(new clsDMVatTu().GetAll());

            // cbKhoNhap.DataSource = dmKho.GetAll();

            AutoCompleteStringCollection combData1 = new AutoCompleteStringCollection();
            AutoCompleteStringCollection combData2 = new AutoCompleteStringCollection();
            foreach (string key in Dic.Keys)
            {
                combData1.Add(Dic[key].Ma_vat_tu);
                combData2.Add(Dic[key].Ten_vat_tu);

            }


            cbMaVatTu.AutoCompleteCustomSource = combData1;
            cbMaVatTu.DataSource = combData1;
            cbTenVatTu.AutoCompleteCustomSource = combData2;
            cbTenVatTu.DataSource = combData2;
            cbMaVatTu.SelectedIndex = -1;
            cbTenVatTu.SelectedIndex = -1;
            clsDM_NhanVien dmnv = new clsDM_NhanVien();
            DataTable temp =(DataTable) dmnv.GetAll();
            DicNhanVien = GetDictMaNhanVien(temp);
            //     AutoCompleteStringCollection combDataMa = new AutoCompleteStringCollection();
            AutoCompleteStringCollection combDataTen = new AutoCompleteStringCollection();
            foreach (string key in DicNhanVien.Keys)
            {
                //   combDataMa.Add(DicNhanVien[key].Ma_nhan_vien);
                combDataTen.Add(DicNhanVien[key].Ten_nhan_vien);

            }



            cbKhoXuat.AutoCompleteCustomSource = combDataTen;
            cbKhoXuat.DataSource = temp;
            cbKhoXuat.DisplayMember = "Ten_nhan_vien";
            cbKhoXuat.ValueMember = "ID_nhan_vien";

            // cbMaNhanVien.SelectedIndex = -1;
            cbKhoXuat.SelectedIndex = -1;
            // gridMaster.DataSource = data;
            //----------
            if (stt == enumButton2.Sua)
            {
                cbMaPhieuXuatTam.Text = MaPhieuXuatTam;

                btnSua_Click(this, EventArgs.Empty);
            }
            else if (stt == enumButton2.Them)
            {
                btnThem_Click(this, EventArgs.Empty);
            }
        }

        public frmChiTietPhieuXuatTam(enumStatus status, clsPhieuNhapKho phieunhap)
        {
            InitializeComponent();
            this.staTus = status;
            if (status == enumStatus.Sua || status == enumStatus.Xoa)
            {
                this.phieuNhapKho = phieunhap;
                DataTable chiTietPhieuNhap = (DataTable)new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieunhap.Ma_phieu_nhap);
                gridChiTietPhieuXuatTam.DataSource = chiTietPhieuNhap;
                //chitiet.get
            }
        }

        

        internal Dictionary<string, clsDM_NhanVien> GetDictMaNhanVien(DataTable dt)
        {
            var areas = new Dictionary<string, clsDM_NhanVien>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                areas.Add(dt.Rows[i]["Ma_nhan_vien"].ToString(), new clsDM_NhanVien(
                    int.Parse( dt.Rows[i]["ID_nhan_vien"].ToString()),
                     dt.Rows[i]["Ma_nhan_vien"].ToString(),
                      dt.Rows[i]["Ten_nhan_vien"].ToString(),
                 bool.Parse (dt.Rows[i]["Trang_thai"].ToString())
                       
                    ));
                //   dt.Rows[i]["ten_vat_tu"];
            }
            return areas;
        }

        internal Dictionary<string, clsDMVatTu> GetDict(DataTable dt)
        {
            var areas = new Dictionary<string, clsDMVatTu>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                areas.Add(dt.Rows[i]["Ma_vat_tu"].ToString(), new clsDMVatTu(

                     dt.Rows[i]["Ma_vat_tu"].ToString(),
                      dt.Rows[i]["ten_vat_tu"].ToString(),
                  (dt.Rows[i]["ten_don_vi_tinh"].ToString()),
                        dt.Rows[i]["Mo_ta"].ToString()
                        ,
                       //long.Parse(dt.Rows[i]["Don_gia"].ToString())
                      // ,
                       int.Parse(dt.Rows[i]["ID_Don_vi_tinh"].ToString())
                    ));

                //   dt.Rows[i]["ten_vat_tu"];

            }
            return areas;
        }

        

        enumStatus staTus = enumStatus.None;
        clsPhieuNhapKho phieuNhapKho = new clsPhieuNhapKho();
        private void ResetAll()
        {
            /*btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLamMoi.Enabled = true;
            btnLuu.Enabled = true;
            ResetText();
            btnCheckMaPhieuXuat.Enabled = true;
            setStatus(true);

            //   cbMaPhieuXuatTam.Text = "";
            txtDiaChi.Text = "";
            txtCongTrinh.Text = "";
            txtLyDo.Text = "";
            txtXuatTaiKho.Text = "";
            dataTableChiTietPhieuXuatTam.Rows.Clear();
            cbMaVatTu.Text = "";
            cbTenVatTu.Text = "";
            txtDVT.Text = "";
            txtSLGL.Text = "0";
            txtSLHN.Text = "0";
            txtSLTX.Text = "0";
            cbKhoXuat.Text = "";
            cbMaPhieuXuatTam.Text = "";
            txtDiaChi.Text = "";
            txtXuatTaiKho.Text = "";*/
        }

        public void setStatus(bool _status)
        {
            //  cbKhoNhap.Enabled = _status;
            //  cbMaPhieuXuatTam.Enabled = _status;

            /*dtNgayXuat.Enabled = _status;
            txtXuatTaiKho.Enabled = _status;
            txtLyDo.Enabled = _status;
            txtCongTrinh.Enabled = _status;
            txtDiaChi.Enabled = _status;
            cbMaVatTu.Enabled = _status;
            cbTenVatTu.Enabled = _status;
            txtSLHN.Enabled = _status;
            txtSLTX.Enabled = _status;
            txtSLGL.Enabled = _status;
            //txtChatLuong.Enabled = _status;
            btnAdd.Enabled = _status;
            btnEdit.Enabled = _status;
            btnSaveGrid.Enabled = _status;
            btnDel.Enabled = _status;*/

            //cbMaPhieuXuatTam.Enabled = _status;

        }
        public bool KiemTraVatTuGridVaTrongKho()
        {

            /*SQLDAL DAL = new SQLDAL();
            DAL.BeginTransaction();
            //DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieuNhap.ID_phieu_nhap);
            for (int i = 0; i < dataTableChiTietPhieuXuatTam.Rows.Count; i++)
            {
                clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                chitiet.Ma_phieu_xuat_tam = (cbMaPhieuXuatTam.Text);
                chitiet.Ma_vat_tu = (dataTableChiTietPhieuXuatTam.Rows[i]["Ma_vat_tu"].ToString());
               // chitiet.So_luong_de_nghi = int.Parse(dataTable1.Rows[i]["So_luong_yeu_cau"].ToString());
           //     chitiet.So_luong_thuc_xuat = int.Parse(dataTable1.Rows[i]["So_luong_thuc_xuat"].ToString());
                chitiet.So_luong_hoan_nhap = int.Parse(dataTableChiTietPhieuXuatTam.Rows[i]["So_luong_hoan_nhap"].ToString());
                chitiet.So_luong_giu_lai = int.Parse(dataTableChiTietPhieuXuatTam.Rows[i]["So_luong_giu_lai"].ToString());

                clsTonDauKy tdk = new clsTonDauKy();
                tdk.ID_kho = int.Parse(txtXuatTaiKho.Text);
                tdk.Ma_vat_tu = chitiet.Ma_vat_tu;
//tdk.So_luong = chitiet.So_luong_thuc_xuat;

                    if (tdk.CheckTonTaiSoDK())
                    {
                        DataTable tb = tdk.GetAllByKey(tdk.Ma_vat_tu);
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Vật tư này chưa có trong đầu kỳ! vui lòng nhập tồn đầu kỳ cho vật tư này!");
                            return false;
                        }
                     //   int? so_luong_kho = int.Parse(tb.Rows[0]["so_luong"].ToString()) - chitiet.So_luong_thuc_xuat;
                        //if (so_luong_kho < 0)
                        //{
                        //    MessageBox.Show("Vật tư này không đủ để xuất!");
                        //    return false;
                        //}
                        //tdk.So_luong = so_luong_kho;
                        //if (tdk.Update(DAL) == 0)
                        //{  
                        //    DAL.RollbackTransaction();
                        //    return;
                        //}
                    }
                }*/
            return true;
            }


//        private int GetIDNhanVien(string TenNV)
//        {
//            for(int i =0;i<DicNhanVien.Count;i++)
//            {
////                if(DicNhanVien.Ten_nhan_vien.Equals(TenNV);
////                    return DicNhanVien[i
//            }}

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnCheckMaPhieuXuat.Enabled = true;
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
            SQLDAL DAL = new SQLDAL();
            switch (staTus)
            {

                case enumStatus.Them:

                     
                      try
                      {
                        //con hang trong kho 

                          if (KiemTraVatTuGridVaTrongKho() == true)
                          {
                              clsPhieuXuatTamVatTu phieuxuat = new clsPhieuXuatTamVatTu();
                              phieuxuat.Ma_phieu_xuat_tam = cbMaPhieuXuatTam.Text;
                              if (!phieuxuat.CheckTonTaiSoDK())
                              {
                                  // phieunhap.
                                  phieuxuat.ID_kho = 1;

                                  phieuxuat.ID_Nhan_vien =int.Parse( cbKhoXuat.SelectedValue.ToString());//(DicNhanVien.Select[ cbMaNhanVien.Text].ID_nhan_vien);
                                  phieuxuat.Ly_do = txtLyDo.Text;
                                  phieuxuat.Ngay_xuat = dtNgayXuat.Value;
                                  phieuxuat.Cong_trinh = txtCongTrinh.Text;
                                  phieuxuat.Dia_chi = txtDiaChi.Text;
                                  
                                  if (phieuxuat.Insert(DAL) == 1)
                                  {
                                      try
                                      {
                                        //  DAL.BeginTransaction();
                                          for (int i = 0; i < dataTableChiTietPhieuXuatTam.Rows.Count; i++)
                                          {
                                              clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                                              chitiet.Ma_phieu_xuat_tam = (cbMaPhieuXuatTam.Text);
                                              chitiet.Ma_vat_tu = (dataTableChiTietPhieuXuatTam.Rows[i]["Ma_vat_tu"].ToString());
                                          //    chitiet.So_luong_de_nghi = int.Parse(dataTable1.Rows[i]["So_luong_yeu_cau"].ToString());
                                         //     chitiet.So_luong_thuc_xuat = int.Parse(dataTable1.Rows[i]["So_luong_thuc_xuat"].ToString());
                                              chitiet.So_luong_hoan_nhap = int.Parse(dataTableChiTietPhieuXuatTam.Rows[i]["So_luong_hoan_nhap"].ToString());
                                              chitiet.So_luong_giu_lai = int.Parse(dataTableChiTietPhieuXuatTam.Rows[i]["So_luong_giu_lai"].ToString());
                                           //   chitiet = txtCongTrinh
                                              if (chitiet.Insert(DAL) == 0)
                                              {


                                                  DAL.RollbackTransaction();
                                                  return;
                                              }
                                              clsTonDauKy tdk = new clsTonDauKy();
                                              DataTable temp = tdk.GetAllByKey(chitiet.Ma_vat_tu);
                                              tdk.Ma_vat_tu = chitiet.Ma_vat_tu;
                                              tdk.ID_kho = phieuxuat.ID_kho;
                                              //cap nhat lai so luong sau khi xuat
                                          //    tdk.So_luong = int.Parse( temp.Rows[0]["So_luong"].ToString()) - chitiet.So_luong_thuc_xuat;
                                              tdk.Update(DAL);

                                          }
                                      //    DAL.CommitTransaction();

                                      }
                                      catch (Exception ex)
                                      {
                                          DAL.RollbackTransaction();
                                      }

                                  }
                                  MessageBox.Show("Thêm thành công");
                                  staTus = enumStatus.None;
                                  setStatus(true);
                                  btnThem.Enabled = true;
                                  btnXoa.Enabled = true;
                                  btnSua.Enabled = true;
                                  btnLamMoi.Enabled = true;
                                  //ResetText();
                              }
                          }
                          break;

                      }
                      catch (Exception ex)
                      {

                          break;
                      }
            
            
                case enumStatus.Sua:
                    {
                       
                        DAL.BeginTransaction();
                        try
                        {
                            if (KiemTraVatTuGridVaTrongKho() == true)
                            {
                                clsPhieuXuatTamVatTu phieuxuat = new clsPhieuXuatTamVatTu();
                                phieuxuat.Ma_phieu_xuat_tam = cbMaPhieuXuatTam.Text;
                                if (phieuxuat.CheckTonTaiSoDK())
                                {
                                    // phieunhap.
                                    phieuxuat.ID_kho = 1;

                                    phieuxuat.ID_Nhan_vien = int.Parse(cbKhoXuat.SelectedValue.ToString());//(DicNhanVien.Select[ cbMaNhanVien.Text].ID_nhan_vien);
                                    phieuxuat.Ly_do = txtLyDo.Text;
                                    phieuxuat.Ngay_xuat = dtNgayXuat.Value;
                                    phieuxuat.Cong_trinh = txtCongTrinh.Text;
                                    phieuxuat.Dia_chi = txtDiaChi.Text;

                                    if (phieuxuat.Update(DAL) == 1)
                                    {
                                        try
                                        {
                                            //  DAL.BeginTransaction();

                                            for (int i = 0; i < tbAff.Rows.Count; i++)
                                            {
                                                clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                                                chitiet.Ma_phieu_xuat_tam = (cbMaPhieuXuatTam.Text);
                                                chitiet.Ma_vat_tu = (tbAff.Rows[i]["ma_vat_tu"].ToString());
                                        //        chitiet.So_luong_thuc_xuat = int.Parse(tbAff.Rows[i]["So_luong_thuc_xuat"].ToString());

                                                clsTonDauKy tdk = new clsTonDauKy();
                                                DataTable temp = tdk.GetAllByKey(chitiet.Ma_vat_tu);
                                                tdk.Ma_vat_tu = chitiet.Ma_vat_tu;
                                                tdk.ID_kho = phieuxuat.ID_kho;
                                            //    tdk.So_luong =int.Parse( temp.Rows[0]["So_luong"].ToString())+chitiet.So_luong_thuc_xuat;

                                                tdk.Update(DAL);
                                               //if (chitiet.Delete(DAL) == 0)
                                                    return;

                                            }
                                                for (int i = 0; i < dataTableChiTietPhieuXuatTam.Rows.Count; i++)
                                                {
                                                    clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                                                    chitiet.Ma_phieu_xuat_tam = (cbMaPhieuXuatTam.Text);
                                                    chitiet.Ma_vat_tu = (dataTableChiTietPhieuXuatTam.Rows[i]["Ma_vat_tu"].ToString());
                                                    //    chitiet.So_luong_de_nghi = int.Parse(dataTable1.Rows[i]["So_luong_yeu_cau"].ToString());
                                                 //   chitiet.So_luong_thuc_xuat = int.Parse(dataTable1.Rows[i]["So_luong_thuc_xuat"].ToString());
                                                    chitiet.So_luong_hoan_nhap = int.Parse(dataTableChiTietPhieuXuatTam.Rows[i]["So_luong_hoan_nhap"].ToString());
                                                    chitiet.So_luong_giu_lai = int.Parse(dataTableChiTietPhieuXuatTam.Rows[i]["So_luong_giu_lai"].ToString());
                                                    //   chitiet = txtCongTrinh
                                                    if (chitiet.Insert(DAL) == 0)
                                                    {


                                                        DAL.RollbackTransaction();
                                                        return;
                                                    }
                                                    clsTonDauKy tdk = new clsTonDauKy();
                                                    DataTable temp = tdk.GetAllByKey(chitiet.Ma_vat_tu);
                                                    tdk.Ma_vat_tu = chitiet.Ma_vat_tu;
                                                    tdk.ID_kho = phieuxuat.ID_kho;
                                                    //cap nhat lai so luong sau khi xuat
                                            //        tdk.So_luong = int.Parse(temp.Rows[0]["So_luong"].ToString()) - chitiet.So_luong_thuc_xuat+chitiet.So_luong_hoan_nhap;
                                                    tdk.Update(DAL);

                                                }
                                            //    DAL.CommitTransaction();

                                        }
                                        catch (Exception ex)
                                        {
                                            DAL.RollbackTransaction();
                                        }

                                    }
                                    MessageBox.Show("Chỉnh sữa thông tin thành công !");
                                    staTus = enumStatus.None;
                                    setStatus(true);
                                    btnThem.Enabled = true;
                                    btnXoa.Enabled = true;
                                    btnSua.Enabled = true;
                                    btnLamMoi.Enabled = true;
                                }



                                else
                                    DAL.RollbackTransaction();


                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            DAL.RollbackTransaction();
                        }
                        break;
                    }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetText();
            dataTableChiTietPhieuXuatTam.Clear();
            initEdit();
        }

        private bool initEdit()
        {
            /*
            clsPhieuXuatTamVatTu clsXuatTam = new clsPhieuXuatTamVatTu();
            clsXuatTam.Ma_phieu_xuat_tam = cbMaPhieuXuatTam.Text;
            if (clsXuatTam.CheckTonTaiSoDK() == true)
            {
                DataTable tb = clsXuatTam.GetAll(cbMaPhieuXuatTam.Text.Trim());
                // dtNgayNhap.Text = tb.Rows[0]["Ngay_nhap"].ToString();
                dtNgayXuat.Text = string.Format("{0:dd/MM/yyyy}", tb.Rows[0]["Ngay_xuat"]);
                cbKhoXuat.Text = tb.Rows[0]["Ten_nhan_vien"].ToString();
                txtLyDo.Text = tb.Rows[0]["Ly_do"].ToString();
                txtXuatTaiKho.Text = tb.Rows[0]["ID_kho"].ToString();
                txtCongTrinh.Text = tb.Rows[0]["cong_trinh"].ToString();
                txtDiaChi.Text = tb.Rows[0]["Dia_chi"].ToString();
                clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                DataTable vChiTiet = chitiet.GetAll(cbMaPhieuXuatTam.Text);
                for (int i = 0; i < vChiTiet.Rows.Count; i++)
                {
                    //  dataTable1.Rows[i]["Ma_phieu_nhap"] = vChiTiet.Rows[i]["ma_phieu_nhap"].ToString();


                    DataRow dr = dataTableChiTietPhieuXuatTam.NewRow();
                    //dr["Ma_vat_tu"] = vChiTiet.Rows[i]["ma_phieu_nhap"].ToString();
                    dr["ma_vat_tu"] = vChiTiet.Rows[i]["ma_vat_tu"].ToString();
                    dr["Ten_vat_tu"] = vChiTiet.Rows[i]["Ten_vat_tu"].ToString();
                    //  dr["don_vi_tinh"] = vChiTiet.Rows[i]["don_vi_tinh"].ToString() ;
                  //  dr["chat_luong"] = vChiTiet.Rows[i]["chat_luong"].ToString();
                    dr["so_luong_hoan_nhap"] = vChiTiet.Rows[i]["so_luong_hoan_nhap"].ToString();
                    dr["so_luong_giu_lai"] = vChiTiet.Rows[i]["so_luong_giu_lai"].ToString();

                    dr["so_luong_thuc_xuat"] = vChiTiet.Rows[i]["so_luong_thuc_xuat"].ToString();
                 //   dr["don_gia"] = vChiTiet.Rows[i]["don_gia"].ToString();
                   // dr["Thanh_tien"] = vChiTiet.Rows[i]["thanh_tien"].ToString();// int.Parse(vChiTiet.Rows[i]["don_gia"].ToString()) * int.Parse(vChiTiet.Rows[i]["so_luong_thuc_xuat"].ToString());
                    dr["Ten_Don_vi_tinh"] = vChiTiet.Rows[i]["ten_don_vi_tinh"].ToString();
                    dr["ID_Don_vi_tinh"] = vChiTiet.Rows[i]["ID_don_vi_tinh"].ToString();

                    dataTableChiTietPhieuXuatTam.Rows.Add(dr);
                }


                MessageBox.Show("Tồn tại mã phiếu nhập trong csdl");
                return true;
            }
            else
            {
                MessageBox.Show("Chưa Tồn tại mã phiếu nhập trong csdl");

            }*/
            return false;
        }

        private void gridMaster_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }
        }

        private void cbMaVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cbMaVatTu.DataSource = 

        }
        private void cbMaVatTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (staTus == enumStatus.SuaLuoi || staTus == enumStatus.XoaLuoi || (e!=null && e.KeyCode == Keys.Enter))
            {
                var val = Dic[cbMaVatTu.Text.Trim()];
                cbTenVatTu.Text = val.Ten_vat_tu.ToString();
                txtDVT.Text = val.ten_don_vi_tinh.ToString();

                //txtDonGia.Text = val.Don_gia.ToString();


            }

        }

        private void cbTenNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            //if (staTus == enumStatus.SuaLuoi || staTus == enumStatus.XoaLuoi || e.KeyCode == Keys.Enter)
            //{
            //    var val = Dic[cbMaVatTu.Text.Trim()];
            //    cbTenVatTu.Text = val.Ten_vat_tu.ToString();
            //    txtDVT.Text = val.ten_don_vi_tinh.ToString();

            //    txtDonGia.Text = val.Don_gia.ToString();


            //}

        }

        private void cbTenVatTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < Dic.Count; i++)
                {
                    if (Dic.ToList()[i].Value.Ten_vat_tu.Equals(cbTenVatTu.Text))

                    // == cbTenVatTu.Text.Trim())
                    {
                        var val = Dic.ToList()[i].Value;
                        cbMaVatTu.Text = val.Ma_vat_tu.ToString();
                        txtDVT.Text = val.ten_don_vi_tinh.ToString();
                        //txtDonGia.Text = val.Don_gia.ToString();
                    }
                }
            }
        }

        enumStatus sttaf;

        
        private void ResetText()
        {
            cbMaVatTu.Text = "";
            cbTenVatTu.Text = "";
            txtDVT.Text = "";
            //txtChatLuong.Text = "";
            txtSLTX.Text = "0";
            txtSLHN.Text = "0";
          //  txtDonGia.Text = "0";

            //            txtChatLuong.Text = "";

        }
        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLKhoDienLucDataSet.DM_Vat_Tu' table. You can move, or remove it, as needed.
            //     this.dM_Vat_TuTableAdapter.Fill(this.qLKhoDienLucDataSet.DM_Vat_Tu);

        }

        

        private void gridMaster_MouseClick(object sender, MouseEventArgs e)
        {
            if (staTus == enumStatus.SuaLuoi || staTus == enumStatus.XoaLuoi)
            {
                Int32 selectedRowCount = gridChiTietPhieuXuatTam.CurrentCell.RowIndex;
                cbMaVatTu.Text = (gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
                if (cbMaVatTu.Text != "")
                {
                    cbMaVatTu_KeyDown(null, null);
                }
                else
                    ResetText();
            }
        }

        private void btnSaveGrid_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 selectedRowCount = gridChiTietPhieuXuatTam.CurrentCell.RowIndex;

                if (dataTableChiTietPhieuXuatTam.Rows.Count == 0 || selectedRowCount >= dataTableChiTietPhieuXuatTam.Rows.Count)
                    return;
                if (staTus == enumStatus.SuaLuoi)
                {
                    gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ma_vat_tu"].Value = cbMaVatTu.Text;
                    gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ten_vat_tu"].Value = cbTenVatTu.Text;
                    gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value = txtDVT.Text;
                  //  gridMaster.Rows[selectedRowCount].Cells["chat_luong"].Value = txtChatLuong.Text;
                    gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["so_luong_hoan_nhap"].Value = txtSLHN.Text;
                    gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["so_luong_thuc_xuat"].Value = txtSLTX.Text;
                    gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["so_luong_giu_lai"].Value = txtSLGL.Text;
              //      gridMaster.Rows[selectedRowCount].Cells["don_gia"].Value = txtDonGia.Text;
                    gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ID_don_vi_tinh"].Value = Dic[cbMaVatTu.Text].ID_Don_vi_tinh;

                    staTus = sttaf;
                }
                if (staTus == enumStatus.XoaLuoi)
                {
                    dataTableChiTietPhieuXuatTam.Rows.RemoveAt(selectedRowCount);
                    cbMaVatTu.Text = "";
                    cbTenVatTu.Text = "";
                    txtDVT.Text = "";
                    txtSLGL.Text = "0";
                    txtSLHN.Text = "0";
                    txtSLTX.Text = "0";
                    staTus = sttaf;
                }
                setStatus(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            staTus = sttaf;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            btnAddToGrid.Enabled = true;
            btnEditRowInGrid.Enabled = true;
            ResetText();
            staTus = enumStatus.None;
        }

        private void cbMaPhieuXuatTam_Enter(object sender, EventArgs e)
        {

        }

        DataTable tbAff;


        private void btnSua_Click(object sender, EventArgs e)
        {
            tbAff = dataTableChiTietPhieuXuatTam.Copy();
            setStatus(true);
            dataTableChiTietPhieuXuatTam.Clear();
            if (cbMaPhieuXuatTam.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã phiếu nhập!");
                return;
            }
            if (initEdit() == true)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                staTus = enumStatus.Sua;
                setStatus(true);
                cbMaPhieuXuatTam.Enabled = false;
                //  btnEdit_Click(null, null);
            }

            tbAff = dataTableChiTietPhieuXuatTam.Copy();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sttaf = staTus;

            try
            {
                Int32 selectedRowCount = gridChiTietPhieuXuatTam.CurrentCell.RowIndex;

                //string ma_vat_tu = dataTable1.Rows[
                if (dataTableChiTietPhieuXuatTam.Rows.Count == 0 || selectedRowCount >= dataTableChiTietPhieuXuatTam.Rows.Count)
                    return;
                staTus = enumStatus.XoaLuoi;
                btnDelRowInGrid.Enabled = false;
                btnAddToGrid.Enabled = false;
                btnEditRowInGrid.Enabled = false;
                cbMaVatTu.Text = (gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
                txtSLHN.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_hoan_nhap"].Value.ToString();
                txtSLTX.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_thuc_xuat"].Value.ToString();
                txtSLGL.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_giu_lai"].Value.ToString();
                //txtChatLuong.Text = gridMaster.Rows[selectedRowCount].Cells["Chat_luong"].Value.ToString();
                txtDVT.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value.ToString();


                cbMaVatTu_KeyDown(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (staTus == enumStatus.Sua || staTus == enumStatus.Them)
                sttaf = staTus;

            try
            {
                Int32 selectedRowCount = gridChiTietPhieuXuatTam.CurrentCell.RowIndex;

                //string ma_vat_tu = dataTable1.Rows[
                if (dataTableChiTietPhieuXuatTam.Rows.Count == 0 || selectedRowCount >= dataTableChiTietPhieuXuatTam.Rows.Count)
                    return;
                //staTus = enumStatus.XoaLuoi;
              //  PanelButton.setClickStatus(enumButton2.XoaLuoi);
                btnDelRowInGrid.Enabled = false;
                btnAddToGrid.Enabled = false;
                btnEditRowInGrid.Enabled = false;
                cbMaVatTu.Text = (gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
                txtSLGL.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_giu_lai"].Value.ToString();
                txtSLTX.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_thuc_xuat"].Value.ToString();
                txtSLHN.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_hoan_nhap"].Value.ToString();
                txtDVT.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value.ToString();
                cbTenVatTu.Text = (gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ten_vat_tu"].Value.ToString());
                staTus = enumStatus.XoaLuoi;
                cbMaVatTu_KeyDown(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool setFormData_By_MaPhieuNhap(string Ma_Phieu_Nhap)
        {
            clsPhieuNhapKho PhieuNhap = new clsPhieuNhapKho();

            if (PhieuNhap.CheckTonTaiSoDK(Ma_Phieu_Nhap))
            {
                //fill vào FRM
                DataTable tb = PhieuNhap.GetAll(Ma_Phieu_Nhap);

                cbMaPhieuXuatTam.Text = tb.Rows[0]["ma_phieu_xuat_tam"].ToString();
               // txtMaPhieuNhap.Text = Ma_Phieu_Nhap;
                dtNgayXuat.Text = string.Format("{0:dd/MM/yyyy}", tb.Rows[0]["Ngay_xuat"]);
                cbKhoXuat.Text = tb.Rows[0]["ten_nhan_vien"].ToString();
                txtLyDo.Text = tb.Rows[0]["Ly_do"].ToString();
                txtCongTrinh.Text = tb.Rows[0]["cong_trinh"].ToString();
                txtDiaChi.Text = tb.Rows[0]["dia_chi"].ToString();
             //   txtDiaChi.Text = tb.Rows[0]["Dia_chi"].ToString();

                //Fill vào grid
                //DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(Ma_Phieu_Nhap);

                //dataTable1 = chiTietPhieuNhap;
                //gridMaster.DataSource = dataTable1;


                //clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();

                DataTable vChiTiet = (DataTable)new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(Ma_Phieu_Nhap);

                for (int i = 0; i < vChiTiet.Rows.Count; i++)
                {
                    DataRow dr = dataTableChiTietPhieuXuatTam.NewRow();

                    dr["ma_vat_tu"] = vChiTiet.Rows[i]["ma_vat_tu"].ToString();
                    dr["Ten_vat_tu"] = vChiTiet.Rows[i]["Ten_vat_tu"].ToString();
                    dr["Ten_Don_vi_tinh"] = vChiTiet.Rows[i]["ten_don_vi_tinh"].ToString();
                    dr["ID_Don_vi_tinh"] = vChiTiet.Rows[i]["ID_don_vi_tinh"].ToString();
                    dr["chat_luong"] = vChiTiet.Rows[i]["chat_luong"].ToString();
                    dr["so_luong_giu_lai"] = vChiTiet.Rows[i]["so_luong_giu_lai"].ToString();
                    dr["so_luong_thuc_xuat"] = vChiTiet.Rows[i]["so_luong_thuc_lanh"].ToString();
                    dr["don_gia"] = vChiTiet.Rows[i]["don_gia"].ToString();
                    dr["Thanh_tien"] = vChiTiet.Rows[i]["thanh_tien"].ToString(); // int.Parse(vChiTiet.Rows[i]["don_gia"].ToString()) * int.Parse(vChiTiet.Rows[i]["so_luong_thuc_xuat"].ToString());

                    dataTableChiTietPhieuXuatTam.Rows.Add(dr);
                }
                return true;
            }
            else
                return false;
        }

        private void cbMaPhieuXuatTam_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        

        private void cbLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetText();
            ResetAll();
            staTus = enumStatus.None;

        }

        
    }
}