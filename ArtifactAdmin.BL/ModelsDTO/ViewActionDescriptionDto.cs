// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewActionDescriptionDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewActionDescriptionDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class ViewActionDescriptionDto
    {
        public ActionDescriptionDto ActionDescriptionDto { get; set; }

        public List<MapZoneDto> MapZoneDto { get; set; }

        public List<ActionTemplateDto> ActionTemplateDto { get; set; }

        public List<RaceDto> RaceDto { get; set; }

        public List<ClassDto> ClassDto { get; set; } 

        public string ActionName { get; set; }

        public string NameZone { get; set; }

        public string NameRace { get; set; }

        public string NameClass { get; set; }
    }
}