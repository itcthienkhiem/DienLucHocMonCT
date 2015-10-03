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

        enumStatus status = enumStatus.None;
        //clsDMVatTu DM_VatTu = new clsDMVatTu();

        clsDM_NhanVien DM_NhanVien = new clsDM_NhanVien();

        public frmDMNhanVien()
        {
            InitializeComponent();

            //Init
            LoadData();

            DM_NhanVien.GetDonViTinh();
            cboTenKho.DataSource = new BindingSource(DM_NhanVien.dicKho, null);
            cboTenKho.DisplayMember = "Key";
            cboTenKho.ValueMember = "Value";

            if (status == enumStatus.None)
                btnLuu.Enabled = false;
        }

        /// <summary>
        /// Re-Load ALL DATA to Grid
        /// </summary>
        public void LoadData()
        {
            gridDMNhanVien.DataSource = DM_NhanVien.GetAll();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (status)
            {

                case enumStatus.Them:
                    {

                        DM_NhanVien.Ten_nhan_vien = txtTenNhanVien.Text.Trim();
                        DM_NhanVien.ID_kho = Int32.Parse(cboTenKho.SelectedValue.ToString());
                        DM_NhanVien.Trang_thai = cbTrangThai.Checked;


                        if (!DM_NhanVien.Checkduplicaterows())
                        {
                            if (DM_NhanVien.Insert() == 1)
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
                        DM_NhanVien.Ten_nhan_vien = txtTenNhanVien.Text.Trim();
                        DM_NhanVien.ID_kho = Int32.Parse(cboTenKho.SelectedValue.ToString());
                        DM_NhanVien.Trang_thai = cbTrangThai.Checked;

                        Int32 selectedRowCount = gridDMNhanVien.CurrentCell.RowIndex;

                        if (selectedRowCount >= 0)
                        {
                            DM_NhanVien.ID_nhan_vien = Int32.Parse(gridDMNhanVien.Rows[selectedRowCount].Cells["ID_nhan_vien"].Value.ToString());

                            if (DM_NhanVien.Update() == 1)
                            {
                                MessageBox.Show("Bạn đã cập nhật thành công !");
                                LoadData();
                                btnThem.Enabled = true;
                                btnSua.Enabled = true;
                                btnXoa.Enabled = true;
                                btnLamMoi.Enabled = true;
                                status = enumStatus.None;

                                txtTenNhanVien.Text = "";
                                cbTrangThai.Checked = false;
                                cboTenKho.SelectedIndex = 1;
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

                Int32 selectedRowCount = gridDMNhanVien.CurrentCell.RowIndex;

                DataGridViewRow SelectedRow = gridDMNhanVien.Rows[selectedRowCount];

                txtTenNhanVien.Text = SelectedRow.Cells["Ten_nhan_vien"].Value.ToString();
                cbTrangThai.Checked = bool.Parse(SelectedRow.Cells["Trang_thai"].Value.ToString());

                cboTenKho.SelectedValue = (int)DM_NhanVien.dicKho[SelectedRow.Cells["Ten_kho"].Value.ToString()];

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
