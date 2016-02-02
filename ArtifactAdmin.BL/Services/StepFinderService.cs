using System;
using System.Collections.Generic;


namespace ArtifactAdmin.BL.Services
{
    using Interfaces;
    using ModelsDTO;
    using ModelsDTO.FlowItems;
    using System.Windows;

    public class StepFinderService : IStepFinderService
    {
        public StepCreationInfo GetNewKeyStepInfo(CarrierDesireDto carrierDesire, System.Windows.Point previousStepCoordinates)
        {
            throw new NotImplementedException();
        }

        public List<StepCreationInfo> GetIntermediateStepCoords(StepDto lastStep, StepCreationInfo newKeyStepCoords)
        {
            throw new NotImplementedException();
        }

        public List<Point> GetPathPoints()
        {
            var list = GetSimplePoints();

            return list;
        }

        #region Simple Points Calculation -- Only for test visualization

        private List<Point> GetSimplePoints()
        {
            //Input
            Random rand = new Random();
            var start = new Point(100, 100);
            var end = new Point(900, 900);
            double W = GenRandom(rand, 50, 80);
            double A = GenRandom(rand, 100, 200);
            double probability = GenRandom(rand, 1, 10);
            int skipPts = GenRandom(rand, 50, 100);

            /////////////
            ///Begin algorithm
            /////////////

            //Lets go always from lowest X
            if (start.X > end.X)
            {
                var pt = start;
                start = end;
                end = pt;
            }

            double dX = end.X - start.X;
            double dY = end.Y - start.Y;
            double len = Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2));

            List<Point> pathPoints = new List<Point>();

            //Always start in (0;0)
            double xToRotate = 0;

            //Calculate angle
            double alpha = Math.Atan(dY / dX);
            double lenFromAlpha = len * Math.Cos(alpha);

            while (xToRotate <= lenFromAlpha)
            {
                //Rotate
                double yToRotate = xToRotate * Math.Tan(alpha);
                Point rotated = RotatePoint(new Point(xToRotate, yToRotate), new Point(0, 0), -alpha);

                //Calculate Sin
                double y0 = A * (Math.Sin(2 * Math.PI * W * rotated.X / len));

                //Rotate back
                Point rotatedBack = RotatePoint(new Point(rotated.X, y0), new Point(0, 0), alpha);

                //Back from (0,0) to real coordinates
                pathPoints.Add(new Point(start.X + rotatedBack.X, start.Y + rotatedBack.Y));

                xToRotate = xToRotate + 1 * Math.Cos(alpha);
            }

            var flowPoints = new List<Point>();
            flowPoints.Add(start);
            for (int i = 0; i < pathPoints.Count; ++i)
            {
                int randNum = rand.Next(100);
                if (probability >= randNum)
                {
                    flowPoints.Add(new Point(Math.Round(pathPoints[i].X), Math.Round(pathPoints[i].Y)));
                    i = i + skipPts;
                }
            }
            flowPoints.Add(end);

            //TODO: Think on sorting(points should be sorted from start to end). Sorting looks time consuming
            //flowPoints = flowPoints.OrderBy(pt => pt.X).ToList();

            /////////////
            ///End algorithm
            /////////////

            return flowPoints;
        }

        private int GenRandom(Random rand, int min, int max)
        {
            return min + rand.Next(Math.Abs(max - min));
        }

        private Point RotatePoint(Point pointToRotate, Point centerPoint, double angleInRadians)
        {
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new Point
            {
                X =
                    (cosTheta * (pointToRotate.X - centerPoint.X) -
                    sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                Y =
                    (sinTheta * (pointToRotate.X - centerPoint.X) +
                    cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)
            };
        }

        #endregion
    }
}