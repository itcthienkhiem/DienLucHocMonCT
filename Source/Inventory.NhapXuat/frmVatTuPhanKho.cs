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

            cbKhoNhanVatTu.DataSource = clsDM_Kho.getAll();
            cbKhoNhanVatTu.DisplayMember = "Ten_kho";
            cbKhoNhanVatTu.ValueMember = "ID_kho";
        }
        private void init()
        {
            //lay danh sach cac vat tu trong phieu nhap chua phan vao kho 
            clsChi_Tiet_Phieu_Nhap_Vat_Tu pnk = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
            gridDanhSachPhieuNhap.DataSource= pnk.GetAllChuaPhanKho();
        }

    }
}
