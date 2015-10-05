// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapObjectService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the MapObjectService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.DAL.Models;
using AutoMapper;

namespace ArtifactAdmin.BL.Services
{
    public class MapObjectService : IMapObjectService
    {
        private readonly IRepository<MapObject> mapObjectRepository;

        public MapObjectService(IRepository<MapObject> mapObjectRepository) 
        {
            this.mapObjectRepository = mapObjectRepository;
        }

        public IEnumerable<MapObjectDto> GetAll()
        {
            return Mapper.Map<List<MapObjectDto>>(this.mapObjectRepository.GetAll());
        }

        public MapObjectDto GetById(int? id)
        {
            return Mapper.Map<MapObjectDto>(this.mapObjectRepository.GetAll().FirstOrDefault(s => s.Id == id));
        }

        public MapObjectDto Create(MapObjectDto mapObjectDto)
        {
            var mapObjects = Mapper.Map<MapObject>(mapObjectDto);
            this.mapObjectRepository.Insert(mapObjects);

            return Mapper.Map<MapObjectDto>(mapObjects);
        }

        public MapObjectDto Update(MapObjectDto mapObjectDto)
        {
            var mapObjects = Mapper.Map<MapObject>(mapObjectDto);
            this.mapObjectRepository.Update(mapObjects);
            return Mapper.Map<MapObjectDto>(mapObjects);
        }

        public void Delete(int? id)
        {
            var mapObjects = this.mapObjectRepository.GetAll().FirstOrDefault(s => s.Id == id);
            this.mapObjectRepository.Delete(mapObjects);
        }
    }
}