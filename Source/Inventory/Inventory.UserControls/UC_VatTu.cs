using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;

namespace Inventory.UserControls
{
    public partial class UC_VatTu : UserControl
    {
        public UC_VatTu()
        {
            InitializeComponent();
           
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

        private void cbMaVatTu_MouseEnter(object sender, EventArgs e)
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

        private void cbTenVatTu_MouseEnter(object sender, EventArgs e)
        {
            cbTenVatTu_SelectedIndexChanged(sender, e);
        }

        private void UC_VatTu_Load(object sender, EventArgs e)
        {
            clsGiaoDienChung.initCombobox(cbTenVatTu, new clsDMVatTu(), "Ten_vat_tu", "ID_vat_tu", "Ten_vat_tu");
            clsGiaoDienChung.initCombobox(cbMaVatTu, new clsDMVatTu(), "Ma_vat_tu", "ID_vat_tu", "Ma_vat_tu");

          
        }


    }
}
