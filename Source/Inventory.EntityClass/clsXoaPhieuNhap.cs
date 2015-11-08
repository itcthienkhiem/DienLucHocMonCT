using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
    /// <summary>
    /// chỉ duoc xoa phieu trong cac truong hop sau :
    /// 1: xoa phieu trong ky co dinh
    /// 2: chi duoc xoa phieu trong truong hop chua xuat vat tu trong ngay hoac chua phat sinh chung tu xuat vat tu do 
    /// tìm kiem phieu can xoa xem da co chung tu xuat chua 
    /// //tim trong bang chi tiet phieu xuat 
    /// neu da xuat thi ko duoc xoa
    /// </summary>
    public class clsXoaPhieuNhap
    {
        public int XoaPhieu(Phieu_Nhap_Kho pnk)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {

                //lay danh sach phieu nhap
                //var dm = (from d in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
                //          join p in help.ent.Phieu_Nhap_Kho on d.Ma_phieu_nhap equals p.Ma_phieu_nhap
                //          join e in help.ent.Chi_Tiet_Phieu_Xuat_Tam on d.Ma_vat_tu equals e.Ma_vat_tu
                //          where d.Ma_phieu_nhap == pnk.Ma_phieu_nhap && d.Id_chat_luong == e.Id_chat_luong && e.ID_kho == pnk.ID_kho
                //          select new
                //          {
                //              mavattu = d.Ma_vat_tu,
                //              idcl = d.Id_chat_luong,

                //          }).ToList();
                //xoa chi tiet the kho 
                // xoa chi tiet ton kho , cap nhat lai so luong ton 

                //có phat sinh phieu xuat
                //if (dm == null || dm.Count == 0)
                {//kiem tra so luong ton trong kho > so luong xoa thi moi duoc xoa

                    var vt = (from c in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
                            
                              
                              join p in help.ent.Ton_kho on c.Ma_vat_tu equals p.Ma_vat_tu
                              where c.Id_chat_luong == p.Id_chat_luong && p.ID_kho == pnk.ID_kho && c.Ma_phieu_nhap == pnk.Ma_phieu_nhap
                              select new
                              {
                                  c.Ma_vat_tu,
                                  c.So_luong_thuc_lanh,
                                  c.Id_chat_luong,
                                  p.So_luong,

                              }).ToList();
                    for (int i = 0; i < vt.Count(); i++)
                    {
                        if (vt[i].So_luong_thuc_lanh > vt[i].So_luong)
                        {
                            return 0;
                        }

                    }
                    //cap nhat lai so luong ton kho 
                    { for (int i = 0; i < vt.Count(); i++){
                      var original = help.ent.Ton_kho.Find(vt[i].Ma_vat_tu,vt[i].Id_chat_luong, pnk.ID_kho);
                            help.ent.Ton_kho.Attach(original);
                            original.So_luong = original.So_luong - vt[i].So_luong ;
                            var entry = help.ent.Entry(original);
                            entry.Property(e => e.So_luong).IsModified = true;
                            help.ent.SaveChanges();
                    }}
                    // da ok chinh thuc cho xoa 

                    var vtgd = (from c in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
                                join p in help.ent.Vat_Tu_Goi_Dau_Ky on c.Ma_vat_tu equals p.Ma_vat_tu
                                where p.ID_chat_luong == c.Id_chat_luong && p.ID_kho == pnk.ID_kho&& c.Ma_phieu_nhap == pnk.Ma_phieu_nhap
                                select new
                                {
                                    c.Ma_vat_tu,
                                    c.Id_chat_luong,
                                    p.ID_kho,
                                    c.So_luong_thuc_lanh,
                                    p.So_Luong,
                                }).ToList();
                    if (vtgd.Count != 0)
                    {
                        for (int i = 0; i < vtgd.Count; i++)
                        {
                            if (vtgd[i].So_Luong < vtgd[i].So_luong_thuc_lanh)
                            {
                                return 0;

                            }
                        }
                        //xoa duoc goi dau, chi tiet goi dau 
                        //var filterCTGD = help.ent.Chi_Tiet_Goi_Dau.Where(o => o.ID_ma_phieu == pnk.ID_phieu_nhap);
                        //help.ent.Chi_Tiet_Goi_Dau.RemoveRange(filterCTGD);
                        //help.ent.SaveChanges();
                        // cap nhat lai so luong dau ky 
                        for (int i = 0; i < vtgd.Count; i++)
                        {
                            var original = help.ent.Vat_Tu_Goi_Dau_Ky.Find(vtgd[i].Ma_vat_tu, vtgd[i].Id_chat_luong, pnk.ID_kho);
                            help.ent.Vat_Tu_Goi_Dau_Ky.Attach(original);
                            original.So_Luong = original.So_Luong - vtgd[i].So_Luong;
                            var entry = help.ent.Entry(original);
                            entry.Property(e => e.So_Luong).IsModified = true;
                            help.ent.SaveChanges();


                        }

                        //var filter = help.ent.Chi_tiet_the_kho.Where(o => o.Ma_phieu == pnk.Ma_phieu_nhap);
                        //help.ent.Chi_tiet_the_kho.RemoveRange(filter);
                        //help.ent.SaveChanges();
                        //var filterCTTK = help.ent.Chi_Tiet_Ton_Kho.Where(o => o.Ma_phieu == pnk.Ma_phieu_nhap);
                        //help.ent.Chi_Tiet_Ton_Kho.RemoveRange(filterCTTK);
                        //help.ent.SaveChanges();
                        // neu phieu la goi dau thi xoa tiep goi dau va chi tiet goi dau 



                       
                    }
                    var filterCTTK = help.ent.Chi_tiet_the_kho.Where(o => o.Ma_phieu == pnk.Ma_phieu_nhap);
                    help.ent.Chi_tiet_the_kho.RemoveRange(filterCTTK);
                    help.ent.SaveChanges();
                    //xoa phieu can tru no 
                    var filterCTNN = help.ent.Can_tru_no_nhap_ngoai.Where(o => o.Ma_phieu_nhap == pnk.Ma_phieu_nhap);
                    help.ent.Can_tru_no_nhap_ngoai.RemoveRange(filterCTNN);
                    help.ent.SaveChanges();
                    //neu no la phieu no 
                    //thi xoa phieu no xong reset lai so luong trong phieu tra no 
                    var filterCTTN = help.ent.Can_tru_no_nhap_ngoai.Where(o => o.Ma_phieu_nhap_no == pnk.Ma_phieu_nhap_no);
                    help.ent.Can_tru_no_nhap_ngoai.RemoveRange(filterCTNN);
                    help.ent.SaveChanges();
                    

                }
                // chua co chung tu xuat
                //thuc hien thao tac xoa phieu 
                // xoa tim va xoa trong the kho co ma phieu nhap


            }
            return 1;
        }
    }
}
