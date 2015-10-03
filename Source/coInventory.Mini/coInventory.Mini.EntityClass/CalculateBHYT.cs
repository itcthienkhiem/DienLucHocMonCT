using System;
using System.Collections.Generic;
using System.Text;

namespace coInventory.Mini.EntityClass
{
    public static class CalculateBHYT
    {
        public static decimal GetPhanTramDuocHuong(string soTheBHYT, bool dungTuyen, byte tuyen, decimal tongChiPhi,
                    string maNoiSinhSong, byte hinhThuc, DateTime? ngayThanhToan, decimal luong, List<clsDM_ChuyenDoiMucHuong> cds, List<clsDM_MucHuong> mhs, bool CNKCCT)
        {
            if (CNKCCT && dungTuyen)
            {
                return 100;
            }
            else
            {
                return PhanTramDuocHuong(soTheBHYT, dungTuyen, tuyen, tongChiPhi, maNoiSinhSong, hinhThuc, ngayThanhToan.Value, luong, cds, mhs);
            }
        }

        #region Calculate bhxh

        private static decimal PhanTramDuocHuong(string soTheBHYT, bool dungTuyen, byte tuyen, decimal tongChiPhi, string maNoiSinhSong, byte hinhThuc, DateTime ngayThanhToan, decimal luong, List<clsDM_ChuyenDoiMucHuong> cds, List<clsDM_MucHuong> mhs)
        {
            try
            {
                soTheBHYT = soTheBHYT.Replace("-", "");
                string doiTuong = soTheBHYT.Substring(0, 2);
                int quyenloi = Int32.Parse(soTheBHYT.Substring(2, 1));
                decimal phantram = 100;
                double tile = 1;
                //decimal luong = clsDM_LuongCoSo.GetLuongCoSo();
                //List<clsDM_ChuyenDoiMucHuong> cds = clsDM_ChuyenDoiMucHuong.GetListChuyenDoi();
                //List<clsDM_MucHuong> mhs = clsDM_MucHuong.GetListMucHuong();
                foreach (var item in cds)
                {
                    if (item.DoiTuong == doiTuong && item.MucHuongCu == quyenloi)
                    {
                        quyenloi = item.MucHuongMoi;
                        break;
                    }
                }
                foreach (var item in mhs)
                {
                    if (item.MucHuong == quyenloi)
                    {
                        phantram = item.PhanTram;
                        break;
                    }
                }

                if (dungTuyen)
                {
                    if (tuyen == (byte)EnumTuyen.Xa
                        || (tuyen != (byte)EnumTuyen.Xa && tongChiPhi < luong * 15 / 100))
                    {
                        phantram = 100;
                    }
                    else
                    {
                        // Do nothing
                    }
                }
                else
                {
                    if (maNoiSinhSong == "K1" || maNoiSinhSong == "K2" || maNoiSinhSong == "K3")
                    {
                        if (tuyen == (byte)EnumTuyen.Huyen)
                        {
                            // Do nothing
                        }
                        else
                        {
                            if (hinhThuc == (byte)EnumHinhThucKham.NoiTru)
                            {
                                // Do nothing
                            }
                            else
                            {
                                phantram = 0;
                            }
                        }
                    }
                    else
                    {
                        if (hinhThuc == (byte)EnumHinhThucKham.NgoaiTru)
                        {
                            if (ngayThanhToan.CompareTo(new DateTime(2015, 1, 1)) >= 0
                                && ngayThanhToan.CompareTo(new DateTime(2016, 1, 1)) < 0)
                            {
                                switch (tuyen)
                                {
                                    case (byte)EnumTuyen.TW:
                                    case (byte)EnumTuyen.Tinh:
                                    case (byte)EnumTuyen.Xa:
                                        tile = 0;
                                        break;
                                    case (byte)EnumTuyen.Huyen:
                                        tile = 0.7;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (tuyen)
                                {
                                    case (byte)EnumTuyen.TW:
                                    case (byte)EnumTuyen.Tinh:
                                        tile = 0;
                                        break;
                                    case (byte)EnumTuyen.Huyen:
                                    case (byte)EnumTuyen.Xa:
                                        tile = 1;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        else
                        {
                            if (ngayThanhToan.CompareTo(new DateTime(2015, 1, 1)) >= 0
                                && ngayThanhToan.CompareTo(new DateTime(2016, 1, 1)) < 0)
                            {
                                switch (tuyen)
                                {
                                    case (byte)EnumTuyen.TW:
                                        tile = 0.4;
                                        break;
                                    case (byte)EnumTuyen.Tinh:
                                        tile = 0.6;
                                        break;
                                    case (byte)EnumTuyen.Huyen:
                                        tile = 0.7;
                                        break;
                                    case (byte)EnumTuyen.Xa:
                                        tile = 0;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else if (ngayThanhToan.CompareTo(new DateTime(2016, 1, 1)) >= 0
                                && ngayThanhToan.CompareTo(new DateTime(2021, 1, 1)) < 0)
                            {
                                switch (tuyen)
                                {
                                    case (byte)EnumTuyen.TW:
                                        tile = 0.4;
                                        break;
                                    case (byte)EnumTuyen.Tinh:
                                        tile = 0.6;
                                        break;
                                    case (byte)EnumTuyen.Huyen:
                                    case (byte)EnumTuyen.Xa:
                                        tile = 1;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (tuyen)
                                {
                                    case (byte)EnumTuyen.TW:
                                        tile = 0.4;
                                        break;
                                    case (byte)EnumTuyen.Tinh:
                                    case (byte)EnumTuyen.Huyen:
                                    case (byte)EnumTuyen.Xa:
                                        tile = 1;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
                return phantram * (decimal)tile;

            }
            catch
            {
                return 0;
            }
        }
        #endregion
    }
}
