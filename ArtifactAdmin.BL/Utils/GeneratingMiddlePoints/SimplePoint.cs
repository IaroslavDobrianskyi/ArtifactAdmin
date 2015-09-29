using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.Utils.GeneratingMiddlePoints
{
    public class SimplePoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            return X == ((SimplePoint)obj).X && Y == ((SimplePoint)obj).Y;
        }

        public override int GetHashCode()
        {
            return X + Y * 10000;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", X, Y);
        }

        public static SimplePoint CreateFrom(string neighor)
        {
            var strArray = neighor.Split(',');
            return new SimplePoint()
                {
                    X = int.Parse(strArray[0]),
                    Y = int.Parse(strArray[1])
                };
        }
    }
}