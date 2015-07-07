// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewActionTemplateDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewActionTemplateDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class ViewActionTemplateDto
    {
        public ActionTemplateDto ActionTemplateDto { get; set; }

        public List<ActionTemplateResultDto> ActionTemplateResults { get; set; }
       
        [Display(Name = "Введіть ймовірність")]
        [RegularExpression(@"0.\d+", ErrorMessage = "Введіть число від 0 до 1 !")]
        public string OneProbability { get; set; }
    }
}