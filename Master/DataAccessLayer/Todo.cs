//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Todo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Todo()
        {
            this.TimeRecord = new HashSet<TimeRecord>();
        }
    
        public long StatusId { get; set; }
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public long ProjectId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeRecord> TimeRecord { get; set; }
        public virtual Status Status { get; set; }
        public virtual Project Project { get; set; }
        public long TimeInSeconds { get; set; }
        public string Comment { get; set; }
    }
}