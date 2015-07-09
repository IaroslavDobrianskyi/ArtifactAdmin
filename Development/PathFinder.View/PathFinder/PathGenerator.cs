using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text.RegularExpressions;

namespace PathFinder
{
    public sealed class PathGenerator
    {
        public const int OscillationFrequencyDef = 1;
        public const int AmplitudeFluctuationsDef = 10;
        public const int MinIntervalWidthDef = 5;
        public const int ProbabilityDef = 5;

        public int OscillationFrequency
        {
            get
            {
                return _oscillationFrequency == 0 ? OscillationFrequencyDef : _oscillationFrequency;
            }
            set
            {
                _oscillationFrequency = value;
            }
        }

        public int AmplitudeFluctuations
        {
            get
            {
                return _amplitudeFluctuations == 0 ? AmplitudeFluctuationsDef : _amplitudeFluctuations;
            }
            set
            {
                _amplitudeFluctuations = value;
            }
        }

        public int MinIntervalWidth
        {
            get
            {
                return _minIntervalWidth == 0 ? MinIntervalWidthDef : _minIntervalWidth;
            }
            set
            {
                _minIntervalWidth = value;
            }
        }

        public Route GetPath(Map map, List<Point> points, int probability = ProbabilityDef)
        {
            var listRotes = new List<Route>();
            for (int index = 0; index + 1 < points.Count; index++)
            {
                var startPoint = points[index];
                var endPoint = points[index + 1];
                listRotes.Add(GetPath(map, startPoint, endPoint, probability));
            }

            var resultRoute = new Route(points.First(), points.Last());
            var helpPointsForResultRoute = new List<Point>();

            var en = listRotes.GetEnumerator();
            var canMove = en.MoveNext();

            while (canMove)
            {
                var currRoute = en.Current;

                helpPointsForResultRoute.AddRange(currRoute.HelpPoints);
                if (canMove = en.MoveNext())
                {
                    helpPointsForResultRoute.Add(currRoute.EndPoint);
                }
            }
            resultRoute.HelpPoints = new LinkedList<Point>(helpPointsForResultRoute);

            return resultRoute;
        }

        public Route GetPath(Map map, Point startPoint, Point endPoint, int probability = ProbabilityDef)
        {
            var route = new Route(startPoint, endPoint);

            if (!ValidateRoute(route, map))
            {
                throw new ArgumentException("Incorect map or route");
            }

            var filterMatrix = new List<Tuple<Point, int>>();
            var lineAngle = Math.Atan((endPoint.Y - startPoint.Y * 1.0) / (endPoint.X - startPoint.X));

            int startX, endX;
            bool reversVal = false;

            if (startPoint.X > endPoint.X)
            {
                endX = startPoint.X + 1;
                startX = endPoint.X;
                reversVal = true;
            }
            else
            {
                endX = endPoint.X;
                startX = startPoint.X + 1;
            }

            for (int i = startX; i < endX; i++)
            {
                var nextPoint = GetNextPoint(i, route, lineAngle);
                if (ValidatePoint(map, nextPoint))
                {
                    var filterMarker = new Tuple<Point, int>(nextPoint, probability);
                    filterMatrix.Add(filterMarker);
                }
            }

            if (reversVal)
            {
                filterMatrix.Reverse();
            }

            route.HelpPoints = FilterPath(filterMatrix);

            return route;
        }

        private bool ValidatePoint(Map map, Point point)
        {
            return point.X <= map.Width && point.Y <= map.Height;
        }

        private bool ValidateRoute(Route route, Map map)
        {
            if (!(ValidatePoint(map, route.EndPoint) && ValidatePoint(map, route.StartPoint))) return false;
            return true;
        }

        private Point GetNextPoint(int nextX, Route route, double lineAngle)
        {
            var nextPoint = new Point();
            var newX = nextX;
            var nextY = GetNextY(route, ref newX, lineAngle);

            nextPoint.X = newX;
            nextPoint.Y = nextY;

            return nextPoint;
        }

        private LinkedList<Point> FilterPath(List<Tuple<Point, int>> filterMatrix)
        {
            var result = new LinkedList<Point>();
            var rand = new Random();
            var index = 0;

            while (index < filterMatrix.Count)
            {
                if (filterMatrix[index].Item2 >= rand.Next(RandValue))
                {
                    result.AddLast(filterMatrix[index].Item1);
                    ++index;
                }
                else
                {
                    index += MinIntervalWidth;
                }
            }

            return result;
        }

        private int GetNextY(Route route, ref int nextX, double lineAngle)
        {
            var angle = GetAngle(nextX, route.XLength);
            int helpVal = 1, helpVal2 = 1;

            if (route.EndPoint.Y < route.StartPoint.Y || route.StartPoint.X > route.EndPoint.X)
            {
                helpVal = -1;
            }

            if (route.EndPoint.X < route.StartPoint.X)
            {
                helpVal2 = -1;
            }

            if (route.StartPoint.X > route.EndPoint.X && route.StartPoint.Y > route.EndPoint.Y)
            {
                helpVal2 = helpVal = 1;
            }

            var nextY = helpVal * (route.YLength / route.XLength) * nextX +
                        helpVal2 * (route.StartPoint.Y * route.EndPoint.X - route.EndPoint.Y * route.StartPoint.X) / route.XLength;

            var amplituda = AmplitudeFluctuations * Math.Sin(angle);

            nextY += amplituda * Math.Sign(Math.PI / 2 - lineAngle);
            nextX -= Convert.ToInt32(Math.Round(amplituda * Math.Cos(Math.PI / 2 - lineAngle)));

            return Convert.ToInt32(Math.Round(nextY));
        }

        private double GetAngle(int nextX, double routeXLength)
        {
            return (2 * Math.PI * nextX * OscillationFrequency) / routeXLength;
        }

        private const int RandValue = 100;
        private int _oscillationFrequency;
        private int _amplitudeFluctuations;
        private int _minIntervalWidth;
    }
}
