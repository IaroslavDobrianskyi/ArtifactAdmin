// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepObjectStepTemplateDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepObjectStepTemplateDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    public class StepObjectStepTemplateDto
    {
        public int Id { get; set; }
        
        public int StepObject { get; set; }
        
        public int StepTemplate { get; set; }

        public virtual StepObjectDto StepObject1 { get; set; }
        
        public virtual StepTemplateDto StepTemplate1 { get; set; }
    }
}