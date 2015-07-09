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
    using System;
    using System.Collections.Generic;
    
    public class ViewStepTemplateDto
    {
        public StepTemplateDto StepTemplate { get; set; }

        public List<StepObjectTypeDto> StepObjectType { get; set; }
        
        public List<ViewStepObjectDto> StepObject { get; set; }

        public List<ViewStepObjectDto> SelectedStepObject { get; set; }

        public List<DesireDto> DesireDto { get; set; }

        public string NameDesire { get; set; }
    }
}