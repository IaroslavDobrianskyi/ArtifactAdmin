// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewStepActionTemplateDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewStepActionTemplateDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class ViewStepActionTemplateDto
    {
        public StepTemplateDto StepTemplateDto { get; set; }

        public List<ActionTemplateDto> ActionTemplate { get; set; }

        public List<ActionTemplateDto> SelectedActionTemplate { get; set; }
    }
}