using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Inventory.NhapXuat.XuLy
{
   public  class PhieuNhanVienMuaNgoai:PhieuBase
    {
       public override int Insert(int id)
       {

           try
           {
               DatabaseHelper help = new DatabaseHelper();
               help.ConnectDatabase();
               using (var dbcxtransaction = help.ent.Database.BeginTransaction())
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
                       return 1;
                   for (int i = 0; i < entryPointCTPN.Count; i++)
                   {
                       string mavattu = entryPointCTPN[i].Ma_vat_tu;
                       int idcl = (int)entryPointCTPN[i].Id_chat_luong;
                       string maphieu = entryPointCTPN[i].Ma_phieu_nhap;
                       decimal sl = (decimal)entryPointCTPN[i].So_luong_thuc_lanh;
                       DateTime ngay_xuat = (DateTime)pnk.Ngay_lap;
                       string dien_giai = pnk.Ly_do;
                       var entryPoint = (from d in help.ent.Ton_kho

                                         where d.ID_kho == pnk.ID_kho && d.Ma_vat_tu == mavattu && d.Id_chat_luong == idcl
                                         select d).FirstOrDefault();
                       if (entryPoint == null)
                       {
                           Ton_kho entTonKho = new Ton_kho();
                           entTonKho.ID_kho = pnk.ID_kho;
                           entTonKho.Ma_vat_tu = mavattu;
                           entTonKho.So_luong = sl;
                           entTonKho.Id_chat_luong = idcl;
                           help.ent.Ton_kho.Add(entTonKho);
                           help.ent.SaveChanges();
                       }
                       else
                       {
                           entryPoint.So_luong = entryPoint.So_luong + sl;
                           help.ent.Ton_kho.Attach(entryPoint);
                           help.ent.Entry(entryPoint).State = EntityState.Modified;
                           help.ent.SaveChanges();
                       }
                       var entryPointTK = (from d in help.ent.The_kho

                                           where d.Ma_vat_tu == mavattu && d.Id_chat_luong == idcl
                                           select d).FirstOrDefault();


                   }
                   pnk.Da_phan_kho = true;

                   help.ent.Phieu_Nhap_Kho.Attach(pnk);
                   help.ent.Entry(pnk).State = EntityState.Modified;
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
    }
}
