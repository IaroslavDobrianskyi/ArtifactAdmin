﻿namespace ArtifactAdmin.BL.MapHelpers
{
    using System;
    using System.Collections.Generic;

    public class MapPointBase
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int ZoneId { get; set; }
    }

    public class MapPoint : MapPointBase
    {
        public Dictionary<int, bool> IsMiddlePoint { get; set; }
        public Dictionary<int, MapPoint> NearestMiddlePoint { get; set; }
        public Dictionary<int, Dictionary<int, List<MapPoint>>> MiddlePointsNeighbors { get; set; }

        public MapPoint()
        {
            IsMiddlePoint = new Dictionary<int, bool>();
            NearestMiddlePoint = new Dictionary<int, MapPoint>();
            MiddlePointsNeighbors = new Dictionary<int, Dictionary<int, List<MapPoint> >>();
        }

        internal void SetAsMiddlePoint(int dimensionId)
        {
            if (IsMiddlePoint.ContainsKey(dimensionId))
            {
                throw new Exception(string.Format(
                    "this middle point({0},{1}) is already existed in this dimention({2})",
                    X, Y, dimensionId));
            }
            else
            {
                IsMiddlePoint.Add(dimensionId, true);
            }
        }

        internal void SetNearestMiddlePoint(int dimensionId, MapPoint middlePoint)
        {
            if (NearestMiddlePoint.ContainsKey(dimensionId))
            {
                throw new Exception(string.Format(
                    "this middle point({0},{1}) is already existed in this dimention({2})",
                    X, Y, dimensionId));
            }
            else
            {
                NearestMiddlePoint.Add(dimensionId, middlePoint);
            }
        }

        internal void SetMiddlePointNeighbors(int dimentionId, int radiusId, List<MapPoint> list)
        {
            if (!MiddlePointsNeighbors.ContainsKey(dimentionId))
            {
                MiddlePointsNeighbors.Add(dimentionId, new Dictionary<int, List<MapPoint>>());
            }
            if (!MiddlePointsNeighbors[dimentionId].ContainsKey(radiusId))
            {
                MiddlePointsNeighbors[dimentionId].Add(radiusId,new List<MapPoint>());
            }
            MiddlePointsNeighbors[dimentionId][radiusId] = list;
        }
    }
}