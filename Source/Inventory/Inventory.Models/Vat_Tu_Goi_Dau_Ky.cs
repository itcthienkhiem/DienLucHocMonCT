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
    
    public partial class Vat_Tu_Goi_Dau_Ky
    {
        public int ID_VT_Goi_Dau { get; set; }
        public string Ma_vat_tu { get; set; }
        public Nullable<int> So_Luong { get; set; }
        public Nullable<int> ID_ky { get; set; }
    
        public virtual DM_Vat_Tu DM_Vat_Tu { get; set; }
        public virtual Ky Ky { get; set; }
    }
}
