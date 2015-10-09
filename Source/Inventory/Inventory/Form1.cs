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
namespace Inventory
{
    public partial class MDIMain : Form
    {
        public MDIMain()
        {
            InitializeComponent();
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
        }

        private void lậpPhieToolStripMenuItem_Click(object sender, EventArgs e)
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
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGioiThieu gioithieu = new frmGioiThieu();
            gioithieu.Show();
        }

        private void MDIMain_Load(object sender, EventArgs e)
        {
            //frmKetNoi kn = new frmKetNoi();
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string configFile = System.IO.Path.Combine(appPath, "App.config");
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = configFile;
                System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);



                clsThamSoUtilities.connectionString = config.AppSettings.Settings["ConnectionString"].Value;
                clsThamSoUtilities.ID_Kho = int.Parse(config.AppSettings.Settings["IDkho"].Value.ToString());
            }
            catch (Exception ex) {
                MessageBox.Show("Chưa cấu hình CSDL! Vui lòng cấu hình hệ thống trước.");
            }
        }
    }
}
