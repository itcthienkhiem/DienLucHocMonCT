using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.DanhMuc;
using coInventory.Mini.HoSo;
using coInventory.Mini.HoSo.Control;
using System.Diagnostics;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace coInventory.Mini
{
    public partial class MDIMain : Form
    {
        private int m_LoaiBangKe = 1;

        public MDIMain()
        {
            InitializeComponent();
        }

        private void danhMucThuocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhMucThuoc frm = new frmDanhMucThuoc();
            frm.Text = "Danh mục thuốc";

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

        private void mnuDanhMucICD_Click(object sender, EventArgs e)
        {
            frmDanhMucICD frm = new frmDanhMucICD();
            frm.Text = "Danh mục ICD";

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

        private void mnuDanhMucMucHuong_Click(object sender, EventArgs e)
        {
            frmDanhMucMucHuong frm = new frmDanhMucMucHuong();
            frm.Text = "Danh Mục Mức Hưởng";

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

        private void mnuDanhMucMucHuongDoiTuong_Click(object sender, EventArgs e)
        {
            frmDanhMucMucHuongDoiTuong frm = new frmDanhMucMucHuongDoiTuong();
            frm.Text = "Danh Mục Mức Hưởng Đối Tượng";

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

        private void mnuChuyenDoiMucHuong_Click(object sender, EventArgs e)
        {
            frmDanhMucChuyenDoiMucHuong frm = new frmDanhMucChuyenDoiMucHuong();
            frm.Text = "Danh Mục Chuyển Đổi Mức Hưởng";

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

        private void mnuDanhMucLuongCoSo_Click(object sender, EventArgs e)
        {
            frmDanhMucLuongCoSo frm = new frmDanhMucLuongCoSo();

            frm.Text = "Danh Mục Lương Cơ Sở";

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

        private void mnuDanhMucVTYT_Click(object sender, EventArgs e)
        {
            frmDanhMucVTYT frm = new frmDanhMucVTYT();

            frm.Text = "Danh Mục VTYT";

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

        private void mnuDanhMucDichVu_Click(object sender, EventArgs e)
        {
            frmDanhMucDichVu frm = new frmDanhMucDichVu();

            frm.Text = "Danh Mục Dịch Vụ";

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

        private void mnuDanhMucMauVaChePhamMau_Click(object sender, EventArgs e)
        {
            frmDanhMucMau frm = new frmDanhMucMau();

            frm.Text = "Danh Mục Máu";

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

        private void mnuNhapHoSo01_Click(object sender, EventArgs e)
        {
            frmHoSo frm = new frmHoSo();

            //frm.Text = "Bảng kê chi phí KCB ngoại trú (01/BV)";

            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == frm.Name)
                {
                    if (((frmHoSo)f).m_LoaiBangKe == 1)
                    {
                        frm.Dispose();
                        GC.Collect();
                        f.Activate();
                        return;
                    }
                }

            }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.m_LoaiBangKe = 1;

            frm.Show();
        }

        private void mnuNhapHoSo02_Click(object sender, EventArgs e)
        {
            frmHoSo frm = new frmHoSo();

            //frm.Text = "Bảng kê chi phí KCB Nội trú (02/BV)";

            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == frm.Name)
                {
                    if (((frmHoSo)f).m_LoaiBangKe == 2)
                    {
                        frm.Dispose();
                        GC.Collect();
                        f.Activate();
                        return;
                    }
                }

            }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.m_LoaiBangKe = 02;

            frm.Show();
        }

        private void mnuNhapHoSo03_Click(object sender, EventArgs e)
        {
            frmHoSo frm = new frmHoSo();

            //frm.Text = "Bảng kê chi phí KCB ngoại trú (03/TYT)";

            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == frm.Name && frm.m_LoaiBangKe == 2)
                {
                    f.Activate();
                    return;
                }

            }

            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.m_LoaiBangKe = 03;

            frm.Show();
        }

        private void cauHinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                if (MessageBox.Show("Bạn có muốn đóng tất cả màn hình trước khi cấu hình.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    foreach (Form f in this.MdiChildren)
                    {
                        f.Close();
                    }
                }
                else
                {
                    return;
                }
            }

            frmCauHinh frm = new frmCauHinh();
            frm.Text = "Cấu hình hệ thống ";

            frm.ShowDialog();
                LoadThongTinCSKCB(false);
        }

        private void mnuDanhMucCSKCB_Click(object sender, EventArgs e)
        {

            frmDanhMucCSKCB frm = new frmDanhMucCSKCB();

            frm.Text = "Danh Mục CSKCB";

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

        private void mnuGuiBHYT_Click(object sender, EventArgs e)
        {
            frmDanhMucBangKe frm = new frmDanhMucBangKe();

            frm.Text = "Danh Sách Bảng kê ";

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

        private void mnuDocXML_Click(object sender, EventArgs e)
        {
            frmBangKeXML frm = new frmBangKeXML();

            frm.Text = "Xuất XML";

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

        private void mnuTraCuuTheBHYT_Click(object sender, EventArgs e)
        {
            frmTraCuuTheBHYT frm = new frmTraCuuTheBHYT();
            frm.ShowDialog();
        }

        private void mnuCloseAll_Click(object sender, EventArgs e)
        {
           
            if (this.MdiChildren.Length == 0)
                return;

            if (MessageBox.Show("Bạn có muốn đóng tất cả màn hình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                foreach (Form f in this.MdiChildren)
                {
                    f.Close();
                    GC.Collect();
                }
            }
        }

        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            frmGioiThieu frm = new frmGioiThieu();
            frm.ShowDialog();
        }

        private void danhMụcPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhMucPhongBan frm = new frmDanhMucPhongBan();
            frm.Text = "Danh mục Phòng Ban";

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
 

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        private void LoadImage()
        {
            foreach (Control control in this.Controls)
            {
                // #2
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    // #3

                  //  Image myThumbnail = ResizeImage(Properties.Resources.background,client.Width,client.Height);
                    
                    //client.BackgroundImage = myThumbnail;
                    client.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    // 4#
                    break;
                }
            }
        }

        private void LoadThongTinCSKCB(bool showCauHinh)
        {
            try
            {
                clsPublic hethong = new clsPublic();
                lblTenCSKCB.Text = hethong.GetThongTinCSKCB();
                this.Text = hethong.TenUngDung();

                if (hethong.ShowCauHinh() && showCauHinh == true)
                {
                    cauHinhToolStripMenuItem.PerformClick();
                    return;
                }

                if (hethong.MaCSKCB.Trim() != "")
                {
                    mnuDanhMuc.Visible = true;
                }
                else
                {
                    mnuDanhMuc.Visible = false;
                }

                if (hethong.TuyenKham != "")
                {

                    mnuHoSo.Visible = true;
                    if (hethong.TuyenKham.ToLower() == "xa")
                    {
                        mnuNhapHoSo01.Visible = false;
                        mnuNhapHoSo02.Visible = false;
                        mnuNhapHoSo03.Visible = true;
                        m_LoaiBangKe = 3;
                    }
                    else
                    {
                        mnuNhapHoSo01.Visible = true;
                        mnuNhapHoSo02.Visible = true;
                        mnuNhapHoSo03.Visible = false;
                    }
                }
                else
                {

                    mnuHoSo.Visible = false;
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void MDIMain_Load(object sender, EventArgs e)
        {
            LoadImage();
            LoadThongTinCSKCB(true);           

        }

        private void mnuDangKyKhamBenh_Click(object sender, EventArgs e)
        {
            frmDangKyKhamBenh frm = new frmDangKyKhamBenh();
            frm.Text = "Đăng Ký Khám Bệnh";

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
            frm.m_LoaiBangKe = m_LoaiBangKe;
            frm.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuTraCuuChiPhiKCBBHYT_Click(object sender, EventArgs e)
        {
            frmTraCuuChiPhiKBBHYT frm = new frmTraCuuChiPhiKBBHYT();
            frm.Text = "Tra Cứu Trực Tuyến Chi Phí Khám Bệnh BHYT";

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

        private void menuMain_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item.Text == "")
            {
                e.Item.Image = null;
            }
        }

        private void mnuGioiThieu_Click_1(object sender, EventArgs e)
        {
            frmGioiThieu frm = new frmGioiThieu();
            frm.ShowDialog();
        }

        private void mnuXemBaoCao_Click(object sender, EventArgs e)
        {
            frmXemBaoCao frm = new frmXemBaoCao();
            frm.ShowDialog();
        }

        private void mnuHuongDanSuDung_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("FoxitReader.exe", "HDSD/HDSD.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy tài liệu hướng dẫn sử dụng", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MDIMain_Resize(object sender, EventArgs e)
        {
            try
            {
                LoadImage();
            }
            catch { }
        }

        private void MDIMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void mnuGiayChuyenTuyen_Click(object sender, EventArgs e)
        {
            frmGiayChuyenTuyen frm = new frmGiayChuyenTuyen();

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

        private void mnuGiayRaVien_Click(object sender, EventArgs e)
        {
            frmGiayRaVien frm = new frmGiayRaVien();

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
}
