// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapZoneService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IMapZoneService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IMapZoneService
    {
            IEnumerable<MapZoneDto> GetAll();

            ViewMapZoneDto GetViewById(int? id);

            MapZoneDto GetById(int? id);
        
            MapZoneDto GetByIdDesire(int id);

            ViewMapZoneDto GetByList(MapZoneDto mapZoneDto, string[] obj, string[] probability);
        
            MapZoneDto Create(MapZoneDto mapZoneDto, string[] obj, string[] probability);

            MapZoneDto Update(MapZoneDto mapZOneDto, string[] obj, string[] probability);

            void UpdateDesireMapZone(int id, int[] desireMapZoneId, string[] modifiers);
     
            void Delete(int? id);
            void EnshureAllZonesPresentInMapInfo(int? mapInfoId);
    }
}