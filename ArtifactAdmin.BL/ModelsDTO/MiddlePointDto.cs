using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class MiddlePointDto
    {    
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string RelatedCoordinates { get; set; }
        public int MapInfoDimension { get; set; }
    
        public virtual MapInfoDimensionDto MapInfoDimension1 { get; set; }
        public virtual ICollection<MiddlePointNeighborDto> MiddlePointNeighbors { get; set; }
    }
}