using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Inventory.BusinessClass
{
 public   class clsBusTraNo
    {
     public string Ten_kho;
     public int ID_kho;
     public int ID_kho_muon;
     public string Ten_kho_muon;
     public string Ten_Chat_luong;
     public int ID_chat_luong;
    // public string Ma_vat_tu;
     public double soluongtra;
     public double soluongmuon;
     public string Ma_vat_tu;
     public string Ten_vat_tu;
     public string Ma_phieu;
     public int idnvt;
     public clsBusTraNo(string mvt, string tvt, int idkho, int idkhomuon, string tenchatluong, int idcl, double soluongmuon,string maphieu,int idnvt)
     {
         this.idnvt = idnvt;
         this.Ma_vat_tu = mvt;
         this.Ten_vat_tu = tvt;
      //   this.Ten_kho = tenkho;
         this.ID_kho = idkho;
         this.ID_kho_muon = idkhomuon;
     //    this.Ten_kho_muon = tenkhomuon;
         this.Ten_Chat_luong = tenchatluong;
         this.ID_chat_luong = idcl;
         this.soluongmuon = soluongmuon;
         this.Ma_phieu = maphieu;
      //   this.soluongtra = slTra;
     //    this.soluongtra = sltra;
     }
     /// <summary>
     /// hàm này lưu trử thông tin trả nợ vật tư
     /// lấy lên số lượng vật tư nợ ở kho và cùng chất lượng
     /// </summary>
     /// <returns></returns>
     public  int Update()
     {
         try
         {
             DatabaseHelper help = new DatabaseHelper();
             help.ConnectDatabase();
             // xem số lượng vật tư trong kho có còn hay hok ?
             //nếu còn thì thực hiện trả nợ 

             using (var dbcxtransaction = help.ent.Database.BeginTransaction())
             {

                 //lấy số lượng vật tư trong kho mượn

                 var muon = (from d in help.ent.Ton_kho
                             where d.Ma_vat_tu == Ma_vat_tu && d.ID_kho == ID_kho && d.Id_chat_luong == ID_chat_luong
                             select d).First();
                 if (muon.So_luong < soluongtra)
                     return 0;
                 //trừ số lượng trong kho mượn
                 muon.So_luong = muon.So_luong - soluongtra;
                 //tiến hành cập nhật lại tồn kho mượn
                 help.ent.Ton_kho.Attach(muon);
                 help.ent.Entry(muon).State = EntityState.Modified;
                 help.ent.SaveChanges();
                 //lấy số lượng kho trả 
                 var dm = (from d in help.ent.Ton_kho
                           where d.Ma_vat_tu == Ma_vat_tu && d.ID_kho == ID_kho_muon && d.Id_chat_luong == ID_chat_luong
                           select d).First();
                 // cập nhật lại số lượng
                 // số lượng tồn kho 
                 double slKho = (double)dm.So_luong + soluongtra;
                 dm.So_luong = slKho;
                 help.ent.Ton_kho.Attach(dm);
                 help.ent.Entry(dm).State = EntityState.Modified;
                 help.ent.SaveChanges();
                 //cập nhật chi tiết tồn kho 
                 var t = new Chi_Tiet_Ton_Kho //Make sure you have a table called test in DB
                 {
                     ID_Ton_kho = dm.ID_ton_kho,
                     Ma_phieu = this.Ma_phieu,                   // ID = Guid.NewGuid(),
                     So_luong = this.soluongtra,
                     Ngay_thay_doi = DateTime.Now,
                     Tang_Giam = true,
                     Ly_do = "Trả vật tư từ kho mượn nợ",
                 };

                 help.ent.Chi_Tiet_Ton_Kho.Add(t);
                 help.ent.SaveChanges();


                 var nvt = (from d in help.ent.Kho_muon_vat_tu
                            where d.ID_kho_muon_vat_tu == idnvt
                            select d).First();
                 nvt.Da_tra = true;
                 help.ent.Kho_muon_vat_tu.Attach(nvt);
                 help.ent.Entry(nvt).State = EntityState.Modified;
                 help.ent.SaveChanges();
                 dbcxtransaction.Commit();
                 return 1;
                 //slKho +=soluongtra
                 ///  help.ent.Phieu_Nhap_Kho.Attach(entryPointPN[0]);
                 // help.ent.Entry(entryPointPN[0]).State = EntityState.Modified;

             }
         }
         catch (Exception ex)
         {
             return 0;
         }
     }
    }
}
