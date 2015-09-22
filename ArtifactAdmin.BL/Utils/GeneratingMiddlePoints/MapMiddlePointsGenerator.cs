using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using ArtifactAdmin.BL.MapHelpers;

namespace ArtifactAdmin.BL.Utils.GeneratingMiddlePoints
{
    public static class MapMiddlePointsGenerator
    {
        public static Dictionary<SimplePoint,LinesContainer> GetMiddlePoints(string imagePath, int mapDimension)
        {
            var bitmap = (Bitmap)Image.FromFile(imagePath);
            var list = GetSimplePoint(bitmap, mapDimension);
            var width = bitmap.Width;
            var height = bitmap.Height;
            var relatedCoordinatesMatrix = new SimplePoint[width, height];

            double sqrt = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var minDistance = double.MaxValue;
                    SimplePoint point = null;
                    foreach (var simplePoint in list)
                    {
                        sqrt = Math.Sqrt((x - simplePoint.X)*(x - simplePoint.X) +
                                         (y - simplePoint.Y)*(y - simplePoint.Y));
                        if ( sqrt < minDistance)
                        {
                            point = simplePoint;
                            minDistance = sqrt;
                        }
                    }

                    relatedCoordinatesMatrix[x, y] = new SimplePoint()
                        {
                            X = point.X,
                            Y = point.Y
                        };   
                }
            }

            var retVal = new Dictionary<SimplePoint, LinesContainer>();

            for (int y = 0; y < height; y++)
            {
                var line = new LineOfPoints();
                line.Y = y;
                SimplePoint previousSimplePoint = null;
                for (int x = 0; x < width; x++)
                {
                    line.Y = y;

                    if (previousSimplePoint == null)
                    {
                        previousSimplePoint = relatedCoordinatesMatrix[x, y];
                        line.StartX = 0;
                    }
                    if (relatedCoordinatesMatrix[x, y].X == previousSimplePoint.X && relatedCoordinatesMatrix[x, y].Y == previousSimplePoint.Y)
                    {
                        line.EndX = x;
                    }
                    else
                    {
                        AddLine(line, retVal, previousSimplePoint);
                        line = new LineOfPoints()
                        {
                            Y = y,
                            StartX = x,
                            EndX = x
                        };
                        previousSimplePoint = relatedCoordinatesMatrix[x, y];
                    }
                }
                AddLine(line, retVal, previousSimplePoint);
            }
            return retVal;
        }

        private static void AddLine(LineOfPoints line, Dictionary<SimplePoint, LinesContainer> dic, SimplePoint simplePoint)
        {
            if (!dic.ContainsKey(simplePoint))
            {
                dic.Add(simplePoint, new LinesContainer());
            }
            dic[simplePoint].Lines.Add(line);
        }

        private static List<SimplePoint> GetSimplePoint(Bitmap bitmap, int mapDimension)
        {
            var retVal = new List<SimplePoint>();
            var width = bitmap.Width;
            var height = bitmap.Height;

            var proceedMatrix = new bool[width, height];

            //for (int x = 0; x < width; x++)
            //{
            //    for (int y = 0; y < height; y++)
            //    {
            //        if (bitmap.GetPixel(x, y) == Color.White)
            //        {
            //            proceedMatrix[x, y] = true;
            //        }
            //    }
            //}

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (!proceedMatrix[x, y])
                    {

                        var zonePointsLocator = new ZonePointsLocator();
                        zonePointsLocator.LoadPoints(new SimplePoint()
                        {
                            X = x,
                            Y = y
                        },
                                            bitmap,
                                            mapDimension,
                                            proceedMatrix
                            );

                        retVal.AddRange(zonePointsLocator.MiddlePoints);
                    }
                }
            }

            return retVal;
        }
    }
}