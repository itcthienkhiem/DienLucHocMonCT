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
        //Data
        clsDM_Kho DM_Kho = new clsDM_Kho();

        //Quản lý Button
        clsPanelButton PanelButton;

        public frmDMKho()
        {
            InitializeComponent();

            //Init cls Button
            PanelButton = new clsPanelButton();

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


        /// <summary>
        /// Loads the data --> Grid.
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
        /// ~
        /// </summary>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (PanelButton.getClickStatus())
            {
                case enumButton.Them:
                    {
                        DM_Kho.Ten_kho = txtTenKho.Text.Trim();
                        if (!DM_Kho.CheckTonTaiSoDK()&& DM_Kho.Insert() == 1)
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
                                //do something
                                
                                if (DM_Kho.Delete() == 1)
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
                                     MessageBox.Show("Bạn đã cập nhật thành công !");

                                     //Reset
                                     PanelButton.ResetClickStatus();

                                     LoadData();

                                     PanelButton.ResetButton();
                                     
                                     //Reset input
                                     ResetInputForm();
                                 }
                                 else
                                 {
                                     MessageBox.Show("Bạn đã cập nhật thất bại!");
                                 }
                             }
                             break;
                        }
            }
        }

        /// <summary>
        /// Đổi stt --> khi Xóa | Sửa
        /// </summary>
        private void gridMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = gridDMKho.CurrentCell.RowIndex;
            if (selectedRowCount >= 0 && PanelButton.isClickXoa() || PanelButton.isClickSua())
            {
                txtTenKho.Text = gridDMKho.Rows[selectedRowCount].Cells["Ten_kho"].Value.ToString();
            }
            // txtTenKho.Text = cell.Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (!PanelButton.isClickNone())
            {
                PanelButton.ResetClickStatus();

                PanelButton.ResetButton();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (PanelButton.isClickNone())
            {
                PanelButton.setClickThem();

                PanelButton.Enable_btn_Luu_Huy();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (PanelButton.isClickNone())
            {
                PanelButton.setClickXoa();

                PanelButton.Enable_btn_Luu_Huy();

                Int32 selectedRowCount = gridDMKho.CurrentCell.RowIndex;
                txtTenKho.Text = gridDMKho.Rows[selectedRowCount].Cells["Ten_kho"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (PanelButton.isClickNone())
            {
                PanelButton.setClickSua();

                PanelButton.Enable_btn_Luu_Huy();

                Int32 selectedRowCount = gridDMKho.CurrentCell.RowIndex;
                txtTenKho.Text = gridDMKho.Rows[selectedRowCount].Cells["Ten_kho"].Value.ToString();

            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

            LoadData();

            PanelButton.ResetButton();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
