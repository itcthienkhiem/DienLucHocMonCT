using Inventory.EntityClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.BusinessClass;
namespace Inventory.QuanLyTonDauKy
{
    public partial class frmChiTietTraNo : Form
    {
        frmNoVatTu f;
        public frmChiTietTraNo()
        {
            InitializeComponent();
        }
        clsBusTraNo trano = null;
        public frmChiTietTraNo(clsBusTraNo trano,frmNoVatTu f)
        {
            InitializeComponent();
            this.f = f;
            try
            {
                this.trano = trano;
                txtMVT.Text = trano.Ma_vat_tu;
                txtTVT.Text = trano.Ten_vat_tu;
                txtChatLuong.Text = trano.Ten_Chat_luong;
                txtSoLuongMuon.Text = trano.soluongmuon.ToString();
                txtKhoHienTai.Text = new clsDM_Kho().get_TenKho(trano.ID_kho);
                txtKhoTraNo.Text = new clsDM_Kho().get_TenKho(trano.ID_kho_muon);
            }
            catch (Exception ex) { }
        }
        private void btnTraNo_Click(object sender, EventArgs e)
        {
            TraNo();
        }
        /// <summary>
        /// hàm này thực hiện trả nợ kho
        /// </summary>
        public void TraNo()
        { 
            //nếu số lượng trong kho < số lượng trả nợ thì báo lỗi
            try
            {
                double sln = double.TryParse(txtSoLuongMuon.Text.ToString(), out sln) ? double.Parse(txtSoLuongMuon.Text) : 0;
                double slt = double.TryParse(txtSoLuongTraNo.Text.ToString(), out slt) ? double.Parse(txtSoLuongTraNo.Text) : 0;
                if (sln < slt)
                {
                    MessageBox.Show("Số lượng trả nợ phải nhỏ hơn hoặc bằng số lượng nợ");
                    return;
                }
                trano.soluongtra = slt;
                if (trano.Update() == 1)
                {
                    MessageBox.Show("Trả nợ thành công");
                    f.LoadData();
                    this.Close();
                }
                else
                    MessageBox.Show("Trả nợ thất bại, kiểm tra lại số lượng tồn trong kho");
                //DataTable temp = clsTonKho.getAllVT(trano.ID_kho, trano.Ma_vat_tu, trano.ID_chat_luong);

                //  double sln = double.TryParse(txtSoLuongTraNo.Text);
            }
            catch (Exception ex)
            { 
            
            }
        }
        private void frmChiTietTraNo_Load(object sender, EventArgs e)
        {
            
          
            

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
