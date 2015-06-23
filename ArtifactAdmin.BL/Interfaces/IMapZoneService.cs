// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapZoneService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IMapZoneService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using ModelsDTO;

        public interface IMapZoneService
    {
            IEnumerable<MapZoneDto> GetAll();

            ViewMapZoneDto GetViewById(int? id);

            MapZoneDto GetById(int? id);

            MapZoneDto Create(MapZoneDto mapZoneDto, string[] obj, string[] probability);

            MapZoneDto Update(MapZoneDto mapZOneDto, string[] obj, string[] probability);

            void Delete(int? id);
    }
}