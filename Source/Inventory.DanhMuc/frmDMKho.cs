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
    /// * Problem
    /// [ ] Bỏ tính năng xóa trực tiếp, chuyển dùng biến trạng thái.
    /// [ ] ?
    /// </summary>
    public partial class frmDMKho : Form
    {
        //Dictionary<int, string> dic = new Dictionary<int, string>();

        enumStatus status = enumStatus.None;
        clsDM_Kho DM_Kho = new clsDM_Kho();

        public frmDMKho()
        {
            InitializeComponent();

            LoadData();
            ResetButton();
        }


        public void LoadData()
        {
            gridDMKho.DataSource = DM_Kho.GetAll();
        }

        public void ResetButton()
        {
            if (status == enumStatus.None)
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnLamMoi.Enabled = true;

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
        }
        
        


        /// <summary>
        /// ~
        /// </summary>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (status)
            {
                case enumStatus.Them:
                    {

                        DM_Kho.Ten_kho = txtTenKho.Text.Trim();
                        if (!DM_Kho.CheckTonTaiSoDK()&& DM_Kho.Insert() == 1)
                        {
                            MessageBox.Show("Bạn đã thêm thành công !");

                            //Reset status
                            status = enumStatus.None;
                            LoadData();
                            ResetButton();

                            //Reset input
                            txtTenKho.Text = "";
                            
                        }
                        else
                            MessageBox.Show("Bạn đã thêm thất bại!");
                        break;
                    }
                case enumStatus.Xoa:
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
                                    status = enumStatus.None;
                                    LoadData();
                                    ResetButton();
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
                case enumStatus.Sua:
                        {
                            DM_Kho.Ten_kho = txtTenKho.Text;
                             Int32 selectedRowCount = gridDMKho.CurrentCell.RowIndex;
                             if (selectedRowCount >= 0)
                             {
                                 DM_Kho.ID_kho = int.Parse(gridDMKho.Rows[selectedRowCount].Cells["id_kho"].Value.ToString());
                                 if (DM_Kho.Update() == 1)
                                 {
                                     MessageBox.Show("Bạn đã cập nhật thành công !");

                                     //Reset stt
                                     status = enumStatus.None;
                                     LoadData();
                                     ResetButton();
                                     
                                     //Reset input
                                     txtTenKho.Text = "";
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
            if (selectedRowCount >= 0 && status == enumStatus.Xoa || status == enumStatus.Sua)
            {
                txtTenKho.Text = gridDMKho.Rows[selectedRowCount].Cells["Ten_kho"].Value.ToString();
            }
            // txtTenKho.Text = cell.Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (status != enumStatus.None)
            {
                status = enumStatus.None;

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLamMoi.Enabled = true;

                btnHuy.Enabled = true;
                btnLuu.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (status == enumStatus.None)
            {
                status = enumStatus.Them;

                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = false;

                btnHuy.Enabled = true;
                btnLuu.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (status == enumStatus.None)
            {
                status = enumStatus.Xoa;

                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnLamMoi.Enabled = false;
                
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }
        }

        
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (status == enumStatus.None)
            {
                status = enumStatus.Sua;

                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = false;
                
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;

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

            ResetButton();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*
         [x] Add ICON khi Enable & Disable
         */
        private void btnThem_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.addFile_omc;
            else
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.addFile_disable;
        }

        private void btnXoa_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.cancel_gmc;
            else
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.cancel_disable;
        }

        private void btnSua_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.edit_gmc;
            else
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.edit_disable;
        }

        private void btnLamMoi_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.refresh_omc;
            else
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.refresh_disable;
        }

        private void btnHuy_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.close_gmc;
            else
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.close_disable;
        }

        private void btnLuu_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.save_bmc;
            else
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.save_disable;
        }
        /*
         END. --> Add ICON khi Enable & Disable
         */
    }
}
