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
            clsDM_NhanVien dmnv = new clsDM_NhanVien();
           DataTable temp =  dmnv.GetAll();
           DicNhanVien = GetDictMaNhanVien(temp);
          //     AutoCompleteStringCollection combDataMa = new AutoCompleteStringCollection();
            AutoCompleteStringCollection combDataTen = new AutoCompleteStringCollection();
            foreach (string key in DicNhanVien.Keys)
            {
             //   combDataMa.Add(DicNhanVien[key].Ma_nhan_vien);
                combDataTen.Add(DicNhanVien[key].Ten_nhan_vien);

            }


        
            cbTenNhanVien.AutoCompleteCustomSource = combDataTen;
            cbTenNhanVien.DataSource = temp;
            cbTenNhanVien.DisplayMember = "Ten_nhan_vien";
            cbTenNhanVien.ValueMember = "ID_nhan_vien";

           // cbMaNhanVien.SelectedIndex = -1;
            cbTenNhanVien.SelectedIndex = -1;
            // gridMaster.DataSource = data;
        }

        public frmChiTietPhieuXuatTam(enumButton2 stt, string MaPhieuXuatTam)
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
            clsDM_NhanVien dmnv = new clsDM_NhanVien();
            DataTable temp = dmnv.GetAll();
            DicNhanVien = GetDictMaNhanVien(temp);
            //     AutoCompleteStringCollection combDataMa = new AutoCompleteStringCollection();
            AutoCompleteStringCollection combDataTen = new AutoCompleteStringCollection();
            foreach (string key in DicNhanVien.Keys)
            {
                //   combDataMa.Add(DicNhanVien[key].Ma_nhan_vien);
                combDataTen.Add(DicNhanVien[key].Ten_nhan_vien);

            }



            cbTenNhanVien.AutoCompleteCustomSource = combDataTen;
            cbTenNhanVien.DataSource = temp;
            cbTenNhanVien.DisplayMember = "Ten_nhan_vien";
            cbTenNhanVien.ValueMember = "ID_nhan_vien";

            // cbMaNhanVien.SelectedIndex = -1;
            cbTenNhanVien.SelectedIndex = -1;
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
                btnCheckMaPhieuXuat.Enabled = false;
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
        private void ResetAll()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLamMoi.Enabled = true;
            btnSave.Enabled = true;
            ResetText();
            btnCheckMaPhieuXuat.Enabled = true;
            setStatus(true);

            //   cbMaPhieuXuatTam.Text = "";
            txtDiaChi.Text = "";
            txtCongTrinh.Text = "";
            txtLyDo.Text = "";
            txtXuatTaiKho.Text = "";
            dataTable1.Rows.Clear();
            cbMaVatTu.Text = "";
            cbTenVatTu.Text = "";
            txtDVT.Text = "";
            txtSLGL.Text = "0";
            txtSLHN.Text = "0";
            txtSLTX.Text = "0";
            cbTenNhanVien.Text = "";
            cbMaPhieuXuatTam.Text = "";
            txtDiaChi.Text = "";
            txtXuatTaiKho.Text = "";
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
            txtSLHN.Enabled = _status;
            txtSLTX.Enabled = _status;
            txtSLGL.Enabled = _status;
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
               // chitiet.So_luong_de_nghi = int.Parse(dataTable1.Rows[i]["So_luong_yeu_cau"].ToString());
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
                        int? so_luong_kho = int.Parse(tb.Rows[0]["so_luong"].ToString()) - chitiet.So_luong_thuc_xuat;
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

                                  phieuxuat.ID_Nhan_vien =int.Parse( cbTenNhanVien.SelectedValue.ToString());//(DicNhanVien.Select[ cbMaNhanVien.Text].ID_nhan_vien);
                                  phieuxuat.Ly_do = txtLyDo.Text;
                                  phieuxuat.Ngay_xuat = dtNgayNhap.Value;
                                  phieuxuat.Cong_trinh = txtCongTrinh.Text;
                                  phieuxuat.Dia_chi = txtDiaChi.Text;
                                  
                                  if (phieuxuat.Insert(DAL) == 1)
                                  {
                                      try
                                      {
                                        //  DAL.BeginTransaction();
                                          for (int i = 0; i < dataTable1.Rows.Count; i++)
                                          {
                                              clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                                              chitiet.Ma_phieu_xuat_tam = (cbMaPhieuXuatTam.Text);
                                              chitiet.Ma_vat_tu = (dataTable1.Rows[i]["Ma_vat_tu"].ToString());
                                          //    chitiet.So_luong_de_nghi = int.Parse(dataTable1.Rows[i]["So_luong_yeu_cau"].ToString());
                                              chitiet.So_luong_thuc_xuat = int.Parse(dataTable1.Rows[i]["So_luong_thuc_xuat"].ToString());
                                              chitiet.So_luong_hoan_nhap = int.Parse(dataTable1.Rows[i]["So_luong_hoan_nhap"].ToString());
                                              chitiet.So_luong_giu_lai = int.Parse(dataTable1.Rows[i]["So_luong_giu_lai"].ToString());
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
                                              tdk.So_luong = int.Parse( temp.Rows[0]["So_luong"].ToString()) - chitiet.So_luong_thuc_xuat;
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

                                    phieuxuat.ID_Nhan_vien = int.Parse(cbTenNhanVien.SelectedValue.ToString());//(DicNhanVien.Select[ cbMaNhanVien.Text].ID_nhan_vien);
                                    phieuxuat.Ly_do = txtLyDo.Text;
                                    phieuxuat.Ngay_xuat = dtNgayNhap.Value;
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
                                                chitiet.So_luong_thuc_xuat = int.Parse(tbAff.Rows[i]["So_luong_thuc_xuat"].ToString());

                                                clsTonDauKy tdk = new clsTonDauKy();
                                                DataTable temp = tdk.GetAllByKey(chitiet.Ma_vat_tu);
                                                tdk.Ma_vat_tu = chitiet.Ma_vat_tu;
                                                tdk.ID_kho = phieuxuat.ID_kho;
                                                tdk.So_luong =int.Parse( temp.Rows[0]["So_luong"].ToString())+chitiet.So_luong_thuc_xuat;

                                                tdk.Update(DAL);
                                                if (chitiet.Delete(DAL) == 0)
                                                    return;

                                            }
                                                for (int i = 0; i < dataTable1.Rows.Count; i++)
                                                {
                                                    clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                                                    chitiet.Ma_phieu_xuat_tam = (cbMaPhieuXuatTam.Text);
                                                    chitiet.Ma_vat_tu = (dataTable1.Rows[i]["Ma_vat_tu"].ToString());
                                                    //    chitiet.So_luong_de_nghi = int.Parse(dataTable1.Rows[i]["So_luong_yeu_cau"].ToString());
                                                    chitiet.So_luong_thuc_xuat = int.Parse(dataTable1.Rows[i]["So_luong_thuc_xuat"].ToString());
                                                    chitiet.So_luong_hoan_nhap = int.Parse(dataTable1.Rows[i]["So_luong_hoan_nhap"].ToString());
                                                    chitiet.So_luong_giu_lai = int.Parse(dataTable1.Rows[i]["So_luong_giu_lai"].ToString());
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
                                                    tdk.So_luong = int.Parse(temp.Rows[0]["So_luong"].ToString()) - chitiet.So_luong_thuc_xuat+chitiet.So_luong_hoan_nhap;
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
            dataTable1.Clear();
            initEdit();
        }

        private bool initEdit()
        {
            clsPhieuXuatTamVatTu clsXuatTam = new clsPhieuXuatTamVatTu();
            clsXuatTam.Ma_phieu_xuat_tam = cbMaPhieuXuatTam.Text;
            if (clsXuatTam.CheckTonTaiSoDK() == true)
            {
                DataTable tb = clsXuatTam.GetAll(cbMaPhieuXuatTam.Text.Trim());
                // dtNgayNhap.Text = tb.Rows[0]["Ngay_nhap"].ToString();
                dtNgayNhap.Text = string.Format("{0:dd/MM/yyyy}", tb.Rows[0]["Ngay_xuat"]);
                cbTenNhanVien.Text = tb.Rows[0]["Ten_nhan_vien"].ToString();
                txtLyDo.Text = tb.Rows[0]["Ly_do"].ToString();
                txtXuatTaiKho.Text = tb.Rows[0]["ID_kho"].ToString();
                txtCongTrinh.Text = tb.Rows[0]["cong_trinh"].ToString();
                txtDiaChi.Text = tb.Rows[0]["Dia_chi"].ToString();
                clsChiTietPhieuXuatTam chitiet = new clsChiTietPhieuXuatTam();
                DataTable vChiTiet = chitiet.GetAll(cbMaPhieuXuatTam.Text);
                for (int i = 0; i < vChiTiet.Rows.Count; i++)
                {
                    //  dataTable1.Rows[i]["Ma_phieu_nhap"] = vChiTiet.Rows[i]["ma_phieu_nhap"].ToString();


                    DataRow dr = dataTable1.NewRow();
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
            DataRow[] result = dataTable1.Select("Ma_vat_tu =" + cbMaVatTu.Text);
            if (result.Length == 0)
            {
                DataRow dr = dataTable1.NewRow();
                dr["Ma_vat_tu"] = cbMaVatTu.Text;
                dr["ten_vat_tu"] = cbTenVatTu.Text;
                dr["Ten_don_vi_tinh"] = txtDVT.Text;
              //  dr["chat_luong"] = txtChatLuong.Text;
                dr["so_luong_hoan_nhap"] = txtSLHN.Text;

                dr["so_luong_thuc_xuat"] = txtSLTX.Text;
                dr["so_luong_giu_lai"] = txtSLGL.Text;
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

                if (dataTable1.Rows.Count == 0)
                    return;
                staTus = enumStatus.SuaLuoi;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
                Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;
                cbMaVatTu.Text = (gridMaster.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
                txtSLHN.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_hoan_nhap"].Value.ToString();
                txtSLTX.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_thuc_xuat"].Value.ToString();

                txtSLGL.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_giu_lai"].Value.ToString();

//                txtSL.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_giu_lai"].Value.ToString();
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
                    gridMaster.Rows[selectedRowCount].Cells["so_luong_hoan_nhap"].Value = txtSLHN.Text;
                    gridMaster.Rows[selectedRowCount].Cells["so_luong_thuc_xuat"].Value = txtSLTX.Text;
                    gridMaster.Rows[selectedRowCount].Cells["so_luong_giu_lai"].Value = txtSLGL.Text;
              //      gridMaster.Rows[selectedRowCount].Cells["don_gia"].Value = txtDonGia.Text;
                    gridMaster.Rows[selectedRowCount].Cells["ID_don_vi_tinh"].Value = Dic[cbMaVatTu.Text].ID_Don_vi_tinh;

                    staTus = sttaf;
                }
                if (staTus == enumStatus.XoaLuoi)
                {
                    dataTable1.Rows.RemoveAt(selectedRowCount);
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
            tbAff = dataTable1.Copy();
            setStatus(true);
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
                txtSLHN.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_hoan_nhap"].Value.ToString();
                txtSLTX.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_thuc_xuat"].Value.ToString();
                txtSLGL.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_giu_lai"].Value.ToString();
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (staTus == enumStatus.Sua || staTus == enumStatus.Them)
                sttaf = staTus;

            try
            {
                Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;

                //string ma_vat_tu = dataTable1.Rows[
                if (dataTable1.Rows.Count == 0 || selectedRowCount >= dataTable1.Rows.Count)
                    return;
                //staTus = enumStatus.XoaLuoi;
              //  PanelButton.setClickStatus(enumButton2.XoaLuoi);
                btnDel.Enabled = false;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                cbMaVatTu.Text = (gridMaster.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
                txtSLGL.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_giu_lai"].Value.ToString();
                txtSLTX.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_thuc_xuat"].Value.ToString();
                txtSLHN.Text = gridMaster.Rows[selectedRowCount].Cells["So_luong_hoan_nhap"].Value.ToString();
                txtDVT.Text = gridMaster.Rows[selectedRowCount].Cells["ten_don_vi_tinh"].Value.ToString();
                cbTenVatTu.Text = (gridMaster.Rows[selectedRowCount].Cells["ten_vat_tu"].Value.ToString());
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
                dtNgayNhap.Text = string.Format("{0:dd/MM/yyyy}", tb.Rows[0]["Ngay_xuat"]);
                cbTenNhanVien.Text = tb.Rows[0]["ten_nhan_vien"].ToString();
                txtLyDo.Text = tb.Rows[0]["Ly_do"].ToString();
                txtCongTrinh.Text = tb.Rows[0]["cong_trinh"].ToString();
                txtDiaChi.Text = tb.Rows[0]["dia_chi"].ToString();
             //   txtDiaChi.Text = tb.Rows[0]["Dia_chi"].ToString();

                //Fill vào grid
                //DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(Ma_Phieu_Nhap);

                //dataTable1 = chiTietPhieuNhap;
                //gridMaster.DataSource = dataTable1;


                //clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();

                DataTable vChiTiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(Ma_Phieu_Nhap);

                for (int i = 0; i < vChiTiet.Rows.Count; i++)
                {
                    DataRow dr = dataTable1.NewRow();

                    dr["ma_vat_tu"] = vChiTiet.Rows[i]["ma_vat_tu"].ToString();
                    dr["Ten_vat_tu"] = vChiTiet.Rows[i]["Ten_vat_tu"].ToString();
                    dr["Ten_Don_vi_tinh"] = vChiTiet.Rows[i]["ten_don_vi_tinh"].ToString();
                    dr["ID_Don_vi_tinh"] = vChiTiet.Rows[i]["ID_don_vi_tinh"].ToString();
                    dr["chat_luong"] = vChiTiet.Rows[i]["chat_luong"].ToString();
                    dr["so_luong_giu_lai"] = vChiTiet.Rows[i]["so_luong_giu_lai"].ToString();
                    dr["so_luong_thuc_xuat"] = vChiTiet.Rows[i]["so_luong_thuc_lanh"].ToString();
                    dr["don_gia"] = vChiTiet.Rows[i]["don_gia"].ToString();
                    dr["Thanh_tien"] = vChiTiet.Rows[i]["thanh_tien"].ToString(); // int.Parse(vChiTiet.Rows[i]["don_gia"].ToString()) * int.Parse(vChiTiet.Rows[i]["so_luong_thuc_xuat"].ToString());

                    dataTable1.Rows.Add(dr);
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