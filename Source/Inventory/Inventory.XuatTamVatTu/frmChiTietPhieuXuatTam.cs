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
        public frmChiTietPhieuXuatTam()
        {
            InitializeComponent();
        }
        Dictionary<string, clsDM_NhanVien> Dic = new Dictionary<string, clsDM_NhanVien>();
        private void frmChiTietPhieuXuatTam_Load(object sender, EventArgs e)
        {
            DataTable lstNhanVien = new DataTable();
            lstNhanVien = new clsDM_NhanVien().GetAll();
            cbMaNhanVien.DataSource = lstNhanVien;
            cbMaNhanVien.DisplayMember = "Ma_nhan_vien";
            cbMaNhanVien.ValueMember = "Ma_nhan_vien";
            DataRow[] result = lstNhanVien.Select("ma_nhan_vien = " + cbMaNhanVien.Text);



            //       staTus = enumStatus.None;
            this.cbMaVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbMaVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cbTenVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbTenVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;

            Dic = GetDict(new clsDM_NhanVien().GetAll());
            //    DicTen = GetDictTen(new clsDMVatTu().GetAll());



            AutoCompleteStringCollection combData1 = new AutoCompleteStringCollection();
            AutoCompleteStringCollection combData2 = new AutoCompleteStringCollection();
            foreach (string key in Dic.Keys)
            {
                combData1.Add(Dic[key].Ma_nhan_vien);
                combData2.Add(Dic[key].Ten_nhan_vien);

            }
            cbMaNhanVien.AutoCompleteCustomSource = combData1;
            cbMaNhanVien.DataSource = combData1;
            cbTenNhanVien.AutoCompleteCustomSource = combData2;
            cbTenNhanVien.DataSource = combData2;
            cbMaNhanVien.SelectedIndex = -1;
            cbTenNhanVien.SelectedIndex = -1;

        }

        internal Dictionary<string, clsDM_NhanVien> GetDict(DataTable dt)
        {
            var areas = new Dictionary<string, clsDM_NhanVien>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                areas.Add(dt.Rows[i]["Ma_Nhan_vien"].ToString(), new clsDM_NhanVien(

                     dt.Rows[i]["Ma_Nhan_vien"].ToString(),
                      dt.Rows[i]["Ten_Nhan_Vien"].ToString(),
                  bool.Parse(dt.Rows[i]["Trang_thai"].ToString())

                    ));

                //   dt.Rows[i]["ten_vat_tu"];

            }
            return areas;
        }

        private void cbMaNhanVien_KeyDown(object sender, KeyEventArgs e)
        {

            {
                var val = Dic[cbMaNhanVien.Text.Trim()];
                cbTenNhanVien.Text = val.Ten_nhan_vien.ToString();
                //  txtDVT.Text = val.ten_don_vi_tinh.ToString();

                // txtDonGia.Text = val.Don_gia.ToString();


            }
        }
        private void cbTenNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < Dic.Count; i++)
                {
                    if (Dic.ToList()[i].Value.Ten_nhan_vien.Equals(cbTenNhanVien.Text))

                    // == cbTenVatTu.Text.Trim())
                    {
                        var val = Dic.ToList()[i].Value;
                        cbMaNhanVien.Text = val.Ma_nhan_vien.ToString();
                        // txtDVT.Text = val.Ten_nhan_vien.ToString();
                        //  txtDonGia.Text = val.Trang_thai.ToString();
                    }
                }
            }
        }

        private void cbMaVatTu_KeyDown(object sender, KeyEventArgs e)
        {

            {
                var val = Dic[cbMaNhanVien.Text.Trim()];
                cbTenNhanVien.Text = val.Ten_nhan_vien.ToString();
                //  txtDVT.Text = val.ten_don_vi_tinh.ToString();

                // txtDonGia.Text = val.Don_gia.ToString();


            }
        }
        enumStatus staTus = enumStatus.None;

        public void setStatus(bool _status)
        {
            cbMaNhanVien.Enabled = _status;
            cbTenNhanVien.Enabled = _status;
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

                cbMaNhanVien.Text = "";
                cbTenNhanVien.Text = "";
                txtDiaChi.Text = "";
                txtCongTrinh.Text = "";
                txtLyDo.Text = "";
                txtXuatTaiKho.Text = "";
                dataTable1.Rows.Clear();
                // gridMaster.ReadOnly = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên bắt buộc nhập!");
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
                        clsPhieuXuatTamVatTu PhieuXuatTam = new clsPhieuXuatTamVatTu();
                        PhieuXuatTam.Ma_phieu_xuat_tam = cbMaPhieuXuatTam.Text;
                        if (!PhieuXuatTam.CheckTonTaiSoDK())
                        {
                            // phieunhap.
                            PhieuXuatTam.ID_kho = 1;
                            PhieuXuatTam.Ma_phieu_xuat_tam = cbMaNhanVien.Text;
                            
                            var val = Dic[cbMaNhanVien.Text.Trim()];
                            cbTenNhanVien.Text = val.ID_nhan_vien.ToString();

                            PhieuXuatTam.ID_Nhan_vien = val.ID_nhan_vien;
                            PhieuXuatTam.Ngay_xuat =DateTime.Parse( dtNgayNhap.Value.ToString());
                            PhieuXuatTam.ly = val.ID_nhan_vien;
                            




                            if (PhieuXuatTam.Insert(DAL) == 1)
                            {

                                //DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieuNhap.ID_phieu_nhap);
                                for (int i = 0; i < dataTable1.Rows.Count; i++)
                                {
                                    clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
                                    //    chitiet.ID_chi_tiet_phieu_nhap = int.Parse(gridMaster.Rows[i].Cells["ID_chi_tiet_phieu_nhap"].ToString());
                                    chitiet.Ma_phieu_nhap = (txtMaPhieuNhap.Text);
                                    chitiet.ID_Don_vi_tinh = int.Parse(dataTable1.Rows[i]["ID_Don_vi_tinh"].ToString());
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
                                            int? so_luong_kho = tdk.So_luong + int.Parse(tb.Rows[0]["so_luong"].ToString());
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
                                        check.removebyKey(DAL, txtMaPhieuNhap.Text, ma_vat_tu);

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
    }
}