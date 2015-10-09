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
    /// Write by Khiêm
    /// 
    /// Editing...
    /// To-Do LIST
    /// [x] Chuyển Status về class, use func thay gì set trực tiếp
    /// [.] B1: Chuyển phần set button về func tập trung --> B2: Tạo 1 class làm việc này
    /// * Problem
    /// [ ] Bỏ tính năng xóa trực tiếp, chuyển dùng biến trạng thái True == Deleted | False.
    /// [ ] ?
    /// </summary>
    public partial class frmDMKho : Form
    {
        FormActionDelegate frmAction;

        //Data
        clsDM_Kho DM_Kho;

        //Quản lý Button
        clsPanelButton PanelButton;

        public frmDMKho()
        {
            InitializeComponent();

            //Init Data
            DM_Kho = new clsDM_Kho();

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

            LoadData();

            PanelButton.ResetButton();
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

        public void CloseForm()
        {
            this.Close();
        }

        public void setFormData()
        {
            Int32 selectedRowCount = gridDMKho.CurrentCell.RowIndex;

            DataGridViewRow SelectedRow = gridDMKho.Rows[selectedRowCount];

            txtTenKho.Text = SelectedRow.Cells["Ten_kho"].Value.ToString();
        }

        /// <summary>
        /// Data --> Grid.
        /// </summary>
        public void LoadData()
        {
            gridDMKho.DataSource = DM_Kho.GetAll();
        }

        /// <summary>
        /// Resets the input form.
        /// </summary>
        public void ResetInputForm()
        {
            if (PanelButton.isClickNone())
            {
                txtTenKho.Text = "";
            }
        }


        /// <summary>
        /// Lưu -> Thêm, Xóa, Sửa | Tùy theo Button nào dc Click
        /// </summary>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenKho.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên kho không được phép rỗng!");
                return;
            }
            switch (PanelButton.getClickStatus())
            {
                case enumButton.Them:
                    {
                        DM_Kho.Ten_kho = txtTenKho.Text.Trim();

                        if (!DM_Kho.CheckTonTaiSoDK())
                        {
                            if (DM_Kho.Insert() == 1)
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
                                //AutoClosingMessageBox.Show("Lỗi: Bạn đã thêm thất bại!", "Thông báo", 1000);
                                MessageBox.Show("Lỗi: Bạn đã thêm thất bại!");

                        }
                        else
                            //AutoClosingMessageBox.Show("Lỗi: Kho đã tồn tại!", "Thông báo", 1000);
                            MessageBox.Show("Lỗi: Kho đã tồn tại!");
                        break;
                    }
                case enumButton.Xoa:
                        {
                            DM_Kho.Ten_kho = txtTenKho.Text;

                            Int32 selectedRowCount = gridDMKho.CurrentCell.RowIndex;
                            DM_Kho.ID_kho = int.Parse(gridDMKho.Rows[selectedRowCount].Cells["id_kho"].Value.ToString());

                            DialogResult dialogResult = MessageBox.Show("Bạn có thật sự muốn xóa không ?", "Cảnh báo!", MessageBoxButtons.YesNo);
                            
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (DM_Kho.Delete() == 1)
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
                        }
                case enumButton.Sua:
                        {
                            DM_Kho.Ten_kho = txtTenKho.Text;

                            Int32 selectedRowCount = gridDMKho.CurrentCell.RowIndex;

                            if (selectedRowCount >= 0)
                            {
                                DM_Kho.ID_kho = int.Parse(gridDMKho.Rows[selectedRowCount].Cells["id_kho"].Value.ToString());
                                if (DM_Kho.Update() == 1)
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
                        }
            }
        }

        /// <summary>
        /// Đổi stt --> khi Xóa | Sửa
        /// </summary>
        private void gridDMKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = gridDMKho.CurrentCell.RowIndex;
            if (selectedRowCount >= 0 && PanelButton.isClickXoa() || PanelButton.isClickSua())
            {
                txtTenKho.Text = gridDMKho.Rows[selectedRowCount].Cells["Ten_kho"].Value.ToString();
            }
            // txtTenKho.Text = cell.Value.ToString();
        }
    }
}
