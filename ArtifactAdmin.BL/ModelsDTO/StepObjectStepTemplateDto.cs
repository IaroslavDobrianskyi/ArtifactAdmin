﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepObjectStepTemplateDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepObjectStepTemplateDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    
    public class StepObjectStepTemplateDto
    {
        public int id { get; set; }
        
        public int StepObject { get; set; }
        
        public int StepTemplate { get; set; }

        public virtual StepObjectDto StepObject1 { get; set; }
        
        public virtual StepTemplateDto StepTemplate1 { get; set; }
    }
}