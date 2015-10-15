using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
    /// <summary>
    /// lớp này lưu trử các tính toán xữ lý phức tạp liên quan đến nhiều bảng
    /// </summary>
    public class clsXuLyDuLieuChung
    {
        /// <summary>
        /// hàm xữ lý thêm vật tư vào kho liên quan đến nhiều lớp, tính toán phức tạp
        /// </summary>
        /// <returns></returns>
        public int InsertTonKho(string mavt, int idkho, int soluong, string maphieu)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                try
                {
                    var entryPoint = (from d in help.ent.Ton_kho

                                      where d.ID_kho == idkho && d.Ma_vat_tu == mavt
                                      select d).ToList();
                    if (entryPoint.Count == 0)
                    {
                        //neu chưa có tiền hành lưu vật tư này vào kho với số lượng bằng số lượng nhập
                        Ton_kho entTonKho = new Ton_kho();
                        entTonKho.ID_kho = idkho;
                        entTonKho.Ma_vat_tu = mavt;
                        entTonKho.So_luong = soluong;
                        help.ent.Ton_kho.Add(entTonKho);
                        help.ent.SaveChanges();


                        //buoc 2: them 1 dong vao ban chi tiet ton kho voi ma, so luong, kho tuong tung
                        Chi_Tiet_Ton_Kho cttk = new Chi_Tiet_Ton_Kho();
                        cttk.ID_Ton_kho = entTonKho.ID_ton_kho;
                        cttk.Ma_phieu = maphieu;
                        cttk.So_luong = soluong;
                        cttk.Ngay_thay_doi = DateTime.Now;
                        cttk.Tang_Giam = true;//<-- set tang 
                        help.ent.Chi_Tiet_Ton_Kho.Add(cttk);
                        help.ent.SaveChanges();
                        //buoc 3 : sau khi them vao bang chi tiet ton kho thi cap nhat lai trang thai phieu nhap
                        //Chi_Tiet_Phieu_Nhap_Vat_Tu ctpn = new Chi_Tiet_Phieu_Nhap_Vat_Tu();
                        var entryPointCT = (from d in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu

                                            where d.Ma_vat_tu == mavt && d.Ma_phieu_nhap == maphieu
                                            select d).ToList();
                        foreach (var temp in entryPointCT)
                        {
                            temp.Da_duyet = true;
                            help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Attach(temp);
                            help.ent.Entry(temp).State = EntityState.Modified;
                        }
                        var entryPointPN = (from d in help.ent.Phieu_Nhap_Kho

                                            where d.Ma_phieu_nhap == maphieu && d.Da_phan_kho ==false
                                            select d).ToList();
                        foreach (var temp in entryPointPN)
                        {
                            temp.Da_phan_kho =true ;
                            help.ent.Phieu_Nhap_Kho.Attach(temp);
                            help.ent.Entry(temp).State = EntityState.Modified;
                        }
                        
                        help.ent.SaveChanges();
                        dbcxtransaction.Commit();//hoan thanh thao tac
                        return 1;
                    }
                    else
                    {
                        //neu kho đó đã có vật tư thì tiến hành cộng vật tư hiện tại vào kho
                    
                       // entTonKho.So_luong = soluong;
                        //lay 1 dong ra 
                      var   stud =  help.ent.Ton_kho.Where(s => s.ID_kho == idkho &&s.Ma_vat_tu ==mavt).FirstOrDefault<Ton_kho>();

                      stud.So_luong = stud.So_luong + soluong;

                      help.ent.Ton_kho.Attach(stud);
                      help.ent.Entry(stud).State = EntityState.Modified;

                        //help.ent.Ton_kho.Attach(entTonKho);
                        //help.ent.Entry(entTonKho).State = EntityState.Modified;
                        help.ent.SaveChanges();

                        //buoc 2: them 1 dong vao ban chi tiet ton kho voi ma, so luong, kho tuong tung
                        Chi_Tiet_Ton_Kho cttk = new Chi_Tiet_Ton_Kho();
                        cttk.ID_Ton_kho = stud.ID_ton_kho;
                        cttk.Ma_phieu = maphieu;
                        cttk.So_luong = stud.So_luong;
                        cttk.Ngay_thay_doi = DateTime.Now;
                        cttk.Tang_Giam = true;//<-- set tang 
                        help.ent.Chi_Tiet_Ton_Kho.Add(cttk);
                        help.ent.SaveChanges();
                        //buoc 3 : sau khi them vao bang chi tiet ton kho thi cap nhat lai trang thai phieu nhap
                        Chi_Tiet_Phieu_Nhap_Vat_Tu ctpn = new Chi_Tiet_Phieu_Nhap_Vat_Tu();
                        var entryPointCT = (from d in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu

                                            where d.Ma_vat_tu == mavt && d.Ma_phieu_nhap == maphieu
                                            select d).ToList();
                        foreach (var temp in entryPointCT)
                        {
                            temp.Da_duyet = true;
                            
                            help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Attach(temp);
                            help.ent.Entry(temp).State = EntityState.Modified;
                        }
                        help.ent.SaveChanges();
                        dbcxtransaction.Commit();//hoan thanh thao tac
                        return 1;
                    }
                }
                catch (Exception ex)
                {
                    dbcxtransaction.Rollback();
                    return 0;

                }
            }
            return 1;
            //return 0;

        }
        /// <summary>
        /// hàm này lưu trử thao tác xóa vật tư có mã phiếu tương ứng
        /// </summary>
        /// <param name="maphieu"></param>
        /// <returns></returns>
        public static int DeletePhieuNhap(string maphieu)
        { 
              DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            { 
                //xoa tat ca cac chi tiet trong bang chi tiet phieu nhap 
                // xoa phieu nhap
                // Chi_Tiet_Phieu_Nhap_Vat_Tu ctpn = new Chi_Tiet_Phieu_Nhap_Vat_Tu();
                try
                {
                    var entryPointCT = (from d in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu

                                        where d.Ma_phieu_nhap == maphieu
                                        select d).ToList();
                    foreach (var temp in entryPointCT)
                    {
                        help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Attach(temp);
                        help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Remove(temp);
                    }
                    help.ent.SaveChanges();
                    //neu xoa thanh cong thi tiep tuc xoa du lieu trong bang phieu nhap
                    //tim ma phieu 
                    var entryPointPN = (from d in help.ent.Phieu_Nhap_Kho

                                        where d.Ma_phieu_nhap == maphieu
                                        select d).ToList();
                    foreach (var temp in entryPointPN)
                    {
                        help.ent.Phieu_Nhap_Kho.Attach(temp);
                        help.ent.Phieu_Nhap_Kho.Remove(temp);
                    }
                    //neu ko co loi gi xay ra thi commit 
                    help.ent.SaveChanges();
                    dbcxtransaction.Commit();

                    return 1;
                }
                catch (Exception eX)
                {
                    dbcxtransaction.Rollback();
                    return 0;
                }
            }
            return 0;
        }
    }
}
