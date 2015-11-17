using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
using Inventory.Models;
using Inventory.BusinessClass;
namespace Inventory.QuanLyTonDauKy
{
    public partial class frmTamUngHoanUngKhoKhac : DevExpress.XtraEditors.XtraForm
    {
        public frmTamUngHoanUngKhoKhac()
        {
            InitializeComponent();
           
        }

        private void btnXem_Click(object sender, EventArgs e)
        {

        }

        private void frmTamUngHoanUngKhoKhac_Load(object sender, EventArgs e)
        {
            clsChi_Tiet_Phieu_Nhap_Vat_Tu chitiet = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
            gridDanhSachPhieuNhap.DataSource = chitiet.GetAllVatTuChoTamUngHoanUng();

        }
    }
}
