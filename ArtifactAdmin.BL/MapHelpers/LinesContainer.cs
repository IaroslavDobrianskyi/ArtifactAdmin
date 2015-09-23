﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ArtifactAdmin.BL.MapHelpers
{
    public class LinesContainer
    {
        public List<LineOfPoints> Lines { get; set; }
        
        public LinesContainer()
        {
            Lines = new List<LineOfPoints>();
        }

        public static LinesContainer Deserialize(string serializedString)
        {
            var retVal = new LinesContainer();
            var stringLines = serializedString.Split(';');
            foreach (var line in stringLines)
            {
                var vals = line.Trim('|').Split(',');
                retVal.Lines.Add(new LineOfPoints()
                    {
                        Y = int.Parse(vals[0]),
                        StartX = int.Parse(vals[1]),
                        EndX = int.Parse(vals[2])
                    });
            }
            return retVal;
        }

        public string Serialize()
        {
            var sb = new StringBuilder();
            var count = Lines.Count();
            for (int i = 0; i < count; i++)
            {
                sb.Append(string.Format("|{0},{1},{2}|{3}", Lines[i].Y, Lines[i].StartX, Lines[i].EndX,i==count - 1 ? "" : ";"));
            }
            return sb.ToString();
        }

    }
}