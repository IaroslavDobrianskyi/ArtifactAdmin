using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.DAL.Models;
using AutoMapper;

namespace ArtifactAdmin.BL.Services
{
    public class MapInfoService : IMapInfoService
    {
        private readonly IRepository<MapInfo> mapInfoRepository;
        private readonly IRepository<ZoneCoordinat> zoneCoordinatRepository;

        public MapInfoService(IRepository<MapInfo> mapInfoRepository, IRepository<ZoneCoordinat> zoneCoordinatRepository) 
        {
            this.mapInfoRepository = mapInfoRepository;
            this.zoneCoordinatRepository = zoneCoordinatRepository;
        }

        public MapInfoDto Create(MapInfoDto mapInfoDto)
        {
            var mapInfo = Mapper.Map<MapInfo>(mapInfoDto);
            this.mapInfoRepository.Insert(mapInfo);
            return Mapper.Map<MapInfoDto>(mapInfo);
        }

        public IEnumerable<MapInfoDto> GetAll()
        {
            return Mapper.Map<List<MapInfoDto>>(this.mapInfoRepository.GetAll());
        }

        public MapInfoDto GetById(int? id)
        {
            return Mapper.Map<MapInfoDto>(this.mapInfoRepository.GetAll().FirstOrDefault(s => s.Id == id));
        }

        public MapInfoDto Update(MapInfoDto mapInfoDto)
        {
            var mapInfo = Mapper.Map<MapInfo>(mapInfoDto);
            this.mapInfoRepository.Update(mapInfo);
            return Mapper.Map<MapInfoDto>(mapInfo);
        }

        public void Delete(int? id)
        {
            var mapInfo = this.mapInfoRepository.GetAll().FirstOrDefault(s => s.Id == id);
            this.mapInfoRepository.Delete(mapInfo);
        }
    }
}