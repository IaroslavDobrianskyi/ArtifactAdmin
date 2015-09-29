using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.DAL.Models;

namespace ArtifactAdmin.BL.Utils.GeneratingMiddlePoints
{
    public static class NeighborMiddlePointsGenerator
    {
        public static string GetNeighbors(MiddlePointDto middlePoint, List<MiddlePointDto> allMiddlePoints, int radius)
        {
            var neighbors = new List<SimplePoint>();
            foreach (var point in allMiddlePoints)
            {
                if (Math.Abs(point.X - middlePoint.X) < radius &&
                    Math.Abs(point.Y - middlePoint.Y) < radius)
                {
                    neighbors.Add(new SimplePoint()
                        {
                            X = point.X,
                            Y = point.Y
                        });
                }
            }
            var sb = new StringBuilder();
            var count = neighbors.Count;
            for (int i = 0; i < count; i++)
            {
                sb.Append(neighbors[i].ToString());
                if (i != count - 1)
                {
                    sb.Append("|");
                }
                
            }
            return sb.ToString();
        }

        public static List<SimplePoint> GetNeighbors(string serializedString)
        {
            var retVal = new List<SimplePoint>();
            var neighors = serializedString.Split('|');
            foreach (var neighor in neighors)
            {
                retVal.Add(SimplePoint.CreateFrom(neighor));
            }
            return retVal;
        }
    }
}