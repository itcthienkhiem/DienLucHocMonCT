using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using coInventory.Mini.EntityClass;
using coInventory.Mini.Utilities;
using System.IO;
using System.Globalization;
namespace coInventory.Mini.DanhMuc
{
    public partial class frmBangKeXML : Form
    {
        public frmBangKeXML()
        {
            InitializeComponent();


        }
        List<clsBangKeChiTiet> objBangKeChiTiet = new List<clsBangKeChiTiet>();
        clsBangKe objBangKe = new clsBangKe();
        private void btnDocXml_Click(object sender, EventArgs e)
        {

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Thread updateFile = new Thread(new ThreadStart(LoadFile));
                // updateFile.Start();
                string folderName = folderBrowserDialog.SelectedPath;
                string txtDuongDan = folderName;
                CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");

                for (int i = 0; i < Directory.GetFiles(txtDuongDan, "*.XML", System.IO.SearchOption.TopDirectoryOnly).Length; i++)
                {
                    DataRow row = tbBangKeXML.NewRow();
                    tbBangKeXML.Rows.Add(row);
                    tbBangKeXML.Rows[i]["BangKe_id"] = i;
                    FileInfo info = new FileInfo(Directory.GetFiles(txtDuongDan, "*.XML", System.IO.SearchOption.TopDirectoryOnly)[i].ToString());
                    using (XmlReader reader = XmlReader.Create(info.FullName))
                    {
                        while (reader.Read())
                        {
                            // Only detect start elements.
                            if (reader.IsStartElement())
                            {
                                // Get element name and switch on it.
                                switch (reader.Name)
                                {
                                    case "BangKe":
                                        string PhienBan = reader["PhienBan"];
                                        string LoaiBangKe = reader["LoaiBangKe"];
                                        objBangKe.LoaiBangKe = int.Parse(LoaiBangKe);
                                        tbBangKeXML.Rows[i]["LoaiBangKe"] = LoaiBangKe;
                                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Cube"))
                                        {

                                        }
                                        break;
                                    //case "MaCSKCBBanDau":
                                    //     objBangKe.MaCSKCBBanDau = reader.ReadString();
                                    //     tbBangKeXML.Rows[i]["MaCSKCBBanDau"] = objBangKe.MaCSKCBBanDau;
                                    //        break;
                                    case "MaKhamChuaBenh":
                                        {

                                            objBangKe.MaCSKCB = reader.ReadString();
                                            tbBangKeXML.Rows[i]["MaCSKCB"] = objBangKe.MaCSKCB;
                                        }
                                        break;
                                    case "MaNguoiBenh":
                                        {

                                            objBangKe.MaNguoiBenh = reader.ReadString();
                                            tbBangKeXML.Rows[i]["MaNguoiBenh"] = objBangKe.MaNguoiBenh;
                                        }
                                        break;
                                    case "Khoa":
                                        {

                                            objBangKe.Khoa = reader.ReadString();
                                            tbBangKeXML.Rows[i]["Khoa"] = objBangKe.Khoa;
                                        }
                                        break;
                                    case "HoTen":
                                        {

                                            objBangKe.HoTen = reader.ReadString();
                                            tbBangKeXML.Rows[i]["HoTen"] = objBangKe.HoTen;
                                        }
                                        break;
                                    case "NgaySinh":
                                        {

                                            objBangKe.NgaySinh = Utils.convertDateTime(reader.ReadString());
                                            tbBangKeXML.Rows[i]["NgaySinh"] = objBangKe.NgaySinh;
                                        }
                                        break;
                                    case "NamSinh":
                                        {

                                            objBangKe.NamSinh = Utils.convertInt(reader.ReadString());
                                            tbBangKeXML.Rows[i]["NamSinh"] = objBangKe.NamSinh;
                                        }
                                        break;
                                    case "GioiTinh":
                                        {

                                            objBangKe.GioiTinh = Utils.convertInt(reader.ReadString());
                                            tbBangKeXML.Rows[i]["GioiTinh"] = objBangKe.GioiTinh;
                                        }
                                        break;
                                    case "DiaChi":
                                        {

                                            objBangKe.DiaChi = reader.ReadString();
                                            tbBangKeXML.Rows[i]["DiaChi"] = objBangKe.DiaChi;
                                        }
                                        break;
                                    case "SoTheBHYT":
                                        {

                                            objBangKe.SoTheBHYT = reader.ReadString();
                                            tbBangKeXML.Rows[i]["SoTheBHYT"] = objBangKe.SoTheBHYT;
                                        }
                                        break;
                                    case "SuDungTu":
                                        {

                                            objBangKe.TuNgayBH = Utils.convertDateTime(reader.ReadString());
                                            tbBangKeXML.Rows[i]["TuNgayBH"] = objBangKe.TuNgayBH;
                                        }
                                        break;
                                    case "SuDungDen":
                                        objBangKe.DenNgayBH = Utils.convertDateTime(reader.ReadString());
                                        tbBangKeXML.Rows[i]["DenNgayBH"] = objBangKe.DenNgayBH;
                                        break;
                                    case "MaDKBanDau":
                                        objBangKe.MaCSKCBBanDau = (reader.ReadString());
                                        tbBangKeXML.Rows[i]["MaCSKCBBanDau"] = objBangKe.MaCSKCBBanDau;
                                        break;
                                    case "MaNoiSinhSong":
                                        objBangKe.MaNoiSinhSong = (reader.ReadString());
                                        tbBangKeXML.Rows[i]["MaNoiSinhSong"] = objBangKe.MaNoiSinhSong;
                                        break;
                                    case "ChungNhanKhongCTC":
                                        objBangKe.ChungNhanKhongCCT = bool.Parse(reader.ReadString());
                                        tbBangKeXML.Rows[i]["ChungNhanKhongCCT"] = objBangKe.ChungNhanKhongCCT;
                                        break;
                                    case "NgayDenKham":
                                        {

                                            objBangKe.NgayDenKham = Utils.convertDateTime(reader.ReadString());
                                            tbBangKeXML.Rows[i]["NgayDenKham"] = objBangKe.NgayDenKham;
                                        }
                                        break;
                                    case "NgayKetThuc":
                                        {

                                            objBangKe.NgayKetThuc = Utils.convertDateTime(reader.ReadString());
                                            tbBangKeXML.Rows[i]["NgayKetThuc"] = objBangKe.NgayKetThuc;
                                        }
                                        break;

                                    case "NgayQuyetToan":
                                        {

                                            objBangKe.NgayQuyetToan = Utils.convertDateTime(reader.ReadString());
                                            tbBangKeXML.Rows[i]["NgayQuyetToan"] = objBangKe.NgayQuyetToan;
                                        }
                                        break;
                                    case "SoNgayDieuTri":
                                        {

                                            objBangKe.SoNgayDieuTri = Utils.convertInt(reader.ReadString());
                                            tbBangKeXML.Rows[i]["SoNgayDieuTri"] = objBangKe.SoNgayDieuTri;
                                        }
                                        break;
                                    case "LyDoVV":
                                        {

                                            objBangKe.TuyenKhamBenh = Utils.convertInt(reader.ReadString());
                                            tbBangKeXML.Rows[i]["TuyenKhamBenh"] = objBangKe.TuyenKhamBenh;
                                        }
                                        break;
                                    case "MaNoiChuyenDen":
                                        {

                                            objBangKe.MaNoiChuyenDen = (reader.ReadString());
                                            tbBangKeXML.Rows[i]["MaNoiChuyenDen"] = objBangKe.MaNoiChuyenDen;
                                        }
                                        break;
                                    case "ChuanDoan":
                                        {

                                            objBangKe.ChanDoan = (reader.ReadString());
                                            tbBangKeXML.Rows[i]["ChanDoan"] = objBangKe.ChanDoan;
                                        }
                                        break;
                                    case "PhanTramDuocHuong":
                                        {


                                            objBangKe.PhanTramDuocHuong = Utils.convertDecimal((reader.ReadString()), NumberStyles.Currency, enUS);
                                            tbBangKeXML.Rows[i]["PhanTramDuocHuong"] = objBangKe.PhanTramDuocHuong;
                                        }
                                        break;
                                    case "TongChiPhi":
                                        {


                                            objBangKe.TongChiPhi = Utils.convertDecimal((reader.ReadString()), NumberStyles.Currency, enUS);
                                            tbBangKeXML.Rows[i]["TongChiPhi"] = objBangKe.TongChiPhi;
                                        }
                                        break;

                                    case "NguonKhac":
                                        {


                                            objBangKe.NguonKhac = Utils.convertDecimal((reader.ReadString()), NumberStyles.Currency, enUS);
                                            tbBangKeXML.Rows[i]["NguonKhac"] = objBangKe.NguonKhac;
                                        }
                                        break;
                                    case "BHYTThanhToan":
                                        {


                                            objBangKe.BHYTThanhToan = Utils.convertDecimal((reader.ReadString()), NumberStyles.Currency, enUS);
                                            tbBangKeXML.Rows[i]["BHYTThanhToan"] = objBangKe.BHYTThanhToan;
                                        }
                                        break;
                                    case "NguoiBenhTra":
                                        {


                                            objBangKe.NguoiBenhTra = Utils.convertDecimal((reader.ReadString()), NumberStyles.Currency, enUS);
                                            tbBangKeXML.Rows[i]["NguoiBenhTra"] = objBangKe.NguoiBenhTra;
                                        }
                                        break;
                                    case "ChiPhiNgoaiDinhSuat":
                                        {


                                            objBangKe.ChiPhiNgoaiDinhSuat = Utils.convertDecimal((reader.ReadString()), NumberStyles.Currency, enUS);
                                            tbBangKeXML.Rows[i]["ChiPhiNgoaiDinhSuat"] = objBangKe.ChiPhiNgoaiDinhSuat;
                                        }
                                        break;
                                    case "MaChiNhanh":
                                        {


                                            objBangKe.MaChiNhanh = ((reader.ReadString()));
                                            tbBangKeXML.Rows[i]["MaChiNhanh"] = objBangKe.MaChiNhanh;
                                        }
                                        break;
                                    case "MaBenh":
                                        {


                                            objBangKe.MaICD = ((reader.ReadString()));
                                            tbBangKeXML.Rows[i]["MaICD"] = objBangKe.MaICD;
                                        }
                                        break;
                                    case "BenhKhac":
                                        {


                                            objBangKe.BenhKhac = ((reader.ReadString()));
                                            tbBangKeXML.Rows[i]["BenhKhac"] = objBangKe.BenhKhac;
                                        }
                                        break;

                                    case "ChiPhi":
                                        {
                                            string MaChiPhi = reader["MaChiPhi"];
                                            string TenChiPhi = reader["TenChiPhi"];
                                            string DonViTinh = reader["DonViTinh"];
                                            string MaNhom1 = reader["MaNhom1"];
                                            string MaNhom2 = reader["MaNhom2"];


                                            decimal PhanTramDuocHuong = Utils.convertDecimal(reader["PhanTramDuocHuong"], NumberStyles.Currency, enUS);
                                            decimal SoLuong = Utils.convertDecimal(reader["SoLuong"], NumberStyles.Currency, enUS);
                                            decimal DonGiaBHYT = Utils.convertDecimal(reader["DonGiaBHYT"], NumberStyles.Currency, enUS);
                                            decimal ThanhTien = Utils.convertDecimal(reader["ThanhTien"], NumberStyles.Currency, enUS);
                                            decimal NguonKhac = Utils.convertDecimal(reader["NguonKhac"], NumberStyles.Currency, enUS);
                                            decimal BHYTThanhToan = Utils.convertDecimal(reader["BHYTThanhToan"], NumberStyles.Currency, enUS);
                                            decimal NguoiBenhTra = Utils.convertDecimal(reader["NguoiBenhTra"], NumberStyles.Currency, enUS);
                                            decimal ChiPhiNgoaiDinhSuat = Utils.convertDecimal(reader["ChiPhiNgoaiDinhSuat"], NumberStyles.Currency, enUS);
                                            clsBangKeChiTiet ct = new clsBangKeChiTiet();
                                            ct.MaChiPhi = MaChiPhi;
                                            ct.TenChiPhi = TenChiPhi;
                                            ct.DonViTinh = DonViTinh;
                                            ct.MaNhom1 = MaNhom1;
                                            ct.MaNhom2 = MaNhom2;
                                            ct.PhanTramDuocHuong = (PhanTramDuocHuong);
                                            ct.SoLuong = (SoLuong);
                                            ct.DonGiaBHYT = (DonGiaBHYT);
                                            ct.ThanhTienBHYT = (ThanhTien);
                                            ct.NguonKhac = (NguonKhac);
                                            ct.BHYTThanhToan = (BHYTThanhToan);
                                            ct.NguoiBenhTra = (NguoiBenhTra);
                                            ct.ChiPhiNgoaiDinhSuat = (ChiPhiNgoaiDinhSuat);
                                            objBangKeChiTiet.Add(ct);
                                            break;
                                        }



                                }

                            }
                        }



                    }
                }
            }
        }

        private void frmBangKeXML_Load(object sender, EventArgs e)
        {
            gridMaster.DataSource = tbBangKeXML;
        }



    }
}
