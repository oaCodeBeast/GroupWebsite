//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GroupWebsiteRestart
{
    using System;
    using System.Collections.Generic;
    
    public partial class BlogPost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BlogPost()
        {
            this.LinkingTableForMPBs = new HashSet<LinkingTableForMPB>();
        }
    
        public System.Guid BlogID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Picture { get; set; }
        public bool HasPicture { get; set; }
        public System.DateTime Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LinkingTableForMPB> LinkingTableForMPBs { get; set; }
    }
}
