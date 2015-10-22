namespace ArtifactAdmin.BL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using DAL.Models;
    using Interfaces;
    using ModelsDTO;
    using Utils;
    using Utils.GeneratingMiddlePoints;
    using Utils.MapHelpers;

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



        public Dictionary<string, List<SimplePoint>> GetZoneValuesCoordinatByMapInfoId(int? id)
        {
            var dic = GetZoneIdCoordinatByMapInfoId(id);
            var retVal = new Dictionary<string, List<SimplePoint>>();

            var zonesInCoordinates = this.zoneCoordinatRepository.GetAll().Where(z => z.MapInfo1.Id == id)
                                  .Select(x => new
                                      {
                                          x.MapZone,
                                          x.MapZone1.Color
                                      });
            foreach (var zonesInCoordinate in zonesInCoordinates)
            {
                retVal.Add(zonesInCoordinate.Color,dic[zonesInCoordinate.MapZone]);
            }

            return retVal;
        }

        public Dictionary<int, List<SimplePoint>> GetZoneIdCoordinatByMapInfoId(int? id)
        {
            if (this.mapInfoRepository.GetAll().FirstOrDefault(s => s.Id == id) == null)
            {
                throw new Exception(string.Format("Mapinfo with id({0}) no exist", id));
            }
            var coordinates = this.zoneCoordinatRepository.GetAll().Where(z => z.MapInfo1.Id == id).ToList();
            //return Mapper.Map<List<ZoneCoordinatDto>>(zoneCoordinates);

            var dic = new Dictionary<int, List<SimplePoint>>();
            var count = 0;
            if (coordinates.Count() > 0)
            {
                foreach (var c in coordinates)
                {
                    dic.Add(c.MapZone, LinesContainer.DeserializeAndGetPointsList(c.Coordinates));
                }
                foreach (var key in dic.Keys)
                {
                    count += dic[key].Count;
                }
            }
            return dic;
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