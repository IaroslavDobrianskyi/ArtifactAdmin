using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinder
{
    public sealed class Route
    {
        public Route(Point start, Point end)
        {
            _start = start;
            _end = end;

            var xLength = Math.Abs(_end.X - _start.X);
            var yLength = Math.Abs(_end.Y - _start.Y);

            if (xLength < yLength)
            {
                Invers = true;
            }

            _xLength = Math.Abs(xLength);
            _yLength = Math.Abs(yLength);
        }

        public Point StartPoint
        {
            get
            {
                return Invers ? new Point(_start.Y, _start.X) : new Point(_start.X, _start.Y);
            }
        }

        public Point EndPoint
        {
            get
            {
                return Invers ? new Point(_end.Y, _end.X) : new Point(_end.X, _end.Y);
            }
        }

        public Double XLength
        {
            get
            {
                return Invers ? _yLength : _xLength;
            }
        }

        public Double YLength
        {
            get
            {
                return Invers ? _xLength : _yLength;
            }
        }

        public bool Invers { get; private set; }

        public LinkedList<Point> HelpPoints { get; set; }

        public Point[] GetFullPath()
        {
            return GetFullPath(HelpPoints);
        }

        public Point[] GetPointsForBeziers()
        {
            var pointsCount = HelpPoints.Count + 2;
            int needPoints = 0;
            for (int i = pointsCount; i >= 4; i--)
            {
                if ((i - 1) % 3 == 0)
                {
                    needPoints = i;
                    break;
                }
            }

            var newHelpPointColl = new LinkedList<Point>(HelpPoints);
            while (newHelpPointColl.Count != needPoints - 2 && HelpPoints.Count > 0)
            {
                newHelpPointColl.RemoveLast();
            }

            return GetFullPath(newHelpPointColl);
        }

        private Point[] GetFullPath(LinkedList<Point> helpPoints)
        {
            if (helpPoints == null) throw new ArgumentNullException("helpPoints");
            var count = helpPoints.Count + 2;
            var points = new Point[count];
            helpPoints.CopyTo(points, 1);
            points[0] = _start;
            points[count - 1] = _end;

            return points;
        }

        private Point _start;
        private Point _end;
        private int _xLength;
        private int _yLength;
    }
}
