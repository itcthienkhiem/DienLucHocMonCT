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
    /// 
    /// ToolTip1.Show("Nhân viên này còn đang giữ vật tư", this.cbTenNhanVien, 15, 15, 1500);
    /// </summary>
    public partial class frmChiTietPhieuXuatTam : Form
    {
        //------------ New --------------
        FormActionDelegate2 frmAction;
        clsPanelButton2 PanelButton;

        System.Windows.Forms.ToolTip ToolTip1;

        clsChiTietPhieuXuatTam PhieuXuat;

        private System.Windows.Forms.ErrorProvider errorProvider1;

        public frmChiTietPhieuXuatTam()
        {
            InitializeComponent();

            ToolTip1 = new System.Windows.Forms.ToolTip();
            errorProvider1 = new ErrorProvider();

            initPanelButton();

            init_cb();

            PhieuXuat = new clsChiTietPhieuXuatTam();

            DisableControl_ForNew();

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
            ToolTip1.Show(cbChatLuong.SelectedIndex.ToString(), this.cbChatLuong, 0, 0, 2000);
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
                    break;
                case enumFormAction2.disableInputForm:
                    DisableControl_ForNew();
                    break;
                case enumFormAction2.Huy:
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

        /// <summary>
        /// Btn chỉ hiện nếu nv đó còn đang giữ vt, khi click vào thì thông báo nv còn giữ lại vt.
        /// </summary>
        private void btnCheckNVGiuVT_Click(object sender, EventArgs e)
        {
            //ToolTip1.Show("Nhân viên này còn đang giữ vật tư", this.cbTenNhanVien, 0, 0, 500);
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

                        if (phieuxuat.Insert_PhieuXuat() == 1)
                        {
                            try
                            {
                                clsChiTietPhieuXuatTam ChiTietPhieuXuat = new clsChiTietPhieuXuatTam();
                                if (ChiTietPhieuXuat.CapNhapChiTietPhieuXuat(dataTableChiTietPhieuXuatTam, phieuxuat.Ma_phieu_xuat_tam) == 1)
                                {
                                    MessageBox.Show("Bạn đã thêm thành công!");

                                    PanelButton.ResetClickStatus();
                                    PanelButton.ResetGridClickStatus();

                                    PanelButton.ResetButton();

                                    init_cbMaPhieuXuatTam();

                                    ResetInputForm();
                                    DisableControl_ForNew();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
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

                            if (phieuxuat.Update_PhieuXuat() == 1)
                            {
                                try
                                {
                                    clsChiTietPhieuXuatTam ChiTietPhieuXuat = new clsChiTietPhieuXuatTam();
                                    if (ChiTietPhieuXuat.CapNhapChiTietPhieuXuat(dataTableChiTietPhieuXuatTam, phieuxuat.Ma_phieu_xuat_tam) == 1)
                                    {
                                        MessageBox.Show("Bạn đã sửa thành công!");

                                        PanelButton.ResetClickStatus();
                                        PanelButton.ResetGridClickStatus();

                                        PanelButton.ResetButton();

                                        init_cbMaPhieuXuatTam();

                                        ResetInputForm();
                                        DisableControl_ForNew();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        break;
                    }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if ((int.Parse(txtSLDN.Text.Trim())) <= 0)
            {
                //MessageBox.Show("Số lượng vật tư không thể là số âm!");
                ToolTip1.Show("Số lượng đề nghị không thể bằng 0!", this.txtSLDN, 20, 20, 1500);
                return;
            }

            if ((int.Parse(txtSLDN.Text.Trim())) < 0 || (int.Parse(txtSLTX.Text.Trim())) < 0)
            {
                //MessageBox.Show("Số lượng vật tư không thể là số âm!");
                ToolTip1.Show("Số lượng vật tư không thể là số âm!", this.txtSLDN, 20, 20, 1500);
                return;
            }

            if ((int.Parse(txtSLHN.Text.Trim())) < 0 || (int.Parse(txtSLGL.Text.Trim())) < 0)
            {
                //MessageBox.Show("Số lượng vật tư không thể là số âm!");
                ToolTip1.Show("Số lượng vật tư không thể là số âm!", this.txtSLGL, 20, 20, 1500);
                return;
            }


            if (cbMaVatTu.Text == "" || cbTenVatTu.Text == "" || cbMaVatTu.SelectedIndex == -1 || cbTenVatTu.SelectedIndex == -1)
            {
                //MessageBox.Show("Bạn chưa chọn Vật Tư!");
                ToolTip1.Show("Bạn chưa chọn Vật Tư!", this.cbMaVatTu, 15, 15, 1500);
                return;
            }

            if (cbChatLuong.Text == "" || cbChatLuong.SelectedIndex == -1)
            {
                //MessageBox.Show("Bạn chưa chọn Vật Tư!");
                ToolTip1.Show("Bạn chưa chọn Loại Chất Lượng!", this.cbChatLuong, 15, 15, 1500);
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
            dr["Id_chat_luong"] = Int32.Parse(cbChatLuong.SelectedValue.ToString());
            dr["Loai_chat_luong"] = cbChatLuong.Text;

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
            //dr["So_luong_su_dung"] = "0";

            dataTableChiTietPhieuXuatTam.Rows.Add(dr);
            ResetGridInputForm();

            //Khi đã add data của kho xuất rồi, thì đó là kho xuất chính, ko thể thay đổi nữa.
            cbKhoXuat.Enabled = false;

            // gridMaster.SelectedRows.
        }

        Int32 curGridRow_Editing = -1;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!((PanelButton.getClickStatus() == enumButton2.Them) || (PanelButton.getClickStatus() == enumButton2.Sua)))
                return;

            if (dataTableChiTietPhieuXuatTam.Rows.Count == 0)
                return;

            try
            {
                if (gridChiTietPhieuXuatTam.Rows.Count > 0)
                {

                    Int32 selectedRowCount = gridChiTietPhieuXuatTam.CurrentRow.Index;
                    DataGridViewRow selectedRow = gridChiTietPhieuXuatTam.Rows[selectedRowCount];

                    bool bXacNhanXuat = bool.Parse(selectedRow.Cells["_Da_duyet_xuat_vat_tu"].Value.ToString());
                    bool bXacNhanHoanNhapGiuLai = bool.Parse(selectedRow.Cells["_Da_duyet_hoan_nhap_giu_lai"].Value.ToString());

                    if (bXacNhanXuat && bXacNhanHoanNhapGiuLai)
                    {
                        MessageBox.Show("Bạn không thể sửa vật tư đã duyệt!");
                        return;
                    }

                    PanelButton.setGridClickEdit();
                    PanelButton.Enable_btn_Luu_Huy_Luoi();

                    curGridRow_Editing = selectedRowCount;

                    clsDMVatTu vt = new clsDMVatTu();
                    cbMaVatTu.SelectedValue = vt.getID_Ma_Vat_Tu(selectedRow.Cells["_Ma_vat_tu"].Value.ToString());
                    this.cbMaVatTu_SelectionChangeCommitted((object)cbMaVatTu, EventArgs.Empty);

                    cbChatLuong.SelectedValue = Int32.Parse(selectedRow.Cells["_Id_chat_luong"].Value.ToString());

                    int ID_Kho = Int32.Parse(selectedRow.Cells["_ID_kho"].Value.ToString());

                    if (Int32.Parse(cbKhoXuat.SelectedValue.ToString()) != ID_Kho)
                    {
                        chkboxEnableMuonVT.Checked = true;
                        cbMuonVTTaiKho.SelectedValue = ID_Kho;
                    }

                    txtSLDN.Text = selectedRow.Cells["_So_luong_de_nghi"].Value.ToString();
                    txtSLTX.Text = selectedRow.Cells["_So_luong_thuc_xuat"].Value.ToString();

                    chkboxXacNhanXuat.Checked = bool.Parse(selectedRow.Cells["_Da_duyet_xuat_vat_tu"].Value.ToString());

                    txtSLHN.Text = selectedRow.Cells["_So_luong_hoan_nhap"].Value.ToString();
                    txtSLGL.Text = selectedRow.Cells["_So_luong_giu_lai"].Value.ToString();
                    chkboxXacNhanHoanNhapGiuLai.Checked = bool.Parse(selectedRow.Cells["_Da_duyet_hoan_nhap_giu_lai"].Value.ToString());
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
                bool bXacNhanHoanNhapGiuLai = bool.Parse(selectedRow.Cells["_Da_duyet_hoan_nhap_giu_lai"].Value.ToString());

                if (bXacNhanXuat || bXacNhanHoanNhapGiuLai)
                {
                    MessageBox.Show("Bạn không thể xóa vật tư đã duyệt!");
                    return;
                }

                string Ten_vat_tu = selectedRow.Cells["_Ten_vat_tu"].Value.ToString();


                DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xóa vật tư \'" + Ten_vat_tu + "\' này ra khỏi phiếu?", "Cảnh báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dataTableChiTietPhieuXuatTam.Rows.RemoveAt(selectedRowCount);

                    if (dataTableChiTietPhieuXuatTam.Rows.Count == 0)
                        cbKhoXuat.Enabled = true;
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
        }

        private void btnSaveGrid_Click(object sender, EventArgs e)
        {
            try
            {
                dataTableChiTietPhieuXuatTam.Rows.RemoveAt(curGridRow_Editing);
                btnAdd_Click(this.btnSaveGrid, EventArgs.Empty);

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

            txtSL.Text = "0";

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

        private void reset_txtSL()
        {
            if (chkboxXacNhanXuat.Checked || (Int32.Parse(txtSL.Text.Trim().ToString()) == 0))
            {
                this.txtSL.BackColor = System.Drawing.SystemColors.Control;
                this.txtSL.ForeColor = System.Drawing.SystemColors.WindowText;
                errorProvider1.SetError(txtSL, "");
            }
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

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            //B1:Check VT
            if (cbMaVatTu.Text.Equals(string.Empty) || cbMaVatTu.SelectedIndex == -1)
            {
                reset_txtSL();
                return;
            }
            
            //Check Chất Lượng
            if (cbChatLuong.Text.Equals(string.Empty) || cbChatLuong.SelectedIndex == -1)
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

            TextBox SoLuong = (TextBox)sender;

            if (Int32.Parse(SoLuong.Text.Trim().ToString()) > 0 || chkboxXacNhanXuat.Checked)
            {
                if (Int32.Parse(SoLuong.Text.Trim().ToString()) > 0)
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

        private void setSLVatTu()
        {
            //getSL
            //txtSL.Text = "0";

            //B1:Check VT
            if (!cbMaVatTu.Text.Equals(string.Empty) && cbMaVatTu.SelectedIndex != -1)
            {
                //Check Chất Lượng
                if (!cbChatLuong.Text.Equals(string.Empty) && cbChatLuong.SelectedIndex != -1)
                {
                    //Check ID Kho
                    if (getIDKho() >= 0)
                    {
                        string Ma_vat_tu = cbMaVatTu.Text.Trim().ToString();
                        int ID_kho = getIDKho();
                        int Id_chat_luong = Int32.Parse(cbChatLuong.SelectedValue.ToString());

                        clsTonKho TonKho = new clsTonKho();
                        int SL = TonKho.getSL(Ma_vat_tu, ID_kho, Id_chat_luong);

                        txtSL.Text = SL.ToString();

                        //if (SL <= 0)
                        //{
                        //    setColorSL(false);
                        //}
                        //else
                        //{
                        //    setColorSL(true);
                        //}

                    }
                }
            }
        }


        private int getIDKho()
        {
            if (chkboxEnableMuonVT.Checked)
            {
                if (cbMuonVTTaiKho.Text.Trim().Equals(string.Empty) || cbMuonVTTaiKho.SelectedIndex == -1)
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
                if (cbKhoXuat.Text.Trim().Equals(string.Empty) || cbKhoXuat.SelectedIndex == -1)
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
                bool bXacNhanHoanNhapGiuLai = bool.Parse(selectedRow.Cells["_Da_duyet_hoan_nhap_giu_lai"].Value.ToString());

                if (bXacNhanXuat == false || bXacNhanHoanNhapGiuLai == false)
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
            txtLyDo.Text = dt.Rows[0]["Ly_do"].ToString();
            txtCongTrinh.Text = dt.Rows[0]["Cong_trinh"].ToString();
            txtDiaChi.Text = dt.Rows[0]["Dia_chi"].ToString();

        }

        private void SetDataToGrid()
        {
            clsChiTietPhieuXuatTam ChitTietPhieuXuat = new clsChiTietPhieuXuatTam();
            DataTable dt = ChitTietPhieuXuat.getAll_toGrid(cbMaPhieuXuatTam.Text.Trim());

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dataTableChiTietPhieuXuatTam.NewRow();
                dr["Ma_vat_tu"] = dt.Rows[i]["Ma_vat_tu"];
                dr["Ten_vat_tu"] = dt.Rows[i]["Ten_vat_tu"];
                dr["Id_chat_luong"] = dt.Rows[i]["Id_chat_luong"];
                dr["Loai_chat_luong"] = dt.Rows[i]["Loai_chat_luong"];
                dr["ID_kho"] = dt.Rows[i]["ID_kho"];
                dr["Ten_kho"] = dt.Rows[i]["Ten_kho"];
                dr["So_luong_de_nghi"] = dt.Rows[i]["So_luong_de_nghi"];
                dr["So_luong_thuc_xuat"] = dt.Rows[i]["So_luong_thuc_xuat"];
                dr["Da_duyet_xuat_vat_tu"] = dt.Rows[i]["Da_duyet_xuat_vat_tu"];
                dr["So_luong_hoan_nhap"] = dt.Rows[i]["So_luong_hoan_nhap"];
                dr["So_luong_giu_lai"] = dt.Rows[i]["So_luong_giu_lai"];
                dr["Da_duyet_hoan_nhap_giu_lai"] = dt.Rows[i]["Da_duyet_hoan_nhap_giu_lai"];
                //dr["So_luong_su_dung"] = dt.Rows[i]["So_luong_su_dung"];
                dr["Ten_don_vi_tinh"] = dt.Rows[i]["Ten_don_vi_tinh"];
                dataTableChiTietPhieuXuatTam.Rows.Add(dr);
            }
        }

        

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

            //clsGiaoDienChung.initCombobox(cbKhoXuat, new clsDM_Kho(), "Ten_kho", "ID_kho", "Ten_kho");

            cbKhoXuat.DataSource = DMKho.getAll_TenKho();
            cbKhoXuat.ValueMember = "ID_kho";
            cbKhoXuat.DisplayMember = "Ten_kho";

            cbKhoXuat.SelectedIndex = -1;
        }

        private void init_cbMaVatTu()
        {
            //clsGiaoDienChung.initCombobox(cbMaVatTu, new clsDMVatTu(), "Ma_vat_tu", "ID_vat_tu", "Ma_vat_tu");

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
            //clsGiaoDienChung.initCombobox(cbTenVatTu, new clsDMVatTu(), "Ten_vat_tu", "ID_vat_tu", "Ten_vat_tu");

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
            //clsGiaoDienChung.initCombobox(cbTenVatTu, new clsDMVatTu(), "Ten_vat_tu", "ID_vat_tu", "Ten_vat_tu");

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

            //clsGiaoDienChung.initCombobox(cbMuonVTTaiKho, new clsDM_Kho(), "Ten_kho", "ID_kho", "Ten_kho");

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
                setSLVatTu();
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
            //ComboBox cb = (ComboBox)sender;

            //int val = Int32.Parse(cb.SelectedValue.ToString());

            //init_cbMuonVTTaiKho();

            //int index = cbMuonVTTaiKho.Items.IndexOf(val);

            //cbMuonVTTaiKho.Items.RemoveAt(index);
            setSLVatTu();
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
            chkboxXacNhanHoanNhapGiuLai.Enabled = false;

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
            chkboxXacNhanHoanNhapGiuLai.Enabled = false;

            btnAddToGrid.Enabled = true;
            btnDelRowInGrid.Enabled = true;
            btnEditRowInGrid.Enabled = true;

            //btnSave dùng lưu thay đổi vào lưới
            btnSaveGrid.Enabled = false;
            btnCancel.Enabled = false;

            //Disable cả grid
            gridChiTietPhieuXuatTam.Enabled = true;

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
            EnableGridInputForm();
            cbMuonVTTaiKho.SelectedIndex = -1;
            cbMaVatTu.SelectedIndex = -1;
            cbTenVatTu.SelectedIndex = -1;
            cbChatLuong.SelectedIndex = -1;
            txtDVT.Text = "";
            chkboxEnableMuonVT.Checked = false;
            txtSL.Text = "0";

            txtSLDN.Text = "0";
            txtSLTX.Text = "0";
            chkboxXacNhanXuat.Checked = false;

            txtSLGL.Text = "0";
            txtSLHN.Text = "0";
            chkboxXacNhanHoanNhapGiuLai.Checked = false;
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
            chkboxXacNhanHoanNhapGiuLai.Enabled = false;
        }

        public void CloseForm()
        {
            this.Close();
        }

        //--------------EVENT
        private void chkboxXacNhanXuat_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;

            if (Int32.Parse(txtSLDN.Text.Trim().ToString()) == 0)
            {
                ToolTip1.Show("SL đề nghị không thể bằng 0", this.chkboxXacNhanXuat, 15, 15, 1500);
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

                txtSLHN.Enabled = true;
                txtSLGL.Enabled = true;
                chkboxXacNhanHoanNhapGiuLai.Enabled = true;

                chkboxXacNhanXuat.Enabled = false;
            }
        }

        /// <summary>
        /// Cần ktra gia tri nhập vào
        /// </summary>
        private void chkboxXacNhanHoanNhapGiuLai_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;

            if (chkBox.Checked)
            {
                txtSLHN.Enabled = false;
                txtSLGL.Enabled = false;
                chkboxXacNhanHoanNhapGiuLai.Enabled = false;
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

            //Xử lý chưa chọn kho xuất
            if (cbKhoXuat.SelectedIndex < 0 && chkBox.Checked == true)
            {
                ToolTip1.Show("Bạn chưa chọn kho xuất!", this.chkboxEnableMuonVT, 10, 10, 2000);
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

        private void txtSLDN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSLDN_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string errorMsg = "Số lượng đề nghị không đúng!";
            Int32 tmp;
            if (!Int32.TryParse(txt.Text.Trim().ToString(), out tmp) || txt.Text.Equals(String.Empty))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txt.Select(0, txt.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(txt, errorMsg);
            }
        }

        private void txtSLDN_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSLDN, "");
        }

        private void txtSLTX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSLTX_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string errorMsg = "Số lượng thực xuất không đúng!";
            Int32 tmp;
            if (!Int32.TryParse(txt.Text.Trim().ToString(), out tmp) || txt.Text.Equals(String.Empty))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txt.Select(0, txt.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(txt, errorMsg);
            }
        }

        private void txtSLTX_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSLTX, "");
        }

        private void txtSLGL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSLGL_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string errorMsg = "Số lượng giữ lại không đúng!";
            Int32 tmp;
            if (!Int32.TryParse(txt.Text.Trim().ToString(), out tmp) || txt.Text.Equals(String.Empty))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txt.Select(0, txt.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(txt, errorMsg);
            }
        }

        private void txtSLGL_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSLGL, "");
        }

        private void txtSLHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSLHN_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string errorMsg = "Số lượng hoàn nhập không đúng!";
            Int32 tmp;
            if (!Int32.TryParse(txt.Text.Trim().ToString(), out tmp) || txt.Text.Equals(String.Empty))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txt.Select(0, txt.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(txt, errorMsg);
            }
        }

        private void txtSLHN_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSLHN, "");
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

        
    }
}