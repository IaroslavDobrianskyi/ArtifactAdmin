// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapObjectService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IMapObjectService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IMapObjectService
    {
        IEnumerable<MapObjectDto> GetAll();
        
        MapObjectDto GetById(int? id);

        MapObjectDto Create(MapObjectDto mapObjectDto);

        MapObjectDto Update(MapObjectDto mapObjectDto);

        void Delete(int? id);
    }
}
