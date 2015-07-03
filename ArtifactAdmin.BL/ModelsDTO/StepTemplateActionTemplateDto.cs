// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepTemplateActionTemplateDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepTemplateActionTemplateDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    
    public class StepTemplateActionTemplateDto
    {
        public int id { get; set; }
        public int StepTemplate { get; set; }
        public int ActionTemplate { get; set; }

        public virtual ActionTemplateDto ActionTemplate1 { get; set; }
        public virtual StepTemplateDto StepTemplate1 { get; set; }
    }
}