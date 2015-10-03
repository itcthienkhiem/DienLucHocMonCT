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
    public partial class frmDanhMucPhongBan : Form
    {
        public frmDanhMucPhongBan()
        {
            InitializeComponent();
        }

        private void frmDanhMucPhongBan_Load(object sender, EventArgs e)
        {
            LoadGridView();
            cboCotDuLieu.SelectedIndex = 0;
        }
        private void LoadGridView()
        {
            clsDM_PhongBan obj = new clsDM_PhongBan();
            TableDanhMucPhongBan = obj.GetAll();
            grdDM_PhongBan.DataSource = TableDanhMucPhongBan;
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
            //    string URL = "WSDMKhoa";
            //    string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL1, "GET", string.Empty, token);
            //    if (string.IsNullOrEmpty(response))
            //    {
            //        MessageBox.Show("Không lấy được dữ liệu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    //string str = XMLUtils.DeSerializeToObject<string>(response);
            //    List<DM_Khoa> lstDMICD = XMLUtils.DeSerializeToList<DM_Khoa>(response);
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
            //    if (MessageBox.Show("Có " + tongRecord + " danh mục Phòng Ban. Bạn có muốn tải về?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            //    {
            //        return;
            //    }
          
            //    SQLiteDAL DAL = new SQLiteDAL();
            //    DAL.BeginTransaction();
            //    foreach (DM_Khoa t in lstDMICD)
            //    {
            //        clsDM_PhongBan obj = new clsDM_PhongBan();
            //        obj.MaPhongBan = t.MaKhoa;
            //        obj.TenPhongBan = t.TenKhoa;
            //        obj.LoaiPhongBan = "";
            //        obj.Active = true;
                    
            //        int result = 0;
            //        if (TableDanhMucPhongBan.Select("MaPhongBan = '" + obj.MaPhongBan + "'").Length > 0)
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
            clsDM_PhongBan obj = new clsDM_PhongBan();
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
            //MessageBox.Show("Chức năng này đang được xây dựng, mời bạn quay lại sau!");
            //return;
            GetDanhMucOnline();
        }

        private void grdDM_ICD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(grdDM_PhongBan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 2, e.RowBounds.Location.Y + 5);
            }
        }
        private int Them()
        {
            int kq = 0;
            frmDanhMucPhongBanChiTiet frmChiTiet = new frmDanhMucPhongBanChiTiet();
            frmChiTiet.ShowDialog();
            LoadGridView();
            return kq;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Them();
        }
        private int Delete()
        {
            int kq = 0;
            clsDM_PhongBan obj = new clsDM_PhongBan();
            if (MessageBox.Show("Bạn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (grdDM_PhongBan.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = this.grdDM_PhongBan.SelectedRows[0];
                    string MaPhongBan = row.Cells["MaPhongBan"].Value.ToString();
                    kq = obj.Delete(MaPhongBan);
                    if (kq > 0)
                    {
                        LoadGridView();
                    }
                }

            }
            return kq;
        }

        private int UpdatePhongBan()
        {
            int kq = 0;
            if (grdDM_PhongBan.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.grdDM_PhongBan.SelectedRows[0];
                string MaPhongBan = row.Cells["MaPhongBan"].Value.ToString();

                frmDanhMucPhongBanChiTiet frmChiTiet = new frmDanhMucPhongBanChiTiet();
                frmChiTiet.MaPhongBan = MaPhongBan;
                frmChiTiet.ShowDialog();
                LoadGridView();
            }
            return kq;

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            UpdatePhongBan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void txtGiaTri_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = TableDanhMucPhongBan;
            string search = "";
            if (cboCotDuLieu.SelectedIndex == 0)
            {
                search = "MaPhongBan like '%" + txtGiaTri.Text + "%'";
            }
            else if (cboCotDuLieu.SelectedIndex == 1)
            {
                search = "TenPhongBan like '%" + txtGiaTri.Text + "%'";
            }
            //else if (cboCotDuLieu.SelectedIndex == 2)
            //{
            //    search = "TenHoatChat like '%" + txtGiaTri.Text + "%'";
            //}
            bs.Filter = search;
            grdDM_PhongBan.DataSource = bs;
        }
    }
}
