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
    using System;
    using System.Collections.Generic;
    
    public class ViewMapZoneDto
    {
        public MapZoneDto MapZone { get; set; }

        public List<MapObjectDto> MapObject { get; set; }

        public List<MapObjectProbabilityDto> SelectedMapObject { get; set; }

        public List<MapObjectProbabilityDto> Probability { get; set; }
    }
}