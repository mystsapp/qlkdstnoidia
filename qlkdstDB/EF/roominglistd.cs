//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace qlkdstDB.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class roominglistd
    {
        public decimal id_roomlistd { get; set; }
        public Nullable<decimal> id_roomlist { get; set; }
        public string sophong { get; set; }
        public Nullable<decimal> id_dsk { get; set; }
        public string loaiphong { get; set; }
    
        public virtual roominglist roominglist { get; set; }
    }
}
