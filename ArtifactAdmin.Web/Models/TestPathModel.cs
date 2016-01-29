using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;

namespace ArtifactAdmin.Web.Models
{
    public class TestPathModel
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public double WMax { get; set; }
        public double WMin { get; set; }
        public double AMax { get; set; }
        public double AMin { get; set; }
        public double ProbMax { get; set; }
        public double ProbMin { get; set; }
        public double SkipPtsMax { get; set; }
        public double SkipPtsMin { get; set; }
    }
}