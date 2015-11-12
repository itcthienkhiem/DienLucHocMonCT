using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;

namespace Inventory.EntityClass
{
    public class clsChiTietTheKho
    {
        //~
        public int ID_the_kho;
        public string Ma_phieu;
        public bool Loai_phieu;
        // public string Ma_phieu;
        public DateTime Ngay_xuat_chung_tu;
        public DateTime Ngay_nhap_xuat;
        public string Dien_giai;
        public decimal SL_Nhap;
        public decimal SL_Xuat;
        public decimal SL_Ton;
        public bool Da_quyet_toan;
        public string Ghi_chu;



        public int Insert(DatabaseHelper help)
        {

            // insert

            {
                try
                {
                    var t = new Chi_tiet_the_kho //Make sure you have a table called test in DB
                    {

                        ID_The_Kho = this.ID_the_kho,                   // ID = Guid.NewGuid(),
                        Ma_phieu = this.Ma_phieu,
                        Loai_phieu = this.Loai_phieu,
                        Ngay_xuat_chung_tu = this.Ngay_xuat_chung_tu,

                        Ngay_nhap_xuat = this.Ngay_nhap_xuat,
                        Dien_giai = this.Dien_giai,
                        SL_Nhap = this.SL_Nhap,
                        SL_Xuat = this.SL_Xuat,
                        SL_Ton = this.SL_Ton,
                        Da_quyet_toan = this.Da_quyet_toan,
                        Ghi_chu = this.Ghi_chu,

                    };

                    help.ent.Chi_tiet_the_kho.Add(t);
                    help.ent.SaveChanges();
                    return 1;
                }
                catch (Exception ex)
                {

                    return 0;

                }

            }



        }

        public int Update(DatabaseHelper help)
        {



            int temp = 0;
            var t = new Chi_tiet_the_kho //Make sure you have a table called test in DB
            {

                ID_The_Kho = this.ID_the_kho,                   // ID = Guid.NewGuid(),
                Ma_phieu = this.Ma_phieu,
                Loai_phieu = this.Loai_phieu,
                Ngay_xuat_chung_tu = this.Ngay_xuat_chung_tu,

                Ngay_nhap_xuat = this.Ngay_nhap_xuat,
                Dien_giai = this.Dien_giai,
                SL_Nhap = this.SL_Nhap,
                SL_Xuat = this.SL_Xuat,
                SL_Ton = this.SL_Ton,
                Da_quyet_toan = this.Da_quyet_toan,
                Ghi_chu = this.Ghi_chu,

            };
            try
            {
                using (var context = help.ent)
                {
                    context.Chi_tiet_the_kho.Attach(t);
                    context.Entry(t).State = EntityState.Modified;
                    temp = help.ent.SaveChanges();


                }


            }
            catch (Exception ex)
            {

            }

            return temp;
        }
        public int Delete(DatabaseHelper help)
        {
            var t = new Chi_tiet_the_kho //Make sure you have a table called test in DB
            {

                ID_The_Kho = this.ID_the_kho,                   // ID = Guid.NewGuid(),
                Ma_phieu = this.Ma_phieu,
                Loai_phieu = this.Loai_phieu,
                Ngay_xuat_chung_tu = this.Ngay_xuat_chung_tu,

                Ngay_nhap_xuat = this.Ngay_nhap_xuat,
                Dien_giai = this.Dien_giai,
                SL_Nhap = this.SL_Nhap,
                SL_Xuat = this.SL_Xuat,
                SL_Ton = this.SL_Ton,
                Da_quyet_toan = this.Da_quyet_toan,
                Ghi_chu = this.Ghi_chu,

            };
            help.ent.Chi_tiet_the_kho.Attach(t);
            help.ent.Chi_tiet_the_kho.Remove(t);
            return help.ent.SaveChanges();

        }
        /// <summary>
        /// hàm này lấy danh sách các thẻ kho có id bằng id thẻ kho và có ngày nhập từ ngày đến ngày 
        /// </summary>
        /// <param name="id_thekho"></param>
        /// <returns></returns>
        public DataTable GetAll(int id_thekho)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = (from d in help.ent.Chi_tiet_the_kho
                          where d.ID_The_Kho == id_thekho
                          select d).ToList();
                dbcxtransaction.Commit();
                return Utilities.clsThamSoUtilities.ToDataTable(dm);
            }
        }
        /// <summary>
        /// hàm get tất cả chi tiết thẻ kho trong id_the_kho nhỏ hơn ngày tìm kiếm
        /// </summary>
        /// <param name="tungays"></param>
        /// <param name="denngays"></param>
        /// <param name="id_the_kho"></param>
        /// <returns></returns>
        public DataTable GetAllSLT(DateTime tungay, int id_the_kho)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var filteredData = (from d in help.ent.Chi_tiet_the_kho
                                    where d.ID_The_Kho == id_the_kho 
                                    orderby d.Ngay_xuat_chung_tu
                                    select d)
                    .ToList();


                return Utilities.clsThamSoUtilities.ToDataTable(filteredData);

            }
        }

        public DataTable Search(DateTime tungays, DateTime denngays, int id_the_kho)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var filteredData =(from d in help.ent.Chi_tiet_the_kho
                    where  EntityFunctions.TruncateTime(d.Ngay_xuat_chung_tu)>=EntityFunctions.TruncateTime(tungays) &&EntityFunctions.TruncateTime( d.Ngay_xuat_chung_tu) <= EntityFunctions.TruncateTime(denngays) && d.ID_The_Kho == id_the_kho
                    orderby d.Ngay_xuat_chung_tu 
                                   select d)
                    .ToList();

               
                return Utilities.clsThamSoUtilities.ToDataTable(filteredData);
            
            }
        }
    }
}
