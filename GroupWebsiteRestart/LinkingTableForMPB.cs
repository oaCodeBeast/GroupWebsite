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
    
    public partial class LinkingTableForMPB
    {
        public System.Guid MemberID { get; set; }
        public System.Guid ProjectID { get; set; }
        public System.Guid BlogID { get; set; }
    
        public virtual BlogPost BlogPost { get; set; }
        public virtual Member Member { get; set; }
        public virtual Project Project { get; set; }
    }
}
