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
    }
}