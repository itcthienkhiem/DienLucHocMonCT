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
    public partial class frmTonKhoKhoNgoai : Form
    {
        public frmTonKhoKhoNgoai()
        {
            InitializeComponent();
        }

        private void frmDanhSachVatTuTrongKho_Load(object sender, EventArgs e)
        {
            clsGiaoDienChung.initComboboxHaveKhoNgoai(cbKho, new clsDM_Kho(), "Ten_kho", "ID_kho", "Ten_kho");
            clsGiaoDienChung.initCombobox(cbChatLuong, new clsDMChatLuong(), "Loai_chat_luong", "ID_chat_luong", "Loai_chat_luong");
           clsGiaoDienChung.initCombobox(cbTenVatTu, new clsDMVatTu(), "Ten_vat_tu", "Ma_vat_tu", "Ten_vat_tu");
            clsGiaoDienChung.initCombobox(cbMaVatTu, new clsDMVatTu(), "Ma_vat_tu", "ID_vat_tu", "Ma_vat_tu");
          
            //cbKho.DataSource = clsDM_Kho.getAll();
            //cbKho.DisplayMember = "Ten_kho";
            //cbKho.ValueMember = "ID_kho";
            //cbKho.SelectedIndex =0;
           // gridTonKhoThuc.DataSource = clsTonKho.getAll((int)cbKho.SelectedValue) ;
            cbTenVatTu.SelectedIndex = -1;

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                gridTonKhoThuc.DataSource = clsTonKho.getAllKhoNgoai(cbKho.Text, cbChatLuong.Text, cbTenVatTu.Text, cbMaVatTu.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex));


            }

        }

        private void cbMaVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = new clsDMVatTu().getThongTinTuMaVT(cbMaVatTu.GetItemText(this.cbMaVatTu.SelectedItem));// cbMaVatTu.Text);
            if (table.Rows.Count == 0)
                return;
            cbTenVatTu.Text = table.Rows[0]["ten_vat_tu"].ToString();
        }

        private void cbMaVatTu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbMaVatTu_SelectedIndexChanged(sender, e);
        }

        private void cbTenVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsDMVatTu vattu = new clsDMVatTu();
            string Ma_Vat_Tu = vattu.getMaVatTu(cbTenVatTu.GetItemText(this.cbTenVatTu.SelectedItem));

            cbMaVatTu.Text = Ma_Vat_Tu;

            DataTable table = vattu.getData_By_MaVatTu(Ma_Vat_Tu);


            if (table.Rows.Count == 0)
                return;
            cbMaVatTu.Text = table.Rows[0]["ma_vat_tu"].ToString();
        }

        private void cbTenVatTu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbTenVatTu_SelectedIndexChanged(sender, e);
        }
    }
}
