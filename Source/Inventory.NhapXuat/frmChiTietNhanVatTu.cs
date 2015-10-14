using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.Models;
using Inventory.EntityClass;
namespace Inventory.NhapXuat
{
    public partial class frmChiTietNhanVatTu : Form
    {
       // public event EventHandler<TextEventArgs> NewTextChanged;
        public frmVatTuPhanKho f;
        string maphieu;
        string mavattu;
        int idKho;
        int soluong;
        public frmChiTietNhanVatTu(frmVatTuPhanKho f,string maphieu,string mavattu,int idKho,int soluong,string tenvt,string tenkho)
        {
            InitializeComponent();
            this.f = f;
            this.maphieu = maphieu;
            this.idKho = idKho;
            this.soluong = soluong;
            txtMaVT.Text = mavattu;
            txtTenVT.Text = tenvt;
            txtSoLuong.Text = soluong.ToString();
            txtKhoNhan.Text = tenkho;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            //load lai form cha 
            f.init();
            Action();
            
                
        }
        /// <summary>
        ///  ///
        ///cap nhat lai trang thai phieu nhap o dong ma phieu va ma vat tu
        ///them 1 dong vao bang chi tiet ton kho 
        ///cap nhat lai ton kho theo dung vat tu co ma vat tu do + them vat tu da nhap vao 
        ///
        /// </summary>
        public void Action() {

           
            clsChi_Tiet_Phieu_Nhap_Vat_Tu ct = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
            ct.UpdateDaDuyet(maphieu, mavattu);
            clsTonKho tk = new clsTonKho();
            Ton_kho tkmodel = new Ton_kho();
            tkmodel.ID_kho = idKho;
            tkmodel.Ma_vat_tu = mavattu;
           
            //lay so luong ton trong kho chinh
            int? sl = clsTonKho.getAllVT(idKho,mavattu);
            //lay so luong ton kho chinh = so luong ton kho chinh + so luong vat tu nhap vao 
            tk.So_luong = soluong + (int)sl;
            tkmodel.So_luong = tk.So_luong;
            tk.Update(tkmodel);
            clsChiTietTonKho cttk = new clsChiTietTonKho();
            cttk.Insert();
        
        }
    }
}
