// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestTemplateStepTemplateDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the QuestTemplateStepTemplateDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
   
    public class QuestTemplateStepTemplateDto
    {
        public int Id { get; set; }

        public int StepTemplate { get; set; }

        public int QuestTemaplate { get; set; }

        public int StepOrder { get; set; }
    }
}