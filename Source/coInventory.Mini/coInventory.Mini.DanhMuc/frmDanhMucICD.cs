using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
using System.Configuration;
////using WebService.Model;;
//using WebService.Model;.Utility;

namespace coInventory.Mini.DanhMuc
{
    public partial class frmDanhMucICD : Form
    {
        public frmDanhMucICD()
        {
            InitializeComponent();
        }

        private void frmDanhMucICD_Load(object sender, EventArgs e)
        {
            LoadGridView();
            cboCotDuLieu.SelectedIndex = 0;
        }
        private void LoadGridView()
        {
            clsDM_ICD obj = new clsDM_ICD();
            TableDanhMucICD = obj.GetAll();
            grdDM_ICD.DataSource = TableDanhMucICD;
        }

        private void GetDanhMucOnline()
        {
            if (MessageBox.Show("Bạn muốn lấy dữ liệu danh mục từ server?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { 
                ////Xử lý lấy danh mục từ server thông qua webservice
                ////Giả sử webservice trả về table.

                //DataTable dt = new DataTable();
                ////Sau đó insert vào database và làm mới dữ liệu trong lưới                
                //InsertDanhMucOnline(dt);

                InsertDanhMucOnline();
                LoadGridView();
            }
        }

        private void InsertDanhMucOnline()
        {
            //for (int i = 0; i <= dt.Rows.Count - 1; i++)
            //{
            //    //Kiểm tra nếu mã chưa tồn tại trong database thì insert, ngược lại thì update
            //    if (!CheckTonTai(""))
            //    {
            //        //Insert
            //    }
            //    else
            //    { 
            //        //Update
            //    }

            //}     
            //btnLamMoi.Enabled = false;
            //btnThem.Enabled = false;
            //btnXoa.Enabled = false;
            //btnLamMoi.Enabled = false;
            //btnGetDM.Enabled = false;
            //btnSua.Enabled = false;
            //SystemConfig system = SystemConfig.Instance;
            //string token = system.GetToken();
            //if (string.IsNullOrEmpty(token))
            //{
            //    MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (!string.IsNullOrEmpty(token))
            //{
            //    string URL = "WSGetDMICD10";
            //    string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL1, "GET", string.Empty, token);
            //    if (string.IsNullOrEmpty(response))
            //    {
            //        MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    //string str = XMLUtils.DeSerializeToObject<string>(response);
            //    List<DM_ICD10> lstDMICD = XMLUtils.DeSerializeToList<DM_ICD10>(response);
            //    if (lstDMICD == null)
            //    {
            //        MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    int tongRecord = lstDMICD.Count;
            //    if (tongRecord == 0)
            //    {
            //        MessageBox.Show("Không có dữ liệu để tải về.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    if (MessageBox.Show("Có " + tongRecord + " danh mục ICD. Bạn có muốn tải về?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            //    {
            //        return;
            //    }
          
            //    SQLiteDAL DAL = new SQLiteDAL();
            //    DAL.BeginTransaction();
            //    foreach (DM_ICD10 t in lstDMICD)
            //    {
            //        clsDM_ICD obj = new clsDM_ICD();
            //        obj.MaICD = t.MaICD10;
            //        obj.TenICD = t.TenICD10;
            //        obj.NgoaiDinhSuat = t.NgoaiDinhSuat ?? false;
            //        obj.Active = t.Active??false;
                    
            //        int result = 0;
            //        if (TableDanhMucICD.Select("MaICD = '" + obj.MaICD + "'").Length > 0)
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

            //    //btnLamMoi.Enabled = true;
            //    //btnThem.Enabled = true;
            //    //btnXoa.Enabled = true;
            //    //btnLamMoi.Enabled = true;
            //    //btnGetDM.Enabled = true;
            //    //btnSua.Enabled = true;
            //}
            //else
            //{
            //    // "Access token is empty.";
            //}

        }

        private bool CheckTonTai(string strMa)
        { 
            bool kq = false;
            clsDM_ICD obj = new clsDM_ICD();
            kq = obj.CheckTonTai(strMa);
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

        private void grdDM_ICD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(grdDM_ICD.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 2, e.RowBounds.Location.Y + 5);
            }
        }

        private void txtGiaTri_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = TableDanhMucICD;
            string search = "";
            if (cboCotDuLieu.SelectedIndex == 0)
            {
                search = "MaICD like '%" + txtGiaTri.Text + "%'";
            }
            else if (cboCotDuLieu.SelectedIndex == 1)
            {
                search = "TenICD like '%" + txtGiaTri.Text + "%'";
            }
            bs.Filter = search;
            grdDM_ICD.DataSource = bs;
        }                   

    }
}
