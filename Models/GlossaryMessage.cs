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
    
    public partial class GlossaryMessage
    {
        public System.Guid Id { get; set; }
        public System.Guid GlossaryMessageTypeCategoryId { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public bool IsBulletPoint { get; set; }
        public bool Enabled { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Modified { get; set; }
    
        public virtual GlossaryMessageTypeCategory GlossaryMessageTypeCategory { get; set; }
    }
}
