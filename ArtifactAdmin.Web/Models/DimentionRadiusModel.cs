using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.Web.Models
{
    public class DimentionRadiusModel
    {
        public DimentionRadiuDto DimentionRadiuDto { get; set; }
        public IList<MapInfoAndDimensionModel> AvailableMapInfoDimensionDtos { get; set; }

        public DimentionRadiusModel()
        {
            AvailableMapInfoDimensionDtos = new List<MapInfoAndDimensionModel>();
        }
    }

    public class DimentionRadiusModelDetails
    {
        public DimentionRadiuDto DimentionRadiuDto { get; set; }
        [Display(Name = "Кількість середніх точок")]
        public int Count { get; set; }
        [Display(Name = "Активна середня точка")]
        public int Index { get; set; }
        
    }
}