﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ArtifactAdmin.Models
{[MetadataType(typeof(ArtifactTypeMetaData))]
    public partial class ArtifactType
    {
    }
public class ArtifactTypeMetaData 
{
    public int id { get; set; }
    [Required(ErrorMessageResourceName = "RequiredName",
    ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
    [Display(Name = "Назва")]
    [StringLength(50, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
    public string Name { get; set; }
    [Required(ErrorMessageResourceName = "RequiredIcon",
         ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
    [Display(Name = "Іконка")]
    public string Icon { get; set; }
    [Required(ErrorMessageResourceName = "RequiredDescription",
         ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
    [Display(Name = "Опис")]
    [StringLength(50, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
    public string Descrioption { get; set; }
}
}