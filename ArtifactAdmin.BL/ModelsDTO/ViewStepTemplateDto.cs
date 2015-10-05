// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewStepTemplateDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewStepTemplateDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.ModelsDTO
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ViewStepTemplateDto
    {
        public StepTemplateDto StepTemplate { get; set; }

        [Display(Name = "Типи об'єктів")]
        public List<StepObjectTypeDto> StepObjectType { get; set; }

        [Display(Name = "Об'єкти")]
        public List<ViewStepObjectDto> StepObject { get; set; }

        [Display(Name = "Об'єкти кроку")]
        public List<ViewStepObjectDto> SelectedStepObject { get; set; }

        public List<DesireDto> DesireDto { get; set; }

        public string NameDesire { get; set; }
    }
}