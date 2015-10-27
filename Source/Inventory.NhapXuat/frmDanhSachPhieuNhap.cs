﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
using Inventory.Models;

namespace Inventory.NhapXuat
{
    /// <summary>
    /// Ẩn sửa, xóa, save
    /// Chọn lưới --> Add thêm chi tiết --> link qua nhập kho
    /// Danh phiếu xuất --> tương tự, tùy theo DB
    /// ?
    /// 
    /// To-do LIST
    /// [?] Phần cls Data
    /// [?] Thêm -> Link qua
    /// [x] Xóa -> Disable
    /// [?] Sửa -> Link select
    /// [x] Refesh -> làm mới
    /// [x] Đóng -> use lib
    /// 
    /// *Problem
    /// [ ] Cách truyền dữ liệu sang frm Chi Tiết
    /// [ ] Khi Frm chi tiết -> close() -> refesh.
    /// [ ] Sửa -> Gọi DS frm Chi Tiết
    /// </summary>
    public partial class frmDanhSachPhieuNhap : Form
    {
        FormActionDelegate frmAction;
        clsPanelButton PanelButton;

        clsPhieuNhapKho phieuNhap;

        public frmDanhSachPhieuNhap()
        {
            InitializeComponent();
            phieuNhap = new clsPhieuNhapKho();

            //Init cls Button
            PanelButton = new clsPanelButton();

            frmAction = new FormActionDelegate(FormAction);
            PanelButton.setDelegateFormAction(frmAction);

            // btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            //enumButton dùng định danh button

            //PanelButton.AddButton(enumButton.Xoa, ref btnXoa);
            //PanelButton.AddButton(enumButton.Luu, ref btnLuu);
            //PanelButton.AddButton(enumButton.Huy, ref btnHuy);

            //PanelButton.AddButton(enumButton.Them, ref btnThem);
            //PanelButton.AddButton(enumButton.Sua, ref btnSua);



            PanelButton.AddButton(enumButton.LamMoi, ref btnLamMoi);
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
                    break;
                case enumFormAction.ResetInputForm:
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
            gridDanhSachPhieuNhap.DataSource = phieuNhap.GetAll();
     //       clsGiaoDienChung.initCombobox(cbKhoNhanVatTu, new clsDM_Kho(), "Ten_kho", "ID_kho", "Ten_kho");
            clsGiaoDienChung.initCombobox(cbbLoaiPhieu, new clsLoaiPhieuNhap(), "Ma_loai_phieu_nhap", "ID_loai_phieu_nhap", "Ma_loai_phieu_nhap");
       
        }

        public void CloseForm()
        {
            this.Close();
        }


        /// <summary>
        /// * Thêm
        /// - Gọi frm Chi Tiết
        /// 
        /// * Problem
        /// [ ] Refesh khi frm chi tiết đóng
        /// </summary>
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmNhapKho nhapkho = new frmNhapKho(enumButton2.Them, "");
            nhapkho.Show();

        }


        /// <summary>
        /// * Sửa
        /// - Gọi frm Chi Tiết ứng với row đã chọn
        /// 
        /// * problem
        /// [ ] Cách thức để gọi frm, nên dùng delegate, truyền sang mã phiếu, rồi call hàm Get data theo mã phiếu đó.
        /// </summary>
        private void btnSua_Click(object sender, EventArgs e)
        {
            /*Int32 selectedRowCount = gridDanhSachPhieuNhap.CurrentCell.RowIndex;

            clsPhieuNhapKho phieuNhap = new clsPhieuNhapKho();
            //phieuNhap.ID_phieu_nhap =int.Parse( gridMaster.Rows[selectedRowCount].Cells["ID_phieu_nhap"].Value.ToString());
            phieuNhap.ID_kho =int.Parse( gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["ID_kho"].Value.ToString());
            phieuNhap.Ngay_lap =DateTime.Parse( gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["Ngay_lap"].Value.ToString());
            phieuNhap.Ly_do =( gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["Ly_do"].Value.ToString());
            phieuNhap.So_hoa_don =( gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["So_hoa_don"].Value.ToString());
            */

            //DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieuNhap.ID_phieu_nhap);
            //for(int i =0;i<chiTietPhieuNhap.Rows.Count;i++)
            //{
            //    clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
            //    chitiet.ID_chi_tiet_phieu_nhap=int.Parse( chiTietPhieuNhap.Rows[i]["ID_chi_tiet_phieu_nhap"].ToString());
            //    chitiet.ID_phieu_nhap=int.Parse( chiTietPhieuNhap.Rows[i]["ID_phieu_nhap"].ToString());
            //    chitiet.ID_vat_tu=int.Parse( chiTietPhieuNhap.Rows[i]["ID_vat_tu"].ToString());
            //    chitiet.Chat_luong=( chiTietPhieuNhap.Rows[i]["Chat_luong"].ToString());
            //    chitiet.So_luong_yeu_cau=int.Parse( chiTietPhieuNhap.Rows[i]["So_luong_yeu_cau"].ToString());
            //    chitiet.So_luong_thuc_nhap=int.Parse( chiTietPhieuNhap.Rows[i]["So_luong_thuc_nhap"].ToString());
            //    phieuNhap.lstChiTietPhieuNhap.Add(chitiet);
            //}

            //  int id_PhieuNhap =int.Parse( gridMaster.Rows[selectedRowCount].Cells["ID_phieu_nhap"].Value.ToString());

            //  DataTable tbChiTiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(id_PhieuNhap);

            Int32 selectedRowCount = gridDanhSachPhieuNhap.CurrentCell.RowIndex;
            DataGridViewRow SelectedRow = gridDanhSachPhieuNhap.Rows[selectedRowCount];
            string strMaPhieuNhap = SelectedRow.Cells["Ma_phieu_nhap"].Value.ToString();
            if (clsPhieuNhapKho.KTVTChuaDuyet(strMaPhieuNhap) == true)// phieu nay da duyet 
            {
                MessageBox.Show("Phiếu nhập này đã được phân vào kho, không thể xóa");
                return;
            }
            //frmNhapKho nhapkho = new frmNhapKho(enumStatus.Sua,phieuNhap);
            //nhapkho.Show();

            frmNhapKho nhapkho = new frmNhapKho(enumButton2.Sua, strMaPhieuNhap);
            nhapkho.Show();
        }

        private void gridgridDanhSachPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /**
         * Khu vực event btn EnabledChanged
         */

        private void btnXoa_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.cancel_gmc;
            else
                b.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.cancel_disable;
        }

        private void btnLuu_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.save_bmc;
            else
                b.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.save_disable;
        }

        private void btnHuy_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.close_gmc;
            else
                b.BackgroundImage = global::Inventory.NhapXuat.Properties.Resources.close_disable;
        }

        private void gridDanhSachPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xoa();
            LoadData();

        }

        private void Xoa()
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập này không", "Cảnh báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // clsChi_Tiet_Phieu_Nhap_Vat_Tu pnvt = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
                //do something
                Int32 selectedRowCount = gridDanhSachPhieuNhap.CurrentCell.RowIndex;
                string maphieu = (gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["Ma_phieu_nhap"].Value.ToString());
                if (clsPhieuNhapKho.KTVTChuaDuyet(maphieu) == true)// phieu nay da duyet 
                {
                    MessageBox.Show("Phiếu nhập này đã được phân vào kho, không thể xóa");
                    return;
                }

                if (clsXuLyDuLieuChung.DeletePhieuNhap(maphieu) == 1)
                    MessageBox.Show("Bạn đã xóa thành công");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //    gridDanhSachPhieuNhap.Rows.Clear();
            try
            {
                if (rdoChuaDuyet.Checked == true)
                    gridDanhSachPhieuNhap.DataSource = phieuNhap.GetAll(false,cbbLoaiPhieu.SelectedValue.ToString());
                else
                    if (rdoDaDuyet.Checked == true)
                        gridDanhSachPhieuNhap.DataSource = phieuNhap.GetAll(true, cbbLoaiPhieu.SelectedValue.ToString());
                    else
                        gridDanhSachPhieuNhap.DataSource = phieuNhap.GetAll();
                this.gridDanhSachPhieuNhap.Refresh();
                this.gridDanhSachPhieuNhap.Parent.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDuyetPhieu_Click(object sender, EventArgs e)
        {
            XuLyNhap_Phieu();
            //  string soluong = SelectedRow.Cells["So_luong"].Value.ToString();

        }

        private void XuLyNhap_Phieu()
        {
            try
            {
                Int32 selectedRowCount = gridDanhSachPhieuNhap.CurrentCell.RowIndex;
                //   DataGridViewRow SelectedRow = gridDanhSachPhieuNhap.Rows[selectedRowCount];
                //  string mavt = SelectedRow.Cells["Ma_vat_tu"].Value.ToString
                string maphieu = gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["Ma_phieu_nhap"].Value.ToString();
                bool Da_phan_kho = bool.Parse(gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["Da_phan_kho"].Value.ToString());
                if (Da_phan_kho == true)
                {
                    MessageBox.Show("Phiếu này đã duyệt và phân kho ");
                    return;

                }

                int idKho = int.Parse(gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["ID_kho"].Value.ToString());
                int ID_loai_phieu_nhap = int.Parse(gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["ID_loai_phieu_nhap"].Value.ToString());
                clsLoaiPhieuNhap LPN = new clsLoaiPhieuNhap();
                LPN.ID_LPN = ID_loai_phieu_nhap;
                // lấy tất cả danh sách các vật tư có mã phiếu nhập đó
                DataTable tb = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(maphieu);
                DatabaseHelper help = new DatabaseHelper();
                help.ConnectDatabase();
                string TenLPN = LPN.getTenLPN(ID_loai_phieu_nhap);
                string setting = Properties.Settings.Default.PhieuNhap;

                using (var dbcxtransaction = help.ent.Database.BeginTransaction())
                {
                    if (TenLPN.Contains(setting) == true)
                    {
                        for (int i = 0; i < tb.Rows.Count; i++)
                        {
                            //duyệt qua từng dòng insert chi tiết phiếu nhập vào
                            clsXuLyDuLieuChung dc = new clsXuLyDuLieuChung();
                            string mavattu = tb.Rows[i]["ma_vat_tu"].ToString();

                            double soluong = double.Parse(tb.Rows[i]["so_luong_thuc_lanh"].ToString());
                            int id_chat_luong = int.Parse(tb.Rows[i]["Id_chat_luong"].ToString());

                            DateTime ngayNhap = DateTime.Now;

                            if (dc.InsertTonKho(help, mavattu, idKho, soluong, maphieu, ngayNhap, id_chat_luong, true) == 0)
                            {
                                dbcxtransaction.Rollback();
                            }

                        }

                        dbcxtransaction.Commit();
                        MessageBox.Show("Bạn đã thêm thành công !");
                    }
                    else
                    {
                        for (int i = 0; i < tb.Rows.Count; i++)
                        {
                            clsXuLyDuLieuChung dc = new clsXuLyDuLieuChung();
                            string mavattu = tb.Rows[i]["ma_vat_tu"].ToString();
                            //   int idKho = int.Parse(tb.Rows[i]["ID_kho"].ToString());
                            double soluong = double.Parse(tb.Rows[i]["so_luong_thuc_lanh"].ToString());
                            int id_chat_luong = int.Parse(tb.Rows[i]["Id_chat_luong"].ToString());

                            DateTime ngayNhap = DateTime.Now;

                            if (dc.InsertTonKho(help, mavattu, idKho, soluong, maphieu, ngayNhap, id_chat_luong, false) == 0)
                            {
                                dbcxtransaction.Rollback();
                            }
                        }
                    }
                }


                try
                {
                    LoadData();
                }
                catch (Exception ex) { }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    

    }
}
