// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewStepObjectDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewStepObjectDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    public class ViewStepObjectDto
    {
        public StepObjectDto StepObjectDto { get; set; }
        
        public string IdObjType { get; set; }
    }
}