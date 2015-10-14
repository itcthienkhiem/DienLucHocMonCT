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
using Inventory.Models;
namespace Inventory.NhapXuat
{
    public partial class frmVatTuPhanKho : Form
    {
        public frmVatTuPhanKho()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            clsChi_Tiet_Phieu_Nhap_Vat_Tu pnk = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
            gridDanhSachPhieuNhap.DataSource = (DataTable)pnk.GetAllChuaPhanKho();
        }
    }
}
