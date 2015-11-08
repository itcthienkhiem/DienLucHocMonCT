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
namespace Inventory.QuanLyTonDauKy
{
    /// <summary>
    /// XỮ LÝ THẺ KHO 
    /// LOAD: LẤY DANH SÁCH CÁC MÃ VẬT TƯ CÓ TRONG THẺ KHO 
    /// LOAD THÔNG TIN THẺ KHO CÓ TRONG KHO = TỔNG CÁC THẺ KHO HIỆN TẠI.
    /// LẤY THONG TIN THẺ KHO VÀ CHI TIẾT THẺ KHO TƯƠNG ỨNG VỚI MÃ TÍNH TOÁN LẠI CỘT TỒN KHO 
    /// THÔNG TIN TRÊN LƯỚI SẮP XẾP THEO THỜI GIAN 
    /// 
    /// </summary>
    public partial class frmTheKho : Form
    {
        public frmTheKho()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {


            cbMaVatTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMaVatTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            clsDMVatTu vt = new clsDMVatTu();
            clsGiaoDienChung.initCombobox(cbMaVatTu, new clsDMVatTu(), "Ma_vat_tu", "ID_Vat_tu", "Ma_vat_tu");
            clsGiaoDienChung.initCombobox(cbChatLuong, new clsDMChatLuong(), "Loai_chat_luong", "ID_chat_luong", "Loai_chat_luong");

            cbMaVatTu.SelectedIndex = -1;



        }

        public DataTable getTableDataGrid()
        {
            DataTable tb =(DataTable) gridTheKho.DataSource;
            return tb;
        }
        private void Search(DateTime tungay,DateTime denngay)
        {
            try
            {
                clsTheKho thekho = new clsTheKho();
                int search =  thekho.Search((int)cbChatLuong.SelectedValue, cbMaVatTu.Text);
                if (search !=-1)
                {
                    clsChiTietTheKho cttk = new clsChiTietTheKho();
                    DataTable tbcttk = cttk.GetAllSLT(tungay,search);

                    //danh sách đã được sắp xếp tăng dần tính sl trươc
                    decimal tkt = 0;
                    for (int i = 0; i < tbcttk.Rows.Count; i++)
                    {
                        decimal slnt = decimal.TryParse(tbcttk.Rows[0]["SL_nhap"].ToString(), out slnt) ? decimal.Parse(tbcttk.Rows[0]["SL_nhap"].ToString()) : 0;
                        decimal slxt = decimal.TryParse(tbcttk.Rows[0]["SL_xuat"].ToString(), out slxt) ? decimal.Parse(tbcttk.Rows[0]["SL_xuat"].ToString()) : 0;
                            tkt = tkt +  slnt - slxt;
                    }
                    //chua so luong hien tai
                    DataTable tb = cttk.Search(tungay, denngay,search);
                    if (tb.Rows.Count == 0)
                    {
                        MessageBox.Show("Chưa có trong chi tiết thẻ kho");
                        return;
                    
                    }
                    decimal sln=0;
                    decimal slx = 0;
                    decimal tonhientai = 0;
                    decimal tontruoc = tkt;
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        sln = decimal.TryParse(tb.Rows[i]["SL_nhap"].ToString(), out sln) ? decimal.Parse(tb.Rows[i]["SL_nhap"].ToString()) : 0;
                        slx = decimal.TryParse(tb.Rows[i]["SL_xuat"].ToString(), out slx) ? decimal.Parse(tb.Rows[i]["SL_xuat"].ToString()) : 0;
                         tonhientai=tontruoc + sln - slx;
                         tontruoc = tonhientai;
                         tb.Rows[i]["SL_ton"] = tonhientai;
                         tb.Rows[i]["STT"] = i + 1;
                    }

                    gridTheKho.DataSource = tb;
                }
            }
            catch (Exception ex) { MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex)); }
        }
        private void cbMaVatTu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                DataTable table = new clsDMVatTu().getThongTinTuMaVT(cbMaVatTu.GetItemText(this.cbMaVatTu.SelectedItem));// cbMaVatTu.Text);
                if (table.Rows.Count == 0)
                    return;
                cbTenVatTu.Text = table.Rows[0]["ten_vat_tu"].ToString();
                int iddvt = int.Parse(table.Rows[0]["ID_don_vi_tinh"].ToString());
                clsDM_DonViTinh dvt = new clsDM_DonViTinh();
                string tenDVT = dvt.getTenDVTTuMa(iddvt);
                txtDVT.Text = tenDVT;
            }
            catch (Exception ex) { MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex)); }
            
        }
        private void comboBox_DropDown(object sender, EventArgs e)
        {

        }

        private void comboBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void cbMaVatTu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbMaVatTu_KeyDown(null, null);
        }

        private void cbMaVatTu_MouseDown(object sender, MouseEventArgs e)
        {
        
       //     cbMaVatTu_KeyDown(null, null);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (cbChatLuong.Text == "")
                MessageBox.Show("Chưa chọn chất lượng");
            Search(dtTuNgay.Value , dtDenNgay.Value);
        }

        private void cbMaVatTu_SelectionChangeCommitted_1(object sender, EventArgs e)
        {

            try
            {
                DataTable table = new clsDMVatTu().getThongTinTuMaVT(cbMaVatTu.GetItemText(this.cbMaVatTu.SelectedItem));// cbMaVatTu.Text);
                if (table.Rows.Count == 0)
                    return;
                cbTenVatTu.Text = table.Rows[0]["ten_vat_tu"].ToString();
                int iddvt = int.Parse(table.Rows[0]["ID_don_vi_tinh"].ToString());
                clsDM_DonViTinh dvt = new clsDM_DonViTinh();
                string tenDVT = dvt.getTenDVTTuMa(iddvt);
                txtDVT.Text = tenDVT;
            }
            catch (Exception ex) { MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex)); }
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable tmp = getTableDataGrid();
            if (tmp.Rows.Count == 0 || tmp == null)
            {
                return;
            }

            string ma_vt = cbMaVatTu.Text;
            string ten_vt = cbTenVatTu.Text;
            string dvt = txtDVT.Text;

            frmReport_The_kho frm = new frmReport_The_kho(tmp, ma_vt, ten_vt, dvt);

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
}
