using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class MiddlePointNeighborDto
    {
        public int Id { get; set; }
        public int DimensionRadius { get; set; }
        public string NeighborCoordinates { get; set; }
        public int MiddlePoint { get; set; }

        public virtual DimentionRadiuDto DimentionRadiu { get; set; }
        public virtual MiddlePointDto MiddlePoint1 { get; set; }
    }
}