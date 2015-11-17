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
    public partial class frmChiTietNhanVatTu : DevExpress.XtraEditors.XtraForm
    {
       // public event EventHandler<TextEventArgs> NewTextChanged;
        public frmVatTuChoMuon f;
        string maphieu;
        string mavattu;
        int idKho;
        decimal soluong;
        
        int id_chatluong;
        public frmChiTietNhanVatTu(frmVatTuChoMuon f, string maphieu, string mavattu, int idKho, decimal soluong, string tenvt, string tenkho, int id_chatluong)
        {
            InitializeComponent();
            this.f = f;
            this.maphieu = maphieu;
            this.idKho = idKho;
            this.soluong = soluong;
            this.mavattu = mavattu;
            txtMaVT.Text = mavattu;
            txtTenVT.Text = tenvt;
            txtSoLuong.Text = soluong.ToString();
            txtKhoNhan.Text = tenkho;
            this.id_chatluong = id_chatluong;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            //load lai form cha 
            //f.init();
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

            clsXuLyDuLieuChung dc = new clsXuLyDuLieuChung();
            DateTime ngayNhap = dtNgayNhap.Value;
            if (dc.InsertTonKho(mavattu, idKho, soluong, maphieu, ngayNhap,id_chatluong) == 1)
            {
                MessageBox.Show("Bạn đã thêm thành công vật tư vào kho ");
                f.init();
                this.Close();
            }

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChiTietNhanVatTu_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtSoLuongTra;
        }
    }
}
