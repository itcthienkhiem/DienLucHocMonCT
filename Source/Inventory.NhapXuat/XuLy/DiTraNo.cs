using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Inventory.NhapXuat.XuLy
{
  public  class DiTraNo : PhieuBase 
    {
      public override int Insert(int id)
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
                  return 0;
              for (int i = 0; i < entryPointCTPN.Count; i++)
              {
                  string mavattu = entryPointCTPN[i].Ma_vat_tu;
                  int idcl = (int)entryPointCTPN[i].Id_chat_luong;
                  string maphieu = entryPointCTPN[i].Ma_phieu_nhap;
                  decimal sl = (decimal)entryPointCTPN[i].So_luong_thuc_lanh;
                  DateTime ngay_xuat = (DateTime)pnk.Ngay_lap;
                    DateTime ngay_nhap_xuat = DateTime.Now;
                    string dien_giai = pnk.Ly_do;
                  var entryPoint = (from d in help.ent.Ton_kho

                                    where d.ID_kho == pnk.ID_kho && d.Ma_vat_tu == mavattu && d.Id_chat_luong == idcl
                                    select d).FirstOrDefault();
                  if (entryPoint == null || entryPoint.So_luong < sl)
                  {
                      return 0;
                  }
                  entryPoint.So_luong = entryPoint.So_luong - sl;
                  help.ent.Ton_kho.Attach(entryPoint);
                  help.ent.Entry(entryPoint).State = EntityState.Modified;
                  help.ent.SaveChanges();
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
                  cttk.SL_Xuat = sl;
                    cttk.Ngay_nhap_xuat = ngay_nhap_xuat;
                  cttk.ID_loai_phieu_nhap = pnk.ID_Loai_Phieu_Nhap;
                 
                  help.ent.Chi_tiet_the_kho.Add(cttk);
                  help.ent.SaveChanges();
                  pnk.Da_phan_kho = true;
                  help.ent.Phieu_Nhap_Kho.Attach(pnk);
                  help.ent.Entry(pnk).State = EntityState.Modified;
                  help.ent.SaveChanges();
              }
              dbcxtransaction.Commit();
          }
          return base.Insert(id);
      }
      public override int BoDuyet(int id)
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
                  return 0;
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
                      return 0;
                  }
                  entryPoint.So_luong = entryPoint.So_luong + sl;
                  help.ent.Ton_kho.Attach(entryPoint);
                  help.ent.Entry(entryPoint).State = EntityState.Modified;
                  help.ent.SaveChanges();

                  var entryPointCTTK = (from d in help.ent.Chi_tiet_the_kho
                                        join f in help.ent.The_kho on d.ID_The_Kho equals f.ID_The_Kho
                                        where d.Ma_phieu == pnk.Ma_phieu_nhap && f.Ma_vat_tu == mavattu && f.Id_chat_luong == idcl
                                        select d).FirstOrDefault();
                  if (entryPointCTTK == null)
                  {
                      dbcxtransaction.Rollback();
                      return 0;
                  }

                  help.ent.Chi_tiet_the_kho.Remove(entryPointCTTK);
                  help.ent.SaveChanges();

              }
              pnk.Da_phan_kho = false;
              help.ent.Phieu_Nhap_Kho.Attach(pnk);
              help.ent.Entry(pnk).State = EntityState.Modified;
              help.ent.SaveChanges();
             
              dbcxtransaction.Commit();
              return 1;
          }
      }
    }
}
