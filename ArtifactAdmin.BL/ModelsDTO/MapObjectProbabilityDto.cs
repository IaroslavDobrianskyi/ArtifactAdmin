﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapObjectProbabilityDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the MapObjectProbabilityDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    public class MapObjectProbabilityDto
    {
        public int Id { get; set; }

        public int MapObject { get; set; }

        public int MapZone { get; set; }

        public double Probability { get; set; }

        public virtual MapObjectDto MapObject1 { get; set; }

        public virtual MapZoneDto MapZone1 { get; set; }
    }
}