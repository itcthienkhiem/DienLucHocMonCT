﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
namespace Inventory.NhapXuat
{
    public partial class frmNhapKho : Form
    {

        Dictionary<string, clsDMVatTu> Dic = new Dictionary<string, clsDMVatTu>();

        //    Dictionary<string, clsDMVatTu> DicTen = new Dictionary<string, clsDMVatTu>();
        //  DataTable data = new DataTable();
        public frmNhapKho()
        {
            InitializeComponent();
            staTus = enumStatus.None;
            this.cbMaVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbMaVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cbTenVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbTenVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            clsDM_Kho dmKho = new clsDM_Kho();
            cbKhoNhap.DisplayMember = "Ten_kho";
            cbKhoNhap.ValueMember = "ID_kho";
            Dic = GetDict(new clsDMVatTu().GetAll());
            //    DicTen = GetDictTen(new clsDMVatTu().GetAll());

            cbKhoNhap.DataSource = dmKho.GetAll();

            AutoCompleteStringCollection combData1 = new AutoCompleteStringCollection();
            AutoCompleteStringCollection combData2 = new AutoCompleteStringCollection();
            foreach (string key in Dic.Keys)
            {
                combData1.Add(Dic[key].Ma_vat_tu);
                combData2.Add(Dic[key].Ten_vat_tu);

            }
            cbMaVatTu.AutoCompleteCustomSource = combData1;
            cbMaVatTu.DataSource = combData1;
            cbTenVatTu.AutoCompleteCustomSource = combData2;
            cbTenVatTu.DataSource = combData2;
            cbMaVatTu.SelectedIndex = -1;
            cbTenVatTu.SelectedIndex = -1;

            // gridMaster.DataSource = data;
        }


        internal Dictionary<string, clsDMVatTu> GetDict(DataTable dt)
        {
            var areas = new Dictionary<string, clsDMVatTu>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                areas.Add(dt.Rows[i]["Ma_vat_tu"].ToString(), new clsDMVatTu(

                     dt.Rows[i]["Ma_vat_tu"].ToString(),
                      dt.Rows[i]["ten_vat_tu"].ToString(),
                  (dt.Rows[i]["ten_don_vi_tinh"].ToString()),
                        dt.Rows[i]["Mo_ta"].ToString()
                        ,
                       long.Parse(dt.Rows[i]["Don_gia"].ToString())
                       ,
                       int.Parse( dt.Rows[i]["ID_Don_vi_tinh"].ToString())
                    ));

                //   dt.Rows[i]["ten_vat_tu"];

            }
            return areas;
        }

        public frmNhapKho(enumStatus status, clsPhieuNhapKho phieunhap)
        {
            InitializeComponent();
            this.staTus = status;
            if (status == enumStatus.Sua || status == enumStatus.Xoa)
            {
                this.phieuNhapKho = phieunhap;
                DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieunhap.Ma_phieu_nhap);
                gridMaster.DataSource = chiTietPhieuNhap;
                //chitiet.get
            }
        }

        enumStatus staTus = enumStatus.None;
        clsPhieuNhapKho phieuNhapKho = new clsPhieuNhapKho();
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (staTus == enumStatus.None)
            {
                staTus = enumStatus.Them;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = false;
                btnSave.Enabled = true;
                ResetText();
                
                setStatus(true);

                txtMaPhieuNhap.Text = "";
                txtDiaChi.Text = "";
                txtCongTrinh.Text = "";
                txtLyDo.Text = "";
                txtXuatTaiKho.Text = "";
                dataTable1.Rows.Clear();
               // gridMaster.ReadOnly = false;
            }

        }
        public void setStatus(bool _status)
        {
            cbKhoNhap.Enabled = _status;
            txtMaPhieuNhap.Enabled = _status;
            dtNgayNhap.Enabled = _status;
            txtXuatTaiKho.Enabled = _status;
            txtLyDo.Enabled = _status;
            txtCongTrinh.Enabled = _status;
            txtDiaChi.Enabled = _status;
            cbMaVatTu.Enabled = _status;
            cbTenVatTu.Enabled = _status;
            txtSLYC.Enabled = _status;
            txtSLTX.Enabled = _status;
            txtChatLuong.Enabled = _status;
            btnAdd.Enabled = _status;
            btnEdit.Enabled = _status;
            btnSaveGrid.Enabled = _status;
            btnDel.Enabled = _status;

            //txtMaPhieuNhap.Enabled = _status;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMaPhieuNhap.Text.Trim() == "")
            {
                MessageBox.Show("Mã phiếu bắt buộc nhập!");
                return;
            }
            if (dataTable1.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu trong danh sách vật tư không rỗng");
                return;
            }
            SQLDAL DAL = new SQLDAL();
            DAL.BeginTransaction();

            switch (staTus)
            {

                case enumStatus.Them:

                 
                    try
                    {
                        clsPhieuNhapKho phieunhap = new clsPhieuNhapKho();
                        phieunhap.Ma_phieu_nhap = txtMaPhieuNhap.Text;
                        if (!phieunhap.CheckTonTaiSoDK())
                        {
                            // phieunhap.
                            phieunhap.ID_kho = 1;
                            phieunhap.Ma_phieu_nhap = txtMaPhieuNhap.Text;
                            phieunhap.Dia_chi = txtDiaChi.Text;
                            phieunhap.Ly_do = txtLyDo.Text;
                            phieunhap.Ngay_lap = dtNgayNhap.Value;
                            //  phieunhap.So_hoa_don = txt
                            phieunhap.Cong_trinh = txtCongTrinh.Text;




                            if (phieunhap.Insert(DAL) == 1)
                            {

                                //DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieuNhap.ID_phieu_nhap);
                                for (int i = 0; i < dataTable1.Rows.Count; i++)
                                {
                                    clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
                                    //    chitiet.ID_chi_tiet_phieu_nhap = int.Parse(gridMaster.Rows[i].Cells["ID_chi_tiet_phieu_nhap"].ToString());
                                    chitiet.Ma_phieu_nhap = (txtMaPhieuNhap.Text);
                                    chitiet.ID_Don_vi_tinh =int.Parse( dataTable1.Rows[i]["ID_Don_vi_tinh"].ToString());
                                    chitiet.Ma_vat_tu = (dataTable1.Rows[i]["Ma_vat_tu"].ToString());
                                    chitiet.Chat_luong = (dataTable1.Rows[i]["Chat_luong"].ToString());
                                    chitiet.So_luong_yeu_cau = int.Parse(dataTable1.Rows[i]["So_luong_yeu_cau"].ToString());
                                    chitiet.So_luong_thuc_nhap = int.Parse(dataTable1.Rows[i]["So_luong_thuc_xuat"].ToString());
                                    chitiet.Don_gia = int.Parse(dataTable1.Rows[i]["Don_gia"].ToString());
                                    chitiet.Thanh_tien = int.Parse(dataTable1.Rows[i]["Thanh_tien"].ToString());

                                    clsTonDauKy tdk = new clsTonDauKy();
                                    tdk.ID_kho = phieunhap.ID_kho;
                                    tdk.Ma_vat_tu = chitiet.Ma_vat_tu;
                                    tdk.So_luong = chitiet.So_luong_thuc_nhap;
                                    if (chitiet.Insert(DAL) == 1)
                                    {
                                        // MessageBox.Show("Chúng tôi sẽ cập nhật lại số tồn đầu kỳ! ");
                                        if (tdk.CheckTonTaiSoDK())
                                        {
                                            DataTable tb = tdk.GetAllByKey(tdk.Ma_vat_tu);
                                            int? so_luong_kho = tdk.So_luong +int.Parse(tb.Rows[0]["so_luong"].ToString());
                                            tdk.So_luong = so_luong_kho;
                                            if (tdk.Update(DAL) == 0)
                                            {   //    MessageBox.Show("Thêm thành công");
                                                DAL.RollbackTransaction();
                                                return;
                                            }
                                        }
                                        else

                                            if (tdk.Insert(DAL) == 0)
                                            {
                                                //                                            MessageBox.Show("Thêm thành công");
                                                DAL.RollbackTransaction();
                                                return;
                                            }
                                    }


                                }
                         //       DAL.CommitTransaction();
                                MessageBox.Show("Thêm thành công");
                                staTus = enumStatus.None;
                                setStatus(true);
                                btnThem.Enabled = true;
                                btnXoa.Enabled = true;
                                btnSua.Enabled = true;
                                btnLamMoi.Enabled = true;
                            }



                            else
                                DAL.RollbackTransaction();


                        }
                        else
                        {
                            MessageBox.Show("mã phiếu nhập này đã tồn tại trong csdl!");

                            button2_Click(null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        DAL.RollbackTransaction();
                    }
                    break;
                case enumStatus.Sua:
                    {
                        
                        DAL.BeginTransaction();
                        try
                        {
                            clsPhieuNhapKho phieunhap = new clsPhieuNhapKho();
                            phieunhap.Ma_phieu_nhap = txtMaPhieuNhap.Text;
                            {
                                // phieunhap.
                                phieunhap.ID_kho = 1;
                                phieunhap.Ma_phieu_nhap = txtMaPhieuNhap.Text;
                                phieunhap.Dia_chi = txtDiaChi.Text;
                                phieunhap.Ly_do = txtLyDo.Text;
                                phieunhap.Ngay_lap = dtNgayNhap.Value;
                                //  phieunhap.So_hoa_don = txt
                                phieunhap.Cong_trinh = txtCongTrinh.Text;


                                if (phieunhap.Update(DAL) == 1)
                                {
                                    clsChi_Tiet_Phieu_Nhap_Vat_Tu check = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
                                    //DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieuNhap.ID_phieu_nhap);
                                    //xoa ton dau ky     
                                    clsTonDauKy tdk = new clsTonDauKy();
                                    //kiem tra du lieu truoc khi xoa
                                    for (int i = 0; i < tbAff.Rows.Count; i++)
                                    {
                                        string ma_vat_tu = tbAff.Rows[i]["Ma_vat_tu"].ToString();
                                        int so_luong =int.Parse( tbAff.Rows[i]["So_luong_thuc_xuat"].ToString());
                                        DataTable tbnews = tdk.GetAllByKey(ma_vat_tu);
                                        int so_luong_ton = int.Parse(tbnews.Rows[0]["So_luong"].ToString());
                                        int so_luong_thuc = so_luong_ton - so_luong;
                                        if(so_luong_thuc <=0)
                                        {
                                            MessageBox.Show("Hàng này ko thể cập nhật lại số lượng vì sau khi cập nhật sẽ bị âm!");
                                            return;
                                        }
                                        tdk.So_luong = so_luong_thuc;
                                        tdk.Ma_vat_tu = ma_vat_tu;
                                        tdk.ID_kho = 1;
                                        tdk.Update(DAL);
                                        check.removebyKey(DAL, txtMaPhieuNhap.Text,ma_vat_tu);

                                    }
                                    
                                    
                                    for (int i = 0; i < dataTable1.Rows.Count; i++)
                                    {
                                        clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
                                        
                                        //chitiet.removebyKey(txtMaPhieuNhap.Text);
                                        //    chitiet.ID_chi_tiet_phieu_nhap = int.Parse(gridMaster.Rows[i].Cells["ID_chi_tiet_phieu_nhap"].ToString());
                                        chitiet.Ma_phieu_nhap = (txtMaPhieuNhap.Text);
                                        chitiet.ID_Don_vi_tinh = int.Parse(dataTable1.Rows[i]["ID_Don_vi_tinh"].ToString());
                                        chitiet.Ma_vat_tu = (dataTable1.Rows[i]["Ma_vat_tu"].ToString());
                                        chitiet.Chat_luong = (dataTable1.Rows[i]["Chat_luong"].ToString());
                                        chitiet.So_luong_yeu_cau = int.Parse(dataTable1.Rows[i]["So_luong_yeu_cau"].ToString());
                                        chitiet.So_luong_thuc_nhap = int.Parse(dataTable1.Rows[i]["So_luong_thuc_xuat"].ToString());
                                        chitiet.Don_gia = int.Parse(dataTable1.Rows[i]["Don_gia"].ToString());
                                        chitiet.Thanh_tien = int.Parse(dataTable1.Rows[i]["Thanh_tien"].ToString());


                                        if (chitiet.Insert(DAL) == 1)
                                        {
                                            //   clsTonDauKy tdk = new clsTonDauKy();



                                            tdk.ID_kho = phieunhap.ID_kho;
                                            tdk.Ma_vat_tu = chitiet.Ma_vat_tu;
                                            tdk.So_luong = chitiet.So_luong_thuc_nhap;

                                            // MessageBox.Show("Chúng tôi sẽ cập nhật lại số tồn đầu kỳ! ");
                                            if (tdk.CheckTonTaiSoDK())
                                            {
                                                DataTable tbnews = tdk.GetAllByKey(chitiet.Ma_vat_tu);

                                                tdk.So_luong += int.Parse(tbnews.Rows[0]["So_luong"].ToString());
                                                if (tdk.Update(DAL) == 0)
                                                //    MessageBox.Show("Thêm thành công");
                                                {
                                                    DAL.RollbackTransaction();
                                                    return;
                                                }
                                            }
                                            else

                                                if (tdk.Insert(DAL) == 0)
                                                {
                                                    //                                            MessageBox.Show("Thêm thành công");
                                                    DAL.RollbackTransaction();
                                                    return;
                                                }
                                        }


                                    }
                                    MessageBox.Show("Chỉnh sữa thông tin thành công !");
                                    staTus = enumStatus.None;
                                    setStatus(true);
                                    btnThem.Enabled = true;
                                    btnXoa.Enabled = true;
                                    btnSua.Enabled = true;
                                    btnLamMoi.Enabled = true;
                                }



                                else
                                    DAL.RollbackTransaction();


                            }
                            
                          
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            DAL.RollbackTransaction();
                        }
                        break;
                    }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            initEdit();
        }

        private bool initEdit()
        {
            clsPhieuNhapKho clsNhap = new clsPhieuNhapKho();
            clsNhap.Ma_phieu_nhap = txtMaPhieuNhap.Text;
            if (clsNhap.CheckTonTaiSoDK() == true)
            {
                DataTable tb = clsNhap.GetAll(txtMaPhieuNhap.Text.Trim());
                // dtNgayNhap.Text = tb.Rows[0]["Ngay_nhap"].ToString();
                dtNgayNhap.Text = string.Format("{0:dd/MM/yyyy}", tb.Rows[0]["Ngay_lap"]);

                txtLyDo.Text = tb.Rows[0]["Ly_do"].ToString();
                txtXuatTaiKho.Text = tb.Rows[0]["ID_kho"].ToString();
                txtCongTrinh.Text = tb.Rows[0]["cong_trinh"].ToString();
                txtDiaChi.Text = tb.Rows[0]["Dia_chi"].ToString();
                clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
                DataTable vChiTiet = chitiet.GetAll(txtMaPhieuNhap.Text);
                for (int i = 0; i < vChiTiet.Rows.Count; i++)
                {
                    //  dataTable1.Rows[i]["Ma_phieu_nhap"] = vChiTiet.Rows[i]["ma_phieu_nhap"].ToString();


                    DataRow dr = dataTable1.NewRow();
                    //dr["Ma_vat_tu"] = vChiTiet.Rows[i]["ma_phieu_nhap"].ToString();
                    dr["ma_vat_tu"] = vChiTiet.Rows[i]["ma_vat_tu"].ToString();
                    dr["Ten_vat_tu"] = vChiTiet.Rows[i]["Ten_vat_tu"].ToString();
                    //  dr["don_vi_tinh"] = vChiTiet.Rows[i]["don_vi_tinh"].ToString() ;
                    dr["chat_luong"] = vChiTiet.Rows[i]["chat_luong"].ToString();
                    dr["so_luong_yeu_cau"] = vChiTiet.Rows[i]["so_luong_yeu_cau"].ToString();
                    dr["so_luong_thuc_xuat"] = vChiTiet.Rows[i]["so_luong_thuc_lanh"].ToString();
                    dr["don_gia"] = vChiTiet.Rows[i]["don_gia"].ToString();
                    dr["Thanh_tien"] = vChiTiet.Rows[i]["thanh_tien"].ToString();// int.Parse(vChiTiet.Rows[i]["don_gia"].ToString()) * int.Parse(vChiTiet.Rows[i]["so_luong_thuc_xuat"].ToString());
                    dr["Ten_Don_vi_tinh"] = vChiTiet.Rows[i]["ten_don_vi_tinh"].ToString();
                    dr["ID_Don_vi_tinh"] = vChiTiet.Rows[i]["ID_don_vi_tinh"].ToString();
                    
                    dataTable1.Rows.Add(dr);
                }


                MessageBox.Show("Tồn tại mã phiếu nhập trong csdl");
                return true;
            }
            else
            {
                MessageBox.Show("Chưa Tồn tại mã phiếu nhập trong csdl");

            }
            return false;
        }

        private void gridMaster_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }
        }

        private void cbMaVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cbMaVatTu.DataSource = 

        }

        private void cbMaVatTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (staTus == enumStatus.SuaLuoi ||staTus ==enumStatus.XoaLuoi||  e.KeyCode == Keys.Enter)
            {
                var val = Dic[cbMaVatTu.Text.Trim()];
                cbTenVatTu.Text = val.Ten_vat_tu.ToString();
                txtDVT.Text = val.ten_don_vi_tinh.ToString();
                
                txtDonGia.Text = val.Don_gia.ToString();


            }

        }

        private void cbTenVatTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < Dic.Count; i++)
                {
                    if (Dic.ToList()[i].Value.Ten_vat_tu.Equals(cbTenVatTu.Text))

                    // == cbTenVatTu.Text.Trim())
                    {
                        var val = Dic.ToList()[i].Value;
                        cbMaVatTu.Text = val.Ma_vat_tu.ToString();
                        txtDVT.Text = val.ten_don_vi_tinh.ToString();
                        txtDonGia.Text = val.Don_gia.ToString();
                    }
                }
            }
        }
        enumStatus sttaf;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            sttaf = staTus;
            if((int.Parse( txtSLYC .Text) )<0 ||(int.Parse( txtSLTX.Text))<0)
            {
                MessageBox.Show("Số lượng vật tư không được phép giá trị âm !");
                return;
            }

                
            if (cbMaVatTu.Text == "" || cbTenVatTu.Text == "")
            {
                MessageBox.Show("Mã vật tư và tên vật tư không được rỗng !");
                return;
            }
            DataRow[] result = dataTable1.Select("Ma_vat_tu =" + cbMaVatTu.Text);
            if (result.Length == 0)
            {
                DataRow dr = dataTable1.NewRow();
                dr["Ma_vat_tu"] = cbMaVatTu.Text;
                dr["ten_vat_tu"] = cbTenVatTu.Text;
                dr["Ten_don_vi_tinh"] = txtDVT.Text;
                dr["chat_luong"] = txtChatLuong.Text;
                dr["so_luong_yeu_cau"] = txtSLYC.Text;
                dr["so_luong_thuc_xuat"] = txtSLTX.Text;
                dr["don_gia"] = txtDonGia.Text;
                dr["ID_don_vi_tinh"] = Dic[cbMaVatTu.Text].ID_Don_vi_tinh;

                dr["thanh_tien"] =int.Parse( txtDonGia.Text) *int.Parse( txtSLTX.Text);

                dataTable1.Rows.Add(dr);
                ResetText();
            }
            else
                MessageBox.Show("Đã tồn tại mã vật tư này rồi !");

            // gridMaster.SelectedRows.
        }
        private void ResetText()
        {
            cbMaVatTu.Text = "";
            cbTenVatTu.Text = "";
            txtDVT.Text = "";
            txtChatLuong.Text = "";
            txtSLTX.Text = "0";
            txtSLYC.Text = "0";
            txtDonGia.Text = "0";
          
            //            txtChatLuong.Text = "";

        }
        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLKhoDienLucDataSet.DM_Vat_Tu' table. You can move, or remove it, as needed.
            //     this.dM_Vat_TuTableAdapter.Fill(this.qLKhoDienLucDataSet.DM_Vat_Tu);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                sttaf = staTus;

                if (dataTable1.Rows.Count == 0)
                    return;
                staTus = enumStatus.SuaLuoi;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
                Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;
                cbMaVatTu.Text = (gridMaster.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
                txtSLYC.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_yeu_cau"].Value.ToString();
                txtSLTX.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_thuc_xuat"].Value.ToString();
                txtChatLuong.Text = gridMaster.Rows[selectedRowCount].Cells["Chat_luong"].Value.ToString();
                txtDVT.Text = gridMaster.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value.ToString();


                cbMaVatTu_KeyDown(null, null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void gridMaster_MouseClick(object sender, MouseEventArgs e)
        {
            if (staTus == enumStatus.SuaLuoi||staTus == enumStatus.XoaLuoi)
            {
                Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;
                cbMaVatTu.Text = (gridMaster.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
                if (cbMaVatTu.Text != "")
                {
                    cbMaVatTu_KeyDown(null, null);
                }
                else
                    ResetText();
            }
        }

        private void btnSaveGrid_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;

                if (dataTable1.Rows.Count == 0 || selectedRowCount >= dataTable1.Rows.Count)
                    return;
                if (staTus == enumStatus.SuaLuoi)
                {
                    gridMaster.Rows[selectedRowCount].Cells["ma_vat_tu"].Value = cbMaVatTu.Text;
                    gridMaster.Rows[selectedRowCount].Cells["ten_vat_tu"].Value = cbTenVatTu.Text;
                    gridMaster.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value = txtDVT.Text;
                    gridMaster.Rows[selectedRowCount].Cells["chat_luong"].Value = txtChatLuong.Text;
                    gridMaster.Rows[selectedRowCount].Cells["so_luong_yeu_cau"].Value = txtSLYC.Text;
                    gridMaster.Rows[selectedRowCount].Cells["so_luong_thuc_xuat"].Value = txtSLTX.Text;
                    gridMaster.Rows[selectedRowCount].Cells["don_gia"].Value = txtDonGia.Text;
                    gridMaster.Rows[selectedRowCount].Cells["ID_don_vi_tinh"].Value = Dic[cbMaVatTu.Text].ID_Don_vi_tinh;

                    staTus = sttaf;
                }
                if (staTus == enumStatus.XoaLuoi)
                {
                    dataTable1.Rows.RemoveAt(selectedRowCount);
                    staTus = sttaf;
                }
                setStatus(true);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            ResetText();
            staTus = enumStatus.None;
        }

        private void txtMaPhieuNhap_Enter(object sender, EventArgs e)
        {

        }
        DataTable tbAff;


        private void btnSua_Click(object sender, EventArgs e)
        {
            dataTable1.Clear();
            if (txtMaPhieuNhap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã phiếu nhập!");
                return;
            }
            if (initEdit() == true)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                staTus = enumStatus.Sua;
                setStatus(true);
                txtMaPhieuNhap.Enabled = false;
                //  btnEdit_Click(null, null);
            }
            
            tbAff = dataTable1.Copy();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sttaf = staTus;

            try
            {
                Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;

                //string ma_vat_tu = dataTable1.Rows[
                if (dataTable1.Rows.Count == 0 || selectedRowCount >= dataTable1.Rows.Count)
                    return;
                staTus = enumStatus.XoaLuoi;
                btnDel.Enabled = false;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                cbMaVatTu.Text = (gridMaster.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
                txtSLYC.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_yeu_cau"].Value.ToString();
                txtSLTX.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_thuc_xuat"].Value.ToString();
                txtChatLuong.Text = gridMaster.Rows[selectedRowCount].Cells["Chat_luong"].Value.ToString();
                txtDVT.Text = gridMaster.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value.ToString();


                cbMaVatTu_KeyDown(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            new frmNhapKho();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setStatus(false);
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLamMoi.Enabled = true;
            ResetText();

            txtMaPhieuNhap.Text = "";
            txtDiaChi.Text = "";
            txtCongTrinh.Text = "";
            txtLyDo.Text = "";
            txtXuatTaiKho.Text = "";
            txtMaPhieuNhap.Enabled = true;
            dataTable1.Clear();

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

    }
}
