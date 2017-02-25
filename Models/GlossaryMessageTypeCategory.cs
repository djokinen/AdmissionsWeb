//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdmissionsWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GlossaryMessageTypeCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GlossaryMessageTypeCategory()
        {
            this.GlossaryMessages = new HashSet<GlossaryMessage>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid GlossaryMessageTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Modified { get; set; }
    
        public virtual GlossaryMessageType GlossaryMessageType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GlossaryMessage> GlossaryMessages { get; set; }
    }
}
