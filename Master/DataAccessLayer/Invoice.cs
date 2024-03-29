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
    
    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            this.Payment = new HashSet<Payment>();
            this.InvoiceProjectLink = new HashSet<InvoiceProjectLink>();
        }
    
        public string Title { get; set; }
        public string DeadLine { get; set; }
        public long CurrencyId { get; set; }
        public long UserTeamLinkId { get; set; }
        public long Id { get; set; }
    
        public virtual Currency Currency { get; set; }
        public virtual UserTeamLink UserTeamLink { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceProjectLink> InvoiceProjectLink { get; set; }
    }
}
