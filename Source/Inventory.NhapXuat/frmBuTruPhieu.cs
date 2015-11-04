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

namespace Inventory.NhapXuat
{
    public partial class frmBuTruPhieu : Form
    {
        frmNhapKho nk = null;
        public frmBuTruPhieu()
        {
            InitializeComponent();
            Load_Data();
        }
        DataTable tbVatTu;
        string maphieu;
        public frmBuTruPhieu(frmNhapKho nk, DataTable tbVatTu,string maphieu)
        {
            InitializeComponent();
            this.maphieu = maphieu;
            this.nk = nk;
            this.tbVatTu = tbVatTu;
            Load_Data();
        }
        public void Load_Data()
        {
            
            clsGiaoDienChung.initCombobox(cbbPhieuNo,new clsBu_Tru_No_Phieu(), "Ma_phieu_nhap", "ID_phieu_nhap", "Ma_phieu_nhap");
          
         
            for (int i = 0; i < tbVatTu.Rows.Count; i++)
            {
               
                DataRow dr = dtPhieuNhap.NewRow(); //.NewRow();
                dr["Ma_vat_tu"] = tbVatTu.Rows[i]["Ma_vat_tu"].ToString();
                dr["ten_vat_tu"] = tbVatTu.Rows[i]["ten_vat_tu"].ToString();

                dr["chat_luong"] = tbVatTu.Rows[i]["chat_luong"].ToString();
                dr["ID_chat_luong"] = tbVatTu.Rows[i]["id_chat_luong"].ToString();

                dr["so_luong_thuc_lanh"] = tbVatTu.Rows[i]["so_luong_thuc_lanh"].ToString();
                dtPhieuNhap.Rows.Add(dr);
            }
            txtMaPhieuNhap.Text = maphieu;
         
        }

    }
}
