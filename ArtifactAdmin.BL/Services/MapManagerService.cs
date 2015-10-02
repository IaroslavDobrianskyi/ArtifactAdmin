using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.MapHelpers;
using ArtifactAdmin.BL.Utils.GeneratingMiddlePoints;
using ArtifactAdmin.DAL.Models;

namespace ArtifactAdmin.BL.Services
{
    public class MapManagerService : IMapManagerService
    {
        private readonly IRepository<MapInfo> mapInfoRepository;
        private readonly IRepository<ZoneCoordinat> zoneCoordinatRepository;
        private readonly ICacheService cacheService;
        private readonly IZoneCoordinatesService zoneCoordinatesService;
        private readonly IMapInfoDimensionService mapInfoDimensionService;
        private readonly IDimentionRadiusService dimentionRadiusService;
        private readonly IMiddlePointNeighborsService middlePointNeighborsService;

        public MapManagerService(IRepository<MapInfo> mapInfoRepository,
                                 IRepository<ZoneCoordinat> zoneCoordinatRepository,
                                 ICacheService cacheService,
                                 IZoneCoordinatesService zoneCoordinatesService,
                                 IMapInfoDimensionService mapInfoDimensionService,
                                 IDimentionRadiusService dimentionRadiusService,
                                 IMiddlePointNeighborsService middlePointNeighborsService)
        {
            this.mapInfoRepository = mapInfoRepository;
            this.zoneCoordinatRepository = zoneCoordinatRepository;
            this.cacheService = cacheService;
            this.zoneCoordinatesService = zoneCoordinatesService;
            this.mapInfoDimensionService = mapInfoDimensionService;
            this.dimentionRadiusService = dimentionRadiusService;
            this.middlePointNeighborsService = middlePointNeighborsService;
        }

        public MapManager GetFirstMapManager()
        {
            MapManager retVal = null;
            var firstMapInfo = mapInfoRepository.GetAll().OrderBy(x => x.Id).FirstOrDefault();
            if (firstMapInfo != null)
            {
                retVal = GetMapManager(firstMapInfo.Id);
            }
            return retVal;
        }


        public MapManager GetMapManager(int mapId)
        {
            var retVal = cacheService.GetOrSet(string.Format("MapManager_{0}", mapId), () =>
                {
                    var mapInfo = mapInfoRepository.GetAll().Where(x => x.Id == mapId).FirstOrDefault();
                    var mapManager = new MapManager(mapInfo.Width, mapInfo.Height);
                    var coordinates = zoneCoordinatesService.GetZoneIdCoordinatByMapInfoId(mapId);

                    foreach (var coordinateKey in coordinates.Keys)
                    {
                        mapManager.InitZoneCoordinates(coordinateKey, coordinates[coordinateKey]);
                    }

                    var dimentions = mapInfoDimensionService.GetAll();

                    foreach (var mapInfoDimensionDto in dimentions)
                    {
                        var middlePoints = mapInfoDimensionService.GetMiddlePointsForDimension(mapInfoDimensionDto.Id);
                        mapManager.AddDimention(mapInfoDimensionDto.Id, middlePoints);

                        var dimentionRadiuses =
                            dimentionRadiusService.GetAll().Where(x => x.MapInfoDimension == mapInfoDimensionDto.Id);
                        foreach (var dimentionRadiuDto in dimentionRadiuses)
                        {
                            var neighbors =
                                middlePointNeighborsService.GetMiddlePointNeighborsByDimentionRadius(
                                    dimentionRadiuDto.Id);
                            mapManager.AddDimentionRadius(mapInfoDimensionDto.Id, dimentionRadiuDto.Id, neighbors);
                        }
                    }
                    return mapManager;
                });
            return retVal;
        }
    }
}