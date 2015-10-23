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

        private void danhMụcVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void quảnLýNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmNhapKho frm = new frmNhapKho();
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

        private void danhSáchPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void menuDMDonViTinh_Click(object sender, EventArgs e)
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

        private void menuDMNhanVien_Click(object sender, EventArgs e)
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

        private void lậpPhieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void MenuItemTonDauKy_Click(object sender, EventArgs e)
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

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGioiThieu gioithieu = new frmGioiThieu();
            gioithieu.Show();
        }

        private void MDIMain_Load(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();
            //SplashScreen.UdpateStatusText("Loading Items!!!");
            //Thread.Sleep(1000);
            //SplashScreen.UdpateStatusTextWithStatus("waiting...", TypeOfMessage.Success);
            //Thread.Sleep(1000);
            //SplashScreen.UdpateStatusTextWithStatus("waiting...", TypeOfMessage.Warning);

            //Thread.Sleep(1000);
            //SplashScreen.UdpateStatusTextWithStatus("waiting...", TypeOfMessage.Error);
            //Thread.Sleep(1000);
            //SplashScreen.UdpateStatusText("Testing Default Message Color");
            //Thread.Sleep(1000);
            //SplashScreen.UdpateStatusText("Items Loaded..");
            //Thread.Sleep(500);

            //this.Show();
            //SplashScreen.CloseSplashScreen();
            //this.Activate();
            //frmKetNoi kn = new frmKetNoi();

            //Thread splashthread = new Thread(new ThreadStart(Show));
            //splashthread.IsBackground = true;
            //splashthread.Start();



            try
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string configFile = System.IO.Path.Combine(appPath, "App.config");
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = configFile;
                System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);



                clsThamSoUtilities.connectionString = config.AppSettings.Settings["ConnectionString"].Value;
                //clsThamSoUtilities.ID_Kho = int.Parse(config.AppSettings.Settings["IDkho"].Value.ToString());
            }
            catch (Exception ex) {
               // MessageBox.Show("Chưa cấu hình CSDL! Vui lòng cấu hình hệ thống trước.");
            }
        }
        public void Show()
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
        }
        private void lapToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void MenuItemDSPhieuXuatTamUng_Click(object sender, EventArgs e)
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

        private void MenuItemNhapTonDauKy_Click(object sender, EventArgs e)
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

        private void phânKhoVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void danhSáchVậtTưTồnThựcTrongKhoToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void danhMụcLoạiPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void thẻKhoToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void nhậpKhoTừFileToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void danhMụcChấtLượngToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
