using System;
using System.Collections.Generic;
using ArtifactAdmin.BL.Utils.GeneratingMiddlePoints;

namespace ArtifactAdmin.BL.MapHelpers
{
    public class MapManager
    {
        public string MapName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public MapPoint[,] mapPoints;
        public Dictionary<int, List<int>> AvailableDimentionAndRadiuses { get; set; }

        public MapManager(int width, int height)
        {
            mapPoints = new MapPoint[width,height];
            Width = width;
            Height = height;
            AvailableDimentionAndRadiuses = new Dictionary<int, List<int>>();
        }

        public void InitZoneCoordinates(int zoneId, List<SimplePoint> zonePoints)
        {
            foreach (var simplePoint in zonePoints)
            {
                mapPoints[simplePoint.X,simplePoint.Y] = new MapPoint()
                    {
                        X = simplePoint.X,
                        Y = simplePoint.Y,
                        ZoneId = zoneId
                    };
            }
        }

        public void AddDimention(int dimensionId, Dictionary<SimplePoint, List<SimplePoint>> middlePointsRelatedCoordinates)
        {
            var middlePoints = middlePointsRelatedCoordinates.Keys;
            foreach (var middlePoint in middlePoints)
            {
                var relatedCoordinates = middlePointsRelatedCoordinates[middlePoint];
                mapPoints[middlePoint.X, middlePoint.Y].SetAsMiddlePoint(dimensionId);
                foreach (var relatedCoordinate in relatedCoordinates)
                {
                    mapPoints[relatedCoordinate.X, relatedCoordinate.Y].SetNearestMiddlePoint(dimensionId, mapPoints[middlePoint.X, middlePoint.Y]);
                }
            }
            if (!AvailableDimentionAndRadiuses.ContainsKey(dimensionId))
            {
                AvailableDimentionAndRadiuses.Add(dimensionId, new List<int>());
            }
        }

        public void AddDimentionRadius(int dimensionId, int radiusId,
                              Dictionary<SimplePoint, List<SimplePoint>> middlePointsNeighborCoordinates)
        {
            var middlePoints = middlePointsNeighborCoordinates.Keys;
            var listOfMapPoints = new List<MapPoint>();
            foreach (var middlePoint in middlePoints)
            {
                var simplePoints = middlePointsNeighborCoordinates[middlePoint];
                foreach (var simplePoint in simplePoints)
                {
                    listOfMapPoints.Add(mapPoints[simplePoint.X, simplePoint.Y]);
                }

                mapPoints[middlePoint.X, middlePoint.Y].SetMiddlePointNeighbors(dimensionId, radiusId, listOfMapPoints);
            }

            if (!AvailableDimentionAndRadiuses.ContainsKey(dimensionId))
            {
                AvailableDimentionAndRadiuses.Add(dimensionId, new List<int>());
            }
            AvailableDimentionAndRadiuses[dimensionId].Add(radiusId);
        }

        public List<MapPointBase> GetNeibhours(int dimantion, int radius, int x, int y)
        {
            throw new NotImplementedException();
        }

        public int GetZone(int x, int y)
        {
            return mapPoints[x, y].ZoneId;
        }
    }
}