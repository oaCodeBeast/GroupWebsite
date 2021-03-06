﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupWebsiteRestart
{
    public class ResourceMetaData
    {
        public System.Guid ResourcesID { get; set; }
        [Required(ErrorMessage = "*Required")]
        [StringLength(50, ErrorMessage = "Text must be 50 characters or less")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string URL { get; set; }
        [Required(ErrorMessage = "*Required")]
        public bool IsActive { get; set; }
    }
    [MetadataType(typeof(ResourceMetaData))]
    public partial class Resource { }
}