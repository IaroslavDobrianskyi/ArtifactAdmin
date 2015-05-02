using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ArtifactAdmin.Models
{
    [MetadataType(typeof(StepTemplateMetaData))]
    public partial class StepTemplate { }
    public class StepTemplates
    {
        public StepTemplate stepTemplate { get; set; }
        public List<StepObjectType> stepObjectType { get; set; }
        public List<ViewStepObject> stepObject { get; set; }
   //     [Required(ErrorMessageResourceName = "RequiredList",
   //ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public List<ViewStepObject> selectedStepObject { get;set; }
    }
public class StepTemplateMetaData
{
    [Required(ErrorMessageResourceName = "RequiredDescription",
       ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
    [Display(Name = "Опис")]
    [StringLength(500, ErrorMessageResourceName = "StringLength",
ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
    public string Description { get; set; }

    [Required(ErrorMessageResourceName = "RequiredText",
      ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
    [Display(Name = "Текст")]
    public string StepText { get; set; }

    [Required(ErrorMessageResourceName = "RequiredName",
   ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
    [Display(Name = "Назва")]
    [StringLength(200, ErrorMessageResourceName = "StringLength",
ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
    public string Name { get; set; }
   [Display(Name = "Об'єкти кроку")]
    public virtual ICollection<StepObjectStepTemplate> StepObjectStepTemplates { get; set; }
}
}