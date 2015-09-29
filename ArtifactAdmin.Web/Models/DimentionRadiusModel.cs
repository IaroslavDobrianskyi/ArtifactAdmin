using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.Web.Models
{
    public class DimentionRadiusModel
    {
        public DimentionRadiuDto DimentionRadiuDto { get; set; }
        public IEnumerable<MapInfoAndDimensionModel> AvailableMapInfoDimensionDtos { get; set; }
    }
}