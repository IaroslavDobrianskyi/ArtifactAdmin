// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.ModelsDTO.FlowItems
{
    public class StepDto
    {   
        public int Id { get; set; }

        public int UserArtifact { get; set; }

        public int? ActiveActionInFlow { get; set; }

        public string Text { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public int? Desire { get; set; }

        public bool? IsKey { get; set; }

        public int Duration { get; set; }
    }
}