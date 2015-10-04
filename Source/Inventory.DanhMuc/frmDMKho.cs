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
    public partial class frmDMKho : Form
    {
        //Dictionary<int, string> dic = new Dictionary<int, string>();

        enumStatus staTus = enumStatus.None;
        clsDM_Kho kho = new clsDM_Kho();

        public frmDMKho()
        {
            InitializeComponent();

            LoadData();
            if (staTus == enumStatus.None)
                btnLuu.Enabled = false;

        }
        public void LoadData()
        {
            gridMaster.DataSource = kho.GetAll();

        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (staTus == enumStatus.None)
            {
                staTus = enumStatus.Them;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = false;
                btnLuu.Enabled = true;
            }


        }

        

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (staTus)
            {

                case enumStatus.Them:
                    {

                        kho.Ten_kho = txtTenKho.Text.Trim();
                        if (!kho.CheckTonTaiSoDK()&& kho.Insert() == 1)
                        {
                            MessageBox.Show("Bạn đã thêm thành công !");
                            LoadData();
                            btnThem.Enabled = true;
                            btnSua.Enabled = true;
                            btnXoa.Enabled = true;
                            btnLamMoi.Enabled = true;
                            staTus = enumStatus.None;
                        }
                        else
                            MessageBox.Show("Bạn đã thêm thất bại!");
                        break;
                    }
                case enumStatus.Xoa:
                        {
                            kho.Ten_kho =txtTenKho.Text;
                            Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;
                            kho.ID_kho = int.Parse(gridMaster.Rows[selectedRowCount].Cells["id_kho"].Value.ToString());
                            DialogResult dialogResult = MessageBox.Show("Bạn có thật sự muốn xóa không ?", "Cảnh báo!", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                //do something
                                
                                if (kho.Delete() == 1)
                                {
                                    MessageBox.Show("Bạn đã xóa thành công !");
                                    LoadData();
                                    btnThem.Enabled = true;
                                    btnSua.Enabled = true;
                                    btnXoa.Enabled = true;
                                    btnLamMoi.Enabled = true;
                                    staTus = enumStatus.None;
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
                            kho.Ten_kho = txtTenKho.Text;
                             Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;
                             if (selectedRowCount >= 0)
                             {
                                 kho.ID_kho = int.Parse(gridMaster.Rows[selectedRowCount].Cells["id_kho"].Value.ToString());
                                 if (kho.Update() == 1)
                                 {
                                     MessageBox.Show("Bạn đã cập nhật thành công !");
                                     LoadData();
                                     btnThem.Enabled = true;
                                     btnSua.Enabled = true;
                                     btnXoa.Enabled = true;
                                     btnLamMoi.Enabled = true;
                                     staTus = enumStatus.None;
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (staTus != enumStatus.None)
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLamMoi.Enabled = true;
                staTus = enumStatus.None; btnLuu.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (staTus == enumStatus.None)
            {
                staTus = enumStatus.Xoa;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = false;
                
                btnLuu.Enabled = true;
            }
        }

        private void gridMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;
            if (selectedRowCount >= 0 && staTus == enumStatus.Xoa||staTus==enumStatus.Sua)
            {
                txtTenKho.Text = gridMaster.Rows[selectedRowCount].Cells["Ten_kho"].Value.ToString();

            }
            // txtTenKho.Text = cell.Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (staTus == enumStatus.None)
            {
                staTus = enumStatus.Sua;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = false; btnLuu.Enabled = true;
                Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;
                txtTenKho.Text = gridMaster.Rows[selectedRowCount].Cells["Ten_kho"].Value.ToString();

            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        
    }
}
