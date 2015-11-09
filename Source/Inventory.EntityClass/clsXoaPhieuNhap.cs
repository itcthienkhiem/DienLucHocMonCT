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
        /// <summary>
        /// hàm này thực hiện xóa các phiếu nhập, tờ trình, gối đầu
        /// </summary>
        /// <param name="pnk"></param>
        /// <returns></returns>
        public int XoaPhieu(string maphieu)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var query = help.ent.Phieu_Nhap_Kho.Where(o => o.Ma_phieu_nhap == maphieu);
                Phieu_Nhap_Kho pnk = query.FirstOrDefault();
                //lay danh sach phieu nhap
                //xoa chi tiet the kho 
                // xoa chi tiet ton kho , cap nhat lai so luong ton 
                //có phat sinh phieu xuat
                {//kiem tra so luong ton trong kho > so luong xoa thi moi duoc xoa
                    //neu phieu nay da can tru no thi ko cho xoa 
                    var filterCTTN = help.ent.Can_tru_no_nhap_ngoai.Where(o => o.Ma_phieu_nhap_no == pnk.Ma_phieu_nhap );// neu la phieu can tru no 
                    if (filterCTTN.Count() != 0)//neu la phieu da duoc tra no thi ko dc xoa
                        return 0;
                    var filterCTN = help.ent.Can_tru_no_nhap_ngoai.Where(o => o.Ma_phieu_nhap == pnk.Ma_phieu_nhap );// neu la phieu can tru no 
                    if (filterCTTN.Count() != 0)//neu la phieu da duoc tra no thi ko dc xoa
                        return 0;

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
                    {
                        for (int i = 0; i < vt.Count(); i++)
                        {
                            string mvt = vt[i].Ma_vat_tu;
                            int id_cl = (int)vt[i].Id_chat_luong;
                            int id_kho = (int)pnk.ID_kho;
                            var original = (from o in help.ent.Ton_kho
                                            where o.Ma_vat_tu == mvt
                                            && o.Id_chat_luong == id_cl
                                            && o.ID_kho == id_kho
                                            select o
                                                ).FirstOrDefault();
                            help.ent.Ton_kho.Attach(original);
                            original.So_luong = original.So_luong - vt[i].So_luong_thuc_lanh;
                            var entry = help.ent.Entry(original);
                            entry.Property(e => e.So_luong).IsModified = true;
                            help.ent.SaveChanges();
                        }
                    }
                    // da ok chinh thuc cho xoa 

                    var vtgd = (from c in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
                                join p in help.ent.Vat_Tu_Goi_Dau_Ky on c.Ma_vat_tu equals p.Ma_vat_tu

                                where p.ID_chat_luong == c.Id_chat_luong && p.ID_kho == pnk.ID_kho && c.Ma_phieu_nhap == pnk.Ma_phieu_nhap && pnk.isGoiDau == true
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
                        // cap nhat lai so luong dau ky 
                        for (int i = 0; i < vtgd.Count; i++)
                        {
                            string mvt = vt[i].Ma_vat_tu;
                            int id_cl = (int)vt[i].Id_chat_luong;
                            int id_kho = (int)pnk.ID_kho;
                            var original = help.ent.Vat_Tu_Goi_Dau_Ky.Where(o => o.Ma_vat_tu == mvt && o.ID_chat_luong == id_cl && o.ID_kho == id_kho && pnk .isGoiDau == true).FirstOrDefault();  //o =>o.  vt[i].Ma_vat_tu, vt[i].Id_chat_luong, pnk.ID_kho);
                            help.ent.Vat_Tu_Goi_Dau_Ky.Attach(original);
                            original.So_Luong = original.So_Luong - vtgd[i].So_Luong;
                            var entry = help.ent.Entry(original);
                            entry.Property(e => e.So_Luong).IsModified = true;
                            help.ent.SaveChanges();


                        }
                    }
                    var filterCTTK = help.ent.Chi_tiet_the_kho.Where(o => o.Ma_phieu == pnk.Ma_phieu_nhap);
                    help.ent.Chi_tiet_the_kho.RemoveRange(filterCTTK);
                    help.ent.SaveChanges();
                    //xoa phieu can tru no 
                    //var filterCTNN = help.ent.Can_tru_no_nhap_ngoai.Where(o => o.Ma_phieu_nhap == pnk.Ma_phieu_nhap && pnk.isCanTru == true);
                    //help.ent.Can_tru_no_nhap_ngoai.RemoveRange(filterCTNN);
                    //help.ent.SaveChanges();
                    //neu no la phieu no 
                    //thi xoa phieu no xong reset lai so luong trong phieu tra no 
                  
                    //van de phat sinh khi xoa phieu no 
                    //reset lai so luong phieu nhap va tien hanh xac nhan lai 
                    //thuc hien tra lai so luong da can tru, so luong se duoc chuyen ve cho 2 phieu kia trong thẻ kho
                    var filterCTPN = help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Where(o => o.Ma_phieu_nhap == pnk.Ma_phieu_nhap);
                    help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.RemoveRange(filterCTPN);
                    help.ent.SaveChanges();
                    //help.ent.Phieu_Nhap_Kho.Attach(pnk);
                    //pnk.isDelete = true;
                    //var entryPNK = help.ent.Entry(pnk);
                    //entryPNK.Property(e => e.isDelete).IsModified = true;
                    //help.ent.SaveChanges();

                    help.ent.Phieu_Nhap_Kho.RemoveRange(query);
                    help.ent.SaveChanges();
                    //thuc hien dieu chinh so lieu trong bang chi tiet ton kho va chi tiet the kho, chi tiet goi dau 
                    
                   

                    dbcxtransaction.Commit();
                }
                // chua co chung tu xuat
                //thuc hien thao tac xoa phieu 
                // xoa tim va xoa trong the kho co ma phieu nhap


            }
            return 1;
        }

        public int XoaPhieuChoMuonNo(string maphieu)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var query = help.ent.Phieu_Nhap_Kho.Where(o => o.Ma_phieu_nhap == maphieu);
                Phieu_Nhap_Kho pnk = query.FirstOrDefault();
                //lay danh sach phieu nhap
                //xoa chi tiet the kho 
                // xoa chi tiet ton kho , cap nhat lai so luong ton 
                //có phat sinh phieu xuat
                {//kiem tra so luong ton trong kho > so luong xoa thi moi duoc xoa
                    //neu phieu nay da can tru no thi ko cho xoa 
                    var filterCTTN = help.ent.Can_tru_no_nhap_ngoai.Where(o => o.Ma_phieu_nhap_no == pnk.Ma_phieu_nhap);// neu la phieu can tru no 
                    if (filterCTTN.Count() != 0)//neu la phieu da duoc tra no thi ko dc xoa
                        return 0;
                    var filterCTN = help.ent.Can_tru_no_nhap_ngoai.Where(o => o.Ma_phieu_nhap == pnk.Ma_phieu_nhap);// neu la phieu can tru no 
                    if (filterCTTN.Count() != 0)//neu la phieu da duoc tra no thi ko dc xoa
                        return 0;

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
                 
                    //cap nhat lai so luong ton kho 
                    {
                        for (int i = 0; i < vt.Count(); i++)
                        {
                            string mvt = vt[i].Ma_vat_tu;
                            int id_cl = (int)vt[i].Id_chat_luong;
                            int id_kho = (int)pnk.ID_kho;
                            var original = (from o in help.ent.Ton_kho
                                            where o.Ma_vat_tu == mvt
                                            && o.Id_chat_luong == id_cl
                                            && o.ID_kho == id_kho
                                            select o
                                                ).FirstOrDefault();
                            help.ent.Ton_kho.Attach(original);
                            original.So_luong = original.So_luong + vt[i].So_luong_thuc_lanh;// cong lai so luong ton kho truoc khi cho muon no 
                            var entry = help.ent.Entry(original);
                            entry.Property(e => e.So_luong).IsModified = true;
                            help.ent.SaveChanges();
                        }
                    }
                    // da ok chinh thuc cho xoa 

                
                    var filterCTTK = help.ent.Chi_tiet_the_kho.Where(o => o.Ma_phieu == pnk.Ma_phieu_nhap);
                    help.ent.Chi_tiet_the_kho.RemoveRange(filterCTTK);
                    help.ent.SaveChanges();
                    //xoa phieu can tru no 
                    //var filterCTNN = help.ent.Can_tru_no_nhap_ngoai.Where(o => o.Ma_phieu_nhap == pnk.Ma_phieu_nhap && pnk.isCanTru == true);
                    //help.ent.Can_tru_no_nhap_ngoai.RemoveRange(filterCTNN);
                    //help.ent.SaveChanges();
                    //neu no la phieu no 
                    //thi xoa phieu no xong reset lai so luong trong phieu tra no 

                    //van de phat sinh khi xoa phieu no 
                    //reset lai so luong phieu nhap va tien hanh xac nhan lai 
                    //thuc hien tra lai so luong da can tru, so luong se duoc chuyen ve cho 2 phieu kia trong thẻ kho
                    var filterCTPN = help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Where(o => o.Ma_phieu_nhap == pnk.Ma_phieu_nhap);
                    help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.RemoveRange(filterCTPN);
                    help.ent.SaveChanges();
                    //help.ent.Phieu_Nhap_Kho.Attach(pnk);
                    //pnk.isDelete = true;
                    //var entryPNK = help.ent.Entry(pnk);
                    //entryPNK.Property(e => e.isDelete).IsModified = true;
                    //help.ent.SaveChanges();

                    help.ent.Phieu_Nhap_Kho.RemoveRange(query);
                    help.ent.SaveChanges();
                    //thuc hien dieu chinh so lieu trong bang chi tiet ton kho va chi tiet the kho, chi tiet goi dau 



                    dbcxtransaction.Commit();
                }
                // chua co chung tu xuat
                //thuc hien thao tac xoa phieu 
                // xoa tim va xoa trong the kho co ma phieu nhap


            }
            return 1;
        }

        public int XoaPhieuHoanNhap(string maphieu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var query = help.ent.Phieu_Nhap_Kho.Where(o => o.Ma_phieu_nhap == maphieu);
                Phieu_Nhap_Kho pnk = query.FirstOrDefault();
                //lay danh sach phieu nhap
                //xoa chi tiet the kho 
                // xoa chi tiet ton kho , cap nhat lai so luong ton 
                //có phat sinh phieu xuat
                {//kiem tra so luong ton trong kho > so luong xoa thi moi duoc xoa
                    //neu phieu nay da can tru no thi ko cho xoa 
                 
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
                   
                    //cap nhat lai so luong ton kho 
                    {
                        for (int i = 0; i < vt.Count(); i++)
                        {
                            string mvt = vt[i].Ma_vat_tu;
                            int id_cl = (int)vt[i].Id_chat_luong;
                            int id_kho = (int)pnk.ID_kho;
                            var original = (from o in help.ent.Ton_kho
                                            where o.Ma_vat_tu == mvt
                                            && o.Id_chat_luong == id_cl
                                            && o.ID_kho == id_kho
                                            select o
                                                ).FirstOrDefault();
                            help.ent.Ton_kho.Attach(original);
                            original.So_luong = original.So_luong + vt[i].So_luong_thuc_lanh;
                            var entry = help.ent.Entry(original);
                            entry.Property(e => e.So_luong).IsModified = true;
                            help.ent.SaveChanges();
                        }
                    }
                    // da ok chinh thuc cho xoa 

                    var vtgd = (from c in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
                                join p in help.ent.Vat_Tu_Goi_Dau_Ky on c.Ma_vat_tu equals p.Ma_vat_tu
                                where p.ID_chat_luong == c.Id_chat_luong && p.ID_kho == pnk.ID_kho && c.Ma_phieu_nhap == pnk.Ma_phieu_nhap
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
                        
                        //xoa duoc goi dau, chi tiet goi dau 
                        //var filterCTGD = help.ent.Chi_Tiet_Goi_Dau.Where(o => o.ID_ma_phieu == pnk.ID_phieu_nhap);
                        //help.ent.Chi_Tiet_Goi_Dau.RemoveRange(filterCTGD);
                        //help.ent.SaveChanges();
                        // cap nhat lai so luong dau ky 
                        for (int i = 0; i < vtgd.Count; i++)
                        {
                            string mvt = vt[i].Ma_vat_tu;
                            int id_cl = (int)vt[i].Id_chat_luong;
                            int id_kho = (int)pnk.ID_kho;
                            var original = help.ent.Vat_Tu_Goi_Dau_Ky.Where(o => o.Ma_vat_tu == mvt && o.ID_chat_luong == id_cl && o.ID_kho == id_kho).FirstOrDefault();  //o =>o.  vt[i].Ma_vat_tu, vt[i].Id_chat_luong, pnk.ID_kho);
                            help.ent.Vat_Tu_Goi_Dau_Ky.Attach(original);
                            original.So_Luong = original.So_Luong + vtgd[i].So_luong_thuc_lanh;
                            var entry = help.ent.Entry(original);
                            entry.Property(e => e.So_Luong).IsModified = true;
                            help.ent.SaveChanges();


                        }
                    }
                    var filterCTTK = help.ent.Chi_tiet_the_kho.Where(o => o.Ma_phieu == pnk.Ma_phieu_nhap);
                    help.ent.Chi_tiet_the_kho.RemoveRange(filterCTTK);
                    help.ent.SaveChanges();
                    //xoa phieu can tru no 
                    //neu no la phieu no 
                    //thi xoa phieu no xong reset lai so luong trong phieu tra no 
                    var filterCTPN = help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Where(o => o.Ma_phieu_nhap == pnk.Ma_phieu_nhap);
                    //van de phat sinh khi xoa phieu no 
                    //reset lai so luong phieu nhap va tien hanh xac nhan lai 
                    //thuc hien tra lai so luong da can tru, so luong se duoc chuyen ve cho 2 phieu kia trong thẻ kho
                    help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.RemoveRange(filterCTPN);
                    help.ent.SaveChanges();

                    help.ent.Phieu_Nhap_Kho.RemoveRange(query);
                    help.ent.SaveChanges();
                    dbcxtransaction.Commit();
                }
                // chua co chung tu xuat
                //thuc hien thao tac xoa phieu 
                // xoa tim va xoa trong the kho co ma phieu nhap


            }
            return 1;
        }

    }
}
