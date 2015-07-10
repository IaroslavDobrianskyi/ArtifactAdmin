// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapZoneDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the MapZoneDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
   
    public class MapZoneDto
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredZoneName",
   ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Назва зони")]
        [StringLength(50, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string ZoneName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredColor",
    ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        [Display(Name = "Колір")]
        [StringLength(10, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationConstellation.ValidationStrings))]
        public string Color { get; set; }

        [Display(Name = "Об'єкти та імовірності")]
        public virtual ICollection<MapObjectProbabilityDto> MapObjectProbabilities { get; set; }
    }
}