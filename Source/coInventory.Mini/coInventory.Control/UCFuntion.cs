using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using eHospital.Mini.EntityClass;
using System.Configuration;
using WebService.Model;
using WebService.Model.Utility;
namespace eHospital.Control
{
    /// <summary>
    /// delegate sử dụng chung cho tất cả các form các class con chỉ cần truyền vào form cần hiển thị và không cần biết dữ liệu như thế nào
    /// cách sử dụng :trong class frmDanhMucDichVu.Designer cần khai báo đối tượng cần truy xuất đến database, form cần hiển thị, loại đối tượng cần lấy dữ liệu
    /// vd:  this.ucFuntion1 = new eHospital.Control.UCFuntion(new clsDM_DichVu(),new frmDanhMucDichVuChiTiet(),new eHospital.Control.clsMaDichVu());
    /// chứa các xữ lý tính toán chung của tất cả các form mà không cần quan tâm đến 
    /// </summary>
    public partial class UCFuntion : UserControl
    {
        /// <summary>
        /// control con cần hiển thị trong từng button
        /// </summary>

        public clsDanhMucAbtract.clsAbGiaoDien frmChiTiet = null;
        public delegate void ButtonClickedEventHandler(object sender, EventArgs e);
        public event ButtonClickedEventHandler OnUserControlButtonClicked;
        clsDM_XuLy hst=null;
        clsAbLoạiGiaoDien clsGetMa = null;
        DataTable dtDM=null;
        public UCFuntion()
        { InitializeComponent(); }


        public void  New(clsDM_XuLy host, clsDanhMucAbtract.clsAbGiaoDien frmChitiet, clsAbLoạiGiaoDien clsMa)
        {
            
            this.hst = host;
            clsGetMa = clsMa;
            dtDM = hst.GetAll();
            if (dtDM != null)
            {

                gridMaster.DataSource = dtDM;
                clsGetMa.SetTableName(ref gridMaster);

                clsGetMa.VisibleColumn(gridMaster);
                frmChiTiet = frmChitiet;

            }

        }
        private void InsertDanhMucOnline()
        {

            //btnLamMoi.Enabled = false;
            //btnThem.Enabled = false;
            //btnXoa.Enabled = false;
            //btnLamMoi.Enabled = false;
            //btnGetDM.Enabled = false;
            //btnSua.Enabled = false;
           
            string service = ConfigurationManager.AppSettings["WebService"];
            string param = "GetAccessToken/abc/123";
            string URL = service + "/" + param;
            string response = HttpRequest.WSRequest(URL, "GET", string.Empty);
            string token = XMLUtils.DeSerializeToObject<string>(response);

            if (!string.IsNullOrEmpty(token))
            {
                string URL1 = service + "/" +clsGetMa.GetTenThamSoWS();
                string response1 = HttpRequest.WSRequest(URL1, "GET", string.Empty, token);
                //string str = XMLUtils.DeSerializeToObject<string>(response);
                List<object> lstDMThuoc = clsGetMa.LayDanhSachFromWS(response1);// XMLUtils.DeSerializeToList<DM_CSKCB>(response1);
                int tongRecord = lstDMThuoc.Count;
//                "Có " + tongRecord + " danh mục thuốc. Bạn có muốn tải về?"
                if (MessageBox.Show(clsGetMa .ShowMessageGetDuLieu(tongRecord), "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                SQLiteDAL DAL = new SQLiteDAL();
                 DAL.BeginTransaction();

                foreach (object t in lstDMThuoc)
                {
                   int result= clsGetMa.XuLyTuWSSangCSDL(t,dtDM,DAL);
                  
                   

                   if (result == 0)
                   {
                       DAL.RollbackTransaction();
                       return;
                   }

                }
              //  Close & Commit Trans
                DAL.CommitTransaction();

                LoadGridview();
                //btnLamMoi.Enabled = true;
                //btnThem.Enabled = true;
                //btnXoa.Enabled = true;
                //btnLamMoi.Enabled = true;
                //btnGetDM.Enabled = true;
                //btnSua.Enabled = true;
            }
            else
            {
                // "Access token is empty.";
            }

        }


        private void OnButtonClicked(object sender, EventArgs e)
        {
            // Delegate the event to the caller
            if (OnUserControlButtonClicked != null)
            {

                frmChiTiet.Show();
                //chuyển dữ liệu từ usercontrol sang form để biết đã hoàn thành sự kiện
                OnUserControlButtonClicked(this, e);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmChiTiet.obj = null;
            frmChiTiet.capNhat = new clsDanhMucAbtract.clsAbGiaoDien.CapNhatDuLieu(CapNhatDuLieu);
            frmChiTiet.ShowDialog();
        }
        private void Delete()
        {
            if (MessageBox.Show(clsGetMa.ShowMessage(), "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridMaster.SelectedRows.Count != 0)
                {
                    string Ma = clsGetMa.getMa(gridMaster);

                    hst.Delete(Ma);
                }
                LoadGridview();
            }
        }
        private void CapNhatDuLieu(object _objDM, int id)
        {
            int result = -1;
            clsDM_XuLy obj = (clsDM_XuLy)_objDM;

            if (id == 0)
            {

                result = obj.Insert();
            }
            else
            {
                result = obj.Update();
            }
            if (result > 0)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công!.");
                LoadGridview();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }
        private void LoadGridview()
        {
            gridMaster.DataSource = hst.GetAll();
            gridMaster.Refresh();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (gridMaster.SelectedRows.Count != 0)
            {
                string Ma = clsGetMa.getMa(gridMaster);
                frmChiTiet.SetObject(hst.GetByKey(Ma));
                frmChiTiet.capNhat = new clsDanhMucAbtract.clsAbGiaoDien.CapNhatDuLieu(CapNhatDuLieu);
                frmChiTiet.ShowDialog();
            }
        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadGridview();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            {

                Form tmp = this.FindForm();
                if (tmp != null)
                {
                  
                    tmp.Close();
                    tmp.Dispose();
                }
               
            }
        }

        private void btnTaiDuLieu_Click(object sender, EventArgs e)
        {
            InsertDanhMucOnline();
        }

    }
}
