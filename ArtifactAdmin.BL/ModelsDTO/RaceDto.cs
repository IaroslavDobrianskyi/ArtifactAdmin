// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RaceDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the RaceDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RaceDto
    {
        [Required(ErrorMessageResourceName = "RequiredDescription",
            ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Опис")]
        [StringLength(500, ErrorMessageResourceName = "StringLength",
            ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string Description { get; set; }
        
        public int id { get; set; }
        
        [Required]
        public long Characreristics { get; set; }
        
        [Required]
        public long CharacteristicsLevelModifier { get; set; }
        
        [Required]
        public long Predisposition { get; set; }

        [Required]
        public long Properties { get; set; }
        
        [Display(Name = "Іконка")]
        public string Icon { get; set; }

        public string NewIcon { get; set; }
    }
}