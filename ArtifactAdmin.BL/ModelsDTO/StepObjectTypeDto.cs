// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepObjectTypeDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepObjectTypeDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using ValidationConstellation;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class StepObjectTypeDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessageResourceName = "RequiredName",
        ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Назва")]
        [StringLength(100, ErrorMessageResourceName = "StringLength",
        ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Name { get; set; }
    }
}