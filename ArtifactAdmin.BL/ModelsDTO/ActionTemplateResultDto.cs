// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionTemplateResultDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionTemplateResultDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.Collections.Generic; 
    using System.ComponentModel.DataAnnotations;

    public class ActionTemplateResultDto
    {
        public int id { get; set; }
        public double PredispositionResultModifier { get; set; }
        public double ExperienceModifier { get; set; }
        public double ArtifactPosibility { get; set; }
        public double GoldModifier { get; set; }

        public virtual ICollection<ActionTemplateDto> ActionTemplates { get; set; }
    }
}