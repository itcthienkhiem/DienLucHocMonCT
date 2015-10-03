using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using coInventory.Mini.DanhMuc.XuLy;
////using WebService.Model;;
//using WebService.Model;.Utility;

namespace coInventory.Mini.DanhMuc
{
    public struct BangKe_ChiTiet_ChuanDoan
    {
        clsBangKe objBangKe;

        public clsBangKe ObjBangKe
        {
            get { return objBangKe; }
            set { objBangKe = value; }
        }
        List<clsBangKeChiTiet> objBangKeChiTiet;

        public List<clsBangKeChiTiet> ObjBangKeChiTiet
        {
            get { return objBangKeChiTiet; }
            set { objBangKeChiTiet = value; }
        }
        List<clsBangKeChanDoan> objBangKeChuanDoan;

        public List<clsBangKeChanDoan> ObjBangKeChuanDoan
        {
            get { return objBangKeChuanDoan; }
            set { objBangKeChuanDoan = value; }
        }

    }
    public partial class frmDanhMucBangKe : Form
    {

        clsBangKe bangke = new clsBangKe();
        clsBangKeChiTiet bangkechitiet = new clsBangKeChiTiet();
        clsBangKeChanDoan bangkechuandoan = new clsBangKeChanDoan();
        clsThamSoHeThong bangThamSoHeThong = new clsThamSoHeThong();

        public frmDanhMucBangKe()
        {
            InitializeComponent();
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridMaster.RowCount; i++)
            {

                gridMaster[0, i].Value = ((CheckBox)gridMaster.Controls.Find("checkboxHeader", true)[0]).Checked;
                if (gridMaster[0, i] == null)
                {
                    gridMaster[0, i].Value = false;
                }
            }
            gridMaster.EndEdit();
        }
        protected T FromXml<T>(String xml)
        {
            T returnedXmlClass = default(T);

            try
            {
                using (TextReader reader = new StringReader(xml))
                {
                    try
                    {
                        returnedXmlClass =
                            (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                    }
                    catch (InvalidOperationException)
                    {
                        // String passed is not XML, simply return defaultXmlClass
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return returnedXmlClass;
        }
        private List<clsBangKeChiTiet> LayBangKeChiTiet(DataTable tbBangKeChiTiet)
        {
            List<clsBangKeChiTiet> lsBangKeChiTiet = new List<clsBangKeChiTiet>();
            DataTable tb = tbBangKeChiTiet;
            if (tb == null)
                return null;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                clsBangKeChiTiet objBangKeChiTiet = new clsBangKeChiTiet();

                objBangKeChiTiet.BangKeChiTiet_Id = int.Parse(tb.Rows[i]["BangKeChiTiet_Id"].ToString());
                objBangKeChiTiet.BangKe_Id = int.Parse(tb.Rows[i]["BangKe_Id"].ToString());
                objBangKeChiTiet.MaChiPhi = tb.Rows[i]["MaChiPhi"].ToString();
                objBangKeChiTiet.MaPhu = tb.Rows[i]["MaPhu"].ToString();
                objBangKeChiTiet.TenChiPhi = (tb.Rows[i]["TenChiPhi"].ToString());
                objBangKeChiTiet.DonViTinh = (tb.Rows[i]["DonViTinh"].ToString());

                try
                {
                    objBangKeChiTiet.SoLuong = decimal.Parse(tb.Rows[i]["SoLuong"].ToString());
                    objBangKeChiTiet.PhanTramDuocHuong = decimal.Parse(tb.Rows[i]["PhanTramDuocHuong"].ToString());
                    objBangKeChiTiet.DonGiaBHYT = decimal.Parse(tb.Rows[i]["DonGiaBHYT"].ToString());
                    objBangKeChiTiet.ThanhTienBHYT = decimal.Parse(tb.Rows[i]["ThanhTienBHYT"].ToString());
                    objBangKeChiTiet.BHYTThanhToan = decimal.Parse(tb.Rows[i]["BHYTThanhToan"].ToString());
                    objBangKeChiTiet.NguonKhac = decimal.Parse(tb.Rows[i]["NguonKhac"].ToString());

                    objBangKeChiTiet.NguoiBenhTra = decimal.Parse(tb.Rows[i]["NguoiBenhTra"].ToString());
                    objBangKeChiTiet.ChiPhiNgoaiDinhSuat = decimal.Parse(tb.Rows[i]["ChiPhiNgoaiDinhSuat"].ToString());
                }
                catch (Exception ex) { }
                objBangKeChiTiet.MaNhom1 = tb.Rows[i]["MaNhom1"].ToString();

                objBangKeChiTiet.MaNhom2 = tb.Rows[i]["MaNhom2"].ToString();
                objBangKeChiTiet.MaLoaiChiPhi = tb.Rows[i]["MaLoaiChiPhi"].ToString();

                objBangKeChiTiet.VTYTDichVuKTC = bool.Parse(tb.Rows[i]["VTYTDichVuKTC"].ToString());
                objBangKeChiTiet.DichVuKTC = bool.Parse(tb.Rows[i]["DichVuKTC"].ToString());
                objBangKeChiTiet.GhiChu = tb.Rows[i]["GhiChu"].ToString();
                lsBangKeChiTiet.Add(objBangKeChiTiet);

            }


            return lsBangKeChiTiet;

        }
        private List<clsBangKeChanDoan> LayBangKeChuanDoan(DataTable tbBangKeChuanDoan)
        {
            List<clsBangKeChanDoan> lsBangKeChiTiet = new List<clsBangKeChanDoan>();
            DataTable tb = tbBangKeChuanDoan;
            if (tb == null)
                return null;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                clsBangKeChanDoan objBangKeChiTiet = new clsBangKeChanDoan();
                objBangKeChiTiet.ChuanDoan_Id = int.Parse(tb.Rows[i]["ChanDoan_Id"].ToString());
                objBangKeChiTiet.BangKe_Id = int.Parse(tb.Rows[i]["BangKe_Id"].ToString());
                objBangKeChiTiet.MaICD = tb.Rows[i]["MaICD"].ToString();
                try
                {
                    objBangKeChiTiet.STT = int.Parse(tb.Rows[i]["STT"].ToString());
                }
                catch (Exception ex) { }
                lsBangKeChiTiet.Add(objBangKeChiTiet);

            }


            return lsBangKeChiTiet;

        }
        private clsBangKe LayDanhSachBangKe(int row)
        {

            clsBangKe objBangKe = new clsBangKe();
            // if (gridMaster.SelectedRows.Count > 0)
            {

                objBangKe.BangKe_Id = gridMaster.Rows[row].Cells["BangKe_Id"].Value is DBNull ? int.MinValue : Convert.ToInt32(gridMaster.Rows[row].Cells["BangKe_Id"].Value.ToString());
                objBangKe.LoaiBangKe = gridMaster.Rows[row].Cells["LoaiBangKe"].Value is DBNull ? int.MinValue : Convert.ToInt32(gridMaster.Rows[row].Cells["LoaiBangKe"].Value.ToString());
                objBangKe.SoHoSo = gridMaster.Rows[row].Cells["SoHoSo"].Value.ToString();
                objBangKe.Khoa = gridMaster.Rows[row].Cells["Khoa"].Value.ToString();
                objBangKe.MaKhamChuaBenh = gridMaster.Rows[row].Cells["MaKhamChuaBenh"].Value.ToString();
                objBangKe.MaNguoiBenh = gridMaster.Rows[row].Cells["MaNguoiBenh"].Value.ToString();
                objBangKe.HoTen = gridMaster.Rows[row].Cells["HoTen"].Value.ToString();

                objBangKe.DiaChi = gridMaster.Rows[row].Cells["DiaChi"].Value.ToString();

                objBangKe.MaNoiSinhSong = gridMaster.Rows[row].Cells["MaNoiSinhSong"].Value.ToString();
                objBangKe.SoTheBHYT = gridMaster.Rows[row].Cells["SoTheBHYT"].Value.ToString();
                try
                {
                    objBangKe.MaCSKCB = gridMaster.Rows[row].Cells["MaCSKCB"].Value.ToString();
                    objBangKe.TenCSKCBBanDau = gridMaster.Rows[row].Cells["TenCSKCBBanDau"].Value.ToString();
                    objBangKe.MaCSKCBBanDau = gridMaster.Rows[row].Cells["MaCSKCBBanDau"].Value.ToString();
                    objBangKe.MaChiNhanh = gridMaster.Rows[row].Cells["MaChiNhanh"].Value.ToString();
                    objBangKe.MaNoiChuyenDen = gridMaster.Rows[row].Cells["MaNoiChuyenDen"].Value.ToString();
                    objBangKe.TenNoiChuyenDen = gridMaster.Rows[row].Cells["TenNoiChuyenDen"].Value.ToString();
                    objBangKe.ChanDoan = gridMaster.Rows[row].Cells["ChanDoan"].Value.ToString();
                    objBangKe.GioiTinh = gridMaster.Rows[row].Cells["GioiTinh"].Value is DBNull ? (int?)null : (int.Parse(gridMaster.Rows[row].Cells["GioiTinh"].Value.ToString()));
                    objBangKe.NgaySinh = gridMaster.Rows[row].Cells["NgaySinh"].Value is DBNull ? (DateTime?)null : DateTime.Parse(gridMaster.Rows[row].Cells["NgaySinh"].Value.ToString());
                    objBangKe.NamSinh = gridMaster.Rows[row].Cells["NamSinh"].Value is DBNull ? (int?)null : int.Parse(gridMaster.Rows[row].Cells["NamSinh"].Value.ToString());
                    objBangKe.TuNgayBH = gridMaster.Rows[row].Cells["TuNgayBH"].Value is DBNull ? (DateTime?)null : DateTime.Parse(gridMaster.Rows[row].Cells["TuNgayBH"].Value.ToString());

                    objBangKe.DenNgayBH = gridMaster.Rows[row].Cells["DenNgayBH"].Value is DBNull ? (DateTime?)null : DateTime.Parse(gridMaster.Rows[row].Cells["DenNgayBH"].Value.ToString());
                    objBangKe.CoBHYT = gridMaster.Rows[row].Cells["CoBHYT"].Value is DBNull ? (bool?)null : bool.Parse(gridMaster.Rows[row].Cells["CoBHYT"].Value.ToString());
                    objBangKe.TreEmKhongTheBHYT = gridMaster.Rows[row].Cells["TreEmKhongTheBHYT"].Value is DBNull ? (bool?)null : bool.Parse(gridMaster.Rows[row].Cells["TreEmKhongTheBHYT"].Value.ToString());
                    objBangKe.MucHuong = gridMaster.Rows[row].Cells["MucHuong"].Value is DBNull ? (int?)null : int.Parse(gridMaster.Rows[row].Cells["MucHuong"].Value.ToString());
                    objBangKe.PhanTramDuocHuong = gridMaster.Rows[row].Cells["PhanTramDuocHuong"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["PhanTramDuocHuong"].Value.ToString());

                    objBangKe.NgayDenKham = gridMaster.Rows[row].Cells["NgayDenKham"].Value is DBNull ? (DateTime?)null : DateTime.Parse(gridMaster.Rows[row].Cells["NgayDenKham"].Value.ToString());
                    objBangKe.NgayKetThuc = gridMaster.Rows[row].Cells["NgayKetThuc"].Value is DBNull ? (DateTime?)null : DateTime.Parse(gridMaster.Rows[row].Cells["NgayKetThuc"].Value.ToString());

                    objBangKe.SoNgayDieuTri = gridMaster.Rows[row].Cells["SoNgayDieuTri"].Value is DBNull ? (int?)null : int.Parse(gridMaster.Rows[row].Cells["SoNgayDieuTri"].Value.ToString());
                    objBangKe.NgayQuyetToan = gridMaster.Rows[row].Cells["NgayQuyetToan"].Value is DBNull ? (DateTime?)null : DateTime.Parse(gridMaster.Rows[row].Cells["NgayQuyetToan"].Value.ToString());
                    objBangKe.TuyenKhamBenh = gridMaster.Rows[row].Cells["TuyenKhamBenh"].Value is DBNull ? (int?)null : int.Parse(gridMaster.Rows[row].Cells["TuyenKhamBenh"].Value.ToString());
                    objBangKe.BenhKhac = (gridMaster.Rows[row].Cells["BenhKhac"].Value.ToString());

                    objBangKe.MaICD = gridMaster.Rows[row].Cells["MaICD"].Value.ToString();
                    objBangKe.TongChiPhi = gridMaster.Rows[row].Cells["TongChiPhi"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["TongChiPhi"].Value.ToString());
                    objBangKe.BHYTThanhToan = gridMaster.Rows[row].Cells["BHYTThanhToan"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["BHYTThanhToan"].Value.ToString());
                    objBangKe.NguoiBenhTra = gridMaster.Rows[row].Cells["NguoiBenhTra"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["NguoiBenhTra"].Value.ToString());
                    objBangKe.NguonKhac = gridMaster.Rows[row].Cells["NguonKhac"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["NguonKhac"].Value.ToString());
                    objBangKe.SoTienThanhToanToiDa = gridMaster.Rows[row].Cells["SoTienThanhToanToiDa"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["SoTienThanhToanToiDa"].Value.ToString());
                    objBangKe.TienKham = gridMaster.Rows[row].Cells["TienKham"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["TienKham"].Value.ToString());
                    objBangKe.TienGiuong = gridMaster.Rows[row].Cells["TienGiuong"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["TienGiuong"].Value.ToString());
                    objBangKe.TienXN = gridMaster.Rows[row].Cells["TienXN"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["TienXN"].Value.ToString());
                    objBangKe.TienCDHA = gridMaster.Rows[row].Cells["TienCDHA"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["TienCDHA"].Value.ToString());
                    objBangKe.TienTDCN = gridMaster.Rows[row].Cells["TienTDCN"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["TienTDCN"].Value.ToString());
                    objBangKe.TienPTTT = gridMaster.Rows[row].Cells["TienPTTT"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["TienPTTT"].Value.ToString());
                    objBangKe.TienDichVuKTC = gridMaster.Rows[row].Cells["TienDichVuKTC"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["TienDichVuKTC"].Value.ToString());
                    objBangKe.TienMau = gridMaster.Rows[row].Cells["TienMau"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["TienMau"].Value.ToString());
                    objBangKe.TienThuoc = gridMaster.Rows[row].Cells["TienThuoc"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["TienThuoc"].Value.ToString());
                    objBangKe.TienVTYT = gridMaster.Rows[row].Cells["TienVTYT"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["TienVTYT"].Value.ToString());
                    objBangKe.TienVTYTTH = gridMaster.Rows[row].Cells["TienVTYTTH"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["TienVTYTTH"].Value.ToString());
                    objBangKe.TienVTYTTT = gridMaster.Rows[row].Cells["TienVTYTTT"].Value is DBNull ? (decimal?)null : int.Parse(gridMaster.Rows[row].Cells["TienVTYTTT"].Value.ToString());
                    objBangKe.TienVanChuyen = gridMaster.Rows[row].Cells["TienVanChuyen"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["TienVanChuyen"].Value.ToString());
                    objBangKe.DVKTC_TinhToan = gridMaster.Rows[row].Cells["DVKTC_TinhToan"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["DVKTC_TinhToan"].Value.ToString());
                    objBangKe.DVKTC_ThanhToan = gridMaster.Rows[row].Cells["DVKTC_ThanhToan"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["DVKTC_ThanhToan"].Value.ToString());
                    objBangKe.ChiPhiNgoaiDinhSuat = gridMaster.Rows[row].Cells["ChiPhiNgoaiDinhSuat"].Value is DBNull ? (decimal?)null : decimal.Parse(gridMaster.Rows[row].Cells["ChiPhiNgoaiDinhSuat"].Value.ToString());
                    objBangKe.DaGuiBHYT = gridMaster.Rows[row].Cells["DaGuiBHYT"].Value is DBNull ? (bool?)null : bool.Parse(gridMaster.Rows[row].Cells["DaGuiBHYT"].Value.ToString());
                    objBangKe.NgayGuiBHYT = gridMaster.Rows[row].Cells["NgayGuiBHYT"].Value is DBNull ? (DateTime?)null : DateTime.Parse(gridMaster.Rows[row].Cells["NgayGuiBHYT"].Value.ToString());
                    objBangKe.NguoiGuiBHYT = gridMaster.Rows[row].Cells["NguoiGuiBHYT"].Value.ToString();
                    objBangKe.NgayTao = gridMaster.Rows[row].Cells["NgayTao"].Value is DBNull ? (DateTime?)null : DateTime.Parse(gridMaster.Rows[row].Cells["NgayTao"].Value.ToString());
                    objBangKe.NguoiTao = gridMaster.Rows[row].Cells["NguoiTao"].Value.ToString();
                    objBangKe.NgayCapNhat = gridMaster.Rows[row].Cells["NgayCapNhat"].Value is DBNull ? (DateTime?)null : DateTime.Parse(gridMaster.Rows[row].Cells["NgayCapNhat"].Value.ToString());
                    objBangKe.NguoiCapNhat = gridMaster.Rows[row].Cells["NguoiCapNhat"].Value.ToString();
                    objBangKe.ChungNhanKhongCCT = gridMaster.Rows[row].Cells["ChungNhanKhongCCT"].Value is DBNull ? (bool?)null : bool.Parse(gridMaster.Rows[row].Cells["ChungNhanKhongCCT"].Value.ToString());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return objBangKe;
        }
        private List<BangKe_ChiTiet_ChuanDoan> SendData()
        {
            List<BangKe_ChiTiet_ChuanDoan> BangKeChiTietChuanDoan = new List<BangKe_ChiTiet_ChuanDoan>();
            for (int i = 0; i < gridMaster.Rows.Count; i++)
            //            foreach (DataGridViewRow gvrow in gridMaster.Rows)
            {
                bool dagui = bool.Parse(gridMaster.Rows[i].Cells["DaGuiBHYT"].Value.ToString());

                if (gridMaster[0, i].Value != null && (bool)gridMaster[0, i].Value == true && dagui == false)
                {
                    BangKe_ChiTiet_ChuanDoan bkctcd = new BangKe_ChiTiet_ChuanDoan();
                    int idBangKe = int.Parse(gridMaster["BangKe_Id", i].Value.ToString());
                    DataTable lsBangKeChiTiet = bangkechitiet.GetByID(idBangKe);
                    DataTable lsBangKeChuanDoan = bangkechuandoan.GetAll(idBangKe);


                    clsBangKe objBangKe = LayDanhSachBangKe(i);
                    bkctcd.ObjBangKe = objBangKe;

                    List<clsBangKeChiTiet> objBangKeChiTiet = LayBangKeChiTiet(lsBangKeChiTiet);
                    List<clsBangKeChanDoan> objBangKeChuanDoan = LayBangKeChuanDoan(lsBangKeChuanDoan);
                    bkctcd.ObjBangKeChiTiet = objBangKeChiTiet;
                    bkctcd.ObjBangKeChuanDoan = objBangKeChuanDoan;
                    BangKeChiTietChuanDoan.Add(bkctcd);
                }
            }
            return BangKeChiTietChuanDoan;

        }
        private void WriteXML()
        {
            //lay danh sach bang ke chi tiet 
            //DataTable thamso = bangThamSoHeThong.GetAll();

            //if (thamso == null)
            //{
            //    MessageBox.Show("Vui lòng kiểm tra đường dẫn trong database chưa tồn tại tham số đường dẫn file");
            //    return;
            //}
            SystemConfig conf = SystemConfig.Instance;
            string dir = conf.PathXML;//thamso.Rows[0]["GiaTriThamSo"].ToString();
            if (string.IsNullOrEmpty(dir.Trim()))
            {
                MessageBox.Show("Vui lòng kiểm tra đường dẫn trong cấu hình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            for (int i = 0; i < gridMaster.Rows.Count; i++)
            //            foreach (DataGridViewRow gvrow in gridMaster.Rows)
            {

                if (gridMaster[0, i].Value == null)
                {
                    continue;
                }
                bool temp = (bool)gridMaster[0, i].Value;
                if (temp == true)
                {
                    int idBangKe = int.Parse(gridMaster["BangKe_Id", i].Value.ToString());
                    DataTable lsBangKeChiTiet = bangkechitiet.GetByID(idBangKe);
                    DataTable lsBangKeChuanDoan = bangkechuandoan.GetAll(idBangKe);


                    clsBangKe objBangKe = LayDanhSachBangKe(i);
                    string today = DateTime.Now.ToString("yyyyMMdd");
                    string[] lsMaCS = conf.MaCSKCB.Split('-');
                    string MaCSKCB = lsMaCS[0] + lsMaCS[1];
                    //string path = dir + "/" + MaCSKCB + "/" + today + "/" + "BangKe0" + objBangKe.LoaiBangKe;
                    string path = dir + "/" + today + "/" + "BangKe0" + objBangKe.LoaiBangKe;
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    List<clsBangKeChiTiet> objBangKeChiTiet = LayBangKeChiTiet(lsBangKeChiTiet);
                    //    List<clsBangKeChanDoan> objBangKeChuanDoan = LayBangKeChuanDoan(lsBangKeChuanDoan);

                    try
                    {
                        XmlWriter xmlWriter = XmlWriter.Create(path + "/" + objBangKe.SoTheBHYT + "_" + objBangKe.MaKhamChuaBenh + ".xml");
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("BangKe");
                        xmlWriter.WriteAttributeString("PhienBan", "1.0");
                        xmlWriter.WriteAttributeString("LoaiBangKe", objBangKe.LoaiBangKe.ToString());
                        xmlWriter.WriteElementString("MaKhamChuaBenh", objBangKe.MaKhamChuaBenh);
                        xmlWriter.WriteElementString("MaNguoiBenh", objBangKe.MaNguoiBenh);
                        xmlWriter.WriteElementString("Khoa", objBangKe.Khoa);
                        xmlWriter.WriteElementString("HoTen", objBangKe.HoTen);

                        var NgaySinh = objBangKe.NgaySinh == null ? "" : objBangKe.NgaySinh.Value.ToString("dd/MM/yyyy");
                        xmlWriter.WriteElementString("NgaySinh", NgaySinh);


                        xmlWriter.WriteElementString("NamSinh", objBangKe.NamSinh.ToString());
                        xmlWriter.WriteElementString("GioiTinh", objBangKe.GioiTinh.ToString());
                        xmlWriter.WriteElementString("DiaChi", objBangKe.DiaChi);
                        xmlWriter.WriteElementString("SoTheBHYT", objBangKe.SoTheBHYT);
                        xmlWriter.WriteElementString("SuDungTu", objBangKe.TuNgayBH.Value.ToString("dd/MM/yyyy"));
                        xmlWriter.WriteElementString("SuDungDen", objBangKe.DenNgayBH.Value.ToString("dd/MM/yyyy"));
                        xmlWriter.WriteElementString("MaDKBanDau", objBangKe.MaCSKCBBanDau.Replace("-", ""));
                        xmlWriter.WriteElementString("MaNoiSinhSong", objBangKe.MaNoiSinhSong);
                        xmlWriter.WriteElementString("ChungNhanKhongCCT", objBangKe.ChungNhanKhongCCT == true ? "1" : "0");
                        xmlWriter.WriteElementString("NgayDenKham", objBangKe.NgayDenKham.Value.ToString("dd/MM/yyyy"));
                        xmlWriter.WriteElementString("NgayKetThuc", objBangKe.NgayKetThuc.Value.ToString("dd/MM/yyyy"));
                        xmlWriter.WriteElementString("NgayQuyetToan", objBangKe.NgayQuyetToan.Value.ToString("dd/MM/yyyy"));
                        xmlWriter.WriteElementString("SoNgayDieuTri", objBangKe.SoNgayDieuTri.ToString());
                        xmlWriter.WriteElementString("LyDoVV", objBangKe.TuyenKhamBenh.ToString());
                        //    xmlWriter.WriteElementString("MaCSKCBBanDau", objBangKe.MaCSKCBBanDau);
                        xmlWriter.WriteElementString("MaNoiChuyenDen", objBangKe.MaNoiChuyenDen.ToString());
                        xmlWriter.WriteElementString("ChanDoan", objBangKe.ChanDoan);
                        xmlWriter.WriteElementString("MaBenh", objBangKe.MaICD);
                        xmlWriter.WriteElementString("MaBenhKhac", objBangKe.BenhKhac);
                        xmlWriter.WriteElementString("PhanTramDuocHuong", objBangKe.PhanTramDuocHuong.ToString());
                        xmlWriter.WriteElementString("TongChiPhi", objBangKe.TongChiPhi.ToString());
                        xmlWriter.WriteElementString("NguonKhac", objBangKe.NguonKhac.ToString());
                        xmlWriter.WriteElementString("BHYTThanhToan", objBangKe.BHYTThanhToan.ToString());
                        xmlWriter.WriteElementString("NguoiBenhTra", objBangKe.NguoiBenhTra.ToString());
                        xmlWriter.WriteElementString("ChiPhiNgoaiDinhSuat", objBangKe.ChiPhiNgoaiDinhSuat.ToString());
                        xmlWriter.WriteElementString("MaChiNhanh", objBangKe.MaChiNhanh);

                        xmlWriter.WriteStartElement("CacChiPhi");
                        {


                            //neu ko co phan tu nao trong danh sach thi khoi tao tag voi gia tri mac dinh
                            if (objBangKeChiTiet != null && objBangKeChiTiet.Count != 0)
                            {


                                foreach (clsBangKeChiTiet chitiet in objBangKeChiTiet)
                                {
                                    xmlWriter.WriteStartElement("ChiPhi");
                                    xmlWriter.WriteAttributeString("MaChiPhi", chitiet.MaChiPhi);
                                    xmlWriter.WriteAttributeString("MaChiPhiCoSo", chitiet.MaChiPhi);
                                    xmlWriter.WriteAttributeString("TenChiPhi", chitiet.TenChiPhi);
                                    xmlWriter.WriteAttributeString("DonViTinh", chitiet.DonViTinh);
                                    xmlWriter.WriteAttributeString("MaNhom1", chitiet.MaNhom1);
                                    xmlWriter.WriteAttributeString("MaNhom2", chitiet.MaNhom2);
                                    xmlWriter.WriteAttributeString("PhanTramDuocHuong", chitiet.PhanTramDuocHuong.ToString());
                                    xmlWriter.WriteAttributeString("SoLuong", chitiet.SoLuong.ToString());
                                    xmlWriter.WriteAttributeString("DonGiaBHYT", chitiet.DonGiaBHYT.ToString());
                                    xmlWriter.WriteAttributeString("ThanhTien", chitiet.ThanhTienBHYT.ToString());
                                    xmlWriter.WriteAttributeString("NguonKhac", chitiet.NguonKhac.ToString());
                                    xmlWriter.WriteAttributeString("BHYTThanhToan", chitiet.BHYTThanhToan.ToString());
                                    xmlWriter.WriteAttributeString("NguoiBenhTra", chitiet.NguoiBenhTra.ToString());
                                    xmlWriter.WriteAttributeString("ChiPhiNgoaiDinhSuat", chitiet.ChiPhiNgoaiDinhSuat.ToString());
                                    xmlWriter.WriteAttributeString("TyLeThanhToan", chitiet.TyLeThanhToan.ToString());
                                    xmlWriter.WriteEndElement();
                                }


                            }

                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteEndElement();

                            xmlWriter.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xuất file không thành công.\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }


            }
            MessageBox.Show("Đã xuất file thành công, kiểm tra lại thư mục lưu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        int curRow = -1;
        private void gridMaster_SelectionChanged(object sender, EventArgs e)
        {
            if (gridMaster.CurrentRow != null && gridMaster.CurrentRow.Index != curRow)
            {
                curRow = gridMaster.CurrentRow.Index;

            }
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            WriteXML();
        }
        public DateTime GetFirstDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddDays(-(dtResult.Day) + 1);
            return dtResult;
        }
        private void frmDanhMucBangKe_Load(object sender, EventArgs e)
        {
            InIt();
            btnTimKiem_Click(null, null);

            // gridMaster[0, 1].ReadOnly = false;
        }

        private void InIt()
        {
            SystemConfig conf = SystemConfig.Instance;
            conf.GetThongTinCSKCB();
            if (conf.TuyenKham == "xa")
            {
                cbbLoaiBangKe.Items.Add("03/TYT");
                cbbLoaiBangKe.SelectedIndex = 3;
                cbbLoaiBangKe.Enabled = false;
            }
            else
            {
                cbbLoaiBangKe.Items.Remove("03/TYT");
                cbbLoaiBangKe.SelectedIndex = 0;
                cbbLoaiBangKe.Enabled = true;
            }

            dtpkTuNgay.Value = GetFirstDayOfMonth(DateTime.Now);
            dtpkDenNgay.Value = DateTime.Now;

            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.Width = 40;
            checkboxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridMaster.Columns.Insert(0, checkboxColumn);
            // add checkbox header
            Rectangle rect = gridMaster.GetCellDisplayRectangle(0, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position correctly.
            rect.X = rect.Location.X + (rect.Width) / 3;
            rect.Y += rect.Location.Y + (rect.Height) / 3;
            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.BackColor = Color.Transparent;
            checkboxHeader.Name = "checkboxHeader";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            checkboxHeader.Width = 40;
            gridMaster.Controls.Add(checkboxHeader);
            //gridMaster.Columns[0].ReadOnly = false;
            for (int i = 1; i < gridMaster.Columns.Count; i++)
                gridMaster.Columns[i].ReadOnly = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            clsBangKe obj = new clsBangKe();
            tbBangKeXML = obj.GetByKey(dtpkTuNgay.Value, dtpkDenNgay.Value, cbbLoaiBangKe.Text, txtSKB.Text, txtHoTen.Text, txtNam.Text, txtSoDKKBBHYT.Text);

            gridMaster.DataSource = tbBangKeXML;
        }

        private void SendToWS_Click(object sender, EventArgs e)
        {
            List<BangKe_ChiTiet_ChuanDoan> value = SendData();
            if (Send(value, "WSPutBangKe") == 1)
            {
                btnTimKiem_Click(null, null);
            }
        }
        public static int Send(List<BangKe_ChiTiet_ChuanDoan> lstobjBangKe, string WSPutBangKe)
        {
            return 0;
            //if (lstobjBangKe.Count == 0)
            //{
            //    MessageBox.Show("Chưa chọn bảng kê hoặc bảng kê đã gửi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return 0;
            //    //URL
            //}
            //SystemConfig sys = SystemConfig.Instance;
            //string URL = "WSUpdateBangKe/" + sys.MaCSKCB;
            //string param = string.Format("GetAccessToken/{0}/{1}", sys.Username, sys.Password);
            //string token = sys.GetToken();

            //if (!string.IsNullOrEmpty(token))
            //{

            //    for (int i = 0; i < lstobjBangKe.Count; i++)
            //    {
            //        clsBangKe BangKe = lstobjBangKe[i].ObjBangKe;

            //        BangKe01 objBangKe = new BangKe01();
            //        objBangKe.BangKe01ChiTiet = new List<BangKe01ChiTiet>();
            //        objBangKe.BangKe01ChanDoan = new List<BangKe01ChanDoan>();

            //        foreach (clsBangKeChiTiet bangkeCT in lstobjBangKe[i].ObjBangKeChiTiet)
            //        {
            //            BangKe01ChiTiet bk01ChiTiet = new BangKe01ChiTiet();

            //            switch (bangkeCT.MaLoaiChiPhi)
            //            {
            //                case "D":
            //                    bk01ChiTiet.MaDanhMuc = 3;
            //                    break;
            //                case "T":
            //                    bk01ChiTiet.MaDanhMuc = 1;
            //                    break;
            //                case "V":
            //                    bk01ChiTiet.MaDanhMuc = 2;
            //                    break;
            //                case "M":
            //                    bk01ChiTiet.MaDanhMuc = 4;
            //                    break;
            //            }

            //            bk01ChiTiet.BHYTThanhToan = bangkeCT.BHYTThanhToan;
            //            bk01ChiTiet.ChiPhiNgoaiDinhSuat = bangkeCT.ChiPhiNgoaiDinhSuat;

            //            bk01ChiTiet.LaDVKTC = bangkeCT.DichVuKTC;
            //            bk01ChiTiet.LaVTDVKTC = bangkeCT.VTYTDichVuKTC;

            //            bk01ChiTiet.DonGiaBHYT = bangkeCT.DonGiaBHYT;

            //            bk01ChiTiet.MaChiPhi = bangkeCT.MaChiPhi;
            //            bk01ChiTiet.MaChiPhi_HIS = bangkeCT.MaChiPhi;

            //            bk01ChiTiet.DonViTinh = bangkeCT.DonViTinh;
            //            bk01ChiTiet.DonViTinh_HIS = bangkeCT.DonViTinh;

            //            bk01ChiTiet.TenChiPhi = bangkeCT.TenChiPhi;
            //            bk01ChiTiet.TenChiPhi_HIS = bangkeCT.TenChiPhi;

            //            bk01ChiTiet.MaLoaiChiPhi = bangkeCT.MaNhom1;
            //            bk01ChiTiet.MaLoaiChiPhi2 = bangkeCT.MaNhom2;
            //            bk01ChiTiet.NguoiBenhTra = bangkeCT.NguoiBenhTra;
            //            bk01ChiTiet.NguonKhac = bangkeCT.NguonKhac;
            //            bk01ChiTiet.PhanTramDuocHuong = bangkeCT.PhanTramDuocHuong;
            //            bk01ChiTiet.SoLuong = bangkeCT.SoLuong;

            //            bk01ChiTiet.ThanhTien = bangkeCT.ThanhTienBHYT;

            //            bk01ChiTiet.TiLeThanhToan = bangkeCT.TyLeThanhToan;

            //            objBangKe.BangKe01ChiTiet.Add(bk01ChiTiet);
            //            //    bk01ChuanDoan.VTYTDichVuKTC = bangkeCT.VTYTDichVuKTC;

            //        }
            //        //foreach (clsBangKeChanDoan bkcd in lstobjBangKe[0].ObjBangKeChuanDoan)
            //        //{
            //        BangKe01ChanDoan cd = new BangKe01ChanDoan();
            //        //  cd.BangKe01Id = bkcd.BangKe_Id;
            //        cd.MaICD10 = BangKe.MaICD;
            //        cd.STT = 1;//byte.Parse(bkcd.STT.ToString());

            //        objBangKe.BangKe01ChanDoan.Add(cd);

            //        //}
            //        //  objBangKe.BangKe01Id = BangKe.BangKe_Id;
            //        objBangKe.BenhKhac = BangKe.BenhKhac;
            //        objBangKe.BHYTThanhToan = BangKe.BHYTThanhToan;
            //        objBangKe.CapCuu = BangKe.TuyenKhamBenh == 2 ? true : false;
            //        objBangKe.ChanDoan = BangKe.ChanDoan;
            //        objBangKe.ChinhSuaChiPhi = null;
            //        objBangKe.ChiPhiNgoaiDinhSuat = BangKe.ChiPhiNgoaiDinhSuat;
            //        objBangKe.ChungNhanKhongCTT = BangKe.ChungNhanKhongCCT;
            //        objBangKe.CoBHYT = BangKe.CoBHYT;
            //        objBangKe.DanhDauThongKe = false;
            //        objBangKe.DiaChi = BangKe.DiaChi;
            //        objBangKe.DiaChiVNFont = null;
            //        objBangKe.DieuTriNgoaiTru = null;
            //        objBangKe.DuaVaoQuyetToan = null;
            //        objBangKe.DungTuyen = BangKe.TuyenKhamBenh == 1 ? true : false;
            //        objBangKe.DVKTC_ThanhToan = BangKe.DVKTC_ThanhToan;
            //        objBangKe.DVKTC_TinhToan = BangKe.DVKTC_TinhToan;
            //        objBangKe.GhiChu = null;
            //        objBangKe.GhiChuChuyenSau = null;
            //        objBangKe.GiamDinhChuyenSau = null;
            //        objBangKe.GioiTinh = byte.Parse(BangKe.GioiTinh.ToString());
            //        objBangKe.HinhThucKham = BangKe.LoaiBangKe == 2 ? (byte)2 : (byte)1;
            //        objBangKe.HoTen = BangKe.HoTen;
            //        objBangKe.HoTenVNFont = null;
            //        objBangKe.HSLienQuanChinhSuaCP = null;
            //        objBangKe.ICD10CV = BangKe.MaICD;
            //        objBangKe.ImportBatch = null;
            //        objBangKe.KetQuaGiamDinh = null;
            //        objBangKe.Khoa = BangKe.Khoa;
            //        objBangKe.KhoaVNFont = null;
            //        objBangKe.LyDoTraHoSo = null;
            //        objBangKe.LyDoTuChoi = null;
            //        objBangKe.MaChiNhanh = BangKe.MaChiNhanh;
            //        objBangKe.MaCSKCB = BangKe.MaCSKCB;
            //        objBangKe.MaCSKCBBanDau = BangKe.MaCSKCBBanDau;
            //        objBangKe.MaDuongDan = null;
            //        objBangKe.MaLoi = null;
            //        objBangKe.MaNguoiBenh = BangKe.MaNguoiBenh;
            //        objBangKe.MaNoiChuyenDen = BangKe.MaNoiChuyenDen;
            //        objBangKe.TenNoiChuyenDen = BangKe.MaNoiChuyenDen;//BangKe.TenNoiChuyenDen;

            //        objBangKe.MaNoiSinhSong = BangKe.MaNoiSinhSong;
            //        objBangKe.MoTaLoi = null;
            //        objBangKe.NamQuyetToan = null;
            //        objBangKe.NamSinh = BangKe.NamSinh;
            //        objBangKe.NgayCapNhat = BangKe.NgayCapNhat == (DateTime?)null ? null : BangKe.NgayCapNhat;
            //        //DateTime dateTime;
            //        //     DateTime.TryParse("26/3/2015 12:00:00 AM", out dateTime);
            //        objBangKe.NgayDenKham = BangKe.NgayDenKham == (DateTime?)null ? null : BangKe.NgayDenKham;

            //        objBangKe.NgayGiamDinh = null;
            //        objBangKe.NgayGui = null;
            //        //            DateTime.TryParse("26/3/2015 12:00:00 AM", out dateTime);
            //        objBangKe.NgayKetThuc = BangKe.NgayKetThuc == (DateTime?)null ? null : BangKe.NgayKetThuc;
            //        objBangKe.NgayPheDuyet = null;
            //        objBangKe.NgayQuyetToan = BangKe.NgayQuyetToan == (DateTime?)null ? null : BangKe.NgayQuyetToan;
            //        objBangKe.NgaySinh = BangKe.NgaySinh;
            //        objBangKe.NgayTao = BangKe.NgayTao == (DateTime?)null ? null : BangKe.NgayTao;
            //        //DateTime.TryParse("26/3/2015 12:00:00 AM", out dateTime);
            //        objBangKe.NgayThanhToan = BangKe.NgayQuyetToan;//.NgayKetThuc;//quan trong
            //        objBangKe.NguoiBenhCungTra = null;
            //        objBangKe.NguoiBenhTra = BangKe.NguoiBenhTra;
            //        objBangKe.NguoiCapNhat = BangKe.NguoiCapNhat;
            //        objBangKe.NguoiGiamDinh = null;
            //        objBangKe.NguoiGiamDinhChuyenSau = null;
            //        objBangKe.NguoiGui = BangKe.NguoiGuiBHYT;
            //        objBangKe.NguoiNhoGiamDinhChuyenSau = null;
            //        objBangKe.NguoiPheDuyet = null;
            //        objBangKe.NguoiTao = BangKe.NguoiTao;
            //        objBangKe.NguonDuLieu = null;
            //        objBangKe.NguonKhac = BangKe.NguonKhac;
            //        objBangKe.NhomDoiTuong = null;
            //        objBangKe.NoiThanhToan = null;
            //        objBangKe.PhanTramDuocHuong = BangKe.PhanTramDuocHuong;
            //        objBangKe.QuyQuyetToan = null;
            //        objBangKe.SoHoSo = BangKe.SoHoSo;
            //        objBangKe.SoKhamBenh = BangKe.MaKhamChuaBenh;// "15032600001";
            //        objBangKe.SoNgayDieuTri = BangKe.SoNgayDieuTri;
            //        objBangKe.SoTheBHYT = BangKe.SoTheBHYT;// "GD7790800816264";
            //        objBangKe.SoTienThanhToanToiDa = BangKe.SoTienThanhToanToiDa;
            //        objBangKe.SoTienTuChoiThanhToan = null;
            //        objBangKe.STTCV = null;
            //        // DateTime.TryParse("31/12/2015 12:00:00 AM", out dateTime);
            //        objBangKe.SuDungDen = BangKe.DenNgayBH;//dateTime;
            //        //DateTime.TryParse("31/12/2015 12:00:00 AM", out dateTime);
            //        objBangKe.SuDungTu = BangKe.TuNgayBH;//dateTime;
            //        objBangKe.TenCSKCBBanDau = BangKe.TenCSKCBBanDau;

            //        objBangKe.ThangQuyetToan = null;
            //        objBangKe.TienCDHA = null;
            //        objBangKe.TienCDHA_XT = null;
            //        objBangKe.TienCDHA_XT2021 = null;
            //        objBangKe.TienDaTuyen = null;
            //        objBangKe.TienDVKTC = BangKe.TienDichVuKTC;//null;
            //        objBangKe.TienDVKTC_XT = null;
            //        objBangKe.TienDVKTC_XT2021 = null;
            //        objBangKe.TienKham = BangKe.TienKham;
            //        objBangKe.TienKham_XT = null;
            //        objBangKe.TienKham_XT2021 = null;
            //        objBangKe.TienKTG = null;
            //        objBangKe.TienKTG_XT = null;
            //        objBangKe.TienKTG_XT2021 = null;
            //        objBangKe.TienMau = BangKe.TienMau;
            //        objBangKe.TienMau_XT = null;
            //        objBangKe.TienMau_XT2021 = null;
            //        objBangKe.TienPTTT = BangKe.TienPTTT;
            //        objBangKe.TienPTTT_XT = null;
            //        objBangKe.TienPTTT_XT2021 = null;
            //        objBangKe.TienThongBao = null;
            //        objBangKe.TienVC = BangKe.TienVanChuyen;
            //        objBangKe.TienVC_XT = null;
            //        objBangKe.TienVC_XT2021 = null;
            //        objBangKe.TienVTYTTH = BangKe.TienVTYTTH;
            //        objBangKe.TienVTYTTH_XT = null;
            //        objBangKe.TienVTYTTH_XT2021 = null;
            //        objBangKe.TienVTYTTT = BangKe.TienVTYTTT;
            //        objBangKe.TienVTYTTT_XT = null;
            //        objBangKe.TienVTYTTT_XT2021 = null;
            //        objBangKe.TienVuotTran = null;
            //        objBangKe.TienXN = BangKe.TienXN;
            //        objBangKe.TienXN_XT = null;
            //        objBangKe.TienXN_XT2021 = null;
            //        objBangKe.TinhTrang = null;
            //        objBangKe.TinhTrangGiamDinh = null;
            //        objBangKe.TongChiPhi = BangKe.TongChiPhi;
            //        objBangKe.TongChiPhiThuoc = BangKe.TienThuoc;
            //        objBangKe.TongChiPhiThuoc_XT = null;
            //        objBangKe.TongChiPhiThuoc_XT2021 = null;
            //        objBangKe.TreEmKhongTheBHYT = BangKe.TreEmKhongTheBHYT;
            //        objBangKe.XuatToanTheo2021 = null;
            //        objBangKe.BenhKhac = BangKe.BenhKhac;


            //        string requestData = XMLUtils.SerializeDataContract(objBangKe);

            //        //  


            //        string response = sys.SendRequest(URL, "POST", requestData);// HttpRequest.WSRequest(URL, "POST", requestData, token);
            //        if (!string.IsNullOrEmpty(response) && response.IndexOf("Error:") == -1)
            //        {
            //            string value = XMLUtils.DeSerializeToObject<string>(response);
            //            int number = 0;
            //            if (!string.IsNullOrEmpty(value) && Int32.TryParse(value, out number))
            //            {
            //                BangKe.DaGuiBHYT = true;
            //                BangKe.BangKe_Id_BHXH = number;
            //                BangKe.Update_GuiBHXH();
            //            }
            //            else
            //            {
            //                MessageBox.Show("Gửi không thành công.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //                return 0;
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Gửi không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return 0;
            //            //quay lai truoc 
            //        }
            //    }
            //    MessageBox.Show("Đã gửi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return 1;
            //}
            //else
            //{
            //    MessageBox.Show("Hiện tại server đang bảo trì vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return 0;
            //}

        }
    }

}
