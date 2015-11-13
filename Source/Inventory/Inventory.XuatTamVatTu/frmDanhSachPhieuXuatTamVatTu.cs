using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory.EntityClass;

namespace Inventory.XuatTamVatTu
{
    public partial class frmDanhSachPhieuXuatTamVatTu : Form
    {
        FormActionDelegate2 frmAction;
        clsPanelButton2 PanelButton;

        clsPhieuXuatTamVatTu PhieuXuatTam;

        public frmDanhSachPhieuXuatTamVatTu()
        {
            InitializeComponent();

            PhieuXuatTam = new clsPhieuXuatTamVatTu();

            //Init cls Button
            PanelButton = new clsPanelButton2();

            frmAction = new FormActionDelegate2(FormAction);
            PanelButton.setDelegateFormAction(frmAction);

            PanelButton.AddButton(enumButton2.Them, ref btnThem);
            PanelButton.AddButton(enumButton2.Xoa, ref btnXoa);
            PanelButton.AddButton(enumButton2.Sua, ref btnSua);
            PanelButton.AddButton(enumButton2.LamMoi, ref btnLamMoi);
            PanelButton.AddButton(enumButton2.Luu, ref btnLuu);
            PanelButton.AddButton(enumButton2.Huy, ref btnHuy);

            PanelButton.AddButton(enumButton2.Dong, ref btnDong);

            PanelButton.setButtonClickEvent(enumButton2.Dong);
            PanelButton.setButtonClickEvent(enumButton2.LamMoi);

            PanelButton.setButtonStatus(enumButton2.Xoa, false);
            PanelButton.setButtonStatus(enumButton2.Luu, false);
            PanelButton.setButtonStatus(enumButton2.Huy, false);
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            PanelButton.ResetButton();

            LoadData();
            InitCombo();
        }
        public void InitCombo()
        {
            clsGiaoDienChung.initCombobox(cbbMNV, new clsDM_NhanVien(), "Ma_nhan_vien", "ID_nhan_vien", "Ma_nhan_vien");
            clsGiaoDienChung.initCombobox(cbbTenNV, new clsDM_NhanVien(), "Ten_nhan_vien", "ID_nhan_vien", "Ten_nhan_vien");

           
        }
        public void FormAction(enumFormAction2 frmAct)
        {
            switch (frmAct)
            {
                case enumFormAction2.None:
                    break;
                case enumFormAction2.LoadData:
                    LoadData();
                    break;
                case enumFormAction2.CloseForm:
                    CloseForm();
                    break;
                case enumFormAction2.setFormData:
                    break;
                case enumFormAction2.ResetInputForm:
                    break;
                case enumFormAction2.Huy:
                    break;
                case enumFormAction2.Dong:
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
            gridDanhSachPhieuXuatTam.DataSource = PhieuXuatTam.GetAll_DSPhieuXuat("","");
        }

        public void CloseForm()
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 selectedRowCount = gridDanhSachPhieuXuatTam.CurrentCell.RowIndex;
                DataGridViewRow SelectedRow = gridDanhSachPhieuXuatTam.Rows[selectedRowCount];
                string Ma_phieu_xuat_tam = SelectedRow.Cells["Ma_phieu_xuat_tam"].Value.ToString();

                //frmChiTietPhieuXuatTam ChiTietPhieuXuatTam = new frmChiTietPhieuXuatTam(enumButton2.Sua, Ma_phieu_xuat_tam);
                //ChiTietPhieuXuatTam.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //frmChiTietPhieuXuatTam ChiTietPhieuXuatTam = new frmChiTietPhieuXuatTam(enumButton2.Them, "");
            //ChiTietPhieuXuatTam.Show();
        }

        private void btnLocLuoi_Click(object sender, EventArgs e)
        {
            gridDanhSachPhieuXuatTam.DataSource = PhieuXuatTam.GetAll_DSPhieuXuat(cbbMNV.Text, cbbTenNV.Text);
        }

        private void btnBaoGiuLai_Click(object sender, EventArgs e)
        {
            if (gridDanhSachPhieuXuatTam.RowCount == 0)
            {
                return;
            }

            Int32 selectedRowCount = gridDanhSachPhieuXuatTam.CurrentRow.Index; // CurrentCell.RowIndex;
            string MaPhieuXuat;

            if (selectedRowCount >= 0)
            {
                MaPhieuXuat = gridDanhSachPhieuXuatTam.Rows[selectedRowCount].Cells["Ma_phieu_xuat_tam"].Value.ToString();
                frmChiTietPhieuXuatTam frm = new frmChiTietPhieuXuatTam(MaPhieuXuat, enumButton2.BaoGiuLai);

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this.ParentForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnBaoHoanNhap_Click(object sender, EventArgs e)
        {
            if (gridDanhSachPhieuXuatTam.RowCount == 0)
            {
                return;
            }

            Int32 selectedRowCount = gridDanhSachPhieuXuatTam.CurrentRow.Index; // CurrentCell.RowIndex;
            string MaPhieuXuat;

            if (selectedRowCount >= 0)
            {
                MaPhieuXuat = gridDanhSachPhieuXuatTam.Rows[selectedRowCount].Cells["Ma_phieu_xuat_tam"].Value.ToString();
                frmChiTietPhieuXuatTam frm = new frmChiTietPhieuXuatTam(MaPhieuXuat, enumButton2.BaoHoanNhap);

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this.ParentForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }
        public void LoadInitGridMaster()
        {
            Int32 selectedRowCount = gridDanhSachPhieuXuatTam.CurrentCell.RowIndex;
            DataGridViewRow SelectedRow = gridDanhSachPhieuXuatTam.Rows[selectedRowCount];
            string strMaPhieuNhap = SelectedRow.Cells["Ma_phieu_xuat_tam"].Value.ToString();
         //   bool daduyet = bool.Parse(SelectedRow.Cells["Da_phan_kho"].Value.ToString());

            gridMaster.DataSource = new clsChiTietPhieuXuatTam().getAll_toGrid(strMaPhieuNhap);
        }
        private void gridDanhSachPhieuXuatTam_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                LoadInitGridMaster();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
