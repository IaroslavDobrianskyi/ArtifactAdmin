using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.MapHelpers;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.BL.Utils.GeneratingMiddlePoints;
using ArtifactAdmin.DAL.Models;
using AutoMapper;

namespace ArtifactAdmin.BL.Services
{
    public class MapInfoDimensionService : IMapInfoDimensionService 
    {
        private readonly IRepository<MapInfoDimension> mapInfoDimensionRepository;
        private readonly IRepository<MapInfo> mapInfoRepository;
        private readonly IRepository<MapZone> mapZoneRepository;
        private readonly IRepository<MiddlePoint> middlePointRepository;

        public MapInfoDimensionService(IRepository<MapInfoDimension> mapInfoDimensionRepository, IRepository<MapZone> mapZoneRepository, IRepository<MiddlePoint> middlePointRepository, IRepository<MapInfo> mapInfoRepository) 
        {
            this.mapInfoDimensionRepository = mapInfoDimensionRepository;
            this.mapZoneRepository = mapZoneRepository;
            this.middlePointRepository = middlePointRepository;
            this.mapInfoRepository = mapInfoRepository;
        }

        public IEnumerable<MapInfoDimensionDto> GetAll()
        {
            return Mapper.Map<List<MapInfoDimensionDto>>(this.mapInfoDimensionRepository.GetAll());
        }

        public MapInfoDimensionDto GetById(int? id)
        {
            return Mapper.Map<MapInfoDimensionDto>(this.mapInfoDimensionRepository.GetAll().FirstOrDefault(s => s.Id == id.Value));
        }

        public void Create(MapInfoDimensionDto mapInfoDimensionDto)
        {
            var mapInfoDimension = Mapper.Map<MapInfoDimension>(mapInfoDimensionDto);
            this.mapInfoDimensionRepository.Insert(mapInfoDimension);

            var mapInfo = this.mapInfoRepository.GetAll().Where(d => d.Id == mapInfoDimension.MapInfo).FirstOrDefault();

            var middlePoints = MapMiddlePointsGenerator.GetMiddlePoints(mapInfo.ImagePath, mapInfoDimension.Dimension);



            foreach (var key in middlePoints.Keys)
            {
                middlePointRepository.Insert(new MiddlePoint()
                    {
                        MapInfoDimension = mapInfoDimension.Id,
                        X = key.X,
                        Y = key.Y,
                        RelatedCoordinates = middlePoints[key].Serialize()
                    });
            }

        }

        public Dictionary<SimplePoint, List<SimplePoint>> GetMiddlePointsForDimension(int? id)
        {
            var middlePoints = this.middlePointRepository.GetAll().Where(x => x.MapInfoDimension == id.Value);
            var retVal = new Dictionary<SimplePoint, List<SimplePoint>>();

            foreach (var c in middlePoints)
            {
                
                retVal.Add(new SimplePoint()
                {
                    X = c.X,
                    Y = c.Y,
                }, LinesContainer.DeserializeAndGetPointsList(c.RelatedCoordinates));
            }
            return retVal;
        }
    }
}