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
        /// hàm insert tồn kho sử dụng transaction bên ngoài 
        /// hàm này dùng + số lượng với mã phiếu X
        /// </summary>
        /// <param name="mavt"></param>
        /// <param name="idkho"></param>
        /// <param name="soluong"></param>
        /// <param name="maphieu"></param>
        /// <param name="NgayNhap"></param>
        /// <param name="ID_chat_luong"></param>
        /// <returns></returns>
        public int InsertTonKho(DatabaseHelper help, string mavt, int idkho, double soluong, string maphieu, DateTime NgayNhap, int ID_chat_luong, bool LNP)
        {

          
            {
                try
                {
                    var entryPoint = (from d in help.ent.Ton_kho

                                      where d.ID_kho == idkho && d.Ma_vat_tu == mavt &&d.Id_chat_luong == ID_chat_luong
                                      select d).ToList();
                    #region "Thêm bảng tồn kho "
                    if (entryPoint.Count == 0)
                    {
                        //neu chưa có tiền hành lưu vật tư này vào kho với số lượng bằng số lượng nhập
                        Ton_kho entTonKho = new Ton_kho();
                        entTonKho.ID_kho = idkho;
                        entTonKho.Ma_vat_tu = mavt;
                        entTonKho.So_luong = soluong;
                        entTonKho.Id_chat_luong = ID_chat_luong;
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
                        //cập nhật trạng thái phiếu nhập
                        ////sau đó thêm 1 dòng vào trong thẻ kho
                        ////thêm vào chi tiết thẻ kho
                        //// tìm kiếm thẻ kho xem đã có thẻ kho có mã vật tư hay chưa ?
                        //// nếu có tiến hành thêm 1 dòng vào chi tiết thẻ kho 
                        ////nếu không có thì tiến hành insert và trong bảng thẻ kho và chi tiết thẻ kho
                        //var entryPointTK = (from d in help.ent.The_kho

                        //                    where d.Ma_vat_tu == mavt&& d.Id_chat_luong == ID_chat_luong 
                        //                    select d).ToList();
                        ////nếu chưa có trong thẻ kho 
                        //if (entryPointTK.Count == 0)
                        //{
                        //    //tiến hành thêm 1 dong vao the kho và chi tiet the kho
                        //    The_kho tk = new The_kho();
                        //    tk.Ma_vat_tu = mavt;
                        //    tk.Dia_diem = idkho.ToString();
                        //    tk.Don_vi = idkho.ToString();
                        //    tk.Id_chat_luong = ID_chat_luong;
                        //    help.ent.The_kho.Add(tk);
                        //    help.ent.SaveChanges();


                        //    Chi_tiet_the_kho cttks = new Chi_tiet_the_kho();
                        //    cttks.ID_The_Kho = tk.ID_The_Kho;
                        //    cttks.Ma_phieu = maphieu;
                        //    cttks.Ngay_xuat_chung_tu = entryPointPN[0].Ngay_lap;
                        //    cttks.Dien_giai = entryPointPN[0].Ly_do;
                        //    cttks.SL_Nhap = entryPointCT[0].So_luong_thuc_lanh;
                        //    cttks.Loai_phieu = true;
                        //    cttks.Ngay_nhap_xuat = NgayNhap;

                        //    help.ent.Chi_tiet_the_kho.Add(cttks);
                        //    help.ent.SaveChanges();


                        //}
                        //else
                        //{

                        //    //nếu đã có trong bảng thẻ kho thì tiến hành thêm vào bảng chi tiết thẻ kho 1 dòng mới
                        //    Chi_tiet_the_kho cttks = new Chi_tiet_the_kho();
                        //    cttks.ID_The_Kho = entryPointTK[0].ID_The_Kho;
                        //    cttks.Ma_phieu = maphieu;
                        //    cttks.Ngay_xuat_chung_tu = entryPointPN[0].Ngay_lap;
                        //    cttks.Dien_giai = entryPointPN[0].Ly_do;
                        //    cttks.SL_Nhap = entryPointCT[0].So_luong_thuc_lanh;
                        //    cttks.Loai_phieu = true;
                        //    cttks.Ngay_nhap_xuat = NgayNhap;
                        //    help.ent.Chi_tiet_the_kho.Add(cttks);
                        //    help.ent.SaveChanges();

                        //}



                      //  return 1;
                    }
                    else
                    {
                        //neu kho đó đã có vật tư thì tiến hành cộng, hoac tru vật tư hiện tại vào kho

                        // entTonKho.So_luong = soluong;
                        //lay 1 dong ra 
                        var stud = help.ent.Ton_kho.Where(s => s.ID_kho == idkho && s.Ma_vat_tu == mavt && s.Id_chat_luong == ID_chat_luong).FirstOrDefault<Ton_kho>();
                        if (LNP == true)
                        {
                            stud.So_luong = stud.So_luong + soluong;
                        }
                        else
                            stud.So_luong = stud.So_luong - soluong;
                        help.ent.Ton_kho.Attach(stud);
                        help.ent.Entry(stud).State = EntityState.Modified;//chinh sua so luong

                        //help.ent.Ton_kho.Attach(entTonKho);
                        //help.ent.Entry(entTonKho).State = EntityState.Modified;
                        help.ent.SaveChanges();

                        //buoc 2: them 1 dong vao ban chi tiet ton kho voi ma, so luong, kho tuong tung
                        Chi_Tiet_Ton_Kho cttk = new Chi_Tiet_Ton_Kho();
                        cttk.ID_Ton_kho = stud.ID_ton_kho;
                        cttk.Ma_phieu = maphieu;
                        cttk.So_luong = stud.So_luong;

                        cttk.Ngay_thay_doi = DateTime.Now;
                        if(LNP == true)
                            cttk.Tang_Giam = true;//<-- set tang 
                        else
                            cttk.Tang_Giam = false;
                        help.ent.Chi_Tiet_Ton_Kho.Add(cttk);
                        help.ent.SaveChanges();
                        //cập nhật lại trạng thái phiếu nhập 
                        //var entryPointPN = (from d in help.ent.Phieu_Nhap_Kho

                        //                    where d.Ma_phieu_nhap == maphieu 
                        //                    select d).ToList();
                        //if (entryPointPN[0].Da_phan_kho == false)
                        //{
                        //    entryPointPN[0].Da_phan_kho = true;
                        //    help.ent.Phieu_Nhap_Kho.Attach(entryPointPN[0]);
                        //    help.ent.Entry(entryPointPN[0]).State = EntityState.Modified;
                        //}

                        //help.ent.SaveChanges();
                        //buoc 3 : sau khi them vao bang chi tiet ton kho thi cap nhat lai trang thai phieu nhap

                        //Chi_Tiet_Phieu_Nhap_Vat_Tu ctpn = new Chi_Tiet_Phieu_Nhap_Vat_Tu();
                       
                        //sau đó thêm 1 dòng vào trong thẻ kho
                        //thêm vào chi tiết thẻ kho
                        // tìm kiếm thẻ kho xem đã có thẻ kho có mã vật tư hay chưa ?
                        // nếu có tiến hành thêm 1 dòng vào chi tiết thẻ kho 
                        //nếu không có thì tiến hành insert và trong bảng thẻ kho và chi tiết thẻ kho                    
                     //   dbcxtransaction.Commit();//hoan thanh thao tac

                    }
                    #endregion
                    #region "Cập nhật bảng chi tiết pn,ctpn"
                    var entryPointCT = (from d in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu

                                        where d.Ma_vat_tu == mavt && d.Ma_phieu_nhap == maphieu && d.Id_chat_luong == ID_chat_luong
                                        select d).ToList();
                    foreach (var temp in entryPointCT)
                    {
                        temp.Da_duyet = true;

                        help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Attach(temp);
                        help.ent.Entry(temp).State = EntityState.Modified;
                    }
                    help.ent.SaveChanges();
                    var entryPointPN = (from d in help.ent.Phieu_Nhap_Kho

                                        where d.Ma_phieu_nhap == maphieu
                                        select d).ToList();
                    if (entryPointPN[0].Da_phan_kho == false)
                    {
                        entryPointPN[0].Da_phan_kho = true;
                        help.ent.Phieu_Nhap_Kho.Attach(entryPointPN[0]);
                        help.ent.Entry(entryPointPN[0]).State = EntityState.Modified;
                    }
                   
                    help.ent.SaveChanges();
                    #endregion
                    #region "Xữ lý kho , thẻ kho"
                    var entryPointTK = (from d in help.ent.The_kho

                                        where d.Ma_vat_tu == mavt && d.Id_chat_luong == ID_chat_luong
                                        select d).ToList();
                    //nếu chưa có trong thẻ kho 
                    if (entryPointTK.Count == 0)
                    {
                        //tiến hành thêm 1 dong vao the kho và chi tiet the kho
                        The_kho tk = new The_kho();
                        tk.Ma_vat_tu = mavt;
                        tk.Dia_diem = idkho.ToString();
                        tk.Don_vi = idkho.ToString();
                        tk.Id_chat_luong = ID_chat_luong;
                        help.ent.The_kho.Add(tk);
                        help.ent.SaveChanges();


                        Chi_tiet_the_kho cttks = new Chi_tiet_the_kho();
                        cttks.ID_The_Kho = tk.ID_The_Kho;
                        cttks.Ma_phieu = maphieu;
                        cttks.Ngay_xuat_chung_tu = entryPointPN.First().Ngay_lap;
                        cttks.Dien_giai = entryPointPN.First().Ly_do;
                        cttks.SL_Nhap = soluong;
                        cttks.SL_Ton = soluong;// nếu đây là dòng đầu tiên trong danh sách thì số lượng tồn = sl thực lãnh
                        cttks.Loai_phieu = true;
                        cttks.Ngay_nhap_xuat = NgayNhap;
                        help.ent.Chi_tiet_the_kho.Add(cttks);
                        help.ent.SaveChanges();


                    }
                    else
                    {

                        //nếu đã có trong bảng thẻ kho thì tiến hành thêm vào bảng chi tiết thẻ kho 1 dòng mới
                        Chi_tiet_the_kho cttks = new Chi_tiet_the_kho();
                        cttks.ID_The_Kho = entryPointTK[0].ID_The_Kho;
                        cttks.Ma_phieu = maphieu;
                        cttks.Ngay_xuat_chung_tu = entryPointPN[0].Ngay_lap;
                        cttks.Dien_giai = entryPointPN[0].Ly_do;
                        cttks.SL_Nhap = entryPointCT[0].So_luong_thuc_lanh;
                        //tìm kiếm số lượng tồn trước đó

                        //sln danh sách các thẻ kho có
                        int id = entryPointTK.First().ID_The_Kho;
                        var slt = (from d in help.ent.Chi_tiet_the_kho

                                   where d.ID_The_Kho == id
                                   orderby d.ID_chi_tiet_the_kho 

                                   select d).ToList().Last();

                        if (LNP == true)
                        {
                            //nếu phiếu nhập X
                            cttks.Loai_phieu = true;
                            //thì cộng vào tồn 
                            cttks.SL_Ton = slt.SL_Ton + soluong;

                        }
                        else
                        {
                            cttks.Loai_phieu = false;
                            cttks.SL_Ton = slt.SL_Ton - soluong;

                        }
                        cttks.Ngay_nhap_xuat = NgayNhap;
                        help.ent.Chi_tiet_the_kho.Add(cttks);
                        help.ent.SaveChanges();

                    }
                    #endregion
                }
                catch (Exception ex)
                {
                 //   dbcxtransaction.Rollback();
                    
                    return 0;

                }
            }
            return 1;
            //return 0;

        }
        /// <summary>
        /// hàm này bị sai tạm thời không dùng mà dùng hàm trên 
        /// hàm xữ lý thêm vật tư vào kho liên quan đến nhiều lớp, tính toán phức tạp
        /// </summary>
        /// <returns></returns>
        public int InsertTonKho(string mavt, int idkho, double soluong, string maphieu, DateTime NgayNhap, int ID_chat_luong)
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
                        entTonKho.Id_chat_luong = ID_chat_luong;
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

                                            where d.Ma_vat_tu == mavt && d.Ma_phieu_nhap == maphieu && d.Id_chat_luong == ID_chat_luong
                                            select d).ToList();
                        foreach (var temp in entryPointCT)
                        {
                            temp.Da_duyet = true;
                            help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Attach(temp);
                            help.ent.Entry(temp).State = EntityState.Modified;
                        }
                         help.ent.SaveChanges();
                        //cập nhật trạng thái phiếu nhập
                        var entryPointPN = (from d in help.ent.Phieu_Nhap_Kho

                                            where d.Ma_phieu_nhap == maphieu
                                            select d).ToList();
                        if (entryPointPN[0].Da_phan_kho == false)
                        {
                            entryPointPN[0].Da_phan_kho = true;
                            help.ent.Phieu_Nhap_Kho.Attach(entryPointPN[0]);
                            help.ent.Entry(entryPointPN[0]).State = EntityState.Modified;
                        }
                        help.ent.SaveChanges();

                     
                        
                        //sau đó thêm 1 dòng vào trong thẻ kho
                        //thêm vào chi tiết thẻ kho
                        // tìm kiếm thẻ kho xem đã có thẻ kho có mã vật tư hay chưa ?
                        // nếu có tiến hành thêm 1 dòng vào chi tiết thẻ kho 
                        //nếu không có thì tiến hành insert và trong bảng thẻ kho và chi tiết thẻ kho
                        var entryPointTK = (from d in help.ent.The_kho

                                            where d.Ma_vat_tu == mavt 
                                            select d).ToList();
                        //nếu chưa có trong thẻ kho 
                        if (entryPointTK.Count == 0)
                        {
                            //tiến hành thêm 1 dong vao the kho và chi tiet the kho
                            The_kho tk = new The_kho();
                            tk.Ma_vat_tu = mavt;
                            tk.Dia_diem = idkho.ToString();
                            tk.Don_vi = idkho.ToString();
                            tk.Id_chat_luong = ID_chat_luong;
                            help.ent.The_kho.Add(tk);
                            help.ent.SaveChanges();


                            Chi_tiet_the_kho cttks = new Chi_tiet_the_kho();
                            cttks.ID_The_Kho = tk.ID_The_Kho;
                            cttks.Ma_phieu = maphieu;
                            cttks.Ngay_xuat_chung_tu = entryPointPN[0].Ngay_lap;
                            cttks.Dien_giai = entryPointPN[0].Ly_do;
                            cttks.SL_Nhap = entryPointCT[0].So_luong_thuc_lanh;
                            cttks.Loai_phieu = true;
                            cttks.Ngay_nhap_xuat = NgayNhap;
                            
                            help.ent.Chi_tiet_the_kho.Add(cttks);
                            help.ent.SaveChanges();


                        }
                        else
                        {

                            //nếu đã có trong bảng thẻ kho thì tiến hành thêm vào bảng chi tiết thẻ kho 1 dòng mới
                            Chi_tiet_the_kho cttks = new Chi_tiet_the_kho();
                            cttks.ID_The_Kho = entryPointTK[0].ID_The_Kho;
                            cttks.Ma_phieu = maphieu;
                            cttks.Ngay_xuat_chung_tu = entryPointPN[0].Ngay_lap;
                            cttks.Dien_giai = entryPointPN[0].Ly_do;
                            cttks.SL_Nhap = entryPointCT[0].So_luong_thuc_lanh;
                            cttks.Loai_phieu = true;
                            cttks.Ngay_nhap_xuat = NgayNhap;
                            help.ent.Chi_tiet_the_kho.Add(cttks);
                            help.ent.SaveChanges();

                        }
                       


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
                      help.ent.Entry(stud).State = EntityState.Modified;//chinh sua so luong

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
                        //cập nhật lại trạng thái phiếu nhập 
                        var entryPointPN = (from d in help.ent.Phieu_Nhap_Kho

                                            where d.Ma_phieu_nhap == maphieu
                                            select d).ToList();
                        if(entryPointPN[0].Da_phan_kho ==false)
                        {
                            entryPointPN[0].Da_phan_kho = true;
                            help.ent.Phieu_Nhap_Kho.Attach(entryPointPN[0]);
                            help.ent.Entry(entryPointPN[0]).State = EntityState.Modified;
                        }

                        help.ent.SaveChanges();
                        //buoc 3 : sau khi them vao bang chi tiet ton kho thi cap nhat lai trang thai phieu nhap
                       
                        //Chi_Tiet_Phieu_Nhap_Vat_Tu ctpn = new Chi_Tiet_Phieu_Nhap_Vat_Tu();
                        var entryPointCT = (from d in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu

                                            where d.Ma_vat_tu == mavt && d.Ma_phieu_nhap == maphieu && d.Id_chat_luong == ID_chat_luong
                                            select d).ToList();
                        foreach (var temp in entryPointCT)
                        {
                            temp.Da_duyet = true;
                            
                            help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Attach(temp);
                            help.ent.Entry(temp).State = EntityState.Modified;
                        }
                        help.ent.SaveChanges();

                      

                        //sau đó thêm 1 dòng vào trong thẻ kho
                        //thêm vào chi tiết thẻ kho
                        // tìm kiếm thẻ kho xem đã có thẻ kho có mã vật tư hay chưa ?
                        // nếu có tiến hành thêm 1 dòng vào chi tiết thẻ kho 
                        //nếu không có thì tiến hành insert và trong bảng thẻ kho và chi tiết thẻ kho
                        var entryPointTK = (from d in help.ent.The_kho

                                            where d.Ma_vat_tu == mavt
                                            select d).ToList();
                        //nếu chưa có trong thẻ kho 
                        if (entryPointTK.Count == 0)
                        {
                            //tiến hành thêm 1 dong vao the kho và chi tiet the kho
                            The_kho tk = new The_kho();
                            tk.Ma_vat_tu = mavt;
                            tk.Dia_diem = idkho.ToString();
                            tk.Don_vi = idkho.ToString();
                            tk.Id_chat_luong = ID_chat_luong;   
                            help.ent.The_kho.Add(tk);
                            help.ent.SaveChanges();


                            Chi_tiet_the_kho cttks = new Chi_tiet_the_kho();
                            cttks.ID_The_Kho = entryPointTK[0].ID_The_Kho;
                            cttks.Ma_phieu = maphieu;
                            cttks.Ngay_xuat_chung_tu = entryPointPN[0].Ngay_lap;
                            cttks.Dien_giai = entryPointPN[0].Ly_do;
                            cttks.SL_Nhap = entryPointCT[0].So_luong_thuc_lanh;
                            cttks.Loai_phieu = true;
                            cttks.Ngay_nhap_xuat = NgayNhap;
                            help.ent.Chi_tiet_the_kho.Add(cttks);
                            help.ent.SaveChanges();


                        }
                        else
                        {

                            //nếu đã có trong bảng thẻ kho thì tiến hành thêm vào bảng chi tiết thẻ kho 1 dòng mới
                            Chi_tiet_the_kho cttks = new Chi_tiet_the_kho();
                            cttks.ID_The_Kho = entryPointTK[0].ID_The_Kho;
                            cttks.Ma_phieu = maphieu;
                            cttks.Ngay_xuat_chung_tu = entryPointPN[0].Ngay_lap;
                            cttks.Dien_giai = entryPointPN[0].Ly_do;
                            cttks.SL_Nhap = entryPointCT[0].So_luong_thuc_lanh;
                            cttks.Loai_phieu = true;
                            cttks.Ngay_nhap_xuat = NgayNhap;
                            help.ent.Chi_tiet_the_kho.Add(cttks);
                            help.ent.SaveChanges();

                        }

                    
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
