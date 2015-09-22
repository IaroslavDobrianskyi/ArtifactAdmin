using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.Web.Models
{
    public class MapInfoDimensionCreateModel
    {
        public MapInfoDimensionDto MapInfoDimensionDto { get; set; }
        public IEnumerable<MapInfoDto> AvailableMapInfos { get; set; }
    }
}