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
    /// X? LÝ TH? KHO 
    /// LOAD: L?Y DANH SÁCH CÁC MÃ V?T TU CÓ TRONG TH? KHO 
    /// LOAD THÔNG TIN TH? KHO CÓ TRONG KHO = T?NG CÁC TH? KHO HI?N T?I.
    /// L?Y THONG TIN TH? KHO VÀ CHI TI?T TH? KHO TUONG ?NG V?I MÃ TÍNH TOÁN L?I C?T T?N KHO 
    /// THÔNG TIN TRÊN LU?I S?P X?P THEO TH?I GIAN 
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
            clsGiaoDienChung.initCombobox(cbTenVatTu, new clsDMVatTu(), "Ten_vat_tu", "ID_Vat_tu", "Ten_vat_tu");
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

                    //danh sách dã du?c s?p x?p tang d?n tính sl truoc
                    decimal tkt = 0;
                    decimal tonhientai = 0;
                    decimal tontruoc = tkt;
                    for (int i = 0; i < tbcttk.Rows.Count; i++)
                    {
                        decimal slnt = decimal.TryParse(tbcttk.Rows[i]["SL_nhap"].ToString(), out slnt) ? decimal.Parse(tbcttk.Rows[i]["SL_nhap"].ToString()) : 0;
                        decimal slxt = decimal.TryParse(tbcttk.Rows[i]["SL_xuat"].ToString(), out slxt) ? decimal.Parse(tbcttk.Rows[i]["SL_xuat"].ToString()) : 0;
                        tonhientai = tontruoc + slnt - slxt;
                        tontruoc = tonhientai;
                        tbcttk.Rows[i]["SL_ton"] = tonhientai;
                    
                    }
                   
                    for (int i = 0; i < tbcttk.Rows.Count; i++)
                    {
                        string item = tbcttk.Rows[i]["ngay_xuat_chung_tu"].ToString();
                        DateTime ngay_xuat_ct = DateTime.Parse(item);
                        if (ngay_xuat_ct < tungay||ngay_xuat_ct >denngay) {
                            tbcttk.Rows.RemoveAt(i);
                        }
                       
                    }
                    int stt = 0;
                    for (int i = 0; i < tbcttk.Rows.Count; i++)
                    {
                        tbcttk.Rows[i]["STT"] = stt + 1;
                        stt++;
                    }
                    //chua so luong hien tai
                    DataTable tb = tbcttk;
                    if (tb.Rows.Count == 0)
                    {
                        MessageBox.Show("Chua có trong chi ti?t th? kho");
                        return;
                    
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
                MessageBox.Show("Chua ch?n ch?t lu?ng");
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

        private void cbTenVatTu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            clsDMVatTu vattu = new clsDMVatTu();
            string Ma_Vat_Tu = vattu.getMaVatTu(cbTenVatTu.GetItemText(this.cbTenVatTu.SelectedItem));

            cbMaVatTu.Text = Ma_Vat_Tu;

            DataTable table = vattu.getData_By_MaVatTu(Ma_Vat_Tu);

          
            if (table.Rows.Count == 0)
                return;
            cbMaVatTu.Text = table.Rows[0]["ma_vat_tu"].ToString();
            int iddvt = int.Parse(table.Rows[0]["ID_don_vi_tinh"].ToString());
            clsDM_DonViTinh dvt = new clsDM_DonViTinh();
            string tenDVT = dvt.getTenDVTTuMa(iddvt);
            txtDVT.Text = tenDVT;
        }

        private void cbTenVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTenVatTu_SelectionChangeCommitted(sender, e);
        }

        private void cbMaVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMaVatTu_SelectionChangeCommitted_1(sender, e);
        }

        private void frmTheKho_Load(object sender, EventArgs e)
        {

            dtTuNgay.Value = DateTime.Now.AddDays(-10);
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
