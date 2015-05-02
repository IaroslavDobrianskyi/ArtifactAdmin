using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ArtifactAdmin.Models
{
     [MetadataType(typeof(StepObjectTypeMetaData))]
    public partial class StepObjectType
    {
    }
public class StepObjectTypeMetaData
{
    public int id { get; set; }
    [Required(ErrorMessageResourceName = "RequiredName",
    ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
    [Display(Name = "Назва")]
    [StringLength(100, ErrorMessageResourceName = "StringLength",
ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
    public string Name { get; set; }
}
}