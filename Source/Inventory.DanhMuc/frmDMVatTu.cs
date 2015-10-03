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
        enumStatus status = enumStatus.None;
        clsDMVatTu DM_VatTu = new clsDMVatTu();


        public frmDMVatTu()
        {
            InitializeComponent();

            //Init
            LoadData();

            DM_VatTu.GetDonViTinh();
            cboDonViTinh.DataSource = new BindingSource(DM_VatTu.dicDonViTinh, null);
            cboDonViTinh.DisplayMember = "Key";
            cboDonViTinh.ValueMember = "Value";

            DM_VatTu.Selected_DonViTinh = (int)cboDonViTinh.SelectedValue;

            if (status == enumStatus.None)
                btnLuu.Enabled = false;

        }

        /// <summary>
        /// Re-Load ALL DATA to Grid
        /// </summary>
        public void LoadData()
        {
            gridDMVatTu.DataSource = DM_VatTu.GetAll();
        }

        /// <summary>
        /// Coding...............
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

                Int32 selectedRowCount = gridDMVatTu.CurrentCell.RowIndex;

                DataGridViewRow SelectedRow = gridDMVatTu.Rows[selectedRowCount];

                txtTenVatTu.Text = SelectedRow.Cells["Ten_vat_tu"].Value.ToString();
                txtMaVatTu.Text = SelectedRow.Cells["Ma_vat_tu"].Value.ToString();
                txtMoTa.Text = SelectedRow.Cells["Mo_ta"].Value.ToString();

                cboDonViTinh.SelectedValue = (int)DM_VatTu.dicDonViTinh[SelectedRow.Cells["Ten_don_vi_tinh"].Value.ToString()];
                
                //Maybe remove
                DM_VatTu.Selected_DonViTinh = (int)cboDonViTinh.SelectedValue;
                

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (status)
            {

                case enumStatus.Them:
                    {

                        DM_VatTu.Ma_vat_tu = txtMaVatTu.Text.Trim();
                        DM_VatTu.Ten_vat_tu = txtTenVatTu.Text.Trim();
                        DM_VatTu.ID_Don_vi_tinh = Int32.Parse(cboDonViTinh.SelectedValue.ToString());
                        DM_VatTu.Mo_ta = txtMoTa.Text.Trim();


                        if (!DM_VatTu.Checkduplicaterows())
                        {
                            if (DM_VatTu.Insert() == 1)
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
                        DM_VatTu.Ma_vat_tu = txtMaVatTu.Text;

                        Int32 selectedRowCount = gridDMVatTu.CurrentCell.RowIndex;
                        DM_VatTu.Ma_vat_tu = gridDMVatTu.Rows[selectedRowCount].Cells["Ma_vat_tu"].Value.ToString();
                        DialogResult dialogResult = MessageBox.Show("Bạn có thật sự muốn xóa không ?", "Cảnh báo!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something

                            if (DM_VatTu.Delete() == 1)
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
                                MessageBox.Show("Bạn đã cập nhật thành công !");
                                LoadData();
                                btnThem.Enabled = true;
                                btnSua.Enabled = true;
                                btnXoa.Enabled = true;
                                btnLamMoi.Enabled = true;
                                status = enumStatus.None;

                                txtMaVatTu.Text = "";
                                txtTenVatTu.Text = "";
                                txtMoTa.Text = "";
                                cboDonViTinh.SelectedIndex = 1;
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

        private void gridDMVatTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
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

        private void cboDonViTinh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Maybe remove
            DM_VatTu.Selected_DonViTinh = (int)cboDonViTinh.SelectedValue;
        }
    }
}
