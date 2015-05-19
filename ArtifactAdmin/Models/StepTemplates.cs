namespace ArtifactAdmin.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ValidationConstellation;

    [MetadataType(typeof(StepTemplateMetaData))]
    public partial class StepTemplate { }
    public class StepTemplates
    {
        public StepTemplate StepTemplate { get; set; }
        public List<StepObjectType> StepObjectType { get; set; }
        public List<ViewStepObject> StepObject { get; set; }
   // [Required(ErrorMessageResourceName = "RequiredList",
   // ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public List<ViewStepObject> SelectedStepObject { get; set; }
    }
public class StepTemplateMetaData
{
    [Required(ErrorMessageResourceName = "RequiredDescription",
       ErrorMessageResourceType = typeof(ValidationStrings))]
    [Display(Name = "Опис")]
    [StringLength(500, ErrorMessageResourceName = "StringLength",
ErrorMessageResourceType = typeof(ValidationStrings))]
    public string Description { get; set; }

    [Required(ErrorMessageResourceName = "RequiredText",
      ErrorMessageResourceType = typeof(ValidationStrings))]
    [Display(Name = "Текст")]
    public string StepText { get; set; }

    [Required(ErrorMessageResourceName = "RequiredName",
   ErrorMessageResourceType = typeof(ValidationStrings))]
    [Display(Name = "Назва")]
    [StringLength(200, ErrorMessageResourceName = "StringLength",
ErrorMessageResourceType = typeof(ValidationStrings))]
    public string Name { get; set; }
   [Display(Name = "Об'єкти кроку")]
    public virtual ICollection<StepObjectStepTemplate> StepObjectStepTemplates { get; set; }
}
}