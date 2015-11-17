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
    /// - [...]
    /// 
    /// To-do LIST
    /// - Init
    /// - Load ALL DATA
    /// - Button Event
    /// - Row Event [???]
    /// 
    /// 
    /// * Problem
    /// [x] Button nên có 2 màu, 1 enable, 1 Disable
    /// [ ] Chức năng sửa: Chọn nhiều dòng? SỬa 1 lúc nhiều dòng? Sửa trên lưới, cập nhật sau, 1 lúc.
    /// [ ] Chức năng Xóa, xóa nhiều line 1 lúc? Lúc hỏi, bạn có muốn xóa line a, b?
    /// </summary>
    public partial class frmDMDonViTinh : DevExpress.XtraEditors.XtraForm
    {
        FormActionDelegate frmAction;

        //Data
        clsDM_DonViTinh DM_DonViTinh;

        //Quản lý Button
        clsPanelButton PanelButton;

        public frmDMDonViTinh()
        {
            InitializeComponent();

            DM_DonViTinh = new clsDM_DonViTinh();

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

        

        public void LoadData()
        {
            gridDMDonViTinh.DataSource = DM_DonViTinh.GetAll();
        }

        public void CloseForm()
        {
            this.Close();
        }

        public void setFormData()
        {
            Int32 selectedRowCount = gridDMDonViTinh.CurrentCell.RowIndex;

            DataGridViewRow SelectedRow = gridDMDonViTinh.Rows[selectedRowCount];

            txtTenDonVi.Text = SelectedRow.Cells["Ten_don_vi_tinh"].Value.ToString();
        }

        /// <summary>
        /// Resets the input form.
        /// </summary>
        public void ResetInputForm()
        {
            if (PanelButton.isClickNone())
            {
                txtTenDonVi.Text = "";
            }
        }

        

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenDonVi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên kho không được phép rỗng!");
                return;
            }
            switch (PanelButton.getClickStatus())
            {

                case enumButton.Them:
                    {
                        DM_DonViTinh.Ten_don_vi_tinh = txtTenDonVi.Text.Trim();

                        if (!DM_DonViTinh.hasDuplicateRow())
                        {
                            if (DM_DonViTinh.Insert() == 1)
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
                            {
                                //MessageBox.Show("Bạn đã thêm thất bại!");
                                AutoClosingMessageBox.Show("Lỗi: Bạn đã thêm thất bại!", "Thông báo", 1000);
                            }
                        }
                        else
                            AutoClosingMessageBox.Show("Lỗi: Đơn vị đã tồn tại!", "Thông báo", 1000);
                            //MessageBox.Show("Lỗi: Đơn vị đã tồn tại!");
                        break;
                    } // End Them
                case enumButton.Xoa:
                    {
                        Int32 selectedRowCount = gridDMDonViTinh.CurrentCell.RowIndex;
                        DM_DonViTinh.ID_Don_vi_tinh = Int32.Parse(gridDMDonViTinh.Rows[selectedRowCount].Cells["ID_Don_vi_tinh"].Value.ToString());
                        DM_DonViTinh.Ten_don_vi_tinh = gridDMDonViTinh.Rows[selectedRowCount].Cells["Ten_don_vi_tinh"].Value.ToString();
                        DialogResult dialogResult = MessageBox.Show("Bạn có thật sự muốn xóa không ?", "Cảnh báo!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something
                            Models.DM_Don_vi_tinh dvt = new Models.DM_Don_vi_tinh();
                            dvt.ID_Don_vi_tinh = DM_DonViTinh.ID_Don_vi_tinh;
                            dvt.Ten_don_vi_tinh = DM_DonViTinh.Ten_don_vi_tinh;
                            if (DM_DonViTinh.Delete(dvt) == 1)
                            {
                                //MessageBox.Show("Bạn đã xóa thành công !");

                                //Reset
                                PanelButton.ResetClickStatus();

                                LoadData();

                                PanelButton.ResetButton();

                                ResetInputForm();
                            }
                            else
                                AutoClosingMessageBox.Show("Lỗi: Bạn đã xóa thất bại!", "Thông báo", 1000);
                                //MessageBox.Show("Bạn đã xóa thất bại!");

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }
                        break;


                    }// end Xóa
                case enumButton.Sua:
                    {
                        DM_DonViTinh.Ten_don_vi_tinh = txtTenDonVi.Text.Trim();

                        Int32 selectedRowCount = gridDMDonViTinh.CurrentCell.RowIndex;
                        if (selectedRowCount >= 0)
                        {
                            DM_DonViTinh.ID_Don_vi_tinh = Int32.Parse(gridDMDonViTinh.Rows[selectedRowCount].Cells["ID_Don_vi_tinh"].Value.ToString());
                            Models.DM_Don_vi_tinh dvt = new Models.DM_Don_vi_tinh();
                            dvt.ID_Don_vi_tinh = DM_DonViTinh.ID_Don_vi_tinh;
                            dvt.Ten_don_vi_tinh = DM_DonViTinh.Ten_don_vi_tinh;

                            if (DM_DonViTinh.Update(dvt) == 1)
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
                                //MessageBox.Show("Bạn đã cập nhật thất bại!");
                                AutoClosingMessageBox.Show("Lỗi: Bạn đã cập nhật thất bại!", "Thông báo", 1000);
                            }
                        }
                        break;
                    } //end Sửa

            } //End Sw
        }

        private void gridDMDonViTinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = gridDMDonViTinh.CurrentCell.RowIndex;
            if (selectedRowCount >= 0 && PanelButton.isClickXoa() || PanelButton.isClickSua())
            {
                txtTenDonVi.Text = gridDMDonViTinh.Rows[selectedRowCount].Cells["Ten_don_vi_tinh"].Value.ToString();
            }
        }
    }
}
