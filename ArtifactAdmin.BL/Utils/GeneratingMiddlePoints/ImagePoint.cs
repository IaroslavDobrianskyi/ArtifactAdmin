using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.Utils.GeneratingMiddlePoints
{
    public class ImagePoint
    {
        public SimplePoint Point { get; set; }
        public ImagePoint Left { get; set; }
        public ImagePoint Right { get; set; }
        public ImagePoint Up { get; set; }
        public ImagePoint Down { get; set; }

        public override bool Equals(object obj)
        {
            return Point.Equals(((ImagePoint)obj).Point);
        }

        public override int GetHashCode()
        {
            return Point.GetHashCode();
        }
    }
}