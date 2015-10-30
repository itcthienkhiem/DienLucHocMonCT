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
    public partial class frmNhapTonDauKy : Form
    {
        clsTonDauKy TonDauKy;

        FormActionDelegate frmAction;

        clsPanelButton PanelButton;

        public frmNhapTonDauKy()
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
            PanelButton.setButtonClickEvent(enumButton.LamMoi);
            PanelButton.setButtonClickEvent(enumButton.Them);
            //PanelButton.setButtonClickEvent(enumButton.Xoa);
            PanelButton.setButtonClickEvent(enumButton.Sua);
            PanelButton.setButtonClickEvent(enumButton.Huy);

            //Không dùng button Xóa, Sửa, Thêm, Lưu, Hủy
            //PanelButton.setButtonStatus(enumButton.Them, false);
            PanelButton.setButtonStatus(enumButton.Xoa, false);
            //PanelButton.setButtonStatus(enumButton.Sua, false);
            //PanelButton.setButtonStatus(enumButton.Luu, false);
            //PanelButton.setButtonStatus(enumButton.Huy, false);

            //btnThem.Enabled = false;
            btnXoa.Enabled = false;
            //btnSua.Enabled = false;
            //btnLuu.Enabled = false;
            //btnHuy.Enabled = false;

            initKhoNhap();
            initMaVatTu();
            initTenVatTu();

            LoadData();
        }

        /// <summary>
        /// Initializes --> combobox kho nhap.
        /// </summary>
        private void initKhoNhap()
        {
            clsGiaoDienChung.initCombobox(cbKhoNhap, new clsDM_Kho(), "Ten_kho", "ID_kho", "Ten_kho");
            //clsDM_Kho dmKho = new clsDM_Kho();
            //cbKhoNhap.DisplayMember = "Ten_kho";
            //cbKhoNhap.ValueMember = "ID_kho";

            //cbKhoNhap.DataSource = clsDM_Kho.getAll();

            cbKhoNhap.SelectedIndex = -1;
        }

        /// <summary>
        /// Initializes --> combobox kho nhap.
        /// </summary>
        private void initMaVatTu()
        {
            clsDMVatTu DMVatTu = new clsDMVatTu();
            cbMaVatTu.DisplayMember = "Ma_vat_tu";
            cbMaVatTu.ValueMember = "id";

            cbMaVatTu.DataSource = DMVatTu.GetAll_for_cb();

            cbMaVatTu.SelectedIndex = -1;
        }

        /// <summary>
        /// Initializes --> combobox kho nhap.
        /// </summary>
        private void initTenVatTu()
        {
            clsDMVatTu DMVatTu = new clsDMVatTu();
            cbTenVatTu.DisplayMember = "Ten_vat_tu";
            cbTenVatTu.ValueMember = "id";

            cbTenVatTu.DataSource = DMVatTu.GetAll_for_cb();

            cbTenVatTu.SelectedIndex = -1;
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
                    setFormData();
                    break;
                case enumFormAction.ResetInputForm:
                    ResetInputForm();
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
            gridTonDauKy.DataSource = TonDauKy.GetAll("");
        }

        public void CloseForm()
        {
            this.Close();
        }

        public void setFormData()
        {
            Int32 selectedRowCount = gridTonDauKy.CurrentCell.RowIndex;

            DataGridViewRow SelectedRow = gridTonDauKy.Rows[selectedRowCount];

            cbKhoNhap.Text = SelectedRow.Cells["Ten_kho"].Value.ToString();

            cbMaVatTu.Text = SelectedRow.Cells["Ma_vat_tu"].Value.ToString();
            cbTenVatTu.Text = SelectedRow.Cells["Ten_vat_tu"].Value.ToString();

            txtSoLuong.Text = SelectedRow.Cells["So_luong"].Value.ToString();
        }

        /// <summary>
        /// Resets the input form.
        /// </summary>
        public void ResetInputForm()
        {
            if (PanelButton.isClickNone())
            {
                cbKhoNhap.Text = "";
                cbMaVatTu.Text = "";
                cbTenVatTu.Text = "";
                txtSoLuong.Text = "";
            }
        }

        private void gridTonDauKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = gridTonDauKy.CurrentCell.RowIndex;
            DataGridViewRow SelectedRow = gridTonDauKy.Rows[selectedRowCount];

            if (selectedRowCount >= 0 && PanelButton.isClickXoa() || PanelButton.isClickSua())
            {
                cbKhoNhap.Text = SelectedRow.Cells["Ten_kho"].Value.ToString();

                cbMaVatTu.Text = SelectedRow.Cells["Ma_vat_tu"].Value.ToString();
                cbTenVatTu.Text = SelectedRow.Cells["Ten_vat_tu"].Value.ToString();

                txtSoLuong.Text = SelectedRow.Cells["So_luong"].Value.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (PanelButton.getClickStatus())
            {

                case enumButton.Them:
                    {

                        //DM_VatTu.Ma_vat_tu = txtMaVatTu.Text.Trim();
                        //DM_VatTu.Ten_vat_tu = txtTenVatTu.Text.Trim();
                        //DM_VatTu.ID_Don_vi_tinh = Int32.Parse(cboDonViTinh.SelectedValue.ToString());
                        //DM_VatTu.Mo_ta = txtMoTa.Text.Trim();

                        TonDauKy.ID_kho = (int)cbKhoNhap.SelectedValue;
                        TonDauKy.Ma_vat_tu = cbMaVatTu.Text;
                        TonDauKy.So_luong = Int32.Parse(txtSoLuong.Text.ToString());


                        if (!TonDauKy.CheckTonTaiSoDK())
                        {
                            if (TonDauKy.Insert() == 1)
                            {
                                //MessageBox.Show("Bạn đã thêm thành công !");
                                AutoClosingMessageBox.Show("Bạn đã thêm thành công !", "Thông báo", 1000);

                                //Reset status
                                PanelButton.ResetClickStatus();

                                LoadData();

                                PanelButton.ResetButton();

                                //Reset input
                                ResetInputForm();
                            }
                            else
                                //AutoClosingMessageBox.Show("Bạn đã thêm thất bại!", "Thông báo", 1000);
                                MessageBox.Show("Lỗi: Bạn đã thêm thất bại!");
                        }
                        else
                            //AutoClosingMessageBox.Show("Lỗi: Vật tư đã tồn tại!", "Thông báo", 1000);
                            MessageBox.Show("Lỗi: Vật tư đã tồn tại!");
                        break;
                    } // End Them
                //case enumButton.Xoa:
                //    {
                //        TonDauKy.Ma_vat_tu = txtMaVatTu.Text;

                //        Int32 selectedRowCount = gridTonDauKy.CurrentCell.RowIndex;
                //        TonDauKy.Ma_vat_tu = gridTonDauKy.Rows[selectedRowCount].Cells["Ma_vat_tu"].Value.ToString();
                //        DialogResult dialogResult = MessageBox.Show("Bạn có thật sự muốn xóa không ?", "Cảnh báo!", MessageBoxButtons.YesNo);
                //        if (dialogResult == DialogResult.Yes)
                //        {
                //            //do something

                //            if (TonDauKy.Delete() == 1)
                //            {
                //                //MessageBox.Show("Bạn đã xóa thành công !");

                //                //Reset
                //                PanelButton.ResetClickStatus();

                //                LoadData();

                //                PanelButton.ResetButton();

                //                ResetInputForm();
                //            }
                //            else
                //                //AutoClosingMessageBox.Show("Lỗi: Bạn đã xóa thất bại!", "Thông báo", 1000);
                //                MessageBox.Show("Lỗi: Bạn đã xóa thất bại!");

                //        }
                //        else if (dialogResult == DialogResult.No)
                //        {
                //            //do something else
                //        }
                //        break;


                //    }// end Xóa
                case enumButton.Sua:
                    {
                        //DM_VatTu.Ma_vat_tu = txtMaVatTu.Text.Trim();
                        //DM_VatTu.Ten_vat_tu = txtTenVatTu.Text.Trim();
                        //DM_VatTu.ID_Don_vi_tinh = (int)cboDonViTinh.SelectedValue;
                        //DM_VatTu.Mo_ta = txtMoTa.Text.Trim();

                        TonDauKy.ID_kho = (int)cbKhoNhap.SelectedValue;
                        TonDauKy.Ma_vat_tu = cbMaVatTu.Text;
                        TonDauKy.So_luong = Int32.Parse(txtSoLuong.Text.ToString());

                        Int32 selectedRowCount = gridTonDauKy.CurrentCell.RowIndex;
                        if (selectedRowCount >= 0)
                        {
                            //TonDauKy.Ma_vat_tu = gridTonDauKy.Rows[selectedRowCount].Cells["Ma_vat_tu"].Value.ToString();

                            if (TonDauKy.Update() == 1)
                            {
                                //MessageBox.Show("Bạn đã cập nhật thành công !");
                                AutoClosingMessageBox.Show("Bạn đã cập nhật thành công !", "Thông báo", 1000);

                                //Reset
                                PanelButton.ResetClickStatus();

                                LoadData();

                                PanelButton.ResetButton();

                                ResetInputForm();
                            }
                            else
                            {
                                MessageBox.Show("Lỗi: Bạn đã cập nhật thất bại!");
                                //AutoClosingMessageBox.Show("Lỗi: Bạn đã cập nhật thất bại!", "Thông báo", 1000);
                            }
                        }
                        break;
                    } //end Sửa

            } //End Sw
        }

        private void cbMaVatTu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;

            cbTenVatTu.SelectedIndex = c.SelectedIndex;
        }

        private void cbTenVatTu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;

            cbMaVatTu.SelectedIndex = c.SelectedIndex;
        }

    }
}
