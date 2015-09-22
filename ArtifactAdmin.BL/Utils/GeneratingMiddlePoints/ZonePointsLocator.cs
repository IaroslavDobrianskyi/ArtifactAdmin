using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.Utils.GeneratingMiddlePoints
{
    public class ZonePointsLocator
    {
        private Color activeColor;
        private Bitmap bitmap;
        public Dictionary<SimplePoint, ImagePoint> AllPoints { get; set; }
        private List<SimplePoint> proceedList;
        public List<SimplePoint> BorderPoints { get; set; }
        public List<SimplePoint> MiddlePoints { get; set; }
        public SimplePoint CentralPoint { get; set; }
        private int xMin;
        private int xMax;
        private int yMin;
        private int yMax;
        private int w;
        private bool[,] proceedMatrix;

        public void LoadPoints(SimplePoint startPoint, Bitmap bitmap, int w, bool[,] proceedMatrix)
        {
            this.proceedMatrix = proceedMatrix;
            AllPoints = new Dictionary<SimplePoint, ImagePoint>();
            this.bitmap = bitmap;
            this.w = w;
            activeColor = bitmap.GetPixel(startPoint.X, startPoint.Y);
            proceedList = new List<SimplePoint>();
            proceedList.Add(startPoint);
            WorkOnProceedList();

            BorderPoints = new List<SimplePoint>();
            foreach (ImagePoint val in AllPoints.Values)
            {
                if (val.Left == null || val.Right == null || val.Up == null || val.Down == null)
                {
                    BorderPoints.Add(val.Point);
                }
            }

            LocateCentralPoint();
            LocateMiddlePoints();
        }

        private void LocateMiddlePoints()
        {
            MiddlePoints = new List<SimplePoint>();

            var nxmin = (CentralPoint.X - xMin) / w + 1;
            var nxmax = (xMax - CentralPoint.X) / w + 1;
            var nymin = (CentralPoint.Y - yMin) / w + 1;
            var nymax = (yMax - CentralPoint.Y) / w + 1;

            var xkmin = CentralPoint.X - w * nxmin;
            var xkmax = CentralPoint.X + w * nxmax;
            var ykmin = CentralPoint.Y - w * nymin;
            var ykmax = CentralPoint.Y + w * nymax;

            for (int x = xkmin; x <= xkmax; x = x + w)
            {
                for (int y = ykmin; y <= ykmax; y = y + w)
                {
                    if (AllPoints.ContainsKey(new SimplePoint()
                    {
                        X = x,
                        Y = y
                    }))
                    {
                        MiddlePoints.Add(new SimplePoint()
                        {
                            X = x,
                            Y = y
                        });
                    }
                }
            }

        }

        private void LocateCentralPoint()
        {
            CentralPoint = null;
            var bCount = BorderPoints.Count;
            var widths = new List<float>(bCount);
            for (int i = 0; i < bCount; i++)
            {
                widths.Add(0);
            }
            var minImagePointK = float.MaxValue;
            float ki = 0;
            foreach (var imagePoint in AllPoints.Values)
            {
                float widthsSum = 0;
                var minWidthsValue = float.MaxValue;
                for (int i = 0; i < bCount; i++)
                {
                    widths[i] =
                        (float)Math.Sqrt((imagePoint.Point.X - BorderPoints[i].X) * (imagePoint.Point.X - BorderPoints[i].X) +
                                  (imagePoint.Point.Y - BorderPoints[i].Y) * (imagePoint.Point.Y - BorderPoints[i].Y));
                    widthsSum += widths[i];
                    if (widths[i] < minWidthsValue)
                    {
                        minWidthsValue = widths[i];
                    }
                }
                if (widthsSum - bCount * minWidthsValue < minImagePointK)
                {
                    minImagePointK = widthsSum - bCount * minWidthsValue;
                    CentralPoint = imagePoint.Point;
                }
            }


        }

        private void WorkOnProceedList()
        {

            while (proceedList.Count != 0)
            {
                var currentPoint = proceedList[0];

                if (currentPoint.X >= 0 && currentPoint.X < bitmap.Width &&
                    currentPoint.Y >= 0 && currentPoint.Y < bitmap.Height)
                {
                    Color color = bitmap.GetPixel(currentPoint.X, currentPoint.Y);
                    if (activeColor.R == color.R &&
                        activeColor.G == color.G &&
                        activeColor.B == color.B &&
                        !AllPoints.ContainsKey(currentPoint)
                        )
                    {
                        AddPoint(currentPoint);
                        TryAddNextSimplePoint(new SimplePoint() { X = currentPoint.X, Y = currentPoint.Y - 1 });
                        TryAddNextSimplePoint(new SimplePoint() { X = currentPoint.X, Y = currentPoint.Y + 1 });
                        TryAddNextSimplePoint(new SimplePoint() { X = currentPoint.X - 1, Y = currentPoint.Y });
                        TryAddNextSimplePoint(new SimplePoint() { X = currentPoint.X + 1, Y = currentPoint.Y });
                    }
                    proceedMatrix[proceedList[0].X, proceedList[0].Y] = true;
                }
                proceedList.RemoveAt(0);
            }
        }

        private void TryAddNextSimplePoint(SimplePoint simplePoint)
        {
            if (!AllPoints.ContainsKey(simplePoint) && !proceedList.Contains(simplePoint))
            {
                proceedList.Add(simplePoint);
            }
        }

        private void AddPoint(SimplePoint simplePoint)
        {
            var imagePoint = new ImagePoint()
            {
                Point = simplePoint,
                Left = TryGetImagePoint(new SimplePoint() { X = simplePoint.X - 1, Y = simplePoint.Y }),
                Right = TryGetImagePoint(new SimplePoint() { X = simplePoint.X + 1, Y = simplePoint.Y }),
                Up = TryGetImagePoint(new SimplePoint() { X = simplePoint.X, Y = simplePoint.Y - 1 }),
                Down = TryGetImagePoint(new SimplePoint() { X = simplePoint.X, Y = simplePoint.Y + 1 }),
            };
            if (imagePoint.Left != null) imagePoint.Left.Right = imagePoint;
            if (imagePoint.Right != null) imagePoint.Right.Left = imagePoint;
            if (imagePoint.Up != null) imagePoint.Up.Down = imagePoint;
            if (imagePoint.Down != null) imagePoint.Down.Up = imagePoint;

            AllPoints.Add(simplePoint, imagePoint);
            if (simplePoint.X < xMin) xMin = simplePoint.X;
            if (xMax < simplePoint.X) xMax = simplePoint.X;
            if (simplePoint.Y < yMin) yMin = simplePoint.Y;
            if (yMax < simplePoint.Y) yMax = simplePoint.Y;
        }

        private ImagePoint TryGetImagePoint(SimplePoint simplePoint)
        {
            ImagePoint retVal = null;
            if (AllPoints.ContainsKey(simplePoint))
            {
                retVal = AllPoints[simplePoint];
            }
            return retVal;
        }
    }
}