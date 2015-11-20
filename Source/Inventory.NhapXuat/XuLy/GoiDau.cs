using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Inventory.NhapXuat.XuLy
{
    public class GoiDau : PhieuBase
    {
        public override int Insert(int id)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();

            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {

                PhieuNhap pn = new PhieuNhap();
                if (pn.Insert(id, help) == 1)
                {

                    {

                        var pnk = (from d in help.ent.Phieu_Nhap_Kho
                                   where d.ID_phieu_nhap == id
                                   select d).FirstOrDefault();
                        if (pnk == null)
                            return 0;

                        var entryPointCTPN = (from d in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
                                              where d.Ma_phieu_nhap == pnk.Ma_phieu_nhap
                                              select d).ToList();
                        if (entryPointCTPN.Count == 0)
                            return 0;
                        for (int i = 0; i < entryPointCTPN.Count; i++)
                        {
                            string mavattu = entryPointCTPN[i].Ma_vat_tu;
                            int idcl = (int)entryPointCTPN[i].Id_chat_luong;
                            string maphieu = entryPointCTPN[i].Ma_phieu_nhap;
                            decimal sl = (decimal)entryPointCTPN[i].So_luong_thuc_lanh;
                            DateTime ngay_xuat = (DateTime)pnk.Ngay_lap;
                            string dien_giai = pnk.Ly_do;
                            var entryPointGD = (from d in help.ent.Vat_Tu_Goi_Dau_Ky

                                                where d.ID_kho == pnk.ID_kho && d.Ma_vat_tu == mavattu && d.ID_chat_luong == idcl
                                                select d).FirstOrDefault();
                            if (entryPointGD == null)
                            {
                                Vat_Tu_Goi_Dau_Ky GD = new Vat_Tu_Goi_Dau_Ky();
                                GD.ID_chat_luong = idcl;
                                GD.ID_kho = pnk.ID_kho;
                                GD.Ma_vat_tu = mavattu;
                                GD.So_Luong = sl;
                                help.ent.Vat_Tu_Goi_Dau_Ky.Add(GD);
                                help.ent.SaveChanges();
                            }
                            else
                            {
                                entryPointGD.So_Luong = entryPointGD.So_Luong + sl;
                                help.ent.Vat_Tu_Goi_Dau_Ky.Attach(entryPointGD);
                                help.ent.Entry(entryPointGD).State = EntityState.Modified;
                                help.ent.SaveChanges();
                            }
                        }
                    }
                }
                dbcxtransaction.Commit();
                return 1;
            }
            return 0;
        }
        public override int BoDuyet(int id)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();

            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                PhieuNhap pn = new PhieuNhap();
                if (pn.BoDuyet(id,help) == 1)
                {

                    {

                        var pnk = (from d in help.ent.Phieu_Nhap_Kho
                                   where d.ID_phieu_nhap == id
                                   select d).FirstOrDefault();
                        if (pnk == null)
                            return 0;

                        var entryPointCTPN = (from d in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
                                              where d.Ma_phieu_nhap == pnk.Ma_phieu_nhap
                                              select d).ToList();
                        if (entryPointCTPN.Count == 0)
                            return 0;
                        for (int i = 0; i < entryPointCTPN.Count; i++)
                        {
                            string mavattu = entryPointCTPN[i].Ma_vat_tu;
                            int idcl = (int)entryPointCTPN[i].Id_chat_luong;
                            string maphieu = entryPointCTPN[i].Ma_phieu_nhap;
                            decimal sl = (decimal)entryPointCTPN[i].So_luong_thuc_lanh;
                            DateTime ngay_xuat = (DateTime)pnk.Ngay_lap;
                            string dien_giai = pnk.Ly_do;
                            var entryPointGD = (from d in help.ent.Vat_Tu_Goi_Dau_Ky

                                                where d.ID_kho == pnk.ID_kho && d.Ma_vat_tu == mavattu && d.ID_chat_luong == idcl
                                                select d).FirstOrDefault();
                            if (entryPointGD == null || entryPointGD.So_Luong < sl)
                            {
                                return 0;
                            }
                            entryPointGD.So_Luong = entryPointGD.So_Luong - sl;
                            help.ent.Vat_Tu_Goi_Dau_Ky.Attach(entryPointGD);
                            help.ent.Entry(entryPointGD).State = EntityState.Modified;
                            help.ent.SaveChanges();

                        }

                        dbcxtransaction.Commit();
                        return 1;
                    }
                }
            }
            return base.BoDuyet(id);
        }
    }
}
