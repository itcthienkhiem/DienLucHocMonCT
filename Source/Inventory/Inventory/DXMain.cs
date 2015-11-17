using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Xml;
using Inventory.QuanLyNguoiDung;
using Inventory.Models;
using Inventory.DanhMuc;
using Inventory.NhapXuat;
using Inventory.QuanLyTonDauKy;
using Inventory.XuatTamVatTu;

namespace Inventory
{
    public partial class DXMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DXMain()
        {
            InitializeComponent();
        }

        private void DXMain_Load(object sender, EventArgs e)
        {
            DocFileCauHinh();
        }
        private void DocFileCauHinh()
        {
            try
            {

                XmlDocument XmlDoc = new XmlDocument();
                //Loading the Config file
                XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                // XmlDoc.Load("App.config");
                foreach (XmlElement xElement in XmlDoc.DocumentElement)
                {
                    if (xElement.Name == "connectionStrings")
                    {
                        //setting the coonection string
                        var temp = xElement.LastChild.Attributes[1].Value;
                        try
                        {
                            DatabaseHelper help = new DatabaseHelper();
                            if (help.CheckConnection((string)temp) == 0)
                            {
                                frmKetNoi frm = new frmKetNoi();
                                frm.MdiParent = this;
                                // Display the new form.
                                frm.Show();
                            }
                            else
                            {
                                Utilities.clsThamSoUtilities.connectionString = temp;
                                help.CloseDatabase();
                            }//
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    if (xElement.Name == "appSettings")
                    {
                        bool temp = bool.Parse(xElement.ChildNodes.Item(0).Attributes[1].Value);
                        if (temp == true)
                        {
                            frmDangNhap frm = new frmDangNhap();
                            frm.MdiParent = this;
                            // Display the new form.
                            frm.Show();
                            return;
                        }
                        Utilities.clsThamSoUtilities.isSectionLogin = true;
                    }
                }
                //writing the connection string in config file
                //    XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                //clsThamSoUtilities.ID_Kho = int.Parse(config.AppSettings.Settings["IDkho"].Value.ToString());
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Chưa cấu hình CSDL! Vui lòng cấu hình hệ thống trước.");
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.Name = "Đăng nhập  ";
            frm.Show();

        }

        private void btnKetNoiCSDL_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmKetNoi frm = new frmKetNoi();
            frm.MdiParent = this;
            // Display the new form.
            frm.Show();
        }

        private void btnDanhSachUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQuanTriNguoiDung frm = new frmQuanTriNguoiDung();
            frm.Name = "Quản lý người dùng  ";
            frm.Show();
        }

        private void btnVatTu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDMVatTu frm = new frmDMVatTu();
                frm.Name = "Danh mục vật tư";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }

                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();


            }
        }

        private void btnNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDMNhanVien frm = new frmDMNhanVien();
                frm.Name = "Danh mục nhân viên";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }

                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();

            }
        }

        private void btnChatLuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDMChatLuong frm = new frmDMChatLuong();
                frm.Name = "Chất lượng   ";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();

            }
        }

        private void btnLoaiPhieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDMLoaiPhieuNhap frm = new frmDMLoaiPhieuNhap();
                frm.Name = "Loại phiếu nhập ";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();

            }
        }

        private void btnDanhMucKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDMKho frm = new frmDMKho();
                frm.Name = "Danh mục kho";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }

                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();


            }
        }

        private void btnDVT_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDMDonViTinh frm = new frmDMDonViTinh();
                frm.Name = "Danh mục đơn vị tính";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }

                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();

            }
        }

        private void btnNhapKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmNhapKho frm = new frmNhapKho("PN");
                frm.Name = "Màn hình nhập vật tư";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }

                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();

            }
        }

        private void btnHoanNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmNhapKho frm = new frmNhapKho("HN");
                frm.Name = "Hoàn nhập";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                
               
            }
        }

        private void btnGoiDau_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNhapKho frm = new frmNhapKho("GD");
            frm.Name = "Màn hình nhập gối đầu";

            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == frm.Name)
                {
                    f.Activate();
                    return;
                }

            }

            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
           
        }

        private void btnNhapKhoTuFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmNhapTuFile frm = new frmNhapTuFile();
                frm.Name = "Nhập từ file  ";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
               
            }
        }

        private void btnDanhSachPhieuNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDanhSachPhieuNhap frm = new frmDanhSachPhieuNhap();
                frm.Name = "Danh sách phiếu nhập vật tư";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }

                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
             
            }
        }

        private void btnBienBanToTrinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmNhapKhoToTrinh frm = new frmNhapKhoToTrinh();
                frm.Name = "Nhập kho tờ trình , biên bản ";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
             
            }
        }

        private void btnMuonNo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmNhapKhoToTrinh frm = new frmNhapKhoToTrinh("muonno");
                frm.Name = "Nhâp Mượn Nợ Kho Khác  ";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
               
            }
        }

        private void btnChoMuonNo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmNhapKhoToTrinh frm = new frmNhapKhoToTrinh("chomuonno");
                frm.Name = "Nhâp Trả Nợ Kho Khác  ";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
               
            }
        }

        private void btnTraNo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmNhapKhoToTrinh frm = new frmNhapKhoToTrinh("trano");
                frm.Name = "Lập Phiếu Trả Nợ ";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();

            }
        }

        private void btnXuatTamUng_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmChiTietPhieuXuatTam frm = new frmChiTietPhieuXuatTam();
                frm.Name = "Xuất vật tư cho nhân viên";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }

                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
             
            }
        }

        private void btnDanhSachPhieuXuatTamUng_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDanhSachPhieuXuatTamVatTu frm = new frmDanhSachPhieuXuatTamVatTu();
                frm.Name = "Danh sách phiếu xuất vật tư cho nhân viên";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }

                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
               
            }
        }

        private void btnXuatVatTuChoNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmXuatTamVatTuChoNhanVien frm = new frmXuatTamVatTuChoNhanVien();
                frm.Name = "Xuất tạm vật tư cho nhân viên";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
               
            }
        }

        private void btnKhoVatTu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmTonKho frm = new frmTonKho();
                frm.Name = "Nhập tồn thực trong kho";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
              
              
            }
        }

        private void btnVatTuGoiDau_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmTonDauKy frm = new frmTonDauKy();
                frm.Name = "Quản lý tồn đầu kỳ";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }

                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                
            }
        }

        private void btnTheKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmTheKho frm = new frmTheKho();
                frm.Name = "Thẻ kho ";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                
            }
        }

        private void btnKhoNoVatTu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmNoVatTu frm = new frmNoVatTu();
                frm.Name = "Nợ vật tư  ";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
               
            }
        }

        private void btnDanhSachPhieuNo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDanhSachPhieuNo frm = new frmDanhSachPhieuNo();
                frm.Name = "Danh sách phiêu nơ ";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
             
            }
        }

        private void btnChiTietTraNo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDanhSachTraNo frm = new frmDanhSachTraNo();
                frm.Name = "Danh sách trả nợ phiếu nhập  ";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
              
            }
        }

        private void btnChiTietMuonNoTraNo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmTamUngHoanUngKhoKhac frm = new frmTamUngHoanUngKhoKhac();
                frm.Name = "Danh sách phiêu nơ ";

                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();

            }
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmDevDMVatTu f = new frmDevDMVatTu();
            f.Show();
        }
        
    }
}