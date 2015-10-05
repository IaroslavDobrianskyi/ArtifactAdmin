using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.Web.Models
{
    public class MapInfoDimensionCreateModel
    {
        public MapInfoDimensionDto MapInfoDimensionDto { get; set; }
        public IEnumerable<MapInfoDto> AvailableMapInfos { get; set; }
    }
}