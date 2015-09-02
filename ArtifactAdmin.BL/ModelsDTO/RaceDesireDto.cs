// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RaceDesireDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the RaceDesireDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;

    public class RaceDesireDto
    {
        public int Id { get; set; }

        public int RaceId { get; set; }

        public int DesireId { get; set; }

        public double Probability { get; set; }

        public int DefaultValue { get; set; }

        public double? Deviation { get; set; }

        public virtual DesireDto Desire { get; set; }

        public virtual RaceDto Race { get; set; }
    }
}