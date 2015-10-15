﻿using System;
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
    /// <summary>
    /// Setup
    /// [ ] Xuất cho nhân viên --> truyền vào ID
    ///     --> Nhân viên đó có thể còn giữ vật tư
    /// [ ] Xác nhận lượng vật tư đã xuất
    /// [ ] Xác nhận hoàn nhập hoặc báo giữ lại VT
    ///     --> NV giữ vật tư thì add vào nợ vật tư
    ///     --> NV hoàn nhập thì cập nhật lại vào kho đã xuất
    /// 
    /// [ ] Xem/sửa phiếu xuất --> truyền vào mã phiếu xuất
    /// [ ] Thêm phiếu xuất mới
    /// 
    /// [ ] Xuất kho, nhưng kho được chọn bị thiếu vật tư, phải mượn từ kho khác --> Tạm chưa xử lý
    /// 
    /// Xử lý ngoại lệ:
    /// [ ] Xuất cho nhân viên chưa có trong DM NV --> Yêu cầu thêm, hoặc ask: tự động thêm (Ko khả thi)
    /// [ ] 
    /// 
    /// Show:
    /// [ ] SL vật tư còn lại trong kho đã chọn
    /// [ ] ChkBox Mượn vật tư sẽ bị disable nếu trong list có vật tư từ kho khác
    /// 
    /// Khởi tạo: 
    /// [ ] SET enable/disable cho các component
    /// [ ] init cho Panel
    /// [ ] init cho các comboBox
    /// [ ] Ràng buột dữ liệu
    /// [ ] 
    /// </summary>
    public partial class frmChiTietPhieuXuatTam : Form
    {
        //------------ New --------------
        FormActionDelegate2 frmAction;
        clsPanelButton2 PanelButton;

        public frmChiTietPhieuXuatTam()
        {
            InitializeComponent();

            DisableControl_ForNew();

            initPanelButton();

        }

        /// <summary>
        /// Demo tinh năng thêm, tắt tạm tính năng sửa.
        /// </summary>
        private void initPanelButton()
        {
            //Init cls Panel Button
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

            PanelButton.setButtonStatus(enumButton2.Xoa, false);
            PanelButton.setButtonStatus(enumButton2.Sua, false);
            PanelButton.setButtonStatus(enumButton2.LamMoi, false);

            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLamMoi.Enabled = false;

            PanelButton.ResetButton();
        }

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
        /// Disable các control, dùng lúc mới load form
        /// </summary>
        private void DisableControl_ForNew()
        {
            //Enable để nhập mã phiếu và check tồn tại, tránh trường hợp trùng mã phiếu
            cbMaPhieuXuatTam.Enabled = true;
            btnCheckMaPhieuXuat.Enabled = true;
            //--------

            cbTenNhanVien.Enabled = false;
            cbMaNhanVien.Enabled = false;
            dtNgayXuat.Enabled = false;
            cbKhoXuat.Enabled = false;
            txtLyDo.Enabled = false;
            txtCongTrinh.Enabled = false;
            txtDiaChi.Enabled = false;

            //Khi bật, nếu đã thêm row vật tư từ kho khác, thì ko thể tắt
            chkboxEnableMuonVT.Enabled = false;

            //Chế độ mượn vật tư từ kho khác, tắt đến khi "chkboxEnableMuonVT" được bật
            cbMuonVTTaiKho.Enabled = false;

            //Control trên grid
            cbMaVatTu.Enabled = false;
            cbTenVatTu.Enabled = false;

            //txtDVT, TxtSL (SL VT còn trong kho) mặc định luôn là ReadOnly, nên ko cần disable
            txtDVT.Enabled = true;
            txtSL.Enabled = true;
            //-----------

            txtSLDN.Enabled = false;
            txtSLTX.Enabled = false;
            chkboxXacNhanXuat.Enabled = false;

            txtSLGL.Enabled = false;
            txtSLHN.Enabled = false;
            chkboxXacNhanHoanNhapGiuLai.Enabled = false;

            btnAddToGrid.Enabled = false;
            btnDelRowInGrid.Enabled = false;
            btnEditRowInGrid.Enabled = false;
            btnSaveGrid.Enabled = false;

            //Disable cả grid
            gridChiTietPhieuXuatTam.Enabled = false;

        }

        //----------------------- Old
        //public frmChiTietPhieuXuatTam()
        //{
        //    InitializeComponent();
        //}

        Dictionary<string, clsDM_NhanVien> DicNhanVien = new Dictionary<string, clsDM_NhanVien>();
        Dictionary<string, clsDMVatTu> Dic = new Dictionary<string, clsDMVatTu>();

        //    Dictionary<string, clsDMVatTu> DicTen = new Dictionary<string, clsDMVatTu>();
        //  DataTable data = new DataTable();

        /* Khiem
        public frmChiTietPhieuXuatTam()
        {
            InitializeComponent();

            
            staTus = enumStatus.None;


             this.cbMaNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbMaNhanVien.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cbKhoXuat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbKhoXuat.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.cbMaVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbMaVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cbTenVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbTenVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            clsDM_Kho dmKho = new clsDM_Kho();
          //  cbKhoNhap.DisplayMember = "Ten_kho";
          //  cbKhoNhap.ValueMember = "ID_kho";
            Dic = GetDict((DataTable)new clsDMVatTu().GetAll());
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
            clsDM_NhanVien dmnv = new clsDM_NhanVien();
           DataTable temp =(DataTable)  dmnv.GetAll();
           DicNhanVien = GetDictMaNhanVien(temp);
          //     AutoCompleteStringCollection combDataMa = new AutoCompleteStringCollection();
            AutoCompleteStringCollection combDataTen = new AutoCompleteStringCollection();
            foreach (string key in DicNhanVien.Keys)
            {
             //   combDataMa.Add(DicNhanVien[key].Ma_nhan_vien);
                combDataTen.Add(DicNhanVien[key].Ten_nhan_vien);

            }


        
            cbKhoXuat.AutoCompleteCustomSource = combDataTen;
            cbKhoXuat.DataSource = temp;
            cbKhoXuat.DisplayMember = "Ten_nhan_vien";
            cbKhoXuat.ValueMember = "ID_nhan_vien";

           // cbMaNhanVien.SelectedIndex = -1;
            cbKhoXuat.SelectedIndex = -1;
            // gridMaster.DataSource = data;
            
            
    }
    //End Khiem */

        public frmChiTietPhieuXuatTam(enumButton2 stt, string MaPhieuXuatTam)
        {
            InitializeComponent();
            staTus = enumStatus.None;


            this.cbMaNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbMaNhanVien.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cbKhoXuat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbKhoXuat.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.cbMaVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbMaVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cbTenVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbTenVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            clsDM_Kho dmKho = new clsDM_Kho();
            //  cbKhoNhap.DisplayMember = "Ten_kho";
            //  cbKhoNhap.ValueMember = "ID_kho";
            Dic = GetDict((DataTable)new clsDMVatTu().GetAll());
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
            clsDM_NhanVien dmnv = new clsDM_NhanVien();
            DataTable temp =(DataTable) dmnv.GetAll();
            DicNhanVien = GetDictMaNhanVien(temp);
            //     AutoCompleteStringCollection combDataMa = new AutoCompleteStringCollection();
            AutoCompleteStringCollection combDataTen = new AutoCompleteStringCollection();
            foreach (string key in DicNhanVien.Keys)
            {
                //   combDataMa.Add(DicNhanVien[key].Ma_nhan_vien);
                combDataTen.Add(DicNhanVien[key].Ten_nhan_vien);

            }



            cbKhoXuat.AutoCompleteCustomSource = combDataTen;
            cbKhoXuat.DataSource = temp;
            cbKhoXuat.DisplayMember = "Ten_nhan_vien";
            cbKhoXuat.ValueMember = "ID_nhan_vien";

            // cbMaNhanVien.SelectedIndex = -1;
            cbKhoXuat.SelectedIndex = -1;
            // gridMaster.DataSource = data;
            //----------
            if (stt == enumButton2.Sua)
            {
                cbMaPhieuXuatTam.Text = MaPhieuXuatTam;

                btnSua_Click(this, EventArgs.Empty);
            }
            else if (stt == enumButton2.Them)
            {
                btnThem_Click(this, EventArgs.Empty);
            }
        }

        public frmChiTietPhieuXuatTam(enumStatus status, clsPhieuNhapKho phieunhap)
        {
            InitializeComponent();
            this.staTus = status;
            if (status == enumStatus.Sua || status == enumStatus.Xoa)
            {
                this.phieuNhapKho = phieunhap;
                DataTable chiTietPhieuNhap = (DataTable)new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieunhap.Ma_phieu_nhap);
                gridChiTietPhieuXuatTam.DataSource = chiTietPhieuNhap;
                //chitiet.get
            }
        }

        public void frmChiTietPhieuXuatTam_Load(object sender, EventArgs e)
        { }
        internal Dictionary<string, clsDM_NhanVien> GetDictMaNhanVien(DataTable dt)
        {
            var areas = new Dictionary<string, clsDM_NhanVien>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                areas.Add(dt.Rows[i]["Ma_nhan_vien"].ToString(), new clsDM_NhanVien(
                    int.Parse( dt.Rows[i]["ID_nhan_vien"].ToString()),
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
                       //long.Parse(dt.Rows[i]["Don_gia"].ToString())
                      // ,
                       int.Parse(dt.Rows[i]["ID_Don_vi_tinh"].ToString())
                    ));

                //   dt.Rows[i]["ten_vat_tu"];

            }
            return areas;
        }

        

        enumStatus staTus = enumStatus.None;
        clsPhieuNhapKho phieuNhapKho = new clsPhieuNhapKho();
        private void btnThem_Click(object sender, EventArgs e)
        {
            /*if (staTus == enumStatus.None)
            {
                staTus = enumStatus.Them;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = false;
                btnLuu.Enabled = true;
                ResetText();
                btnCheckMaPhieuXuat.Enabled = false;
                setStatus(true);

             //   cbMaPhieuXuatTam.Text = "";
                txtDiaChi.Text = "";
                txtCongTrinh.Text = "";
                txtLyDo.Text = "";
                txtXuatTaiKho.Text = "";
                dataTableChiTietPhieuXuatTam.Rows.Clear();
                // gridMaster.ReadOnly = false;
            }*/

        }
        private void ResetAll()
        {
            /*btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLamMoi.Enabled = true;
            btnLuu.Enabled = true;
            ResetText();
            btnCheckMaPhieuXuat.Enabled = true;
            setStatus(true);

            //   cbMaPhieuXuatTam.Text = "";
            txtDiaChi.Text = "";
            txtCongTrinh.Text = "";
            txtLyDo.Text = "";
            txtXuatTaiKho.Text = "";
            dataTableChiTietPhieuXuatTam.Rows.Clear();
            cbMaVatTu.Text = "";
            cbTenVatTu.Text = "";
            txtDVT.Text = "";
            txtSLGL.Text = "0";
            txtSLHN.Text = "0";
            txtSLTX.Text = "0";
            cbKhoXuat.Text = "";
            cbMaPhieuXuatTam.Text = "";
            txtDiaChi.Text = "";
            txtXuatTaiKho.Text = "";*/
        }

        public void setStatus(bool _status)
        {
            //  cbKhoNhap.Enabled = _status;
            //  cbMaPhieuXuatTam.Enabled = _status;

            /*dtNgayXuat.Enabled = _status;
            txtXuatTaiKho.Enabled = _status;
            txtLyDo.Enabled = _status;
            txtCongTrinh.Enabled = _status;
            txtDiaChi.Enabled = _status;
            cbMaVatTu.Enabled = _status;
            cbTenVatTu.Enabled = _status;
            txtSLHN.Enabled = _status;
            txtSLTX.Enabled = _status;
            txtSLGL.Enabled = _status;
            //txtChatLuong.Enabled = _status;
            btnAdd.Enabled = _status;
            btnEdit.Enabled = _status;
            btnSaveGrid.Enabled = _status;
            btnDel.Enabled = _status;*/

            //cbMaPhieuXuatTam.Enabled = _status;

        }
        public bool KiemTraVatTuGridVaTrongKho()
        {

            /*SQLDAL DAL = new SQLDAL();
            DAL.BeginTransaction();
            //DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieuNhap.ID_phieu_nhap);
            for (int i = 0; i < dataTableChiTietPhieuXuatTam.Rows.Count; i++)
            {
                clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                chitiet.Ma_phieu_xuat_tam = (cbMaPhieuXuatTam.Text);
                chitiet.Ma_vat_tu = (dataTableChiTietPhieuXuatTam.Rows[i]["Ma_vat_tu"].ToString());
               // chitiet.So_luong_de_nghi = int.Parse(dataTable1.Rows[i]["So_luong_yeu_cau"].ToString());
           //     chitiet.So_luong_thuc_xuat = int.Parse(dataTable1.Rows[i]["So_luong_thuc_xuat"].ToString());
                chitiet.So_luong_hoan_nhap = int.Parse(dataTableChiTietPhieuXuatTam.Rows[i]["So_luong_hoan_nhap"].ToString());
                chitiet.So_luong_giu_lai = int.Parse(dataTableChiTietPhieuXuatTam.Rows[i]["So_luong_giu_lai"].ToString());

                clsTonDauKy tdk = new clsTonDauKy();
                tdk.ID_kho = int.Parse(txtXuatTaiKho.Text);
                tdk.Ma_vat_tu = chitiet.Ma_vat_tu;
//tdk.So_luong = chitiet.So_luong_thuc_xuat;

                    if (tdk.CheckTonTaiSoDK())
                    {
                        DataTable tb = tdk.GetAllByKey(tdk.Ma_vat_tu);
                        if (tb.Rows.Count == 0)
                        {
                            MessageBox.Show("Vật tư này chưa có trong đầu kỳ! vui lòng nhập tồn đầu kỳ cho vật tư này!");
                            return false;
                        }
                     //   int? so_luong_kho = int.Parse(tb.Rows[0]["so_luong"].ToString()) - chitiet.So_luong_thuc_xuat;
                        //if (so_luong_kho < 0)
                        //{
                        //    MessageBox.Show("Vật tư này không đủ để xuất!");
                        //    return false;
                        //}
                        //tdk.So_luong = so_luong_kho;
                        //if (tdk.Update(DAL) == 0)
                        //{  
                        //    DAL.RollbackTransaction();
                        //    return;
                        //}
                    }
                }*/
            return true;
            }


//        private int GetIDNhanVien(string TenNV)
//        {
//            for(int i =0;i<DicNhanVien.Count;i++)
//            {
////                if(DicNhanVien.Ten_nhan_vien.Equals(TenNV);
////                    return DicNhanVien[i
//            }}

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnCheckMaPhieuXuat.Enabled = true;
            if (cbMaPhieuXuatTam.Text.Trim() == "")
            {
                MessageBox.Show("Mã phiếu bắt buộc nhập!");
                return;
            }
            if (dataTableChiTietPhieuXuatTam.Rows.Count == 0)
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

                                  phieuxuat.ID_Nhan_vien =int.Parse( cbKhoXuat.SelectedValue.ToString());//(DicNhanVien.Select[ cbMaNhanVien.Text].ID_nhan_vien);
                                  phieuxuat.Ly_do = txtLyDo.Text;
                                  phieuxuat.Ngay_xuat = dtNgayXuat.Value;
                                  phieuxuat.Cong_trinh = txtCongTrinh.Text;
                                  phieuxuat.Dia_chi = txtDiaChi.Text;
                                  
                                  if (phieuxuat.Insert(DAL) == 1)
                                  {
                                      try
                                      {
                                        //  DAL.BeginTransaction();
                                          for (int i = 0; i < dataTableChiTietPhieuXuatTam.Rows.Count; i++)
                                          {
                                              clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                                              chitiet.Ma_phieu_xuat_tam = (cbMaPhieuXuatTam.Text);
                                              chitiet.Ma_vat_tu = (dataTableChiTietPhieuXuatTam.Rows[i]["Ma_vat_tu"].ToString());
                                          //    chitiet.So_luong_de_nghi = int.Parse(dataTable1.Rows[i]["So_luong_yeu_cau"].ToString());
                                         //     chitiet.So_luong_thuc_xuat = int.Parse(dataTable1.Rows[i]["So_luong_thuc_xuat"].ToString());
                                              chitiet.So_luong_hoan_nhap = int.Parse(dataTableChiTietPhieuXuatTam.Rows[i]["So_luong_hoan_nhap"].ToString());
                                              chitiet.So_luong_giu_lai = int.Parse(dataTableChiTietPhieuXuatTam.Rows[i]["So_luong_giu_lai"].ToString());
                                           //   chitiet = txtCongTrinh
                                              if (chitiet.Insert(DAL) == 0)
                                              {


                                                  DAL.RollbackTransaction();
                                                  return;
                                              }
                                              clsTonDauKy tdk = new clsTonDauKy();
                                              DataTable temp = tdk.GetAllByKey(chitiet.Ma_vat_tu);
                                              tdk.Ma_vat_tu = chitiet.Ma_vat_tu;
                                              tdk.ID_kho = phieuxuat.ID_kho;
                                              //cap nhat lai so luong sau khi xuat
                                          //    tdk.So_luong = int.Parse( temp.Rows[0]["So_luong"].ToString()) - chitiet.So_luong_thuc_xuat;
                                              tdk.Update(DAL);

                                          }
                                      //    DAL.CommitTransaction();

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
                                  //ResetText();
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
                            if (KiemTraVatTuGridVaTrongKho() == true)
                            {
                                clsPhieuXuatTamVatTu phieuxuat = new clsPhieuXuatTamVatTu();
                                phieuxuat.Ma_phieu_xuat_tam = cbMaPhieuXuatTam.Text;
                                if (phieuxuat.CheckTonTaiSoDK())
                                {
                                    // phieunhap.
                                    phieuxuat.ID_kho = 1;

                                    phieuxuat.ID_Nhan_vien = int.Parse(cbKhoXuat.SelectedValue.ToString());//(DicNhanVien.Select[ cbMaNhanVien.Text].ID_nhan_vien);
                                    phieuxuat.Ly_do = txtLyDo.Text;
                                    phieuxuat.Ngay_xuat = dtNgayXuat.Value;
                                    phieuxuat.Cong_trinh = txtCongTrinh.Text;
                                    phieuxuat.Dia_chi = txtDiaChi.Text;

                                    if (phieuxuat.Update(DAL) == 1)
                                    {
                                        try
                                        {
                                            //  DAL.BeginTransaction();

                                            for (int i = 0; i < tbAff.Rows.Count; i++)
                                            {
                                                clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                                                chitiet.Ma_phieu_xuat_tam = (cbMaPhieuXuatTam.Text);
                                                chitiet.Ma_vat_tu = (tbAff.Rows[i]["ma_vat_tu"].ToString());
                                        //        chitiet.So_luong_thuc_xuat = int.Parse(tbAff.Rows[i]["So_luong_thuc_xuat"].ToString());

                                                clsTonDauKy tdk = new clsTonDauKy();
                                                DataTable temp = tdk.GetAllByKey(chitiet.Ma_vat_tu);
                                                tdk.Ma_vat_tu = chitiet.Ma_vat_tu;
                                                tdk.ID_kho = phieuxuat.ID_kho;
                                            //    tdk.So_luong =int.Parse( temp.Rows[0]["So_luong"].ToString())+chitiet.So_luong_thuc_xuat;

                                                tdk.Update(DAL);
                                                if (chitiet.Delete(DAL) == 0)
                                                    return;

                                            }
                                                for (int i = 0; i < dataTableChiTietPhieuXuatTam.Rows.Count; i++)
                                                {
                                                    clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                                                    chitiet.Ma_phieu_xuat_tam = (cbMaPhieuXuatTam.Text);
                                                    chitiet.Ma_vat_tu = (dataTableChiTietPhieuXuatTam.Rows[i]["Ma_vat_tu"].ToString());
                                                    //    chitiet.So_luong_de_nghi = int.Parse(dataTable1.Rows[i]["So_luong_yeu_cau"].ToString());
                                                 //   chitiet.So_luong_thuc_xuat = int.Parse(dataTable1.Rows[i]["So_luong_thuc_xuat"].ToString());
                                                    chitiet.So_luong_hoan_nhap = int.Parse(dataTableChiTietPhieuXuatTam.Rows[i]["So_luong_hoan_nhap"].ToString());
                                                    chitiet.So_luong_giu_lai = int.Parse(dataTableChiTietPhieuXuatTam.Rows[i]["So_luong_giu_lai"].ToString());
                                                    //   chitiet = txtCongTrinh
                                                    if (chitiet.Insert(DAL) == 0)
                                                    {


                                                        DAL.RollbackTransaction();
                                                        return;
                                                    }
                                                    clsTonDauKy tdk = new clsTonDauKy();
                                                    DataTable temp = tdk.GetAllByKey(chitiet.Ma_vat_tu);
                                                    tdk.Ma_vat_tu = chitiet.Ma_vat_tu;
                                                    tdk.ID_kho = phieuxuat.ID_kho;
                                                    //cap nhat lai so luong sau khi xuat
                                            //        tdk.So_luong = int.Parse(temp.Rows[0]["So_luong"].ToString()) - chitiet.So_luong_thuc_xuat+chitiet.So_luong_hoan_nhap;
                                                    tdk.Update(DAL);

                                                }
                                            //    DAL.CommitTransaction();

                                        }
                                        catch (Exception ex)
                                        {
                                            DAL.RollbackTransaction();
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
            ResetText();
            dataTableChiTietPhieuXuatTam.Clear();
            initEdit();
        }

        private bool initEdit()
        {
            /*
            clsPhieuXuatTamVatTu clsXuatTam = new clsPhieuXuatTamVatTu();
            clsXuatTam.Ma_phieu_xuat_tam = cbMaPhieuXuatTam.Text;
            if (clsXuatTam.CheckTonTaiSoDK() == true)
            {
                DataTable tb = clsXuatTam.GetAll(cbMaPhieuXuatTam.Text.Trim());
                // dtNgayNhap.Text = tb.Rows[0]["Ngay_nhap"].ToString();
                dtNgayXuat.Text = string.Format("{0:dd/MM/yyyy}", tb.Rows[0]["Ngay_xuat"]);
                cbKhoXuat.Text = tb.Rows[0]["Ten_nhan_vien"].ToString();
                txtLyDo.Text = tb.Rows[0]["Ly_do"].ToString();
                txtXuatTaiKho.Text = tb.Rows[0]["ID_kho"].ToString();
                txtCongTrinh.Text = tb.Rows[0]["cong_trinh"].ToString();
                txtDiaChi.Text = tb.Rows[0]["Dia_chi"].ToString();
                clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                DataTable vChiTiet = chitiet.GetAll(cbMaPhieuXuatTam.Text);
                for (int i = 0; i < vChiTiet.Rows.Count; i++)
                {
                    //  dataTable1.Rows[i]["Ma_phieu_nhap"] = vChiTiet.Rows[i]["ma_phieu_nhap"].ToString();


                    DataRow dr = dataTableChiTietPhieuXuatTam.NewRow();
                    //dr["Ma_vat_tu"] = vChiTiet.Rows[i]["ma_phieu_nhap"].ToString();
                    dr["ma_vat_tu"] = vChiTiet.Rows[i]["ma_vat_tu"].ToString();
                    dr["Ten_vat_tu"] = vChiTiet.Rows[i]["Ten_vat_tu"].ToString();
                    //  dr["don_vi_tinh"] = vChiTiet.Rows[i]["don_vi_tinh"].ToString() ;
                  //  dr["chat_luong"] = vChiTiet.Rows[i]["chat_luong"].ToString();
                    dr["so_luong_hoan_nhap"] = vChiTiet.Rows[i]["so_luong_hoan_nhap"].ToString();
                    dr["so_luong_giu_lai"] = vChiTiet.Rows[i]["so_luong_giu_lai"].ToString();

                    dr["so_luong_thuc_xuat"] = vChiTiet.Rows[i]["so_luong_thuc_xuat"].ToString();
                 //   dr["don_gia"] = vChiTiet.Rows[i]["don_gia"].ToString();
                   // dr["Thanh_tien"] = vChiTiet.Rows[i]["thanh_tien"].ToString();// int.Parse(vChiTiet.Rows[i]["don_gia"].ToString()) * int.Parse(vChiTiet.Rows[i]["so_luong_thuc_xuat"].ToString());
                    dr["Ten_Don_vi_tinh"] = vChiTiet.Rows[i]["ten_don_vi_tinh"].ToString();
                    dr["ID_Don_vi_tinh"] = vChiTiet.Rows[i]["ID_don_vi_tinh"].ToString();

                    dataTableChiTietPhieuXuatTam.Rows.Add(dr);
                }


                MessageBox.Show("Tồn tại mã phiếu nhập trong csdl");
                return true;
            }
            else
            {
                MessageBox.Show("Chưa Tồn tại mã phiếu nhập trong csdl");

            }*/
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
            if (staTus == enumStatus.SuaLuoi || staTus == enumStatus.XoaLuoi || (e!=null && e.KeyCode == Keys.Enter))
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
            if(staTus ==enumStatus.Sua ||staTus ==enumStatus.Them)
                sttaf = staTus;
            if ((int.Parse(txtSLHN.Text)) < 0 || (int.Parse(txtSLTX.Text)) < 0)
            {
                MessageBox.Show("Số lượng vật tư không được phép giá trị âm !");
                return;
            }


            if (cbMaVatTu.Text == "" || cbTenVatTu.Text == "")
            {
                MessageBox.Show("Mã vật tư và tên vật tư không được rỗng !");
                return;
            }
            DataRow[] result = dataTableChiTietPhieuXuatTam.Select("Ma_vat_tu =" + cbMaVatTu.Text);
            if (result.Length == 0)
            {
                DataRow dr = dataTableChiTietPhieuXuatTam.NewRow();
                dr["Ma_vat_tu"] = cbMaVatTu.Text;
                dr["ten_vat_tu"] = cbTenVatTu.Text;
                dr["Ten_don_vi_tinh"] = txtDVT.Text;
              //  dr["chat_luong"] = txtChatLuong.Text;
                dr["so_luong_hoan_nhap"] = txtSLHN.Text;

                dr["so_luong_thuc_xuat"] = txtSLTX.Text;
                dr["so_luong_giu_lai"] = txtSLGL.Text;
                dr["ID_don_vi_tinh"] = Dic[cbMaVatTu.Text].ID_Don_vi_tinh;

               // dr["thanh_tien"] = int.Parse(txtDonGia.Text) * int.Parse(txtSLTX.Text);

                dataTableChiTietPhieuXuatTam.Rows.Add(dr);
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
            txtSLHN.Text = "0";
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
            setStatus(true);
            //staTus = enumStatus.SuaLuoi;
            try
            {
                if (staTus == enumStatus.Sua || staTus == enumStatus.Them)
                    sttaf = staTus;

                if (dataTableChiTietPhieuXuatTam.Rows.Count == 0)
                    return;
                staTus = enumStatus.SuaLuoi;
                btnAddToGrid.Enabled = false;
                btnEditRowInGrid.Enabled = false;
                btnDelRowInGrid.Enabled = false;
                Int32 selectedRowCount = gridChiTietPhieuXuatTam.CurrentCell.RowIndex;
                cbMaVatTu.Text = (gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
                txtSLHN.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_hoan_nhap"].Value.ToString();
                txtSLTX.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_thuc_xuat"].Value.ToString();

                txtSLGL.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_giu_lai"].Value.ToString();

//                txtSL.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_giu_lai"].Value.ToString();
                //txtChatLuong.Text = gridMaster.Rows[selectedRowCount].Cells["Chat_luong"].Value.ToString();
                txtDVT.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value.ToString();


                cbMaVatTu_KeyDown(null, null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void gridMaster_MouseClick(object sender, MouseEventArgs e)
        {
            if (staTus == enumStatus.SuaLuoi || staTus == enumStatus.XoaLuoi)
            {
                Int32 selectedRowCount = gridChiTietPhieuXuatTam.CurrentCell.RowIndex;
                cbMaVatTu.Text = (gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
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
                Int32 selectedRowCount = gridChiTietPhieuXuatTam.CurrentCell.RowIndex;

                if (dataTableChiTietPhieuXuatTam.Rows.Count == 0 || selectedRowCount >= dataTableChiTietPhieuXuatTam.Rows.Count)
                    return;
                if (staTus == enumStatus.SuaLuoi)
                {
                    gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ma_vat_tu"].Value = cbMaVatTu.Text;
                    gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ten_vat_tu"].Value = cbTenVatTu.Text;
                    gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value = txtDVT.Text;
                  //  gridMaster.Rows[selectedRowCount].Cells["chat_luong"].Value = txtChatLuong.Text;
                    gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["so_luong_hoan_nhap"].Value = txtSLHN.Text;
                    gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["so_luong_thuc_xuat"].Value = txtSLTX.Text;
                    gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["so_luong_giu_lai"].Value = txtSLGL.Text;
              //      gridMaster.Rows[selectedRowCount].Cells["don_gia"].Value = txtDonGia.Text;
                    gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ID_don_vi_tinh"].Value = Dic[cbMaVatTu.Text].ID_Don_vi_tinh;

                    staTus = sttaf;
                }
                if (staTus == enumStatus.XoaLuoi)
                {
                    dataTableChiTietPhieuXuatTam.Rows.RemoveAt(selectedRowCount);
                    cbMaVatTu.Text = "";
                    cbTenVatTu.Text = "";
                    txtDVT.Text = "";
                    txtSLGL.Text = "0";
                    txtSLHN.Text = "0";
                    txtSLTX.Text = "0";
                    staTus = sttaf;
                }
                setStatus(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            staTus = sttaf;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            btnAddToGrid.Enabled = true;
            btnEditRowInGrid.Enabled = true;
            ResetText();
            staTus = enumStatus.None;
        }

        private void cbMaPhieuXuatTam_Enter(object sender, EventArgs e)
        {

        }

        DataTable tbAff;


        private void btnSua_Click(object sender, EventArgs e)
        {
            tbAff = dataTableChiTietPhieuXuatTam.Copy();
            setStatus(true);
            dataTableChiTietPhieuXuatTam.Clear();
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

            tbAff = dataTableChiTietPhieuXuatTam.Copy();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sttaf = staTus;

            try
            {
                Int32 selectedRowCount = gridChiTietPhieuXuatTam.CurrentCell.RowIndex;

                //string ma_vat_tu = dataTable1.Rows[
                if (dataTableChiTietPhieuXuatTam.Rows.Count == 0 || selectedRowCount >= dataTableChiTietPhieuXuatTam.Rows.Count)
                    return;
                staTus = enumStatus.XoaLuoi;
                btnDelRowInGrid.Enabled = false;
                btnAddToGrid.Enabled = false;
                btnEditRowInGrid.Enabled = false;
                cbMaVatTu.Text = (gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
                txtSLHN.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_hoan_nhap"].Value.ToString();
                txtSLTX.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_thuc_xuat"].Value.ToString();
                txtSLGL.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_giu_lai"].Value.ToString();
                //txtChatLuong.Text = gridMaster.Rows[selectedRowCount].Cells["Chat_luong"].Value.ToString();
                txtDVT.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value.ToString();


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

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (staTus == enumStatus.Sua || staTus == enumStatus.Them)
                sttaf = staTus;

            try
            {
                Int32 selectedRowCount = gridChiTietPhieuXuatTam.CurrentCell.RowIndex;

                //string ma_vat_tu = dataTable1.Rows[
                if (dataTableChiTietPhieuXuatTam.Rows.Count == 0 || selectedRowCount >= dataTableChiTietPhieuXuatTam.Rows.Count)
                    return;
                //staTus = enumStatus.XoaLuoi;
              //  PanelButton.setClickStatus(enumButton2.XoaLuoi);
                btnDelRowInGrid.Enabled = false;
                btnAddToGrid.Enabled = false;
                btnEditRowInGrid.Enabled = false;
                cbMaVatTu.Text = (gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
                txtSLGL.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_giu_lai"].Value.ToString();
                txtSLTX.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_thuc_xuat"].Value.ToString();
                txtSLHN.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["So_luong_hoan_nhap"].Value.ToString();
                txtDVT.Text = gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value.ToString();
                cbTenVatTu.Text = (gridChiTietPhieuXuatTam.Rows[selectedRowCount].Cells["ten_vat_tu"].Value.ToString());
                staTus = enumStatus.XoaLuoi;
                cbMaVatTu_KeyDown(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool setFormData_By_MaPhieuNhap(string Ma_Phieu_Nhap)
        {
            clsPhieuNhapKho PhieuNhap = new clsPhieuNhapKho();

            if (PhieuNhap.CheckTonTaiSoDK(Ma_Phieu_Nhap))
            {
                //fill vào FRM
                DataTable tb = PhieuNhap.GetAll(Ma_Phieu_Nhap);

                cbMaPhieuXuatTam.Text = tb.Rows[0]["ma_phieu_xuat_tam"].ToString();
               // txtMaPhieuNhap.Text = Ma_Phieu_Nhap;
                dtNgayXuat.Text = string.Format("{0:dd/MM/yyyy}", tb.Rows[0]["Ngay_xuat"]);
                cbKhoXuat.Text = tb.Rows[0]["ten_nhan_vien"].ToString();
                txtLyDo.Text = tb.Rows[0]["Ly_do"].ToString();
                txtCongTrinh.Text = tb.Rows[0]["cong_trinh"].ToString();
                txtDiaChi.Text = tb.Rows[0]["dia_chi"].ToString();
             //   txtDiaChi.Text = tb.Rows[0]["Dia_chi"].ToString();

                //Fill vào grid
                //DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(Ma_Phieu_Nhap);

                //dataTable1 = chiTietPhieuNhap;
                //gridMaster.DataSource = dataTable1;


                //clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();

                DataTable vChiTiet = (DataTable)new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(Ma_Phieu_Nhap);

                for (int i = 0; i < vChiTiet.Rows.Count; i++)
                {
                    DataRow dr = dataTableChiTietPhieuXuatTam.NewRow();

                    dr["ma_vat_tu"] = vChiTiet.Rows[i]["ma_vat_tu"].ToString();
                    dr["Ten_vat_tu"] = vChiTiet.Rows[i]["Ten_vat_tu"].ToString();
                    dr["Ten_Don_vi_tinh"] = vChiTiet.Rows[i]["ten_don_vi_tinh"].ToString();
                    dr["ID_Don_vi_tinh"] = vChiTiet.Rows[i]["ID_don_vi_tinh"].ToString();
                    dr["chat_luong"] = vChiTiet.Rows[i]["chat_luong"].ToString();
                    dr["so_luong_giu_lai"] = vChiTiet.Rows[i]["so_luong_giu_lai"].ToString();
                    dr["so_luong_thuc_xuat"] = vChiTiet.Rows[i]["so_luong_thuc_lanh"].ToString();
                    dr["don_gia"] = vChiTiet.Rows[i]["don_gia"].ToString();
                    dr["Thanh_tien"] = vChiTiet.Rows[i]["thanh_tien"].ToString(); // int.Parse(vChiTiet.Rows[i]["don_gia"].ToString()) * int.Parse(vChiTiet.Rows[i]["so_luong_thuc_xuat"].ToString());

                    dataTableChiTietPhieuXuatTam.Rows.Add(dr);
                }
                return true;
            }
            else
                return false;
        }

        private void cbMaPhieuXuatTam_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmChiTietPhieuXuatTam_Load_1(object sender, EventArgs e)
        {

        }

        private void cbLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetText();
            ResetAll();
            staTus = enumStatus.None;

        }
    }
}