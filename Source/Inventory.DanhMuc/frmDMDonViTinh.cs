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
    /// - Button nên có 2 màu, 1 enable, 1 Disable
    /// </summary>
    public partial class frmDMDonViTinh : Form
    {
        enumStatus status = enumStatus.None;
        
        clsDM_DonViTinh DM_DonViTinh = new clsDM_DonViTinh();


        public frmDMDonViTinh()
        {
            InitializeComponent();

            LoadData();

            if (status == enumStatus.None)
                btnLuu.Enabled = false;
        }

        public void LoadData()
        {
            gridDMDonViTinh.DataSource = DM_DonViTinh.GetAll();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (status)
            {

                case enumStatus.Them:
                    {
                        DM_DonViTinh.Ten_don_vi_tinh = txtTenDonVi.Text.Trim();

                        if (!DM_DonViTinh.Checkduplicaterows())
                        {
                            if (DM_DonViTinh.Insert() == 1)
                            {
                                MessageBox.Show("Bạn đã thêm thành công !");

                                LoadData();

                                btnThem.Enabled = true;
                                btnSua.Enabled = true;
                                btnXoa.Enabled = true;
                                btnLamMoi.Enabled = true;

                                status = enumStatus.None;
                            }
                            else
                                MessageBox.Show("Bạn đã thêm thất bại!");
                        }
                        else
                            MessageBox.Show("Bạn đã thêm thất bại!");
                        break;
                    } // End Them
                case enumStatus.Xoa:
                    {
                        Int32 selectedRowCount = gridDMDonViTinh.CurrentCell.RowIndex;
                        DM_DonViTinh.ID_Don_vi_tinh = Int32.Parse(gridDMDonViTinh.Rows[selectedRowCount].Cells["ID_Don_vi_tinh"].Value.ToString());

                        DialogResult dialogResult = MessageBox.Show("Bạn có thật sự muốn xóa không ?", "Cảnh báo!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something

                            if (DM_DonViTinh.Delete() == 1)
                            {
                                MessageBox.Show("Bạn đã xóa thành công !");

                                LoadData();

                                btnThem.Enabled = true;
                                btnSua.Enabled = true;
                                btnXoa.Enabled = true;
                                btnLamMoi.Enabled = true;

                                status = enumStatus.None;
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
                case enumStatus.Sua:
                    {
                        DM_DonViTinh.Ten_don_vi_tinh = txtTenDonVi.Text.Trim();

                        Int32 selectedRowCount = gridDMDonViTinh.CurrentCell.RowIndex;
                        if (selectedRowCount >= 0)
                        {
                            DM_DonViTinh.ID_Don_vi_tinh = Int32.Parse(gridDMDonViTinh.Rows[selectedRowCount].Cells["ID_Don_vi_tinh"].Value.ToString());

                            if (DM_DonViTinh.Update() == 1)
                            {
                                MessageBox.Show("Bạn đã cập nhật thành công !");
                                LoadData();
                                btnThem.Enabled = true;
                                btnSua.Enabled = true;
                                btnXoa.Enabled = true;
                                btnLamMoi.Enabled = true;
                                status = enumStatus.None;

                                txtTenDonVi.Text = "";
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

                Int32 selectedRowCount = gridDMDonViTinh.CurrentCell.RowIndex;

                DataGridViewRow SelectedRow = gridDMDonViTinh.Rows[selectedRowCount];

                txtTenDonVi.Text = SelectedRow.Cells["Ten_don_vi_tinh"].Value.ToString();


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

                btnLuu.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (status == enumStatus.None)
            {
                status = enumStatus.Xoa;

                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnLamMoi.Enabled = true;

                btnLuu.Enabled = true;
            }
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            if (status != enumStatus.None)
            {
                status = enumStatus.None;

                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnLamMoi.Enabled = true;
                btnLuu.Enabled = true;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
