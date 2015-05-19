using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.DAL
{
     [MetadataType(typeof(StepObjectTypeMetaData))]
    public partial class StepObjectType
    {
    }
public class StepObjectTypeMetaData
{
    public int Id { get; set; }
    [Required(ErrorMessageResourceName = "RequiredName",
    ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
    [Display(Name = "Назва")]
    [StringLength(100, ErrorMessageResourceName = "StringLength",
ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
    public string Name { get; set; }
}
}