//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventory.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DM_Vat_Tu
    {
        public string Ten_vat_tu { get; set; }
        public string Ma_vat_tu { get; set; }
        public Nullable<int> ID_Don_vi_tinh { get; set; }
        public string Mo_ta { get; set; }
        public Nullable<bool> Trang_thai { get; set; }
        public Nullable<long> Don_gia { get; set; }
        public Nullable<bool> Da_xuat { get; set; }
        public int ID_Vat_tu { get; set; }
        public string Ten_khong_dau { get; set; }
    
        public virtual DM_Don_vi_tinh DM_Don_vi_tinh { get; set; }
    }
}
