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

    /// <summary>
    /// thực hiện bù trừ nợ như sau :
    /// load  phiếu có trạng thái trả nợ
    /// load phiếu nợ
    /// thực hiện cấn trừ vật tư như sau 
    /// tìm trong phiếu nợ 
    /// tìm vật tư có mã phiếu trùng trong phiếu nợ
    /// thực hiện cấn trừ
    /// cấn trừ xong phải cập nhật lại số lượng phiếu nhập
    /// 
    /// 
    /// </summary>
    public partial class frmBuTruPhieu : Form
    {
      
        public frmBuTruPhieu()
        {
            InitializeComponent();
            Load_Data();
        }
     
        string maphieu;
        DataTable dtPhieuNhap;
        DataTable dtPhieuNhapNo;
        frmDanhSachPhieuNhap dspn;
        public frmBuTruPhieu(frmDanhSachPhieuNhap dspn, string maphieu)
        {
            InitializeComponent();
            this.maphieu = maphieu;
            Load_Data();
            this.dspn = dspn;
        }
        public void Load_Data()
        {
             clsChi_Tiet_Phieu_Nhap_Vat_Tu pn = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
            clsGiaoDienChung.initCombobox(cbbPhieuNo, new clsBu_Tru_No_Phieu(), "Ma_phieu_nhap", "ID_phieu_nhap", "Ma_phieu_nhap");
            txtMaPhieuNhap.Text = maphieu;
             dtPhieuNhap= pn.GetAll(txtMaPhieuNhap.Text);
             gridDanhSachPhieuNhap.DataSource = dtPhieuNhap;
        }
     

        private void Load_DataNo()
        {
            clsChi_Tiet_Phieu_Nhap_Vat_Tu pn = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
            dtPhieuNhapNo = pn.GetAll(cbbPhieuNo.GetItemText(this.cbbPhieuNo.SelectedItem));
            gridNhapNo.DataSource = dtPhieuNhapNo;
        }

        private void cbbPhieuNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_DataNo();
        }

        private void btnCanTru_Click(object sender, EventArgs e)
        {

         
            Phieu_Nhap_Kho phieunhapno = clsPhieuNhapKho.GetPhieuNhap(cbbPhieuNo.Text);

            if (phieunhapno.Da_phan_kho == false)
            {
                MessageBox.Show("Phiếu nợ này chưa được xác nhận, vui lòng xác nhận phiếu nợ trước khi cấn trừ!");
                return;
            }

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction()){
            try
            {
                
               
                {
                    for (int i = 0; i < dtPhieuNhapNo.Rows.Count; i++)
                    {
                        int id_no = int.Parse(dtPhieuNhapNo.Rows[i]["ID_chi_tiet_phieu_nhap_vat_tu"].ToString());
                        decimal soluongno = decimal.Parse(dtPhieuNhapNo.Rows[i]["so_luong_thuc_lanh"].ToString());
                        if (soluongno > 0)
                        {
                            string mavtno = dtPhieuNhapNo.Rows[i]["Ma_vat_tu"].ToString();
                            for (int j = 0; j < dtPhieuNhap.Rows.Count; j++)
                            {
                                int id_tra = int.Parse(dtPhieuNhap.Rows[j]["ID_chi_tiet_phieu_nhap_vat_tu"].ToString());
                                string mavt = dtPhieuNhap.Rows[j]["Ma_vat_tu"].ToString();
                                if (mavt.Equals(mavtno))
                                {
                                    decimal soluongnhap = decimal.Parse(dtPhieuNhap.Rows[j]["so_luong_thuc_lanh"].ToString());
                                    //  decimal soluongno = decimal.Parse(dtPhieuNhapNo.Rows[i]["so_luong_thuc_lanh"].ToString());

                                    decimal soluongcantru = soluongnhap - soluongno;
                                    decimal soluongtru = 0;
                                    if (soluongcantru >= 0)
                                    {//trả nợ hết
                                        soluongtru =  soluongno;
                                        soluongnhap = soluongnhap - soluongno;
                                        soluongno = 0;

                                    }
                                    else
                                    {
                                        soluongtru = soluongnhap;
                                        // khi số lượng mượn > sl nhập
                                        soluongno = soluongno - soluongnhap;
                                        soluongnhap = 0;
                                    }
                                    //cập nhật lại datatable 
                                    dtPhieuNhap.Rows[j]["so_luong_thuc_lanh"] = soluongnhap;
                                    dtPhieuNhapNo.Rows[i]["so_luong_thuc_lanh"] = soluongno;
                                    clsCanTruNoNhapNgoai cantru = new clsCanTruNoNhapNgoai();
                                    cantru.Ma_phieu_nhap = txtMaPhieuNhap.Text;
                                    cantru.Ma_phieu_nhap_no = cbbPhieuNo.Text;
                                    cantru.So_luong_can_tru = soluongtru;
                                    cantru.Id_chat_luong = int.Parse(dtPhieuNhap.Rows[j]["ID_chat_luong"].ToString());
                                    cantru.Ma_vat_tu = mavt;
                                    int iD = cantru.CheckTonTaiSoDK();
                                    if (iD != -1)
                                    {
                                        cantru.ID = iD;

                                        // cập nhật lại số lượng nhập o phieu nhập
                                        Chi_Tiet_Phieu_Nhap_Vat_Tu pn = clsChi_Tiet_Phieu_Nhap_Vat_Tu.getChitiet(id_tra);
                                        pn.So_luong_thuc_lanh = soluongnhap;


                                        Chi_Tiet_Phieu_Nhap_Vat_Tu pnn = clsChi_Tiet_Phieu_Nhap_Vat_Tu.getChitiet(id_no);
                                        //cập nhật lại số lượng nợ của phiếu nợ 
                                        pnn.So_luong_thuc_lanh = 0;
                                        if (cantru.Update(help) == 0 || clsChi_Tiet_Phieu_Nhap_Vat_Tu.Update(help, pnn) == 0 || clsChi_Tiet_Phieu_Nhap_Vat_Tu.Update(help, pn) == 0)
                                        {
                                            dbcxtransaction.Rollback();
                                            MessageBox.Show("Thực hiện bù trừ thất bại!");
                                            return;
                                        }
                                        // nếu trùng thì update 
                                    }
                                    else
                                    {
                                        //cập nhật số lượng phiếu nợ 
                                        Chi_Tiet_Phieu_Nhap_Vat_Tu pnn = clsChi_Tiet_Phieu_Nhap_Vat_Tu.getChitiet(id_no);
                                        pnn.So_luong_thuc_lanh = soluongno;

                                        Chi_Tiet_Phieu_Nhap_Vat_Tu pn = clsChi_Tiet_Phieu_Nhap_Vat_Tu.getChitiet(id_tra);
                                        //cập nhật lại số lượng nợ của phiếu nợ 
                                        pn.So_luong_thuc_lanh = soluongnhap;

                                        if (cantru.Insert(help) == 0 || clsChi_Tiet_Phieu_Nhap_Vat_Tu.Update(help, pnn) == 0 ||
                                            clsChi_Tiet_Phieu_Nhap_Vat_Tu.Update(help, pn) == 0

                                            )
                                        {
                                            dbcxtransaction.Rollback();
                                            MessageBox.Show("Thực hiện bù trừ thất bại!");
                                            return;
                                        }
                                    }
                                }
                            }
                        }

                    }
                    dbcxtransaction.Commit();
                    MessageBox.Show("Cấn trừ thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Utilities.clsThamSoUtilities.COException(ex));
                dbcxtransaction.Rollback();
            }
        }}

        private void cbbPhieuNo_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maphieu = txtMaPhieuNhap.Text;
            clsPhieuNhapKho pnk = new clsPhieuNhapKho();
            Phieu_Nhap_Kho pn = clsPhieuNhapKho.GetPhieuNhap(maphieu);
            
            if (pn.isCanTru == true)
            {
                pn.isCanTru = false;
                if (pnk.Update(pn) == 1)
                {
                    MessageBox.Show("Chuyển đổi thành công trạng thái phiếu! Bây giờ có thể xác nhận phiếu nhập này");
                    dspn.LoadData();
                }
            }

        }

    }
}
