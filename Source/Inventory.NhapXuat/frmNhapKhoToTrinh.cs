using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
using Inventory.Report;
using Inventory.Models;
namespace Inventory.NhapXuat
{
    /// <summary>
    /// To-do LIST
    /// [ ] Load frm --> Chưa biết mã phiếu nhập | biết mã phiếu nhập && status Sửa?
    /// [ ] Load frm mặc định disable 1 số component --> Load Init from component
    /// [ ] 
    /// [ ] 
    /// [ ] 
    /// [ ] 
    /// </summary>
    public partial class frmNhapKhoToTrinh : Form
    {

        // Dictionary<string, clsDMVatTu> Dic = new Dictionary<string, clsDMVatTu>();

        //    Dictionary<string, clsDMVatTu> DicTen = new Dictionary<string, clsDMVatTu>();
        //  DataTable data = new DataTable();

        public int id_kho_phu;
        public frmNhapKhoToTrinh()
        {
            InitializeComponent();

            //Setup một số component
            InitFormComponent();
        }

        /// <summary>
        /// Call form theo tham số.
        /// </summary>
        /// <param name="stt">enumButton2</param>
        /// <param name="Ma_Phieu_Nhap">str Mã phiếu nhập.</param>
        public frmNhapKhoToTrinh(enumButton2 stt, int id_Kho_Phu)
        {
            InitializeComponent();

            //Setup một số component
            InitFormComponent();

            if (stt == enumButton2.Sua)
            {

                this.id_kho_phu = id_kho_phu;
                btnSua_Click(this, EventArgs.Empty);
            }
            else if (stt == enumButton2.Them)
            {
                btnThem_Click(this, EventArgs.Empty);
            }
        }

        public frmNhapKhoToTrinh(enumStatus status, clsPhieuNhapKho phieunhap)
        {
            try
            {
                InitializeComponent();

                InitFormComponent();

                //this.staTus = status;
                PanelButton.setClickStatus((enumButton2)status);

                //if (status == enumStatus.Sua || status == enumStatus.Xoa)
                if (PanelButton.isClickSua() || PanelButton.isClickXoa())
                {
                    this.phieuNhapKho = phieunhap;

                    DataTable chiTietPhieuNhap = (DataTable)new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieunhap.Ma_phieu_nhap);
                    gridMaster.DataSource = chiTietPhieuNhap;
                    //chitiet.get
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex));
            }
        }


        clsPhieuNhapKho phieuNhapKho = new clsPhieuNhapKho();
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (PanelButton.isClickNone())
            {
                PanelButton.setClickThem();

                PanelButton.Enable_btn_Luu_Huy();

                //reset for input
                enableInputForm();
                ResetInputForm();
                //txtXuatTaiKho.Enabled = true;
            }

        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text.Trim() == "")
            {
                MessageBox.Show("Mã phiếu bắt buộc nhập!");
                return;
            }
            if (cbKhoNhan.Text == "")
            {
                MessageBox.Show("Chưa nhập kho hoặc mã phiếu");
                return;
            }

            SQLDAL DAL = new SQLDAL();
            DAL.BeginTransaction();

            //switch (staTus)
            switch (PanelButton.getClickStatus())
            {

                #region "Thêm"
                case enumButton2.Them:
                    try
                    {
                        DatabaseHelper help = new DatabaseHelper();
                        help.ConnectDatabase();
                        using (var dbcxtransaction = help.ent.Database.BeginTransaction())
                        {
                            clsKhoPhu phieunhap = new clsKhoPhu();
                            phieunhap.ID_kho_chinh = (int)cbKhoNhan.SelectedValue;
                            phieunhap.So_chung_tu = txtMaPhieu.Text;
                            phieunhap.Ly_do = txtLyDo.Text;
                            phieunhap.Ngay_nhap = dtNgayNhap.Value;

                            phieunhap.Ten_phieu = txtTenPhieu.Text;
                         
                            if (phieunhap.Insert(help) == 1)
                            {

                                //DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieuNhap.ID_phieu_nhap);
                                for (int i = 0; i < dataTable1.Rows.Count; i++)
                                {
                                    clsChi_Tiet_Kho_Phu chitiet = new clsChi_Tiet_Kho_Phu();
                                    //    chitiet.ID_chi_tiet_phieu_nhap = int.Parse(gridMaster.Rows[i].Cells["ID_chi_tiet_phieu_nhap"].ToString());
                                    chitiet.Ma_vat_tu = (txtMaPhieu.Text);
                                    chitiet.ID_don_vi_tinh = int.Parse(dataTable1.Rows[i]["ID_Don_vi_tinh"].ToString());
                                    chitiet.Ma_vat_tu = (dataTable1.Rows[i]["Ma_vat_tu"].ToString());
                                    chitiet.ID_chat_luong = int.Parse(dataTable1.Rows[i]["ID_Chat_luong"].ToString());
                                     chitiet.So_luong = decimal.Parse(dataTable1.Rows[i]["so_luong_thuc_lanh"].ToString());
                                     chitiet.Don_gia = decimal.Parse(dataTable1.Rows[i]["Don_gia"].ToString());
                                    chitiet.Thanh_tien = decimal.Parse(dataTable1.Rows[i]["Thanh_tien"].ToString());


                                    if (chitiet.Insert(help) == 0)
                                    {
                                        dbcxtransaction.Rollback();
                                        MessageBox.Show("Thêm thất bại!");
                                        break;
                                    }

                                }



                                PanelButton.ResetClickStatus();

                                //setInputComponentStatus(true);
                                enableInputForm();

                                PanelButton.ResetButton();
                                id_kho_phu = phieunhap.ID_kho_phu;
                            }
                            else
                                DAL.RollbackTransaction();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex));
                        DAL.RollbackTransaction();
                    }
                    break;
                #endregion
                #region "Sua"
                case enumButton2.Sua:
                    {
                        DatabaseHelper help = new DatabaseHelper();
                        help.ConnectDatabase();
                        using (var dbcxtransaction = help.ent.Database.BeginTransaction())
                        {
                            try
                            {
                                clsKhoPhu phieunhap = new clsKhoPhu();
                                phieunhap .ID_kho_phu = 
                                phieunhap.ID_kho_chinh =(int) cbKhoNhan.SelectedValue;
                                {

                                    // phieunhap.

                                    //       phieunhap.ID_Loai_Phieu_Nhap = Int32.Parse(cbLoaiPhieuNhan.SelectedValue.ToString());
                                    phieunhap.So_chung_tu = txtMaPhieu.Text;
                                    phieunhap.Ly_do = txtLyDo.Text;
                                    phieunhap.Ngay_nhap = dtNgayNhap.Value;

                                    phieunhap.Ten_phieu = txtTenPhieu.Text;

                                 //   DataTable temp = phieunhap.GetThongTinPhieuNhap(phieunhap.Ma_phieu_nhap);
                                    Kho_phu nk = new Kho_phu();

                                    nk.ID_kho_chinh = phieunhap.ID_kho_chinh;


                                    nk.So_chung_tu = phieunhap.So_chung_tu;
                                    nk.Ly_do = phieunhap.Ly_do;
                                    nk.Ngay_nhap = phieunhap.Ngay_nhap;
                                    nk.Ten_phieu = phieunhap.Ten_phieu;
                                   
                                    //   nk.isGoiDau = chbNGD.Checked;
                                    if (phieunhap.Update(nk) == 1)
                                    {

                                        clsChi_Tiet_Kho_Phu pn = new clsChi_Tiet_Kho_Phu();
                                        pn.ID_kho_phu =id_kho_phu;

                                        pn.Delete(help,pn.ID_kho_phu);
                                        for (int i = 0; i < dataTable1.Rows.Count; i++)
                                        {

                                            clsChi_Tiet_Kho_Phu chitiet = new clsChi_Tiet_Kho_Phu();
                                            chitiet.ID_kho_phu =id_kho_phu;
                                            chitiet.ID_don_vi_tinh = int.Parse(dataTable1.Rows[i]["ID_Don_vi_tinh"].ToString());
                                            chitiet.Ma_vat_tu = (dataTable1.Rows[i]["Ma_vat_tu"].ToString());
                                            chitiet.ID_chat_luong = int.Parse(dataTable1.Rows[i]["ID_Chat_luong"].ToString());
                                        //    chitiet.So_luong_yeu_cau = decimal.Parse(dataTable1.Rows[i]["So_luong_yeu_cau"].ToString());
                                            chitiet.So_luong = decimal.Parse(dataTable1.Rows[i]["so_luong_thuc_lanh"].ToString());
                                            chitiet.Don_gia = decimal.Parse(dataTable1.Rows[i]["Don_gia"].ToString());
                                            chitiet.Thanh_tien = decimal.Parse(dataTable1.Rows[i]["Thanh_tien"].ToString());
                                        //    chitiet.Da_duyet = false;
                                           // chitiet.ID_chat_luong = int.Parse(cbChatLuong.SelectedValue.ToString());
                                            if (chitiet.Insert(help) == 0)
                                            {
                                                MessageBox.Show("Chỉnh sửa thất bại!");
                                                dbcxtransaction.Rollback();
                                                break;
                                            }
                                        }


                                        PanelButton.ResetClickStatus();

                                        //setInputComponentStatus(true);
                                        enableInputForm();

                                        PanelButton.ResetButton();
                                    }
                                    else
                                        DAL.RollbackTransaction();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex));
                                DAL.RollbackTransaction();
                            }
                        }
                        break;
                    }
                #endregion

            }
        }

        //Còn lỗi, add lập lại số dòng vào lưới.
        private void button2_Click(object sender, EventArgs e)
        {
            //initEdit();
            ResetInputFormForCheck();

            if (initEdit() == true)
            {
                //MessageBox.Show("Tồn tại mã phiếu nhập trong csdl");
            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnHuy.Enabled = true;
                // MessageBox.Show("Mã phiếu nhập không tồn tại trong csdl!");
            }
        }

        private bool initEdit()
        {
            try
            {



                clsPhieuNhapKho clsNhap = new clsPhieuNhapKho();

                clsNhap.Ma_phieu_nhap = txtMaPhieu.Text;

                if (clsNhap.CheckTonTaiSoDK(txtMaPhieu.Text) == true)
                {

                    DataTable tb = clsNhap.GetAll(txtMaPhieu.Text.Trim());
                    // dtNgayNhap.Text = tb.Rows[0]["Ngay_nhap"].ToString();
                    dtNgayNhap.CustomFormat = "dd-MM-yyyy";
                    dtNgayNhap.Value = Convert.ToDateTime(tb.Rows[0]["Ngay_lap"].ToString());
                    // dtNgayNhap.Text = string.Format("{0:dd/MM/yyyy}", tb.Rows[0]["Ngay_lap"]);

                    txtLyDo.Text = tb.Rows[0]["Ly_do"].ToString();
                    //   txtXuatTaiKho.Text = tb.Rows[0]["ID_kho"].ToString();
                    txtTenPhieu.Text = tb.Rows[0]["cong_trinh"].ToString();
                    cbKhoNhan.Text = tb.Rows[0]["Ten_kho"].ToString();
                 //   txtDiaChi.Text = tb.Rows[0]["Dia_chi"].ToString();


                    clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
                    DataTable vChiTiet = (DataTable)chitiet.GetAll(txtMaPhieu.Text);
                    for (int i = 0; i < vChiTiet.Rows.Count; i++)
                    {
                        //  dataTable1.Rows[i]["Ma_phieu_nhap"] = vChiTiet.Rows[i]["ma_phieu_nhap"].ToString();

                        DataRow dr = dataTable1.NewRow();
                        //dr["Ma_vat_tu"] = vChiTiet.Rows[i]["ma_phieu_nhap"].ToString();
                        dr["ma_vat_tu"] = vChiTiet.Rows[i]["ma_vat_tu"].ToString();
                        dr["Ten_vat_tu"] = vChiTiet.Rows[i]["Ten_vat_tu"].ToString();
                        //  dr["don_vi_tinh"] = vChiTiet.Rows[i]["don_vi_tinh"].ToString() ;
                        // dr["chat_luong"] = vChiTiet.Rows[i]["chat_luong"].ToString();
                        dr["ID_chat_luong"] = vChiTiet.Rows[i]["ID_chat_luong"].ToString();
                        dr["so_luong_yeu_cau"] = vChiTiet.Rows[i]["so_luong_yeu_cau"].ToString();
                        dr["so_luong_thuc_lanh"] = vChiTiet.Rows[i]["so_luong_thuc_lanh"].ToString();
                        dr["don_gia"] = vChiTiet.Rows[i]["don_gia"].ToString();
                        dr["Thanh_tien"] = vChiTiet.Rows[i]["thanh_tien"].ToString();// int.Parse(vChiTiet.Rows[i]["don_gia"].ToString()) * int.Parse(vChiTiet.Rows[i]["so_luong_thuc_lanh"].ToString());
                        dr["Ten_Don_vi_tinh"] = vChiTiet.Rows[i]["ten_don_vi_tinh"].ToString();
                        dr["ID_Don_vi_tinh"] = vChiTiet.Rows[i]["ID_don_vi_tinh"].ToString();

                        dataTable1.Rows.Add(dr);
                    }
                    if (clsChi_Tiet_Phieu_Nhap_Vat_Tu.KTVTChuaDuyet(clsNhap.Ma_phieu_nhap) == true)
                    {
                        //khong cho sua thong tin tren luoi
                        disableInputForm();
                        MessageBox.Show("Phiếu nhập này chứa vật tư đã phân vào kho, không thể chỉnh sữa thông tin.");
                        return false;

                    }

                    //MessageBox.Show("Tồn tại mã phiếu nhập trong csdl");

                    return true;
                }
                else
                {
                    //MessageBox.Show("Chưa Tồn tại mã phiếu nhập trong csdl");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex));
            }
            return false;
        }


        private void gridMaster_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (e.Control is DataGridViewComboBoxEditingControl)
                {
                    ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                    ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                    ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex));

            }
        }



        private void cbMaVatTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbMaVatTu_SelectionChangeCommitted(sender, e);
            //if (PanelButton.getClickStatus() == enumButton2.SuaLuoi || PanelButton.getClickStatus() == enumButton2.XoaLuoi || e.KeyCode == Keys.Enter)
            //{
            //    string val = cbMaVatTu.Text ;
            //    DataTable temp =  new clsDMVatTu().GetAll(val);
            //    cbTenVatTu.Text =temp.Rows[0]["Ten_vat_tu"].ToString();
            //    txtDVT.Text = temp.Rows[0]["Ten_don_vi_tinh"].ToString();

            //    txtDonGia.Text = temp.Rows[0]["Don_gia"].ToString();
            //}

        }

        private void cbTenVatTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                cbTenVatTu_SelectionChangeCommitted(sender, e);
                //for (int i = 0; i < Dic.Count; i++)
                //{
                //    if (Dic.ToList()[i].Value.Ten_vat_tu.Equals(cbTenVatTu.Text))

                //    // == cbTenVatTu.Text.Trim())
                {
                    //clsDMVatTu vt = new clsDMVatTu();
                    //DataTable temp = vt.GetAllMa(cbMaVatTu.Text);
                    //cbMaVatTu.Text = temp.Rows[0]["Ma_vat_tu"].ToString();
                    //txtDVT.Text = temp.Rows[0]["Ten_don_vi_tinh"].ToString();
                    //txtDonGia.Text = temp.Rows[0]["Don_gia"].ToString();


                }
                //}
            }
        }


        enumButton2 sttaf;
        private void btnGridAdd_Click(object sender, EventArgs e)
        {
            try
            {
                sttaf = PanelButton.getClickStatus();

                if (double.Parse(txtSLTX.Text) < 0)
                {
                    MessageBox.Show("Số lượng vật tư không được phép giá trị âm !");
                    return;
                }

                if (cbMaVatTu.Text == "" || cbTenVatTu.Text == "" || cbChatLuong.Text == "")
                {
                    MessageBox.Show("Mã vật tư và tên vật tư không được rỗng, Chất lượng bắt buộc nhập !");
                    return;
                }

                DataRow[] result = dataTable1.Select("Ma_vat_tu =" + cbMaVatTu.Text);

                if (result.Length == 0)
                {
                    try
                    {
                        DataRow dr = dataTable1.NewRow();
                        dr["Ma_vat_tu"] = cbMaVatTu.Text;
                        dr["ten_vat_tu"] = cbTenVatTu.Text;
                        dr["Ten_don_vi_tinh"] = txtDVT.Text;
                        dr["chat_luong"] = cbChatLuong.Text;
                        dr["ID_chat_luong"] = cbChatLuong.SelectedValue;
                        //   dr["so_luong_yeu_cau"] = txtSLYC.Text;
                        dr["so_luong_thuc_lanh"] = txtSLTX.Text;
                        dr["don_gia"] = txtDonGia.Text;
                        clsDMVatTu vt = new clsDMVatTu();
                        DataTable temp = vt.GetAll(cbMaVatTu.Text);
                        dr["ID_don_vi_tinh"] = temp.Rows[0]["ID_Don_vi_tinh"];
                        if (txtDonGia.Text == "")
                            txtDonGia.Text = "0";
                        dr["thanh_tien"] = double.Parse(txtDonGia.Text) * double.Parse(txtSLTX.Text) == 0;

                        dataTable1.Rows.Add(dr);

                        ResetGridInputForm();
                        PanelButton.setClickStatus(sttaf);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Đã tồn tại mã vật tư này rồi !");

                // gridMaster.SelectedRows.
            }
            catch (Exception ex)
            {
                MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex));

            }
        }




        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLKhoDienLucDataSet.DM_Vat_Tu' table. You can move, or remove it, as needed.
            //     this.dM_Vat_TuTableAdapter.Fill(this.qLKhoDienLucDataSet.DM_Vat_Tu);

        }

        private void btnGridEdit_Click(object sender, EventArgs e)
        {
            try
            {

                sttaf = PanelButton.getClickStatus();

                if (dataTable1.Rows.Count == 0)
                    return;
                PanelButton.setClickStatus(enumButton2.SuaLuoi);

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
                Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;
                cbMaVatTu.Text = (gridMaster.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
                //txtSLYC.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_yeu_cau"].Value.ToString();
                txtSLTX.Text = gridMaster.Rows[selectedRowCount].Cells["so_luong_thuc_lanh"].Value.ToString();
                cbChatLuong.Text = gridMaster.Rows[selectedRowCount].Cells["Chat_luong"].Value.ToString();
                txtDVT.Text = gridMaster.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value.ToString();
                cbTenVatTu.Text = gridMaster.Rows[selectedRowCount].Cells["Ten_vat_tu"].Value.ToString();

                //cbMaVatTu_KeyDown(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex));
            }
        }


        private void gridMaster_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (PanelButton.getClickStatus() == enumButton2.SuaLuoi || PanelButton.getClickStatus() == enumButton2.XoaLuoi)
                {
                    Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;
                    cbMaVatTu.Text = (gridMaster.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
                    if (cbMaVatTu.Text != "")
                    {
                        cbMaVatTu_KeyDown(null, null);
                    }
                    else
                        ResetGridInputForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex));
            }
        }


        private void btnGridSave_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;

                if (dataTable1.Rows.Count == 0 || selectedRowCount >= dataTable1.Rows.Count)
                    return;
                if (PanelButton.getClickStatus() == enumButton2.SuaLuoi)
                {
                    gridMaster.Rows[selectedRowCount].Cells["ma_vat_tu"].Value = cbMaVatTu.Text;
                    gridMaster.Rows[selectedRowCount].Cells["ten_vat_tu"].Value = cbTenVatTu.Text;
                    gridMaster.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value = txtDVT.Text;
                    gridMaster.Rows[selectedRowCount].Cells["chat_luong"].Value = cbChatLuong.Text;
                    gridMaster.Rows[selectedRowCount].Cells["ID_chat_luong"].Value = cbChatLuong.SelectedValue;
                    //  gridMaster.Rows[selectedRowCount].Cells["so_luong_yeu_cau"].Value = txtSLYC.Text;
                    gridMaster.Rows[selectedRowCount].Cells["so_luong_thuc_lanh"].Value = txtSLTX.Text;
                    gridMaster.Rows[selectedRowCount].Cells["don_gia"].Value = txtDonGia.Text;
                    clsDMVatTu vt = new clsDMVatTu();
                    DataTable temp = vt.GetAll(cbMaVatTu.Text);
                    gridMaster.Rows[selectedRowCount].Cells["ID_don_vi_tinh"].Value = temp.Rows[0]["ID_Don_vi_tinh"];
                    if (txtDonGia.Text == "")
                        txtDonGia.Text = "0";

                    gridMaster.Rows[selectedRowCount].Cells["thanh_tien"].Value = double.Parse(txtDonGia.Text) * int.Parse(txtSLTX.Text);

                    PanelButton.setClickStatus(sttaf);
                }
                if (PanelButton.getClickStatus() == enumButton2.XoaLuoi)
                {
                    dataTable1.Rows.RemoveAt(selectedRowCount);
                    PanelButton.setClickStatus(sttaf);
                }
                setInputComponentStatus(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //private void btnHuyBo_Click(object sender, EventArgs e)
        //{
        //    btnAdd.Enabled = true;
        //    btnEdit.Enabled = true;

        //    ResetGridInputForm();

        //    PanelButton.ResetClickStatus();
        //}

        private void txtMaPhieuNhap_Enter(object sender, EventArgs e)
        {

        }


        DataTable tbAff;
        private void btnSua_Click(object sender, EventArgs e)
        {
            dataTable1.Clear();
            //kiem tra ma phieu nhap xem co vat tu nao trung ko? neu co thì chỉ hiển thị thông tin và ko cho cập nhật

            if (txtMaPhieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã phiếu nhập!");
                return;
            }

            if (initEdit() == true)
            {
                PanelButton.setClickSua();
                PanelButton.Enable_btn_Luu_Huy();

                enableInputForm();

                txtMaPhieu.Enabled = false;
            }

            tbAff = dataTable1.Copy();
        }

        private void btnGridDel_Click(object sender, EventArgs e)
        {
            //sttaf = staTus;
            sttaf = PanelButton.getClickStatus();
            //PanelButton.setClickStatus(sttaf);

            try
            {
                Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;

                //string ma_vat_tu = dataTable1.Rows[
                if (dataTable1.Rows.Count == 0 || selectedRowCount >= dataTable1.Rows.Count)
                    return;
                //staTus = enumStatus.XoaLuoi;
                PanelButton.setClickStatus(enumButton2.XoaLuoi);
                btnDel.Enabled = false;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                cbMaVatTu.Text = (gridMaster.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
                //txtSLYC.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_yeu_cau"].Value.ToString();
                txtSLTX.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_thuc_lanh"].Value.ToString();
                cbChatLuong.SelectedText = gridMaster.Rows[selectedRowCount].Cells["Chat_luong"].Value.ToString();
                txtDVT.Text = gridMaster.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value.ToString();
                cbTenVatTu.Text = gridMaster.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value.ToString();
                //PanelButton.setClickStatus(sttaf);
                //     cbMaVatTu_KeyDown(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void btnLamMoi_Click(object sender, EventArgs e)
        //{
        //    new frmNhapKho();
        //}

        //private void btnHuy_Click(object sender, EventArgs e)
        //{

        //    btnThem.Enabled = true;
        //    btnSua.Enabled = true;
        //    btnXoa.Enabled = true;
        //    btnLamMoi.Enabled = true;


        //    setStatus(false);
        //    ResetText();

        //    txtMaPhieuNhap.Text = "";
        //    txtDiaChi.Text = "";
        //    txtCongTrinh.Text = "";
        //    txtLyDo.Text = "";
        //    txtXuatTaiKho.Text = "";
        //    txtMaPhieuNhap.Enabled = true;
        //    dataTable1.Clear();

        //}

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (PanelButton.isClickNone())
            {
                PanelButton.setClickXoa();
                PanelButton.Enable_btn_Luu_Huy();

                //reset for input
                enableInputForm();
                ResetInputForm();
                DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xóa phiếu nhập này ?", "Cảnh báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }

        }


        /// <summary>
        /// By AN
        /// 
        /// To-do LIST
        /// [x] Test load data by Mã Số Phiếu
        /// [ ] Khi click btn Lưu -> Gọi Delegates refesh DS phiếu (if frm DS Phiếu != null)
        /// [ ] Init trạng thái enable/disable của các button, txt, cb, ...
        /// [ ] 
        /// [ ] 
        /// [ ] 
        /// </summary>
        private void btnTest_Click(object sender, EventArgs e)
        {
            string Ma_Phieu_Nhap = "002";

            setFormData_By_MaPhieuNhap(Ma_Phieu_Nhap);
        }

        /// <summary>
        /// To-Do LIST
        /// [ ] Vấn đề 1: Lấy DataTable chi tiết phiếu nhập (by mã phiếu nhập) --> fill vào grid
        /// [ ] Vấn đề 2: Lấy thông tin Phiếu (by Ma Phieu Nhap) --> Check tồn tại --> Set to FRM
        /// [ ] 
        /// [ ] 
        /// [ ] 
        /// </summary>
        /// <param name="Ma_Phieu_Nhap">The ma_ phieu_ nhap.</param>
        private bool setFormData_By_MaPhieuNhap(string Ma_Phieu_Nhap)
        {
            clsPhieuNhapKho PhieuNhap = new clsPhieuNhapKho();

            if (PhieuNhap.CheckTonTaiSoDK(Ma_Phieu_Nhap))
            {
                //fill vào FRM
                DataTable tb = PhieuNhap.GetAll(Ma_Phieu_Nhap);

                //cbKhoNhap.SelectedValue = tb.Rows[0]["ID_kho"].ToString();
                txtMaPhieu.Text = Ma_Phieu_Nhap;
                dtNgayNhap.Text = string.Format("{0:dd/MM/yyyy}", tb.Rows[0]["Ngay_lap"]);

                txtLyDo.Text = tb.Rows[0]["Ly_do"].ToString();
                txtTenPhieu.Text = tb.Rows[0]["cong_trinh"].ToString();
                //txtDiaChi.Text = tb.Rows[0]["Dia_chi"].ToString();

                //Fill vào grid
                //DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(Ma_Phieu_Nhap);

                //dataTable1 = chiTietPhieuNhap;
                //gridMaster.DataSource = dataTable1;


                //clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();

                DataTable vChiTiet = (DataTable)new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(Ma_Phieu_Nhap);

                for (int i = 0; i < vChiTiet.Rows.Count; i++)
                {
                    DataRow dr = dataTable1.NewRow();

                    dr["ma_vat_tu"] = vChiTiet.Rows[i]["ma_vat_tu"].ToString();
                    dr["Ten_vat_tu"] = vChiTiet.Rows[i]["Ten_vat_tu"].ToString();
                    dr["Ten_Don_vi_tinh"] = vChiTiet.Rows[i]["ten_don_vi_tinh"].ToString();
                    dr["ID_Don_vi_tinh"] = vChiTiet.Rows[i]["ID_don_vi_tinh"].ToString();
                    dr["chat_luong"] = vChiTiet.Rows[i]["chat_luong"].ToString();
                    dr["so_luong_yeu_cau"] = vChiTiet.Rows[i]["so_luong_yeu_cau"].ToString();
                    dr["so_luong_thuc_lanh"] = vChiTiet.Rows[i]["so_luong_thuc_lanh"].ToString();
                    dr["don_gia"] = vChiTiet.Rows[i]["don_gia"].ToString();
                    dr["Thanh_tien"] = vChiTiet.Rows[i]["thanh_tien"].ToString(); // int.Parse(vChiTiet.Rows[i]["don_gia"].ToString()) * int.Parse(vChiTiet.Rows[i]["so_luong_thuc_lanh"].ToString());

                    dataTable1.Rows.Add(dr);
                }
                return true;
            }
            else
                return false;
        }


        FormActionDelegate2 frmAction;
        clsPanelButton2 PanelButton;

        /// <summary>
        /// Initializes the form component.
        /// Enable/Disable
        /// 
        /// * Nhóm top panel -> Chức năng cho toàn bộ phiếu
        /// BtnThem --> reset status frm --> chuẩn bị nhập mới.
        /// btnSua --> tùy theo mã phiếu --> Load data vào form
        /// btnLamMoi --> Có cần thiết --> disable
        /// btnHuy --> nếu đang thêm|sửa --> reset lại form
        /// btnDong --> Close
        /// *btnXoa --> Setup sau --> xóa chi tiết trước --> xóa phiếu
        /// btnLuu --> Apply action Them, sua
        /// 
        /// * Nhóm Component thông tin phiếu
        /// cbKhoNhap --> init tên kho
        /// txtMaPhieuNhap --> Mã Phiếu --> auto complete --> btn [...] --> chọn từ Danh Sách Mã Phiếu
        /// dtNgayNhap --> Chọn ngày (Format dd/mm/yyyy)
        /// txtLyDo
        /// txtCongTrinh
        /// txtDiaChi
        /// 
        /// *Nhóm panel cho grid - Chi tiết phiếu
        /// btnGridAdd --> Add to row
        /// btnGridDel
        /// btnGridEdit
        /// btnGridSave
        /// 
        /// * Nhóm Component thông tin phiếu
        /// cbMaVatTu -->
        /// cbTenVatTu -->
        /// txtDVT
        /// txtSLYC
        /// txtSLTX
        /// txtDonGia
        /// txtChatLuong
        /// 
        /// </summary>
        private void InitFormComponent()
        {
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


            //PanelButton.setButtonClickEvent(enumButton2.Them);
            //PanelButton.setButtonClickEvent(enumButton2.Xoa);
            //PanelButton.setButtonClickEvent(enumButton2.Sua);
            //PanelButton.setButtonClickEvent(enumButton2.LamMoi);
            //PanelButton.setButtonClickEvent(enumButton2.Luu);

            PanelButton.setButtonClickEvent(enumButton2.Huy);
            PanelButton.setButtonClickEvent(enumButton2.Dong);

            PanelButton.AddButton(enumButton2.Dong, ref btnDong);

            //Ko dùng nút xóa
            PanelButton.setButtonStatus(enumButton2.Xoa, false);
            PanelButton.setButtonStatus(enumButton2.LamMoi, false);
            btnXoa.Enabled = false;
            btnLamMoi.Enabled = false;

            //Init cho combobox Kho Nhập
            initKhoNhap();
            // var temp = new clsDMVatTu().GetAll();


            //Init cho combobox Ma vat tu, Ten vat tu
            //  Dic = GetDict(new clsDMVatTu().GetAll());

            initMaVatTu();
            initTenVatTu();
            initChatLuong();
            ///
            //   clsGiaoDienChung.initCombobox(cbKhoChinh, new clsDM_Kho(), "ten_kho", "ID_kho", "ten_kho");
            //cbLoaiPhieuNhan.DataSource = clsLoaiPhieuNhap.getAll();
            //cbLoaiPhieuNhan.ValueMember = "ID_loai_phieu_nhap";
            //cbLoaiPhieuNhan.DisplayMember= "ma_loai_phieu_nhap";
            clsGiaoDienChung.initCombobox(cbKhoNhan, new clsDM_Kho(), "Ten_kho", "ID_kho", "Ten_kho");

            PanelButton.ResetClickStatus();
            PanelButton.ResetButton();
        }

        private void initChatLuong()
        {
            clsGiaoDienChung.initCombobox(cbChatLuong, new clsDMChatLuong(), "Loai_chat_luong", "ID_chat_luong", "Loai_chat_luong");
        }

        private void initTenVatTu()
        {
            clsGiaoDienChung.initCombobox(cbTenVatTu, new clsDMVatTu(), "Ten_vat_tu", "ID_vat_tu", "Ten_vat_tu");
        }



        /// <summary>
        /// Initializes --> combobox kho nhap.
        /// </summary>
        private void initKhoNhap()
        {
            //   clsDM_Kho dmKho = new clsDM_Kho();
            //cbKhoNhap.DisplayMember = "Ten_kho";
            //cbKhoNhap.ValueMember = "ID_kho";

            //cbKhoNhap.DataSource = clsDM_Kho.getAll();
        }


        /// <summary>
        /// Initializes --> combobox ma vat tu.
        /// </summary>
        private void initMaVatTu()
        {
            clsGiaoDienChung.initCombobox(cbMaVatTu, new clsDMVatTu(), "Ma_vat_tu", "ID_vat_tu", "Ma_vat_tu");
        }


        /// <summary>
        /// Initializes --> combobox ten vat tu.
        /// </summary>



        public void FormAction(enumFormAction2 frmAct)
        {
            switch (frmAct)
            {
                case enumFormAction2.None:
                    break;
                case enumFormAction2.LoadData:
                    break;
                case enumFormAction2.CloseForm:
                    CloseForm();
                    break;
                case enumFormAction2.setFormData:
                    break;
                case enumFormAction2.ResetInputForm:
                    ResetInputForm();
                    break;
                case enumFormAction2.disableInputForm:
                    disableInputForm();
                    break;
                case enumFormAction2.Huy:
                    break;
                case enumFormAction2.Dong:
                    break;
                default:
                    break;
            }
        }

        public void CloseForm()
        {
            this.Close();
        }

        /// <summary>
        /// Enable/Disable --> input component.
        /// </summary>
        /// <param name="_status">if set to <c>true</c> [_status].</param>
        public void setInputComponentStatus(bool _status)
        {
            //cbKhoNhap.Enabled = _status;
            txtMaPhieu.Enabled = _status;
            dtNgayNhap.Enabled = _status;
            txtXuatTaiKho.Enabled = _status;
            txtLyDo.Enabled = _status;
            txtTenPhieu.Enabled = _status;
            //txtDiaChi.Enabled = _status;
            cbMaVatTu.Enabled = _status;
            cbTenVatTu.Enabled = _status;
            //txtSLYC.Enabled = _status;
            txtSLTX.Enabled = _status;
            cbChatLuong.Enabled = _status;
            btnAdd.Enabled = _status;
            btnEdit.Enabled = _status;
            btnSaveGrid.Enabled = _status;
            btnDel.Enabled = _status;
            txtDonGia.Enabled = _status;
            txtXuatTaiKho.Enabled = _status;
            cbKhoNhan.Enabled = _status;
            //      txtSoHD.Enabled = _status;
            //  txtSLYC.Enabled = _status;
            //txtMaPhieuNhap.Enabled = _status;

        }

        public void enableInputForm()
        {
            setInputComponentStatus(true);
        }

        public void disableInputForm()
        {
            setInputComponentStatus(false);
        }

        /// <summary>
        /// Resets --> Lưới, grid input form.
        /// </summary>
        private void ResetGridInputForm()
        {
            cbMaVatTu.Text = "";
            cbTenVatTu.Text = "";

            txtDVT.Text = "";
            cbChatLuong.Text = "";
            txtSLTX.Text = "0";

            txtDonGia.Text = "0";
        }

        public void ResetInputForm()
        {
            ResetGridInputForm();

            txtMaPhieu.Text = "";
            //txtDiaChi.Text = "";
            txtTenPhieu.Text = "";
            txtLyDo.Text = "";
            txtXuatTaiKho.Text = "";

            txtMaPhieu.Enabled = true;
            txtDonGia.Text = "0";

            dataTable1.Clear();
        }

        public void ResetInputFormForCheck()
        {
            ResetGridInputForm();

            //txtMaPhieuNhap.Text = "";
          //  txtDiaChi.Text = "";
            txtTenPhieu.Text = "";
            txtLyDo.Text = "";
            txtXuatTaiKho.Text = "";

            txtMaPhieu.Enabled = true;


            dataTable1.Clear();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            //dataTable1.Clear();
            clsPhieuNhapKho clsNhap = new clsPhieuNhapKho();
            clsNhap.Ma_phieu_nhap = txtMaPhieu.Text;

            if (!txtMaPhieu.Text.Trim().Equals(String.Empty) && clsNhap.CheckTonTaiSoDK(txtMaPhieu.Text) == true)
            {
                frmReport_Phieu_Nhap_Kho frm = new frmReport_Phieu_Nhap_Kho(txtMaPhieu.Text.Trim());
                frm.Text = "Report Phiếu Nhập Kho";

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

        private void cbMaVatTu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ComboBox c = (ComboBox)sender;
                //DataRowView dtv = c.Items[c.SelectedIndex] as DataRowView ;

                string Ma_Vat_Tu = c.Text.ToString();

                clsDMVatTu vattu = new clsDMVatTu();

                string Ten_Vat_Tu = vattu.getTenVatTu(Ma_Vat_Tu);

                cbTenVatTu.Text = Ten_Vat_Tu;

                DataTable tb = vattu.getData_By_MaVatTu(Ma_Vat_Tu);

                txtDVT.Text = tb.Rows[0]["Ten_don_vi_tinh"].ToString();
                txtDonGia.Text = tb.Rows[0]["Don_gia"].ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cbTenVatTu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ComboBox c = (ComboBox)sender;

                string Ten_Vat_Tu = c.Text.ToString();

                clsDMVatTu vattu = new clsDMVatTu();

                string Ma_Vat_Tu = vattu.getMaVatTu(Ten_Vat_Tu);

                cbMaVatTu.Text = Ma_Vat_Tu;

                DataTable tb = vattu.getData_By_MaVatTu(Ma_Vat_Tu);

                txtDVT.Text = tb.Rows[0]["Ten_don_vi_tinh"].ToString();
                txtDonGia.Text = tb.Rows[0]["Don_gia"].ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtSLYC_KeyPress(object sender, KeyPressEventArgs e)
        {



            //if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtSLTX_KeyPress(object sender, KeyPressEventArgs e)
        {
            double number;
            try
            {
                number = double.Parse(txtSLTX.Text);
                txtSLTX.BackColor = Color.White;
            }
            catch
            {
                txtSLTX.BackColor = Color.Red;
            }
        }

        private bool IsNumeric(string s)
        {
            Int32 output;
            return Int32.TryParse(s, out output);
        }

        private System.Windows.Forms.ErrorProvider errorProvider1 = new ErrorProvider();

        private void txtSLYC_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtSLYC_Validated(object sender, EventArgs e)
        {

        }

        private void txtSLTX_Validated(object sender, EventArgs e)
        {

        }

        private void txtSLTX_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }



    }
}
