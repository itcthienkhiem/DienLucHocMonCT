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
    
    public partial class Chi_Tiet_Kho_Phu
    {
        public int ID_chi_tiet_kho_phu { get; set; }
        public Nullable<int> ID_kho_phu { get; set; }
        public string Ma_vat_tu { get; set; }
        public Nullable<decimal> So_luong { get; set; }
        public Nullable<int> ID_chat_luong { get; set; }
        public Nullable<decimal> Don_gia { get; set; }
        public Nullable<decimal> Thanh_tien { get; set; }
        public Nullable<int> ID_don_vi_tinh { get; set; }
    }
}
