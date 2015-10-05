using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArtifactAdmin.BL.ModelsDTO
{
    public class DimentionRadiuDto
    {
    
        public int Id { get; set; }
        public int MapInfoDimension { get; set; }
        [Display(Name = "Радіус виміру")]
        public int Radius { get; set; }
    
        public virtual MapInfoDimensionDto MapInfoDimension1 { get; set; }
        public virtual ICollection<MiddlePointNeighborDto> MiddlePointNeighbors { get; set; }
    }
}