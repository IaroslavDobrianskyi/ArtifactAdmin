// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewMapZoneDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewMapZoneDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.ModelsDTO
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ViewMapZoneDto
    {
        public MapZoneDto MapZone { get; set; }

        public List<MapObjectDto> MapObject { get; set; }

        public List<MapObjectProbabilityDto> SelectedMapObject { get; set; }

        public List<MapObjectProbabilityDto> Probability { get; set; }

        [Display(Name = "Введіть ймовірність")]
        [RegularExpression(@"0\.\d+", ErrorMessage = "Введіть число від 0 до 1 !")]
        public string OneProbability { get; set; }
    }
}