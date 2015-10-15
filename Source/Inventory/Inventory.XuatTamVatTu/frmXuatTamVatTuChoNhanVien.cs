using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;

namespace Inventory.XuatTamVatTu
{
    /// <summary>
    /// [ ] Init: Hiện ds nhân viên đang còn giữ vật tư
    /// --> chọn nhân viên, xem DS vật tư nv đang giữ, vật tư đó của kho nào
    /// [ ] Gõ tên nhân viên: hiện ds vật tư nv đó đang giữ, của kho nào, nếu rỗng, báo rỗng --> groupBox.
    /// --> Có tên nhân viên, mã nhân viên --> Chọn xuất VT cho nv đó
    /// 
    /// LIST BTN
    /// [ ] Xem phiếu xuất của row -> ??? Chưa làm lúc này
    /// [ ] Xuất vật tư cho NV đã chọn
    /// [ ] 
    /// 
    /// Dự kiến:
    /// [ ] Dùng 2 grid --> loại
    /// </summary>
    public partial class frmXuatTamVatTuChoNhanVien : Form
    {
        FormActionDelegate2 frmAction;
        clsPanelButton2 PanelButton;

        clsXuatVatTuChoNhanVien XuatVTChoNV;

        string ID_nhan_vien;

        public frmXuatTamVatTuChoNhanVien()
        {
            InitializeComponent();

            ID_nhan_vien = "";

            XuatVTChoNV = new clsXuatVatTuChoNhanVien();

            gbGrid.Text = "Danh sách nhân viên còn giữ vật tư";

            gridNhanVienNoVatTu.Visible = true;
            gridNhanVienNoVatTu.Dock = System.Windows.Forms.DockStyle.Fill;


            //Init cls Button
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
            PanelButton.setButtonClickEvent(enumButton2.LamMoi);

            PanelButton.setButtonStatus(enumButton2.Them, false);
            PanelButton.setButtonStatus(enumButton2.Sua, false);
            PanelButton.setButtonStatus(enumButton2.Xoa, false);
            PanelButton.setButtonStatus(enumButton2.Luu, false);
            PanelButton.setButtonStatus(enumButton2.Huy, false);
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            PanelButton.ResetButton();

            LoadData();

            init_cbMaNhanVien();
            init_cbTenNhanVien();

        }

        public void FormAction(enumFormAction2 frmAct)
        {
            switch (frmAct)
            {
                case enumFormAction2.None:
                    break;
                case enumFormAction2.LoadData:
                    //Khi click lam moi
                    //Reset data
                    cbMaNhanVien.SelectedIndex = -1;
                    cbTenNhanVien.SelectedIndex = -1;
                    ID_nhan_vien = "";
                    LoadData();
                    break;
                case enumFormAction2.CloseForm:
                    CloseForm();
                    break;
                case enumFormAction2.setFormData:
                    break;
                case enumFormAction2.ResetInputForm:
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
        /// Re-Load ALL DATA to Grid
        /// </summary>
        private void LoadData()
        {
            if (ID_nhan_vien.Equals(string.Empty))
                gridNhanVienNoVatTu.DataSource = XuatVTChoNV.getDSNhanVienNoVatTu();
            else
            {
                gridNhanVienNoVatTu.DataSource = XuatVTChoNV.getDSNhanVienNoVatTu(ID_nhan_vien);
            }
        }

        private void CloseForm()
        {
            this.Close();
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

        private void cbMaNhanVien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if ((comboBox.SelectedIndex != -1) && (cbTenNhanVien.SelectedValue != comboBox.SelectedValue))
            {
                cbTenNhanVien.SelectedValue = comboBox.SelectedValue;
                ID_nhan_vien = comboBox.SelectedValue.ToString();
                LoadData();
            }
            
        }

        private void cbTenNhanVien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if ((comboBox.SelectedIndex != -1) && (cbMaNhanVien.SelectedValue != comboBox.SelectedValue))
            {
                cbMaNhanVien.SelectedValue = comboBox.SelectedValue;
                ID_nhan_vien = comboBox.SelectedValue.ToString();
                LoadData();
            }
                
        }
    }
}
