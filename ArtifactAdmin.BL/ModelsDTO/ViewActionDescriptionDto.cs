// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewActionDescriptionDto.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ViewActionDescriptionDto type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.ModelsDTO
{
    using System;
    using System.Collections.Generic;

    public class ViewActionDescriptionDto
    {
        public ActionDescriptionDto ActionDescriptionDto { get; set; }

        public List<MapZoneDto> MapZoneDto { get; set; }

        public List<ActionTemplateDto> ActionTemplateDto { get; set; }

        public string ActionName { get; set; }

        public string NameZone { get; set; }
    }
}