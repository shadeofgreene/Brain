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
    
    public partial class request
    {
        public int requestId { get; set; }
        public Nullable<int> repId { get; set; }
        public Nullable<int> stock_pointId { get; set; }
        public Nullable<int> request_statusId { get; set; }
        public string comments_from_rep { get; set; }
        public string comments_from_controller { get; set; }
        public Nullable<int> tool_typeId { get; set; }
        public Nullable<int> partId { get; set; }
        public Nullable<int> drill_sizeId { get; set; }
        public Nullable<int> threadId { get; set; }
        public Nullable<int> styleId { get; set; }
        public Nullable<System.DateTime> date_needed { get; set; }
        public Nullable<int> toolId_to_fulfill { get; set; }
        public Nullable<System.DateTime> date_to_arrive { get; set; }
        public Nullable<int> transit_serviceID { get; set; }
        public string transit_dropoff_instructions { get; set; }
    }
}