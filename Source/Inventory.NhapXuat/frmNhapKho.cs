using System;
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
                DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieunhap.ID_phieu_nhap);
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
            btnHuyBo.Enabled = _status;

            //txtMaPhieuNhap.Enabled = _status;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            switch (staTus)
            {

                case enumStatus.Them:

                    clsPhieuNhapKho phieunhap = new clsPhieuNhapKho();
                    phieunhap.Ma_phieu_nhap = txtMaPhieuNhap.Text;
                    if (!phieunhap.CheckTonTaiSoDK())
                    {
                        // phieunhap.
                        phieunhap.ID_kho = (int)cbKhoNhap.SelectedValue;
                        phieunhap.Ma_phieu_nhap = txtMaPhieuNhap.Text;
                        phieunhap.Dia_chi = txtDiaChi.Text;
                        phieunhap.Ly_do = txtLyDo.Text;
                        phieunhap.Ngay_lap = dtNgayNhap.Value;
                        //  phieunhap.So_hoa_don = txt
                        SQLDAL DAL = new SQLDAL();
                        DAL.BeginTransaction();
                        if (phieunhap.Insert() == 1)
                        {
                            //DataTable chiTietPhieuNhap = new clsChi_Tiet_Phieu_Nhap_Vat_Tu().GetAll(phieuNhap.ID_phieu_nhap);
                            for (int i = 0; i < gridMaster.Rows.Count; i++)
                            {
                                clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
                                chitiet.ID_chi_tiet_phieu_nhap = int.Parse(gridMaster.Rows[i].Cells["ID_chi_tiet_phieu_nhap"].ToString());
                                chitiet.Ma_phieu_nhap = (gridMaster.Rows[i].Cells["Ma_phieu_nhap"].ToString());
                                chitiet.Ma_vat_tu = (gridMaster.Rows[i].Cells["Ma_vat_tu"].ToString());
                                chitiet.Chat_luong = (gridMaster.Rows[i].Cells["Chat_luong"].ToString());
                                chitiet.So_luong_yeu_cau = int.Parse(gridMaster.Rows[i].Cells["So_luong_yeu_cau"].ToString());
                                chitiet.So_luong_thuc_nhap = int.Parse(gridMaster.Rows[i].Cells["So_luong_thuc_nhap"].ToString());
                                chitiet.Insert();
                            }

                        }


                    }
                    else
                        MessageBox.Show("mã phiếu nhập này đã tồn tại trong csdl!");
                    break;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsPhieuNhapKho clsNhap = new clsPhieuNhapKho();
            clsNhap.Ma_phieu_nhap = txtMaPhieuNhap.Text;
            if (clsNhap.CheckTonTaiSoDK() == true)
                MessageBox.Show("Tồn tại mã phiếu nhập trong csdl");
            else
                MessageBox.Show("Chưa Tồn tại mã phiếu nhập trong csdl");

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
            if (staTus == enumStatus.SuaLuoi || e.KeyCode == Keys.Enter)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
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
                dr["don_vi_tinh"] = txtDVT.Text;
                dr["chat_luong"] = txtChatLuong.Text;
                dr["so_luong_yeu_cau"] = txtSLYC.Text;
                dr["so_luong_thuc_xuat"] = txtSLTX.Text;
                dr["don_gia"] = txtDonGia.Text;
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
            txtSLTX.Text = "";
            txtSLYC.Text = "";
            txtDonGia.Text = "";
            //            txtChatLuong.Text = "";

        }
        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLKhoDienLucDataSet.DM_Vat_Tu' table. You can move, or remove it, as needed.
            //     this.dM_Vat_TuTableAdapter.Fill(this.qLKhoDienLucDataSet.DM_Vat_Tu);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (dataTable1.Rows.Count == 0)
                return;
            staTus = enumStatus.SuaLuoi;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;
            cbMaVatTu.Text = (gridMaster.Rows[selectedRowCount].Cells["ma_vat_tu"].Value.ToString());
            cbMaVatTu_KeyDown(null, null);
        }

        private void gridMaster_MouseClick(object sender, MouseEventArgs e)
        {
            if (staTus == enumStatus.SuaLuoi)
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
            if (dataTable1.Rows.Count == 0)
                return;
            Int32 selectedRowCount = gridMaster.CurrentCell.RowIndex;
            gridMaster.Rows[selectedRowCount].Cells["ma_vat_tu"].Value = cbMaVatTu.Text;
            gridMaster.Rows[selectedRowCount].Cells["ten_vat_tu"].Value = cbTenVatTu.Text;
            gridMaster.Rows[selectedRowCount].Cells["don_vi_tinh"].Value = txtDVT.Text;
            gridMaster.Rows[selectedRowCount].Cells["chat_luong"].Value = txtChatLuong.Text;
            gridMaster.Rows[selectedRowCount].Cells["so_luong_yeu_cau"].Value = txtSLYC.Text;
            gridMaster.Rows[selectedRowCount].Cells["so_luong_thuc_xuat"].Value = txtSLTX.Text;
            gridMaster.Rows[selectedRowCount].Cells["don_gia"].Value = txtDonGia.Text;


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

    }
}
