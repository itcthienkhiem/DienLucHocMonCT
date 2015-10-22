using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
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
            //AutoCompleteStringCollection combData1 = vt.getListMaVatTu();

            //cbMaVatTu.AutoCompleteCustomSource = combData1;

            //cbMaVatTu.DataSource = vt.getAll_Ma_Ten_VatTu();
            //cbMaVatTu.ValueMember = "ID_Vat_tu";
            //cbMaVatTu.DisplayMember = "Ma_vat_tu";
            clsGiaoDienChung.initCombobox(cbMaVatTu, new clsDMVatTu(), "Ma_vat_tu", "ID_Vat_tu", "Ma_vat_tu");
            cbMaVatTu.SelectedIndex = -1;



        }

        private void cbMaVatTu_KeyDown(object sender, KeyEventArgs e)
        {
            DataTable table = new clsDMVatTu().getThongTinTuMaVT(cbMaVatTu.Text);
            txtTenVatTu.Text = table.Rows[0]["ten_vat_tu"].ToString();
            int iddvt = int.Parse( table.Rows[0]["ID_don_vi_tinh"].ToString());
            clsDM_DonViTinh dvt = new clsDM_DonViTinh();
            string tenDVT = dvt.getTenDVTTuMa(iddvt);
            txtDVT.Text = tenDVT;

            
        }
        private void comboBox_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(comboBox_PreviewKeyDown);
        }

        private void comboBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= comboBox_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
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
    }
}
