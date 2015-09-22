using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.MapHelpers;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.BL.Utils;
using ArtifactAdmin.DAL.Models;
using AutoMapper;

namespace ArtifactAdmin.BL.Services
{
    public class ZoneCoordinatesService : IZoneCoordinatesService
    {
        private readonly IRepository<MapInfo> mapInfoRepository;
        private readonly IRepository<ZoneCoordinat> zoneCoordinatRepository;
        private readonly IRepository<MapZone> mapZoneRepository;

        public ZoneCoordinatesService(IRepository<MapInfo> mapInfoRepository, IRepository<ZoneCoordinat> zoneCoordinatRepository, IRepository<MapZone> mapZoneRepository) 
        {
            this.mapInfoRepository = mapInfoRepository;
            this.zoneCoordinatRepository = zoneCoordinatRepository;
            this.mapZoneRepository = mapZoneRepository;
        }

        public IEnumerable<ZoneCoordinatDto> GetZoneCoordinatByMapInfoId(int? id)
        {
            if (this.mapInfoRepository.GetAll().FirstOrDefault(s => s.Id == id) == null)
            {
                throw new Exception(string.Format("Mapinfo with id({0}) no exist", id));
            }
            var zoneCoordinates = this.zoneCoordinatRepository.GetAll().Where(z => z.MapInfo1.Id == id).ToList();
            return Mapper.Map<List<ZoneCoordinatDto>>(zoneCoordinates);
        }


        public IEnumerable<ZoneCoordinatDto> GetZoneCoordinatInfo(int? id)
        {
            if (this.mapInfoRepository.GetAll().FirstOrDefault(s => s.Id == id) == null)
            {
                throw new Exception(string.Format("Mapinfo with id({0}) no exist", id));
            }
            return Mapper.Map<List<ZoneCoordinatDto>>(this.zoneCoordinatRepository.GetAll().Where(z => z.MapInfo1.Id == id));
        }

        public void Delete(int id)
        {
            var allZonesCoordinates = zoneCoordinatRepository.GetAll().Where(z => z.MapInfo1.Id == id);
            foreach (var zoneCoordinates in allZonesCoordinates)
            {
                zoneCoordinatRepository.DeleteWithOutSave(zoneCoordinates);    
            }
            this.zoneCoordinatRepository.SaveChanges();
        }

        public void CreateZoneCoordinates(int id)
        {
            var mapInfo = this.mapInfoRepository.GetAll().FirstOrDefault(s => s.Id == id);
            if (mapInfo == null)
            {
                throw new Exception(string.Format("Mapinfo with id({0}) no exist", id));
            }
            var zoneLines = ImageHelper.CreateLinesFromImage(mapInfo.ImagePath);

            foreach (var color in zoneLines.Keys)
            {
                zoneCoordinatRepository.Insert(new ZoneCoordinat()
                    {
                        Coordinates = zoneLines[color].Serialize(),
                        MapZone1 = mapZoneRepository.GetAll().FirstOrDefault(c => c.Color == color),
                        MapInfo1 = mapInfo
                    });
            }
        }

        
    }
}