using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.Utils
{
    public static class ColorHelper
    {
        private static Random randomGen;

        static ColorHelper()
        {
            randomGen = new Random();
        }

        public static Color GetRandomColor()
        {
            
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            return Color.FromKnownColor(randomColorName);
        }
    }
}