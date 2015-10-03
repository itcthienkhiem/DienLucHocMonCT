using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
//////using WebService.Model;;
////using WebService.Model;.Utility;
using System.Configuration;

namespace coInventory.Mini.DanhMuc
{
    public partial class frmDanhMucMucHuong : Form
    {
        public frmDanhMucMucHuong()
        {
            InitializeComponent();
        }

        private void frmDanhMucMucHuong_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void LoadGridView()
        {
            clsDM_MucHuong obj = new clsDM_MucHuong();
            TableDanhMucMucHuong = obj.GetAll();
            grdDM_MucHuong.DataSource = TableDanhMucMucHuong;
        }

        private void GetDanhMucOnline()
        {
            if (MessageBox.Show("Bạn muốn lấy dữ liệu danh mục từ server?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                         
                InsertDanhMucOnline();
                LoadGridView();
            }
        }

        private void InsertDanhMucOnline()
        {
            //SystemConfig system = SystemConfig.Instance;
            //string token = system.GetToken();
            //if (string.IsNullOrEmpty(token))
            //{
            //    MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (!string.IsNullOrEmpty(token))
            //{
            //    string URL = "WSGetDMMucHuong";
            //    string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL, "GET", string.Empty, token);
            //    if (string.IsNullOrEmpty(response))
            //    {
            //        MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    //string str = XMLUtils.DeSerializeToObject<string>(response);
            //    List<DM_MucHuong> lstDM = XMLUtils.DeSerializeToList<DM_MucHuong>(response);
            //    if (lstDM == null)
            //    {
            //        MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    int tongRecord = lstDM.Count;
            //    if (tongRecord == 0)
            //    {
            //        MessageBox.Show("Không có dữ liệu để tải về.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    if (MessageBox.Show("Có " + tongRecord + " danh mục mức hưởng. Bạn có muốn tải về?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            //    {
            //        return;
            //    }

            //    SQLiteDAL DAL = new SQLiteDAL();
            //    DAL.BeginTransaction();
            //    foreach (DM_MucHuong t in lstDM)
            //    {
            //        clsDM_MucHuong obj = new clsDM_MucHuong();
            //        obj.MucHuong = t.MucHuong;
            //        obj.PhanTram = t.PhanTram;
            //        obj.Active = true;

            //        int result = 0;
            //        if (TableDanhMucMucHuong.Select("MucHuong = " + obj.MucHuong).Length > 0)
            //        {
            //            result = obj.Update(DAL);
            //        }
            //        else
            //        {
            //            result = obj.Insert(DAL);
            //        }

            //        if (result == 0)
            //        {
            //            DAL.RollbackTransaction();
            //            MessageBox.Show("Lỗi cập nhật dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //    }
            //    //Close & Commit Trans
            //    DAL.CommitTransaction();
            //    MessageBox.Show("Cập nhật dữ liệu thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //btnLamMoi.Enabled = true;
                //btnThem.Enabled = true;
                //btnXoa.Enabled = true;
                //btnLamMoi.Enabled = true;
                //btnGetDM.Enabled = true;
                //btnSua.Enabled = true;
           // }
           // else
            {
                // "Access token is empty.";
            }

        }

        private bool CheckTonTai(int intMucHuong)
        {
            bool kq = false;
            clsDM_MucHuong obj = new clsDM_MucHuong();
            kq = obj.CheckTonTai(intMucHuong);
            return kq;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetDM_Click(object sender, EventArgs e)
        {
            GetDanhMucOnline();
        }       

    }
}
