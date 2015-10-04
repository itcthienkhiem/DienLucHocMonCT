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

        }
    }
}
