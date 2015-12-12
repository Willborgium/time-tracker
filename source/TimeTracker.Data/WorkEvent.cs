//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeTracker.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkEvent
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int Type { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<decimal> Duration { get; set; }
        public string Description { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual WorkEventType WorkEventType { get; set; }
    }
}