using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
using Inventory.NhapXuat;
namespace Inventory.XuatTamVatTu
{
    public partial class frmChiTietPhieuXuatTam : Form
    {
        //public frmChiTietPhieuXuatTam()
        //{
        //    InitializeComponent();
        //}
        Dictionary<string, clsDM_NhanVien> DicNhanVien = new Dictionary<string, clsDM_NhanVien>();
             Dictionary<string, clsDMVatTu> Dic = new Dictionary<string, clsDMVatTu>();

        //    Dictionary<string, clsDMVatTu> DicTen = new Dictionary<string, clsDMVatTu>();
        //  DataTable data = new DataTable();
        public frmChiTietPhieuXuatTam()
        {
            InitializeComponent();
            staTus = enumStatus.None;


             this.cbMaNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbMaNhanVien.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cbTenNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbTenNhanVien.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.cbMaVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbMaVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cbTenVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbTenVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            clsDM_Kho dmKho = new clsDM_Kho();
          //  cbKhoNhap.DisplayMember = "Ten_kho";
          //  cbKhoNhap.ValueMember = "ID_kho";
            Dic = GetDict(new clsDMVatTu().GetAll());
            //    DicTen = GetDictTen(new clsDMVatTu().GetAll());

           // cbKhoNhap.DataSource = dmKho.GetAll();

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

            DicNhanVien =  GetDictMaNhanVien(new clsDM_NhanVien().GetAll());
               AutoCompleteStringCollection combDataMa = new AutoCompleteStringCollection();
            AutoCompleteStringCollection combDataTen = new AutoCompleteStringCollection();
            foreach (string key in DicNhanVien.Keys)
            {
                combDataMa.Add(DicNhanVien[key].Ma_nhan_vien);
                combDataTen.Add(DicNhanVien[key].Ten_nhan_vien);

            }


            cbMaNhanVien.AutoCompleteCustomSource = combDataMa;
            cbMaNhanVien.DataSource = combDataMa;
            cbTenNhanVien.AutoCompleteCustomSource = combDataTen;
            cbTenNhanVien.DataSource = combDataTen;
            cbMaNhanVien.SelectedIndex = -1;
            cbTenNhanVien.SelectedIndex = -1;
            // gridMaster.DataSource = data;
        }
        public void frmChiTietPhieuXuatTam_Load(object sender, EventArgs e)
        { }
        internal Dictionary<string, clsDM_NhanVien> GetDictMaNhanVien(DataTable dt)
        {
            var areas = new Dictionary<string, clsDM_NhanVien>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                areas.Add(dt.Rows[i]["Ma_nhan_vien"].ToString(), new clsDM_NhanVien(

                     dt.Rows[i]["Ma_nhan_vien"].ToString(),
                      dt.Rows[i]["Ten_nhan_vien"].ToString(),
                 bool.Parse (dt.Rows[i]["Trang_thai"].ToString())
                       
                    ));

                //   dt.Rows[i]["ten_vat_tu"];

            }
            return areas;
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
                       int.Parse(dt.Rows[i]["ID_Don_vi_tinh"].ToString())
                    ));

                //   dt.Rows[i]["ten_vat_tu"];

            }
            return areas;
        }

        public frmChiTietPhieuXuatTam(enumStatus status, clsPhieuNhapKho phieunhap)
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

             //   cbMaPhieuXuatTam.Text = "";
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
          //  cbKhoNhap.Enabled = _status;
          //  cbMaPhieuXuatTam.Enabled = _status;
            dtNgayNhap.Enabled = _status;
            txtXuatTaiKho.Enabled = _status;
            txtLyDo.Enabled = _status;
            txtCongTrinh.Enabled = _status;
            txtDiaChi.Enabled = _status;
            cbMaVatTu.Enabled = _status;
            cbTenVatTu.Enabled = _status;
            txtSLYC.Enabled = _status;
            txtSLTX.Enabled = _status;
            //txtChatLuong.Enabled = _status;
            btnAdd.Enabled = _status;
            btnEdit.Enabled = _status;
            btnSaveGrid.Enabled = _status;
            btnDel.Enabled = _status;

            //cbMaPhieuXuatTam.Enabled = _status;

        }
        public bool KiemTraVatTuGridVaTrongKho()
        {

            SQLDAL DAL = new SQLDAL();
            DAL.BeginTransaction();
            //DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieuNhap.ID_phieu_nhap);
            for (int i = 0; i < dataTable1.Rows.Count; i++)
            {
                clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                chitiet.Ma_phieu_xuat_tam = (cbMaPhieuXuatTam.Text);
                chitiet.Ma_vat_tu = (dataTable1.Rows[i]["Ma_vat_tu"].ToString());
                chitiet.So_luong_de_nghi = int.Parse(dataTable1.Rows[i]["So_luong_yeu_cau"].ToString());
                chitiet.So_luong_thuc_xuat = int.Parse(dataTable1.Rows[i]["So_luong_thuc_xuat"].ToString());
                chitiet.So_luong_hoan_nhap = int.Parse(dataTable1.Rows[i]["So_luong_hoan_nhap"].ToString());
                chitiet.So_luong_giu_lai = int.Parse(dataTable1.Rows[i]["So_luong_giu_lai"].ToString());

                clsTonDauKy tdk = new clsTonDauKy();
                tdk.ID_kho = int.Parse(txtXuatTaiKho.Text);
                tdk.Ma_vat_tu = chitiet.Ma_vat_tu;
                tdk.So_luong = chitiet.So_luong_thuc_xuat;

                    if (tdk.CheckTonTaiSoDK())
                    {
                        DataTable tb = tdk.GetAllByKey(tdk.Ma_vat_tu);
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Vật tư này chưa có trong đầu kỳ! vui lòng nhập tồn đầu kỳ cho vật tư này!");
                            return false;
                        }
                        int? so_luong_kho = tdk.So_luong - int.Parse(tb.Rows[0]["so_luong_thuc_xuat"].ToString());
                        if (so_luong_kho < 0)
                        {
                            MessageBox.Show("Vật tư này không đủ để xuất!");
                            return false;
                        }
                        //tdk.So_luong = so_luong_kho;
                        //if (tdk.Update(DAL) == 0)
                        //{  
                        //    DAL.RollbackTransaction();
                        //    return;
                        //}
                    }
                }
            return true;
            }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbMaPhieuXuatTam.Text.Trim() == "")
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
            switch (staTus)
            {

                case enumStatus.Them:

                     
                      try
                      {
                        //con hang trong kho 
                          if (KiemTraVatTuGridVaTrongKho() == true)
                          {
                              clsPhieuXuatTamVatTu phieuxuat = new clsPhieuXuatTamVatTu();
                              phieuxuat.Ma_phieu_xuat_tam = cbMaPhieuXuatTam.Text;
                              if (!phieuxuat.CheckTonTaiSoDK())
                              {
                                  // phieunhap.
                                  phieuxuat.ID_kho = 1;
                                  phieuxuat.ID_Nhan_vien = int.Parse(cbMaNhanVien.Text);
                                  phieuxuat.Ly_do = txtLyDo.Text;
                                  phieuxuat.Ngay_xuat = dtNgayNhap.Value;
                                  if (phieuxuat.Insert(DAL) == 1)
                                  {
                                      try
                                      {
                                          DAL.BeginTransaction();
                                          for (int i = 0; i < dataTable1.Rows.Count; i++)
                                          {
                                              clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                                              chitiet.Ma_phieu_xuat_tam = (cbMaPhieuXuatTam.Text);
                                              chitiet.Ma_vat_tu = (dataTable1.Rows[i]["Ma_vat_tu"].ToString());
                                              chitiet.So_luong_de_nghi = int.Parse(dataTable1.Rows[i]["So_luong_yeu_cau"].ToString());
                                              chitiet.So_luong_thuc_xuat = int.Parse(dataTable1.Rows[i]["So_luong_thuc_xuat"].ToString());
                                              chitiet.So_luong_hoan_nhap = int.Parse(dataTable1.Rows[i]["So_luong_hoan_nhap"].ToString());
                                              chitiet.So_luong_giu_lai = int.Parse(dataTable1.Rows[i]["So_luong_giu_lai"].ToString());

                                              if (chitiet.Insert(DAL) == 0)
                                              {
                                                  DAL.RollbackTransaction();
                                                  return;
                                              }
                                          }
                                          DAL.CommitTransaction();

                                      }
                                      catch (Exception ex)
                                      {
                                          DAL.RollbackTransaction();
                                      }

                                  }
                                  MessageBox.Show("Thêm thành công");
                                  staTus = enumStatus.None;
                                  setStatus(true);
                                  btnThem.Enabled = true;
                                  btnXoa.Enabled = true;
                                  btnSua.Enabled = true;
                                  btnLamMoi.Enabled = true;
                              }
                          }
                          break;

                      }
                      catch (Exception ex)
                      {

                          break;
                      }
            
            
                case enumStatus.Sua:
                    {
                       
                        DAL.BeginTransaction();
                        try
                        {
                            clsPhieuNhapKho phieunhap = new clsPhieuNhapKho();
                            phieunhap.Ma_phieu_nhap = cbMaPhieuXuatTam.Text;
                            {
                                // phieunhap.
                                phieunhap.ID_kho = 1;
                                phieunhap.Ma_phieu_nhap = cbMaPhieuXuatTam.Text;
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
                                        int so_luong = int.Parse(tbAff.Rows[i]["So_luong_thuc_xuat"].ToString());
                                        DataTable tbnews = tdk.GetAllByKey(ma_vat_tu);
                                        int so_luong_ton = int.Parse(tbnews.Rows[0]["So_luong"].ToString());
                                        int so_luong_thuc = so_luong_ton - so_luong;
                                        if (so_luong_thuc <= 0)
                                        {
                                            MessageBox.Show("Hàng này ko thể cập nhật lại số lượng vì sau khi cập nhật sẽ bị âm!");
                                            return;
                                        }
                                        tdk.So_luong = so_luong_thuc;
                                        tdk.Ma_vat_tu = ma_vat_tu;
                                        tdk.ID_kho = 1;
                                        tdk.Update(DAL);
                                        check.removebyKey(DAL, cbMaPhieuXuatTam.Text, ma_vat_tu);

                                    }


                                    for (int i = 0; i < dataTable1.Rows.Count; i++)
                                    {
                                        clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();

                                        //chitiet.removebyKey(cbMaPhieuXuatTam.Text);
                                        //    chitiet.ID_chi_tiet_phieu_nhap = int.Parse(gridMaster.Rows[i].Cells["ID_chi_tiet_phieu_nhap"].ToString());
                                        chitiet.Ma_phieu_nhap = (cbMaPhieuXuatTam.Text);
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
            clsNhap.Ma_phieu_nhap = cbMaPhieuXuatTam.Text;
            if (clsNhap.CheckTonTaiSoDK() == true)
            {
                DataTable tb = clsNhap.GetAll(cbMaPhieuXuatTam.Text.Trim());
                // dtNgayNhap.Text = tb.Rows[0]["Ngay_nhap"].ToString();
                dtNgayNhap.Text = string.Format("{0:dd/MM/yyyy}", tb.Rows[0]["Ngay_lap"]);

                txtLyDo.Text = tb.Rows[0]["Ly_do"].ToString();
                txtXuatTaiKho.Text = tb.Rows[0]["ID_kho"].ToString();
                txtCongTrinh.Text = tb.Rows[0]["cong_trinh"].ToString();
                txtDiaChi.Text = tb.Rows[0]["Dia_chi"].ToString();
                clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
                DataTable vChiTiet = chitiet.GetAll(cbMaPhieuXuatTam.Text);
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
            if (staTus == enumStatus.SuaLuoi || staTus == enumStatus.XoaLuoi || e.KeyCode == Keys.Enter)
            {
                var val = Dic[cbMaVatTu.Text.Trim()];
                cbTenVatTu.Text = val.Ten_vat_tu.ToString();
                txtDVT.Text = val.ten_don_vi_tinh.ToString();

                //txtDonGia.Text = val.Don_gia.ToString();


            }

        }

        private void cbTenNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            //if (staTus == enumStatus.SuaLuoi || staTus == enumStatus.XoaLuoi || e.KeyCode == Keys.Enter)
            //{
            //    var val = Dic[cbMaVatTu.Text.Trim()];
            //    cbTenVatTu.Text = val.Ten_vat_tu.ToString();
            //    txtDVT.Text = val.ten_don_vi_tinh.ToString();

            //    txtDonGia.Text = val.Don_gia.ToString();


            //}

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
                        //txtDonGia.Text = val.Don_gia.ToString();
                    }
                }
            }
        }
        enumStatus sttaf;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            sttaf = staTus;
            if ((int.Parse(txtSLYC.Text)) < 0 || (int.Parse(txtSLTX.Text)) < 0)
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
              //  dr["chat_luong"] = txtChatLuong.Text;
                dr["so_luong_yeu_cau"] = txtSLYC.Text;
                dr["so_luong_thuc_xuat"] = txtSLTX.Text;
               // dr["don_gia"] = txtDonGia.Text;
                dr["ID_don_vi_tinh"] = Dic[cbMaVatTu.Text].ID_Don_vi_tinh;

               // dr["thanh_tien"] = int.Parse(txtDonGia.Text) * int.Parse(txtSLTX.Text);

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
            //txtChatLuong.Text = "";
            txtSLTX.Text = "0";
            txtSLYC.Text = "0";
          //  txtDonGia.Text = "0";

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
                //txtChatLuong.Text = gridMaster.Rows[selectedRowCount].Cells["Chat_luong"].Value.ToString();
                txtDVT.Text = gridMaster.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value.ToString();


                cbMaVatTu_KeyDown(null, null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void gridMaster_MouseClick(object sender, MouseEventArgs e)
        {
            if (staTus == enumStatus.SuaLuoi || staTus == enumStatus.XoaLuoi)
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
                  //  gridMaster.Rows[selectedRowCount].Cells["chat_luong"].Value = txtChatLuong.Text;
                    gridMaster.Rows[selectedRowCount].Cells["so_luong_yeu_cau"].Value = txtSLYC.Text;
                    gridMaster.Rows[selectedRowCount].Cells["so_luong_thuc_xuat"].Value = txtSLTX.Text;
              //      gridMaster.Rows[selectedRowCount].Cells["don_gia"].Value = txtDonGia.Text;
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
            catch (Exception ex)
            {
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

        private void cbMaPhieuXuatTam_Enter(object sender, EventArgs e)
        {

        }
        DataTable tbAff;


        private void btnSua_Click(object sender, EventArgs e)
        {
            dataTable1.Clear();
            if (cbMaPhieuXuatTam.Text == "")
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
                cbMaPhieuXuatTam.Enabled = false;
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
                //txtChatLuong.Text = gridMaster.Rows[selectedRowCount].Cells["Chat_luong"].Value.ToString();
                txtDVT.Text = gridMaster.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value.ToString();


                cbMaVatTu_KeyDown(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmChiTietPhieuXuatTam_Load()
        {

        }
    }
}