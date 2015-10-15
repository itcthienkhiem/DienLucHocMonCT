using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Inventory.Utilities;
using Inventory.Models;
using System.Linq;
using System.Data.Entity;
namespace Inventory.EntityClass
{
    public class clsChi_Tiet_Phieu_Nhap_Vat_Tu
    {
        public int? ID_chi_tiet_phieu_nhap;
        public string Ma_phieu_nhap;
        public string Ma_vat_tu;
        public string Chat_luong;
        public string Don_vi;
        public int? So_luong_yeu_cau;
        public int? So_luong_thuc_lanh;
        public int? Don_gia;
        public int? Thanh_tien;
        public int? ID_Don_vi_tinh;
        public string Ten_DVT;
        public bool Da_duyet;




        SqlConnection m_dbConnection = new SqlConnection(clsThamSoUtilities.connectionString);
        public clsChi_Tiet_Phieu_Nhap_Vat_Tu()
        {

        }
        public object GetAll()
        {



            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var dm = from d in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
                         join e in help.ent.DM_Don_vi_tinh on d.ID_Don_vi_tinh equals e.ID_Don_vi_tinh
                         select new
                         {
                             d.ID_chi_tiet_phieu_nhap_vat_tu,
                             d.Ma_phieu_nhap,
                             d.Ma_vat_tu,
                             d.Chat_luong,
                             d.So_luong_yeu_cau,
                             d.So_luong_thuc_lanh,
                             d.Don_gia,
                             d.Thanh_tien,
                             d.ID_Don_vi_tinh,
                             e.Ten_don_vi_tinh,

                         };
                dbcxtransaction.Commit();
                return (object)dm.ToList();
            }



        }

        public int remove(string ma_phieu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var recordsToDelete = (from c in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu where c.Ma_phieu_nhap == ma_phieu select c).ToList<Chi_Tiet_Phieu_Nhap_Vat_Tu>();
                if (recordsToDelete.Count > 0)
                {
                    foreach (var record in recordsToDelete)
                    {
                        help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Attach(record);
                        help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Remove(record);
                    }
                }
                help.ent.SaveChanges();
                dbcxtransaction.Commit();
            }

            return 1;
        }


        public int removebyKey(SQLDAL DAL, string ma_Phieunhap, string ma_vat_tu)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                Chi_Tiet_Phieu_Nhap_Vat_Tu deptBook = new Chi_Tiet_Phieu_Nhap_Vat_Tu { Ma_vat_tu = ma_vat_tu, Ma_phieu_nhap = ma_Phieunhap };
                help.ent.Entry(deptBook).State = EntityState.Deleted;
                help.ent.SaveChanges();
                dbcxtransaction.Commit();
                return 1;
            }
            return 0;

        }
        /// <summary>
        /// ham kiem tra co vat tu nao da duyet trong phieu nhap chua 
        /// </summary>
        /// <param name="ma_Phieunhap"></param>
        /// <returns>false : chua co , true: da co </returns>
        public static bool KTVTChuaDuyet(string ma_Phieunhap)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();


            var entryPoint = (from ep in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
                               where ep.Ma_phieu_nhap.Equals(ma_Phieunhap) && ep.Da_duyet == true
                              select ep).ToList();

            if (entryPoint.Count == 0)
                return false;// chua co phan tu nao da duyet trong danh sach
            return true;
        }


        /// <summary>
        /// Lấy dữ liệu theo "Mã phiếu nhập"
        /// - Trả về Data để set lên frm
        /// </summary>
        /// <param name="ma_Phieunhap">The ma_ phieunhap.</param>
        /// <returns></returns>
        public DataTable GetAll(string ma_Phieunhap)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();


            var entryPoint = (from ep in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
                              join e in help.ent.DM_Don_vi_tinh on ep.ID_Don_vi_tinh equals e.ID_Don_vi_tinh
                              join u in help.ent.DM_Vat_Tu on ep.Ma_vat_tu equals u.Ma_vat_tu
                              where ep.Ma_phieu_nhap.Equals(ma_Phieunhap)

                              select new
                              {
                                  ID_chi_tiet_phieu_nhap_vat_tu = ep.ID_chi_tiet_phieu_nhap_vat_tu,
                                  Ma_vat_tu = ep.Ma_vat_tu,
                                  Ten_vat_tu = u.Ten_vat_tu,
                                  Ten_don_vi_tinh = e.Ten_don_vi_tinh,
                                  Chat_luong = ep.Chat_luong,
                                  So_luong_yeu_cau = ep.So_luong_yeu_cau,
                                  So_luong_thuc_nhap = ep.So_luong_thuc_lanh,
                                  Thanh_tien = ep.Thanh_tien,
                                  Don_gia = ep.Don_gia,
                                  id_don_vi_tinh = ep.ID_Don_vi_tinh,
                                  Ten_DVT = e.Ten_don_vi_tinh,
                              }).ToList();
            //return entryPoint.ToList();

            DataTable table = new DataTable();
            table.Columns.Add("ID_vat_tu", typeof(int));
            table.Columns.Add("Ma_vat_tu", typeof(string));
            table.Columns.Add("Ten_vat_tu", typeof(string));
            table.Columns.Add("Ten_don_vi_tinh", typeof(string));
            table.Columns.Add("Chat_luong", typeof(string));
            table.Columns.Add("So_luong_yeu_cau", typeof(int));
            table.Columns.Add("So_luong_thuc_lanh", typeof(int));
            table.Columns.Add("Thanh_tien", typeof(int));
            table.Columns.Add("id_don_vi_tinh", typeof(int));
            table.Columns.Add("Ten_DVT", typeof(string));
            table.Columns.Add("Don_gia", typeof(string));
            entryPoint.ToList().ForEach((n) =>
            {
                DataRow row = table.NewRow();
                row.SetField<int>("ID_vat_tu", n.ID_chi_tiet_phieu_nhap_vat_tu);
                row.SetField<string>("Ma_vat_tu", n.Ma_vat_tu);
                row.SetField<string>("Ten_vat_tu", n.Ten_vat_tu);
                row.SetField<string>("Ten_don_vi_tinh", n.Ten_don_vi_tinh);
                row.SetField<string>("Chat_luong", n.Chat_luong);
                row.SetField<int?>("So_luong_yeu_cau", n.So_luong_yeu_cau);
                row.SetField<int?>("So_luong_thuc_lanh", n.So_luong_thuc_nhap);
                row.SetField<int?>("Thanh_tien", n.Thanh_tien);
                row.SetField<int?>("id_don_vi_tinh", n.id_don_vi_tinh);
                row.SetField<string>("Ten_DVT", n.Ten_DVT);

                row.SetField<int?>("Don_gia", n.Don_gia);



                table.Rows.Add(row);
            });
            return table;

        }
        /// <summary>
        /// ham cap nhat lai trang thai da duyet 
        /// </summary>
        /// <param name="maphieunhap"></param>
        /// <param name="mavattu"></param>
        /// <returns></returns>
        public int UpdateDaDuyet(string maphieunhap, string mavattu)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            //   help.ent.Database.BeginTransaction();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var recordsToUpdate = (from c in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu where c.Ma_phieu_nhap == maphieunhap && c.Ma_vat_tu == mavattu select c).ToList<Chi_Tiet_Phieu_Nhap_Vat_Tu>();
                if (recordsToUpdate.Count > 0)
                {
                    foreach (var record in recordsToUpdate)
                    {
                        record.Da_duyet = true;
                        help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Attach(record);
                        help.ent.Entry(record).State = EntityState.Modified;
                    }
                }
                help.ent.SaveChanges();
                dbcxtransaction.Commit();
                return 1;
            }
            return 0;


        }
        /// <summary>
        /// lấy danh sách các vật tư chưa phân vào kho
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllChuaPhanKho()
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                var entryPoint = (from d in help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu
                                  join e in help.ent.DM_Vat_Tu on d.Ma_vat_tu equals e.Ma_vat_tu
                                  join f in help.ent.Phieu_Nhap_Kho on d.Ma_phieu_nhap equals f.Ma_phieu_nhap
                                  where d.Da_duyet == false
                                  select new
                                  {
                                      d.ID_chi_tiet_phieu_nhap_vat_tu,
                                      d.Ma_phieu_nhap,
                                      d.Ma_vat_tu,
                                      e.Ten_vat_tu,
                                      f.Ngay_lap,
                                      d.So_luong_thuc_lanh,
                                      d.Da_duyet,


                                  }).ToList();
                DataTable table = new DataTable();
                table.Columns.Add("ID_chi_tiet_phieu_nhap_vat_tu", typeof(int));
                table.Columns.Add("Ma_phieu_nhap", typeof(string));
                table.Columns.Add("Ma_vat_tu", typeof(string));
                table.Columns.Add("Ten_vat_tu", typeof(string));
                table.Columns.Add("Ngay_lap", typeof(DateTime));
                table.Columns.Add("So_luong_thuc_lanh", typeof(int));
                table.Columns.Add("Da_duyet", typeof(bool));
                entryPoint.ToList().ForEach((n) =>
                {
                    DataRow row = table.NewRow();
                    row.SetField<int>("ID_chi_tiet_phieu_nhap_vat_tu", n.ID_chi_tiet_phieu_nhap_vat_tu);
                    row.SetField<string>("Ma_phieu_nhap", n.Ma_phieu_nhap);
                    row.SetField<string>("Ma_vat_tu", n.Ma_vat_tu);
                    row.SetField<DateTime?>("Ngay_lap", n.Ngay_lap);
                    row.SetField<string>("Ten_vat_tu", n.Ten_vat_tu);
                    row.SetField<int?>("So_luong_thuc_lanh", n.So_luong_thuc_lanh);

                    row.SetField<bool?>("Da_duyet", n.Da_duyet);



                    table.Rows.Add(row);
                });
                dbcxtransaction.Commit();
                return table;


            }

        }

        public bool CheckTonTaiSoDK()
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            bool has = help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Any(cus => cus.Ma_phieu_nhap == Ma_phieu_nhap);
            return has;


        }
        public int Insert(SQLDAL DAL)
        {

            // insert
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                try
                {
                    var t = new Chi_Tiet_Phieu_Nhap_Vat_Tu //Make sure you have a table called test in DB
                    {
                        Ma_phieu_nhap = this.Ma_phieu_nhap,
                        Ma_vat_tu = this.Ma_vat_tu,                   // ID = Guid.NewGuid(),
                        Chat_luong = this.Chat_luong,
                        So_luong_yeu_cau = this.So_luong_yeu_cau,
                        So_luong_thuc_lanh = this.So_luong_thuc_lanh,
                        Don_gia = this.Don_gia,
                        Thanh_tien = this.Thanh_tien,
                        ID_Don_vi_tinh = this.ID_Don_vi_tinh,
                    };

                    help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Add(t);
                    help.ent.SaveChanges(); dbcxtransaction.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    dbcxtransaction.Rollback();
                    return 0;

                }

            }



        }

        public int Update(Chi_Tiet_Phieu_Nhap_Vat_Tu pn)
        {

            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            int temp = 0;
            using (var dbcxtransaction = help.ent.Database.BeginTransaction())
            {
                using (var context = help.ent)
                {
                    context.Chi_Tiet_Phieu_Nhap_Vat_Tu.Attach(pn);
                    context.Entry(pn).State = EntityState.Modified;
                    temp = help.ent.SaveChanges();
                    dbcxtransaction.Commit();

                }


            }
            return temp;




        }

        public int Delete(Chi_Tiet_Phieu_Nhap_Vat_Tu pn)
        {
            DatabaseHelper help = new DatabaseHelper();
            help.ConnectDatabase();
            help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Attach(pn);
            help.ent.Chi_Tiet_Phieu_Nhap_Vat_Tu.Remove(pn);
            return help.ent.SaveChanges();

        }
    }
}
