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
        frmNhapKho nk = null;
        public frmBuTruPhieu()
        {
            InitializeComponent();
            Load_Data();
        }
       // DataTable tbVatTu;
        string maphieu;
        public frmBuTruPhieu(frmNhapKho nk, string maphieu)
        {
            InitializeComponent();
            this.maphieu = maphieu;
            this.nk = nk;
         
            Load_Data();
        }
        public void Load_Data()
        {
            dtPhieuNhap.Rows.Clear();
             clsChi_Tiet_Phieu_Nhap_Vat_Tu pn = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
            clsGiaoDienChung.initCombobox(cbbPhieuNo, new clsBu_Tru_No_Phieu(), "Ma_phieu_nhap", "ID_phieu_nhap", "Ma_phieu_nhap");
            txtMaPhieuNhap.Text = maphieu;
           
            dtPhieuNhap = pn.GetAll(txtMaPhieuNhap.Text);
            //for (int i = 0; i < tbVatTu.Rows.Count; i++)
            //{

            //    DataRow dr = dtPhieuNhap.NewRow(); //.NewRow();
            //    dr["Ma_vat_tu"] = tbVatTu.Rows[i]["Ma_vat_tu"].ToString();
            //    dr["ten_vat_tu"] = tbVatTu.Rows[i]["ten_vat_tu"].ToString();

            //    dr["chat_luong"] = tbVatTu.Rows[i]["chat_luong"].ToString();
            //    dr["ID_chat_luong"] = tbVatTu.Rows[i]["id_chat_luong"].ToString();

            //    dr["so_luong_thuc_lanh"] = tbVatTu.Rows[i]["so_luong_thuc_lanh"].ToString();
            //    dtPhieuNhap.Rows.Add(dr);
            //}
           
            
            //lấy danh sách các phiếu nhập kho dạng nợ
            //   Load_DataNo();
        }
      //  DataTable tbVatTuNo;

        private void Load_DataNo()
        {
            clsChi_Tiet_Phieu_Nhap_Vat_Tu pn = new clsChi_Tiet_Phieu_Nhap_Vat_Tu();
            dtPhieuNhapNo = pn.GetAll(cbbPhieuNo.GetItemText(this.cbbPhieuNo.SelectedItem));

            //tbVatTuNo = pn.GetAll(cbbPhieuNo.GetItemText(this.cbbPhieuNo.SelectedItem));
            //dtPhieuNhapNo.Rows.Clear();
            //for (int i = 0; i < tbVatTuNo.Rows.Count; i++)
            //{

            //    DataRow dr = dtPhieuNhapNo.NewRow(); //.NewRow();
            //    dr["Ma_vat_tu"] = tbVatTuNo.Rows[i]["Ma_vat_tu"].ToString();
            //    dr["ten_vat_tu"] = tbVatTuNo.Rows[i]["ten_vat_tu"].ToString();

            //    dr["chat_luong"] = tbVatTuNo.Rows[i]["chat_luong"].ToString();
            //    dr["ID_chat_luong"] = tbVatTuNo.Rows[i]["id_chat_luong"].ToString();

            //    dr["so_luong_thuc_lanh"] = tbVatTuNo.Rows[i]["so_luong_thuc_lanh"].ToString();
            //    dr["ID_chi_tiet_phieu_nhap"] = tbVatTuNo.Rows[i]["ID_chi_tiet_phieu_nhap"].ToString();

            //    dtPhieuNhapNo.Rows.Add(dr);
            //}
        }

        private void cbbPhieuNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_DataNo();
        }

        private void btnCanTru_Click(object sender, EventArgs e)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                for (int i = 0; i < dtPhieuNhapNo.Rows.Count; i++)
                {
                    int id_no = int.Parse(dtPhieuNhapNo.Rows[i]["ID_chi_tiet_phieu_nhap"].ToString());
                    decimal soluongno = decimal.Parse(dtPhieuNhapNo.Rows[i]["so_luong_thuc_lanh"].ToString());
                    if (soluongno > 0)
                    {
                        string mavtno = dtPhieuNhapNo.Rows[i]["Ma_vat_tu"].ToString();
                        for (int j = 0; j < dtPhieuNhap.Rows.Count; j++)
                        {
                            string mavt = dtPhieuNhap.Rows[i]["Ma_vat_tu"].ToString();
                            if (mavt.Equals(mavtno))
                            {
                                decimal soluongnhap = decimal.Parse(dtPhieuNhap.Rows[i]["so_luong_thuc_lanh"].ToString());
                                //  decimal soluongno = decimal.Parse(dtPhieuNhapNo.Rows[i]["so_luong_thuc_lanh"].ToString());

                                decimal soluongcantru = soluongnhap - soluongno;
                                decimal soluongtru = 0;
                                if (soluongcantru >= 0)
                                {//trả nợ hết
                                    soluongnhap = soluongnhap - soluongno;
                                    soluongtru = soluongno;
                                    soluongno = 0;

                                }
                                else
                                {
                                    soluongcantru = soluongcantru - soluongnhap;
                                    // khi số lượng mượn > sl nhập
                                    soluongtru = soluongnhap;
                                    soluongnhap = 0;
                                }
                                //cập nhật lại datatable 
                                dtPhieuNhap.Rows[i]["so_luong_thuc_lanh"] = soluongnhap;
                                dtPhieuNhapNo.Rows[i]["so_luong_thuc_lanh"] = soluongno;
                                clsCanTruNoNhapNgoai cantru = new clsCanTruNoNhapNgoai();
                                cantru.Ma_phieu_nhap = txtMaPhieuNhap.Text;
                                cantru.Ma_phieu_nhap_no = cbbPhieuNo.Text;
                                cantru.So_luong_can_tru = soluongtru;
                                cantru.Id_chat_luong = int.Parse(dtPhieuNhap.Rows[i]["ID_chat_luong"].ToString());
                                cantru.Ma_vat_tu = mavt;
                                int iD = cantru.CheckTonTaiSoDK();
                                if (iD != -1)
                                {
                                    cantru.ID = iD;
                                    Chi_Tiet_Phieu_Nhap_Vat_Tu pn = clsChi_Tiet_Phieu_Nhap_Vat_Tu.getChitiet(id_no);
                                    //cập nhật lại số lượng nợ
                                    pn.So_luong_thuc_lanh = 0;
                                    if (cantru.Update(help) == 0 || clsChi_Tiet_Phieu_Nhap_Vat_Tu.Update(help, pn) == 0)
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
                                    Chi_Tiet_Phieu_Nhap_Vat_Tu pn = clsChi_Tiet_Phieu_Nhap_Vat_Tu.getChitiet(id_no);
                                    pn.So_luong_thuc_lanh = 0;
                                    if (cantru.Insert(help) == 0 || clsChi_Tiet_Phieu_Nhap_Vat_Tu.Update(help, pn) == 0)
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

        private void cbbPhieuNo_MouseDown(object sender, MouseEventArgs e)
        {
        }

    }
}
