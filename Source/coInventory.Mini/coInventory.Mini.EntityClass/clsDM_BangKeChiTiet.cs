using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace eHospital.Mini.EntityClass
{
 public   class clsDM_BangKeChiTiet:clsDM_XuLy
    {
     public int BangKeChiTietId;
     public int BangKeId;
     public string MaChiPhi;
     public string MaPhu;
     public string TenChiPhi;
     public string DonViTinh;
     public decimal SoLuong;
     public decimal PhanTramDuocHuong;
     public decimal DonGiaBHYT;
     public decimal ThanhTienBHYT;
     public decimal BHYTThanhToan;
     public decimal NguonKhac;
     public decimal NguoiBenhTra;
     public decimal ChiPhiNgoaiDinhSuat;
     public string MaNhom1;
     public string MaNhom2;
     public string MaLoaiChiPhi;
     public bool VTYTDichVuKTC;
     public bool DichVuKTC;
     public string GhiChu;

     public override System.Data.DataTable GetAll()
     {
         sql = "Select * from BangKeChiTiet";
         return base.GetAll();
     }
     public DataTable GetByID(string strMa)
     {
         sql = "Select * from BangKeChiTiet where Bangke_id = "+strMa;
         return base.GetAll();
     }
          public override object GetByKey(string strMa)
        {
            //clsDM_CSKCB kcb = new clsDM_CSKCB();
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM BangKeChiTiet WHERE BangKe_Id=@BangKe_Id";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.Add(new SQLiteParameter("@BangKe_Id", strMa));
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);
            m_dbConnection.Close();

          //  clsDM_CSKCB objCSKCB = new clsDM_CSKCB();

            if (dt.Rows.Count > 0)
            {
                this.BangKeChiTietId =int.Parse( dt.Rows[0]["BangKeChiTiet_Id"].ToString());
                this.BangKeId = int.Parse(dt.Rows[0]["BangKe_Id"].ToString());
                this.MaChiPhi = dt.Rows[0]["MaChiPhi"].ToString();
                this.MaPhu = dt.Rows[0]["MaPhu"].ToString();
                this.TenChiPhi = (dt.Rows[0]["TenChiPhi"].ToString());
                this.DonViTinh = (dt.Rows[0]["DonViTinh"].ToString());

                try
                {
                    this.SoLuong = decimal.Parse(dt.Rows[0]["SoLuong"].ToString());
                    this.PhanTramDuocHuong = decimal.Parse(dt.Rows[0]["PhanTramDuocHuong"].ToString());
                    this.DonGiaBHYT = decimal.Parse(dt.Rows[0]["DonGiaBHYT"].ToString());
                    this.ThanhTienBHYT = decimal.Parse(dt.Rows[0]["ThanhTienBHYT"].ToString());
                    this.BHYTThanhToan = decimal.Parse(dt.Rows[0]["BHYTThanhToan"].ToString());
                    this.NguonKhac = decimal.Parse(dt.Rows[0]["NguonKhac"].ToString());
                
                    this.NguoiBenhTra = decimal.Parse(dt.Rows[0]["NguoiBenhTra"].ToString());
                    this.ChiPhiNgoaiDinhSuat = decimal.Parse(dt.Rows[0]["ChiPhiNgoaiDinhSuat"].ToString());
                }
                catch (Exception ex) { }
                this.MaNhom1 = dt.Rows[0]["MaNhom1"].ToString();
              
                   
             
            
                this.MaNhom2 = dt.Rows[0]["MaNhom2"].ToString();
                 this.MaLoaiChiPhi = dt.Rows[0]["MaLoaiChiPhi"].ToString();

                 this.VTYTDichVuKTC =bool.Parse( dt.Rows[0]["VTYTDichVuKTC"].ToString());
                 this.DichVuKTC = bool.Parse(dt.Rows[0]["DichVuKTC"].ToString());
                 this.GhiChu = dt.Rows[0]["GhiChu"].ToString();
               
            }
            return (object)this;
          

         
    }
}
}



