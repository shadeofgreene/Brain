//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Brain.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cutter
    {
        public int cutterId { get; set; }
        public string cutter_name { get; set; }
        public Nullable<int> cutter_typeId { get; set; }
        public Nullable<decimal> cutter_diameter_decimal_inches { get; set; }
        public string cutter_diameter_fraction_inches { get; set; }
        public Nullable<int> cutter_diameter_mm { get; set; }
    }
}
