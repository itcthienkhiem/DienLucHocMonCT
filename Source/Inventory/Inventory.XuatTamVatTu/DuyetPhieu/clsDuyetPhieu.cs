using Inventory.EntityClass;
using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Inventory.XuatTamVatTu.DuyetPhieu
{

    


    public class clsDuyetPhieu
    {


        public int BoDuyet(int id_phieu_xuat)
        {
            //khoi tao lai so luong trong kho 
            // xoa cac du lieu lien quan
            try
            {
                DatabaseHelper help = new DatabaseHelper();
                help.ConnectDatabase();
                using (var dbcxtransaction = help.ent.Database.BeginTransaction())
                {
                    var pxk = (from d in help.ent.Phieu_Xuat_Tam_Vat_Tu
                               where d.ID_phieu_xuat_tam == id_phieu_xuat
                               select d).FirstOrDefault();
                    if (pxk == null)
                        return 0;

                    var entryPointCTPN = (from d in help.ent.Chi_Tiet_Phieu_Xuat_Tam
                                          where d.Ma_phieu_xuat_tam == pxk.Ma_phieu_xuat_tam
                                          select d).ToList();

                    if (entryPointCTPN.Count == 0)
                        return 1;
                    for (int i = 0; i < entryPointCTPN.Count; i++)
                    {
                        string mavattu = entryPointCTPN[i].Ma_vat_tu;
                        int idcl = (int)entryPointCTPN[i].Id_chat_luong;
                        int idkho = (int)entryPointCTPN[i].ID_kho;
                        var entryPoint = (from d in help.ent.Ton_kho

                                          where d.ID_kho == pxk.ID_kho && d.Ma_vat_tu == mavattu && d.Id_chat_luong == idcl
                                          select d).FirstOrDefault();
                        if (entryPoint == null)
                            return 0;

                        if (entryPoint.So_luong < entryPointCTPN[i].So_luong_thuc_xuat)
                            return 0;

                        if (entryPointCTPN[i].ID_kho != pxk.ID_kho)
                        {
                            entryPoint.So_luong = entryPoint.So_luong + entryPointCTPN[i].So_luong_thuc_xuat - entryPointCTPN[i].So_luong_hoan_nhap;
                            if (entryPoint.So_luong < entryPointCTPN[i].So_luong_thuc_xuat)
                                return 0;
                            entryPoint.So_luong = entryPoint.So_luong - entryPointCTPN[i].So_luong_thuc_xuat;

                            var entryPointKM = (from d in help.ent.Ton_kho

                                                where d.ID_kho == idkho && d.Ma_vat_tu == mavattu && d.Id_chat_luong == idcl
                                                select d).FirstOrDefault();
                            if (entryPointKM == null)
                            {
                                return 0;
                            }
                            entryPointKM.So_luong = entryPointKM.So_luong + entryPointCTPN[i].So_luong_thuc_xuat;
                            help.ent.Ton_kho.Attach(entryPointKM);
                            help.ent.Entry(entryPointKM).State = EntityState.Modified;
                            help.ent.SaveChanges();
                        }
                        else
                            entryPoint.So_luong = entryPoint.So_luong + entryPointCTPN[i].So_luong_thuc_xuat - entryPointCTPN[i].So_luong_hoan_nhap;
                        help.ent.Ton_kho.Attach(entryPoint);
                        help.ent.Entry(entryPoint).State = EntityState.Modified;
                        help.ent.SaveChanges();

                        var CTTK = (from ct in help.ent.Chi_tiet_the_kho
                                    join tk in help.ent.The_kho on ct.ID_The_Kho equals tk.ID_The_Kho
                                    where ct.Ma_phieu == pxk.Ma_phieu_xuat_tam && tk.Ma_vat_tu == mavattu && tk.Id_chat_luong == idcl
                                    select ct).FirstOrDefault();

                        help.ent.Chi_tiet_the_kho.Attach(CTTK);
                        help.ent.Chi_tiet_the_kho.Remove(CTTK);
                        help.ent.SaveChanges();
                        var NVT = (from d in help.ent.No_vat_tu
                                   where d.Ma_phieu_xuat_tam == pxk.Ma_phieu_xuat_tam && d.Ma_vat_tu == mavattu && d.Id_chat_luong == idcl
                                   select d).FirstOrDefault();
                        if (NVT != null)
                        {
                            help.ent.No_vat_tu.Attach(NVT);
                            help.ent.No_vat_tu.Remove(NVT);
                            help.ent.SaveChanges();
                        }
                        // trả lại số lượng đã mượn vật tư 
                        var KMVT = (from d in help.ent.Kho_muon_vat_tu
                                    where d.Ma_phieu_xuat_tam == pxk.Ma_phieu_xuat_tam && d.Ma_vat_tu == mavattu && d.Id_chat_luong == idcl
                                    select d).FirstOrDefault();
                        if (KMVT != null)
                        {
                            help.ent.Kho_muon_vat_tu.Attach(KMVT);
                            help.ent.Kho_muon_vat_tu.Remove(KMVT);
                            int temp = help.ent.SaveChanges();
                        }
                    }
                    pxk.isGiuLai = false;
                    pxk.isHoanNhap = false;
                    pxk.Da_duyet = false;
                    help.ent.Phieu_Xuat_Tam_Vat_Tu.Attach(pxk);
                    help.ent.Entry(pxk).State = EntityState.Modified;
                    help.ent.SaveChanges();
                    dbcxtransaction.Commit();
                    return 1;



                }
            }
            catch (Exception ex)
            {
                return 0;
            }
                

        }

        public int Insert(int id_phieu_xuat)
        {
            try
            {
                DatabaseHelper help = new DatabaseHelper();
                help.ConnectDatabase();
                using (var dbcxtransaction = help.ent.Database.BeginTransaction())
                {

                    var pxk = (from d in help.ent.Phieu_Xuat_Tam_Vat_Tu
                               where d.ID_phieu_xuat_tam == id_phieu_xuat
                               select d).FirstOrDefault();
                    if (pxk == null)
                        return 0;

                    var entryPointCTPN = (from d in help.ent.Chi_Tiet_Phieu_Xuat_Tam
                                          where d.Ma_phieu_xuat_tam == pxk.Ma_phieu_xuat_tam
                                          select d).ToList();
                    if (entryPointCTPN.Count == 0)
                        return 1;
                    

                    for (int i = 0; i < entryPointCTPN.Count; i++)
                    {
                        string mavattu = entryPointCTPN[i].Ma_vat_tu;
                        int idcl = (int)entryPointCTPN[i].Id_chat_luong;
                        string maphieu = entryPointCTPN[i].Ma_phieu_xuat_tam;
                        decimal sl = (decimal)entryPointCTPN[i].So_luong_thuc_xuat;
                        DateTime ngay_xuat = (DateTime)pxk.Ngay_xuat;
                        string dien_giai = pxk.Ly_do;
                        int id_kho_chinh = (int)pxk.ID_kho;
                        int id_kho_muon = (int)entryPointCTPN[i].ID_kho;
                        var entryPoint = (from d in help.ent.Ton_kho

                                          where d.ID_kho == pxk.ID_kho && d.Ma_vat_tu == mavattu && d.Id_chat_luong == idcl
                                          select d).FirstOrDefault();
                        var entryPointTK = (from d in help.ent.The_kho

                                            where d.Ma_vat_tu == mavattu && d.Id_chat_luong == idcl
                                            select d).FirstOrDefault();
                        if (id_kho_chinh != id_kho_muon)
                        {
                            Kho_muon_vat_tu khomuon = new Kho_muon_vat_tu();
                            khomuon.ID_Kho = id_kho_chinh;
                            khomuon.ID_Kho_muon = id_kho_muon;
                            khomuon.Ma_vat_tu = mavattu;
                            khomuon.Id_chat_luong = idcl;
                            khomuon.So_luong = sl;
                            khomuon.Ma_phieu_xuat_tam = maphieu;
                            khomuon.Da_tra = false;
                            help.ent.Kho_muon_vat_tu.Add(khomuon);
                            help.ent.SaveChanges();
                            entryPoint.So_luong = entryPoint.So_luong + sl;
                            help.ent.Ton_kho.Attach(entryPoint);
                            help.ent.Entry(entryPoint).State = EntityState.Modified;
                            help.ent.SaveChanges();
                            Chi_tiet_the_kho cttk = new Chi_tiet_the_kho();
                            cttk.ID_The_Kho = entryPointTK.ID_The_Kho;
                            cttk.Ma_phieu = maphieu;
                            cttk.Ngay_xuat_chung_tu = ngay_xuat;
                            cttk.Dien_giai = "Mượn vật tư kho khác ";
                            cttk.SL_Nhap = sl;

                            cttk.ID_loai_phieu_nhap = 0;

                            help.ent.Chi_tiet_the_kho.Add(cttk);
                            help.ent.SaveChanges();
                        }

                        if (entryPoint == null)
                        {
                            return 0;
                        }
                        else
                        {
                            entryPoint.So_luong = entryPoint.So_luong - sl;
                            help.ent.Ton_kho.Attach(entryPoint);
                            help.ent.Entry(entryPoint).State = EntityState.Modified;
                            help.ent.SaveChanges();
                        }


                        if (entryPointTK == null)
                        {
                            return 0;

                        }
                        Chi_tiet_the_kho ChitietTK = new Chi_tiet_the_kho();
                        ChitietTK.ID_The_Kho = entryPointTK.ID_The_Kho;
                        ChitietTK.Ma_phieu = maphieu;
                        ChitietTK.Ngay_xuat_chung_tu = ngay_xuat;
                        ChitietTK.Dien_giai = dien_giai;
                        ChitietTK.SL_Xuat = sl;
                        ChitietTK.ID_loai_phieu_nhap = 0;
                        help.ent.Chi_tiet_the_kho.Add(ChitietTK);
                        help.ent.SaveChanges();
                    }
                    pxk.Da_duyet = true;

                    help.ent.Phieu_Xuat_Tam_Vat_Tu.Attach(pxk);
                    help.ent.Entry(pxk).State = EntityState.Modified;
                    help.ent.SaveChanges();
                    dbcxtransaction.Commit();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int XuLyGiuLai(string mp)
        {
            try
            {
                DatabaseHelper help = new DatabaseHelper();
                help.ConnectDatabase();
                using (var dbcxtransaction = help.ent.Database.BeginTransaction())
                {

                    var pxk = (from d in help.ent.Phieu_Xuat_Tam_Vat_Tu
                               where d.Ma_phieu_xuat_tam == mp
                               select d).FirstOrDefault();
                    if (pxk == null)
                        return 0;

                    var entryPointCTPN = (from d in help.ent.Chi_Tiet_Phieu_Xuat_Tam
                                          where d.Ma_phieu_xuat_tam == pxk.Ma_phieu_xuat_tam
                                          select d).ToList();
                    if (entryPointCTPN.Count == 0)
                        return 1;
                    for (int i = 0; i < entryPointCTPN.Count; i++)
                    {
                        string mavattu = entryPointCTPN[i].Ma_vat_tu;
                        int idcl = (int)entryPointCTPN[i].Id_chat_luong;
                        string maphieu = entryPointCTPN[i].Ma_phieu_xuat_tam;
                        decimal sl = (decimal)entryPointCTPN[i].So_luong_giu_lai;
                        int id_nhan_vien = (int)pxk.ID_nhan_vien;
                        DateTime ngay_xuat = (DateTime)pxk.Ngay_xuat;
                        string dien_giai = pxk.Ly_do;
                        var No_vat_tu = (from d in help.ent.No_vat_tu
                                         where d.Ma_phieu_xuat_tam == pxk.Ma_phieu_xuat_tam
                                         && d.Ma_vat_tu == mavattu && d.Id_chat_luong == idcl
                                         select d).FirstOrDefault();

                        if (No_vat_tu == null)
                        {
                            No_vat_tu novattu = new No_vat_tu();
                            novattu.ID_nhan_vien = id_nhan_vien;
                            novattu.Ma_phieu_xuat_tam = maphieu;
                            novattu.Ma_vat_tu = mavattu;
                            novattu.Id_chat_luong = idcl;
                            novattu.So_luong_giu_lai = sl;
                            novattu.Da_tra = false;

                            help.ent.No_vat_tu.Add(novattu); help.ent.SaveChanges();
                        }
                        else
                        {
                            No_vat_tu.So_luong_giu_lai = sl;
                            help.ent.No_vat_tu.Attach(No_vat_tu);
                            help.ent.Entry(No_vat_tu).State = EntityState.Modified;
                            help.ent.SaveChanges();

                        }


                    }
                    dbcxtransaction.Commit();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int XuLyGiuLai(DatabaseHelper help, string mp)
        {
            try
            {

                {

                    var pxk = (from d in help.ent.Phieu_Xuat_Tam_Vat_Tu
                               where d.Ma_phieu_xuat_tam.Equals(mp)
                               select d).FirstOrDefault();
                    if (pxk == null)
                        return 0;

                    var entryPointCTPN = (from d in help.ent.Chi_Tiet_Phieu_Xuat_Tam
                                          where d.Ma_phieu_xuat_tam == pxk.Ma_phieu_xuat_tam
                                          select d).ToList();
                    if (entryPointCTPN.Count == 0)
                        return 1;
                    for (int i = 0; i < entryPointCTPN.Count; i++)
                    {
                        string mavattu = entryPointCTPN[i].Ma_vat_tu;
                        int idcl = (int)entryPointCTPN[i].Id_chat_luong;
                        string maphieu = entryPointCTPN[i].Ma_phieu_xuat_tam;
                        decimal sl = (decimal)entryPointCTPN[i].So_luong_giu_lai;
                        int id_nhan_vien = (int)pxk.ID_nhan_vien;
                        DateTime ngay_xuat = (DateTime)pxk.Ngay_xuat;
                        string dien_giai = pxk.Ly_do;
                        var NVT = (from d in help.ent.No_vat_tu
                                   where d.Ma_phieu_xuat_tam == pxk.Ma_phieu_xuat_tam
                                   && d.Ma_vat_tu == mavattu && d.Id_chat_luong == idcl
                                   select d).FirstOrDefault();

                        if (NVT == null)
                        {
                            No_vat_tu novattu = new No_vat_tu();
                            novattu.ID_nhan_vien = id_nhan_vien;
                            novattu.Ma_phieu_xuat_tam = maphieu;
                            novattu.Ma_vat_tu = mavattu;
                            novattu.Id_chat_luong = idcl;
                            novattu.So_luong_giu_lai = sl;
                            novattu.Da_tra = false;

                            help.ent.No_vat_tu.Add(novattu);
                            help.ent.SaveChanges();
                        }
                        else
                        {
                            NVT.So_luong_giu_lai = sl;
                            help.ent.No_vat_tu.Attach(NVT);
                            help.ent.Entry(NVT).State = EntityState.Modified;
                            help.ent.SaveChanges();

                        }


                    }
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


   
        public int XyLyHoanNhap(DatabaseHelper help, string mp)
        {
            try
            {
                var pxk = (from d in help.ent.Phieu_Xuat_Tam_Vat_Tu
                           where d.Ma_phieu_xuat_tam == mp
                           select d).FirstOrDefault();
                if (pxk == null)
                    return 0;

                var entryPointCTPN = (from d in help.ent.Chi_Tiet_Phieu_Xuat_Tam
                                      where d.Ma_phieu_xuat_tam == pxk.Ma_phieu_xuat_tam
                                      select d).ToList();
                if (entryPointCTPN.Count == 0)
                    return 1;
                  
                for (int i = 0; i < entryPointCTPN.Count; i++)
                {
                    string mavattu = entryPointCTPN[i].Ma_vat_tu;
                    int idcl = (int)entryPointCTPN[i].Id_chat_luong;
                    string maphieu = entryPointCTPN[i].Ma_phieu_xuat_tam;
                    decimal sl = (decimal)entryPointCTPN[i].So_luong_thuc_xuat;
                    DateTime ngay_xuat = (DateTime)pxk.Ngay_xuat;
                    string dien_giai = pxk.Ly_do;
                  
                        var entryPoint = (from d in help.ent.Ton_kho

                                          where d.ID_kho == pxk.ID_kho && d.Ma_vat_tu == mavattu && d.Id_chat_luong == idcl
                                          select d).FirstOrDefault();

                        if (entryPoint == null)
                        {
                            return 0;
                        }
                        else
                        {

                            {
                                entryPoint.So_luong = entryPoint.So_luong + sl;
                                help.ent.Ton_kho.Attach(entryPoint);
                                help.ent.Entry(entryPoint).State = EntityState.Modified;
                                help.ent.SaveChanges();
                            }
                        }
                        var entryPointTK = (from d in help.ent.The_kho

                                            where d.Ma_vat_tu == mavattu && d.Id_chat_luong == idcl
                                            select d).FirstOrDefault();


                        if (entryPointTK == null)
                        {
                            return 0;

                        }
                        Chi_tiet_the_kho cttk = new Chi_tiet_the_kho();
                        cttk.ID_The_Kho = entryPointTK.ID_The_Kho;
                        cttk.Ma_phieu = maphieu;
                        cttk.Ngay_xuat_chung_tu = ngay_xuat;
                        cttk.Dien_giai = dien_giai;
                        cttk.SL_Nhap = sl;

                        cttk.ID_loai_phieu_nhap = 0;

                        help.ent.Chi_tiet_the_kho.Add(cttk);
                        help.ent.SaveChanges();
                }
                pxk.Da_duyet = true;
                pxk.isHoanNhap = true;
                help.ent.Phieu_Xuat_Tam_Vat_Tu.Attach(pxk);
                help.ent.Entry(pxk).State = EntityState.Modified;
                help.ent.SaveChanges();


                return 1;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
//if (pxk.isHoanNhap == true)
//                    {
                   
//                        var entryPointTK = (from d in help.ent.The_kho
//                                            join e in help.ent.Chi_tiet_the_kho  on d.ID_The_Kho equals  e.ID_The_Kho
//                                            where e.Ma_phieu== mp 
//                                            select new {
//                                            d.Ma_vat_tu ,
//                                            d.Id_chat_luong,
//                                            e.SL_Nhap,
//                                            }).ToList();

//                        for (int i = 0; i < entryPointTK.Count; i++)
//                        {
//                            string ma_vat_tu = entryPointTK[i].Ma_vat_tu;
//                            decimal slvt =(decimal) entryPointTK[i].SL_Nhap;
//                            int idcl = (int)entryPointTK[i].Id_chat_luong;

//                            var entryPoint = (from d in help.ent.Ton_kho

//                                              where d.ID_kho == pxk.ID_kho && d.Ma_vat_tu == ma_vat_tu && d.Id_chat_luong == idcl
//                                              select d).FirstOrDefault();
//                            if (entryPoint == null)
//                                return 0;
//                            entryPoint.So_luong = entryPoint.So_luong - slvt;
//                            help.ent.Ton_kho.Attach(entryPoint);
//                            help.ent.Entry(entryPoint).State = EntityState.Modified;
//                            help.ent.SaveChanges();
                            

//                        }
//                  }