// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestTemplateDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the QuestTemplateDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ValidationConstellation;

    public class QuestTemplateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredName",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Назва")]
        [StringLength(500, ErrorMessageResourceName = "StringLength",
    ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "RequiredDescription",
      ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Опис")]
        [StringLength(10, ErrorMessageResourceName = "StringLength",
    ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Description { get; set; }

        [Display(Name = "Кроки")]
        public virtual ICollection<QuestTemplateStepTemplateDto> QuestTemplateStepTemplates { get; set; }

        [Display(Name = "Всі кроки")]
        public List<StepTemplateDto> AllSteps { get; set; }

        [Display(Name = "Вибрані кроки")]
        public List<StepTemplateDto> SelectedSteps { get; set; } 
    }
}