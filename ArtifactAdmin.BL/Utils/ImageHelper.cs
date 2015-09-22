using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using ArtifactAdmin.BL.MapHelpers;

namespace ArtifactAdmin.BL.Utils
{
    public static class ImageHelper
    {
        public static List<string> GetAllColorsFromImage(string imagePath)
        {
            var colors = new List<Color>();
            var bitmap = (Bitmap) Image.FromFile(imagePath);
            var width = bitmap.Width;
            var height = bitmap.Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (!colors.Contains(bitmap.GetPixel(x, y)))
                    {
                        colors.Add(bitmap.GetPixel(x, y));
                    }
                }
            }
            return colors.Select(x => HexConverter(x).ToLower().Trim()).ToList();
        }

        public static Stream ToStream(this Image image, ImageFormat formaw)
        {
            var stream = new System.IO.MemoryStream();
            image.Save(stream, formaw);
            stream.Position = 0;
            return stream;
        }

        public static String HexConverter(System.Drawing.Color c)
        {
            String rtn = String.Empty;
            try
            {
                rtn = "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
            }
            catch (Exception ex)
            {
                //doing nothing
            }

            return rtn.ToLower().Trim();
        }

        public static Dictionary<string, LinesContainer> CreateLinesFromImage(string imagePath)
        {
            var bitmap = (Bitmap)Image.FromFile(imagePath);
            var width = bitmap.Width;
            var height = bitmap.Height;

            var zoneLines = new Dictionary<string, LinesContainer>();

            for (int y = 0; y < height; y++)
            {
                var line = new LineOfPoints();
                line.Y = y;
                string previousColor = null;
                for (int x = 0; x < width; x++)
                {
                    line.Y = y;
                    var colorName = ImageHelper.HexConverter(bitmap.GetPixel(x, y));

                    if (previousColor == null)
                    {
                        previousColor = colorName;
                        line.StartX = 0;
                    }
                    if (colorName == previousColor)
                    {
                        line.EndX = x;
                    }
                    else
                    {
                        AddLine(line, zoneLines, previousColor);
                        line = new LineOfPoints()
                        {
                            Y = y,
                            StartX = x,
                            EndX = x
                        };
                        previousColor = colorName;
                    }
                }
                AddLine(line, zoneLines, previousColor);
            }
            return zoneLines;
        }

        private static void AddLine(LineOfPoints line, Dictionary<string, LinesContainer> dic, string color)
        {
            if (!dic.ContainsKey(color))
            {
                dic.Add(color, new LinesContainer());
            }
            dic[color].Lines.Add(line);
        }
    }
}