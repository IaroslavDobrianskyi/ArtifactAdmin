using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.DAL
{
    [MetadataType(typeof(StepObjectMetaData))]
    public partial class StepObject
    {
    }
    public class StepObjectMetaData
    {
        public int Id { get; set; }
        public int StepObjectType { get; set; }
        [Required(ErrorMessageResourceName = "RequiredName",
  ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Назва")]
        [StringLength(50, ErrorMessageResourceName = "StringLength",
   ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceName = "RequiredDescription",
         ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Опис")]
        [StringLength(100, ErrorMessageResourceName = "StringLength",
   ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string Description { get; set; }
        [Required(ErrorMessageResourceName = "RequiredIcon",
       ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Іконка")]
        public string Icon { get; set; }
         [Display(Name = "Тип")]
        public virtual StepObjectType StepObjectType1 { get; set; }
    }
}