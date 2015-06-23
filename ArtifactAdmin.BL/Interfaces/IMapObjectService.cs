// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapObjectService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IMapObjectService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using ModelsDTO;

    public interface IMapObjectService
    {
        IEnumerable<MapObjectDto> GetAll();
        
        MapObjectDto GetById(int? id);

        MapObjectDto Create(MapObjectDto mapObjectDto);

        MapObjectDto Update(MapObjectDto mapObjectDto);

        void Delete(int? id);
    }
}
