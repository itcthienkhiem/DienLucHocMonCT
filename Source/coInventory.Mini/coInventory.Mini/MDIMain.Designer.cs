namespace coInventory.Mini
{
    partial class MDIMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIMain));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.cauHinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMucThuoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMucVTYT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMucDichVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMucMauVaChePhamMau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDanhMucMucHuong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMucMucHuongDoiTuong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChuyenDoiMucHuong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDanhMucICD = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMucCSKCB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMucLuongCoSo = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcPhòngBanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoSo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangKyKhamBenh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapHoSo01 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapHoSo02 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapHoSo03 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGuiBHYT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDocXML = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTraCuuTheBHYT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTraCuuChiPhiKCBBHYT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHuongDanSuDung = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXemBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGioiThieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCuaSo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTenCSKCB = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGiayChuyenTuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGiayRaVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuDanhMuc,
            this.mnuHoSo,
            this.mnuTroGiup,
            this.mnuCuaSo});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.MdiWindowListItem = this.mnuCuaSo;
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuMain.Size = new System.Drawing.Size(1106, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuMain";
            this.menuMain.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.menuMain_ItemAdded);
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cauHinhToolStripMenuItem,
            this.mnuThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(74, 20);
            this.mnuHeThong.Text = "Hệ Thống";
            // 
            // cauHinhToolStripMenuItem
            // 
            this.cauHinhToolStripMenuItem.Name = "cauHinhToolStripMenuItem";
            this.cauHinhToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.cauHinhToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.cauHinhToolStripMenuItem.Text = "Cấu hình";
            this.cauHinhToolStripMenuItem.Click += new System.EventHandler(this.cauHinhToolStripMenuItem_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.ShortcutKeyDisplayString = "";
            this.mnuThoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuThoat.Size = new System.Drawing.Size(150, 22);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDanhMucThuoc,
            this.mnuDanhMucVTYT,
            this.mnuDanhMucDichVu,
            this.mnuDanhMucMauVaChePhamMau,
            this.mnu1,
            this.mnuDanhMucMucHuong,
            this.mnuDanhMucMucHuongDoiTuong,
            this.mnuChuyenDoiMucHuong,
            this.mnu2,
            this.mnuDanhMucICD,
            this.mnuDanhMucCSKCB,
            this.mnuDanhMucLuongCoSo,
            this.danhMụcPhòngBanToolStripMenuItem});
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(73, 20);
            this.mnuDanhMuc.Text = "Danh Mục";
            this.mnuDanhMuc.Visible = false;
            // 
            // mnuDanhMucThuoc
            // 
            this.mnuDanhMucThuoc.Name = "mnuDanhMucThuoc";
            this.mnuDanhMucThuoc.Size = new System.Drawing.Size(261, 22);
            this.mnuDanhMucThuoc.Text = "Danh mục thuốc";
            this.mnuDanhMucThuoc.Click += new System.EventHandler(this.danhMucThuocToolStripMenuItem_Click);
            // 
            // mnuDanhMucVTYT
            // 
            this.mnuDanhMucVTYT.Name = "mnuDanhMucVTYT";
            this.mnuDanhMucVTYT.Size = new System.Drawing.Size(261, 22);
            this.mnuDanhMucVTYT.Text = "Danh mục VTYT";
            this.mnuDanhMucVTYT.Click += new System.EventHandler(this.mnuDanhMucVTYT_Click);
            // 
            // mnuDanhMucDichVu
            // 
            this.mnuDanhMucDichVu.Name = "mnuDanhMucDichVu";
            this.mnuDanhMucDichVu.Size = new System.Drawing.Size(261, 22);
            this.mnuDanhMucDichVu.Text = "Danh mục dịch vụ";
            this.mnuDanhMucDichVu.Click += new System.EventHandler(this.mnuDanhMucDichVu_Click);
            // 
            // mnuDanhMucMauVaChePhamMau
            // 
            this.mnuDanhMucMauVaChePhamMau.Name = "mnuDanhMucMauVaChePhamMau";
            this.mnuDanhMucMauVaChePhamMau.Size = new System.Drawing.Size(261, 22);
            this.mnuDanhMucMauVaChePhamMau.Text = "Danh mục máu và chế phẩm máu";
            this.mnuDanhMucMauVaChePhamMau.Click += new System.EventHandler(this.mnuDanhMucMauVaChePhamMau_Click);
            // 
            // mnu1
            // 
            this.mnu1.Name = "mnu1";
            this.mnu1.Size = new System.Drawing.Size(258, 6);
            // 
            // mnuDanhMucMucHuong
            // 
            this.mnuDanhMucMucHuong.Name = "mnuDanhMucMucHuong";
            this.mnuDanhMucMucHuong.Size = new System.Drawing.Size(261, 22);
            this.mnuDanhMucMucHuong.Text = "Danh mục mức hưởng";
            this.mnuDanhMucMucHuong.Click += new System.EventHandler(this.mnuDanhMucMucHuong_Click);
            // 
            // mnuDanhMucMucHuongDoiTuong
            // 
            this.mnuDanhMucMucHuongDoiTuong.Name = "mnuDanhMucMucHuongDoiTuong";
            this.mnuDanhMucMucHuongDoiTuong.Size = new System.Drawing.Size(261, 22);
            this.mnuDanhMucMucHuongDoiTuong.Text = "Danh mục mức hưởng đối tượng";
            this.mnuDanhMucMucHuongDoiTuong.Click += new System.EventHandler(this.mnuDanhMucMucHuongDoiTuong_Click);
            // 
            // mnuChuyenDoiMucHuong
            // 
            this.mnuChuyenDoiMucHuong.Name = "mnuChuyenDoiMucHuong";
            this.mnuChuyenDoiMucHuong.Size = new System.Drawing.Size(261, 22);
            this.mnuChuyenDoiMucHuong.Text = "Danh mục chuyển đổi mức hưởng";
            this.mnuChuyenDoiMucHuong.Click += new System.EventHandler(this.mnuChuyenDoiMucHuong_Click);
            // 
            // mnu2
            // 
            this.mnu2.Name = "mnu2";
            this.mnu2.Size = new System.Drawing.Size(258, 6);
            // 
            // mnuDanhMucICD
            // 
            this.mnuDanhMucICD.Name = "mnuDanhMucICD";
            this.mnuDanhMucICD.Size = new System.Drawing.Size(261, 22);
            this.mnuDanhMucICD.Text = "Danh mục ICD";
            this.mnuDanhMucICD.Click += new System.EventHandler(this.mnuDanhMucICD_Click);
            // 
            // mnuDanhMucCSKCB
            // 
            this.mnuDanhMucCSKCB.Name = "mnuDanhMucCSKCB";
            this.mnuDanhMucCSKCB.Size = new System.Drawing.Size(261, 22);
            this.mnuDanhMucCSKCB.Text = "Danh mục cơ sở khám chữa bệnh";
            this.mnuDanhMucCSKCB.Click += new System.EventHandler(this.mnuDanhMucCSKCB_Click);
            // 
            // mnuDanhMucLuongCoSo
            // 
            this.mnuDanhMucLuongCoSo.Name = "mnuDanhMucLuongCoSo";
            this.mnuDanhMucLuongCoSo.Size = new System.Drawing.Size(261, 22);
            this.mnuDanhMucLuongCoSo.Text = "Danh mục lương cơ sở";
            this.mnuDanhMucLuongCoSo.Click += new System.EventHandler(this.mnuDanhMucLuongCoSo_Click);
            // 
            // danhMụcPhòngBanToolStripMenuItem
            // 
            this.danhMụcPhòngBanToolStripMenuItem.Name = "danhMụcPhòngBanToolStripMenuItem";
            this.danhMụcPhòngBanToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.danhMụcPhòngBanToolStripMenuItem.Text = "Danh mục phòng ban";
            this.danhMụcPhòngBanToolStripMenuItem.Click += new System.EventHandler(this.danhMụcPhòngBanToolStripMenuItem_Click);
            // 
            // mnuHoSo
            // 
            this.mnuHoSo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangKyKhamBenh,
            this.mnuNhapHoSo01,
            this.mnuNhapHoSo02,
            this.mnuNhapHoSo03,
            this.toolStripSeparator3,
            this.mnuGuiBHYT,
            this.mnuDocXML,
            this.mnuTraCuuTheBHYT,
            this.mnuTraCuuChiPhiKCBBHYT,
            this.toolStripSeparator1,
            this.mnuGiayChuyenTuyen,
            this.mnuGiayRaVien});
            this.mnuHoSo.Name = "mnuHoSo";
            this.mnuHoSo.Size = new System.Drawing.Size(52, 20);
            this.mnuHoSo.Text = "Hồ Sơ";
            this.mnuHoSo.Visible = false;
            // 
            // mnuDangKyKhamBenh
            // 
            this.mnuDangKyKhamBenh.Name = "mnuDangKyKhamBenh";
            this.mnuDangKyKhamBenh.Size = new System.Drawing.Size(361, 22);
            this.mnuDangKyKhamBenh.Text = "Đăng ký KCB";
            this.mnuDangKyKhamBenh.Click += new System.EventHandler(this.mnuDangKyKhamBenh_Click);
            // 
            // mnuNhapHoSo01
            // 
            this.mnuNhapHoSo01.Name = "mnuNhapHoSo01";
            this.mnuNhapHoSo01.Size = new System.Drawing.Size(361, 22);
            this.mnuNhapHoSo01.Text = "Bảng kê chi phí KCB Ngoại trú (01/BV)";
            this.mnuNhapHoSo01.Visible = false;
            this.mnuNhapHoSo01.Click += new System.EventHandler(this.mnuNhapHoSo01_Click);
            // 
            // mnuNhapHoSo02
            // 
            this.mnuNhapHoSo02.Name = "mnuNhapHoSo02";
            this.mnuNhapHoSo02.Size = new System.Drawing.Size(361, 22);
            this.mnuNhapHoSo02.Text = "Bảng kê chi phí KCB Nội trú (02/BV)";
            this.mnuNhapHoSo02.Visible = false;
            this.mnuNhapHoSo02.Click += new System.EventHandler(this.mnuNhapHoSo02_Click);
            // 
            // mnuNhapHoSo03
            // 
            this.mnuNhapHoSo03.Name = "mnuNhapHoSo03";
            this.mnuNhapHoSo03.Size = new System.Drawing.Size(361, 22);
            this.mnuNhapHoSo03.Text = "Bảng kê chi phí KCB Trạm y tế xã/phường (03/TYT)";
            this.mnuNhapHoSo03.Visible = false;
            this.mnuNhapHoSo03.Click += new System.EventHandler(this.mnuNhapHoSo03_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(358, 6);
            // 
            // mnuGuiBHYT
            // 
            this.mnuGuiBHYT.Name = "mnuGuiBHYT";
            this.mnuGuiBHYT.Size = new System.Drawing.Size(361, 22);
            this.mnuGuiBHYT.Text = "Gửi hồ sơ lên BHXH";
            this.mnuGuiBHYT.Click += new System.EventHandler(this.mnuGuiBHYT_Click);
            // 
            // mnuDocXML
            // 
            this.mnuDocXML.Name = "mnuDocXML";
            this.mnuDocXML.Size = new System.Drawing.Size(361, 22);
            this.mnuDocXML.Text = "Đọc Lại Bảng Kê File XML";
            this.mnuDocXML.Visible = false;
            this.mnuDocXML.Click += new System.EventHandler(this.mnuDocXML_Click);
            // 
            // mnuTraCuuTheBHYT
            // 
            this.mnuTraCuuTheBHYT.Name = "mnuTraCuuTheBHYT";
            this.mnuTraCuuTheBHYT.Size = new System.Drawing.Size(361, 22);
            this.mnuTraCuuTheBHYT.Text = "Tra cứu trực tuyến thẻ BHYT";
            this.mnuTraCuuTheBHYT.Click += new System.EventHandler(this.mnuTraCuuTheBHYT_Click);
            // 
            // mnuTraCuuChiPhiKCBBHYT
            // 
            this.mnuTraCuuChiPhiKCBBHYT.Name = "mnuTraCuuChiPhiKCBBHYT";
            this.mnuTraCuuChiPhiKCBBHYT.Size = new System.Drawing.Size(361, 22);
            this.mnuTraCuuChiPhiKCBBHYT.Text = "Tra cứu trực tuyến chi phí KCB BHYT";
            this.mnuTraCuuChiPhiKCBBHYT.Click += new System.EventHandler(this.mnuTraCuuChiPhiKCBBHYT_Click);
            // 
            // mnuTroGiup
            // 
            this.mnuTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHuongDanSuDung,
            this.mnuXemBaoCao,
            this.mnuGioiThieu});
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Size = new System.Drawing.Size(66, 20);
            this.mnuTroGiup.Text = "Trợ Giúp";
            // 
            // mnuHuongDanSuDung
            // 
            this.mnuHuongDanSuDung.Name = "mnuHuongDanSuDung";
            this.mnuHuongDanSuDung.Size = new System.Drawing.Size(184, 22);
            this.mnuHuongDanSuDung.Text = "Hướng dẫn sử dụng";
            this.mnuHuongDanSuDung.Click += new System.EventHandler(this.mnuHuongDanSuDung_Click);
            // 
            // mnuXemBaoCao
            // 
            this.mnuXemBaoCao.Name = "mnuXemBaoCao";
            this.mnuXemBaoCao.Size = new System.Drawing.Size(184, 22);
            this.mnuXemBaoCao.Text = "Xem báo cáo";
            this.mnuXemBaoCao.Click += new System.EventHandler(this.mnuXemBaoCao_Click);
            // 
            // mnuGioiThieu
            // 
            this.mnuGioiThieu.Name = "mnuGioiThieu";
            this.mnuGioiThieu.Size = new System.Drawing.Size(184, 22);
            this.mnuGioiThieu.Text = "Giới thiệu";
            this.mnuGioiThieu.Click += new System.EventHandler(this.mnuGioiThieu_Click_1);
            // 
            // mnuCuaSo
            // 
            this.mnuCuaSo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCloseAll});
            this.mnuCuaSo.Name = "mnuCuaSo";
            this.mnuCuaSo.Size = new System.Drawing.Size(58, 20);
            this.mnuCuaSo.Text = "Cửa Sổ";
            // 
            // mnuCloseAll
            // 
            this.mnuCloseAll.Name = "mnuCloseAll";
            this.mnuCloseAll.Size = new System.Drawing.Size(179, 22);
            this.mnuCloseAll.Text = "Đóng tất cả cửa sổ";
            this.mnuCloseAll.Click += new System.EventHandler(this.mnuCloseAll_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTenCSKCB,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6});
            this.statusStrip1.Location = new System.Drawing.Point(0, 720);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1106, 22);
            this.statusStrip1.TabIndex = 83;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTenCSKCB
            // 
            this.lblTenCSKCB.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenCSKCB.Name = "lblTenCSKCB";
            this.lblTenCSKCB.Size = new System.Drawing.Size(68, 17);
            this.lblTenCSKCB.Text = "Tên CSKCB";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabel1.Text = "Thêm (Ctrl+N)";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel2.Text = "Sửa (Ctrl+E) ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel3.Text = "Xóa (Ctrl+D)";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel4.Text = "Lưu (Ctrl+S)";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabel5.Text = "Xem (Ctrl+W)";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel6.Text = "In (Ctrl+P)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(358, 6);
            // 
            // mnuGiayChuyenTuyen
            // 
            this.mnuGiayChuyenTuyen.Name = "mnuGiayChuyenTuyen";
            this.mnuGiayChuyenTuyen.Size = new System.Drawing.Size(361, 22);
            this.mnuGiayChuyenTuyen.Text = "Giấy chuyển tuyến";
            this.mnuGiayChuyenTuyen.Click += new System.EventHandler(this.mnuGiayChuyenTuyen_Click);
            // 
            // mnuGiayRaVien
            // 
            this.mnuGiayRaVien.Name = "mnuGiayRaVien";
            this.mnuGiayRaVien.Size = new System.Drawing.Size(361, 22);
            this.mnuGiayRaVien.Text = "Giấy ra viện";
            this.mnuGiayRaVien.Click += new System.EventHandler(this.mnuGiayRaVien_Click);
            // 
            // MDIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 742);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.Name = "MDIMain";
            this.Text = "MDIMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIMain_FormClosing);
            this.Load += new System.EventHandler(this.MDIMain_Load);
            this.Resize += new System.EventHandler(this.MDIMain_Resize);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMucThuoc;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMucVTYT;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMucDichVu;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMucMauVaChePhamMau;
        private System.Windows.Forms.ToolStripSeparator mnu1;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMucMucHuong;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMucMucHuongDoiTuong;
        private System.Windows.Forms.ToolStripMenuItem mnuChuyenDoiMucHuong;
        private System.Windows.Forms.ToolStripSeparator mnu2;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMucICD;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMucCSKCB;
        private System.Windows.Forms.ToolStripMenuItem mnuHoSo;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapHoSo01;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapHoSo02;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapHoSo03;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuGuiBHYT;
        private System.Windows.Forms.ToolStripMenuItem mnuDocXML;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMucLuongCoSo;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem cauHinhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCuaSo;
        private System.Windows.Forms.ToolStripMenuItem mnuTraCuuTheBHYT;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseAll;
        private System.Windows.Forms.ToolStripMenuItem danhMụcPhòngBanToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTenCSKCB;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripMenuItem mnuDangKyKhamBenh;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuTraCuuChiPhiKCBBHYT;
        private System.Windows.Forms.ToolStripMenuItem mnuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem mnuHuongDanSuDung;
        private System.Windows.Forms.ToolStripMenuItem mnuXemBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuGioiThieu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuGiayChuyenTuyen;
        private System.Windows.Forms.ToolStripMenuItem mnuGiayRaVien;
    }
}

