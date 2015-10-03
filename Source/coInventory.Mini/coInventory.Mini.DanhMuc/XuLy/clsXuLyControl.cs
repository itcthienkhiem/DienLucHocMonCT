using System;
using System.Collections.Generic;
using System.Text;

using coInventory.Mini.EntityClass;
using System.Data;
using System.Configuration;
//////using WebService.Model;;
////using WebService.Model;.Utility;
using System.Windows.Forms;

namespace coInventory.Mini.DanhMuc.XuLy
{
  public  class clsXuLyControl
    {
         public clsDanhMucAbtract.clsAbGiaoDien frmChiTiet = null;
        public delegate void ButtonClickedEventHandler(object sender, EventArgs e);
        public event ButtonClickedEventHandler OnUserControlButtonClicked;
        clsDM_XuLy hst=null;
        clsAbLoạiGiaoDien clsGetMa = null;
        DataTable dtDM=null;

        DataGridView gridMaster = null;
        public void  New(clsDM_XuLy host, clsDanhMucAbtract.clsAbGiaoDien frmChitiet, clsAbLoạiGiaoDien clsMa,ref DataGridView gridMaster)
        {
            this.frmChiTiet = frmChitiet;
            this.hst = host;
            clsGetMa = clsMa;
          this. dtDM = hst.GetAll();
            if (dtDM != null)
            {
               this. gridMaster = gridMaster;
                gridMaster.DataSource = dtDM;
                //clsGetMa.SetTableName(ref gridMaster);

               // clsGetMa.VisibleColumn(gridMaster);
                

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

            SystemConfig system = SystemConfig.Instance;
            string token = system.GetToken();
            if (string.IsNullOrEmpty(token))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin cấu hình!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!string.IsNullOrEmpty(token))
            {
                string URL = clsGetMa.GetTenThamSoWS();
                string response = system.SendRequest(URL, "GET", string.Empty); //HttpRequest.WSRequest(URL1, "GET", string.Empty, token);
                if (string.IsNullOrEmpty(response))
                {
                    MessageBox.Show("Không lấy được dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //string str = XMLUtils.DeSerializeToObject<string>(response);
                List<object> lstDMThuoc = clsGetMa.LayDanhSachFromWS(response);// XMLUtils.DeSerializeToList<DM_CSKCB>(response1);
                int tongRecord = lstDMThuoc.Count;
//                "Có " + tongRecord + " danh mục thuốc. Bạn có muốn tải về?"
                if (MessageBox.Show(clsGetMa .ShowMessageGetDuLieu(tongRecord), "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }

                SQLiteDAL DAL = new SQLiteDAL();
                 DAL.BeginTransaction();
               //  hst.Delete();
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
                MessageBox.Show("Đã Lấy Dữ Liệu Thành Công.");
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

        public void btnThem_Click(object sender, EventArgs e)
        {
         
            frmChiTiet.capNhat = new clsDanhMucAbtract.clsAbGiaoDien.CapNhatDuLieu(CapNhatDuLieu);
            frmChiTiet.ShowDialog();
        }
        public void Delete()
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
        public void CapNhatDuLieu(object _objDM, int id)
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
        public void LoadGridview()
        {
            gridMaster.DataSource = hst.GetAll();
            gridMaster.Refresh();
        }

        public void btnSua_Click(object sender, EventArgs e)
        {
            if (gridMaster.SelectedRows.Count != 0)
            {
                string Ma = clsGetMa.getMa(gridMaster);
                frmChiTiet.SetObject(hst.GetByKey(Ma));
                frmChiTiet.capNhat = new clsDanhMucAbtract.clsAbGiaoDien.CapNhatDuLieu(CapNhatDuLieu);
                frmChiTiet.ShowDialog();
            }
        }



        public void btnXoa_Click(object sender, EventArgs e)
        {
            Delete();
        }

        public void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadGridview();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            {

               
               
            }
        }

        public void btnTaiDuLieu_Click(object sender, EventArgs e)
        {
            InsertDanhMucOnline();
        }
    }
}
