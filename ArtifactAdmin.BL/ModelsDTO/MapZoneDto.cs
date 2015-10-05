// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapZoneDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the MapZoneDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ValidationConstellation;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class MapZoneDto
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredZoneName",
   ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Назва зони")]
        [StringLength(50, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        public string ZoneName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredColor",
    ErrorMessageResourceType = typeof(ValidationStrings))]
        [Display(Name = "Колір")]
        [StringLength(10, ErrorMessageResourceName = "StringLength",
  ErrorMessageResourceType = typeof(ValidationStrings))]
        public string Color { get; set; }

        [Display(Name = "Об'єкти та імовірності")]
        public virtual ICollection<MapObjectProbabilityDto> MapObjectProbabilities { get; set; }

        public ViewDesireMapZoneDto ViewDesireMapZoneDto { get; set; }
    }
}