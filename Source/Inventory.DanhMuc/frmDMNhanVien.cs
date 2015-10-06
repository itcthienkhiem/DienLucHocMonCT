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
    public partial class frmDMNhanVien : Form
    {
        FormActionDelegate frmAction;

        //enumStatus status = enumStatus.None;
        //clsDMVatTu DM_VatTu = new clsDMVatTu();

        //Quản lý Button
        clsPanelButton PanelButton;

        clsDM_NhanVien DM_NhanVien = new clsDM_NhanVien();

        public frmDMNhanVien()
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

            LoadData();
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
            gridDMNhanVien.DataSource = DM_NhanVien.GetAll();
        }

        public void CloseForm()
        {
            this.Close();
        }

        public void setFormData()
        {
            Int32 selectedRowCount = gridDMNhanVien.CurrentCell.RowIndex;

            DataGridViewRow SelectedRow = gridDMNhanVien.Rows[selectedRowCount];

            txtTenNhanVien.Text = SelectedRow.Cells["Ten_nhan_vien"].Value.ToString();
            txtMaNhanVien.Text = SelectedRow.Cells["Ma_nhan_vien"].Value.ToString();
            cbTrangThai.Checked = bool.Parse(SelectedRow.Cells["Trang_thai"].Value.ToString());
        }

        /// <summary>
        /// Resets the input form.
        /// </summary>
        public void ResetInputForm()
        {
            if (PanelButton.isClickNone())
            {
                txtTenNhanVien.Text = "";
                txtMaNhanVien.Text = "";
                cbTrangThai.Checked = false;
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (PanelButton.getClickStatus())
            {

                case enumButton.Them:
                    {

                        DM_NhanVien.Ten_nhan_vien = txtTenNhanVien.Text.Trim();
                        DM_NhanVien.Ma_nhan_vien = txtMaNhanVien.Text.Trim(); //Int32.Parse(cboTenKho.SelectedValue.ToString());
                        DM_NhanVien.Trang_thai = cbTrangThai.Checked;


                        if (!DM_NhanVien.Checkduplicaterows())
                        {
                            if (DM_NhanVien.Insert() == 1)
                            {
                                MessageBox.Show("Bạn đã thêm thành công !");

                                //Reset status
                                PanelButton.ResetClickStatus();

                                LoadData();

                                PanelButton.ResetButton();

                                //Reset input
                                ResetInputForm();
                            }
                            else
                                MessageBox.Show("Bạn đã thêm thất bại!");
                        }
                        else
                            MessageBox.Show("Lỗi: Đơn vị đã tồn tại!");
                        break;
                    } // End Them
                case enumButton.Xoa:
                    {
                        //DM_VatTu.Ma_vat_tu = txtMaVatTu.Text;

                        Int32 selectedRowCount = gridDMNhanVien.CurrentCell.RowIndex;
                        DM_NhanVien.ID_nhan_vien = Int32.Parse(gridDMNhanVien.Rows[selectedRowCount].Cells["ID_nhan_vien"].Value.ToString());

                        DialogResult dialogResult = MessageBox.Show("Bạn có thật sự muốn xóa không ?", "Cảnh báo!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something

                            if (DM_NhanVien.Delete() == 1)
                            {
                                MessageBox.Show("Bạn đã xóa thành công !");

                                //Reset
                                PanelButton.ResetClickStatus();

                                LoadData();

                                PanelButton.ResetButton();

                                ResetInputForm();
                            }
                            else
                                MessageBox.Show("Bạn đã xóa thất bại!");

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }
                        break;


                    }// end Xóa
                case enumButton.Sua:
                    {
                        DM_NhanVien.Ten_nhan_vien = txtTenNhanVien.Text.Trim();
                        DM_NhanVien.Ma_nhan_vien = txtMaNhanVien.Text.Trim(); //Int32.Parse(cboTenKho.SelectedValue.ToString());
                        DM_NhanVien.Trang_thai = cbTrangThai.Checked;

                        Int32 selectedRowCount = gridDMNhanVien.CurrentCell.RowIndex;

                        if (selectedRowCount >= 0)
                        {
                            DM_NhanVien.ID_nhan_vien = Int32.Parse(gridDMNhanVien.Rows[selectedRowCount].Cells["ID_nhan_vien"].Value.ToString());

                            if (DM_NhanVien.Update() == 1)
                            {
                                MessageBox.Show("Bạn đã cập nhật thành công !");

                                //Reset
                                PanelButton.ResetClickStatus();

                                LoadData();

                                PanelButton.ResetButton();

                                ResetInputForm();
                                
                            }
                            else
                            {
                                MessageBox.Show("Bạn đã cập nhật thất bại!");
                            }
                        }
                        break;
                    } //end Sửa

            } //End Sw
        }

        

        private void gridDMNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = gridDMNhanVien.CurrentCell.RowIndex;
            if (selectedRowCount >= 0 && PanelButton.isClickXoa() || PanelButton.isClickSua())
            {
                DataGridViewRow SelectedRow = gridDMNhanVien.Rows[selectedRowCount];

                txtTenNhanVien.Text = SelectedRow.Cells["Ten_nhan_vien"].Value.ToString();
                txtMaNhanVien.Text = SelectedRow.Cells["Ma_nhan_vien"].Value.ToString();
                cbTrangThai.Checked = bool.Parse(SelectedRow.Cells["Trang_thai"].Value.ToString());
            }
        }
    }
}
