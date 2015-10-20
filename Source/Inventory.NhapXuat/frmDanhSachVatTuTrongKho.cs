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
    public partial class frmDanhSachVatTuTrongKho : Form
    {
        public frmDanhSachVatTuTrongKho()
        {
            InitializeComponent();
        }

        private void frmDanhSachVatTuTrongKho_Load(object sender, EventArgs e)
        {
            clsGiaoDienChung.initCombobox(cbKho, new clsDM_Kho(), "Ten_kho", "ID_kho", "Ten_kho");
            //cbKho.DataSource = clsDM_Kho.getAll();
            //cbKho.DisplayMember = "Ten_kho";
            //cbKho.ValueMember = "ID_kho";
            //cbKho.SelectedIndex =0;
            gridTonKhoThuc.DataSource = clsTonKho.getAll((int)cbKho.SelectedValue) ;

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            gridTonKhoThuc.DataSource = clsTonKho.getAll((int)cbKho.SelectedValue);
        }
    }
}
