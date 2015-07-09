// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepTemplateDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepTemplateDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ValidationConstellation;

    public class StepTemplateDto
    {
        public int id { get; set; }

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

        public Nullable<int> Desire { get; set; }
        
        [Required(ErrorMessageResourceName = "RequiredName",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Назва")]
        [StringLength(200, ErrorMessageResourceName = "StringLength",
    ErrorMessageResourceType = typeof(ValidationStrings))]

        public string Name { get; set; }
        
        [Display(Name = "Об'єкти кроку")]
        public virtual ICollection<StepObjectStepTemplateDto> StepObjectStepTemplates { get; set; }

        [Display(Name = "Дії кроку")]
        public virtual ICollection<StepTemplateActionTemplateDto> StepTemplateActionTemplates { get; set; }
        
        [Display(Name="Бажання")]
        public virtual DesireDto Desire1 { get; set; }
    }
}