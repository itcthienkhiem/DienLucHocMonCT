using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.DanhMuc;
using Inventory.NhapXuat;
using Inventory.XuatTamVatTu;
using Inventory.QuanLyTonDauKy;
using Inventory.Utilities;
using System.Configuration;
using Inventory.Models;
using SplashScreenThreaded;
using System.Threading;
using System.Xml;
using Inventory.QuanLyNguoiDung;
namespace Inventory
{
    public partial class MDIMain : Form
    {
        List<Form> frms = new List<Form>();

        public MDIMain()
        {

            this.Hide();
            Thread splashthread = new Thread(new ThreadStart(Show));
            splashthread.IsBackground = true;
            splashthread.Start();

            InitializeComponent();

            //lapToolStripMenuItem_Click(null, null);


            //   DatabaseHelper help = new DatabaseHelper();
            //   help. ConnectDatabase(@"KHIEM-PC\SQLEXPRESS", "sa", "2051990", "QLKhoDienLuc");
            //Entities.ent = help.db;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void kếtNốiCSDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKetNoi frm = new frmKetNoi();
            frm.MdiParent = this;
            // Display the new form.
            frm.Show();
        }

        private void danhMụcKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDMKho frm = new frmDMKho();
                frm.Text = "Danh mục kho";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }
        private void danhMụcVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDMVatTu frm = new frmDMVatTu();
                frm.Text = "Danh mục vật tư";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void quảnLýNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmNhapKho frm = new frmNhapKho("PN");
                frm.Text = "Màn hình nhập vật tư";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void danhSáchPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDanhSachPhieuNhap frm = new frmDanhSachPhieuNhap();
                frm.Text = "Danh sách phiếu nhập vật tư";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void menuDMDonViTinh_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDMDonViTinh frm = new frmDMDonViTinh();
                frm.Text = "Danh mục đơn vị tính";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void menuDMNhanVien_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDMNhanVien frm = new frmDMNhanVien();
                frm.Text = "Danh mục nhân viên";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void lậpPhieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuItemTonDauKy_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmTonDauKy frm = new frmTonDauKy();
                frm.Text = "Quản lý tồn đầu kỳ";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGioiThieu gioithieu = new frmGioiThieu();
            gioithieu.Show();
        }

        private void MDIMain_Load(object sender, EventArgs e)
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
        public void CheckConnectionString()
        {

        }
        public void Show()
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
        }
        private void lapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmChiTietPhieuXuatTam frm = new frmChiTietPhieuXuatTam();
                frm.Text = "Xuất vật tư cho nhân viên";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void MenuItemDSPhieuXuatTamUng_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDanhSachPhieuXuatTamVatTu frm = new frmDanhSachPhieuXuatTamVatTu();
                frm.Text = "Danh sách phiếu xuất vật tư cho nhân viên";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void MenuItemNhapTonDauKy_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmNhapTonDauKy frm = new frmNhapTonDauKy();
                frm.Text = "Nhập tồn đầu kỳ";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }
        private void phânKhoVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmVatTuPhanKho frm = new frmVatTuPhanKho();
                frm.Text = "Nhập tồn đầu kỳ";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void danhSáchVậtTưTồnThựcTrongKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDanhSachVatTuTrongKho frm = new frmDanhSachVatTuTrongKho();
                frm.Text = "Nhập tồn thực trong kho";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void danhSáchVậtTưChưaPhânVàoKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phânKhoVậtTưToolStripMenuItem_Click(sender, e);
        }

        private void danhSáchPhiếuNhậpChưaPhânKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSáchPhiếuNhậpToolStripMenuItem_Click(sender, e);
        }

        private void MenuItemXuatVTChoNhanVien_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmXuatTamVatTuChoNhanVien frm = new frmXuatTamVatTuChoNhanVien();
                frm.Text = "Xuất tạm vật tư cho nhân viên";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void danhMụcLoạiPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDMLoaiPhieuNhap frm = new frmDMLoaiPhieuNhap();
                frm.Text = "Loại phiếu nhập ";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void thẻKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmTheKho frm = new frmTheKho();
                frm.Text = "Thẻ kho ";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void nhậpKhoTừFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmNhapTuFile frm = new frmNhapTuFile();
                frm.Text = "Nhập từ file  ";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void danhMụcChấtLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDMChatLuong frm = new frmDMChatLuong();
                frm.Text = "Chất lượng   ";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            lapToolStripMenuItem_Click(null, null);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void quảnLýXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýHoànTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmNhapKho frm = new frmNhapKho("HN");
                frm.Text = "Hoàn nhập";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void thẻGóiĐầuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmTheGoiDau frm = new frmTheGoiDau();
                frm.Text = "Thẻ Gói Đầu  ";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void khoNợVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmNoVatTu frm = new frmNoVatTu();
                frm.Text = "Nợ vật tư  ";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void nhậpKhoTừTờTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmNhapKhoToTrinh frm = new frmNhapKhoToTrinh();
                frm.Text = "Nhập kho tờ trình , biên bản ";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void danhSáchPhiếuNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDanhSachPhieuNo frm = new frmDanhSachPhieuNo();
                frm.Text = "Danh sách phiêu nơ ";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void chiTiếtTrảNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilities.clsThamSoUtilities.isSectionLogin == true)
            {
                frmDanhSachTraNo frm = new frmDanhSachTraNo();
                frm.Text = "Danh sách trả nợ phiếu nhập  ";

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
                for (int i = 0; i < frms.Count; i++)
                    frms[i].Close();
                frms.Clear();
                frms.Add(frm);
            }
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.Text = "Đăng nhập  ";
            frm.Show();
        }

        private void quảnTrịNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanTriNguoiDung frm = new frmQuanTriNguoiDung();
            frm.Text = "Quản lý người dùng  ";
            frm.Show();
        }
    }
}
