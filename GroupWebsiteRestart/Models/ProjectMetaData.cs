using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//added
using GroupWebsiteRestart;

namespace GroupWebsiteRestart
{
    public class ProjectMetaData
    {
        public Guid ProjectID { get; set; }

        [Required(ErrorMessage = "* Required")]
        [StringLength(50, ErrorMessage = "* Name must be 50 characters or less.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Description { get; set; }

        [StringLength(50, ErrorMessage = "* URL must be 50 characters or less.")]
        public string URL { get; set; }

        public bool IsActive { get; set; }

        [StringLength(50, ErrorMessage = "* Project Picture URL must be 50 characters or less.")]
        public string ProjectPic { get; set; }

        public DateTime DatePublished { get; set; }

        public virtual ICollection<LinkingTableForMPB> LinkingTableForMPBs { get; set; }

    }
    [MetadataType(typeof(ProjectMetaData))]
    public partial class Project { }
}