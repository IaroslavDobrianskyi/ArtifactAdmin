// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionTemplateDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionTemplateDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class ActionTemplateDto
    {
        public int id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredName",
    ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Назва")]
        [StringLength(200, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string Name { get; set; }
        public double PredispositionResult { internal get; set; }
    }
}