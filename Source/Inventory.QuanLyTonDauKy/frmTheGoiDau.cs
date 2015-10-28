using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
using Inventory.Models;
namespace Inventory.QuanLyTonDauKy
{
    public partial class frmTheGoiDau : Form
    {
        clsTonDauKy TonDauKy;


        FormActionDelegate frmAction;

        //Quản lý Button
        clsPanelButton PanelButton;

        public frmTheGoiDau()
        {
            InitializeComponent();

            TonDauKy = new clsTonDauKy();

            //Init cls Button
            PanelButton = new clsPanelButton();

            frmAction = new FormActionDelegate(FormAction);
            PanelButton.setDelegateFormAction(frmAction);

            //enumButton dùng định danh button
            PanelButton.AddButton(enumButton.Them, ref btnThem);
            PanelButton.AddButton(enumButton.Xoa, ref btnXoa);
            PanelButton.AddButton(enumButton.Sua, ref btnSua);
            PanelButton.AddButton(enumButton.LamMoi, ref btnLamMoi);
            PanelButton.AddButton(enumButton.Luu, ref btnLuu);
            PanelButton.AddButton(enumButton.Huy, ref btnHuy);
            PanelButton.AddButton(enumButton.Dong, ref btnDong);

            PanelButton.setButtonClickEvent(enumButton.Dong);

            //Không dùng button Xóa, Sửa, Thêm, Lưu, Hủy
            PanelButton.setButtonStatus(enumButton.Them, false);
            PanelButton.setButtonStatus(enumButton.Xoa, false);
            PanelButton.setButtonStatus(enumButton.Sua, false);
            PanelButton.setButtonStatus(enumButton.Luu, false);
            PanelButton.setButtonStatus(enumButton.Huy, false);

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            initKhoNhap();

            LoadData();
        }

        /// <summary>
        /// Initializes --> combobox kho nhap.
        /// </summary>
        private void initKhoNhap()
        {
            clsGiaoDienChung.initCombobox(cbMaVatTu, new clsDMVatTu(), "Ma_vat_tu", "ID_vat_tu", "Ma_vat_tu");
            clsGiaoDienChung.initCombobox(cbChatLuong, new clsDMChatLuong(), "Loai_chat_luong", "ID_chat_luong", "Loai_chat_luong");
            //clsDM_Kho dmKho = new clsDM_Kho();
            //cbKhoNhap.DisplayMember = "Ten_kho";
            //cbKhoNhap.ValueMember = "ID_kho";

            //cbKhoNhap.DataSource =clsDM_Kho .getAll();

            cbMaVatTu.SelectedIndex = -1;
        }

        public void FormAction(enumFormAction frmAct)
        {
            switch (frmAct)
            {
                case enumFormAction.None:
                    break;
                case enumFormAction.LoadData:
                    LoadData();
                    break;
                case enumFormAction.CloseForm:
                    CloseForm();
                    break;
                case enumFormAction.setFormData:
                    break;
                case enumFormAction.ResetInputForm:
                    break;
                case enumFormAction.Huy:
                    break;
                case enumFormAction.Dong:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Re-Load ALL DATA to Grid
        /// </summary>
        public void LoadData()
        {
            try
            {
                gridTonDauKy.DataSource =clsChiTietGoiDau .GetAll();
            }
            catch (Exception ex) { }
        }

        public void CloseForm()
        {
            this.Close();
        }

        private void cbKhoNhap_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;

            //MessageBox.Show("" + c.SelectedValue.ToString());

            Int32 ID_Kho = Int32.Parse(c.SelectedValue.ToString());

            gridTonDauKy.DataSource = TonDauKy.GetAll_By_IDKho(ID_Kho);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbMaVatTu.SelectedIndex = -1;
            LoadData();
        }

        private void frmTheGoiDau_Load(object sender, EventArgs e)
        {

        }
    }
}
