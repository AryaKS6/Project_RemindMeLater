//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RemindMe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class remindme
    {
        public int id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<System.TimeSpan> time { get; set; }
        public string message { get; set; }
        public string RemindType { get; set; }
    }
}
