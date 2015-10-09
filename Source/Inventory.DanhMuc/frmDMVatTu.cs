using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;

namespace Inventory.DanhMuc
{
    /// <summary>
    /// *Current Working
    /// [...]
    /// 
    /// To-do LIST
    /// - Init
    /// - Load ALL DATA
    /// - Button Event
    /// - Row Event
    /// 
    /// 
    /// * Problem
    /// - Button nên có 2 màu, 1 enable, 1 Disable
    /// </summary>
    public partial class frmDMVatTu : Form
    {
        //enumStatus status = enumStatus.None;
        clsDMVatTu DM_VatTu = new clsDMVatTu();

        
        FormActionDelegate frmAction;

        //Quản lý Button
        clsPanelButton PanelButton;


        /// <summary>
        /// [Bug] Lỗi khi GetDonViTinh == Rỗng
        /// </summary>
        public frmDMVatTu()
        {
            InitializeComponent();

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

            PanelButton.ResetButton();

            /*DM_VatTu.GetDonViTinh();
            if (DM_VatTu.dicDonViTinh.Count > 0)
            {
                cboDonViTinh.DataSource = new BindingSource(DM_VatTu.dicDonViTinh, null);
                cboDonViTinh.DisplayMember = "Key";
                cboDonViTinh.ValueMember = "Value";

                DM_VatTu.Selected_DonViTinh = (int)cboDonViTinh.SelectedValue;
            }*/
            initDonViTinh();

            LoadData();

        }

        private void initDonViTinh()
        {
            clsDM_DonViTinh dmKho = new clsDM_DonViTinh();
            cboDonViTinh.DisplayMember = "Ten_don_vi_tinh";
            cboDonViTinh.ValueMember = "ID_Don_vi_tinh";

            cboDonViTinh.DataSource = dmKho.GetAll();

            cboDonViTinh.SelectedIndex = -1;
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
                case enumFormAction.Luu:
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
            gridDMVatTu.DataSource = DM_VatTu.GetAll();
        }

        public void CloseForm()
        {
            this.Close();
        }

        public void setFormData()
        {
            Int32 selectedRowCount = gridDMVatTu.CurrentCell.RowIndex;

            DataGridViewRow SelectedRow = gridDMVatTu.Rows[selectedRowCount];

            txtTenVatTu.Text = SelectedRow.Cells["Ten_vat_tu"].Value.ToString();
            txtMaVatTu.Text = SelectedRow.Cells["Ma_vat_tu"].Value.ToString();
            txtMoTa.Text = SelectedRow.Cells["Mo_ta"].Value.ToString();

            cboDonViTinh.Text = SelectedRow.Cells["Ten_don_vi_tinh"].Value.ToString();//cboDonViTinh.Items.IndexOf("Mét"); //(int)DM_VatTu.dicDonViTinh[SelectedRow.Cells["ID_Don_vi_tinh"].Value.ToString()];
        }

        /// <summary>
        /// Resets the input form.
        /// </summary>
        public void ResetInputForm()
        {
            if (PanelButton.isClickNone())
            {
                txtMaVatTu.Text = "";
                txtTenVatTu.Text = "";
                txtMoTa.Text = "";
                cboDonViTinh.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Coding...............
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaVatTu.Text.Trim().Length == 0 || txtTenVatTu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Kiểm tra lại thuộc tính không được phép rỗng !");
                return;
            }
            switch (PanelButton.getClickStatus())
            {

                case enumButton.Them:
                    {

                        DM_VatTu.Ma_vat_tu = txtMaVatTu.Text.Trim();
                        DM_VatTu.Ten_vat_tu = txtTenVatTu.Text.Trim();
                        DM_VatTu.ID_Don_vi_tinh = Int32.Parse(cboDonViTinh.SelectedValue.ToString());
                        DM_VatTu.Mo_ta = txtMoTa.Text.Trim();


                        if (!DM_VatTu.Checkduplicaterows())
                        {
                            if (DM_VatTu.Insert() == 1)
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
                case enumButton.Xoa:
                    {
                        DM_VatTu.Ma_vat_tu = txtMaVatTu.Text;

                        Int32 selectedRowCount = gridDMVatTu.CurrentCell.RowIndex;
                        DM_VatTu.Ma_vat_tu = gridDMVatTu.Rows[selectedRowCount].Cells["Ma_vat_tu"].Value.ToString();
                        DialogResult dialogResult = MessageBox.Show("Bạn có thật sự muốn xóa không ?", "Cảnh báo!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something

                            if (DM_VatTu.Delete() == 1)
                            {
                                //MessageBox.Show("Bạn đã xóa thành công !");

                                //Reset
                                PanelButton.ResetClickStatus();

                                LoadData();

                                PanelButton.ResetButton();

                                ResetInputForm();
                            }
                            else
                                //AutoClosingMessageBox.Show("Lỗi: Bạn đã xóa thất bại!", "Thông báo", 1000);
                                MessageBox.Show("Lỗi: Bạn đã xóa thất bại!");

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }
                        break;


                    }// end Xóa
                case enumButton.Sua:
                    {
                        DM_VatTu.Ma_vat_tu = txtMaVatTu.Text.Trim();
                        DM_VatTu.Ten_vat_tu = txtTenVatTu.Text.Trim();
                        DM_VatTu.ID_Don_vi_tinh = (int)cboDonViTinh.SelectedValue;
                        DM_VatTu.Mo_ta = txtMoTa.Text.Trim();

                        Int32 selectedRowCount = gridDMVatTu.CurrentCell.RowIndex;
                        if (selectedRowCount >= 0)
                        {
                            DM_VatTu.old_Ma_vat_tu = gridDMVatTu.Rows[selectedRowCount].Cells["Ma_vat_tu"].Value.ToString();

                            if (DM_VatTu.Update() == 1)
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

        private void gridDMVatTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = gridDMVatTu.CurrentCell.RowIndex;
            DataGridViewRow SelectedRow = gridDMVatTu.Rows[selectedRowCount];

            if (selectedRowCount >= 0 && PanelButton.isClickXoa() || PanelButton.isClickSua())
            {
                txtTenVatTu.Text = SelectedRow.Cells["Ten_vat_tu"].Value.ToString();
                txtMaVatTu.Text = SelectedRow.Cells["Ma_vat_tu"].Value.ToString();
                txtMoTa.Text = SelectedRow.Cells["Mo_ta"].Value.ToString();

                cboDonViTinh.SelectedValue = (int)DM_VatTu.dicDonViTinh[SelectedRow.Cells["Ten_don_vi_tinh"].Value.ToString()];
            }
        }

        

        private void cboDonViTinh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Maybe remove
            DM_VatTu.Selected_DonViTinh = (int)cboDonViTinh.SelectedValue;
        }

        
    }
}
