using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using BHXH.Model;
using BHXH.Model.Enum;
using System.Globalization;

namespace BHXH.Utils
{
    public static class XmlUtil
    {
        #region CSKCBs special
        public static string CSKCB_TREEM_KHONGTHE = "000";
        public static string CSKCB_KHONG_XAC_DINH = "ZZZ";
        #endregion

        private const string VERSION = "PhienBan";
        private const string LOAI_BANG_KE = "LoaiBangKe";

        private static CultureInfo culture = CultureInfo.CreateSpecificCulture("vi-VN");

        public static void ExportToXml(BangKe01 bangKe01, string filePath)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            // Root
            doc.Add(new XElement("BangKe01",
                        new XElement("Khoa", bangKe01.Khoa),
                        new XElement("SoKhamBenh", bangKe01.SoKhamBenh),
                        new XElement("MaNguoiBenh", bangKe01.MaNguoiBenh),
                        new XElement("HoTen", bangKe01.HoTen),
                        new XElement("NgaySinh", bangKe01.NgaySinh.Value),
                        new XElement("GioiTinh", bangKe01.GioiTinh),
                        new XElement("DiaChi", bangKe01.DiaChi),
                        new XElement("CoBHYT", bangKe01.CoBHYT),
                        new XElement("TreEmKhongTheBHYT", bangKe01.TreEmKhongTheBHYT),
                        new XElement("SoTheBHYT", bangKe01.SoTheBHYT),
                        new XElement("SuDungTu", bangKe01.SuDungTu),
                        new XElement("SuDungDen", bangKe01.SuDungDen),
                        new XElement("NamSinh", bangKe01.NamSinh),
                        new XElement("MaCSKCBBanDau", bangKe01.MaCSKCBBanDau),
                        new XElement("NgayDenKham", bangKe01.NgayDenKham),
                        new XElement("NgayKetThuc", bangKe01.NgayKetThuc),
                        new XElement("SoNgayDieuTri", bangKe01.SoNgayDieuTri),
                        new XElement("CapCuu", bangKe01.CapCuu),
                        new XElement("DungTuyen", bangKe01.DungTuyen),
                        new XElement("MaNoiChuyenDen", bangKe01.MaNoiChuyenDen),
                        new XElement("ChanDoan", bangKe01.ChanDoan),
                        new XElement("TongChiPhi", bangKe01.TongChiPhi),
                        new XElement("NguonKhac", bangKe01.NguonKhac),
                        new XElement("ChiPhiNgoaiDinhSuat", bangKe01.ChiPhiNgoaiDinhSuat.Value),
                        new XElement("MaChiNhanh", bangKe01.MaChiNhanh),
                        new XElement("BangKeChiTiets", bangKe01.BangKe01ChiTiet.Select(x => new XElement("BKChiTiet",
                                                      new XAttribute("MaDanhMuc", x.MaDanhMuc),
                                                      new XAttribute("MaDanhMuc_HIS", x.MaDanhMuc_HIS),
                                                      new XAttribute("MaChiPhi_HIS", x.MaChiPhi_HIS),
                                                      new XAttribute("TenChiPhi_HIS", x.TenChiPhi_HIS),
                                                      new XAttribute("DonViTinh_HIS", x.DonViTinh_HIS),
                                                      new XAttribute("SoLuong", x.SoLuong),
                                                      new XAttribute("DonGiaCSKCB", x.DonGiaCSKCB),
                                                      new XAttribute("ThanhTien", x.ThanhTien),
                                                      new XAttribute("ChiPhiNgoaiDinhSuat", x.ChiPhiNgoaiDinhSuat),
                                                      new XAttribute("NguonKhac", x.NguonKhac))
                                    )),
                        new XElement("BangKeChanDoans", bangKe01.BangKe01ChanDoan.Select(x => new XElement("BKChanDoan",
                                                        new XAttribute("MaICD10", x.MaICD10),
                                                        new XAttribute("STT", x.STT))
                                    ))
                  ));
            doc.Save(filePath);
        }

        #region Read XML file
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="loaiBangKe">
        /// 1: BangKe01, 2: BangKe02, 3: BangKe03
        /// </param>
        /// <returns></returns>
        public static BangKe01 ReadXml(string filePath)
        {
            XDocument doc = XDocument.Load(filePath);            
            XElement eBangKe = doc.Element("BangKe");
            IEnumerable<XAttribute> atts = eBangKe.Attributes();
            string version = string.Empty;
            string loaiBangKe = string.Empty;
            foreach (var item in atts)
            {
                if (item.Name.ToString().Equals(VERSION, StringComparison.CurrentCultureIgnoreCase))
                {
                    version = item.Value;
                }
                if (item.Name.ToString().Equals(LOAI_BANG_KE, StringComparison.CurrentCultureIgnoreCase))
                {
                    loaiBangKe = item.Value;
                }
            }

            BangKe01 bangke01 = ReadXMLByVersion(version, loaiBangKe, eBangKe);

            CheckAndFixMaCSKCBBanDau(bangke01);

            return bangke01;
        }

        private static BangKe01 ReadXMLByVersion(string version, string loaiBangKe, XElement eBangKe)
        {
            BangKe01 bk = new BangKe01();
            if (string.IsNullOrEmpty(version))
            {
                bk = ReadXMLDefaultVersion(eBangKe);
            }
            else if (version == "1.0")
            {
                bk = ReadXMLDefaultVersion(eBangKe);
            }

            if (loaiBangKe == "1" || loaiBangKe == "3")
            {
                bk.HinhThucKham = (byte)EnumHinhThucKham.NgoaiTru;
            }
            else
            {
                bk.HinhThucKham = (byte)EnumHinhThucKham.NoiTru;
            }
            return bk;
        }

        private static BangKe01 ReadXMLDefaultVersion(XElement eBangKe)
        {
            BangKe01 bangke01 = new BangKe01();
            bangke01.SoKhamBenh = eBangKe.Element("MaKhamChuaBenh").Value;
            bangke01.MaNguoiBenh = eBangKe.Element("MaNguoiBenh").Value;
            bangke01.Khoa = eBangKe.Element("Khoa").Value;            
            bangke01.HoTen = eBangKe.Element("HoTen").Value;
            bangke01.NgaySinh = DateTimeUtil.ParseDateTime(eBangKe.Element("NgaySinh").Value, culture);
            bangke01.NamSinh = Convert.ToInt32(eBangKe.Element("NamSinh").Value);
            bangke01.GioiTinh = Convert.ToByte(eBangKe.Element("GioiTinh").Value);
            bangke01.DiaChi = eBangKe.Element("DiaChi").Value;
            bangke01.SoTheBHYT = eBangKe.Element("SoTheBHYT").Value;
            bangke01.SuDungTu = DateTimeUtil.ParseDateTime(eBangKe.Element("SuDungTu").Value, culture);
            bangke01.SuDungDen = DateTimeUtil.ParseDateTime(eBangKe.Element("SuDungDen").Value, culture);
            bangke01.MaCSKCBBanDau = FormatToCSKCB(eBangKe.Element("MaDKBanDau").Value);
            bangke01.MaNoiSinhSong = string.IsNullOrEmpty(eBangKe.Element("MaNoiSinhSong").Value) ? null : eBangKe.Element("MaNoiSinhSong").Value;
            bangke01.ChungNhanKhongCTT = string.IsNullOrEmpty(eBangKe.Element("ChungNhanKhongCCT").Value)
                || eBangKe.Element("ChungNhanKhongCCT").Value == "0" ? false : true;
            bangke01.NgayDenKham = DateTimeUtil.ParseDateTime(eBangKe.Element("NgayDenKham").Value, culture);
            bangke01.NgayKetThuc = DateTimeUtil.ParseDateTime(eBangKe.Element("NgayKetThuc").Value, culture);
            bangke01.NgayThanhToan = DateTimeUtil.ParseDateTime(eBangKe.Element("NgayQuyetToan").Value, culture);
            bangke01.SoNgayDieuTri = string.IsNullOrEmpty(eBangKe.Element("SoNgayDieuTri").Value)
                || eBangKe.Element("SoNgayDieuTri").Value == "0" ? 1 : Convert.ToInt32(eBangKe.Element("SoNgayDieuTri").Value);            
            int tuyen = int.Parse(eBangKe.Element("LyDoVV").Value);
            SetTuyen(bangke01, tuyen);            
            
            bangke01.TenNoiChuyenDen = FormatToCSKCB(eBangKe.Element("MaNoiChuyenDen").Value);
            bangke01.ChanDoan = eBangKe.Element("ChanDoan").Value;
            bangke01.ICD10CV = eBangKe.Element("MaBenh").Value;
            bangke01.BenhKhac = eBangKe.Element("MaBenhKhac").Value;
            bangke01.PhanTramDuocHuong = Convert.ToInt32(eBangKe.Element("PhanTramDuocHuong").Value);
            bangke01.TongChiPhi = GetTien(eBangKe.Element("TongChiPhi").Value);
            bangke01.NguonKhac = GetTien(eBangKe.Element("NguonKhac").Value);
            bangke01.BHYTThanhToan = GetTien(eBangKe.Element("BHYTThanhToan").Value);
            bangke01.NguoiBenhTra = GetTien(eBangKe.Element("NguoiBenhTra").Value);
            bangke01.ChiPhiNgoaiDinhSuat = GetTien(eBangKe.Element("ChiPhiNgoaiDinhSuat").Value);
            bangke01.MaChiNhanh = eBangKe.Element("MaChiNhanh").Value;

            IEnumerable<XElement> items = eBangKe.Descendants("ChiPhi");
            List<BangKe01ChiTiet> bkcts = new List<BangKe01ChiTiet>();
            foreach (var item in items)
            {
                BangKe01ChiTiet bkct = new BangKe01ChiTiet();
                bkct.MaDanhMuc = GetMaDanhMuc(item.Attribute("MaNhom2").Value);
                bkct.MaLoaiChiPhi = item.Attribute("MaNhom1").Value;
                bkct.MaLoaiChiPhi2 = item.Attribute("MaNhom2").Value;
                bkct.MaDanhMuc_HIS = item.Attribute("MaPhu").Value;
                bkct.MaChiPhi_HIS = item.Attribute("MaChiPhi").Value;
                bkct.TenChiPhi_HIS = item.Attribute("TenChiPhi").Value;
                bkct.DonViTinh_HIS = item.Attribute("DonViTinh").Value;
                bkct.TrongDanhMucBHYT = GetTrongDanhMucBHYT(item.Attribute("MaNhom1").Value);

                bkct.LaDVKTC = GetDVKTTL(item.Attribute("MaNhom2").Value);
                bkct.LaVTDVKTC = GetVTYTTL(item.Attribute("MaNhom2").Value);
                bkct.CoTiLe = GetCoTiLe(item.Attribute("MaNhom2").Value);
                bkct.TiLeThanhToan = GetTiLeThanhToan(item.Attribute("TyLeThanhToan").Value);
                bkct.PhanTramDuocHuong = GetTien(item.Attribute("PhanTramDuocHuong").Value);
                bkct.SoLuong = GetTien(item.Attribute("SoLuong").Value);
                bkct.DonGiaBHYT = GetTien(item.Attribute("DonGiaBHYT").Value);
                bkct.ThanhTien = GetTien(item.Attribute("ThanhTien").Value);
                bkct.NguonKhac = GetTien(item.Attribute("NguonKhac").Value);
                bkct.BHYTThanhToan = GetTien(item.Attribute("BHYTThanhToan").Value);
                bkct.NguoiBenhTra = GetTien(item.Attribute("NguoiBenhTra").Value);
                bkct.ChiPhiNgoaiDinhSuat = GetTien(item.Attribute("ChiPhiNgoaiDinhSuat").Value);
                bkcts.Add(bkct);
            }
            bangke01.BangKe01ChiTiet = bkcts;

            List<BangKe01ChanDoan> bkcds = new List<BangKe01ChanDoan>();
            string[] icd10s = bangke01.ICD10CV.Split(';');
            byte stt = 0;
            foreach (var item in icd10s)
            {
                stt++;
                BangKe01ChanDoan bkcd = new BangKe01ChanDoan();
                bkcd.MaICD10 = item;
                bkcd.STT = stt;
                bkcds.Add(bkcd);
            }
            bangke01.BangKe01ChanDoan = bkcds.Distinct(new ChanDoanComparer()).ToList();

            return bangke01;
        }

        
             

        private static BangKe01 ReadXMLVersion12(XElement eBangKe)
        {
            BangKe01 bangke01 = new BangKe01();
            bangke01.SoKhamBenh = eBangKe.Element("MaKhamChuaBenh").Value;
            bangke01.Khoa = eBangKe.Element("Khoa").Value;
            bangke01.SoKhamBenh = eBangKe.Element("SoKhamBenh").Value;
            bangke01.MaNguoiBenh = eBangKe.Element("MaNguoiBenh").Value;
            bangke01.HoTen = eBangKe.Element("HoTen").Value;
            bangke01.NgaySinh = Convert.ToDateTime(eBangKe.Element("NgaySinh").Value);
            bangke01.GioiTinh = Convert.ToByte(eBangKe.Element("GioiTinh").Value);
            bangke01.DiaChi = eBangKe.Element("DiaChi").Value;
            bangke01.CoBHYT = Convert.ToBoolean(eBangKe.Element("CoBHYT").Value);
            bangke01.TreEmKhongTheBHYT = Convert.ToBoolean(eBangKe.Element("TreEmKhongTheBHYT").Value);
            bangke01.SoTheBHYT = eBangKe.Element("SoTheBHYT").Value;
            bangke01.MaNoiSinhSong = string.IsNullOrEmpty(eBangKe.Element("MaNoiSinhSong").Value) ? null : eBangKe.Element("MaNoiSinhSong").Value;
            bangke01.PhanTramDuocHuong = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(eBangKe.Element("PhanTramDuocHuong").Value)));
            bangke01.SuDungTu = Convert.ToDateTime(eBangKe.Element("SuDungTu").Value);
            bangke01.SuDungDen = Convert.ToDateTime(eBangKe.Element("SuDungDen").Value);
            bangke01.NamSinh = Convert.ToInt32(eBangKe.Element("NamSinh").Value);
            bangke01.MaCSKCBBanDau = FormatToCSKCB(eBangKe.Element("MaCSKCBBanDau").Value);
            bangke01.NgayDenKham = Convert.ToDateTime(eBangKe.Element("NgayDenKham").Value);
            bangke01.NgayKetThuc = Convert.ToDateTime(eBangKe.Element("NgayKetThuc").Value);
            bangke01.NgayThanhToan = Convert.ToDateTime(eBangKe.Element("NgayThanhToan").Value);
            bangke01.SoNgayDieuTri = string.IsNullOrEmpty(eBangKe.Element("SoNgayDieuTri").Value)
                || (!string.IsNullOrEmpty(eBangKe.Element("SoNgayDieuTri").Value) && eBangKe.Element("SoNgayDieuTri").Value == "0") ?
                1 : Convert.ToInt32(eBangKe.Element("SoNgayDieuTri").Value);
            bangke01.CapCuu = Convert.ToBoolean(eBangKe.Element("CapCuu").Value);
            bangke01.DungTuyen = Convert.ToBoolean(eBangKe.Element("DungTuyen").Value);
            bangke01.TenNoiChuyenDen = FormatToCSKCB(eBangKe.Element("MaNoiChuyenDen").Value);
            bangke01.ChanDoan = eBangKe.Element("ChanDoan").Value;
            bangke01.TongChiPhi = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(eBangKe.Element("TongChiPhi").Value)));
            bangke01.NguonKhac = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(eBangKe.Element("NguonKhac").Value)));
            bangke01.BHYTThanhToan = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(eBangKe.Element("BHYTThanhToan").Value)));
            bangke01.NguoiBenhTra = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(eBangKe.Element("NguoiBenhTra").Value)));
            bangke01.ChiPhiNgoaiDinhSuat = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(eBangKe.Element("ChiPhiNgoaiDinhSuat").Value)));
            bangke01.MaChiNhanh = eBangKe.Element("MaChiNhanh").Value;
            IEnumerable<XElement> items = eBangKe.Descendants("BKChiTiet");
            List<BangKe01ChiTiet> bkcts = new List<BangKe01ChiTiet>();
            foreach (var item in items)
            {
                BangKe01ChiTiet bkct = new BangKe01ChiTiet();
                bkct.MaDanhMuc = GetMaDanhMuc(item.Attribute("MaNhom2").Value);                
                bkct.MaLoaiChiPhi = item.Attribute("MaNhom1").Value;
                bkct.MaLoaiChiPhi2 = item.Attribute("MaNhom2").Value;
                bkct.MaDanhMuc_HIS = item.Attribute("MaPhu").Value;
                bkct.MaChiPhi_HIS = item.Attribute("MaChiPhi").Value;
                bkct.TenChiPhi_HIS = item.Attribute("TenChiPhi").Value;
                bkct.DonViTinh_HIS = item.Attribute("DonViTinh").Value;
                bkct.TrongDanhMucBHYT = GetTrongDanhMucBHYT(item.Attribute("MaNhom1").Value);

                bkct.LaDVKTC = GetDVKTTL(item.Attribute("MaNhom2").Value);
                bkct.LaVTDVKTC = GetVTYTTL(item.Attribute("MaNhom2").Value);
                bkct.CoTiLe = GetCoTiLe(item.Attribute("MaNhom2").Value);
                //bkct.TiLeThanhToan = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(item.Attribute("TiLeThanhToan").Value)));
                bkct.PhanTramDuocHuong = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(item.Attribute("PhanTramDuocHuong").Value)));
                bkct.SoLuong = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(item.Attribute("SoLuong").Value)));                
                bkct.DonGiaBHYT = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(item.Attribute("DonGiaBHYT").Value)));
                bkct.ThanhTien = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(item.Attribute("ThanhTien").Value)));
                bkct.NguonKhac = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(item.Attribute("NguonKhac").Value)));
                bkct.BHYTThanhToan = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(item.Attribute("BHYTThanhToan").Value)));
                bkct.NguoiBenhTra = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(item.Attribute("NguoiBenhTra").Value)));
                bkct.ChiPhiNgoaiDinhSuat = Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(item.Attribute("ChiPhiNgoaiDinhSuat").Value)));                
                bkcts.Add(bkct);
            }
            bangke01.BangKe01ChiTiet = bkcts;

            List<BangKe01ChanDoan> bkcds = new List<BangKe01ChanDoan>();
            items = eBangKe.Descendants("ICD10");
            foreach (var item in items)
            {
                BangKe01ChanDoan bkcd = new BangKe01ChanDoan();
                bkcd.STT = Convert.ToByte(item.Attribute("STT").Value);
                bkcd.MaICD10 = item.Attribute("MaICD10").Value;                
                bkcds.Add(bkcd);
            }
            bangke01.BangKe01ChanDoan = bkcds.Distinct(new ChanDoanComparer()).ToList();

            return bangke01;
        }
        
        #endregion

        #region Utils
        private static string FormatToCSKCB(string tempCSKCB)
        {
            if (tempCSKCB.Length == 5)
            {
                return string.Format("{0}-{1}", tempCSKCB.Substring(0, 2), tempCSKCB.Substring(2, 3));
            }
            else
            {
                return tempCSKCB;
            }
        }

        private static string ReplaceDecimalSymbol(string money)
        {
            return money.Replace(".", ",");
        }

        public class ChanDoanComparer : IEqualityComparer<BangKe01ChanDoan>
        {
            #region IEqualityComparer<BangKe01ChanDoan> Members
            bool IEqualityComparer<BangKe01ChanDoan>.Equals(BangKe01ChanDoan x, BangKe01ChanDoan y)
            {
                return x.MaICD10 == y.MaICD10;
            }

            int IEqualityComparer<BangKe01ChanDoan>.GetHashCode(BangKe01ChanDoan obj)
            {
                return obj.MaICD10.GetHashCode();
            }
            #endregion
        }

        private static void CheckAndFixMaCSKCBBanDau(BangKe01 bangke)
        {
            if (bangke.MaCSKCBBanDau.Length == 5)
            {
                bangke.MaCSKCBBanDau = string.Format("{0}-{1}", bangke.MaCSKCBBanDau.Substring(0, 2), bangke.MaCSKCBBanDau.Substring(2, 3));
            }
            else if (bangke.MaCSKCBBanDau.Length == 6
                && bangke.MaCSKCBBanDau.IndexOf('-') > 0)
            {
                //do nothing
            }
            else
            {
                if (bangke.SoTheBHYT.StartsWith("TE") && bangke.SoTheBHYT.Substring(7, 3) == "000")
                {
                    bangke.TreEmKhongTheBHYT = true;
                    bangke.TenCSKCBBanDau = bangke.MaCSKCBBanDau;
                    bangke.MaCSKCBBanDau = string.Format("{0}-{1}", bangke.SoTheBHYT.Substring(3, 2), CSKCB_TREEM_KHONGTHE);
                }
                else
                {
                    bangke.TenCSKCBBanDau = bangke.MaCSKCBBanDau;
                    bangke.MaCSKCBBanDau = string.Format("{0}-{1}", bangke.SoTheBHYT.Substring(3, 2), CSKCB_KHONG_XAC_DINH);
                }
            }
        }

        private static byte GetMaDanhMuc(string manhom2)
        {
            EnumDanhMuc madanhmuc = EnumDanhMuc.Default;
            switch (manhom2)
            {
                case "03":
                case "08":
                    madanhmuc = EnumDanhMuc.Thuoc;
                    break;
                case "06":
                case "09":
                    madanhmuc = EnumDanhMuc.VatTuYTe;
                    break;
                case "04":
                    madanhmuc = EnumDanhMuc.MauVaChePham;
                    break;
                default:
                    madanhmuc = EnumDanhMuc.Khac;
                    break;
            }
            return (byte)madanhmuc;
        }

        private static bool? GetTrongDanhMucBHYT(string manhom1)
        {
            bool trongbhyt = true;
            switch (manhom1)
            {
                case "09.2":
                case "10.2":
                    trongbhyt = false;
                    break;
                default:
                    break;
            }
            return trongbhyt;
        }

        private static void SetTuyen(BangKe01 bangke01, int tuyen)
        {
            // 0: trai tuyen
            // 1: dung tuyen
            // 2: cap cuu
            if (tuyen == 0)
            {
                bangke01.CapCuu = false;
                bangke01.DungTuyen = false;
            }
            else if (tuyen == 1)
            {
                bangke01.CapCuu = false;
                bangke01.DungTuyen = true;
            }
            else
            {
                bangke01.CapCuu = true;
                bangke01.DungTuyen = true;
            }
        }   

        private static bool? GetDVKTTL(string manhom2)
        {
            bool dvkttl = false;
            switch (manhom2)
            {
                case "07":
                    dvkttl = true;
                    break;
                default:
                    break;
            }
            return dvkttl;
        }

        private static bool? GetVTYTTL(string manhom2)
        {
            bool vtyttl = false;
            switch (manhom2)
            {
                case "09":
                    vtyttl = true;
                    break;
                default:
                    break;
            }
            return vtyttl;
        }

        private static bool? GetThuocTL(string manhom2)
        {
            bool thuoctl = false;
            switch (manhom2)
            {
                case "08":
                    thuoctl = true;
                    break;
                default:
                    break;
            }
            return thuoctl;
        }

        private static bool? GetCoTiLe(string manhom2)
        {
            bool cotl = false;
            switch (manhom2)
            {
                case "07":
                case "08":
                case "09":
                    cotl = true;
                    break;
                default:
                    break;
            }
            return cotl;
        }

        private static decimal? GetTiLeThanhToan(string tile)
        {
            if (string.IsNullOrEmpty(tile))
            {
                return 100;
            }
            else
            {
                return Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(tile)));
            }
        }

        private static decimal? GetTien(string tien)
        {
            if (string.IsNullOrEmpty(tien))
            {
                return 0;
            }
            else
	        {
                return Convert.ToDecimal(Convert.ToDouble(ReplaceDecimalSymbol(tien)));
	        }
        }
        #endregion
    }

}
