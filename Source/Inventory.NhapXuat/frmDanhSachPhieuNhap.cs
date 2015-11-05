using System;
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
            //btnXemChiTiet.Enabled = false;
            btnHuy.Enabled = false;
            //enumButton dùng định danh button
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
            gridDanhSachPhieuNhap.DataSource = phieuNhap.SearchDSPN(null,"");
            //       clsGiaoDienChung.initCombobox(cbKhoNhanVatTu, new clsDM_Kho(), "Ten_kho", "ID_kho", "Ten_kho");
             clsGiaoDienChung.initCombobox(cbbKho, new clsDM_Kho(), "Ten_kho", "ID_kho", "Ten_kho");

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
          
            Int32 selectedRowCount = gridDanhSachPhieuNhap.CurrentCell.RowIndex;
            DataGridViewRow SelectedRow = gridDanhSachPhieuNhap.Rows[selectedRowCount];
            string strMaPhieuNhap = SelectedRow.Cells["Ma_phieu"].Value.ToString();
            if (clsPhieuNhapKho.KTVTChuaDuyet(strMaPhieuNhap) == true)// phieu nay da duyet 
            {
                MessageBox.Show("Phiếu nhập này đã được phân vào kho, không thể xóa");
                return;
            }
          
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
                string maphieu = (gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["Ma_phieu"].Value.ToString());
                if (clsPhieuNhapKho.KTVTChuaDuyet(maphieu) == true)// phieu nay da duyet 
                {
                    MessageBox.Show("Phiếu nhập này đã được xác nhận, không thể xóa");
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
                    gridDanhSachPhieuNhap.DataSource = phieuNhap.SearchDSPN(false,cbbKho.Text);
                else
                    if (rdoDaDuyet.Checked == true)
                        gridDanhSachPhieuNhap.DataSource = phieuNhap.SearchDSPN(true, cbbKho.Text);
                    else
                        gridDanhSachPhieuNhap.DataSource = phieuNhap.SearchDSPN(null, cbbKho.Text);
                this.gridDanhSachPhieuNhap.Refresh();
                // this.gridDanhSachPhieuNhap.Parent.Refresh();
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
                string maphieu = gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["Ma_phieu"].Value.ToString();
                int idKho = int.Parse(gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["ID_kho"].Value.ToString());
              
                bool Da_phan_kho = bool.Parse(gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["Da_phan_kho"].Value.ToString());
                if (Da_phan_kho == true)
                {
                    MessageBox.Show("Phiếu này đã duyệt và phân kho ");
                    return;
                }
                // lấy tất cả danh sách các vật tư có mã phiếu nhập đó
                DataTable tb = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(maphieu);
                DatabaseHelper help = new DatabaseHelper();
                help.ConnectDatabase();
                //nếu phiếu này là cấn trừ 
                //hiển thị form cấn trừ nợ cho vật tư 
               // bool? isCanTru = bool.Parse(gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["isCanTru"].Value.ToString());
                try
                {
                    bool? isCanTru = bool.Parse(gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["isCanTru"].Value.ToString());
                    if (isCanTru == true)
                    {
                        MessageBox.Show("Phiếu này đang ở trạng thái chưa bù trừ nợ, vui lòng thực hiện chức năng bù trừ nợ trước! ");
                        return;
                    }
                }
                catch (Exception ex) { }

                bool? isNhapNgoai = bool.Parse(gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["isNhapNgoai"].Value.ToString());
                if (isNhapNgoai == true)
                {
                    using (var dbcxtransaction = help.ent.Database.BeginTransaction())
                    {
                        for (int i = 0; i < tb.Rows.Count; i++)
                        {
                            clsXuLyDuLieuChung dc = new clsXuLyDuLieuChung();
                            string mavattu = tb.Rows[i]["ma_vat_tu"].ToString();
                            decimal soluong = decimal.Parse(tb.Rows[i]["so_luong_thuc_lanh"].ToString());
                            int id_chat_luong = int.Parse(tb.Rows[i]["Id_chat_luong"].ToString());
                            DateTime ngayNhap = DateTime.Now;
                            if (dc.InsertTonKho(help, mavattu, idKho, soluong, maphieu, ngayNhap, id_chat_luong, true) == 0)
                            {
                                dbcxtransaction.Rollback();
                            }

                        }
                        MessageBox.Show("Bạn đã xác nhận thành công ");
                        dbcxtransaction.Commit();
                        LoadData();
                    }
                    return;
                }
                int? ID_loai_phieu_nhap = int.Parse(gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["ID_loai_phieu_nhap"].Value.ToString());
                clsLoaiPhieuNhap LPN = new clsLoaiPhieuNhap();
                LPN.ID_LPN =(int) ID_loai_phieu_nhap;
                string TenLPN = LPN.getTenLPN((int)ID_loai_phieu_nhap);
                using (var dbcxtransaction = help.ent.Database.BeginTransaction())
                {
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        //duyệt qua từng dòng insert chi tiết phiếu nhập vào
                        clsXuLyDuLieuChung dc = new clsXuLyDuLieuChung();
                        string mavattu = tb.Rows[i]["ma_vat_tu"].ToString();
                        // số lượng hoàn nhập hay số lượng lãnh vật tư tùy vào ID loai phieu
                        decimal soluong = decimal.Parse(tb.Rows[i]["so_luong_thuc_lanh"].ToString());
                        int id_chat_luong = int.Parse(tb.Rows[i]["Id_chat_luong"].ToString());
                        DateTime ngayNhap = DateTime.Now;
                        try
                        {
                            bool isGoiDau = bool.Parse(gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["isGoiDau"].Value.ToString());
                            if (isGoiDau == true)
                            {
                                clsVatTuGoiDauKy gdk = new clsVatTuGoiDauKy();
                                gdk.ID_chat_luong = id_chat_luong;
                                gdk.Ma_vat_tu = mavattu;
                                gdk.So_Luong = soluong;
                                gdk.ID_kho = idKho;
                                if (gdk.CheckTonTaiSoDK() == true)
                                {
                                    //nếu có cập nhật lại gối đầu 
                                    DataTable temp = gdk.GetAll();
                                    decimal sl = decimal.Parse(temp.Rows[0]["So_luong"].ToString());
                                    gdk.ID_VT_Goi_Dau = int.Parse(temp.Rows[0]["ID_VT_Goi_Dau"].ToString());
                                    gdk.So_Luong = gdk.So_Luong + sl;
                                    gdk.Update();
                                }
                                //nếu chưa tồn tại tiến hành insert dòng mới 
                                else

                                    if (gdk.Insert() == 0)
                                    {
                                        MessageBox.Show("Đã có lỗi xãy ra !");
                                        return;
                                    }

                            }
                            // nếu mã phiếu hoàn nhập thì trừ trong gói đầu nếu có phiếu hoàn nhập mà chưa có gói đầu thì vô lý
                            if (TenLPN.Contains("T"))
                            {
                                clsVatTuGoiDauKy gdk = new clsVatTuGoiDauKy();

                                gdk.ID_chat_luong = id_chat_luong;
                                gdk.Ma_vat_tu = mavattu;

                                gdk.ID_kho = idKho;
                                DataTable temp = gdk.GetAll();
                                //số lượng gối đầu
                                if (temp.Rows.Count == 0)//chưa có 
                                {
                                    MessageBox.Show("Vật tư này chưa có trong danh sách vật tư gối đầu, không thể hoàn nhập được");
                                    return;
                                }
                                decimal soluonght = decimal.Parse(temp.Rows[0]["So_luong"].ToString());
                                soluonght = soluonght - soluong;
                                gdk.So_Luong = soluonght;
                                gdk.ID_VT_Goi_Dau = int.Parse(temp.Rows[0]["ID_VT_Goi_Dau"].ToString());
                                if (gdk.Update() == 0)
                                {
                                    MessageBox.Show("Đã có lỗi xãy ra trong quá trình cập nhật số lượng đầu kỳ!");
                                    return;
                                }
                                //sau đó trừ vào kho, thẻ kho 

                                //    MessageBox.Show("Hoàn nhập thành công!");
                                //    return; 

                            }
                        }
                        catch (Exception ex) { }

                        if (TenLPN.Contains("X") == true)
                        {

                            if (dc.InsertTonKho(help, mavattu, idKho, soluong, maphieu, ngayNhap, id_chat_luong, true) == 0)
                            {
                                dbcxtransaction.Rollback();
                            }



                        }
                        else
                        {
                            //CO MA PHIEU TD

                            //PHIEU TRU KHO
                            if (dc.InsertTonKho(help, mavattu, idKho, soluong, maphieu, ngayNhap, id_chat_luong, false) == 0)
                            {
                                dbcxtransaction.Rollback();
                            }


                        }
                    }
                    dbcxtransaction.Commit();
                    MessageBox.Show("Bạn đã thêm thành công !");
                }


            
                    LoadData();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex));
            }
        }

        private void btnTruNo_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = gridDanhSachPhieuNhap.CurrentCell.RowIndex;
            string maphieu = gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["Ma_phieu"].Value.ToString();
            bool? isCanTru = bool.Parse(gridDanhSachPhieuNhap.Rows[selectedRowCount].Cells["isCanTru"].Value.ToString());
            if (isCanTru == true)
            {
                frmBuTruPhieu butru = new frmBuTruPhieu(this,maphieu);
                butru.Show();
                return;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = gridDanhSachPhieuNhap.CurrentCell.RowIndex;
            DataGridViewRow SelectedRow = gridDanhSachPhieuNhap.Rows[selectedRowCount];
            string strMaPhieuNhap = SelectedRow.Cells["Ma_phieu"].Value.ToString();
            //string strMaPhieuNhap = SelectedRow.Cells["Ma_phieu"].Value.ToString();
            bool isNhapNgoai = (bool)SelectedRow.Cells["isNhapNgoai"].Value;
            if (isNhapNgoai == true)
            {
                frmNhapKhoToTrinh frmTT = new frmNhapKhoToTrinh(enumButton2.None, strMaPhieuNhap);
                frmTT.Show();
            }
            else{
            frmNhapKho nhapkho = new frmNhapKho(enumButton2.None, strMaPhieuNhap);
            nhapkho.Show();
        }}


    }
}
